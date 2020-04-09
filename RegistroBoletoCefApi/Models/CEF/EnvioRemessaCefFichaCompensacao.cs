﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace RegistroBoletoCefApi.Models.CEF
{
    /// <summary>
    /// Dto com os dados da ficha de compensação
    /// </summary>
    public class EnvioRemessaCefFichaCompensacao
    {
        /// <summary>
        /// Lista com as mensagens
        /// </summary>
        [XmlArray("MENSAGENS")]
        [XmlArrayItem(ElementName = "MENSAGEM")]
        public List<string> Mensagens { get; set; }
    }
}