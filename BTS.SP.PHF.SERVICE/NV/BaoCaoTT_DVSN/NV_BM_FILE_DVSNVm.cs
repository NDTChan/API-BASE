using System.Collections.Generic;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS;
using BTS.SP.TOOLS.BuildQuery;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Types;

namespace BTS.SP.PHF.SERVICE.NV.BaoCaoTT_DVSN
{
    public class NV_BM_FILE_DVSNVm
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
                    return ClassHelper.GetPropertyName(() => new ENTITY.Nv.PHF_BM_FILE_DVSN().MA_FILE);

                }
            }
            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new ENTITY.Nv.PHF_BM_FILE_DVSN();

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

        public class DTO_BM_TT_DVSN
        {
            public DTO_BM_TT_DVSN()
            {
                PHF_BM_01TT_DVSN_DTO = new List<PHF_BM_01TT_DVSN_DTO>();
                PHF_BM_02TT_DVSN_DTO = new List<PHF_BM_02TT_DVSN_DTO>();
                PHF_BM_03TT_DVSN_DTO = new List<PHF_BM_03TT_DVSN_DTO>();
                PHF_BM_04TT_DVSN_DTO = new List<PHF_BM_04TT_DVSN_DTO>();
                PHF_BM_05TT_DVSN_DTO = new List<PHF_BM_05TT_DVSN_DTO>();
                PHF_BM_06TT_DVSN_DTO = new List<PHF_BM_06TT_DVSN_DTO>();
                PHF_BM_07TT_DVSN_DTO = new List<PHF_BM_07TT_DVSN_DTO>();
                PHF_BM_08TT_DVSN_DTO = new List<PHF_BM_08TT_DVSN_DTO>();
                PHF_BM_09TT_DVSN_DTO = new List<PHF_BM_09TT_DVSN_DTO>();
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
            public List<PHF_BM_01TT_DVSN_DTO> PHF_BM_01TT_DVSN_DTO { get; set; }
            public List<PHF_BM_02TT_DVSN_DTO> PHF_BM_02TT_DVSN_DTO { get; set; }
            public List<PHF_BM_03TT_DVSN_DTO> PHF_BM_03TT_DVSN_DTO { get; set; }
            public List<PHF_BM_04TT_DVSN_DTO> PHF_BM_04TT_DVSN_DTO { get; set; }
            public List<PHF_BM_05TT_DVSN_DTO> PHF_BM_05TT_DVSN_DTO { get; set; }
            public List<PHF_BM_06TT_DVSN_DTO> PHF_BM_06TT_DVSN_DTO { get; set; }
            public List<PHF_BM_07TT_DVSN_DTO> PHF_BM_07TT_DVSN_DTO { get; set; }
            public List<PHF_BM_08TT_DVSN_DTO> PHF_BM_08TT_DVSN_DTO { get; set; }
            public List<PHF_BM_09TT_DVSN_DTO> PHF_BM_09TT_DVSN_DTO { get; set; }
        }

        public class PHF_BM_01TT_DVSN_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string MA_DONVI { get; set; }
            public string THOI_KY { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string NOIDUNG_CHI { get; set; }
            public decimal? THUCTHI_NAM { get; set; }
            public decimal? QUYETTOAN_CHI_NAM { get; set; }
            public decimal? THUCTHI_DUOCGIAO { get; set; }
            public string GHICHU { get; set; }
        }

        public class PHF_BM_02TT_DVSN_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string MA_DONVI { get; set; }
            public string THOI_KY { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string NOIDUNG_CHI { get; set; }
            public decimal? THUCTHI_DUOCGIAO { get; set; }
            public decimal? THANHTRA_XACDINH { get; set; }
            public string TITLE_NGUYENNHAN { get; set; }
            public string NGUYENNHAN { get; set; }
            public string GHICHU { get; set; }
        }

        public class PHF_BM_03TT_DVSN_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string MA_DONVI { get; set; }
            public string THOI_KY { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string NGUONTHU { get; set; }
            public decimal? THUCTHI_DUOCGIAO { get; set; }
            public decimal? THANHTRA_XACDINH { get; set; }
            public string TITLE_NGUYENNHAN { get; set; }
            public string NGUYENNHAN { get; set; }
            public string GHICHU { get; set; }
        }

        public class PHF_BM_04TT_DVSN_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string MA_DONVI { get; set; }
            public string THOI_KY { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string NOIDUNG_THU { get; set; }
            public decimal? SOTIEN { get; set; }
            public string TITLE_NGUYENNHAN { get; set; }
            public string NGUYENNHAN { get; set; }
            public string GHICHU { get; set; }
        }

        public class PHF_BM_05TT_DVSN_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string MA_DONVI { get; set; }
            public string THOI_KY { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string HOTEN { get; set; }
            public decimal? CHILUONG_SAI_CHEDO { get; set; }
            public decimal? CHIBH_SAI_CHEDO { get; set; }
            public decimal? CHITN_SAI_CHEDO { get; set; }
            public decimal? CHI_KHAC { get; set; }
            public string GHICHU { get; set; }
        }

        public class PHF_BM_06TT_DVSN_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string MA_DONVI { get; set; }
            public string THOI_KY { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string NOIDUNG_CHI { get; set; }
            public decimal? SOTIEN { get; set; }
            public string TITLE_NGUYENNHAN { get; set; }
            public string NGUYENNHAN { get; set; }
            public string GHICHU { get; set; }
        }

        public class PHF_BM_07TT_DVSN_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string MA_DONVI { get; set; }
            public string THOI_KY { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string NOIDUNG { get; set; }
            public decimal? BAOCAO_DONVI { get; set; }
            public decimal? THANHTRA_XACDINH { get; set; }
            public string NGUYENNHAN { get; set; }
        }

        public class PHF_BM_08TT_DVSN_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string MA_DONVI { get; set; }
            public string THOI_KY { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string NOIDUNG_CHI { get; set; }
            public decimal? SOTIEN { get; set; }
            public string NGUYENNHAN_TRICH_CAOHON { get; set; }
            public string NGUYENNHAN_TRICH_SAINGUON { get; set; }
            public string NGUYENNHAN_TRICH_SAI_TYLE { get; set; }
        }

        public class PHF_BM_09TT_DVSN_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string MA_DONVI { get; set; }
            public string THOI_KY { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string HOTEN { get; set; }
            public decimal? SOLIEU_DV_CHIUTHUE { get; set; }
            public decimal? SOLIEU_DV_PHAINOP { get; set; }
            public decimal? THANHTRA_DV_CHIUTHUE { get; set; }
            public decimal? THANHTRA_DV_PHAINOP { get; set; }
            public string NGUYENNHAN { get; set; }
        }
    }
}
