using MiniERP.Domain.Entities;
using MiniERP.Domain.Repositories.Base;

namespace MiniERP.Domain.Repositories
{
    public interface IPedidoItemRepository : IBaseRepository
    {
        Task<IEnumerable<PedidoItem>> GetAllByCodigoPedidoAsync(Guid codigoPedido);
    }
}
