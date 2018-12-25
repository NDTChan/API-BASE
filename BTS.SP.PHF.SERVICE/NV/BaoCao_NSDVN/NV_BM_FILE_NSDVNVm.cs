using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS;
using BTS.SP.TOOLS.BuildQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.SERVICE.NV.BaoCao_NSDVN
{
    public class NV_BM_FILE_NSDVNVm
    {
        public class ViewModel
        {
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string TEN_FILE { get; set; }
            public int NAM { get; set; }
            public string MA_DOT { get; set; }
            public string THOIGIAN { get; set; }
            public string TEN_BIEUMAU { get; set; }
            public string TIEUDE_BIEUMAU { get; set; }
        }
        public class Search : IDataSearch
        {
            public string MA_FILE { get; set; }
            public int NAM { get; set; }
            public string MA_DOT { get; set; }
            public string DefaultOrder
            {
                get
                {
                    return ClassHelper.GetPropertyName(() => new PHF_BM_FILE_NSDVN().MA_FILE);
                }
            }

            public void LoadGeneralParam(string summary)
            {
                MA_FILE = summary;
            }

            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new PHF_BM_FILE_NSDVN();

                return result;
            }

            public List<IQueryFilter> GetQuickFilters()
            {
                return null;
            }
        }
    }
}
