using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY
{
    public class DataInfoEntity : EntityBase
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
    }
}
