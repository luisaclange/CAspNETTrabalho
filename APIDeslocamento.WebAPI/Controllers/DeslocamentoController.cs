
using APIDeslocamento.Application.Deslocamentos.Commands.FinalizarDeslocamento;
using APIDeslocamento.Application.Deslocamentos.Commands.IniciarDeslocamento;
using APIDeslocamento.Application.Deslocamentos.Queries;
using APIDeslocamento.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentoApp.WebAPI.Controllers
{
    public class DeslocamentoController : APIController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetDeslocamentosQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] IniciarDeslocamentoCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }

        [HttpPut("{deslocamentoId:long}/finalizar_deslocamento")]
        public async Task<IActionResult> PutAdicionarSignatarioAsync(
            [FromRoute] long deslocamentoId,
            [FromBody] FinalizarDeslocamentoCommand command)
        {
            if (deslocamentoId != command.DeslocamentoId) return BadRequest();

            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}