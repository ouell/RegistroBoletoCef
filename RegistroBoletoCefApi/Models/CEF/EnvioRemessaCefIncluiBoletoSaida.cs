﻿using System.Xml.Serialization;

namespace RegistroBoletoCefApi.Models.CEF
{
    /// <summary>
    /// Dados com o resultado da inclusão do boleto
    /// </summary>
    [XmlRoot(ElementName = "IncluiBoletoSaida", Namespace = "")]
    public class EnvioRemessaCefIncluiBoletoSaida
    {
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
        /// Nosso número do boleto
        /// </summary>
        [XmlElement(ElementName="NOSSO_NUMERO")]
        public string NossoNumero { get; set; }
        
        /// <summary>
        /// Url para download do arquivo do boleto
        /// </summary>
        [XmlElement(ElementName="URL")]
        public string Url { get; set; }
    }
}