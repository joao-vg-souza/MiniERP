using Microsoft.AspNetCore.Mvc;
using MiniERP.Application.Commands.Categoria.Command;
using MiniERP.Application.Queries.Categoria.Query;
using MiniERP.Infra.API;
using MiniERP.Infra.Bus;

namespace MiniERP.API.Controllers
{
    [ApiController]
    [Route($"api/[controller]")]
    public class CategoriaController(IMediator mediator) : ControllerBaseAPI
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoriaCommand request)
        {
            var result = await _mediator.Send(request);

            return ReturnResponse(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCategoriaCommand request)
        {
            var result = await _mediator.Send(request);

            return ReturnNoContent(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCategoriaCommand request)
        {
            var result = await _mediator.Send(request);

            return ReturnNoContent(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCategoriaQuery());

            return ReturnResponse(result);
        }


        [HttpGet("{Codigo}")]
        public async Task<IActionResult> GetById([FromRoute] GetCategoriaByIdQuery request)
        {
            var result = await _mediator.Send(request);

            return ReturnResponse(result);
        }
    }
}
