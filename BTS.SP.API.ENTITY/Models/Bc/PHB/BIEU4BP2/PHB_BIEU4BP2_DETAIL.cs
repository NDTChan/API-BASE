using System.ComponentModel.DataAnnotations;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU4BP2
{
    public class PHB_BIEU4BP2_DETAIL:DataInfoEntity
    {
        [StringLength(50)]
        [Required]
        public string PHB_BIEU4BP2_REFID { get; set; }

        [StringLength(3)]
        public string MA_LOAI { get; set; }

        [StringLength(3)]
        public string MA_KHOAN { get; set; }

        [StringLength(4)]
        public string MA_MUC { get; set; }

        [StringLength(4)]
        public string MA_TIEU_MUC { get; set; }

        [StringLength(255)]
        public string NOI_DUNG_CHI { get; set; }

        public double NSTN { get; set; }
        public double VT { get; set; }
        public double VN { get; set; }
        public double PKT { get; set; }
        public double HDKDL { get; set; }
    }
}
