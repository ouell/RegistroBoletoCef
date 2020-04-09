﻿using System;
using System.Xml.Serialization;

namespace RegistroBoletoCefApi.Models.CEF
{
    /// <summary>
    /// Dto com os dados de multa
    /// </summary>
    public class EnvioRemessaCefMulta
    {
        /// <summary>
        /// Data
        /// </summary>
        [XmlElement(ElementName="DATA")]
        public DateTime Data { get; set; }
        
        /// <summary>
        /// Valor
        /// </summary>
        [XmlElement(ElementName="VALOR")]
        public decimal Valor { get; set; }
        
        /// <summary>
        /// Percentual
        /// </summary>
        [XmlElement(ElementName="PERCENTUAL")]
        public decimal Percentual { get; set; }
    }
}