using MediatR;
using MiniERP.Application.Commands.Contato.Command;
using MiniERP.Application.Commands.Contato.Response;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Commands.Contato
{
    public class CreateContatoCommandHandler(IContatoRepository contatoRepository) : IRequestHandler<CreateContatoCommand, CommandResponseBase<CreateContatoCommandResponse>>
    {
        private readonly IContatoRepository _contatoRepository = contatoRepository;

        public async Task<CommandResponseBase<CreateContatoCommandResponse>> Handle(CreateContatoCommand request, CancellationToken cancellationToken)
        {
            var contato = new Domain.Entities.Contato
            {
                Codigo = Guid.NewGuid(),
                CodigoCliente = request.CodigoCliente,
                Email = request.Email,
                TelefoneCelular = request.TelefoneCelular,
                TelefoneFixo = request.TelefoneFixo,
            };

            contato.Id = await _contatoRepository.InsertAsync(contato);

            var response = CreateContatoCommandResponse.EntityToResponse(contato);

            return CommandResponseBase<CreateContatoCommandResponse>.Create(response, true, [], System.Net.HttpStatusCode.OK);
        }
    }
}
