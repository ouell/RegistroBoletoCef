namespace RegistroBoletoCefApi.Models.Enum
{
    /// <summary>
    /// Enum com os tipos de desconto
    /// </summary>
    public enum DescontoTipo
    {
        /// <summary>
        /// Isento de desconto
        /// </summary>
        Isento,
        
        /// <summary>
        /// Valor fixo até o dia
        /// </summary>
        ValorFixoAteDia,
        
        /// <summary>
        /// Percentual ate o dia
        /// </summary>
        PercentualAteDia,
        
        /// <summary>
        /// Valor antecipado até o dia útil
        /// </summary>
        ValorAntecipadoDiaUtil,
        
        /// <summary>
        /// Valor antecipado por dia corrido
        /// </summary>
        ValorAntecipadoDiaCorrido,
        
        /// <summary>
        /// Percentual antecipado até o dia útil
        /// </summary>
        PercentualAntecipadoDiaUtil,
        
        /// <summary>
        /// Percentual antecipado por dia corrido
        /// </summary>
        PercentualAntecipadoDiaCorrido,
    }
}