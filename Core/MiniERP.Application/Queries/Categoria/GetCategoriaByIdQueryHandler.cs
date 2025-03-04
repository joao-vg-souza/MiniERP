using MediatR;
using MiniERP.Application.Queries.Categoria.Query;
using MiniERP.Application.Queries.Categoria.Response;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Queries.Categoria
{
    public class GetCategoriaByIdQueryHandler(ICategoriaRepository categoriaRepository) : IRequestHandler<GetCategoriaByIdQuery, CommandResponseBase<GetCategoriaResponse>>
    {
        private readonly ICategoriaRepository _categoriaRepository = categoriaRepository;

        public async Task<CommandResponseBase<GetCategoriaResponse>> Handle(GetCategoriaByIdQuery request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetByIdAsync<Domain.Entities.Categoria>(request.Codigo);

            if (categoria == null)
                return CommandResponseBase<GetCategoriaResponse>.Error<GetCategoriaResponse>("Categoria não encontrada", System.Net.HttpStatusCode.BadRequest);

            var response = GetCategoriaResponse.EntityToResponse(categoria);

            return CommandResponseBase<GetCategoriaResponse>.Create(response);
        }
    }
}
