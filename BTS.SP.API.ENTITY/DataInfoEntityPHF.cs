using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY
{
    public class DataInfoEntityPHF : EntityBase
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("I_CREATE_DATE")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "yyyy/MM/dd", ApplyFormatInEditMode = true)]
        public virtual DateTime? ICreateDate { get; set; }

        [Column("I_CREATE_BY")]
        [StringLength(50)]
        public virtual string ICreateBy { get; set; }

        [Column("I_UPDATE_DATE")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "yyyy/MM/dd", ApplyFormatInEditMode = true)]
        public virtual DateTime? IUpdateDate { get; set; }

        [Column("I_UPDATE_BY")]
        [StringLength(50)]
        public virtual string IUpdateBy { get; set; }

        [Column("I_STATE")]
        [StringLength(50)]
        public virtual string IState { get; set; }
        [Column("UNITCODE")]
        [Description("Mã đơn vị")]
        [StringLength(50)]
        public string UnitCode { get; set; }

    }
}
