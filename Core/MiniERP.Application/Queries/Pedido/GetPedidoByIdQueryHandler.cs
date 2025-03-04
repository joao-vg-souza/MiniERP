using MediatR;
using MiniERP.Application.Queries.Pedido.Query;
using MiniERP.Application.Queries.Pedido.Response;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Queries.Pedido
{
    public class GetPedidoByIdQueryHandler(IPedidoRepository pedidoRepository, IPedidoItemRepository pedidoItemRepository) : IRequestHandler<GetPedidoByIdQuery, CommandResponseBase<IEnumerable<GetPedidoItemResponse>>>
    {
        private readonly IPedidoRepository _pedidoRepository = pedidoRepository;
        private readonly IPedidoItemRepository _pedidoItemRepository = pedidoItemRepository;

        public async Task<CommandResponseBase<IEnumerable<GetPedidoItemResponse>>> Handle(GetPedidoByIdQuery request, CancellationToken cancellationToken)
        {
            var pedido = await _pedidoRepository.GetByIdAsync<Domain.Entities.Pedido>(request.Codigo);

            if (pedido == null)
                return CommandResponseBase<IEnumerable<GetPedidoItemResponse>>.Error<IEnumerable<GetPedidoItemResponse>>("Pedido não encontrado", System.Net.HttpStatusCode.BadRequest);

            var response = new List<GetPedidoItemResponse>();

            var pedidoItens = await _pedidoItemRepository.GetAllByCodigoPedidoAsync(request.Codigo);

            foreach (var item in pedidoItens)
            {
                response.Add(GetPedidoItemResponse.EntityToResponse(item));
            }

            return CommandResponseBase<IEnumerable<GetPedidoItemResponse>>.Create<IEnumerable<GetPedidoItemResponse>>(response);
        }
    }
}
