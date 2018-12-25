using BTS.SP.TOOLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS.BuildQuery;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Types;

namespace BTS.SP.PHF.SERVICE.NV.XayDungKeHoachThanhTraCoQuanThuocBo
{
    public class PHF_KH_THANHTRA_COQUANVm
    {
        public class ViewModel
        {
            public string MA_PHIEU { get; set; }
            public DateTime? NGAYTHANG_LUUTRU { get; set; }
            public string NOIDUNG { get; set; }
            public string DOT_THANHTRA { get; set; }
            public int? NAM_THANHTRA { get; set; }
        }
        public class Search : IDataSearch
        {
            public string MA_PHIEU { get; set; }
            public string DefaultOrder
            {

                get
                {
                    return ClassHelper.GetPropertyName(() => new PHF_KH_THANHTRA_COQUAN().MA_PHIEU);

                }
            }

            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new PHF_KH_THANHTRA_COQUAN();

                if (!string.IsNullOrEmpty(this.MA_PHIEU))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_PHIEU),
                        Value = this.MA_PHIEU,
                        Method = FilterMethod.Like
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
            public DateTime? NGAYTHANG_LUUTRU { get; set; }
            public string NOIDUNG { get; set; }
            public string DOT_THANHTRA { get; set; }
            public int? NAM_THANHTRA { get; set; }
            public List<DTO_DETAILS> DETAILS { get; set; }
        }

        public class DTO_DETAILS
        {
            public string MA_PHIEU { get; set; }
            public string LOAI_THANHTRA { get; set; }
            public string NHOM_THANHTRA { get; set; }
            public string DOITUONG_THANHTRA { get; set; }
            public string COQUAN_THANHTRA { get; set; }
            public string NOIDUNG_THANHTRA { get; set; }
            public string THOIKY_THANHTRA { get; set; }
            public string TEP_DINHKEM { get; set; }
        }
    }
}
