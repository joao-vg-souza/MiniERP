using MiniERP.Application.Queries.Base;

namespace MiniERP.Application.Queries.Categoria.Response
{
    public class GetCategoriaResponse : BaseEntityResponse
    {
        public string Nome { get; set; }
        public string? Descricao { get; set; }

        private GetCategoriaResponse(Domain.Entities.Categoria categoria) : base(categoria)
        {
            Nome = categoria.Nome;
            Descricao = categoria.Descricao;
        }

        public static GetCategoriaResponse EntityToResponse(Domain.Entities.Categoria categoria) => new(categoria);
    }
}
