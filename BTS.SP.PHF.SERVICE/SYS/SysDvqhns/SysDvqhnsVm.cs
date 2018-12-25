using System.Collections.Generic;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS.BuildQuery;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Types;
using BTS.SP.TOOLS;
using BTS.SP.PHF.ENTITY.Sys;
using System;

namespace BTS.SP.PHF.SERVICE.SYS.SysDvqhns
{
    public class SysDvqhnsVm
    {
        public class ViewModel
        {
            public string MA_QHNS { get; set; }
            public string TEN_QHNS { get; set; }
            public string MA_QHNS_CHA { get; set; }
            public string MA_CHUONG { get; set; }
        }
        public class Search : IDataSearch
        {
            public string MA_DVQHNS { get; set; }
            public string TEN_DVQHNS { get; set; }
            public string MA_DVQHNS_CHA { get; set; }
            public string MA_CHUONG { get; set; }

            public void LoadGeneralParam(string summary)
            {
                MA_DVQHNS = summary;
                TEN_DVQHNS = summary;
                MA_DVQHNS_CHA = summary;
                MA_CHUONG = summary;
            }

            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new SYS_DVQHNS();

                if (!string.IsNullOrEmpty(this.MA_DVQHNS))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_DVQHNS),
                        Value = this.MA_DVQHNS,
                        Method = FilterMethod.Like
                    });
                }
                if (!string.IsNullOrEmpty(this.TEN_DVQHNS))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.TEN_DVQHNS),
                        Value = this.TEN_DVQHNS,
                        Method = FilterMethod.Like
                    });
                }
                if (!string.IsNullOrEmpty(this.MA_DVQHNS_CHA))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_DVQHNS_CHA),
                        Value = this.MA_DVQHNS_CHA,
                        Method = FilterMethod.Like
                    });
                }
                if (!string.IsNullOrEmpty(this.MA_CHUONG))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_CHUONG),
                        Value = this.MA_CHUONG,
                        Method = FilterMethod.EqualTo
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
                get { return ClassHelper.GetPropertyName(() => new SYS_DVQHNS().MA_DVQHNS); }
            }
        }

        public class SearchCTMT
        {
            public string MA_CTMTQG { get; set; }
            public DateTime NGAY_HL { get; set; }
            public Nullable<DateTime> NGAY_HET_HL { get; set; }
            public string TEN_CTMTQG { get; set; }
            public string TRANG_THAI { get; set; }
            public string MA_CTMTQG_CHA { get; set; }
            public string LOAI_CTMTQG { get; set; }
            public string GHI_CHU { get; set; }
            public string USER_NAME { get; set; }
            public Nullable<DateTime> NGAY_PS { get; set; }
            public Nullable<DateTime> NGAY_SD { get; set; }
        }

        public class PagedObjDTO<T>
        {
            public static int DefaultPageSize;

            public PagedObjDTO()
            {

            }
            public int currentPage { get; set; }
            public List<T> Data { get; set; }
            public int fromItem { get; }
            public int itemsPerPage { get; set; }
            public bool takeAll { get; set; }
            public int toItem { get; }
            public int totalItems { get; set; }
            public int totalPages { get; }
        }

        public class ParamInput
        {
            public string TableName { get; set; }
            public string FieldValue { get; set; }
            public string FieldText{ get; set; }
            public string WhereClause { get; set; }
        }
    }
}
