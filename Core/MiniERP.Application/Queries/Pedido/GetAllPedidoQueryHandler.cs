using MediatR;
using MiniERP.Application.Queries.Pedido.Query;
using MiniERP.Application.Queries.Pedido.Response;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Queries.Pedido
{
    public class GetAllPedidoQueryHandler(IPedidoRepository pedidoRepository) : IRequestHandler<GetAllPedidoQuery, CommandResponseBase<IEnumerable<GetPedidoResponse>>>
    {
        private readonly IPedidoRepository _pedidoRepository = pedidoRepository;

        public async Task<CommandResponseBase<IEnumerable<GetPedidoResponse>>> Handle(GetAllPedidoQuery request, CancellationToken cancellationToken)
        {
            var pedidos = await _pedidoRepository.GetAllAsync<Domain.Entities.Pedido>();

            var responses = new List<GetPedidoResponse>();

            foreach (var item in pedidos)
            {
                responses.Add(GetPedidoResponse.EntityToResponse(item));
            }

            return CommandResponseBase<IEnumerable<GetPedidoResponse>>.Create<IEnumerable<GetPedidoResponse>>(responses);
        }
    }
}
