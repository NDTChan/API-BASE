using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTS.SP.PHF.ENTITY.Auth;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.PHF.SERVICE.Services;
using BTS.SP.TOOLS.BuildQuery;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Types;
using BTS.SP.TOOLS;

namespace BTS.SP.PHF.SERVICE.AUTH.AuNhomQuyen
{
    public class AuNhomQuyenVm
    {
        public class ViewModel
        {
            public string MANHOMQUYEN { get; set; }
            public string TENNHOMQUYEN { get; set; }
            public string MOTA { get; set; }
        }
        public class Search : IDataSearch
        {
            public string MANHOMQUYEN { get; set; }
            public string MOTA { get; set; }
            public string TENNHOMQUYEN { get; set; }

            public void LoadGeneralParam(string summary)
            {
                MANHOMQUYEN = summary;
                MOTA = summary;
                TENNHOMQUYEN = summary;
            }

            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new AU_NHOMQUYEN();

                if (!string.IsNullOrEmpty(this.MANHOMQUYEN))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MANHOMQUYEN),
                        Value = this.MANHOMQUYEN,
                        Method = FilterMethod.Like
                    });
                }
                if (!string.IsNullOrEmpty(this.TENNHOMQUYEN))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.TENNHOMQUYEN),
                        Value = this.TENNHOMQUYEN,
                        Method = FilterMethod.Like
                    });
                }
                if (!string.IsNullOrEmpty(this.MOTA))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MOTA),
                        Value = this.MOTA,
                        Method = FilterMethod.Like
                    });
                }
                return result;
            }

            public List<IQueryFilter> GetQuickFilters()
            {
                return null;
            }

            public string DefaultOrder
            {
                get { return ClassHelper.GetPropertyName(() => new AU_NHOMQUYEN().MANHOMQUYEN); }
            }
        }
    }
}
