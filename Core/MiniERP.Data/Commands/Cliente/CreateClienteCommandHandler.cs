using MediatR;
using MiniERP.Application.Commands.Cliente.Command;
using MiniERP.Application.Commands.Cliente.Response;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Commands.Cliente
{
    public class CreateClienteCommandHandler(IClienteRepository clienteRepository) : IRequestHandler<CreateClienteCommand, CommandResponseBase<CreateClienteCommandResponse>>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;

        public async Task<CommandResponseBase<CreateClienteCommandResponse>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var categoria = new Domain.Entities.Cliente
            {
                Codigo = Guid.NewGuid(),
                Documento = request.Documento,
                Nome = request.Nome,
                TipoCliente = request.TipoCliente
            };

            categoria.Id = await _clienteRepository.InsertAsync(categoria);

            var response = CreateClienteCommandResponse.EntityToResponse(categoria);
            return CommandResponseBase<CreateClienteCommandResponse>.Create(response, true, [], System.Net.HttpStatusCode.OK);
        }
    }
}
