using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Au.PHB
{
    [Table("PHB_AU_VAITRO")]
    public class PHB_AU_VAITRO:DataInfoEntity
    {
        [Column("MAVAITRO")]
        [StringLength(50)]
        [Required]
        public string MAVAITRO { get; set; }

        [Column("TENVAITRO")]
        [StringLength(100)]
        public string TENVAITRO { get; set; }

        [Column("MOTA")]
        [StringLength(200)]
        public string MOTA { get; set; }

        [Column("TRANGTHAI")]
        [Description("1: sudung | 0 : khongsudung")]
        public int TRANGTHAI { get; set; }
    }
}
