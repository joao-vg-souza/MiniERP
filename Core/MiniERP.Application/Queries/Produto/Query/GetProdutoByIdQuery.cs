using MiniERP.Application.Queries.Produto.Response;
using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Queries.Produto.Query
{
    public class GetProdutoByIdQuery : IDomainQuery<GetProdutoResponse>
    {
        public Guid Codigo { get; set; }
    }
}
