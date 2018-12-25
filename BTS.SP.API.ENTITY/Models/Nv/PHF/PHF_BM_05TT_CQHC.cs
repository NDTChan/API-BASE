using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Nv.PHF
{
    [Table("PHF_BM_05TT_CQHC")]
    public class PHF_BM_05TT_CQHC : DataInfoEntityPHF
    {
        [Column("STT")]
        [Description("Số thứ tự")]
        public int STT { get; set; }

        [Column("STT_TIEUDE")]
        [Description("Số thứ tự tiêu đề")]
        [StringLength(5)]
        public string STT_TIEUDE { get; set; }

        [Column("STT_CHA")]
        [Description("Số thứ tự cha")]
        public int STT_CHA { get; set; }

        [Column("MA_FILE")]
        [StringLength(200)]
        [Description("Mã file Template")]
        public string MA_FILE { get; set; }

        [Column("MA_FILE_PK")]
        [StringLength(200)]
        [Description("Mã file pk Template")]
        public string MA_FILE_PK { get; set; }

        [Column("HO_VATEN")]
        [StringLength(1000)]
        [Description("Họ và tên")]
        public string HO_VATEN { get; set; }

        [Column("CHI_LUONG_SCD")]
        [StringLength(1000)]
        [Description("Chi lương sai chế độ")]
        public string CHI_LUONGSCD { get; set; }

        [Column("CHI_BHYTBHXH_SCD")]
        [StringLength(1000)]
        [Description("Chi BHYT, BHXH sai chế độ")]
        public string CHI_BHYTBHXH_SCD { get; set; }

        [Column("CHI_THUNHAP")]
        [StringLength(1000)]
        [Description("Chi thu nhập tăng them không đúng")]
        public string CHI_THUNHAP { get; set; }

        [Column("CHI_KHENTHUONG")]
        [StringLength(1000)]
        [Description("Chi khen thưởng phúc lợi sai quy định")]
        public string CHI_KHENTHUONG { get; set; }

        [Column("CHI_KHAC")]
        [StringLength(1000)]
        [Description("Chi khác")]
        public string CHI_KHAC { get; set; }

        [Column("GHI_CHU")]
        [StringLength(1000)]
        [Description("Ghi chú")]
        public string GHI_CHU { get; set; }

        [Column("IS_BOLD")]
        [Description("Font in đậm")]
        public int IS_BOLD { get; set; }

        [Column("IS_ITALIC")]
        [Description("Font in nghiêng")]
        public int IS_ITALIC { get; set; }

    }
}
