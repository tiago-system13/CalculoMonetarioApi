using CaulculoMonetarioApi.Negocio.Dto;
using CaulculoMonetarioApi.Negocio.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculoMonetarioApi.Controller
{
    [Route("")]
    [ApiController]
    public class MostreCodigoController : ControllerBase
    {
        private readonly IConsumindoApiGitHubServico _consumindoApiGitHub;

        public MostreCodigoController(IConsumindoApiGitHubServico consumindoApiGitHub)
        {
            _consumindoApiGitHub = consumindoApiGitHub;
        }

        [HttpGet]
        [Route("/showmethecode")]
        public ActionResult<RepositorioDto> ObterJuros()
        {
            return Ok(_consumindoApiGitHub.ObterUrlProjetoGitHub());
        }
    }
}