using BTS.SP.API.PHF.Utils;
using BTS.SP.PHF.ENTITY;
using BTS.SP.PHF.ENTITY.Auth;
using BTS.SP.PHF.ENTITY.Sys;
using BTS.SP.PHF.SERVICE.AUTH.AuNguoiDung;
using BTS.SP.PHF.SERVICE.AUTH.AuNguoiDungNhomQuyen;
using BTS.SP.PHF.SERVICE.AUTH.AuNguoiDungQuyen;
using BTS.SP.PHF.SERVICE.AUTH.AuNhomQuyen;
using BTS.SP.PHF.SERVICE.AUTH.AuNhomQuyenChucNang;
using BTS.SP.PHF.SERVICE.AUTH.Shared;
using BTS.SP.PHF.SERVICE.DM;
using BTS.SP.PHF.SERVICE.SYS.SysChucNang;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using System.Web.Http;
using BTS.SP.PHF.ENTITY.Nv;
using System.Web;
using BTS.SP.PHF.ENTITY.Dm;
using BTS.SP.PHF.SERVICE.NV;
using BTS.SP.PHF.SERVICE.NV.BaoCaoTT_TCXD;
using BTS.SP.PHF.SERVICE.NV.XayDungKeHoachThanhTraBo;
using Unity;
using Unity.Lifetime;
using BTS.SP.PHF.SERVICE.NV.TienDoThucHienThanhTra;
using BTS.SP.PHF.SERVICE.NV.ThanhTraThuocBo;
using BTS.SP.PHF.SERVICE.NV.SoanThaoNoiDungThanhTraBo;
using BTS.SP.PHF.SERVICE.NV.TheoDoiCanBo;
using BTS.SP.PHF.SERVICE.NV.ThuMucFile;
using BTS.SP.PHF.SERVICE.NV.QDPheDuyetThanhTra;
using BTS.SP.PHF.SERVICE.NV.CapNhatKetQuaThanhTra;
using BTS.SP.PHF.SERVICE.NV.XayDungKeHoachThanhTraCoQuanThuocBo;
using BTS.SP.PHF.SERVICE.SYS.SysDvqhns;
using BTS.SP.PHF.SERVICE.NV.QDGiaoThucHienThanhTra;
using BTS.SP.PHF.SERVICE.NV.QDGiaoThucHienTTThuocBo;
using BTS.SP.PHF.SERVICE.NV.BaoCao_NSDVN;
using BTS.SP.PHF.SERVICE.NV.BaoCaoTT_DVSN;
using BTS.SP.PHF.SERVICE.NV.BaoCaoTT_CQHC;
using BTS.SP.PHF.SERVICE.NV.BaoCaoTT_TCDN;
using BTS.SP.PHF.SERVICE.NV.NamBatTinhHinh.TieuChiDanhGiaRuiRo;

namespace BTS.SP.API.PHF
{
    public class PerRequestLifetimeManager : LifetimeManager
    {
        private readonly object key = new object();
        public override object GetValue()
        {
            if (HttpContext.Current != null &&
                HttpContext.Current.Items.Contains(key))
                return HttpContext.Current.Items[key];
            else
                return null;
        }

        public override void RemoveValue()
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Items.Remove(key);
        }

