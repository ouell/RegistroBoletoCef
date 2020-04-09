using System.Collections.Generic;
using System.Xml.Serialization;

namespace RegistroBoletoCefApi.Models.CEF
{
    /// <summary>
    /// Dto do recibo pagador
    /// </summary>
    public class EnvioRemessaCefReciboPagador
    {
        /// <summary>
        /// Lista de mensagens do recibo do pagador
        /// </summary>
        [XmlElement(ElementName="MENSAGENS")]
        public List<EnvioRemessaCefMensagem> Mensagens { get; set; }
    }

    /// <summary>
    /// Dto com a mensagem do recibo pagador
    /// </summary>
    public class EnvioRemessaCefMensagem
    {
        /// <summary>
        /// Mensagem
        /// </summary>
        [XmlElement(ElementName = "MENSAGEM")]
        public string DescricaoMensagem { get; set; }
        
        /// <summary>
        /// Retorno
        /// </summary>
        [XmlElement(ElementName = "RETORNO")]
        public string Retorno { get; set; }
    }
}