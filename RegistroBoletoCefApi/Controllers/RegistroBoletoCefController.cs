using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegistroBoletoCefApi.Models;

namespace RegistroBoletoCefApi.Controllers
{
    public class RegistroBoletoCefController : ControllerBase
    {
        public async Task<ActionResult> Solicitar([FromBody] SolicitacaoDto body)
        {
            
            return Ok();
        }
    }
}