using System.Xml.Serialization;

namespace RegistroBoletoCefApi.Models.CEF
{
    /// <summary>
    /// Dto com o controle negocial
    /// </summary>
    [XmlRoot(ElementName = "CONTROLE_NEGOCIAL")]
    public class EnvioRemessaCefControleNegocial
    {
        /// <summary>
        /// Origem do retorno
        /// </summary>
        [XmlElement(ElementName = "ORIGEM_RETORNO")]
        public string OrigemRetorno { get; set; }

        /// <summary>
        /// Código do retorno
        /// </summary>
        [XmlElement(ElementName = "COD_RETORNO")]
        public string CodRetorno { get; set; }

        /// <summary>
        /// Mensagens
        /// </summary>
        [XmlElement(ElementName = "MENSAGENS")]
        public EnvioRemessaCefMensagem Mensagens { get; set; }
    }
}