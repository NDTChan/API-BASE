using System;
using System.Collections.Generic;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS;
using BTS.SP.TOOLS.BuildQuery;
using BTS.SP.TOOLS.BuildQuery.Types;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.PHF.ENTITY.Dm;

namespace BTS.SP.PHF.SERVICE.DM
{
    public class DM_DOITUONGVm
    {
        public class ViewModel
        {
            public string MA_DOITUONG { get; set; }
            public string TEN_DOITUONG { get; set; }
            public int NAM { get; set; }
            public string MA_DVQHNS { get; set; }
            public Nullable<int> TRANG_THAI { get; set; }
        }

        public class Search : IDataSearch
        {
            public string MA_DOITUONG { get; set; }
            public string TEN_DOITUONG { get; set; }
            public string DefaultOrder
            {
                get
                {
                    return ClassHelper.GetPropertyName(() => new PHF_DM_DOITUONG().MA_DOITUONG);
                }
            }

            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new PHF_DM_DOITUONG();

                if (!string.IsNullOrEmpty(this.MA_DOITUONG))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_DOITUONG),
                        Value = this.MA_DOITUONG,
                        Method = FilterMethod.Like
                    });
                }
                if (!string.IsNullOrEmpty(this.TEN_DOITUONG))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.TEN_DOITUONG),
                        Value = this.TEN_DOITUONG,
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
                MA_DOITUONG = summary;
                TEN_DOITUONG = summary;
            }
        }     
    }
}
