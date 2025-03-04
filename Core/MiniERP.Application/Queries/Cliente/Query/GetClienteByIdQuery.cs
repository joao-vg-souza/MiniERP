using MiniERP.Application.Queries.Cliente.Response;
using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Queries.Cliente.Query
{
    public class GetClienteByIdQuery : IDomainQuery<GetClienteResponse>
    {
        public Guid Codigo { get; set; }
    }
}
