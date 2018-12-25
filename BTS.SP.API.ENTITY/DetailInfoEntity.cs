using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY
{
    public class DetailInfoEntity : EntityBase
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
    }
}
