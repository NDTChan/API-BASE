using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS;
using BTS.SP.TOOLS.BuildQuery;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Types;
using System.Collections.Generic;

namespace BTS.SP.PHF.SERVICE.NV.BaoCaoTT_TCXD
{
    public class NV_BM_FILE_TCXDVm
    {
        public class ViewModel
        {
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string TEN_FILE { get; set; }
            public int NAM { get; set; }
            public string MA_DOT { get; set; }
            public string MA_DOITUONG { get; set; }
            public string THOIGIAN { get; set; }
            public string TEN_BIEUMAU { get; set; }
            public string TIEUDE_BIEUMAU { get; set; }
        }
        public class Search : IDataSearch
        {
            public string MA_FILE { get; set; }
            public int NAM { get; set; }
            public string MA_DOT { get; set; }
            public string MA_DOITUONG { get; set; }
            public string MA_DONVI { get; set; }
            public string DefaultOrder
            {

                get
                {
                    return ClassHelper.GetPropertyName(() => new PHF_BM_FILE_TCXD().MA_FILE);

                }
            }
            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new PHF_BM_FILE_TCXD();

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
                if (!string.IsNullOrEmpty(this.MA_DONVI))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.UnitCode),
                        Value = this.MA_DONVI,
                        Method = FilterMethod.StartsWith
                    });
                }
                if (!string.IsNullOrEmpty(this.MA_DOITUONG))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_DOITUONG),
                        Value = this.MA_DOITUONG,
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

        public class DTO_BM_TT_TCXD
        {
            public DTO_BM_TT_TCXD()
            {
                PHF_BM_01TT_TCXD_DTO = new List<PHF_BM_01TT_TCXD_DTO>();
                PHF_BM_02TT_TCXD_DTO = new List<PHF_BM_02TT_TCXD_DTO>();
                PHF_BM_03TT_TCXD_DTO = new List<PHF_BM_03TT_TCXD_DTO>();
                PHF_BM_04TT_TCXD_DTO = new List<PHF_BM_04TT_TCXD_DTO>();
                PHF_BM_05TT_TCXD_DTO = new List<PHF_BM_05TT_TCXD_DTO>();
                PHF_BM_06TT_TCXD_DTO = new List<PHF_BM_06TT_TCXD_DTO>();
                PHF_BM_07TT_TCXD_DTO = new List<PHF_BM_07TT_TCXD_DTO>();
                PHF_BM_08TT_TCXD_DTO = new List<PHF_BM_08TT_TCXD_DTO>();
                PHF_BM_10TT_TCXD_DTO = new List<PHF_BM_10TT_TCXD_DTO>();

            }
            public int ID { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string TEN_FILE { get; set; }
            public int NAM { get; set; }
            public string MA_DOT { get; set; }
            public string MA_DOITUONG { get; set; }
            public string THOIGIAN { get; set; }
            public string TEN_BIEUMAU { get; set; }
            public string TIEUDE_BIEUMAU { get; set; }
            public List<PHF_BM_01TT_TCXD_DTO> PHF_BM_01TT_TCXD_DTO { get; set; }
            public List<PHF_BM_02TT_TCXD_DTO> PHF_BM_02TT_TCXD_DTO { get; set; }
            public List<PHF_BM_03TT_TCXD_DTO> PHF_BM_03TT_TCXD_DTO { get; set; }
            public List<PHF_BM_04TT_TCXD_DTO> PHF_BM_04TT_TCXD_DTO { get; set; }
            public List<PHF_BM_05TT_TCXD_DTO> PHF_BM_05TT_TCXD_DTO { get; set; }
            public List<PHF_BM_06TT_TCXD_DTO> PHF_BM_06TT_TCXD_DTO { get; set; }
            public List<PHF_BM_07TT_TCXD_DTO> PHF_BM_07TT_TCXD_DTO { get; set; }
            public List<PHF_BM_08TT_TCXD_DTO> PHF_BM_08TT_TCXD_DTO { get; set; }
            public List<PHF_BM_10TT_TCXD_DTO> PHF_BM_10TT_TCXD_DTO { get; set; }

        }

        public class PHF_BM_01TT_TCXD_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string STT_TIEUDE { get; set; }
            public int STT_CHA { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string TEN_THUTUC { get; set; }
            public string COQUAN_DUYET { get; set; }
            public string GIATRI_KHOANMUC { get; set; }
            public string TRANGTHAI_THUTUC { get; set; }
            public string NGUYENNHAN_THIEU { get; set; }
            public int IS_BOLD { get; set; }
            public int IS_ITALIC { get; set; }
        }
        public class PHF_BM_02TT_TCXD_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string STT_TIEUDE { get; set; }
            public int STT_CHA { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string TEN_SAIPHAM { get; set; }
            public string GIATRI { get; set; }
            public string NGUYENNHAN { get; set; }
            public string TRACHNHIEM { get; set; }
            public string HAUQUA { get; set; }
            public string GHICHU { get; set; }
            public int IS_BOLD { get; set; }
            public int IS_ITALIC { get; set; }
        }
        public class PHF_BM_03TT_TCXD_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string STT_TIEUDE { get; set; }
            public int STT_CHA { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string TEN_CHIPHI_DAUTU { get; set; }
            public string VON_NSNN_KHV { get; set; }
            public string VONVAY_KHV { get; set; }
            public string VONKHAC_KHV { get; set; }
            public string TONGCONG_KHV { get; set; }
            public string VON_NSNN_GNV { get; set; }
            public string VONVAY_GNV { get; set; }
            public string VONKHAC_GNV { get; set; }
            public string TONGCONG_GNV { get; set; }
            public string VON_NSNN_TLGN { get; set; }
            public string VONVAY_TLGN { get; set; }
            public string VONKHAC_TLGN { get; set; }
            public string TONGCONG_TLGN { get; set; }
            public string NGUYENNHAN { get; set; }
            public int IS_BOLD { get; set; }
            public int IS_ITALIC { get; set; }
        }
        public class PHF_BM_04TT_TCXD_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string STT_TIEUDE { get; set; }
            public int STT_CHA { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string TEN_THUTUC { get; set; }
            public string GIATRI { get; set; }
            public string NGUYENNHAN { get; set; }
            public string KETQUA { get; set; }
            public int IS_BOLD { get; set; }
            public int IS_ITALIC { get; set; }
        }
        public class PHF_BM_05TT_TCXD_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string STT_TIEUDE { get; set; }
            public int STT_CHA { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string TEN_DUTOAN { get; set; }
            public string GIATRI { get; set; }
            public string SO { get; set; }
            public string NGAY { get; set; }
            public string THAMQUYEN_DUYET { get; set; }
            public string THUTUC_DACO { get; set; }
            public string NGUYENNHAN_THIEU { get; set; }
            public int IS_BOLD { get; set; }
            public int IS_ITALIC { get; set; }
        }
        public class PHF_BM_06TT_TCXD_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string STT_TIEUDE { get; set; }
            public int STT_CHA { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string TEN_CONGVIEC { get; set; }
            public string KL_DUTOAN { get; set; }
            public string KL_TINHLAI { get; set; }
            public string KL_CHENHLECH { get; set; }
            public string DG_DUTOAN { get; set; }
            public string DG_TINHLAI { get; set; }
            public string DG_CHENHLECH { get; set; }
            public string DM_DUTOAN { get; set; }
            public string DM_TINHLAI { get; set; }
            public string DM_CHENHLECH { get; set; }
            public string GIATRI_CHENHLECH { get; set; }
            public string NGUYENNHAN { get; set; }
            public int IS_BOLD { get; set; }
            public int IS_ITALIC { get; set; }
        }
        public class PHF_BM_07TT_TCXD_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string STT_TIEUDE { get; set; }
            public int STT_CHA { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string TEN_GOITHAU { get; set; }
            public string DT_DUYET { get; set; }
            public string DT_TINHLAI { get; set; }
            public string GGT_DUYET { get; set; }
            public string GGT_TINHLAI { get; set; }
            public string GIATRI_HOPDONG { get; set; }
            public string HINHTHUC_HOPDONG { get; set; }
            public string GIATRI_HOPDONG_VUOTGIA { get; set; }
            public string GIATRI_KHOILUONG { get; set; }
            public string GIATRI_GIAINGAN { get; set; }
            public string GHICHU { get; set; }
            public int IS_BOLD { get; set; }
            public int IS_ITALIC { get; set; }
        }
        public class PHF_BM_08TT_TCXD_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string STT_TIEUDE { get; set; }
            public int STT_CHA { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string TEN_HANGMUC { get; set; }
            public string GIATRI_HOPDONG { get; set; }
            public string GIATRI_KHOILUONG { get; set; }
            public string GIATRI_GIAINGAN { get; set; }
            public string SOSANH_GIAINGAN_KHOILUONG { get; set; }
            public string NGUYENNHAN { get; set; }
            public int IS_BOLD { get; set; }
            public int IS_ITALIC { get; set; }
        }
        public class PHF_BM_10TT_TCXD_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string STT_TIEUDE { get; set; }
            public int STT_CHA { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string TEN_HANGMUC { get; set; }
            public string THOIGIAN_QUYETTOAN { get; set; }
            public string GIATRI_DENGHI { get; set; }
            public string GIATRI_XACDINH { get; set; }
            public string CHENHLECH { get; set; }
            public string THOIGIAN_QUYETTOAN_CHAM { get; set; }
            public string NGUYENNHAN { get; set; }
            public string GHICHU { get; set; }
            public int IS_BOLD { get; set; }
            public int IS_ITALIC { get; set; }
        }
    }
}
