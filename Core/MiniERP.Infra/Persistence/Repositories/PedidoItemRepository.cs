using Microsoft.Extensions.Configuration;
using MiniERP.Domain.Entities;
using MiniERP.Domain.Repositories;
using MiniERP.Infra.Persistence.Repositories.Base;

namespace MiniERP.Infra.Persistence.Repositories
{
    public class PedidoItemRepository(IConfiguration configuration) : DapperBaseRepository(configuration.GetConnectionString("MiniERP")!), IPedidoItemRepository
    {
        public async Task<IEnumerable<PedidoItem>> GetAllByCodigoPedidoAsync(Guid codigoPedido)
        {
            string query = @"SELECT * FROM dbo.PedidoItem WITH (NOLOCK) WHERE CodigoPedido = @Codigo";

            return await RawQueryAsync<PedidoItem>(query, new { Codigo = codigoPedido });
        }
    }
}
