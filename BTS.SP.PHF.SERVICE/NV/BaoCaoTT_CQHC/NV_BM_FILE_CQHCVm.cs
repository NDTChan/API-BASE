using System.Collections.Generic;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS;
using BTS.SP.TOOLS.BuildQuery;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Types;

namespace BTS.SP.PHF.SERVICE.NV.BaoCaoTT_CQHC
{
    public class NV_BM_FILE_CQHCVm
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
            public string MA_DONVI { get; set; }
            public string MA_DOITUONG { get; set; }

            public string DefaultOrder
            {
                get
                {
                    return ClassHelper.GetPropertyName(() => new PHF_BM_FILE_CQHC().MA_FILE);
                }
            }

            public void LoadGeneralParam(string summary)
            {
                MA_FILE = summary;
            }

            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new PHF_BM_FILE_CQHC();
                if (!string.IsNullOrEmpty(this.MA_FILE))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_FILE),
                        Value = this.MA_FILE,
                        Method = FilterMethod.Like
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
                if (!string.IsNullOrEmpty(this.MA_DONVI))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.UnitCode),
                        Value = this.MA_DONVI,
                        Method = FilterMethod.Like
                    });
                }
                if (!string.IsNullOrEmpty(this.MA_DOITUONG))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MA_DOITUONG),
                        Value = this.MA_DOITUONG,
                        Method = FilterMethod.Like
                    });
                }

                return result;
            }

            public List<IQueryFilter> GetQuickFilters()
            {
                return null;
            }
        }


        public class UploadFileReport_Parameter
        {
            public string UNITCODE { get; set; }
            public string URL { get; set; }
        }

        public class DTO_BM_01_FILE_CQHC
        {
            public DTO_BM_01_FILE_CQHC()
            {
                Details = new List<PHF_BM_01TT_CQHC_DTO>();
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
            public List<PHF_BM_01TT_CQHC_DTO> Details { get; set; }
        }

        public class DTO_BM_02_FILE_CQHC
        {
            public DTO_BM_02_FILE_CQHC()
            {
                Details = new List<PHF_BM_02TT_CQHC_DTO>();
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
            public List<PHF_BM_02TT_CQHC_DTO> Details { get; set; }
        }

        public class DTO_BM_03_FILE_CQHC
        {
            public DTO_BM_03_FILE_CQHC()
            {
                Details = new List<PHF_BM_03TT_CQHC_DTO>();
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
            public List<PHF_BM_03TT_CQHC_DTO> Details { get; set; }
        }
       
        public class DTO_BM_04_FILE_CQHC
        {
            public DTO_BM_04_FILE_CQHC()
            {
                Details = new List<PHF_BM_04TT_CQHC_DTO>();
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
            public List<PHF_BM_04TT_CQHC_DTO> Details { get; set; }
        }
        public class DTO_BM_05_FILE_CQHC
        {
            public DTO_BM_05_FILE_CQHC()
            {
                Details = new List<PHF_BM_05TT_CQHC_DTO>();
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
            public List<PHF_BM_05TT_CQHC_DTO> Details { get; set; }
        }
        public class DTO_BM_06_FILE_CQHC
        {
            public DTO_BM_06_FILE_CQHC()
            {
                Details = new List<PHF_BM_06TT_CQHC_DTO>();
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
            public List<PHF_BM_06TT_CQHC_DTO> Details { get; set; }
        }
        public class DTO_BM_07_FILE_CQHC
        {
            public DTO_BM_07_FILE_CQHC()
            {
                Details = new List<PHF_BM_07TT_CQHC_DTO>();
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
            public List<PHF_BM_07TT_CQHC_DTO> Details { get; set; }
        }
        public class DTO_BM_08_FILE_CQHC
        {
            public DTO_BM_08_FILE_CQHC()
            {
                Details = new List<PHF_BM_08TT_CQHC_DTO>();
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
            public List<PHF_BM_08TT_CQHC_DTO> Details { get; set; }
        }

        public class PHF_BM_01TT_CQHC_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string STT_TIEUDE { get; set; }
            public int STT_CHA { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string NOIDUNG { get; set; }
            public string NAMTRUOC_LIENKE { get; set; }
            public string NAMLAP_DUTOAN { get; set; }
            public string GHICHU { get; set; }
            public string HAUQUA { get; set; }
            public string NGUYENNHAN { get; set; }
            public int IS_BOLD { get; set; }
            public int IS_ITALIC { get; set; }
        }
        public class PHF_BM_02TT_CQHC_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string STT_TIEUDE { get; set; }
            public int STT_CHA { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string NOIDUNG { get; set; }
            public string DUTOAN_DUOCGIAO_LK { get; set; }
            public string QUYETTOANCHI_LK { get; set; }
            public string DUTOAN_DONVILAP_NAM { get; set; }
            public string DUTOAN_DUOCGIAO_NAM { get; set; }
            public string QUYETTOANCHI_NAM { get; set; }
            public string DUTOAN_DVLAP_NAMLK { get; set; }
            public string DUTOAN_DUOCGIAO_DVLAP { get; set; }
            public string DUTOAN_DUOCGIAO_NAMKT { get; set; }
            public string NGUYENNHAN { get; set; }
            public int IS_BOLD { get; set; }
            public int IS_ITALIC { get; set; }
        }

        public class PHF_BM_03TT_CQHC_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string STT_TIEUDE { get; set; }
            public int STT_CHA { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string NOIDUNG { get; set; }
            public string DUTOAN_DUOCGIAO { get; set; }
            public string THANHTRA_XACDINH { get; set; }
            public string DUTOANGIAO_KHONGDUNG { get; set; }
            public string TITLE_NGUYENNHAN { get; set; }
            public string NGUYENNHAN { get; set; }
            public string GHICHU { get; set; }
            public int IS_BOLD { get; set; }
            public int IS_ITALIC { get; set; }
        }

        public class PHF_BM_04TT_CQHC_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string STT_TIEUDE { get; set; }
            public int STT_CHA { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string NOIDUNG { get; set; }
            public string SOTIEN { get; set; }
            public string THUKHONG_QDNC_NN { get; set; }
            public string THUCAOTHAP_QDNC_NN { get; set; }
            public string THUKHONG_SSQT_NN { get; set; }
            public string CHUAGHI_THUCHI_NN { get; set; }
            public int IS_BOLD { get; set; }
            public int IS_ITALIC { get; set; }
        }

        public class PHF_BM_05TT_CQHC_DTO
        {
            public int ID { get; set; }           
            public int STT { get; set; }           
            public string STT_TIEUDE { get; set; }         
            public int STT_CHA { get; set; }            
            public string MA_FILE { get; set; }          
            public string MA_FILE_PK { get; set; }          
            public string HO_VATEN { get; set; }     
            public string CHI_LUONGSCD { get; set; }            
            public string CHI_BHYTBHXH_SCD { get; set; }
            public string CHI_THUNHAP { get; set; }
            public string CHI_KHENTHUONG { get; set; }
            public string CHI_KHAC { get; set; }
            public string GHI_CHU { get; set; }
            public int IS_BOLD { get; set; }
            public int IS_ITALIC { get; set; }
        }
        public class PHF_BM_06TT_CQHC_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string STT_TIEUDE { get; set; }
            public int STT_CHA { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string NOIDUNG { get; set; }
            public string SOTIEN { get; set; }
            public string TITLE_NGUYENNHAN { get; set; }
            public string NGUYENNHAN { get; set; }
            public int IS_BOLD { get; set; }
            public int IS_ITALIC { get; set; }
        }
        public class PHF_BM_07TT_CQHC_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string STT_TIEUDE { get; set; }
            public int STT_CHA { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string NOIDUNG_SAIPHAM { get; set; }
            public string SOTIEN { get; set; }
            public string TRICHSAI_TYLE { get; set; }
            public string TRICHKHONG_DUNGNGUON { get; set; }
            public string GHICHU { get; set; }
            //public int IS_BOLD { get; set; }
            //public int IS_ITALIC { get; set; }

        }
        public class PHF_BM_08TT_CQHC_DTO
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string STT_TIEUDE { get; set; }
            public int STT_CHA { get; set; }
            public string MA_FILE { get; set; }
            public string MA_FILE_PK { get; set; }
            public string HO_VATEN { get; set; }          
            public string SLCDV_THUNHAP_CHIUTHUE { get; set; }
            public string TTXD_THUNHAP_CHIUTHUE { get; set; }      
            public string SLCDV_SOTHUE_PHAINOP { get; set; }          
            public string TTXD_SOTHUE_PHAINOP { get; set; }          
            public string CL_THUNHAP_CHIUTHUE { get; set; }
            public string CL_SOTHUE_PHAINOP { get; set; }          
            public string NGUYENNHAN { get; set; }           
            public int IS_BOLD { get; set; }
            public int IS_ITALIC { get; set; }

        }
        

    }
}
