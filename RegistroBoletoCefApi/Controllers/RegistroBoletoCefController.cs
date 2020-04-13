using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegistroBoletoCefApi.ClientApi.IClientApi;
using RegistroBoletoCefApi.Models;

namespace RegistroBoletoCefApi.Controllers
{
    /// <summary>
    /// Controller responsável por realizar o registro de boleto
    /// </summary>
    [Route("registroboleto")]
    public class RegistroBoletoCefController : ControllerBase
    {
        private readonly IClientApiCef _clientApiCef;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="clientApiCef">Client da api da CEF</param>
        public RegistroBoletoCefController(IClientApiCef clientApiCef)
        {
            _clientApiCef = clientApiCef;
        }

        /// <summary>
        /// Solicita um registro de boleto no webservice da CEF
        /// </summary>
        /// <param name="body">Dados necessários para registrar um boleto</param>
        /// <returns>Dados de retorno do boleto <seealso cref="SolicitacaoRetornoDto"/></returns>
        [HttpPost]
        [Route("solicitar")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<SolicitacaoRetornoDto>> Solicitar([FromBody] SolicitacaoDto body)
        {
            var retorno = await _clientApiCef.RegistrarBoleto(body).ConfigureAwait(false);
            return Ok(retorno);
        }
    }
}