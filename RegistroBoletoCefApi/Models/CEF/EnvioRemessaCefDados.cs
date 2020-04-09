using System.Xml.Serialization;

namespace RegistroBoletoCefApi.Models.CEF
{
    /// <summary>
    /// Dto com os dados do xml
    /// </summary>
    [XmlRoot(ElementName = "DADOS", Namespace = "")]
    public class EnvioRemessaCefDados
    {
        /// <summary>
        /// Dados da inclusão do boleto
        /// </summary>
        [XmlElement(ElementName = "INCLUI_BOLETO", Namespace = "")]
        public EnvioRemessaCefIncluiBoleto IncluiBoleto { get; set; }
    }
}