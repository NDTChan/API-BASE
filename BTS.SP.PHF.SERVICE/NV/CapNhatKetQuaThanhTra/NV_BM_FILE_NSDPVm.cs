using System.Collections.Generic;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS;
using BTS.SP.TOOLS.BuildQuery;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Types;

namespace BTS.SP.PHF.SERVICE.NV.CapNhatKetQuaThanhTra
{
    public class NV_BM_FILE_NSDPVm
    {
        public class ViewModel
        {
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string TEN_FILE { get; set; }
            public int NAM { get; set; }
            public string MA_DOT { get; set; }
            public string THOIGIAN { get; set; }
            public string TEN_BIEUMAU { get; set; }
            public string TIEUDE_BIEUMAU { get; set; }
        }
        public class Search : IDataSearch
        {
            public string MA_FILE { get; set; }
            public int NAM { get; set; }
            public string MA_DOT { get; set; }
            public string DefaultOrder
            {

                get
                {
                    return ClassHelper.GetPropertyName(() => new PHF_BM_FILE_NSDP().MA_FILE);

                }
            }
            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new PHF_BM_FILE_NSDP();

                if (!string.IsNullOrEmpty(this.MA_FILE))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_FILE),
                        Value = this.MA_FILE,
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
                if (!string.IsNullOrEmpty(this.MA_DOT))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_DOT),
                        Value = this.MA_DOT,
                        Method = FilterMethod.StartsWith
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
                MA_FILE = summary;
            }
        }

        public class UploadFileReport_Parameter
        {
            public string UNITCODE { get; set; }
            public string URL { get; set; }
        }

        public class DTO_BM_01TT_NSDP
        {
            public DTO_BM_01TT_NSDP()
            {
                PHF_BM_01TT_NSDP_DTO = new List<PHF_BM_01TT_NSDP_DTO>();
            }
            public int ID { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string TEN_FILE { get; set; }
            public int NAM { get; set; }
            public string MA_DOT { get; set; }
            public string THOIGIAN { get; set; }
            public string TEN_BIEUMAU { get; set; }
            public string TIEUDE_BIEUMAU { get; set; }
            public List<PHF_BM_01TT_NSDP_DTO> PHF_BM_01TT_NSDP_DTO { get; set; }
        }

        public class PHF_BM_01TT_NSDP_DTO
        {
            public int STT { get; set; }
            public string STT_TIEUDE { get; set; }
            public int STT_CHA { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string NOIDUNG { get; set; }
            public string CONGVIEC { get; set; }
            public string TRANGTHAI_TRIENKHAI { get; set; }
            public string VANBAN_SAIPHAM { get; set; }
            public string HAUQUA { get; set; }
            public string NGUYENNHAN { get; set; }
            public int IS_BOLD { get; set; }
            public int IS_ITALIC { get; set; }
        }
    }
}
