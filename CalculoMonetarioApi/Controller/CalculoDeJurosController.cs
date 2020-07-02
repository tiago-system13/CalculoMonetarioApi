using System;
using CaulculoMonetarioApi.Negocio.Constantes;
using CaulculoMonetarioApi.Negocio.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculoMonetarioApi.Controller
{
    [Route("")]
    [ApiController]
    public class CalculoDeJurosController : ControllerBase
    {
        private readonly ICalculaJurosServico _calculaJurosServico;

        public CalculoDeJurosController(ICalculaJurosServico calculaJurosServico)
        {
            _calculaJurosServico = calculaJurosServico;
        }

        [HttpGet]
        [Route("taxaJuros")]
        public ActionResult<decimal> ObterJuros()
        {
            return Ok(Convert.ToDecimal(EnvConstants.TAXA_JUROS));
        }

        [HttpGet]
        [Route("calculajuros/{valorInicial:decimal}/{meses:int}")]
        public ActionResult<decimal> ObterCalculoDeJuros(decimal valorInicial, int meses)
        {
            return Ok(_calculaJurosServico.CalcularJuros(meses, valorInicial));
        }
    }
}