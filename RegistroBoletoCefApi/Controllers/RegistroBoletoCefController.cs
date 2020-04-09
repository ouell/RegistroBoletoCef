using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegistroBoletoCefApi.Models;

namespace RegistroBoletoCefApi.Controllers
{
    [Route("registroboleto")]
    public class RegistroBoletoCefController : ControllerBase
    {
        [HttpPost]
        [Route("solicitar")]
        public async Task<ActionResult> Solicitar([FromBody] SolicitacaoDto body)
        {
            
            return Ok();
        }
    }
}