using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS;
using BTS.SP.TOOLS.BuildQuery;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.SERVICE.NV.ThuMucFile
{
    public class THUMUCFILEVm
    {
        public class ViewModel
        {
            public string SO_PHIEU { get; set; }
            public string TEN_FILE { get; set; }
            public string TIEU_DE { get; set; }
            public string URL { get; set; }          
        }
        public class Search : IDataSearch
        {
            public string SO_PHIEU { get; set; }
            public string NGUOI_BAOCAO { get; set; }

            public string DefaultOrder
            {

                get
                {
                    return ClassHelper.GetPropertyName(() => new PHF_THUMUC_FILE().SO_PHIEU);

                }
            }

            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new PHF_THUMUC_FILE();

                if (!string.IsNullOrEmpty(this.SO_PHIEU))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.SO_PHIEU),
                        Value = this.SO_PHIEU,
                        Method = FilterMethod.Like
                    });
                }
                if (!string.IsNullOrEmpty(this.NGUOI_BAOCAO))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.TEN_FILE),
                        Value = this.NGUOI_BAOCAO,
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
                SO_PHIEU = summary;
                NGUOI_BAOCAO = summary;
            }
        }
    }
}
