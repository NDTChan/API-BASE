using System.Collections.Generic;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS;
using BTS.SP.TOOLS.BuildQuery;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Types;
using System;

namespace BTS.SP.PHF.SERVICE.NV.QDPheDuyetThanhTra
{
    public class QDPheDuyetThanhTraVm
    {
        public class ViewModel
        {
            public string SO_QUYETDINH { get; set; }
            public string DOT_THANHTRA { get; set; }
            public int NAM_THANHTRA_PHULUC { get; set; }
            public int NAM_THANHTRA { get; set; }
            public string FILE_DINHKEM { get; set; }
            public DateTime NGAY_QUYETDINH { get; set; }

            public DateTime? ICreateDate { get; set; }
        }
        public class Search : IDataSearch
        {
            public string SO_QUYETDINH { get; set; }
            public string DefaultOrder
            {

                get
                {
                    return ClassHelper.GetPropertyName(() => new PHF_QD_PHEDUYET_THANHTRA().SO_QUYETDINH);

                }
            }
            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new PHF_QD_PHEDUYET_THANHTRA();

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
            public string FILE_DINHKEM { get; set; }
        }

        public class ArrayAppendix
        {
            public int NO { get; set; }
            public string TITLE { get; set; }
            public string VALUE { get; set; }
            public ArrayAppendix(int Value_1, string Value_2, string Value_3)
            {
                NO = Value_1;
                TITLE = Value_2;
                VALUE = Value_3;
            }
        }
    }
}
