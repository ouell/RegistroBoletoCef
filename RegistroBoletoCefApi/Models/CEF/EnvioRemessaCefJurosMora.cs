﻿using System.Xml.Serialization;

namespace RegistroBoletoCefApi.Models.CEF
{
    /// <summary>
    /// Dto cm os dados de juros de mora
    /// </summary>
    public class EnvioRemessaCefJurosMora
    {
        /// <summary>
        /// Tipo
        /// </summary>
        [XmlElement(ElementName="TIPO")]
        public string Tipo { get; set; }
        
        /// <summary>
        /// Data
        /// </summary>
        [XmlElement(ElementName="DATA")]
        public string Data { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        [XmlElement(IsNullable = true, ElementName="VALOR")]
        public decimal? Valor { get; set; }
        
        /// <summary>
        /// Percentual
        /// </summary>
        [XmlElement(IsNullable = true, ElementName="PERCENTUAL")]
        public decimal? Percentual { get; set; }
        
        /// <summary>
        /// Valida se o valor será serializado
        /// </summary>
        /// <returns>Verdadeiro ou falso</returns>
        public bool ShouldSerializeValor()
        {
            return Valor.HasValue;
        }
        
        /// <summary>
        /// Valida se o valor será serializado
        /// </summary>
        /// <returns>Verdadeiro ou falso</returns>
        public bool ShouldSerializePercentual()
        {
            return Percentual.HasValue;
        }
    }
}