﻿using System.Xml.Serialization;

namespace RegistroBoletoCefApi.Models.CEF
{
    /// <summary>
    /// Dto para dos dados sacador avalista
    /// </summary>
    public class EnvioRemessaCefSacadorAvalista
    {
        /// <summary>
        /// Número do cpf
        /// </summary>
        [XmlElement(ElementName="CPF")]
        public string Cpf { get; set; }
        
        /// <summary>
        /// Número do cnpj
        /// </summary>
        [XmlElement(ElementName="CNPJ")]
        public string Cnpj { get; set; }
        
        /// <summary>
        /// Nome
        /// </summary>
        [XmlElement(ElementName="NOME")]
        public string Nome { get; set; }
        
        /// <summary>
        /// Razão social
        /// </summary>
        [XmlElement(ElementName="RAZAO_SOCIAL")]
        public string RazaoSocial { get; set; }
    }
}