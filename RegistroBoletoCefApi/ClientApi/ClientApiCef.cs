using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using RegistroBoletoCefApi.ClientApi.IClientApi;
using RegistroBoletoCefApi.Models;
using RegistroBoletoCefApi.Models.CEF;
using RegistroBoletoCefApi.Models.Enum;

namespace RegistroBoletoCefApi.ClientApi
{
    /// <summary>
    /// Classe reponsável pelo cliente da CEF
    /// </summary>
    public class ClientApiCef : IClientApiCef
    {
        /// <summary>
        /// Automapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Configuration
        /// </summary>
        private readonly IConfiguration _configuration;


        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="mapper">Automapper</param>
        /// <param name="configuration">Configuration</param>
        public ClientApiCef(IMapper mapper,
                            IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }

        /// <summary>
        /// Realiza o registro de boleto no webservice da CEF
        /// </summary>
        /// <param name="solicitacao">Dados para solicitação <seealso cref="SolicitacaoDto"/></param>
        /// <returns>Dados de retorno do webservice da CEF <seealso cref="SolicitacaoRetornoDto"/></returns>
        public async Task<SolicitacaoRetornoDto> RegistrarBoleto(SolicitacaoDto solicitacao)
        {
            var xmlSolicitacaoRegistro = GerarXmlInclusaoBoleto(solicitacao);
            var document = new XmlDocument();
            document.LoadXml(xmlSolicitacaoRegistro);

            var dadosXmlRetorno = Helper.CallSoapWebRequest(_configuration["APPSETTINGS:CAIXAENDPOINT"],
                                                            document.InnerXml,
                                                            "INCLUI_BOLETO");

            var retornoWebService = Helper.XmlDeserialize<SoapEnvelopeSaida>(dadosXmlRetorno);

            var retorno = _mapper.Map<SolicitacaoRetornoDto>(solicitacao);
            retorno.XmlRetorno = dadosXmlRetorno;
            retorno.XmlSolicitacao = xmlSolicitacaoRegistro;
            retorno.CodigoBarras = retornoWebService.body.SERVICO_SAIDA.Dados.ControleNegocial.CodRetorno;
            retorno.LinhaDigitavel = retornoWebService.body.SERVICO_SAIDA.Dados.IncluiBoleto.LinhaDigitavel;
            retorno.ArquivoBoleto = Helper.DownloadArquivo(retornoWebService.body.SERVICO_SAIDA.Dados.IncluiBoleto.Url);

            return retorno;
        }
        
        /// <summary>
        /// Gera o xml da inclusão do boleto
        /// </summary>
        /// <param name="solicitacao">Dados da solicitação</param>
        /// <returns>XML</returns>
        private string GerarXmlInclusaoBoleto(SolicitacaoDto solicitacao)
        {
            var dadosXml = RetonarDadosXml(solicitacao);

            var xmlNameSpaces = new XmlSerializerNamespaces();
            xmlNameSpaces.Add("ext", "http://caixa.gov.br/sibar/manutencao_cobranca_bancaria/boleto/externo");
            xmlNameSpaces.Add("sib", "http://caixa.gov.br/sibar");

            var soapEnvelope = new SoapEnvelope
            {
                body = new ResponseBody<EnvioRemessaCefServicoEntrada>
                {
                    SERVICO_ENTRADA = dadosXml
                }
            };

            return Helper.XmlSerialize(soapEnvelope, xmlNameSpaces);
        }
        
        /// <summary>
        /// Retorna os dados necessários para geração do XML
        /// </summary>
        /// <param name="solicitacao">Dados da solicitação</param>
        /// <returns>Dados da entrada do boleto <seealso cref="EnvioRemessaCefServicoEntrada"/></returns>
        private static EnvioRemessaCefServicoEntrada RetonarDadosXml(SolicitacaoDto solicitacao)
        {
            var header = GerarHeader(solicitacao);
            var dadosInclusaoBoleto = GerarDadosInclusaoBoleto(solicitacao.CodigoBeneficiario);
            var dadosTitulo = GerarDadosTitulo(solicitacao);

            dadosTitulo.JurosMora = GerarDadosJuros(solicitacao.Juros);
            dadosTitulo.PosVencimento = GerarDadosPosVencimento(solicitacao.PosVencimento);
            dadosTitulo.Pagador = GerarDadosPagador(solicitacao.PessoaPagador);
            dadosTitulo.SacadorAvalista = GerarDadosSacadorAvalista(solicitacao.SacadorAvalista);
            dadosTitulo.FichaCompensacao = GerarDadosFichaCompensacao(solicitacao.InstrucaoBoleto);

            dadosInclusaoBoleto.Titulo = dadosTitulo;

            var dados = new EnvioRemessaCefDados
            {
                IncluiBoleto = dadosInclusaoBoleto
            };

            var dadosBoletoCef = new EnvioRemessaCefServicoEntrada()
            {
                Dados = dados,
                Header = header
            };
            return dadosBoletoCef;
        }

