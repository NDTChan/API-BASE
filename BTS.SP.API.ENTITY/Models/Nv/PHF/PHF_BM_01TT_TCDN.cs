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
    [Table("PHF_BM_01TT_TCDN")]
    public class PHF_BM_01TT_TCDN : DataInfoEntityPHF
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

        [Column("NOIDUNG")]
        [StringLength(1000)]
        [Description("Nội dung thành phần công việc")]
        public string NOIDUNG { get; set; }

        [Column("THOIGIAN_QD")]
        [StringLength(1000)]
        [Description("Thời gian phải ban hành theo quy định")]
        public string THOIGIAN_QD { get; set; }

        [Column("THOIGIAN_TT")]
        [StringLength(1000)]
        [Description("Thời gian thực tế thực hiện")]
        public string THOIGIAN_TT { get; set; }

        [Column("NOIDUNG_BH")]
        [StringLength(1000)]
        [Description("Nội dung ban hành thiếu/sai")]
        public string NOIDUNG_BH { get; set; }

        [Column("HAUQUA")]
        [StringLength(1000)]
        [Description("Hậu quả")]
        public string HAUQUA { get; set; }

        [Column("NGUYENNHAN")]
        [StringLength(1000)]
        [Description("Nguyên nhân")]
        public string NGUYENNHAN { get; set; }

        [Column("KIENNGHI")]
        [StringLength(1000)]
        [Description("Kiến nghị xử lý")]
        public string KIENNGHI { get; set; }

        [Column("IS_BOLD")]
        [Description("Font in đậm")]
        public int IS_BOLD { get; set; }

        [Column("IS_ITALIC")]
        [Description("Font in nghiêng")]
        public int IS_ITALIC { get; set; }
    }
}
