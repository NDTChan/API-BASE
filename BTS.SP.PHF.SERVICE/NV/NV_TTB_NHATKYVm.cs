using BTS.SP.PHF.ENTITY.Nv;
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

namespace BTS.SP.PHF.SERVICE.NV
{
    public class NV_TTB_NHATKYVm
    {
        public class ViewModel
        {
            public string SO_PHIEU { get; set; }
            public string MA_DOITUONG { get; set; }
            public string NGUOI_BAOCAO { get; set; }
            public string NOIDDUNG_BAOCAO { get; set; }
            public Nullable<int> TRANG_THAI { get; set; }
            public string TENTEP { get; set; }
            public DateTime? TU_NGAY { get; set; }
            public DateTime? DEN_NGAY { get; set; }
            public string CONGVIEC_THUCHIEN { get; set; }
            public string QD_SO { get; set; }

        }
        public class Search : IDataSearch
        {
            public string SO_PHIEU { get; set; }
            public string NGUOI_BAOCAO { get; set; }
            public string MA_DOITUONG { get; set; }
            public string MA_PHONGBAN { get; set; }
            public string MA_DOT { get; set; }
            public int NAM { get; set; }
            public DateTime? TU_NGAY { get; set; }
            public DateTime? DEN_NGAY { get; set; }
            public DateTime? NGAY_LUUTRU { get; set; }
            public string DefaultOrder
            {

                get
                {
                    return ClassHelper.GetPropertyName(() => new PHF_TTB_NHATKY().NGAY_LUUTRU);

                }
            }

            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new PHF_TTB_NHATKY();

                if (!string.IsNullOrEmpty(this.SO_PHIEU))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.SO_PHIEU),
                        Value = this.SO_PHIEU,
                        Method = FilterMethod.Like
                    });
                }
                if (!string.IsNullOrEmpty(this.NGUOI_BAOCAO))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.NGUOI_BAOCAO),
                        Value = this.NGUOI_BAOCAO,
                        Method = FilterMethod.Like
                    });
                }
                if(!string.IsNullOrEmpty(this.MA_DOITUONG))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_DOITUONG),
                        Value = this.MA_DOITUONG,
                        Method = FilterMethod.Like
                    });
                }
                if(!string.IsNullOrEmpty(this.MA_PHONGBAN))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_PHONGBAN),
                        Value = this.MA_PHONGBAN,
                        Method = FilterMethod.EqualTo
                    });
                }
                if (this.NGAY_LUUTRU.HasValue)
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.NGAY_LUUTRU),
                        Value = this.NGAY_LUUTRU,
                        Method = FilterMethod.EqualTo
                    });
                }
                if (!string.IsNullOrEmpty(this.MA_DOT))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_DOT),
                        Value = this.MA_DOT,
                        Method = FilterMethod.Like
                    });
                }
                if (this.NAM != 0)
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.NAM),
                        Value = this.NAM,
                        Method = FilterMethod.EqualTo
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
                SO_PHIEU = summary;
                NGUOI_BAOCAO = summary;
            }
        }
    }
}

