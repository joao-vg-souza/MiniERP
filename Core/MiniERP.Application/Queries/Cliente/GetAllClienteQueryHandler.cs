using MediatR;
using MiniERP.Application.Queries.Categoria.Response;
using MiniERP.Application.Queries.Cliente.Query;
using MiniERP.Application.Queries.Cliente.Response;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Queries.Cliente
{
    public class GetAllClienteQueryHandler(IClienteRepository clienteRepository) : IRequestHandler<GetAllClienteQuery, CommandResponseBase<IEnumerable<GetClienteResponse>>>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;

        public async Task<CommandResponseBase<IEnumerable<GetClienteResponse>>> Handle(GetAllClienteQuery request, CancellationToken cancellationToken)
        {
            var clientes = await _clienteRepository.GetAllAsync<Domain.Entities.Cliente>();

            var responses = new List<GetClienteResponse>();

            foreach (var item in clientes)
            {
                responses.Add(GetClienteResponse.EntityToResponse(item));
            }

            return CommandResponseBase<IEnumerable<GetClienteResponse>>.Create<IEnumerable<GetClienteResponse>>(responses);
        }
    }
}
