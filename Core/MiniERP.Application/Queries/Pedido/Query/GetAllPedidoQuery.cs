using MiniERP.Application.Queries.Pedido.Response;
using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Queries.Pedido.Query
{
    public class GetAllPedidoQuery : IDomainQuery<IEnumerable<GetPedidoResponse>>
    {
    }
}
