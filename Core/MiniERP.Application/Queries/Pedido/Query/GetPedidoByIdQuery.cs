using MiniERP.Application.Queries.Pedido.Response;
using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Queries.Pedido.Query
{
    public class GetPedidoByIdQuery : IDomainQuery<IEnumerable<GetPedidoItemResponse>>
    {
        public Guid Codigo { get; set; }
    }
}
