using MediatR;
using MiniERP.Application.Commands.Cliente.Command;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Commands.Cliente
{
    public class UpdateClienteCommandHandler(IClienteRepository clienteRepository) : IRequestHandler<UpdateClienteCommand, CommandResponseBase<Unit>>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;

        public async Task<CommandResponseBase<Unit>> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync<Domain.Entities.Cliente>(request.CodigoCliente);

            if (cliente == null)
                return CommandResponseBase<Unit>.Error<Unit>("Cliente não encontrado", System.Net.HttpStatusCode.BadRequest);
            UpdateCliente(request, ref cliente);

            await _clienteRepository.UpdateAsync(cliente);

            return CommandResponseBase<Unit>.Create(new Unit(), true, [], System.Net.HttpStatusCode.Accepted);
        }

        private void UpdateCliente(UpdateClienteCommand request, ref Domain.Entities.Cliente cliente)
        {
            cliente.TipoCliente = request.TipoCliente;
            cliente.DtAlteracao = DateTime.Now;
            cliente.Documento = request.Documento;
            cliente.Nome = request.Nome;
        }
    }
}