        public override void SetValue(object newValue)
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Items[key] = newValue;
        }
    }
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IDataContextAsync, PHFContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWorkAsync, UnitOfWork>(new HierarchicalLifetimeManager());

            container.RegisterType<IRepositoryAsync<BaseEntity>, Repository<BaseEntity>>(new HierarchicalLifetimeManager());

            container.RegisterType<IRepositoryAsync<PHF_DM_CANBO>, Repository<PHF_DM_CANBO>>(new HierarchicalLifetimeManager());

            container.RegisterType<IRepositoryAsync<AU_NGUOIDUNG>, Repository<AU_NGUOIDUNG>>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuNguoiDungService, AuNguoiDungService>(new HierarchicalLifetimeManager());

            container.RegisterType<IRepositoryAsync<AU_NHOMQUYEN>, Repository<AU_NHOMQUYEN>>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuNhomQuyenService, AuNhomQuyenService>(new HierarchicalLifetimeManager());

            container.RegisterType<IRepositoryAsync<SYS_CHUCNANG>, Repository<SYS_CHUCNANG>>(new HierarchicalLifetimeManager());
            container.RegisterType<ISysChucNangService, SysChucNangService>(new HierarchicalLifetimeManager());

            container.RegisterType<ISharedService, SharedService>(new HierarchicalLifetimeManager());


            container.RegisterType<IRepositoryAsync<PHF_SYS_TUDIEN>, Repository<PHF_SYS_TUDIEN>>(new HierarchicalLifetimeManager());
            container.RegisterType<IDM_SYS_TUDIENService, DM_SYS_TUDIENService>(new HierarchicalLifetimeManager());

            container.RegisterType<IRepositoryAsync<SYS_DVQHNS>, Repository<SYS_DVQHNS>>(new HierarchicalLifetimeManager());
            container.RegisterType<ISysDvqhnsService, SysDvqhnsService>(new HierarchicalLifetimeManager());

            container.RegisterType<IRepositoryAsync<PHF_DM_DOTTHANHTRA>, Repository<PHF_DM_DOTTHANHTRA>>(new HierarchicalLifetimeManager());
            container.RegisterType<IDM_DOTTHANHTRAService, DM_DOTTHANHTRAService>(new HierarchicalLifetimeManager());

            container.RegisterType<IRepositoryAsync<PHF_DM_DOITUONG>, Repository<PHF_DM_DOITUONG>>(new HierarchicalLifetimeManager());
            container.RegisterType<IDM_DOITUONGService, DM_DOITUONGService>(new HierarchicalLifetimeManager());

            container.RegisterType<IRepositoryAsync<AU_NHOMQUYEN_CHUCNANG>, Repository<AU_NHOMQUYEN_CHUCNANG>>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuNhomQuyenChucNangService, AuNhomQuyenChucNangService>(new HierarchicalLifetimeManager());

            container.RegisterType<IRepositoryAsync<AU_NGUOIDUNG_NHOMQUYEN>, Repository<AU_NGUOIDUNG_NHOMQUYEN>>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuNguoiDungNhomQuyenService, AuNguoiDungNhomQuyenService>(new HierarchicalLifetimeManager());

            container.RegisterType<IRepositoryAsync<AU_NGUOIDUNG_QUYEN>, Repository<AU_NGUOIDUNG_QUYEN>>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuNguoiDungQuyenService, AuNguoiDungQuyenService>(new HierarchicalLifetimeManager());

            #region DANHMUC
            container.RegisterType<IRepositoryAsync<PHF_DM_CANBO>, Repository<PHF_DM_CANBO>>(new HierarchicalLifetimeManager());
            container.RegisterType<IDM_CANBOService, DM_CANBOService>(new HierarchicalLifetimeManager());

            container.RegisterType<IRepositoryAsync<PHF_DM_DONVI_PHONGBAN>, Repository<PHF_DM_DONVI_PHONGBAN>>(new HierarchicalLifetimeManager());
            container.RegisterType<IDM_DONVI_PHONGBANService, DM_DONVI_PHONGBANService>(new HierarchicalLifetimeManager());

            #endregion

            #region NGHIEPVU
            container.RegisterType<IRepositoryAsync<PHF_XD_KH_THANHTRA_BO>, Repository<PHF_XD_KH_THANHTRA_BO>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_XD_KH_THANHTRA_BOService, NV_XD_KH_THANHTRA_BOService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_XD_KH_THANHTRA_BO_CHITIET>, Repository<PHF_XD_KH_THANHTRA_BO_CHITIET>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_XD_KH_THANHTRA_BO_CHITIETService, NV_XD_KH_THANHTRA_BO_CHITIETService>(new HierarchicalLifetimeManager());
            //TienDoThanhTra
            container.RegisterType<IRepositoryAsync<PHF_TIENDO_THUCHIEN_KH>, Repository<PHF_TIENDO_THUCHIEN_KH>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_TIENDO_THUCHIEN_KHService, NV_TIENDO_THUCHIEN_KHService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_TIENDO_THUCHIEN_KH_CT>, Repository<PHF_TIENDO_THUCHIEN_KH_CT>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_TIENDO_THUCHIEN_KH_CTService, NV_TIENDO_THUCHIEN_KH_CTService>(new HierarchicalLifetimeManager());
            //End TienDoThanhTra
            //ThanhTraThuocBo
            container.RegisterType<IRepositoryAsync<PHF_XD_KH_TT_THUOC_BO>, Repository<PHF_XD_KH_TT_THUOC_BO>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_XD_KH_TT_THUOC_BOService, NV_XD_KH_TT_THUOC_BOService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_XD_KH_TT_THUOC_BO_CT>, Repository<PHF_XD_KH_TT_THUOC_BO_CT>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_XD_KH_TT_THUOC_BO_CTService, NV_XD_KH_TT_THUOC_BO_CTService>(new HierarchicalLifetimeManager());
            //End ThanhTraThuocBo
            //Theo Doi Can Bo 
            container.RegisterType<IRepositoryAsync<PHF_THEODOI_CANBO>, Repository<PHF_THEODOI_CANBO>>(new HierarchicalLifetimeManager());
            container.RegisterType<IPHF_THEODOI_CANBOService, PHF_THEODOI_CANBOService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_THEODOI_CANBO_CT>, Repository<PHF_THEODOI_CANBO_CT>>(new HierarchicalLifetimeManager());
            container.RegisterType<IPHF_THEODOI_CANBO_CTService, PHF_THEODOI_CANBO_CTService>(new HierarchicalLifetimeManager());
            //End Theo Doi Can Bo 
            //Ke Hoach Thanh Tra Co Quan Thuoc Bo
            container.RegisterType<IRepositoryAsync<PHF_KH_THANHTRA_COQUAN>, Repository<PHF_KH_THANHTRA_COQUAN>>(new HierarchicalLifetimeManager());
            container.RegisterType<IPHF_KH_THANHTRA_COQUANService, PHF_KH_THANHTRA_COQUANService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_KH_THANHTRA_COQUAN_CT>, Repository<PHF_KH_THANHTRA_COQUAN_CT>>(new HierarchicalLifetimeManager());
            container.RegisterType<IPHF_KH_THANHTRA_COQUAN_CTService, PHF_KH_THANHTRA_COQUAN_CTService>(new HierarchicalLifetimeManager());
            //End Ke Hoach Thanh Tra Co Quan Thuoc Bo
            //Cập nhật thanh tra
            container.RegisterType<IRepositoryAsync<PHF_BM_FILE_NSDP>, Repository<PHF_BM_FILE_NSDP>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_FILE_NSDPService, NV_BM_FILE_NSDPService>(new HierarchicalLifetimeManager());

            //Biểu 01
            container.RegisterType<IRepositoryAsync<PHF_BM_01TT_NSDP>, Repository<PHF_BM_01TT_NSDP>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_01TT_NSDPService, NV_BM_01TT_NSDPService>(new HierarchicalLifetimeManager());

            //Biểu 02
            container.RegisterType<IRepositoryAsync<PHF_BM_02TT_NSDP>, Repository<PHF_BM_02TT_NSDP>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_02TT_NSDPService, NV_BM_02TT_NSDPService>(new HierarchicalLifetimeManager());

            //Biểu 03
            container.RegisterType<IRepositoryAsync<PHF_BM_03TT_NSDP>, Repository<PHF_BM_03TT_NSDP>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_03TT_NSDPService, NV_BM_03TT_NSDPService>(new HierarchicalLifetimeManager());

            //Biểu 05
            container.RegisterType<IRepositoryAsync<PHF_BM_05TT_NSDP>, Repository<PHF_BM_05TT_NSDP>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_05TT_NSDPService, NV_BM_05TT_NSDPService>(new HierarchicalLifetimeManager());

            //Biểu 10
            container.RegisterType<IRepositoryAsync<PHF_BM_10TT_NSDP>, Repository<PHF_BM_10TT_NSDP>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_10TT_NSDPService, NV_BM_10TT_NSDPService>(new HierarchicalLifetimeManager());

            //Biểu 11
            container.RegisterType<IRepositoryAsync<PHF_BM_11TT_NSDP>, Repository<PHF_BM_11TT_NSDP>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_11TT_NSDPService, NV_BM_11TT_NSDPService>(new HierarchicalLifetimeManager());

            //Biểu 12
            container.RegisterType<IRepositoryAsync<PHF_BM_12TT_NSDP>, Repository<PHF_BM_12TT_NSDP>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_12TT_NSDPService, NV_BM_12TT_NSDPService>(new HierarchicalLifetimeManager());

            //Biểu 14
            container.RegisterType<IRepositoryAsync<PHF_BM_14TT_NSDP>, Repository<PHF_BM_14TT_NSDP>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_14TT_NSDPService, NV_BM_14TT_NSDPService>(new HierarchicalLifetimeManager());

            //Biểu 15
            container.RegisterType<IRepositoryAsync<PHF_BM_15TT_NSDP>, Repository<PHF_BM_15TT_NSDP>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_15TT_NSDPService, NV_BM_15TT_NSDPService>(new HierarchicalLifetimeManager());

            //Biểu 16
            container.RegisterType<IRepositoryAsync<PHF_BM_16TT_NSDP>, Repository<PHF_BM_16TT_NSDP>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_16TT_NSDPService, NV_BM_16TT_NSDPService>(new HierarchicalLifetimeManager());

            //End Cập nhật thanh tra
            container.RegisterType<IRepositoryAsync<PHF_TTB_NHATKY>, Repository<PHF_TTB_NHATKY>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_TTB_NHATKYService, NV_TTB_NHATKYService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_QD_PHEDUYET_THANHTRA>, Repository<PHF_QD_PHEDUYET_THANHTRA>>(new HierarchicalLifetimeManager());
            container.RegisterType<IQDPheDuyetThanhTraService, QDPheDuyetThanhTraService>(new HierarchicalLifetimeManager());

            #region Nắm bắt tình hình đối tượng thanh tra - tiêu chính đánh giá rủi ro
            container.RegisterType<IRepositoryAsync<PHF_TIEUCHI_DGRR>, Repository<PHF_TIEUCHI_DGRR>>(new HierarchicalLifetimeManager());
            container.RegisterType<IPHF_TIEUCHI_DGRRService, PHF_TIEUCHI_DGRRService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_TIEUCHI_DGRR_DETAIL>, Repository<PHF_TIEUCHI_DGRR_DETAIL>>(new HierarchicalLifetimeManager());
            container.RegisterType<IPHF_TIEUCHI_DGRR_DETAILService, PHF_TIEUCHI_DGRR_DETAILService>(new HierarchicalLifetimeManager());
            #endregion

            #endregion
            container.RegisterType<IRepositoryAsync<PHF_SOANTHAO_THANHTRA>, Repository<PHF_SOANTHAO_THANHTRA>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_SOANTHAO_THANHTRAService, NV_SOANTHAO_THANHTRAService>(new HierarchicalLifetimeManager());

            container.RegisterType<IRepositoryAsync<PHF_THUMUC_FILE>, Repository<PHF_THUMUC_FILE>>(new HierarchicalLifetimeManager());
            container.RegisterType<ITHUMUCFILEService, THUMUCFILEService>(new HierarchicalLifetimeManager());

            container.RegisterType<IRepositoryAsync<PHF_QD_GIAOTHUCHIEN_THANHTRA>, Repository<PHF_QD_GIAOTHUCHIEN_THANHTRA>>(new HierarchicalLifetimeManager());
            container.RegisterType<IQDGiaoThucHienThanhTraService, QDGiaoThucHienThanhTraService>(new HierarchicalLifetimeManager());

            container.RegisterType<IRepositoryAsync<PHF_QD_GIAOTHUCHIEN_TT_THUOCBO>, Repository<PHF_QD_GIAOTHUCHIEN_TT_THUOCBO>>(new HierarchicalLifetimeManager());
            container.RegisterType<IQDGiaoThucHienTTThuocBoService, QDGiaoThucHienTTThuocBoService>(new HierarchicalLifetimeManager());

            #region Báo cáo tổng hợp TCXD
            container.RegisterType<IRepositoryAsync<PHF_BM_FILE_TCXD>, Repository<PHF_BM_FILE_TCXD>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_FILE_TCXDService, NV_BM_FILE_TCXDService>(new HierarchicalLifetimeManager());

            container.RegisterType<IRepositoryAsync<PHF_BM_01TT_TCXD>, Repository<PHF_BM_01TT_TCXD>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_01TT_TCXDService, NV_BM_01TT_TCXDService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_02TT_TCXD>, Repository<PHF_BM_02TT_TCXD>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_02TT_TCXDService, NV_BM_02TT_TCXDService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_03TT_TCXD>, Repository<PHF_BM_03TT_TCXD>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_03TT_TCXDService, NV_BM_03TT_TCXDService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_04TT_TCXD>, Repository<PHF_BM_04TT_TCXD>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_04TT_TCXDService, NV_BM_04TT_TCXDService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_05TT_TCXD>, Repository<PHF_BM_05TT_TCXD>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_05TT_TCXDService, NV_BM_05TT_TCXDService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_06TT_TCXD>, Repository<PHF_BM_06TT_TCXD>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_06TT_TCXDService, NV_BM_06TT_TCXDService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_07TT_TCXD>, Repository<PHF_BM_07TT_TCXD>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_07TT_TCXDService, NV_BM_07TT_TCXDService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_08TT_TCXD>, Repository<PHF_BM_08TT_TCXD>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_08TT_TCXDService, NV_BM_08TT_TCXDService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_10TT_TCXD>, Repository<PHF_BM_10TT_TCXD>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_10TT_TCXDService, NV_BM_10TT_TCXDService>(new HierarchicalLifetimeManager());
            #endregion

            #region Báo cáo tổng hợp DVSN
            container.RegisterType<IRepositoryAsync<PHF_BM_FILE_DVSN>, Repository<PHF_BM_FILE_DVSN>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_FILE_DVSNService, NV_BM_FILE_DVSNService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_01TT_DVSN>, Repository<PHF_BM_01TT_DVSN>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_01TT_DVSNService, NV_BM_01TT_DVSNService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_02TT_DVSN>, Repository<PHF_BM_02TT_DVSN>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_02TT_DVSNService, NV_BM_02TT_DVSNService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_03TT_DVSN>, Repository<PHF_BM_03TT_DVSN>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_03TT_DVSNService, NV_BM_03TT_DVSNService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_04TT_DVSN>, Repository<PHF_BM_04TT_DVSN>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_04TT_DVSNService, NV_BM_04TT_DVSNService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_05TT_DVSN>, Repository<PHF_BM_05TT_DVSN>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_05TT_DVSNService, NV_BM_05TT_DVSNService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_06TT_DVSN>, Repository<PHF_BM_06TT_DVSN>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_06TT_DVSNService, NV_BM_06TT_DVSNService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_07TT_DVSN>, Repository<PHF_BM_07TT_DVSN>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_07TT_DVSNService, NV_BM_07TT_DVSNService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_08TT_DVSN>, Repository<PHF_BM_08TT_DVSN>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_08TT_DVSNService, NV_BM_08TT_DVSNService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_09TT_DVSN>, Repository<PHF_BM_09TT_DVSN>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_09TT_DVSNService, NV_BM_09TT_DVSNService>(new HierarchicalLifetimeManager());
            #endregion

            #region Báo cáo tổng hợp NSDVN
            container.RegisterType<IRepositoryAsync<PHF_BM_FILE_NSDVN>, Repository<PHF_BM_FILE_NSDVN>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_FILE_NSDVNService, NV_BM_FILE_NSDVNService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_60TT_NSDVN>, Repository<PHF_BM_60TT_NSDVN>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_60TT_NSDVNService, NV_BM_60TT_NSDVNService>(new HierarchicalLifetimeManager());
            #endregion

            #region Báo cáo tổng hợp CQHC
            container.RegisterType<IRepositoryAsync<PHF_BM_FILE_CQHC>, Repository<PHF_BM_FILE_CQHC>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_FILE_CQHCService, NV_BM_FILE_CQHCService>(new HierarchicalLifetimeManager());

            container.RegisterType<IRepositoryAsync<PHF_BM_01TT_CQHC>, Repository<PHF_BM_01TT_CQHC>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_01TT_CQHCService, NV_BM_01TT_CQHCService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_02TT_CQHC>, Repository<PHF_BM_02TT_CQHC>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_02TT_CQHCService, NV_BM_02TT_CQHCService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_03TT_CQHC>, Repository<PHF_BM_03TT_CQHC>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_03TT_CQHCService, NV_BM_03TT_CQHCService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_04TT_CQHC>, Repository<PHF_BM_04TT_CQHC>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_04TT_CQHCService, NV_BM_04TT_CQHCService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_05TT_CQHC>, Repository<PHF_BM_05TT_CQHC>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_05TT_CQHCService, NV_BM_05TT_CQHCService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_06TT_CQHC>, Repository<PHF_BM_06TT_CQHC>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_06TT_CQHCService, NV_BM_06TT_CQHCService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_07TT_CQHC>, Repository<PHF_BM_07TT_CQHC>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_07TT_CQHCService, NV_BM_07TT_CQHCService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryAsync<PHF_BM_08TT_CQHC>, Repository<PHF_BM_08TT_CQHC>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_08TT_CQHCService, NV_BM_08TT_CQHCService>(new HierarchicalLifetimeManager());
            #endregion

            #region Báo cáo tổng hợp TCDN
            container.RegisterType<IRepositoryAsync<PHF_BM_FILE_TCDN>, Repository<PHF_BM_FILE_TCDN>>(new HierarchicalLifetimeManager());
            container.RegisterType<INV_BM_FILE_TCDNService, NV_BM_FILE_TCDNService>(new HierarchicalLifetimeManager());

            #endregion


            config.DependencyResolver = new UnityResolver(container);
        }
    }
}