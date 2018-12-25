using Repository.Pattern.Ef6;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.PHF.ENTITY
{
    public class BaseEntity:Entity
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("I_CREATE_BY")]
        [StringLength(50)]
        public string ICreateBy { get; set; }

        [Column("I_CREATE_DATE")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "yyyy/MM/dd", ApplyFormatInEditMode = true)]
        public DateTime? ICreateDate { get; set; }

        [Column("I_UPDATE_DATE")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "yyyy/MM/dd", ApplyFormatInEditMode = true)]
        public DateTime? IUpdateDate { get; set; }

        [Column("I_UPDATE_BY")]
        [StringLength(50)]
        public string IUpdateBy { get; set; }

        [Column("I_STATE")]
        [StringLength(50)]
        public string IState { get; set; }

        [Column("UNITCODE")]
        [Description("Mã đơn vị")]
        [StringLength(50)]
        public string UnitCode { get; set; }

    }
}
