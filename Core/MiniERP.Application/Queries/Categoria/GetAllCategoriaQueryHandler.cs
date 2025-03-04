using MediatR;
using MiniERP.Application.Queries.Categoria.Query;
using MiniERP.Application.Queries.Categoria.Response;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Queries.Categoria
{
    public class GetAllCategoriaQueryHandler(ICategoriaRepository categoriaRepository) : IRequestHandler<GetAllCategoriaQuery, CommandResponseBase<IEnumerable<GetCategoriaResponse>>>
    {
        private readonly ICategoriaRepository _categoriaRepository = categoriaRepository;

        public async Task<CommandResponseBase<IEnumerable<GetCategoriaResponse>>> Handle(GetAllCategoriaQuery request, CancellationToken cancellationToken)
        {
            var categorias = await _categoriaRepository.GetAllAsync<Domain.Entities.Categoria>();

            var responses = new List<GetCategoriaResponse>();

            foreach (var item in categorias)
            {
                responses.Add(GetCategoriaResponse.EntityToResponse(item));
            }

            return CommandResponseBase<IEnumerable<GetCategoriaResponse>>.Create<IEnumerable<GetCategoriaResponse>>(responses);
        }
    }
}
