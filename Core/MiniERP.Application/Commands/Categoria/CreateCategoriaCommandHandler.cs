using MediatR;
using MiniERP.Application.Commands.Categoria.Command;
using MiniERP.Application.Commands.Categoria.Response;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Commands.Categoria
{
    public class CreateCategoriaCommandHandler(ICategoriaRepository categoriaRepository) : IRequestHandler<CreateCategoriaCommand, CommandResponseBase<CreateCategoriaCommandResponse>>
    {
        private readonly ICategoriaRepository _categoriaRepository = categoriaRepository;

        public async Task<CommandResponseBase<CreateCategoriaCommandResponse>> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = new Domain.Entities.Categoria
            {
                Codigo = Guid.NewGuid(),
                Descricao = request.Descricao,
                Nome = request.Nome
            };
            
            categoria.Id = await _categoriaRepository.InsertAsync(categoria);

            var response = CreateCategoriaCommandResponse.EntityToResponse(categoria);
            return CommandResponseBase<CreateCategoriaCommandResponse>.Create(response);
        }
    }
}
