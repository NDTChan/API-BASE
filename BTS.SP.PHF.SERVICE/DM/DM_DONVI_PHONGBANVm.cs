using BTS.SP.PHF.ENTITY.Dm;
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

namespace BTS.SP.PHF.SERVICE.DM
{
    public class DM_DONVI_PHONGBANVm
    {
        public class Search : IDataSearch
        {
            public string MA{ get; set; }
            public string TEN{ get; set; }
            public string DefaultOrder
            {
                get
                {
                    return ClassHelper.GetPropertyName(() => new PHF_DM_DONVI_PHONGBAN().MA);
                }
            }

            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new PHF_DM_DONVI_PHONGBAN();

                if (!string.IsNullOrEmpty(this.MA))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA),
                        Value = this.MA,
                        Method = FilterMethod.Like
                    });
                }
                if (!string.IsNullOrEmpty(this.TEN))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.TEN),
                        Value = this.TEN,
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
                MA = summary;
                TEN = summary;
            }
        }

        public class DTO
        {
            public DTO()
            {
                items = new List<DTO>();
            }
            public int ID { get; set; }
            public string MA { get; set; }
            public string MA_CHA { get; set; }
            public string TEN { get; set; }
            public string MA_DVQHNS { get; set; }
            public string LOAI { get; set; }
            public string FIELDNAME { get; set; }
            public Nullable<int> TRANGTHAI { get; set; }
            public string MADONVI { get; set; }
            public List<DTO> items { get; set; }
        }

        public class TreeRootModel
        {
            public string value { get; set; }
            public string text { get; set; }
            public bool expanded { get; set; }
            public string spriteCssClass { get; set; }
            public TreeRootModel()
            {
                items = new List<TreeLeafModel>();
            }
            public List<TreeLeafModel> items = new List<TreeLeafModel>();
        }

        public class TreeLevelModel
        {
            public string value { get; set; }
            public string text { get; set; }
            public bool expanded { get; set; }
            public string spriteCssClass { get; set; }
        }

        public class TreeLeafModel
        {
            public string value { get; set; }
            public string text { get; set; }
            public bool expanded { get; set; }
            public string spriteCssClass { get; set; }
            public TreeLeafModel()
            {
                items = new List<TreeLevelModel>();
            }
            public List<TreeLevelModel> items = new List<TreeLevelModel>();
        }


    }
}
