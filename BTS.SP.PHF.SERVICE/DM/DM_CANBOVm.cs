using BTS.SP.PHF.ENTITY.Dm;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS;
using BTS.SP.TOOLS.BuildQuery;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Types;
using System;
using System.Collections.Generic;

namespace BTS.SP.PHF.SERVICE.DM
{
    public class DM_CANBOVm
    {
        public class ViewModel
        {
            public string MA_CANBO { get; set; }

            public string TEN_CANBO { get; set; }

            public Nullable<int> TRANG_THAI { get; set; }

            public string MA_PHONG { get; set; }
            public string MA_CHUCVU { get; set; }
            public int? GIOI_TINH { get; set; }
            public DateTime? NGAY_SINH { get; set; }
            public string SO_PHONG { get; set; }
            public string SO_MAY_LE { get; set; }
            public string DI_DONG { get; set; }


        }
        public class Search : IDataSearch
        {
            public string MA_CANBO { get; set; }
            public string TEN_CANBO { get; set; }
            public string DefaultOrder
            {

                get
                {
                    return ClassHelper.GetPropertyName(() => new PHF_DM_CANBO().MA_CANBO);

                }
            }

            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new PHF_DM_CANBO();

                if (!string.IsNullOrEmpty(this.MA_CANBO))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_CANBO),
                        Value = this.MA_CANBO,
                        Method = FilterMethod.Like
                    });
                }
                if (!string.IsNullOrEmpty(this.TEN_CANBO))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.TEN_CANBO),
                        Value = this.TEN_CANBO,
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
                MA_CANBO = summary;
                TEN_CANBO = summary;
            }
        }
    }
}
