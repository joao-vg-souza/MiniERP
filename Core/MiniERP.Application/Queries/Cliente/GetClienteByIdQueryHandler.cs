using MediatR;
using MiniERP.Application.Queries.Categoria.Response;
using MiniERP.Application.Queries.Cliente.Query;
using MiniERP.Application.Queries.Cliente.Response;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Queries.Cliente
{
    public class GetClienteByIdQueryHandler(IClienteRepository clienteRepository) : IRequestHandler<GetClienteByIdQuery, CommandResponseBase<GetClienteResponse>>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;

        public async Task<CommandResponseBase<GetClienteResponse>> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync<Domain.Entities.Cliente>(request.Codigo);

            if (cliente == null)
                return CommandResponseBase<GetClienteResponse>.Error<GetClienteResponse>("Cliente não encontrada", System.Net.HttpStatusCode.BadRequest);

            var response = GetClienteResponse.EntityToResponse(cliente);

            return CommandResponseBase<GetClienteResponse>.Create(response);
        }
    }
}
