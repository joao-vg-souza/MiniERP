using MiniERP.Domain.Base.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MiniERP.Domain.Base
{
    public abstract class EntityBase : IEntity
    {
        [Key]
        public Guid Codigo { get; set; }
        public int Id { get; set; }
        public DateTime DtInclusao { get; set; } = DateTime.Now;
        public DateTime? DtAlteracao { get; set; }
    }
}
