﻿using System.Xml.Serialization;
 using RegistroBoletoCefApi.Models.CEF;

 namespace RegistroBoletoCefApi.Models.CEF
{
    /// <summary>
    /// Dto que contém os dados de saída do boleto
    /// </summary>
    [XmlRoot(ElementName = "DadosSaida", Namespace = "")]
    public class EnvioRemessaCefDadosSaida
    {
        /// <summary>
        /// Dados de controle negociavel
        /// </summary>
        [XmlElement(ElementName="CONTROLE_NEGOCIAL", Namespace = "")]
        public EnvioRemessaCefControleNegocial ControleNegocial { get; set; }
        
        /// <summary>
        /// Dados do boleto gerado
        /// </summary>
        [XmlElement(ElementName="INCLUI_BOLETO", Namespace = "")]
        public EnvioRemessaCefIncluiBoletoSaida IncluiBoleto { get; set; }
    }
}