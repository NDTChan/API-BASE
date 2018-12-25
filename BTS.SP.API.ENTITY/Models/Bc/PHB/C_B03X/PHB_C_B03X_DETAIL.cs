using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.C_B03X
{
    [Table("PHB_C_B03X_DETAIL")]
    public class PHB_C_B03X_DETAIL : DataInfoEntity
    {
        [Column("PHB_C_B03X_REFID")]
        [Required]
        [Description("Guid ID trong  PHB_C_B03X")]
        [StringLength(50)]
        public string PHB_C_B03X_REFID { get; set; }

        public double THU_DUTOAN_TONG { get; set; }
        public double THU_THUCHIEN_TONG { get; set; }
        public double THU_DUTOAN_XAHUONG100 { get; set; }
        public double THU_THUCHIEN_XAHUONG100 { get; set; }
        public double THU_DUTOAN_PHANCHIATYLE { get; set; }
        public double THU_THUCHIEN_PHANCHIATYLE { get; set; }
        public double THU_DUTOAN_THUBOSUNG { get; set; }
        public double THU_THUCHIEN_THUBOSUNG { get; set; }
        public double THU_DUTOAN_BOSUNGCANDOI { get; set; }
        public double THU_THUCHIEN_BOSUNGCANDOI { get; set; }
        public double THU_DUTOAN_BOSUNGCOMUCTIEU { get; set; }
        public double THU_THUCHIEN_BOSUNGCOMUCTIEU { get; set; }
        public double THU_DUTOAN_THUCHUYENNGUON { get; set; }
        public double THU_THUCHIEN_THUCHUYENNGUON { get; set; }

        public double CHI_DUTOAN_TONG { get; set; }
        public double CHI_THUCHIEN_TONG { get; set; }
        public double CHI_DUTOAN_DTPT { get; set; }
        public double CHI_THUCHIEN_DTPT { get; set; }
        public double CHI_DUTOAN_CTX { get; set; }
        public double CHI_THUCHIEN_CTX { get; set; }
        public double CHI_DUTOAN_CHICHUYENNGUON { get; set; }
        public double CHI_THUCHIEN_CHICHUYENNGUON { get; set; }

        public double KETDU_NGANSACH { get; set; }
    }
}
