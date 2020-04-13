using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace RegistroBoletoCefApi
{
    /// <summary>
    /// Classe com métodos uteis para o registro de boleto.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Corta um string para um valor específico
        /// </summary>
        /// <param name="text">Texto que será cortado</param>
        /// <param name="tamanho">Tamanho de caractres</param>
        /// <returns>Texto cortado</returns>
        public static string CortaPalavra(this string text,
                                          int tamanho)
        {
            return text.Length > tamanho
                ? text.Substring(0, tamanho)
                : text;
        }

        /// <summary>
        /// Checa se o parametro é vazio.
        /// </summary>
        /// <param name="param">string que será validada.</param>
        /// <returns>Valor convertido.</returns>
        public static bool EstaVazio(string param)
        {
            if (string.IsNullOrWhiteSpace(param))
                return true;
            var converteu = long.TryParse(param, out var resultado);
            return converteu && resultado == 0;
        }


        /// <summary>
        /// Checa se uma string está sem zero.
        /// </summary>
        /// <param name="param">String que será validada.</param>
        /// <returns>Valor convertido.</returns>
        public static bool EstaVazioSemZero(string param)
        {
            if (string.IsNullOrWhiteSpace(param))
                return true;
            var converteu = long.TryParse(param, out var resultado);
            return converteu && resultado > 0;
        }

        /// <summary>
        /// Client HTTP with basic auth
        /// </summary>
        /// <param name="username">usuário</param>
        /// <param name="password">senha</param>
        /// <returns>Http client com autenticação por basic auth</returns>
        public static HttpClient GetClient(string username,
                                           string password)
        {
            var authValue =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));

            var client = new HttpClient()
            {
                DefaultRequestHeaders = {Authorization = authValue}
                //Set some other client defaults like timeout / BaseAddress
            };
            return client;
        }

        /// <summary>
        /// Client HTTP with bearer token
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Http client com autenticação por bearer auth</returns>
        public static HttpClient GetClient(string token)
        {
            var authValue = new AuthenticationHeaderValue("Bearer", token);

            var client = new HttpClient()
            {
                DefaultRequestHeaders = {Authorization = authValue}
            };
            return client;
        }

        /// <summary>
        /// Transforma um objeto em xml.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string GetXmlFromObject(object o)
        {
            var sw = new StringWriter();
            XmlTextWriter tw = null;
            var serializer = new XmlSerializer(o.GetType());
            try
            {
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
            }
            finally
            {
                sw.Close();
                tw?.Close();
            }

            return sw.ToString();
        }

        /// <summary>
        /// Convert um xml para objeto
        /// </summary>
        /// <param name="xml">string do xml que será convertido</param>
        /// <param name="objectType">objeto de destino</param>
        /// <returns></returns>
        public static object XmlToObject(string xml,
                                         Type objectType)
        {
            StringReader strReader = null;
            XmlTextReader xmlReader = null;
            object obj;
            try
            {
                strReader = new StringReader(xml);
                var serializer = new XmlSerializer(objectType);
                xmlReader = new XmlTextReader(strReader);
                obj = serializer.Deserialize(xmlReader);
            }
            finally
            {
                xmlReader?.Close();
                strReader?.Close();
            }

            return obj;
        }

        /// <summary>
        /// Convert uma string pra HASH256
        /// </summary>
        /// <param name="text">texto que será convertido</param>
        /// <returns>Texto convertido para HASH256</returns>
        public static string GetHashSha256(string text)
        {
            var bytesText = Encoding.UTF8.GetBytes(text);
            var hasher = SHA256.Create();
            var hashValue = hasher.ComputeHash(bytesText);
            return Convert.ToBase64String(hashValue);
        }

        /// <summary>
        /// Serializa um dto para xml
        /// </summary>
        /// <param name="dataToSerialize">Dto que será serializado</param>
        /// <param name="namespaces">Namespaces</param>
        /// <typeparam name="T">Parametro anonimo</typeparam>
        /// <returns>String com o xml</returns>
        /// <exception cref="Exception">Erro ao converter o dto</exception>
        public static string XmlSerialize<T>(T dataToSerialize,
                                             XmlSerializerNamespaces namespaces = null)
        {
            try
            {
                var s = new MemoryStream();
                var sw = new StreamWriter(s);
                var serializer = new XmlSerializer(typeof(T));

                if (namespaces != null)
                    serializer.Serialize(sw, dataToSerialize, namespaces);
                else
                    serializer.Serialize(sw, dataToSerialize);

                var xml = Encoding.UTF8.GetString(s.ToArray());

                return xml;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        /// <summary>
        /// Convert um xml pra dto
        /// </summary>
        /// <param name="xmlText">xml em string</param>
        /// <typeparam name="T">Objeto anonimo de retorno</typeparam>
        /// <returns>Xml convertido pra dto</returns>
        public static T XmlDeserialize<T>(string xmlText)
        {
            var stringReader = new StringReader(xmlText);
            var serializer = new XmlSerializer(typeof(T));
            return (T) serializer.Deserialize(stringReader);
        }

        public static string CallSoapWebRequest(string url,
                                                string xml,
                                                string operacao)
        {
            var soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(xml);
            var webRequest = CreateWebRequest(url, operacao);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            var asyncResult = webRequest.BeginGetResponse(null, null);

            asyncResult.AsyncWaitHandle.WaitOne();
            try
            {
                using (var webResponse = webRequest.EndGetResponse(asyncResult))
                {
                    using (var rd = new StreamReader(webResponse.GetResponseStream()))
                    {
                        var soapResult = rd.ReadToEnd();
                        return soapResult;
                    }
                }
            }
            catch (WebException err)
            {
                using (var stream = err.Response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var erro = reader.ReadToEnd();
                        throw new Exception(erro);
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        private static HttpWebRequest CreateWebRequest(string url,
                                                       string action)
        {
            //TLS 1.2
            ServicePointManager.SecurityProtocol = (SecurityProtocolType) 3072;
            //Desabilitado erros de SSL pois URL do banco retorna erro
            ServicePointManager.ServerCertificateValidationCallback += (sender,
                                                                        cert,
                                                                        chain,
                                                                        sslPolicyErrors) => true;

            var webRequest = (HttpWebRequest) WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml,
                                                             HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

        internal static byte[] DownloadArquivo(string url)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));

            var responseMessage = httpClient.GetAsync(url).Result;
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new FileNotFoundException(responseMessage.Content.ReadAsStringAsync().Result);
            }

            return responseMessage.Content.ReadAsStreamAsync().Result.ConvertToByteArray();
        }

        private static byte[] ConvertToByteArray(this Stream stream)
        {
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            return bytes;
        }
    }
}