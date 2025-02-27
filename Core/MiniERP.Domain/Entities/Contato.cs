using MiniERP.Domain.Base;

namespace MiniERP.Domain.Entities
{
    public class Contato : EntityBase
    {
        public  Guid CodigoCliente { get; set; }
        public  string Email { get; set; }
        public string? TelefoneCelular { get; set; }
        public string? TelefoneFixo { get; set; }
    }
}
