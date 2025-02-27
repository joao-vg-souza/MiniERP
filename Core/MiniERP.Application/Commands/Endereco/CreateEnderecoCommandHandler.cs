using MediatR;
using MiniERP.Application.Commands.Endereco.Command;
using MiniERP.Application.Commands.Endereco.Response;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Commands.Endereco
{
    public class CreateEnderecoCommandHandler(IEnderecoRepository enderecoRepository) : IRequestHandler<CreateEnderecoCommand, CommandResponseBase<CreateEnderecoCommandResponse>>
    {
        private readonly IEnderecoRepository _enderecoRepository = enderecoRepository;

        public async Task<CommandResponseBase<CreateEnderecoCommandResponse>> Handle(CreateEnderecoCommand request, CancellationToken cancellationToken)
        {
            var endereco = new Domain.Entities.Endereco
            {
                Codigo = Guid.NewGuid(),
                Bairro = request.Bairro,
                CEP = request.CEP,
                Cidade = request.Cidade,
                Complemento = request.Complemento,
                CodigoCliente = request.CodigoCliente,
                Estado = request.Estado,
                Logradouro = request.Logradouro,
                Numero = request.Numero
            };

            endereco.Id = await _enderecoRepository.InsertAsync(endereco);

            var response = CreateEnderecoCommandResponse.EntityToResponse(endereco);
            return CommandResponseBase<CreateEnderecoCommandResponse>.Create(response, true, [], System.Net.HttpStatusCode.OK);
        }
    }
}
