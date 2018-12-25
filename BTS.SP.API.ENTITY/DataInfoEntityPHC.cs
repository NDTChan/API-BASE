using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY
{
    public class DataInfoEntityPHC: EntityBase
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("CODELOCATION")]
        [StringLength(5)]
        [Description("Mã địa bàn hành chính, để phân quyền")]
        public string CODELOCATION { get; set; }
    }
}
