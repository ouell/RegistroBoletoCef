﻿using System.Xml.Serialization;

namespace RegistroBoletoCefApi.Models.CEF
{
    /// <summary>
    /// Dto com os dados de endereço
    /// </summary>
    public class EnvioRemessaCefEndereco
    {
        /// <summary>
        /// Logradouro
        /// </summary>
        [XmlElement(ElementName="LOGRADOURO")]
        public string Logradouro { get; set; }
        
        /// <summary>
        /// Bairro
        /// </summary>
        [XmlElement(ElementName="BAIRRO")]
        public string Bairro { get; set; }
        
        /// <summary>
        /// Cidade
        /// </summary>
        [XmlElement(ElementName="CIDADE")]
        public string Cidade { get; set; }
        
        /// <summary>
        /// UF
        /// </summary>
        [XmlElement(ElementName="UF")]
        public string Uf { get; set; }
        
        /// <summary>
        /// Cep
        /// </summary>
        [XmlElement(ElementName="CEP")]
        public string Cep { get; set; }
    }
}