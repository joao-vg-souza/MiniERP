using MediatR;
using MiniERP.Application.Commands.Categoria.Command;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Commands.Categoria
{
    public class DeleteCategoriaCommandHandler(ICategoriaRepository categoriaRepository) : IRequestHandler<DeleteCategoriaCommand, CommandResponseBase<Unit>>
    {
        private readonly ICategoriaRepository _categoriaRepository = categoriaRepository;

        public async Task<CommandResponseBase<Unit>> Handle(DeleteCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetByIdAsync<Domain.Entities.Categoria>(request.CodigoCategoria);

            if (categoria == null)
                return CommandResponseBase<Unit>.Error<Unit>("Categoria não encontrada", System.Net.HttpStatusCode.BadRequest);

            await _categoriaRepository.DeleteAsync<Domain.Entities.Categoria>(categoria.Codigo);

            return CommandResponseBase<Unit>.Create(new Unit(), true, [], System.Net.HttpStatusCode.OK);
        }
    }
}
