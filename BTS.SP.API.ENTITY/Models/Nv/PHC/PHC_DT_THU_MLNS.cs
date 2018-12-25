using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Nv.PHC
{
    [Table("PHC_DT_THU_MLNS")]
    public class PHC_DT_THU_MLNS : DataInfoEntityPHC
    {
        [Column("MADUTOAN")]
        [StringLength(20)]
        [Description("Mã dự toán")]
        public string MADUTOAN { get; set; }

        [Column("NOIDUNG")]
        [StringLength(500)]
        [Description("Nội dung")]
        public string NOIDUNG { get; set; }

        [Column("NGAY_QD")]
        [Description("Ngày quyết định")]
        public Nullable<DateTime> NGAY_QD { get; set; }

        [Column("NGAY_HT")]
        [Description("Ngày hạc toán")]
        public Nullable<DateTime> NGAY_HT { get; set; }

        [Column("SO_QD")]
        [Description("Số quyết định")]
        public Nullable<int> SO_QD { get; set; }

        [Column("SO_CTGS")]
        [Description("Số CTGS")]
        public Nullable<int> SO_CTGS { get; set; }

        //DAUNAM = 1,
        //BOSUNG = 2,
        //DIEUCHINH = 3,
        //HUY = 4,
        [Column("LOAI_DT")]
        [Description("Loại Dự toán")]
        public Nullable<int> LOAI_DT { get; set; }

        [Column("FILE_NAME")]
        [StringLength(300)]
        [Description("File đính kèm")]
        public string FILE_NAME { get; set; }

    }
}
