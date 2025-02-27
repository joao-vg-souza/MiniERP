namespace MiniERP.Application.Commands.Contato.Response
{
    public class CreateContatoCommandResponse
    {
        private CreateContatoCommandResponse(Domain.Entities.Contato contato)
        {
            Codigo = contato.Codigo;
            Id = contato.Id;
            CodigoCliente = contato.CodigoCliente;
            Email = contato.Email;
            TelefoneCelular = contato.TelefoneCelular;
            TelefoneFixo = contato.TelefoneFixo;
        }
        public Guid Codigo { get; set; }
        public int Id { get; set; }
        public Guid CodigoCliente { get; set; }
        public string Email { get; set; }
        public string? TelefoneCelular { get; set; }
        public string? TelefoneFixo { get; set; }

        public static CreateContatoCommandResponse EntityToResponse(Domain.Entities.Contato contato) => new(contato);
    }
}
