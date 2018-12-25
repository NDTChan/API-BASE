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

namespace BTS.SP.PHF.SERVICE.NV.XayDungKeHoachThanhTraBo
{
    public class NV_XD_KH_THANHTRA_BOVm
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
            public string DOT_THANHTRA { get; set; }
            public string MA_PHONGBAN { get; set; }
            public int NAM { get; set; }
            public string DefaultOrder
            {

                get
                {
                    return ClassHelper.GetPropertyName(() => new PHF_XD_KH_THANHTRA_BO().MA_PHIEU);

                }
            }

            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new PHF_XD_KH_THANHTRA_BO();

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
                        Property = ClassHelper.GetProperty(() => refObj.MA_DOITUONG),
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
                        Method = FilterMethod.Like
                    });
                }
                if(!string.IsNullOrEmpty(this.DOT_THANHTRA))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.DOT_THANHTRA),
                        Value = this.DOT_THANHTRA,
                        Method = FilterMethod.Like
                    });
                }
                if (this.NAM != 0)
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.NAM),
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
            public DateTime? NGAY_LAPPHIEU { get; set; }
            public string NOIDUNG { get; set; }
            public string DOT_THANHTRA { get; set; }
            public DateTime? TUNGAY { get; set; }
            public DateTime? DENNGAY { get; set; }
            public List<DTO_DETAILS> DETAILS { get; set; }
        }

        public class DTO_DETAILS
        {
            public string MA_PHIEU { get; set; }
            public string KEHOACH_THANHTRA { get; set; }
            public string LOAI_THANHTRA { get; set; }
            public string NHOM_THANHTRA { get; set; }
            public string PHONG_THANHTRA { get; set; }
            public string DOITUONG_THANHTRA { get; set; }
            public string LYDO_THANHTRA { get; set; }
            public string MA_DOITUONG { get; set; }
            public string MA_DOITUONG_CHA { get; set; }
            public string TEN_DOITUONG { get; set; }
            public string PHONG_CHUTRI { get; set; }
        }
    }
    
}
