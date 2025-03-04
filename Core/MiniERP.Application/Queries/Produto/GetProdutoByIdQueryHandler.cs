using MediatR;
using MiniERP.Application.Queries.Pedido.Response;
using MiniERP.Application.Queries.Produto.Query;
using MiniERP.Application.Queries.Produto.Response;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Queries.Produto
{
    public class GetProdutoByIdQueryHandler(IProdutoRepository produtoRepository) : IRequestHandler<GetProdutoByIdQuery, CommandResponseBase<GetProdutoResponse>>
    {
        private readonly IProdutoRepository _produtoRepository = produtoRepository;

        public async Task<CommandResponseBase<GetProdutoResponse>> Handle(GetProdutoByIdQuery request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByIdAsync<Domain.Entities.Produto>(request.Codigo);

            if (produto == null)
                return CommandResponseBase<GetProdutoResponse>.Error<GetProdutoResponse>("Produto não encontrado", System.Net.HttpStatusCode.BadRequest);

            var response = GetProdutoResponse.EntityToResponse(produto);

            return CommandResponseBase<GetProdutoResponse>.Create<GetProdutoResponse>(response);
        }
    }
}
