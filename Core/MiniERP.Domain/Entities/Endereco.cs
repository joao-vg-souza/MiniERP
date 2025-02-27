using MiniERP.Domain.Base;

namespace MiniERP.Domain.Entities
{
    public class Endereco : EntityBase
    {
        public  Guid CodigoCliente { get; set; }
        public  string Logradouro { get; set; }
        public  string Numero { get; set; }
        public string? Complemento { get; set; }
        public  string Bairro { get; set; }
        public  string Cidade { get; set; }
        public  string Estado { get; set; }
        public  string CEP { get; set; }
    }
}
