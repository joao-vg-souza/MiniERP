using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniERP.Application.Commands.Pedido.Command;
using MiniERP.Infra.API;

namespace MiniERP.API.Controllers
{
    [ApiController]
    [Route($"api/[controller]")]
    public class PedidoController(IMediator mediator) : ControllerBaseAPI
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreatePedidoCommand request)
        {
            var result = await _mediator.Send(request);

            return ReturnResponse(result);
        }
    }
}
