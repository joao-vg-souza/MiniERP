using MiniERP.Application.Queries.Categoria.Response;
using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Queries.Categoria.Query
{
    public class GetAllCategoriaQuery : IDomainQuery<IEnumerable<GetCategoriaResponse>>
    {
    }
}
