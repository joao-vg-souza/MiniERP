using MiniERP.Domain.Base.Interfaces;

namespace MiniERP.Application.Queries.Base
{
    public class BaseEntityResponse
    {
        public Guid Codigo { get; set; }
        public int Id { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime? DtAlteracao { get; set; }

        protected BaseEntityResponse(IEntity entity)
        {
            Codigo = entity.Codigo;
            Id = entity.Id;
            DtInclusao = entity.DtInclusao;
            DtAlteracao = entity.DtAlteracao;
        }
    }
}
