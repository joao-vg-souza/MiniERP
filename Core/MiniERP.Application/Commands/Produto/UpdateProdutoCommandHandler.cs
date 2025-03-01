using MediatR;
using MiniERP.Application.Commands.Produto.Command;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Commands.Produto
{
    public class UpdateProdutoCommandHandler(IProdutoRepository produtoRepository) : IRequestHandler<UpdateProdutoCommand, CommandResponseBase<Unit>>
    {
        private readonly IProdutoRepository _produtoRepository = produtoRepository;

        public async Task<CommandResponseBase<Unit>> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByIdAsync<Domain.Entities.Produto>(request.CodigoProduto);

            if (produto == null) 
                return CommandResponseBase<Unit>.Error<Unit>("Produto não encontrado", System.Net.HttpStatusCode.BadRequest);

            UpdateProduto(request, ref produto);

            await _produtoRepository.UpdateAsync(produto);

            return CommandResponseBase<Unit>.Create(new Unit(), System.Net.HttpStatusCode.NoContent);
        }

        private void UpdateProduto(UpdateProdutoCommand request, ref Domain.Entities.Produto produto)
        {
            produto.Descricao = request.Descricao;
            produto.Ativo = request.Ativo;
            produto.EstoqueAtual = request.EstoqueAtual;
            produto.Nome = request.Nome;
            produto.PrecoCusto = request.PrecoCusto;
            produto.PrecoVenda = request.PrecoVenda;
            produto.DtAlteracao = DateTime.Now;
        }
    }
}
