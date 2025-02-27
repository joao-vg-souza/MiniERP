using MiniERP.Domain.Base;

namespace MiniERP.Domain.Entities
{
    public class Categoria : EntityBase
    {
        public string Nome { get; set; }
        public string? Descricao { get; set; }
    }
}
