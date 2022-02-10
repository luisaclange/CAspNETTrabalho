using APIDeslocamento.Application.Condutores.Commands.CriarCondutor;
using APIDeslocamento.Application.Condutores.Queries;
using APIDeslocamento.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentoApp.WebAPI.Controllers
{
    public class CondutorController : APIController
    {

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] GetCondutoresQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarCondutorCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}