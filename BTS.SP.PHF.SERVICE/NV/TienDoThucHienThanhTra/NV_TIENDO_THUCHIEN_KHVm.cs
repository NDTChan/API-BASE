using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS;
using BTS.SP.TOOLS.BuildQuery;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Types;

namespace BTS.SP.PHF.SERVICE.NV.TienDoThucHienThanhTra
{
    public class NV_TIENDO_THUCHIEN_KHVm
    {
        public class ViewModel
        {
            public string MA_PHIEU { get; set; }
            public DateTime? NGAY_LAPPHIEU { get; set; }
            public string NOIDUNG { get; set; }
            public string DOT_THANHTRA { get; set; }
            public DateTime? TUNGAY { get; set; }
            public DateTime? DENNGAY { get; set; }
        }
        public class Search : IDataSearch
        {
            public string MA_PHIEU { get; set; }
            public string MA_DOITUONG { get; set; }
            public string MA_PHONGBAN { get; set; }
            public string MA_DOT { get; set; }
            public int NAM { get; set; }
            public string DefaultOrder
            {

                get
                {
                    return ClassHelper.GetPropertyName(() => new PHF_TIENDO_THUCHIEN_KH().MA_PHIEU);

                }
            }

            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new PHF_TIENDO_THUCHIEN_KH();

                if (!string.IsNullOrEmpty(this.MA_PHIEU))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_PHIEU),
                        Value = this.MA_PHIEU,
                        Method = FilterMethod.Like
                    });
                }
                if (!string.IsNullOrEmpty(this.MA_DOITUONG))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_DOITUONG_TT),
                        Value = this.MA_DOITUONG,
                        Method = FilterMethod.Like
                    });
                }
                if (!string.IsNullOrEmpty(this.MA_PHONGBAN))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_PHONGBAN),
                        Value = this.MA_PHONGBAN,
                        Method = FilterMethod.EqualTo
                    });
                }
                if (!string.IsNullOrEmpty(this.MA_DOT))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_DOT),
                        Value = this.MA_DOT,
                        Method = FilterMethod.Like
                    });
                }
                if (this.NAM != 0)
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.NAM_THANHTRA),
                        Value = this.NAM,
                        Method = FilterMethod.EqualTo
                    });
                }
                return result;

            }

            public List<IQueryFilter> GetQuickFilters()
            {
                return null;
            }

            public void LoadGeneralParam(string summary)
            {
                MA_PHIEU = summary;
            }
        }

        public class DTO
        {
            public DTO()
            {
                DETAILS = new List<DTO_DETAILS>();
            }
            public int ID { get; set; }
            public string MA_PHIEU { get; set; }
            public int NAM_THANHTRA { get; set; }
            public string MA_DOITUONG_TT { get; set; }
            public string NOI_DUNG { get; set; }
            public List<DTO_DETAILS> DETAILS { get; set; }
        }

        public class DTO_DETAILS
        {
            public string MA_PHIEU { get; set; }
            public string DOI_TUONG_TT { get; set; }
            public string KE_HOACH_TT { get; set; }
            public string LOAI_TT { get; set; }
            public string NHOM_TT { get; set; }
            public string PHONG_TT { get; set; }
            public string TRUONGDOAN_TT { get; set; }
            public string THANHVIEN_DOAN { get; set; }
            public string SO_NGAY_THANG_QG { get; set; }
            public string THOIHAN_TT { get; set; }
            public DateTime? NGAY_TRIENKHAI { get; set; }
            public DateTime? NGAY_KETTHUC { get; set; }
            public string GIAMSAT_DOAN { get; set; }
            public string MA_DOITUONG { get; set; }
            public string MA_DOITUONG_CHA { get; set; }
        }

        public class DOITUONG_THANHTRA
        {
            public DOITUONG_THANHTRA()
            {
                PHF_XD_KH_THANHTRA_BO_CHITIETs = new List<PHF_XD_KH_THANHTRA_BO_CHITIET>();
            }
            public string MA_PHIEU { get; set; }
            public List<PHF_XD_KH_THANHTRA_BO_CHITIET> PHF_XD_KH_THANHTRA_BO_CHITIETs { get; set; }
        }
    }
}
