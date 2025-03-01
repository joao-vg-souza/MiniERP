using MediatR;
using MiniERP.Application.Commands.Produto.Command;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Commands.Produto
{
    public class DeleteProdutoCommandHandler(IProdutoRepository produtoRepository) : IRequestHandler<DeleteProdutoCommand, CommandResponseBase<Unit>>
    {
        private readonly IProdutoRepository _produtoRepository = produtoRepository;

        public async Task<CommandResponseBase<Unit>> Handle(DeleteProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByIdAsync<Domain.Entities.Produto>(request.CodigoProduto);

            if (produto == null)
                return CommandResponseBase<Unit>.Error<Unit>("Produto não encontrado", System.Net.HttpStatusCode.BadRequest);

            await _produtoRepository.DeleteAsync<Domain.Entities.Produto>(request.CodigoProduto);

            return CommandResponseBase<Unit>.Create(new Unit(), System.Net.HttpStatusCode.NoContent);
        }
    }
}
