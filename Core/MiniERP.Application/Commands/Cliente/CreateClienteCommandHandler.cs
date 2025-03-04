using MediatR;
using MiniERP.Application.Commands.Cliente.Command;
using MiniERP.Application.Commands.Cliente.Response;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;
using MiniERP.Infra.Persistence.Repositories;

namespace MiniERP.Application.Commands.Cliente
{
    public class CreateClienteCommandHandler(IClienteRepository clienteRepository, IContatoRepository contatoRepository, IEnderecoRepository enderecoRepository) : IRequestHandler<CreateClienteCommand, CommandResponseBase<CreateClienteCommandResponse>>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;
        private readonly IContatoRepository _contatoRepository = contatoRepository;
        private readonly IEnderecoRepository _enderecoRepository = enderecoRepository;

        public async Task<CommandResponseBase<CreateClienteCommandResponse>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Domain.Entities.Cliente
            {
                Codigo = Guid.NewGuid(),
                Documento = request.Documento,
                Nome = request.Nome,
                TipoCliente = request.TipoCliente
            };

            cliente.Id = await _clienteRepository.InsertAsync(cliente);

            foreach (var item in request.Contatos)
            {
                await _contatoRepository.InsertAsync(new Domain.Entities.Contato
                {
                    Codigo = Guid.NewGuid(),
                    CodigoCliente = cliente.Codigo,
                    Email = item.Email,
                    TelefoneCelular = item.TelefoneCelular,
                    TelefoneFixo = item.TelefoneFixo,
                });
            }

            foreach (var item in request.Enderecos)
            {
                await _enderecoRepository.InsertAsync(new Domain.Entities.Endereco
                {
                    Codigo = Guid.NewGuid(),
                    Bairro = item.Bairro,
                    CEP = item.CEP,
                    Cidade = item.Cidade,
                    Complemento = item.Complemento,
                    CodigoCliente = cliente.Codigo,
                    Estado = item.Estado,
                    Logradouro = item.Logradouro,
                    Numero = item.Numero
                });
            }

            var response = CreateClienteCommandResponse.EntityToResponse(cliente, request.Contatos, request.Enderecos);
            return CommandResponseBase<CreateClienteCommandResponse>.Create(response);
        }
    }
}
