using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniERP.Application.Commands.Produto.Command;
using MiniERP.Infra.API;

namespace MiniERP.API.Controllers
{
    [ApiController]
    [Route($"api/[controller]")]
    public class ProdutoController(IMediator mediator) : ControllerBaseAPI
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateProdutoCommand request)
        {
            var result = await _mediator.Send(request);

            return ReturnResponse(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProdutoCommand request)
        {
            var result = await _mediator.Send(request);

            return ReturnNoContent(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProdutoCommand request)
        {
            var result = await _mediator.Send(request);

            return ReturnNoContent(result);
        }
    }
}
