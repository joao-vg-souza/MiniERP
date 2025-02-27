using MediatR;
using MiniERP.Application.Commands.Endereco.Command;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Commands.Endereco
{
    public class DeleteEnderecoCommandHandler(IEnderecoRepository enderecoRepository) : IRequestHandler<DeleteEnderecoCommand, CommandResponseBase<Unit>>
    {
        private readonly IEnderecoRepository _enderecoRepository = enderecoRepository;

        public async Task<CommandResponseBase<Unit>> Handle(DeleteEnderecoCommand request, CancellationToken cancellationToken)
        {
            var endereco = await _enderecoRepository.GetByIdAsync<Domain.Entities.Endereco>(request.CodigoEndereco);

            if (endereco == null)
                return CommandResponseBase<Unit>.Error<Unit>("Endereço não encontrado", System.Net.HttpStatusCode.BadRequest);

            await _enderecoRepository.DeleteAsync<Domain.Entities.Endereco>(endereco.Codigo);

            return CommandResponseBase<Unit>.Create(new Unit(), true, [], System.Net.HttpStatusCode.OK);
        }
    }
}
