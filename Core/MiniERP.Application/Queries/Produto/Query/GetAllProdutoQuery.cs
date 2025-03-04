using MiniERP.Application.Queries.Produto.Response;
using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Queries.Produto.Query
{
    public class GetAllProdutoQuery : IDomainQuery<IEnumerable<GetProdutoResponse>>
    {
    }
}
