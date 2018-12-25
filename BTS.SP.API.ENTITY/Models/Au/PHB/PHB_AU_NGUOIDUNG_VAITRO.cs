using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Au.PHB
{
    [Table("PHB_AU_NGUOIDUNG_VAITRO")]
    public class PHB_AU_NGUOIDUNG_VAITRO:DataInfoEntity
    {
        [Required]
        [StringLength(50)]
        public string USERNAME { get; set; }

        [Required]
        [StringLength(50)]
        public string MAVAITRO { get; set; }
    }
}
