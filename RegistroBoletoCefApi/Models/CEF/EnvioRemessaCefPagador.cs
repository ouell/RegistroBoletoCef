﻿using System.Xml.Serialization;

namespace RegistroBoletoCefApi.Models.CEF
{
    /// <summary>
    /// Dto com os dados do pagador
    /// </summary>
    public class EnvioRemessaCefPagador
    {
        /// <summary>
        /// Cpf
        /// </summary>
        [XmlElement(ElementName="CPF")]
        public string Cpf { get; set; }
       
        /// <summary>
        /// Cnpj
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
        
        /// <summary>
        /// Endereço
        /// </summary>
        [XmlElement(ElementName="ENDERECO")]
        public EnvioRemessaCefEndereco Endereco { get; set; }
        
        /// <summary>
        /// Valida se o valor será serializado
        /// </summary>
        /// <returns>Verdadeiro ou falso</returns>
        public bool ValidaSerializeCnpj()
        {
            return !string.IsNullOrEmpty(this.Cnpj);
        }
        
        /// <summary>
        /// Valida se o valor será serializado
        /// </summary>
        /// <returns>Verdadeiro ou falso</returns>
        public bool ValidaSerializeRazaoSocial()
        {
            return !string.IsNullOrEmpty(this.RazaoSocial);
        }
        
        /// <summary>
        /// Valida se o valor será serializado
        /// </summary>
        /// <returns>Verdadeiro ou falso</returns>
        public bool ValidaSerializeNome()
        {
            return !string.IsNullOrEmpty(this.Nome);
        }
        
        /// <summary>
        /// Valida se o valor será serializado
        /// </summary>
        /// <returns>Verdadeiro ou falso</returns>
        public bool ValidaSerializeCpf()
        {
            return !string.IsNullOrEmpty(this.Cpf);
        }
    }
}