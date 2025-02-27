using MiniERP.Domain.Base;

namespace MiniERP.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public string Nome { get; set; }
        public int TipoCliente { get; set; }
        public string Documento { get; set; }
    }
}
