using MediatR;
using MiniERP.Application.Queries.Pedido.Response;
using MiniERP.Application.Queries.Produto.Query;
using MiniERP.Application.Queries.Produto.Response;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Queries.Produto
{
    public class GetAllProdutoQueryHandler(IProdutoRepository produtoRepository) : IRequestHandler<GetAllProdutoQuery, CommandResponseBase<IEnumerable<GetProdutoResponse>>>
    {
        private readonly IProdutoRepository _produtoRepository = produtoRepository;

        public async Task<CommandResponseBase<IEnumerable<GetProdutoResponse>>> Handle(GetAllProdutoQuery request, CancellationToken cancellationToken)
        {
            var produtos = await _produtoRepository.GetAllAsync<Domain.Entities.Produto>();

            var responses = new List<GetProdutoResponse>();

            foreach (var item in produtos)
            {
                responses.Add(GetProdutoResponse.EntityToResponse(item));
            }

            return CommandResponseBase<IEnumerable<GetProdutoResponse>>.Create<IEnumerable<GetProdutoResponse>>(responses);
        }
    }
}
