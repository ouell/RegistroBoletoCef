﻿using System.Xml.Serialization;

namespace RegistroBoletoCefApi.Models.CEF
{
    /// <summary>
    /// Dto com os dados de pós vencimento
    /// </summary>
    public class EnvioRemessaCefPosVencimento
    {
        /// <summary>
        /// Ação 
        /// </summary>
        [XmlElement(ElementName="ACAO")]
        public string Acao { get; set; }
        
        /// <summary>
        /// Número de dias
        /// </summary>
        [XmlElement(ElementName="NUMERO_DIAS")]
        public short NumeroDias { get; set; }
    }
}