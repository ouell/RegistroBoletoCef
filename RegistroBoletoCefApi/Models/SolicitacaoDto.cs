using System;
using System.ComponentModel.DataAnnotations;
using RegistroBoletoCefApi.Models.Enum;

namespace RegistroBoletoCefApi.Models
{
    /// <summary>
    /// Dados da solicitação de um registro de boleto
    /// </summary>
    public class SolicitacaoDto
    {
        /// <summary>
        /// Código do beneficiário no sistema da CEF
        /// </summary>
        public string CodigoBeneficiario { get; set; }

        /// <summary>
        /// Data de vencimento do boleto
        /// </summary>
        [Required]
        public DateTime DataVencimento { get; set; }

        /// <summary>
        /// Cpf ou Cnpj do beneficiário
        /// </summary>
        [Required]
        public string CpfCnpjBeneficiario { get; set; }

        /// <summary>
        /// Nosso número do boleto
        /// </summary>
        [Required]
        public string NossoNumero { get; set; }

        /// <summary>
        /// Valor do boleto
        /// </summary>
        [Required]
        public decimal Valor { get; set; }

        /// <summary>
        /// Número do documento
        /// </summary>
        [Required]
        public string NumeroDocumento { get; set; }

        /// <summary>
        /// Data de emissão do boleto
        /// </summary>
        [Required]
        public DateTime DataEmissao { get; set; }

        /// <summary>
        /// Valor do IOF
        /// </summary>
        public decimal? ValorIof { get; set; }

        /// <summary>
        /// Dados da pessoa do pagador
        /// </summary>
        public DadosPessoaPagador PessoaPagador { get; set; }

        /// <summary>
        /// Dados de pagamento
        /// </summary>
        public DadosPagamento Pagamento { get; set; }

        /// <summary>
        /// Dados dos juros
        /// </summary>
        public DadosJuros Juros { get; set; }

        /// <summary>
        /// Dados da multa
        /// </summary>
        public DadosMulta Multa { get; set; }

        /// <summary>
        /// Dados do desconto
        /// </summary>
        public DadosDesconto Desconto { get; set; }

        /// <summary>
        /// Dados do pós vencimento
        /// </summary>
        public DadosPosVencimento PosVencimento { get; set; }

        /// <summary>
        /// Dados sacador avalista
        /// </summary>
        public DadosSacadorAvalista SacadorAvalista { get; set; }

        /// <summary>
        /// Dados com as instruções do boleto
        /// </summary>
        public DadosInstrucaoBoleto InstrucaoBoleto { get; set; }
    }

    

    /// <summary>
    /// Dados da pessoa do pagador
    /// </summary>
    public abstract class DadosPessoaPagador
    {
        /// <summary>
        /// Dados da pessoa física do pagador
        /// </summary>
        public PagadorPessoaFisica PessoaFisica { get; set; }

        /// <summary>
        /// Dados da pessoa jurídica do pagador
        /// </summary>
        public PagadorPessoaJuridica PessoaJuridica { get; set; }

        /// <summary>
        /// Dados de endereço do pagador
        /// </summary>
        public DadosPagadorEndereco DadosEndereco { get; set; }
    }
    
    /// <summary>
    /// Dados do endereço do pagador
    /// </summary>
    public abstract class DadosPagadorEndereco
    {
        /// <summary>
        /// Unidade federativa do endereço do pagador
        /// </summary>
        public string PagadorUf { get; set; }

        /// <summary>
        /// Cep do endereço do pagador
        /// </summary>
        public string PagadorCep { get; set; }

        /// <summary>
        /// Bairro do endereço do pagador
        /// </summary>
        public string PagadorBairro { get; set; }

        /// <summary>
        /// Cidade do endereço do pagador
        /// </summary>
        public string PagadorCidade { get; set; }

        /// <summary>
        /// Logradouro do endereço do pagador
        /// </summary>
        public string PagadorLogradouro { get; set; }
    }

    /// <summary>
    /// Dados da pessoa física do pagador
    /// </summary>
    public abstract class PagadorPessoaFisica
    {
        /// <summary>
        /// Cpf do pagador
        /// </summary>
        public string Cpf { get; set; }