        /// <summary>
        /// Gera os dados do header
        /// </summary>
        /// <param name="solicitacao">Dados da solicitação</param>
        /// <returns>Header da solicitação <seealso cref="EnvioRemessaCefHeader"/></returns>
        private static EnvioRemessaCefHeader GerarHeader(SolicitacaoDto solicitacao)
        {
            var autenticacao = GerarHash(solicitacao);
            var header = new EnvioRemessaCefHeader
            {
                Versao = "2.1",
                Autenticacao = autenticacao,
                UsuarioServico = "SGCBS02P",
                Operacao = "INCLUI_BOLETO",
                SistemaOrigem = "SIGCB",
                DataHora = DateTime.Now.ToString("yyyyMMddHHmmss")
            };

            return header;
        }
        
        /// <summary>
        /// Gera o hash
        /// </summary>
        /// <param name="solicitacaoRegistro">Dados da solicitação</param>
        /// <returns>Hash</returns>
        private static string GerarHash(SolicitacaoDto solicitacaoRegistro)
        {
            var codigoBeneficiario = solicitacaoRegistro.CodigoBeneficiario.PadLeft(7, '0');
            var nossoNumero = $"14{solicitacaoRegistro.NossoNumero.PadLeft(15, '0')}";
            var dataVencimento = solicitacaoRegistro.DataVencimento.ToString("ddMMyyyy");
            var valor = solicitacaoRegistro.Valor.ToString("n2").Replace(".", "").Replace(",", "").PadLeft(15, '0');
            var documento = solicitacaoRegistro.CpfCnpjBeneficiario.PadLeft(14, '0');

            var valoresAutenticacao = $"{codigoBeneficiario}{nossoNumero}{dataVencimento}{valor}{documento}";

            return Helper.GetHashSha256(valoresAutenticacao);
        }

        /// <summary>
        /// Gera os dados do titulo
        /// </summary>
        /// <param name="solicitacao">Dados da solicitação do boleto</param>
        /// <returns>Dados do titulo <seealso cref="EnvioRemessaCefTitulo"/></returns>
        private static EnvioRemessaCefTitulo GerarDadosTitulo(SolicitacaoDto solicitacao)
        {
            var dadosTitulo = new EnvioRemessaCefTitulo
            {
                FlagAceite = "S",
                CodigoMoeda = 9, // Real brasileiro
                Valor = solicitacao.Valor,
                NossoNumero = Convert.ToInt64($"{14}{solicitacao.NossoNumero.PadLeft(15, '0')}"),
                TipoEspecie = solicitacao.Pagamento.TipoEspecie,
                NumeroDocumento = solicitacao.NumeroDocumento,
                DataVencimento = solicitacao.DataVencimento.ToString("yyyy-MM-dd"),
                DataEmissao = solicitacao.DataEmissao.ToString("yyyy-MM-dd")
            };

            return dadosTitulo;
        }

        /// <summary>
        /// Gera os dados dos juros
        /// </summary>
        /// <param name="juros">Dados do juros</param>
        /// <returns>Dados referentes ao juros <seealso cref="EnvioRemessaCefJurosMora"/></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static EnvioRemessaCefJurosMora GerarDadosJuros(DadosJuros juros)
        {
            var dadosJurosMora = new EnvioRemessaCefJurosMora();
            switch (juros.TipoJuros)
            {
                case null:
                case TipoJuros.Isento:
                    dadosJurosMora.Tipo = "ISENTO";
                    dadosJurosMora.Valor = 0;
                    return dadosJurosMora;
                case TipoJuros.TaxaMensal:
                    dadosJurosMora.Tipo = "TAXA_MENSAL";
                    dadosJurosMora.Percentual = juros.PercentualJuros;
                    return dadosJurosMora;
                case TipoJuros.ValorPorDia:
                    dadosJurosMora.Tipo = "VALOR_POR_DIA";
                    dadosJurosMora.Valor = juros.ValorJuros;
                    return dadosJurosMora;
                default:
                    throw new ArgumentOutOfRangeException(nameof(juros.TipoJuros), "Tipo de juros informado é inválido!");
            }
        }

        /// <summary>
        /// Gera os dados de pós vecimento do registro de boleto
        /// </summary>
        /// <param name="posVencimento">Dados do pós vencimento</param>
        /// <returns>Dados de pós vencimento <seealso cref="EnvioRemessaCefPosVencimento"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Ação pós vencimento inválida</exception>
        private static EnvioRemessaCefPosVencimento GerarDadosPosVencimento(DadosPosVencimento posVencimento)
        {
            var dadosPosVencimento = new EnvioRemessaCefPosVencimento();
            switch (posVencimento.PosVencimentoAcao)
            {
                case null:
                case PosVencimentoAcao.Devolver:
                    dadosPosVencimento.NumeroDias = 0;
                    dadosPosVencimento.Acao = "DEVOLVER";
                    break;
                case PosVencimentoAcao.Protestar:
                    dadosPosVencimento.Acao = "PROTESTAR";
                    dadosPosVencimento.NumeroDias = posVencimento.PosVencimentoNumeroDias;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(posVencimento.PosVencimentoAcao), "Ação pós vencimento inválida!");
            }

