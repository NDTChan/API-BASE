using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.C_B02AX
{
    public class PHB_C_B02AX_DETAIL : DataInfoEntity
    {
        [Column("PHB_C_B02AX_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_C_B02AX_DETAIL_REFID")]
        [StringLength(50)]
        public string PHB_C_B02AX_REFID { get; set; }

        [Description("Sắp xếp")]        
        public int SAP_XEP { get; set; }

        [Description("Số thứ tự")]
        [StringLength(4)]
        public string STT { get; set; }

        [Description("NOI_DUNG_CHI")]
        [StringLength(255)]
        [Required]
        public string NOI_DUNG { get; set; }

        [Description("NOI_DUNG_CHI")]
        [StringLength(255)]
        public string NOI_DUNG_OLD { get; set; }

        [Description("Mã số")]
        [StringLength(3)]
        public string MA_SO { get; set; }       

        [Description("Dự toán năm")]
        public decimal DU_TOAN { get; set; }

        [Description("Thực hiện trong tháng")]
        public decimal TH_TRONG_THANG { get; set; }

        [Description("Lũy kế từ đầu năm")]
        public decimal TH_LUYKE_DN { get; set; }

        [Description("So sánh thực hiện với dự toán")]
        public decimal SO_SANH { get; set; }
    }
}
