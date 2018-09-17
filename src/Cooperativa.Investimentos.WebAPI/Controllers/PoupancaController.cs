using System;
using Cooperativa.Investimentos.Poupancas;
using Cooperativa.Investimentos.WebAPI.Models;
using Infraestructure.Core.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Cooperativa.Investimentos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PoupancaController : Controller
    {
        private readonly IRequestContext _requestContext;

        public PoupancaController(IRequestContext requestContext)
        {
            _requestContext = requestContext;
        }

        [HttpGet]
        public string Get()
        {
            return "Investimentos - Poupança";
        }

        [HttpPost]
        public IActionResult Post([FromBody]CriarNovaPoupancaRequest criarNovaPoupancaRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var criarNovaPoupancaCommand = new CriarNovaPoupancaCommand(
                new ContaCorrente(Guid.Parse(criarNovaPoupancaRequest.CooperativaId),
                    Guid.Parse(criarNovaPoupancaRequest.PostoAtendimentoId),
                    Guid.Parse(criarNovaPoupancaRequest.ContaCorrenteId),
                    criarNovaPoupancaRequest.Numero, criarNovaPoupancaRequest.Digito), 
                    criarNovaPoupancaRequest.Valor);

            _requestContext.SendCommand(criarNovaPoupancaCommand);

            return Ok($"Comando {criarNovaPoupancaCommand.Id}");
        }
    }
}