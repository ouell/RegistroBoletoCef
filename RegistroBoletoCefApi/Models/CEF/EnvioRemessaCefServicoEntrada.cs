using System.Xml.Serialization;

namespace RegistroBoletoCefApi.Models.CEF
{
    /// <summary>
    /// Dados de entrada para o sistema da CEF
    /// </summary>
    [XmlRoot(ElementName = "SERVICO_ENTRADA", Namespace = "http://caixa.gov.br/sibar/manutencao_cobranca_bancaria/boleto/externo")]
    public class EnvioRemessaCefServicoEntrada
    {
        /// <summary>
        /// Cabeçalho da requisição SOAP
        /// </summary>
        [XmlElement(ElementName = "HEADER", Namespace="http://caixa.gov.br/sibar")]
        public EnvioRemessaCefHeader Header { get; set; }

        /// <summary>
        /// Dados da requisição SOAP
        /// </summary>
        [XmlElement(ElementName = "DADOS", Namespace = "")]
        public EnvioRemessaCefDados Dados { get; set; }
    }
}
