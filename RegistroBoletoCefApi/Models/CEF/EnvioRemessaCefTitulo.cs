﻿using System.Xml.Serialization;

 namespace RegistroBoletoCefApi.Models.CEF
{
    
    /// <summary>
    /// Dto referente ao titulo na inclusão de boleto 
    /// </summary>
    public class EnvioRemessaCefTitulo
    {
        /// <summary>
        /// Nosso número
        /// </summary>
        [XmlElement(ElementName="NOSSO_NUMERO")]
        public long NossoNumero { get; set; }
        
        /// <summary>
        /// Número do documento
        /// </summary>
        [XmlElement(ElementName="NUMERO_DOCUMENTO")]
        public string NumeroDocumento { get; set; }
        
        /// <summary>
        /// Data de vencimento
        /// </summary>
        [XmlElement(ElementName="DATA_VENCIMENTO")]
        public string DataVencimento { get; set; }
        
        /// <summary>
        /// Valor
        /// </summary>
        [XmlElement(ElementName="VALOR")]
        public decimal Valor { get; set; }
        
        /// <summary>
        /// Tipo especie
        /// </summary>
        [XmlElement(ElementName="TIPO_ESPECIE")]
        public string TipoEspecie { get; set; }
        
        /// <summary>
        /// Flag aceite
        /// </summary>
        [XmlElement(ElementName="FLAG_ACEITE")]
        public string FlagAceite { get; set; }
        
        /// <summary>
        /// Data de emissão do boleto
        /// </summary>
        [XmlElement(ElementName = "DATA_EMISSAO")]
        public string DataEmissao { get; set; }
        
        /// <summary>
        /// Dados do juros de mora
        /// </summary>
        [XmlElement(ElementName="JUROS_MORA")]
        public EnvioRemessaCefJurosMora JurosMora { get; set; }
        
        /// <summary>
        /// Dados do pós vencimento
        /// </summary>
        [XmlElement(ElementName="POS_VENCIMENTO")]
        public EnvioRemessaCefPosVencimento PosVencimento { get; set; }
        
        /// <summary>
        /// Código da moeda
        /// </summary>
        [XmlElement(ElementName="CODIGO_MOEDA")]
        public short CodigoMoeda { get; set; }
        
        /// <summary>
        /// Dados do pagador
        /// </summary>
        [XmlElement(ElementName="PAGADOR")]
        public EnvioRemessaCefPagador Pagador { get; set; }
        
        /// <summary>
        /// Dados do sacador avalista
        /// </summary>
        [XmlElement(ElementName="SACADOR_AVALISTA")]
        public EnvioRemessaCefSacadorAvalista SacadorAvalista { get; set; }
        
        /// <summary>
        /// Dados da multa
        /// </summary>
        [XmlElement(ElementName="MULTA")]
        public EnvioRemessaCefMulta Multa { get; set; }
        
        /// <summary>
        /// Dados do desconto
        /// </summary>
        [XmlElement(ElementName="DESCONTOS")]
        public EnvioRemessaCefDescontos Descontos { get; set; }
        
        /// <summary>
        /// Valor do iof
        /// </summary>
        [XmlElement(ElementName="VALOR_IOF")]
        public string ValorIof { get; set; }
        
        /// <summary>
        /// Identificação da empresa
        /// </summary>
        [XmlElement(ElementName="IDENTIFICACAO_EMPRESA")]
        public string IdentificacaoEmpresa { get; set; }
        
        /// <summary>
        /// Dados da ficha de compensação
        /// </summary>
        [XmlElement(ElementName="FICHA_COMPENSACAO")]
        public EnvioRemessaCefFichaCompensacao FichaCompensacao { get; set; }
        
        /// <summary>
        /// Dados do recibo do pagador
        /// </summary>
        [XmlElement(ElementName="RECIBO_PAGADOR")]
        public EnvioRemessaCefReciboPagador ReciboPagador { get; set; }
        
        /// <summary>
        /// Dados do pagamento
        /// </summary>
        [XmlElement(ElementName="PAGAMENTO")]
        public EnvioRemessaCefPagamento Pagamento { get; set; }
        
        /// <summary>
        /// Código de barras do boleto
        /// </summary>
        [XmlElement(ElementName="CODIGO_BARRAS")]
        public string CodigoBarras { get; set; }
        
        /// <summary>
        /// Linha digitável do boleto
        /// </summary>
        [XmlElement(ElementName="LINHA_DIGITAVEL")]
        public string LinhaDigitavel { get; set; }
        
        /// <summary>
        /// Url 
        /// </summary>
        [XmlElement(ElementName="URL")]
        public string Url { get; set; }
    }
}