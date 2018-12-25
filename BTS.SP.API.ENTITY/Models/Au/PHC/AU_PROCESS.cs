using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTS.SP.API.ENTITY.Models.Au.PHC
{
    [Table("AU_PROCESS")]
    public class AU_PROCESS : DataInfoEntityPHC
    {
        [Column("PROCESSCODE")]
        [StringLength(50)]
        public string ProcessCode { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(300)]
        public string Description { get; set; }
        [Column("STATE")]
        public ProcessState State { get; set; }
    }
}
