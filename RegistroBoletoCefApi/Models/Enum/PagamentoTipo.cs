namespace RegistroBoletoCefApi.Models.Enum
{
    /// <summary>
    /// Enum com os tipos de pagamento
    /// </summary>
    public enum PagamentoTipo
    {
        /// <summary>
        /// Aceita o pagamento de qualquer valor
        /// </summary>
        AceitaQualquerValor,
        
        /// <summary>
        /// Aceita somente o pagamento do valor mínimo 
        /// </summary>
        SomenteValorMinimo,
        
        /// <summary>
        /// Não aceita o pagamento de valor divergente 
        /// </summary>
        NaoAceitaValorDivergente,
        
        /// <summary>
        /// Aceita pagamento de valores entre o mínimo e o máximo
        /// </summary>
        AceitaValoresEntreMinimoMaximo
    }
}