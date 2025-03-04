using MiniERP.Application.Queries.Base;

namespace MiniERP.Application.Queries.Cliente.Response
{
    public class GetClienteResponse : BaseEntityResponse
    {
        private GetClienteResponse(Domain.Entities.Cliente cliente) : base(cliente)
        {
            Nome = cliente.Nome;
            TipoCliente = cliente.TipoCliente;
            Documento = cliente.Documento;
        }

        public string Nome { get; set; }
        public int TipoCliente { get; set; }
        public string Documento { get; set; }

        public static GetClienteResponse EntityToResponse(Domain.Entities.Cliente cliente) => new(cliente);
    }
}
