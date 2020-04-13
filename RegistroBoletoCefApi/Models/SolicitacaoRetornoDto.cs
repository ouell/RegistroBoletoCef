using System;
using System.ComponentModel.DataAnnotations;

namespace RegistroBoletoCefApi.Models
{
    /// <summary>
    /// Dto com os dados de retorno
    /// </summary>
    public abstract class SolicitacaoRetornoDto
    {
        /// <summary>
        /// Cpf ou Cnpj do beneficiário
        /// </summary>
        public string CpfCnpjBeneficiario { get; set; }

        /// <summary>
        /// Nosso número do boleto
        /// </summary>
        public string NossoNumero { get; set; }

        /// <summary>
        /// Valor do boleto
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Número do documento
        /// </summary>
        public string NumeroDocumento { get; set; }

        /// <summary>
        /// Data de emissão do boleto
        /// </summary>
        public DateTime DataEmissao { get; set; }

        /// <summary>
        /// Data de vencimento do boleto
        /// </summary>
        public DateTime DataVencimento { get; set; }

        /// <summary>
        /// Código de barras do boleto gerado
        /// </summary>
        public string CodigoBarras { get; set; }

        /// <summary>
        /// Linha digitável do boleto gerado
        /// </summary>
        public string LinhaDigitavel { get; set; }

        /// <summary>
        /// PDF do boleto
        /// </summary>
        public byte[] ArquivoBoleto { get; set; }

        /// <summary>
        /// Xml enviado para o webservice da caixa
        /// </summary>
        public string XmlSolicitacao { get; set; }

        /// <summary>
        /// Xml retornado pelo webservice da caixa
        /// </summary>
        public string XmlRetorno { get; set; }

        /// <summary>
        /// Dados do pagador caso seja pessoa física
        /// </summary>
        public PagadorPessoaFisicaRetorno PagadorPessoaFisica { get; set; }

        /// <summary>
        /// Dados do pagador caso seja pessoa jurídica
        /// </summary>
        public PagadorPessoaJuridicaRetorno PagadorPessoaJuridica { get; set; }
    }

    /// <summary>
    /// Dados da pessoa física do pagador
    /// </summary>
    public abstract class PagadorPessoaFisicaRetorno
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
    public abstract class PagadorPessoaJuridicaRetorno
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
}