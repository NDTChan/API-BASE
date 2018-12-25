using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHA
{
    [Table("DM_BAOCAO_DETAIL")]
    public class DM_BAOCAO_DETAIL : DataInfoEntity
    {
        [Column("MABAOCAO")]
        [StringLength(100)]
        public string MABAOCAO { get; set; }

        [Column("TENBAOCAO")]
        [StringLength(200)]
        public string TENBAOCAO { get; set; }
        [Column("LOAIBAOCAO")]
        [StringLength(200)]
        public string LOAIBAOCAO { get; set; }
        [Column("USER_NAME")]
        [StringLength(20)]
        public string USER_NAME { get; set; }

        [Column("DUONGDAN", TypeName = "VARCHAR2")]
        [StringLength(2000)]
        public string DUONGDAN { get; set; }

        [Column("MATKKHOBAC")]
        [StringLength(200)]
        public string MATKKHOBAC { get; set; }

        [Column("DONVIQUANHENS")]
        [StringLength(200)]
        public string DONVIQUANHENS { get; set; }

        [Column("TUNGAY_HL")]
        public DateTime TUNGAY_HL { get; set; }

        [Column("DENNGAY_HL")]
        public DateTime DENNGAY_HL { get; set; }

        [Column("DENNGAY_KS")]
        public DateTime DENNGAY_KS { get; set; }

        [Column("TUNGAY_KS")]
        public DateTime TUNGAY_KS { get; set; }

        [Column("DONVITIEN")]
        public int DONVITIEN { get; set; }

        [Column("CONGTHUC")]
        [StringLength(500)]
        public string CONGTHUC { get; set; }

        [Column("FILE_VIEW", TypeName = "VARCHAR2")]
        [StringLength(2000)]
        public string FILE_VIEW { get; set; }

        [Column("DO_UUTIEN")]
        public int DO_UUTIEN { get; set; }

        [Column("LOAI_BC")]
        [StringLength(10)]
        public string LOAI_BC { get; set; }

        [Column("NGAY_TAO")]
        public DateTime? NGAY_TAO { get; set; }

        [Column("NGUOI_TAO")]
        [StringLength(200)]
        public string NGUOI_TAO { get; set; }

        [Column("MA_CHA")]
        [StringLength(50)]
        public string MA_CHA { get; set; }

        [Column("LOAI_INDEX")]
        public int LOAI_INDEX { get; set; }

        [Column("PART_REPORT")]
        [StringLength(1000)]
        public string PART_REPORT { get; set; }

        [Column("STATE")]
        [StringLength(200)]
        public string STATE { get; set; }

        [Column("GROUP_NAME")]
        [StringLength(100)]
        public string GROUP_NAME { get; set; }

        [Column("MAU_SO")]
        [StringLength(100)]
        public string MAU_SO { get; set; }

        [Column("BC_THEO")]
        public int? BC_THEO { get; set; }  //1. Theo Chỉ tiêu; 2. Theo ĐVQHNS; 3. Theo địa bàn

        [Column("MA_DIABAN")]
        [StringLength(50)]
        public string MA_DIABAN { get; set; }

        [Column("STT")]
        public int? STT { get; set; }
    }
}
