using MediatR;
using MiniERP.Application.Commands.Contato.Command;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Commands.Contato
{
    public class UpdateContatoCommandHandler(IContatoRepository contatoRepository) : IRequestHandler<UpdateContatoCommand, CommandResponseBase<Unit>>
    {
        private readonly IContatoRepository _contatoRepository = contatoRepository;

        public async Task<CommandResponseBase<Unit>> Handle(UpdateContatoCommand request, CancellationToken cancellationToken)
        {
            var contato = await _contatoRepository.GetByIdAsync<Domain.Entities.Contato>(request.CodigoContato);

            if (contato == null)
                return CommandResponseBase<Unit>.Error<Unit>("Contato não encontrado", System.Net.HttpStatusCode.BadRequest);

            UpdateContato(request, ref contato);

            await _contatoRepository.UpdateAsync(contato);

            return CommandResponseBase<Unit>.Create(new Unit(), true, [], System.Net.HttpStatusCode.Accepted);
        }

        private void UpdateContato(UpdateContatoCommand request, ref Domain.Entities.Contato contato)
        {
            contato.DtAlteracao = DateTime.Now;
            contato.TelefoneCelular = request.TelefoneCelular;
            contato.TelefoneFixo = request.TelefoneFixo;
            contato.Email = request.Email;
        }
    }
}
