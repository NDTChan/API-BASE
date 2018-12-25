using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS;
using BTS.SP.TOOLS.BuildQuery;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Types;
using System;
using System.Collections.Generic;

namespace BTS.SP.PHF.SERVICE.NV.NamBatTinhHinh.TieuChiDanhGiaRuiRo
{
    public class PHF_TIEUCHI_DGRRVm
    {
        public class ViewModel
        {
            public long Id { get; set; }
            public string REF_ID { get; set; }
            public LOAINHAP_TIEUCHI_DGRR LOAINHAP_TIEUCHI_DGRR { get; set; }
            public LOAIMANHAP LOAIMANHAP { get; set; }
            public string MA_LOAITHANHTRA { get; set; }
            public string MA_DOTTHANHTRA { get; set; }
            public DateTime TUNGAY { get; set; }
            public DateTime DENNGAY { get; set; }
            public List<PHF_TIEUCHI_DGRR_DETAILVm.ViewModel> DETAILS { get; set; }
        }
        public class InsertModel
        {
            public LOAIMANHAP LOAIMANHAP { get; set; }
            public string MA_LOAITHANHTRA { get; set; }
            public string MA_DOTTHANHTRA { get; set; }
            public DateTime TUNGAY { get; set; }
            public DateTime DENNGAY { get; set; }
            public List<PHF_TIEUCHI_DGRR_DETAILVm.InsertModel> DETAILS { get; set; }
        }
        public class Search : IDataSearch
        {
            public string MA_LOAITHANHTRA { get; set; }
            public string MA_DOTTHANHTRA { get; set; }
            public string DefaultOrder
            {
                get
                {
                    return ClassHelper.GetPropertyName(() => new PHF_TIEUCHI_DGRR().Id);
                }
            }

            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new PHF_TIEUCHI_DGRR();

                if (!string.IsNullOrEmpty(MA_LOAITHANHTRA))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_LOAITHANHTRA),
                        Value = this.MA_LOAITHANHTRA,
                        Method = FilterMethod.Like
                    });
                }
                if (!string.IsNullOrEmpty(MA_DOTTHANHTRA))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_DOTTHANHTRA),
                        Value = this.MA_DOTTHANHTRA,
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
                MA_LOAITHANHTRA = summary;
                MA_DOTTHANHTRA = summary;
            }
        }
    }
}
