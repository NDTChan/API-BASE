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
    public class DM_DOTTHANHTRAVm
    {
        public class ViewModel
        {
            public string MA_DOT { get; set; }
            public string TEN_DOT { get; set; }
            public DateTime TU_NGAY { get; set; }
            public DateTime DEN_NGAY { get; set; }
            public Nullable<int> TRANG_THAI { get; set; }
        }


        public class Search : IDataSearch
        {
            public string MA_DOT { get; set; }
            public string TEN_DOT { get; set; }
            public string DefaultOrder
            {
                get
                {
                    return ClassHelper.GetPropertyName(() => new PHF_DM_DOTTHANHTRA().MA_DOT);

                }
            }

            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new PHF_DM_DOTTHANHTRA();

                if (!string.IsNullOrEmpty(this.MA_DOT))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_DOT),
                        Value = this.MA_DOT,
                        Method = FilterMethod.Like
                    });
                }
                if (!string.IsNullOrEmpty(this.TEN_DOT))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.TEN_DOT),
                        Value = this.TEN_DOT,
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
                MA_DOT = summary;
                TEN_DOT = summary;
            }
        }

        public class TreeRootModel
        {
            public string value { get; set; }
            public string text { get; set; }
            public bool expanded { get; set; }
            public string spriteCssClass{ get; set; }
            public TreeRootModel()
            {
                items = new List<TreeLeafModel>();
            }
            public List<TreeLeafModel> items = new List<TreeLeafModel>();
        }

        public class TreeLeafModel
        {
            public string value { get; set; }
            public string text { get; set; }
            public bool expanded { get; set; }
            public string spriteCssClass { get; set; }
        }
    }
}
