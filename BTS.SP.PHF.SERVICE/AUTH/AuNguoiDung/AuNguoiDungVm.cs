using System;
using System.Collections.Generic;
using BTS.SP.PHF.ENTITY.Auth;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.PHF.SERVICE.Services;
using BTS.SP.TOOLS;
using BTS.SP.TOOLS.BuildQuery;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Types;

namespace BTS.SP.PHF.SERVICE.AUTH.AuNguoiDung
{
    public class AuNguoiDungVm
    {
        
        public class ViewModel
        {
            public int ID { get; set; }
            public string USERNAME { get; set; }
            public string FULLNAME { get; set; }
            public string EMAIL { get; set; }
            public string PHONE { get; set; }
            public string GHICHU { get; set; }
            public string MA_DBHC { get; set; }
            public string CHUCVU { get; set; }
            public string MA_QHNS { get; set; }
            public int TRANGTHAI { get; set; }
            public string MA_DONVI { get; set; }
        }
        public class ParameterModel
        {
            public string USERNAME { get; set; }
            public string MA_DONVI { get; set; }
        }
        public class ModelInsert 
        {
            public string USERNAME { get; set; }
            public string PASSWORD { get; set; }
            public string FULLNAME { get; set; }
            public string EMAIL { get; set; }
            public string PHONE { get; set; }
            public string MA_DBHC { get; set; }
            public string CHUCVU { get; set; }
            public string GHICHU { get; set; }
            public int TRANGTHAI { get; set; }
            public string MA_QHNS { get; set; }
            public string MA_DBHC_CHA { get; set; }
            public string MA_PHONGBAN { get; set; }
            public string MA_DONVI { get; set; }
            public int LOAI { get; set; }
        }
        public class ModelUpdate
        {
            public int ID { get; set; }
            public string USERNAME { get; set; }
            public string PASSWORD { get; set; }
            public string FULLNAME { get; set; }
            public string EMAIL { get; set; }
            public string PHONE { get; set; }
            public string MA_DBHC { get; set; }
            public string CHUCVU { get; set; }
            public string GHICHU { get; set; }
            public int TRANGTHAI { get; set; }
            public string MA_QHNS { get; set; }
            public string MA_DBHC_CHA { get; set; }
            public string MA_DONVI { get; set; }
            public int LOAI { get; set; }
        }
        public class Search : IDataSearch
        {
            public string USERNAME { get; set; }
            public string EMAIL { get; set; }
            public string FULLNAME { get; set; }

            public void LoadGeneralParam(string summary)
            {
                USERNAME = summary;
                EMAIL = summary;
                FULLNAME = summary;
            }

            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new AU_NGUOIDUNG();

                if (!string.IsNullOrEmpty(this.USERNAME))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.USERNAME),
                        Value = this.USERNAME,
                        Method = FilterMethod.Like
                    });
                }
                if (!string.IsNullOrEmpty(this.FULLNAME))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.FULLNAME),
                        Value = this.FULLNAME,
                        Method = FilterMethod.Like
                    });
                }
                if (!string.IsNullOrEmpty(this.EMAIL))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.EMAIL),
                        Value = this.EMAIL,
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
                get { return "USERNAME"; }
            }
        }
    }
}
