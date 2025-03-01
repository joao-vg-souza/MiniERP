using MediatR;
using MiniERP.Application.Commands.Categoria.Command;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Commands.Categoria
{
    public class UpdateCategoriaCommandHandler(ICategoriaRepository categoriaRepository) : IRequestHandler<UpdateCategoriaCommand, CommandResponseBase<Unit>>
    {
        private readonly ICategoriaRepository _categoriaRepository = categoriaRepository;

        public async Task<CommandResponseBase<Unit>> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetByIdAsync<Domain.Entities.Categoria>(request.CodigoCategoria);

            if (categoria == null)
                return CommandResponseBase<Unit>.Error<Unit>("Categoria não encontrada", System.Net.HttpStatusCode.BadRequest);

            UpdateCategoria(request, ref categoria);

            await _categoriaRepository.UpdateAsync(categoria);

            return CommandResponseBase<Unit>.Create(new Unit(), System.Net.HttpStatusCode.NoContent);
        }

        private void UpdateCategoria(UpdateCategoriaCommand request, ref Domain.Entities.Categoria categoria)
        {
            categoria.Descricao = request.Descricao;
            categoria.Nome = request.Nome;
            categoria.DtAlteracao = DateTime.Now;
        }
    }
}
