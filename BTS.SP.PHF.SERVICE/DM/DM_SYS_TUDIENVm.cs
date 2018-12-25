using System;
using System.Collections.Generic;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS;
using BTS.SP.TOOLS.BuildQuery;
using BTS.SP.TOOLS.BuildQuery.Types;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.PHF.ENTITY.Sys;

namespace BTS.SP.PHF.SERVICE.DM
{
    public class DM_SYS_TUDIENVm
    {
        public class ViewModel
        {
            public string MA_TUDIEN { get; set; }
            public string TEN_TUDIEN { get; set; }
            public Nullable<int> TRANG_THAI { get; set; }
        }
        public class Search : IDataSearch
        {
            public string MA_TUDIEN { get; set; }
            public string TEN_TUDIEN { get; set; }
            public string LOAI_TUDIEN { get; set; }
            public string DefaultOrder
            {
                get
                {
                    return ClassHelper.GetPropertyName(() => new PHF_SYS_TUDIEN().MA_TUDIEN);

                }
            }

            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new PHF_SYS_TUDIEN();

                if (!string.IsNullOrEmpty(this.MA_TUDIEN))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_TUDIEN),
                        Value = this.MA_TUDIEN,
                        Method = FilterMethod.Like
                    });
                }
                if (!string.IsNullOrEmpty(this.TEN_TUDIEN))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.TEN_TUDIEN),
                        Value = this.TEN_TUDIEN,
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
                MA_TUDIEN = summary;
                TEN_TUDIEN = summary;
            }
        }

        public class DM_DBHCVm
        {
            public string Value { get; set; }
            public string Text { get; set; }
            public string MA_T { get; set; }
            public string MA_H { get; set; }
            public string MA_X { get; set; }
            public string MA_DBHC { get; set; }
            public string TEN_DBHC { get; set; }
            public Nullable<int> LOAI { get; set; }
            public string MA_DBHC_CHA { get; set; }
            public string USER_NAME { get; set; }
            public Nullable<DateTime> NGAY_PS { get; set; }
            public Nullable<DateTime> NGAY_SD { get; set; }
            public DateTime NGAY_HL { get; set; }
            public Nullable<DateTime> NGAY_HET_HL { get; set; }
            public string MA_THAMCHIEU { get; set; }
            public string CAN_CU { get; set; }
            public Nullable<int> VALID { get; set; }
            public string TRANG_THAI { get; set; }
        }
    }
}
