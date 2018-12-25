using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Au.PHB
{
    [Table("PHB_AU_VAITRO_CHUCNANG")]
    public class PHB_AU_VAITRO_CHUCNANG:DataInfoEntity
    {
        [Column("MAVAITRO")]
        [StringLength(50)]
        [Required]
        public string MAVAITRO { get; set; }

        [Column("MACHUCNANG")]
        [StringLength(50)]
        [Required]
        public string MACHUCNANG { get; set; }

        [Column("XEM")]
        [Required]
        public bool XEM { get; set; }

        [Column("THEM")]
        [Required]
        public bool THEM { get; set; }

        [Column("SUA")]
        [Required]
        public bool SUA { get; set; }

        [Column("XOA")]
        [Required]
        public bool XOA { get; set; }

        [Column("DUYET")]
        [Required]
        public bool DUYET { get; set; }

        [Column("TRANGTHAI")]
        public int TRANGTHAI { get; set; }
    }
}
