using MediatR;
using MiniERP.Application.Commands.Cliente.Command;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Commands.Cliente
{
    public class DeleteClienteCommandHandler(IClienteRepository clienteRepository) : IRequestHandler<DeleteClienteCommand, CommandResponseBase<Unit>>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;

        public async Task<CommandResponseBase<Unit>> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync<Domain.Entities.Cliente>(request.CodigoCliente);

            if (cliente == null)
                return CommandResponseBase<Unit>.Error<Unit>("Cliente não encontrado", System.Net.HttpStatusCode.BadRequest);

            await _clienteRepository.DeleteAsync<Domain.Entities.Cliente>(cliente.Codigo);

            return CommandResponseBase<Unit>.Create(new Unit(), System.Net.HttpStatusCode.NoContent);
        }
    }
}
