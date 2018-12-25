using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU2CP2
{
    [Table("PHB_BIEU2CP2_DETAIL")]
    public class PHB_BIEU2CP2_DETAIL : DataInfoEntity
    {
        [Column("PHB_BIEU2CP2_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_BIEU2CP2")]
        [StringLength(50)]
        public string PHB_BIEU2CP2_REFID { get; set; }

        [Description("NOI_DUNG_CHI")]
        [StringLength(255)]
        [Required]
        public string NOI_DUNG_CHI { get; set; }

        [Description("Mã loại")]
        [StringLength(3)]
        public string MA_LOAI { get; set; }

        [Description("Mã khoản")]
        [StringLength(3)]
        public string MA_KHOAN { get; set; }

        [Description("Mã mục")]
        [StringLength(4)]
        public string MA_MUC { get; set; }

        [Description("Mã tiểu mục")]
        [StringLength(4)]
        public string MA_TIEU_MUC { get; set; }

        [Description("Ngân sách trong nước")]
        public decimal NS_TRONGNUOC { get; set; }

        [Description("Viện trợ")]
        public decimal VIEN_TRO { get; set; }

        [Description("Vay nợ nước ngoài")]
        public decimal VAY_NO_NN { get; set; }

        [Description("Phí được khấu trừ để lại")]
        public decimal PHI_KT_DELAI { get; set; }

        [Description("Nguồn hoạt động khác được để lại")]
        public decimal NGUON_KHAC { get; set; }



    }
}
