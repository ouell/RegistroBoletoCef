﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RegistroBoletoCefApi.Models.CEF
{
    /// <summary>
    /// Dto com os dados de desconto
    /// </summary>
    public class EnvioRemessaCefDescontos
    {
        /// <summary>
        /// Lista com os dados de desconto
        /// </summary>
        [XmlElement(ElementName="LSTDESCONTOS")]
        public List<EnvioRemessaCefDesconto> ListaDescontos { get; set; }
    }
    
    /// <summary>
    /// Dto com o desconto
    /// </summary>
    public class EnvioRemessaCefDesconto
    {
        /// <summary>
        /// Data
        /// </summary>
        [XmlElement(ElementName="Data")]
        public DateTime Data { get; set; }
        
        /// <summary>
        /// Valor
        /// </summary>
        [XmlElement(ElementName="Valor")]
        public decimal Valor { get; set; }
        
        /// <summary>
        /// Percentual
        /// </summary>
        [XmlElement(ElementName="Percentual")]
        public decimal Percentual { get; set; }
    }
}