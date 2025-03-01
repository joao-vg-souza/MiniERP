using MediatR;
using MiniERP.Application.Commands.Contato.Command;
using MiniERP.Domain.Entities;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Commands.Contato
{
    public class DeleteContatoCommandHandler(IContatoRepository contatoRepository) : IRequestHandler<DeleteContatoCommand, CommandResponseBase<Unit>>
    {
        private readonly IContatoRepository _contatoRepository = contatoRepository;

        public async Task<CommandResponseBase<Unit>> Handle(DeleteContatoCommand request, CancellationToken cancellationToken)
        {
            var contato = await _contatoRepository.GetByIdAsync<Domain.Entities.Contato>(request.CodigoContato);

            if (contato == null)
                return CommandResponseBase<Unit>.Error<Unit>("Contato não encontrado", System.Net.HttpStatusCode.BadRequest);

            await _contatoRepository.DeleteAsync<Domain.Entities.Contato>(contato.Codigo);

            return CommandResponseBase<Unit>.Create(new Unit(), System.Net.HttpStatusCode.NoContent);
        }
    }
}
