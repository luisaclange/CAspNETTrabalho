using APIDeslocamento.Application.Carros.Commands.CriarCarro;
using APIDeslocamento.Application.Carros.Queries;
using APIDeslocamento.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentoApp.WebAPI.Controllers
{
    public class CarroController : APIController
    {

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] GetCarrosQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarCarroCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}
