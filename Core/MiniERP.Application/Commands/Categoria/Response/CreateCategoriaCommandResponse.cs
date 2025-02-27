namespace MiniERP.Application.Commands.Categoria.Response
{
    public class CreateCategoriaCommandResponse
    {
        private CreateCategoriaCommandResponse(Domain.Entities.Categoria categoria)
        {
            Codigo = categoria.Codigo;
            Nome = categoria.Nome;
            Descricao = categoria.Descricao;
            DtInclusao = categoria.DtInclusao;
            Id = categoria.Id;
        }

        public Guid Codigo { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime DtInclusao { get; set; }

        public static CreateCategoriaCommandResponse EntityToResponse(Domain.Entities.Categoria categoria) => new(categoria);
    }
}
