using System.Threading.Tasks;
using RegistroBoletoCefApi.Models;

namespace RegistroBoletoCefApi.ClientApi.IClientApi
{
    /// <summary>
    /// Interface do client da CEF
    /// </summary>
    public interface IClientApiCef
    {
        /// <summary>
        /// Realiza o registro de boleto no webservice da CEF
        /// </summary>
        /// <param name="solicitacao">Dados para solicitação <seealso cref="SolicitacaoDto"/></param>
        /// <returns>Dados de retorno do webservice da CEF <seealso cref="SolicitacaoRetornoDto"/></returns>
        Task<SolicitacaoRetornoDto> RegistrarBoleto(SolicitacaoDto solicitacao);
    }
}