        /// <summary>
        /// Nome do pagador
        /// </summary>
        public string Nome { get; set; }
    }

    /// <summary>
    /// Dados da pessoa jurídica do pagador
    /// </summary>
    public abstract class PagadorPessoaJuridica
    {
        /// <summary>
        /// Cnpj do pagador
        /// </summary>
        public string Cnpj { get; set; }

        /// <summary>
        /// Razão social do pagador
        /// </summary>
        public string RazaoSocial { get; set; }
    }

    /// <summary>
    /// Dados da multa
    /// </summary>
    public abstract class DadosMulta
    {
        /// <summary>
        /// Data da multa
        /// </summary>
        public DateTime? MultaData { get; set; }

        /// <summary>
        /// Valor da multa
        /// </summary>
        public decimal? MultaValor { get; set; }

        /// <summary>
        /// Percentual da multa
        /// </summary>
        public decimal? MultaPercentual { get; set; }
    }

    /// <summary>
    /// Dados de juros
    /// </summary>
    public abstract class DadosJuros
    {
        /// <summary>
        /// Tipo de Juros
        /// </summary>
        public TipoJuros? TipoJuros { get; set; }

        /// <summary>
        /// Valor do juros
        /// </summary>
        public decimal? ValorJuros { get; set; }

        /// <summary>
        /// Percentual do juros
        /// </summary>
        public decimal? PercentualJuros { get; set; }
    }

    /// <summary>
    /// Dados do pós vencimento
    /// </summary>
    public abstract class DadosPosVencimento
    {
        /// <summary>
        /// Pós vencimento ação (Protestar, Devolver)
        /// </summary>
        public PosVencimentoAcao? PosVencimentoAcao { get; set; }

        /// <summary>
        /// Número de dias do pós vencimento
        /// </summary>
        public short PosVencimentoNumeroDias { get; set; }
    }

    /// <summary>
    /// Dados do sacador avalista
    /// </summary>
    public abstract class DadosSacadorAvalista
    {
        /// <summary>
        /// Dados da pessoa fisica do avalista
        /// </summary>
        public DadosSacadorAvalistaPessoaFisica AvalistaPessoaFisica { get; set; }

        /// <summary>
        /// Dados da pessoa juridica do avalista
        /// </summary>
        public DadosSacadorAvalistaPessoaJuridica AvalistaPessoaJuridica { get; set; }
    }

    /// <summary>
    /// Dados da pessoa fisica do avalista
    /// </summary>
    public abstract class DadosSacadorAvalistaPessoaFisica
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
    }
    
    /// <summary>
    /// Dados da pessoa juridica do avalista
    /// </summary>
    public abstract class DadosSacadorAvalistaPessoaJuridica
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
    }
    
    /// <summary>
    /// Dados com as instruções do boleto
    /// </summary>
    public abstract class DadosInstrucaoBoleto
    {
        /// <summary>
        /// Instrução do boleto
        /// </summary>
        public string InstrucaoBoleto1 { get; set; }

        /// <summary>
        /// Instrução do boleto
        /// </summary>
        public string InstrucaoBoleto2 { get; set; }
    }

    /// <summary>
    /// Dados com as informações de desconto
    /// </summary>
    public abstract class DadosDesconto
    {
        /// <summary>
        /// Data do desconto
        /// </summary>
        public DateTime? DescontoData { get; set; }

        /// <summary>
        /// Valor do desconto
        /// </summary>
        public decimal? DescontoValor { get; set; }

        /// <summary>
        /// Percentual do desconto
        /// </summary>
        public decimal? DescontoPercentual { get; set; }

        /// <summary>
        /// TIpo do desconto
        /// </summary>
        public DescontoTipo? DescontoTipo { get; set; }
    }

    /// <summary>
    /// Dados de pagamento
    /// </summary>
    public abstract class DadosPagamento
    {
        /// <summary>
        /// Quantidade permitida de pagamentos
        /// </summary>
        public short? PagamentoQuantidadePermitida { get; set; }

        /// <summary>
        /// Tipo de pagamento
        /// </summary>
        public PagamentoTipo? PagamentoTipo { get; set; }

        /// <summary>
        /// Tipo da espécie do titulo
        /// </summary>
        [Required]
        public string TipoEspecie { get; set; }
    }
}