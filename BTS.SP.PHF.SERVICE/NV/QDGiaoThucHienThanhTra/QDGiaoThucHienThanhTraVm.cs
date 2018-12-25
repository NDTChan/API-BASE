using System.Collections.Generic;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS;
using BTS.SP.TOOLS.BuildQuery;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Types;
using System;

namespace BTS.SP.PHF.SERVICE.NV.QDGiaoThucHienThanhTra
{
    public class QDGiaoThucHienThanhTraVm
    {
        public class ViewModel
        {
            public string SO_QUYETDINH { get; set; }
            public int NAM_THANHTRA { get; set; }
            public string DOT_THANHTRA { get; set; }
            public string QD_GIAOTHUCHIEN_THANHTRA { get; set; }
            public string FILE_DINHKEM { get; set; }
        }
        public class Search : IDataSearch
        {
            public string SO_QUYETDINH { get; set; }
            public string DefaultOrder
            {

                get
                {
                    return ClassHelper.GetPropertyName(() => new PHF_QD_GIAOTHUCHIEN_THANHTRA().SO_QUYETDINH);

                }
            }
            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new PHF_QD_GIAOTHUCHIEN_THANHTRA();

                if (!string.IsNullOrEmpty(this.SO_QUYETDINH))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.SO_QUYETDINH),
                        Value = this.SO_QUYETDINH,
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
                SO_QUYETDINH = summary;
            }
        }
        public class DTO
        {
            public int ID { get; set; }
            public string SO_QUYETDINH { get; set; }
            public string DOT_THANHTRA { get; set; }
            public int NAM_THANHTRA { get; set; }
            public DateTime NGAY_QUYETDINH { get; set; }
            public string QD_GIAOTHUCHIEN_THANHTRA { get; set; }
            public string FILE_DINHKEM { get; set; }
        }
    }
}
