using MediatR;
using MiniERP.Application.Commands.Endereco.Command;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Commands.Endereco
{
    public class UpdateEnderecoCommandHandler(IEnderecoRepository enderecoRepository) : IRequestHandler<UpdateEnderecoCommand, CommandResponseBase<Unit>>
    {
        private readonly IEnderecoRepository _enderecoRepository = enderecoRepository;

        public async Task<CommandResponseBase<Unit>> Handle(UpdateEnderecoCommand request, CancellationToken cancellationToken)
        {
            var endereco = await _enderecoRepository.GetByIdAsync<Domain.Entities.Endereco>(request.CodigoEndereco);

            if (endereco == null)
                return CommandResponseBase<Unit>.Error<Unit>("Endereço não encontrado", System.Net.HttpStatusCode.BadRequest);

            UpdateEndereco(request, ref endereco);

            await _enderecoRepository.UpdateAsync(endereco);

            return CommandResponseBase<Unit>.Create(new Unit(), System.Net.HttpStatusCode.NoContent);
        }

        private void UpdateEndereco(UpdateEnderecoCommand request, ref Domain.Entities.Endereco endereco)
        {
            endereco.Bairro = request.Bairro;
            endereco.CEP = request.CEP;
            endereco.Cidade = request.Cidade;
            endereco.Complemento = request.Complemento;
            endereco.Estado = request.Estado;
            endereco.Logradouro = request.Logradouro;
            endereco.Numero = request.Numero;
            endereco.DtAlteracao = DateTime.Now;
        }
    }
}
