using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniERP.Application.Commands.Contato.Command;
using MiniERP.Infra.API;

namespace MiniERP.API.Controllers
{
    [ApiController]
    [Route($"api/[controller]")]
    public class ContatoController(IMediator mediator) : ControllerBaseAPI
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateContatoCommand request)
        {
            var result = await _mediator.Send(request);

            return ReturnResponse(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateContatoCommand request)
        {
            var result = await _mediator.Send(request);

            return ReturnNoContent(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteContatoCommand request)
        {
            var result = await _mediator.Send(request);

            return ReturnNoContent(result);
        }
    }
}
