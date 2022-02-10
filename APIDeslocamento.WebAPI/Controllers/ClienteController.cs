using APIDeslocamento.Application.Clientes.Commands.CriarCliente;
using APIDeslocamento.Application.Clientes.Queries;
using APIDeslocamento.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentoApp.WebAPI.Controllers
{
    public class ClienteController : APIController
    {

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] GetClientesQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarClienteCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}
