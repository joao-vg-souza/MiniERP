using MiniERP.Application.Queries.Cliente.Response;
using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Queries.Cliente.Query
{
    public class GetAllClienteQuery : IDomainQuery<IEnumerable<GetClienteResponse>>
    {
    }
}
