using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniERP.Application.Commands.Cliente.Command;
using MiniERP.Application.Queries.Cliente.Query;
using MiniERP.Infra.API;

namespace MiniERP.API.Controllers
{
    [ApiController]
    [Route($"api/[controller]")]
    public class ClienteController(IMediator mediator) : ControllerBaseAPI
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateClienteCommand request)
        {
            var result = await _mediator.Send(request);

            return ReturnResponse(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateClienteCommand request)
        {
            var result = await _mediator.Send(request);

            return ReturnNoContent(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteClienteCommand request)
        {
            var result = await _mediator.Send(request);

            return ReturnNoContent(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllClienteQuery());

            return ReturnResponse(result);
        }


        [HttpGet("{Codigo}")]
        public async Task<IActionResult> GetById([FromRoute] GetClienteByIdQuery request)
        {
            var result = await _mediator.Send(request);

            return ReturnResponse(result);
        }
    }
}
