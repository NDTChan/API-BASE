using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Dm.PHE
{
    public class PHE_DM_CONGVIEC : DataInfoEntity
    {
        [StringLength(50)]
        public string MaCongViec { get; set; }

        [StringLength(50)]
        public string MaCha { get; set; }

        [StringLength(50)]
        public string STT { get; set; }

        [StringLength(250)]
        public string TenCongViec { get; set; }

        public int? ThoiGian { get; set; }

        public DateTime? TuNgay { get; set; }

        public DateTime? DenNgay { get; set; }

        [StringLength(250)]
        public string NguoiThucHien { get; set; }

        [StringLength(250)]
        public string NguoiGiamSat { get; set; }

        [StringLength(250)]
        public string DonViPheDuyet { get; set; }

        [StringLength(500)]
        public string VanBanDinhKem { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

    }
}
