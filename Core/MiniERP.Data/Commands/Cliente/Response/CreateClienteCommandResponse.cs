namespace MiniERP.Application.Commands.Cliente.Response
{
    public class CreateClienteCommandResponse
    {
        private CreateClienteCommandResponse(Domain.Entities.Cliente cliente)
        {
            Codigo = cliente.Codigo;
            Nome = cliente.Nome;
            TipoCliente = cliente.TipoCliente;
            Documento = cliente.Documento;
            DtInclusao = cliente.DtInclusao;
        }

        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public int TipoCliente { get; set; }
        public string Documento { get; set; }
        public DateTime DtInclusao { get; set; }

        public static CreateClienteCommandResponse EntityToResponse(Domain.Entities.Cliente cliente) => new(cliente);
    }
}
