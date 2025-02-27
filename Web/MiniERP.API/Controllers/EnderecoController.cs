using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniERP.Application.Commands.Endereco.Command;
using MiniERP.Infra.API;

namespace MiniERP.API.Controllers
{
    [ApiController]
    [Route($"api/[controller]")]
    public class EnderecoController(IMediator mediator) : ControllerBaseAPI
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateEnderecoCommand request)
        {
            var result = await _mediator.Send(request);

            return ReturnResponse(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateEnderecoCommand request)
        {
            var result = await _mediator.Send(request);

            return ReturnNoContent(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteEnderecoCommand request)
        {
            var result = await _mediator.Send(request);

            return ReturnNoContent(result);
        }
    }
}
