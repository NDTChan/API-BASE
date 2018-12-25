using BTS.SP.API.ENTITY;
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
    [Table("PHF_THUMUC_FILE")]
    public class PHF_THUMUC_FILE : DataInfoEntityPHF
    {

        [Column("TEN_FILE")]
        [StringLength(250)]
        [Description("Tên File")]
        public string TEN_FILE { get; set; }

        [Column("TIEU_DE")]
        [StringLength(50)]
        [Description("Tiêu đề")]
        public string TIEU_DE { get; set; }

        [Column("SO_PHIEU")]
        [StringLength(50)]
        [Description("Số phiếu nhật ký")]

        public string SO_PHIEU { get; set; }

        [Column("URL")]
        [StringLength(250)]
        [Description("Đường dẫn để lưu tệp upload")]
        public string URL { get; set; }

    }
}
