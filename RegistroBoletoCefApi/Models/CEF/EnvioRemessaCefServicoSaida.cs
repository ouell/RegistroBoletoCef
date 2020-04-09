﻿using System.Xml.Serialization;

namespace RegistroBoletoCefApi.Models.CEF
{
    /// <summary>
    /// Dados de retorno
    /// </summary>
    [XmlRoot(ElementName="SERVICO_SAIDA", Namespace = "")]
    public class EnvioRemessaCefServicoSaida
    {
        [XmlElement(ElementName="HEADER", Namespace = "http://caixa.gov.br/sibar")]
        public EnvioRemessaCefHeader Header { get; set; }

        /// <summary>
        /// Código de retorno do ws da CEF
        /// </summary>
        [XmlElement(ElementName="COD_RETORNO")]
        public string CodRetorno { get; set; }
        
        /// <summary>
        /// Origem do retorno
        /// </summary>
        [XmlElement(ElementName="ORIGEM_RETORNO")]
        public string OrigemRetorno { get; set; }
        
        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        [XmlElement(ElementName="MSG_RETORNO")]
        public string MsgRetorno { get; set; }

        /// <summary>
        /// Dados de retorno do ws
        /// </summary>
        [XmlElement(ElementName="DADOS", Namespace = "")]
        public EnvioRemessaCefDadosSaida Dados { get; set; }
    }
}