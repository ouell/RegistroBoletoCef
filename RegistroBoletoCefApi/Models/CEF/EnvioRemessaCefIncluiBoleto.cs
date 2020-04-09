﻿using System.Xml.Serialization;
 using RegistroBoletoCefApi.Models.CEF;

 namespace RegistroBoletoCefApi.Models.CEF
{
    /// <summary>
    /// Dto com os dados da inclusão de boleto
    /// </summary>
    [XmlRoot(ElementName="INCLUI_BOLETO")]
    public class EnvioRemessaCefIncluiBoleto
    {
        /// <summary>
        /// Código do beneficiário 
        /// </summary>
        [XmlElement(ElementName="CODIGO_BENEFICIARIO")]
        public string CodigoBeneficiario { get; set; }
        
        /// <summary>
        /// Dados do título
        /// </summary>
        [XmlElement(ElementName="TITULO")]
        public EnvioRemessaCefTitulo Titulo { get; set; }
    }
}