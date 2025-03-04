namespace MiniERP.Domain.Base.Interfaces
{
    public interface IEntity
    {
        Guid Codigo { get; set; }
        DateTime DtInclusao { get; set; }
        DateTime? DtAlteracao { get; set; }
        int Id { get; set; }
    }
}
