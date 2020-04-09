﻿using System.Xml.Serialization;

namespace RegistroBoletoCefApi.Models.CEF
{
    /// <summary>
    /// Dto com os dados de pagamento
    /// </summary>
    public class EnvioRemessaCefPagamento
    {
        /// <summary>
        /// Quantidade de parcelas permitidas
        /// </summary>
        [XmlElement(ElementName="QUANTIDADE_PERMITIDA")]
        public short QuantidadePermitida { get; set; }
        
        /// <summary>
        /// Tipo
        /// </summary>
        [XmlElement(ElementName="TIPO")]
        public string Tipo { get; set; }

        /// <summary>
        /// Valor minimo
        /// </summary>
        [XmlElement(ElementName="VALOR_MINIMO")]
        public string ValorMinimo { get; set; }
        
        /// <summary>
        /// Valor máximo
        /// </summary>
        [XmlElement(ElementName="VALOR_MAXIMO")]
        public string ValorMaximo { get; set; }
        
        /// <summary>
        /// Percentual minimo
        /// </summary>
        [XmlElement(ElementName="PERCENTUAL_MINIMO")]
        public string PercentualMinimo { get; set; }
        
        /// <summary>
        /// Percentual máximo
        /// </summary>
        [XmlElement(ElementName="PERCENTUAL_MAXIMO")]
        public string PercentualMaximo { get; set; }
        
        /// <summary>
        /// Valida se o valor será serializado
        /// </summary>
        /// <returns>Verdadeiro ou falso</returns>
        public bool ShouldSerializePercentualMinimo()
        {
            return !string.IsNullOrEmpty(this.PercentualMinimo);
        }

        /// <summary>
        /// Valida se o valor será serializado
        /// </summary>
        /// <returns>Verdadeiro ou falso</returns>
        public bool ShouldSerializePercentualMaximo()
        {
            return !string.IsNullOrEmpty(this.PercentualMaximo);
        }
        
        /// <summary>
        /// Valida se o valor será serializado
        /// </summary>
        /// <returns>Verdadeiro ou falso</returns>
        public bool ShouldSerializeValorMaxim()
        {
            return !string.IsNullOrEmpty(this.ValorMaximo);
        }
        
        /// <summary>
        /// Valida se o valor será serializado
        /// </summary>
        /// <returns>Verdadeiro ou falso</returns>
        public bool ShouldSerializeValorMinimo()
        {
            return !string.IsNullOrEmpty(this.ValorMinimo);
        }
    }
}