            return dadosPosVencimento;
        }

        /// <summary>
        /// Gera os dados do pagador
        /// </summary>
        /// <param name="dadosPagador">Dados do pagador</param>
        /// <returns>Dados do pagador <seealso cref="EnvioRemessaCefPagador"/></returns>
        private static EnvioRemessaCefPagador GerarDadosPagador(DadosPessoaPagador dadosPagador)
        {
            var pagador = new EnvioRemessaCefPagador();
            if (dadosPagador.PessoaFisica != null)
            {
                pagador.Cpf = dadosPagador.PessoaFisica.Cpf;
                pagador.Nome = dadosPagador.PessoaFisica.Nome.CortaPalavra(40);
            }
            else
            {
                pagador.Cnpj = dadosPagador.PessoaJuridica.Cnpj;
                pagador.RazaoSocial = dadosPagador.PessoaJuridica.RazaoSocial.CortaPalavra(40);
            }

            if (dadosPagador.DadosEndereco != null)
            {
                // Dados de endereço do pagador
                pagador.Endereco = new EnvioRemessaCefEndereco
                {
                    Uf = dadosPagador.DadosEndereco.PagadorUf,
                    Cep = dadosPagador.DadosEndereco.PagadorCep,
                    Bairro = dadosPagador.DadosEndereco.PagadorBairro.CortaPalavra(15),
                    Cidade = dadosPagador.DadosEndereco.PagadorCidade.CortaPalavra(15),
                    Logradouro = dadosPagador.DadosEndereco.PagadorLogradouro.CortaPalavra(40)
                };
            }
            
            return pagador;
        }

        /// <summary>
        /// Gera os dados do sacador avalista
        /// </summary>
        /// <param name="sacadorAvalista">Dados do sacador avalista</param>
        /// <returns>Dados do sacadorAvalista <seealso cref="EnvioRemessaCefSacadorAvalista"/></returns>
        private static EnvioRemessaCefSacadorAvalista GerarDadosSacadorAvalista(DadosSacadorAvalista sacadorAvalista)
        {
            var dadosSacadorAvalista = new EnvioRemessaCefSacadorAvalista();

            if (sacadorAvalista == null)
                return dadosSacadorAvalista;
            
            if (sacadorAvalista.AvalistaPessoaFisica != null)
            {
                dadosSacadorAvalista.Cpf = sacadorAvalista.AvalistaPessoaFisica.Cpf;
                dadosSacadorAvalista.Nome = sacadorAvalista.AvalistaPessoaFisica.Nome.CortaPalavra(40);
            }
            else
            {
                dadosSacadorAvalista.Cnpj = sacadorAvalista.AvalistaPessoaJuridica.Cnpj;
                dadosSacadorAvalista.RazaoSocial = sacadorAvalista.AvalistaPessoaJuridica.RazaoSocial.CortaPalavra(40);
            }

            return dadosSacadorAvalista;
        }

        /// <summary>
        /// Gera os dados da ficha de compensação
        /// </summary>
        /// <param name="instrucao">Instrução do boleto</param>
        /// <returns>Dados da ficha de compensação <seealso cref="EnvioRemessaCefFichaCompensacao"/></returns>
        private static EnvioRemessaCefFichaCompensacao GerarDadosFichaCompensacao(DadosInstrucaoBoleto instrucao)
        {
            var dadosFichaCompensacao = new EnvioRemessaCefFichaCompensacao { Mensagens = new List<string>() };

            if (instrucao == null)
                return dadosFichaCompensacao;
            
            if(!string.IsNullOrEmpty(instrucao.InstrucaoBoleto1))
                dadosFichaCompensacao.Mensagens.Add(instrucao.InstrucaoBoleto1.CortaPalavra(40));
            if(!string.IsNullOrEmpty(instrucao.InstrucaoBoleto2))
                dadosFichaCompensacao.Mensagens.Add(instrucao.InstrucaoBoleto2.CortaPalavra(40));
            
            return dadosFichaCompensacao;
        }

        /// <summary>
        /// Gera os dados da inclusão do boleto
        /// </summary>
        /// <param name="codigoBeneficiario">Código do beneficiário</param>
        /// <returns>Dados da inclusão do boleto <seealso cref="EnvioRemessaCefIncluiBoleto"/></returns>
        private static EnvioRemessaCefIncluiBoleto GerarDadosInclusaoBoleto(string codigoBeneficiario)
        {
            var dadosInclusaoBoleto = new EnvioRemessaCefIncluiBoleto
            {
                CodigoBeneficiario = codigoBeneficiario
            };

            return dadosInclusaoBoleto;
        }
    }
}