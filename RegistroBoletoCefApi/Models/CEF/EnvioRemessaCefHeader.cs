﻿using System.Xml.Serialization;

namespace RegistroBoletoCefApi.Models.CEF
{
    /// <summary>
    /// Classe responsável pelo DTO do Header do xml
    /// </summary>
    [XmlRoot(Namespace = "")]
    public class EnvioRemessaCefHeader
    {
        /// <summary>
        /// Versão
        /// </summary>
        [XmlElement("VERSAO")]
        public string Versao { get; set; }

        /// <summary>
        /// Autenticação
        /// </summary>
        [XmlElement("AUTENTICACAO")]
        public string Autenticacao { get; set; }

        /// <summary>
        /// Usuário do serviço
        /// </summary>
        [XmlElement("USUARIO_SERVICO")]
        public string UsuarioServico { get; set; }

        /// <summary>
        /// Operação
        /// </summary>
        [XmlElement("OPERACAO")]
        public string Operacao { get; set; }

        /// <summary>
        /// Sistema de origem
        /// </summary>
        [XmlElement("SISTEMA_ORIGEM")]
        public string SistemaOrigem { get; set; }

        /// <summary>
        /// Data e hora
        /// </summary>
        [XmlElement("DATA_HORA")]
        public string DataHora { get; set; }
    }
}
