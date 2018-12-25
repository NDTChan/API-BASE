namespace BTS.SP.API.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _07122018_INITIALIZE_DATABASE_ANHPT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "BTSTC.AU_KYKETOAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        KY = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NAME = c.String(maxLength: 500),
                        TUNGAY = c.DateTime(nullable: false),
                        DENNGAY = c.DateTime(nullable: false),
                        NAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANGTHAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.AU_NGUOIDUNG_NHOMQUYEN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHANHE = c.String(nullable: false, maxLength: 50),
                        USERNAME = c.String(nullable: false, maxLength: 50),
                        MANHOMQUYEN = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.AU_NGUOIDUNG_QUYEN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHANHE = c.String(nullable: false, maxLength: 50),
                        USERNAME = c.String(nullable: false, maxLength: 50),
                        MACHUCNANG = c.String(nullable: false, maxLength: 50),
                        XEM = c.Decimal(nullable: false, precision: 1, scale: 0),
                        THEM = c.Decimal(nullable: false, precision: 1, scale: 0),
                        SUA = c.Decimal(nullable: false, precision: 1, scale: 0),
                        XOA = c.Decimal(nullable: false, precision: 1, scale: 0),
                        DUYET = c.Decimal(nullable: false, precision: 1, scale: 0),
                        TRANGTHAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.AU_NGUOIDUNG",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        USERNAME = c.String(nullable: false, maxLength: 30),
                        PASSWORD = c.String(nullable: false, maxLength: 500),
                        FULLNAME = c.String(nullable: false, maxLength: 500),
                        EMAIL = c.String(maxLength: 500),
                        PHONE = c.String(maxLength: 20),
                        MA_DBHC = c.String(nullable: false, maxLength: 50),
                        CHUCVU = c.String(maxLength: 50),
                        MA_PHONGBAN = c.String(maxLength: 50),
                        GHICHU = c.String(maxLength: 500),
                        TRANGTHAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DBHC_CHA = c.String(maxLength: 50),
                        MA_QHNS = c.String(maxLength: 2000),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DONVI = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.AU_NHOMQUYEN_CHUCNANG",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHANHE = c.String(nullable: false, maxLength: 50),
                        MANHOMQUYEN = c.String(nullable: false, maxLength: 50),
                        MACHUCNANG = c.String(nullable: false, maxLength: 50),
                        XEM = c.Decimal(nullable: false, precision: 1, scale: 0),
                        THEM = c.Decimal(nullable: false, precision: 1, scale: 0),
                        SUA = c.Decimal(nullable: false, precision: 1, scale: 0),
                        XOA = c.Decimal(nullable: false, precision: 1, scale: 0),
                        DUYET = c.Decimal(nullable: false, precision: 1, scale: 0),
                        TRANGTHAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.AU_NHOMQUYEN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHANHE = c.String(nullable: false, maxLength: 50),
                        MANHOMQUYEN = c.String(nullable: false, maxLength: 50),
                        TENNHOMQUYEN = c.String(maxLength: 100),
                        MOTA = c.String(maxLength: 200),
                        TRANGTHAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.AU_PROCESS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PROCESSCODE = c.String(maxLength: 50),
                        DESCRIPTION = c.String(maxLength: 300),
                        STATE = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_BAOCAO_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MABAOCAO = c.String(maxLength: 100),
                        TENBAOCAO = c.String(maxLength: 200),
                        LOAIBAOCAO = c.String(maxLength: 200),
                        USER_NAME = c.String(maxLength: 20),
                        DUONGDAN = c.String(maxLength: 2000, unicode: false),
                        MATKKHOBAC = c.String(maxLength: 200),
                        DONVIQUANHENS = c.String(maxLength: 200),
                        TUNGAY_HL = c.DateTime(nullable: false),
                        DENNGAY_HL = c.DateTime(nullable: false),
                        DENNGAY_KS = c.DateTime(nullable: false),
                        TUNGAY_KS = c.DateTime(nullable: false),
                        DONVITIEN = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CONGTHUC = c.String(maxLength: 500),
                        FILE_VIEW = c.String(maxLength: 2000, unicode: false),
                        DO_UUTIEN = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LOAI_BC = c.String(maxLength: 10),
                        NGAY_TAO = c.DateTime(),
                        NGUOI_TAO = c.String(maxLength: 200),
                        MA_CHA = c.String(maxLength: 50),
                        LOAI_INDEX = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PART_REPORT = c.String(maxLength: 1000),
                        STATE = c.String(maxLength: 200),
                        GROUP_NAME = c.String(maxLength: 100),
                        MAU_SO = c.String(maxLength: 100),
                        BC_THEO = c.Decimal(precision: 10, scale: 0),
                        MA_DIABAN = c.String(maxLength: 50),
                        STT = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_BAOCAO",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_BAOCAO = c.String(maxLength: 100),
                        NGAY_HL = c.DateTime(nullable: false),
                        TEN_BAOCAO = c.String(maxLength: 200),
                        TRANGTHAI = c.String(maxLength: 1),
                        LOAI_BC = c.Decimal(precision: 10, scale: 0),
                        LOAI_CT = c.Decimal(precision: 10, scale: 0),
                        USER_NAME = c.String(maxLength: 20),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_CHITIEU_BAOCAO_COL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.String(maxLength: 100),
                        TRANG_THAI = c.String(maxLength: 1),
                        MA_BAOCAO = c.String(maxLength: 50),
                        MA_COT = c.String(maxLength: 100),
                        MA_DBHC = c.String(maxLength: 10),
                        TEN_COT = c.String(maxLength: 2000),
                        CONGTHUC = c.String(),
                        CONGTHUC_WHERE = c.String(),
                        CONGTHUC_DH = c.String(),
                        CONGTHUC_DH_WHERE = c.String(),
                        GIA_TRI = c.Decimal(precision: 18, scale: 2),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_HET_HL = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_CHITIEU_BAOCAO",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_BAOCAO = c.String(maxLength: 50),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_HET_HL = c.DateTime(),
                        MA_CHITIEU = c.String(maxLength: 50),
                        MA_CONGTRINH = c.String(maxLength: 50),
                        MA_DONG = c.String(maxLength: 200),
                        TRANG_THAI = c.String(maxLength: 10),
                        SAPXEP = c.String(maxLength: 100),
                        TEN_CHITIEU = c.String(maxLength: 500),
                        STT = c.String(maxLength: 100),
                        CONGTHUC = c.String(),
                        CONGTHUC_WHERE = c.String(),
                        CONGTHUC_DH_WHERE = c.String(),
                        DAU = c.Decimal(precision: 10, scale: 0),
                        INDAM = c.Decimal(precision: 10, scale: 0),
                        INNGHIENG = c.Decimal(precision: 10, scale: 0),
                        HIENTHI = c.String(maxLength: 1),
                        USER_NAME = c.String(maxLength: 20),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        ISHIEN = c.Decimal(precision: 10, scale: 0),
                        CONGCHA = c.Decimal(precision: 10, scale: 0),
                        MA_CHUONG = c.String(maxLength: 3),
                        LOAICHITIEU = c.Decimal(precision: 10, scale: 0),
                        SOSAPXEP = c.Decimal(precision: 10, scale: 0),
                        CAP = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_CHITIEU_COT_SOLIEU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_COT = c.String(maxLength: 50),
                        MA_CHITIEU = c.String(maxLength: 50),
                        TRANG_THAI = c.String(maxLength: 10),
                        LOAI_CHITIEU = c.Decimal(precision: 10, scale: 0),
                        NAM = c.Decimal(precision: 10, scale: 0),
                        GIA_TRI = c.Decimal(precision: 18, scale: 2),
                        MA_DBHC = c.String(maxLength: 20),
                        MA_DBHC_XA = c.String(maxLength: 20),
                        MA_DBHC_USER = c.String(maxLength: 20),
                        CAP = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_CHITIEU_COT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_COT = c.String(maxLength: 50),
                        TEN_COT = c.String(maxLength: 500),
                        TRANG_THAI = c.String(maxLength: 10),
                        CONGTHUC = c.String(maxLength: 2000),
                        CONGTHUC_WHERE = c.String(),
                        SAPXEP = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_CHITIEU_DUTOAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(maxLength: 50),
                        MACHA = c.String(maxLength: 20),
                        MACHITIEU = c.String(maxLength: 20),
                        TENCHITIEU = c.String(maxLength: 250),
                        CAP = c.Decimal(precision: 10, scale: 0),
                        TYLE_XADUOCHUONG = c.Decimal(precision: 18, scale: 2),
                        MATAIKHOAN = c.String(maxLength: 1000),
                        LOAICHITIEU = c.Decimal(precision: 10, scale: 0),
                        TRANG_THAI = c.String(maxLength: 1),
                        SAPXEP = c.String(maxLength: 100),
                        PHAN_HE = c.String(maxLength: 3),
                        CT_DH = c.String(),
                        CT_DH_W = c.String(),
                        CT_QT = c.String(),
                        CT_QT_W = c.String(),
                        CT_DT = c.String(),
                        CT_DT_W = c.String(),
                        TUNGAY_HL = c.DateTime(),
                        DENNGAY_HL = c.DateTime(),
                        CODELOCATION = c.String(maxLength: 5),
                        NAM_DUTOAN = c.String(maxLength: 4),
                        LOAI_DUTOAN = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_CHITIEU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHITIEU = c.String(maxLength: 100),
                        NGAY_HL = c.DateTime(nullable: false),
                        TEN_CHITIEU = c.String(maxLength: 300),
                        TRANG_THAI = c.String(maxLength: 1),
                        CONGTHUC = c.String(maxLength: 2000),
                        LOAI_CT = c.Decimal(precision: 10, scale: 0),
                        USER_NAME = c.String(maxLength: 20),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_CHUCVU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUCVU = c.String(maxLength: 4),
                        TEN_CHUCVU = c.String(maxLength: 500),
                        TRANG_THAI = c.String(maxLength: 1),
                        GHI_CHU = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_CTMUCTIEU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(maxLength: 20),
                        TEN = c.String(maxLength: 250),
                        TEN_RUTGON = c.String(maxLength: 250),
                        BAC = c.Decimal(precision: 10, scale: 0),
                        CHITIET = c.Decimal(precision: 10, scale: 0),
                        MA_CTMUCTIEU_CHA = c.String(maxLength: 20),
                        CHON = c.Decimal(precision: 10, scale: 0),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        USER_NAME = c.String(maxLength: 20),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_DANHMUC",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MADANHMUC = c.String(nullable: false, maxLength: 50),
                        MADANHMUC_CHA = c.String(maxLength: 50),
                        TENDANHMUC = c.String(maxLength: 500),
                        TENDANHMUC_RUTGON = c.String(maxLength: 250),
                        CHITIET = c.Decimal(precision: 10, scale: 0),
                        MALOAIHINH = c.String(maxLength: 50),
                        TYLE_HAOMON = c.Decimal(precision: 10, scale: 0),
                        DONVITINH = c.String(maxLength: 20),
                        BAC = c.Decimal(precision: 10, scale: 0),
                        NAM_SX = c.Decimal(precision: 10, scale: 0),
                        NAM_SD = c.Decimal(precision: 10, scale: 0),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        USER_NAME = c.String(maxLength: 50),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_DAUTU_XDCB",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(maxLength: 20),
                        TEN = c.String(maxLength: 250),
                        NHOM_CHA = c.String(maxLength: 1),
                        MA_CHA = c.String(maxLength: 250),
                        TRANG_THAI = c.String(maxLength: 1),
                        CHU_DAU_TU = c.String(maxLength: 250),
                        LOAI_DA = c.String(maxLength: 250),
                        NHOM_DA = c.String(maxLength: 250),
                        TONG_MUC_DAU_TU = c.Decimal(precision: 18, scale: 2),
                        TU_NGAY_HIEU_LUC = c.DateTime(),
                        DEN_NGAY_HIEU_LUC = c.DateTime(),
                        DIA_DIEM_MO_TK = c.String(maxLength: 250),
                        KIEU_DA = c.String(maxLength: 3),
                        MA_HTDA = c.String(maxLength: 3),
                        TEN_HTDA = c.String(maxLength: 255),
                        MA_HTQL = c.String(maxLength: 3),
                        TEN_HTQL = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_DBHC",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_T = c.String(maxLength: 10),
                        MA_H = c.String(maxLength: 10),
                        MA_X = c.String(maxLength: 10),
                        MA_DBHC = c.String(maxLength: 500),
                        TEN_DBHC = c.String(maxLength: 500),
                        LOAI = c.Decimal(precision: 10, scale: 0),
                        MA_DBHC_CHA = c.String(maxLength: 10),
                        USER_NAME = c.String(maxLength: 20),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_HET_HL = c.DateTime(),
                        MA_THAMCHIEU = c.String(maxLength: 150),
                        CAN_CU = c.String(maxLength: 500),
                        VALID = c.Decimal(precision: 10, scale: 0),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_DONVI_CHUDAUTU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DONVI = c.String(maxLength: 10),
                        TEN_DONVI_CHUDAUTU = c.String(maxLength: 255),
                        DIACHI = c.String(maxLength: 500),
                        SODIENTHOAI = c.String(maxLength: 11),
                        NGUOIDAIDIEN = c.String(maxLength: 255),
                        EMAIL = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_DTTHANHTOAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(maxLength: 20),
                        TEN = c.String(maxLength: 250),
                        TEN_RUTGON = c.String(maxLength: 250),
                        BAC = c.Decimal(precision: 10, scale: 0),
                        CHITIET = c.Decimal(precision: 10, scale: 0),
                        MA_DB = c.String(maxLength: 100),
                        DIACHI = c.String(maxLength: 250),
                        SO_TK = c.String(maxLength: 50),
                        TEN_NGANHANG = c.String(maxLength: 250),
                        SO_CMTND = c.String(maxLength: 20),
                        NGAY_CAP = c.DateTime(),
                        NOICAP = c.String(maxLength: 250),
                        MA_KBNN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        USER_NAME = c.String(maxLength: 20),
                        TRANG_THAI = c.String(maxLength: 1),
                        LOAI_DT = c.Decimal(precision: 10, scale: 0),
                        MST = c.String(maxLength: 50),
                        TINH = c.String(maxLength: 50),
                        HUYEN = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_HACHTOANTUDONG",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(maxLength: 20),
                        TEN = c.String(maxLength: 250),
                        LOAINGHIEPVU = c.String(maxLength: 50),
                        DIENGIAI = c.String(maxLength: 250),
                        TAIKHOAN_CHUYEN = c.String(maxLength: 20),
                        LOAITK_CHUYEN = c.String(maxLength: 20),
                        TAIKHOAN_DEN = c.String(maxLength: 20),
                        LOAITK_DEN = c.String(maxLength: 20),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_IDBUILDER",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUNGTU = c.String(maxLength: 50),
                        NGAY_CHUNGTU = c.DateTime(),
                        TYPE = c.String(maxLength: 100),
                        CODE = c.String(maxLength: 100),
                        CURRENT = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_KHO",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_KHO = c.String(maxLength: 20),
                        TEN_KHO = c.String(maxLength: 250),
                        TRANG_THAI = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_LOAI_KHV",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_LOAI_KHV = c.String(maxLength: 100),
                        TEN = c.String(maxLength: 250),
                        TTHAI_KX = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_LOAI_TSCD",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(maxLength: 20),
                        TEN = c.String(maxLength: 250),
                        TEN_RUTGON = c.String(maxLength: 250),
                        DONVI_TINH = c.String(maxLength: 20),
                        TYLE_HAOMON = c.Decimal(precision: 18, scale: 2),
                        SONAM_SD = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_LOAICT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(maxLength: 20),
                        TEN = c.String(maxLength: 250),
                        NHOM_CHA = c.String(maxLength: 1),
                        MA_CHA = c.String(maxLength: 250),
                        SO_CT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LOAI_CT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        USER_NAME = c.String(maxLength: 20),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_LOAIDUTOAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(maxLength: 20),
                        TEN = c.String(maxLength: 250),
                        TEN_RUTGON = c.String(maxLength: 250),
                        BAC = c.Decimal(precision: 10, scale: 0),
                        CHITIET = c.Decimal(precision: 10, scale: 0),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        USER_NAME = c.String(maxLength: 20),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_LOAIHINH",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MALOAIHINH = c.String(maxLength: 50),
                        MALOAIHINH_CHA = c.String(maxLength: 50),
                        TENLOAIHINH = c.String(maxLength: 500),
                        TENLOAIHINH_RUTGON = c.String(maxLength: 250),
                        CAPLOAIHINH = c.Decimal(precision: 10, scale: 0),
                        LOAIHINH_CUOI = c.Decimal(precision: 10, scale: 0),
                        LOAI_LOAIHINH = c.Decimal(precision: 10, scale: 0),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        USER_NAME = c.String(maxLength: 50),
                        TRANG_THAI = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_LOAIPHI",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(maxLength: 20),
                        TEN = c.String(maxLength: 500),
                        TEN_RUTGON = c.String(maxLength: 250),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        USER_NAME = c.String(maxLength: 50),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_MA_LOAIVON",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_LOAI_VON = c.String(maxLength: 100),
                        TEN = c.String(maxLength: 250),
                        TTHAI_KX = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_MAUBAOCAOCHI",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(maxLength: 20),
                        TEN = c.String(maxLength: 250),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        USER_NAME = c.String(maxLength: 20),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_MAUBAOCAO",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_BAOCAO = c.String(maxLength: 10),
                        TEN_BAOCAO = c.String(maxLength: 100),
                        NGAY_TAO = c.DateTime(nullable: false),
                        DINH_KEM = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_MAUBAOCAOTHU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(maxLength: 20),
                        TEN = c.String(maxLength: 250),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        USER_NAME = c.String(maxLength: 20),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_NGHIEPVU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_NGHIEPVU = c.String(maxLength: 50),
                        TEN_NGHIEPVU = c.String(maxLength: 2000),
                        LOAI = c.String(maxLength: 20),
                        GHI_CHU = c.String(maxLength: 2000),
                        CONG_THUC = c.String(maxLength: 2000),
                        DIEU_KIEN = c.String(maxLength: 500),
                        DR_CR = c.String(maxLength: 50),
                        CQD = c.String(maxLength: 3),
                        TU_NGAY = c.DateTime(),
                        DEN_NGAY = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_NGUON_DIA_PHUONG",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_NGUON_DIA_PHUONG = c.String(maxLength: 4),
                        TEN_NGUON_DIA_PHUONG = c.String(maxLength: 500),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_HET_HL = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_NGUON_NSNN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_NGUON_NSNN = c.String(maxLength: 4),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_HET_HL = c.DateTime(),
                        TEN_NGUON_NSNN = c.String(maxLength: 240),
                        TRANG_THAI = c.String(maxLength: 1),
                        MA_NGUON_NSNN_CHA = c.String(maxLength: 4),
                        GHI_CHU = c.String(maxLength: 500),
                        USER_NAME = c.String(maxLength: 20),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_NGUONVON",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(maxLength: 20),
                        TEN = c.String(maxLength: 250),
                        TEN_RUTGON = c.String(maxLength: 250),
                        BAC = c.Decimal(precision: 10, scale: 0),
                        CHITIET = c.Decimal(precision: 10, scale: 0),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        USER_NAME = c.String(maxLength: 20),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_PHC_CHITIEU_HAS_CONGTHUC",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MACHITIEU = c.String(maxLength: 20),
                        MACONGTHUC = c.String(maxLength: 200),
                        CONGTHUC = c.String(maxLength: 2000),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_HET_HL = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_PHC_CHITIEUTHUCHI",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(maxLength: 50),
                        MACHA = c.String(maxLength: 20),
                        MACHITIEU = c.String(maxLength: 20),
                        TENCHITIEU = c.String(maxLength: 250),
                        CAP = c.Decimal(precision: 10, scale: 0),
                        TYLE_XADUOCHUONG = c.Decimal(precision: 18, scale: 2),
                        MATAIKHOAN = c.String(maxLength: 1000),
                        LOAICHITIEU = c.Decimal(precision: 10, scale: 0),
                        TRANG_THAI = c.String(maxLength: 1),
                        SAPXEP = c.String(maxLength: 100),
                        PHAN_HE = c.String(maxLength: 3),
                        CT_DH = c.String(),
                        CT_DH_W = c.String(),
                        CT_QT = c.String(),
                        CT_QT_W = c.String(),
                        CT_DT = c.String(),
                        CT_DT_W = c.String(),
                        TUNGAY_HL = c.DateTime(),
                        DENNGAY_HL = c.DateTime(),
                        CODELOCATION = c.String(maxLength: 5),
                        MA_DBHC = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_PHC_CONGTHUC_CHITIEUTHU_CHI",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(maxLength: 50),
                        MACHITIEU = c.String(maxLength: 20),
                        LOAICHITIEU = c.Decimal(precision: 10, scale: 0),
                        MACONGTHUC = c.String(maxLength: 200),
                        MACHUONG = c.String(),
                        MALOAI = c.String(),
                        MAKHOAN = c.String(),
                        MAMUC = c.String(),
                        MATIEUMUC = c.String(),
                        CAP = c.String(maxLength: 1000),
                        DAU = c.String(maxLength: 10),
                        MADVSDNS = c.String(maxLength: 1000),
                        MACTTM = c.String(maxLength: 1000),
                        MAQHNS = c.String(maxLength: 1000),
                        MANSH = c.String(maxLength: 1000),
                        MANGUONVON = c.String(maxLength: 1000),
                        MADB = c.String(maxLength: 1000),
                        MANVC = c.String(maxLength: 1000),
                        MANHOM = c.String(maxLength: 1000),
                        MATIEUNHOM = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_PHC_NGHIEPVU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        NHOMCHA = c.String(maxLength: 50),
                        MA = c.String(maxLength: 50),
                        TEN = c.String(maxLength: 250),
                        TAIKHOANNO = c.String(maxLength: 20),
                        TAIKHOANNOTB = c.String(maxLength: 20),
                        TAIKHOANCO = c.String(maxLength: 20),
                        TAIKHOANCONB = c.String(maxLength: 20),
                        NGUONNO = c.String(maxLength: 20),
                        NGUONCO = c.String(maxLength: 20),
                        CHUONGNO = c.String(maxLength: 3),
                        CHUONGCO = c.String(maxLength: 3),
                        LOAIKHOANNO = c.String(maxLength: 6),
                        LOAIKHOANCO = c.String(maxLength: 6),
                        MUCNO = c.String(maxLength: 6),
                        MUCCO = c.String(maxLength: 6),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_PHONGBAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_PHONGBAN = c.String(nullable: false, maxLength: 50),
                        TEN_PHONGBAN = c.String(maxLength: 500),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANGTHAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_QUY",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(maxLength: 20),
                        TEN = c.String(maxLength: 250),
                        TEN_RUTGON = c.String(maxLength: 250),
                        BAC = c.Decimal(precision: 10, scale: 0),
                        CHITIET = c.Decimal(precision: 10, scale: 0),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        USER_NAME = c.String(maxLength: 20),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_TAIKHOAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(maxLength: 20),
                        TEN = c.String(maxLength: 250),
                        LOAITK = c.String(maxLength: 1),
                        LOAIHINH_TK = c.String(maxLength: 1),
                        TEN_RUTGON = c.String(maxLength: 250),
                        BAC_TK = c.Decimal(precision: 10, scale: 0),
                        TK_CHA = c.String(maxLength: 10),
                        TINHCHAT_TK = c.String(maxLength: 1),
                        THEODOI_DT = c.Decimal(precision: 10, scale: 0),
                        THEODOI_HOATDONG = c.Decimal(precision: 10, scale: 0),
                        THEODOI_DKTT = c.Decimal(precision: 10, scale: 0),
                        THEODOI_LOAIXDCB = c.Decimal(precision: 10, scale: 0),
                        THEODOI_VATTU = c.Decimal(precision: 10, scale: 0),
                        THEODOI_CHITIET = c.Decimal(precision: 10, scale: 0),
                        THEODOI_NGOAITE = c.Decimal(precision: 10, scale: 0),
                        THEODOI_SOLUONG = c.Decimal(precision: 10, scale: 0),
                        TINHTON = c.Decimal(precision: 10, scale: 0),
                        TRONGBANG = c.Decimal(precision: 10, scale: 0),
                        LATAISANCODINH = c.Decimal(precision: 10, scale: 0),
                        LATK_THUNS = c.Decimal(precision: 10, scale: 0),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        USER_NAME = c.String(maxLength: 20),
                        THEODOI_MLNS_CHUONG = c.Decimal(precision: 10, scale: 0),
                        THEODOI_MLNS_LOAIKHOAN = c.Decimal(precision: 10, scale: 0),
                        THEODOI_MLNS_MUC = c.Decimal(precision: 10, scale: 0),
                        THEODOI_MLNS_TIEUMUC = c.String(maxLength: 20),
                        THEODOI_NGUON = c.Decimal(precision: 10, scale: 0),
                        NOP_THUE = c.Decimal(precision: 10, scale: 0),
                        THEODOI_TKKB = c.Decimal(precision: 10, scale: 0),
                        TRANG_THAI = c.String(maxLength: 1),
                        TAIKHOAN_NGUYENGIA = c.Decimal(precision: 18, scale: 2),
                        TAIKHOAN_HAOMON = c.Decimal(precision: 18, scale: 2),
                        TAIKHOAN_NGUON = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_TINHCHAT_DONGTIEN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_TCDT = c.String(maxLength: 100),
                        MA_CHA = c.String(maxLength: 100),
                        TEN_TCDT = c.String(maxLength: 250),
                        TINH_TRANG = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_TAO = c.String(maxLength: 100),
                        NGUOI_SUA = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_TINHCHATNGUON",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(maxLength: 20),
                        TEN = c.String(maxLength: 250),
                        TEN_RUTGON = c.String(maxLength: 250),
                        NHOM_CHA = c.String(maxLength: 1),
                        MA_CHA = c.String(maxLength: 250),
                        BAC = c.Decimal(precision: 10, scale: 0),
                        CHITIET = c.Decimal(precision: 10, scale: 0),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        USER_NAME = c.String(maxLength: 20),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_TKKHOBAC",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(maxLength: 20),
                        TEN = c.String(maxLength: 250),
                        TEN_RUTGON = c.String(maxLength: 250),
                        NHOM_CHA = c.String(maxLength: 1),
                        MA_CHA = c.String(maxLength: 250),
                        BAC = c.Decimal(precision: 10, scale: 0),
                        CHITIET = c.Decimal(precision: 10, scale: 0),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_HET_HL = c.DateTime(),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        USER_NAME = c.String(maxLength: 20),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_TSCD",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(maxLength: 20),
                        TEN = c.String(maxLength: 250),
                        TEN_RUTGON = c.String(maxLength: 250),
                        NAM_BD_KHAUHAO = c.String(maxLength: 250),
                        LOAI_TSCD = c.String(maxLength: 250),
                        DONVI_TINH = c.String(maxLength: 20),
                        TYLE_HAOMON = c.Decimal(precision: 18, scale: 2),
                        NAM_SANXUAT = c.DateTime(nullable: false),
                        NAM_SD = c.DateTime(nullable: false),
                        SONAM_SD = c.Decimal(precision: 10, scale: 0),
                        GIATRI_HAOMON = c.Decimal(precision: 18, scale: 2),
                        NGUYEN_GIA = c.Decimal(precision: 18, scale: 2),
                        TAIKHOAN_NGUYENGIA = c.Decimal(precision: 18, scale: 2),
                        TAIKHOAN_HAOMON = c.Decimal(precision: 18, scale: 2),
                        TAIKHOAN_NGUON = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_VATTU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(maxLength: 20),
                        TEN = c.String(maxLength: 250),
                        LOAIVATTU = c.String(maxLength: 50),
                        TEN_RUTGON = c.String(maxLength: 250),
                        DONVI_TINH = c.String(maxLength: 20),
                        MA_KHO = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_CHUONG",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUONG = c.String(maxLength: 3),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_HET_HL = c.DateTime(),
                        TEN_CHUONG = c.String(maxLength: 240),
                        TRANG_THAI = c.String(maxLength: 1),
                        MA_CAP = c.String(maxLength: 1),
                        GHI_CHU = c.String(maxLength: 500),
                        USER_NAME = c.String(maxLength: 20),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_CTMTQG",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CTMTQG = c.String(maxLength: 5),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_HET_HL = c.DateTime(),
                        TEN_CTMTQG = c.String(maxLength: 500),
                        TRANG_THAI = c.String(maxLength: 1),
                        MA_CTMTQG_CHA = c.String(maxLength: 6),
                        LOAI_CTMTQG = c.String(maxLength: 1),
                        GHI_CHU = c.String(maxLength: 500),
                        USER_NAME = c.String(maxLength: 20),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_MUC",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_MUC = c.String(maxLength: 6),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_HET_HL = c.DateTime(),
                        TEN_MUC = c.String(maxLength: 240),
                        TRANG_THAI = c.String(maxLength: 1),
                        MA_TIEUNHOM = c.String(maxLength: 4),
                        GHI_CHU = c.String(maxLength: 500),
                        USER_NAME = c.String(maxLength: 20),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        LOAI = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_NGANHKT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_NGANHKT = c.String(maxLength: 6),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_HET_HL = c.DateTime(),
                        TEN_NGANHKT = c.String(maxLength: 240),
                        TRANG_THAI = c.String(maxLength: 1),
                        LOAI_NGANHKT = c.String(maxLength: 1),
                        MA_LOAI = c.String(maxLength: 6),
                        GHI_CHU = c.String(maxLength: 500),
                        USER_NAME = c.String(maxLength: 20),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_TIEUMUC",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_TIEUMUC = c.String(maxLength: 6),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_HET_HL = c.DateTime(),
                        TEN_TIEUMUC = c.String(maxLength: 500),
                        TRANG_THAI = c.String(maxLength: 1),
                        MA_MUC = c.String(maxLength: 4),
                        GHI_CHU = c.String(maxLength: 500),
                        USER_NAME = c.String(maxLength: 20),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        LOAI = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_TIEUNHOM",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_TIEUNHOM = c.String(maxLength: 6),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_HET_HL = c.DateTime(),
                        TEN_TIEUNHOM = c.String(maxLength: 240),
                        TRANG_THAI = c.String(maxLength: 1),
                        MA_NHOM = c.String(maxLength: 4),
                        GHI_CHU = c.String(maxLength: 500),
                        USER_NAME = c.String(maxLength: 20),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.DM_TKTN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_TKTN = c.String(maxLength: 4),
                        NGAY_HL = c.DateTime(nullable: false),
                        NGAY_HET_HL = c.DateTime(),
                        TEN_TKTN = c.String(maxLength: 500),
                        TRANG_THAI = c.String(maxLength: 1),
                        MA_TKTN_CHA = c.String(maxLength: 6),
                        LOAI_TKTN = c.String(maxLength: 1),
                        CAP_TKTN = c.String(maxLength: 1),
                        GHI_CHU = c.String(maxLength: 500),
                        USER_NAME = c.String(maxLength: 20),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        NGAY_KT = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.LOG_SIGNIN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        USERNAME = c.String(nullable: false, maxLength: 50),
                        DIACHIMAY = c.String(maxLength: 100),
                        THOIGIANTRUYCAP = c.DateTime(nullable: false),
                        CHUCNANG = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.MBL_PHA_C_DTTX",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        DT = c.Decimal(precision: 19, scale: 0),
                        TX = c.Decimal(precision: 19, scale: 0),
                        SHKB = c.String(maxLength: 4),
                        NAM = c.Decimal(precision: 10, scale: 0),
                        THANG = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.MBL_PHA_C_NSDP",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        T_CCD = c.Decimal(precision: 19, scale: 0),
                        T_CTN = c.Decimal(precision: 19, scale: 0),
                        H_CCD = c.Decimal(precision: 19, scale: 0),
                        H_CTN = c.Decimal(precision: 19, scale: 0),
                        X_CCD = c.Decimal(precision: 19, scale: 0),
                        X_CTN = c.Decimal(precision: 19, scale: 0),
                        SHKB = c.String(maxLength: 4),
                        NAM = c.Decimal(precision: 10, scale: 0),
                        THANG = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.MBL_PHA_CQ_THU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        TW_THUE = c.Decimal(precision: 19, scale: 0),
                        TINH_THUE = c.Decimal(precision: 19, scale: 0),
                        HUYEN_THUE = c.Decimal(precision: 19, scale: 0),
                        XA_THUE = c.Decimal(precision: 19, scale: 0),
                        TW_HQ = c.Decimal(precision: 19, scale: 0),
                        TINH_HQ = c.Decimal(precision: 19, scale: 0),
                        HUYEN_HQ = c.Decimal(precision: 19, scale: 0),
                        XA_HQ = c.Decimal(precision: 19, scale: 0),
                        TW_KHAC = c.Decimal(precision: 19, scale: 0),
                        TINH_KHAC = c.Decimal(precision: 19, scale: 0),
                        HUYEN_KHAC = c.Decimal(precision: 19, scale: 0),
                        XA_KHAC = c.Decimal(precision: 19, scale: 0),
                        SHKB = c.String(maxLength: 4),
                        NAM = c.Decimal(precision: 10, scale: 0),
                        THANG = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.MBL_PHA_QTTDB",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        DT = c.Decimal(precision: 19, scale: 0),
                        QT = c.Decimal(precision: 19, scale: 0),
                        LOAIQT = c.String(maxLength: 4),
                        SHKB = c.String(maxLength: 4),
                        NAM = c.Decimal(precision: 10, scale: 0),
                        THANG = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.MBL_PHA_T_DIABAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SOTIEN = c.Decimal(precision: 19, scale: 0),
                        SHKB = c.String(maxLength: 4),
                        NAM = c.Decimal(precision: 10, scale: 0),
                        THANG = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.MBL_PHA_T_NSDP",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        T_DT = c.Decimal(precision: 19, scale: 0),
                        T_CG = c.Decimal(precision: 19, scale: 0),
                        T_CN = c.Decimal(precision: 19, scale: 0),
                        T_NNS = c.Decimal(precision: 19, scale: 0),
                        T_KDNS = c.Decimal(precision: 19, scale: 0),
                        T_KBNN = c.Decimal(precision: 19, scale: 0),
                        SHKB = c.String(maxLength: 4),
                        NAM = c.Decimal(precision: 10, scale: 0),
                        THANG = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.MBL_PHA_T_NSNN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        T_TW_100 = c.Decimal(precision: 19, scale: 0),
                        T_TW_PC = c.Decimal(precision: 19, scale: 0),
                        T_T_100 = c.Decimal(precision: 19, scale: 0),
                        T_T_PC = c.Decimal(precision: 19, scale: 0),
                        T_H_100 = c.Decimal(precision: 19, scale: 0),
                        T_H_PC = c.Decimal(precision: 19, scale: 0),
                        T_X_100 = c.Decimal(precision: 19, scale: 0),
                        T_X_PC = c.Decimal(precision: 19, scale: 0),
                        SHKB = c.String(maxLength: 4),
                        NAM = c.Decimal(precision: 10, scale: 0),
                        THANG = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.MBL_PHA_TC_TOANTINH",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        T_DIABAN = c.Decimal(precision: 19, scale: 0),
                        T_NSNN = c.Decimal(precision: 19, scale: 0),
                        T_NSDP = c.Decimal(precision: 19, scale: 0),
                        C_NSDP = c.Decimal(precision: 19, scale: 0),
                        SHKB = c.String(maxLength: 4),
                        NAM = c.Decimal(precision: 10, scale: 0),
                        THANG = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_AU_NGUOIDUNG_NHOMQUYEN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        USERNAME = c.String(nullable: false, maxLength: 50),
                        MANHOMQUYEN = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_AU_NGUOIDUNG_QUYEN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        USERNAME = c.String(nullable: false, maxLength: 50),
                        MACHUCNANG = c.String(nullable: false, maxLength: 50),
                        XEM = c.Decimal(nullable: false, precision: 1, scale: 0),
                        THEM = c.Decimal(nullable: false, precision: 1, scale: 0),
                        SUA = c.Decimal(nullable: false, precision: 1, scale: 0),
                        XOA = c.Decimal(nullable: false, precision: 1, scale: 0),
                        DUYET = c.Decimal(nullable: false, precision: 1, scale: 0),
                        TRANGTHAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_AU_NHOMQUYEN_CHUCNANG",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MANHOMQUYEN = c.String(nullable: false, maxLength: 50),
                        MACHUCNANG = c.String(nullable: false, maxLength: 50),
                        XEM = c.Decimal(nullable: false, precision: 1, scale: 0),
                        THEM = c.Decimal(nullable: false, precision: 1, scale: 0),
                        SUA = c.Decimal(nullable: false, precision: 1, scale: 0),
                        XOA = c.Decimal(nullable: false, precision: 1, scale: 0),
                        DUYET = c.Decimal(nullable: false, precision: 1, scale: 0),
                        TRANGTHAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_AU_NHOMQUYEN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MANHOMQUYEN = c.String(nullable: false, maxLength: 50),
                        TENNHOMQUYEN = c.String(maxLength: 100),
                        MOTA = c.String(maxLength: 200),
                        TRANGTHAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_BC_NS_CHITIET",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_BAOCAOPK = c.String(maxLength: 50),
                        MA_BAOCAO = c.String(maxLength: 50),
                        MA_CHITIEU = c.String(maxLength: 50),
                        TEN_CHITIEU = c.String(maxLength: 500),
                        AMOUNT1 = c.Decimal(precision: 18, scale: 2),
                        AMOUNT2 = c.Decimal(precision: 18, scale: 2),
                        AMOUNT3 = c.Decimal(precision: 18, scale: 2),
                        AMOUNT4 = c.Decimal(precision: 18, scale: 2),
                        AMOUNT5 = c.Decimal(precision: 18, scale: 2),
                        AMOUNT6 = c.Decimal(precision: 18, scale: 2),
                        GHI_CHU = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_BC_NS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_BAOCAOPK = c.String(maxLength: 50),
                        MA_BAOCAO = c.String(maxLength: 50),
                        NAM_BC = c.String(maxLength: 10),
                        THANG_BC = c.String(maxLength: 10),
                        DONVI = c.String(maxLength: 200),
                        NGAY_TAO = c.DateTime(),
                        NGUOI_TAO = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DASHBOARD",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        T_TW = c.Decimal(precision: 19, scale: 0),
                        T_TI = c.Decimal(precision: 19, scale: 0),
                        T_HU = c.Decimal(precision: 19, scale: 0),
                        T_XA = c.Decimal(precision: 19, scale: 0),
                        SHKB = c.String(maxLength: 4),
                        C_TW = c.Decimal(precision: 19, scale: 0),
                        C_TI = c.Decimal(precision: 19, scale: 0),
                        C_HU = c.Decimal(precision: 19, scale: 0),
                        C_XA = c.Decimal(precision: 19, scale: 0),
                        NAM = c.Decimal(precision: 10, scale: 0),
                        THANG = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DTXD01_1",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        DUTAMUNG_NT = c.Decimal(precision: 18, scale: 2),
                        HOANUNG = c.Decimal(precision: 18, scale: 2),
                        KHVDT = c.Decimal(precision: 18, scale: 2),
                        TTKL = c.Decimal(precision: 18, scale: 2),
                        VTUCTH = c.Decimal(precision: 18, scale: 2),
                        KHVCSNS = c.Decimal(precision: 18, scale: 2),
                        KHVHB = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DTXD01_2",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        DUTAMUNG_NT = c.Decimal(precision: 18, scale: 2),
                        HOANUNG = c.Decimal(precision: 18, scale: 2),
                        KHVDT = c.Decimal(precision: 18, scale: 2),
                        TTKL = c.Decimal(precision: 18, scale: 2),
                        VTUCTH = c.Decimal(precision: 18, scale: 2),
                        KHVCSNS = c.Decimal(precision: 18, scale: 2),
                        KHVHB = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DTXD01_3",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        DUTAMUNG_NT = c.Decimal(precision: 18, scale: 2),
                        HOANUNG = c.Decimal(precision: 18, scale: 2),
                        KHVDT = c.Decimal(precision: 18, scale: 2),
                        TTKL = c.Decimal(precision: 18, scale: 2),
                        VTUCTH = c.Decimal(precision: 18, scale: 2),
                        KHVCSNS = c.Decimal(precision: 18, scale: 2),
                        KHVHB = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DTXD01_4",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        DUTAMUNG_NT = c.Decimal(precision: 18, scale: 2),
                        HOANUNG = c.Decimal(precision: 18, scale: 2),
                        KHVDT = c.Decimal(precision: 18, scale: 2),
                        TTKL = c.Decimal(precision: 18, scale: 2),
                        VTUCTH = c.Decimal(precision: 18, scale: 2),
                        KHVCSNS = c.Decimal(precision: 18, scale: 2),
                        KHVHB = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DTXD01_5",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        DUTAMUNG_NT = c.Decimal(precision: 18, scale: 2),
                        HOANUNG = c.Decimal(precision: 18, scale: 2),
                        KHVDT = c.Decimal(precision: 18, scale: 2),
                        TTKL = c.Decimal(precision: 18, scale: 2),
                        VTUCTH = c.Decimal(precision: 18, scale: 2),
                        KHVCSNS = c.Decimal(precision: 18, scale: 2),
                        KHVHB = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DTXD01_6",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        DUTAMUNG_NT = c.Decimal(precision: 18, scale: 2),
                        HOANUNG = c.Decimal(precision: 18, scale: 2),
                        KHVDT = c.Decimal(precision: 18, scale: 2),
                        TTKL = c.Decimal(precision: 18, scale: 2),
                        VTUCTH = c.Decimal(precision: 18, scale: 2),
                        KHVCSNS = c.Decimal(precision: 18, scale: 2),
                        KHVHB = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DTXD01_7",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        DUTAMUNG_NT = c.Decimal(precision: 18, scale: 2),
                        HOANUNG = c.Decimal(precision: 18, scale: 2),
                        KHVDT = c.Decimal(precision: 18, scale: 2),
                        TTKL = c.Decimal(precision: 18, scale: 2),
                        VTUCTH = c.Decimal(precision: 18, scale: 2),
                        KHVCSNS = c.Decimal(precision: 18, scale: 2),
                        KHVHB = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DTXDBG04_10",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_CAP = c.String(maxLength: 50),
                        TEN_CAP = c.String(maxLength: 2000),
                        MA_CTMTQG = c.String(maxLength: 50),
                        TEN_CTMTQG = c.String(maxLength: 2000),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        KHVKD = c.Decimal(precision: 18, scale: 2),
                        KLHT = c.Decimal(precision: 18, scale: 2),
                        KHVNS = c.Decimal(precision: 18, scale: 2),
                        KHDTN = c.Decimal(precision: 18, scale: 2),
                        KLHTN = c.Decimal(precision: 18, scale: 2),
                        VTUCTH = c.Decimal(precision: 18, scale: 2),
                        KHVKD_NAM = c.Decimal(precision: 18, scale: 2),
                        VTUCTH_NAM = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DTXDBG04_1",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_CAP = c.String(maxLength: 50),
                        TEN_CAP = c.String(maxLength: 2000),
                        MA_CTMTQG = c.String(maxLength: 50),
                        TEN_CTMTQG = c.String(maxLength: 2000),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        KHVKD = c.Decimal(precision: 18, scale: 2),
                        KLHT = c.Decimal(precision: 18, scale: 2),
                        KHVNS = c.Decimal(precision: 18, scale: 2),
                        KHDTN = c.Decimal(precision: 18, scale: 2),
                        KLHTN = c.Decimal(precision: 18, scale: 2),
                        VTUCTH = c.Decimal(precision: 18, scale: 2),
                        KHVKD_NAM = c.Decimal(precision: 18, scale: 2),
                        VTUCTH_NAM = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DTXDBG04_2",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_CAP = c.String(maxLength: 50),
                        TEN_CAP = c.String(maxLength: 2000),
                        MA_CTMTQG = c.String(maxLength: 50),
                        TEN_CTMTQG = c.String(maxLength: 2000),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        KHVKD = c.Decimal(precision: 18, scale: 2),
                        KLHT = c.Decimal(precision: 18, scale: 2),
                        KHVNS = c.Decimal(precision: 18, scale: 2),
                        KHDTN = c.Decimal(precision: 18, scale: 2),
                        KLHTN = c.Decimal(precision: 18, scale: 2),
                        VTUCTH = c.Decimal(precision: 18, scale: 2),
                        KHVKD_NAM = c.Decimal(precision: 18, scale: 2),
                        VTUCTH_NAM = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DTXDBG04_3",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_CAP = c.String(maxLength: 50),
                        TEN_CAP = c.String(maxLength: 2000),
                        MA_CTMTQG = c.String(maxLength: 50),
                        TEN_CTMTQG = c.String(maxLength: 2000),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        KHVKD = c.Decimal(precision: 18, scale: 2),
                        KLHT = c.Decimal(precision: 18, scale: 2),
                        KHVNS = c.Decimal(precision: 18, scale: 2),
                        KHDTN = c.Decimal(precision: 18, scale: 2),
                        KLHTN = c.Decimal(precision: 18, scale: 2),
                        VTUCTH = c.Decimal(precision: 18, scale: 2),
                        KHVKD_NAM = c.Decimal(precision: 18, scale: 2),
                        VTUCTH_NAM = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DTXDBG04_4",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_CAP = c.String(maxLength: 50),
                        TEN_CAP = c.String(maxLength: 2000),
                        MA_CTMTQG = c.String(maxLength: 50),
                        TEN_CTMTQG = c.String(maxLength: 2000),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        KHVKD = c.Decimal(precision: 18, scale: 2),
                        KLHT = c.Decimal(precision: 18, scale: 2),
                        KHVNS = c.Decimal(precision: 18, scale: 2),
                        KHDTN = c.Decimal(precision: 18, scale: 2),
                        KLHTN = c.Decimal(precision: 18, scale: 2),
                        VTUCTH = c.Decimal(precision: 18, scale: 2),
                        KHVKD_NAM = c.Decimal(precision: 18, scale: 2),
                        VTUCTH_NAM = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DTXDBG04_5",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_CAP = c.String(maxLength: 50),
                        TEN_CAP = c.String(maxLength: 2000),
                        MA_CTMTQG = c.String(maxLength: 50),
                        TEN_CTMTQG = c.String(maxLength: 2000),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        KHVKD = c.Decimal(precision: 18, scale: 2),
                        KLHT = c.Decimal(precision: 18, scale: 2),
                        KHVNS = c.Decimal(precision: 18, scale: 2),
                        KHDTN = c.Decimal(precision: 18, scale: 2),
                        KLHTN = c.Decimal(precision: 18, scale: 2),
                        VTUCTH = c.Decimal(precision: 18, scale: 2),
                        KHVKD_NAM = c.Decimal(precision: 18, scale: 2),
                        VTUCTH_NAM = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DTXDBG04_6",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_CAP = c.String(maxLength: 50),
                        TEN_CAP = c.String(maxLength: 2000),
                        MA_CTMTQG = c.String(maxLength: 50),
                        TEN_CTMTQG = c.String(maxLength: 2000),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        KHVKD = c.Decimal(precision: 18, scale: 2),
                        KLHT = c.Decimal(precision: 18, scale: 2),
                        KHVNS = c.Decimal(precision: 18, scale: 2),
                        KHDTN = c.Decimal(precision: 18, scale: 2),
                        KLHTN = c.Decimal(precision: 18, scale: 2),
                        VTUCTH = c.Decimal(precision: 18, scale: 2),
                        KHVKD_NAM = c.Decimal(precision: 18, scale: 2),
                        VTUCTH_NAM = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DTXDBG04_7",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_CAP = c.String(maxLength: 50),
                        TEN_CAP = c.String(maxLength: 2000),
                        MA_CTMTQG = c.String(maxLength: 50),
                        TEN_CTMTQG = c.String(maxLength: 2000),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        KHVKD = c.Decimal(precision: 18, scale: 2),
                        KLHT = c.Decimal(precision: 18, scale: 2),
                        KHVNS = c.Decimal(precision: 18, scale: 2),
                        KHDTN = c.Decimal(precision: 18, scale: 2),
                        KLHTN = c.Decimal(precision: 18, scale: 2),
                        VTUCTH = c.Decimal(precision: 18, scale: 2),
                        KHVKD_NAM = c.Decimal(precision: 18, scale: 2),
                        VTUCTH_NAM = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DTXDBG04_8",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_CAP = c.String(maxLength: 50),
                        TEN_CAP = c.String(maxLength: 2000),
                        MA_CTMTQG = c.String(maxLength: 50),
                        TEN_CTMTQG = c.String(maxLength: 2000),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        KHVKD = c.Decimal(precision: 18, scale: 2),
                        KLHT = c.Decimal(precision: 18, scale: 2),
                        KHVNS = c.Decimal(precision: 18, scale: 2),
                        KHDTN = c.Decimal(precision: 18, scale: 2),
                        KLHTN = c.Decimal(precision: 18, scale: 2),
                        VTUCTH = c.Decimal(precision: 18, scale: 2),
                        KHVKD_NAM = c.Decimal(precision: 18, scale: 2),
                        VTUCTH_NAM = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DTXDBG04_9",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_CAP = c.String(maxLength: 50),
                        TEN_CAP = c.String(maxLength: 2000),
                        MA_CTMTQG = c.String(maxLength: 50),
                        TEN_CTMTQG = c.String(maxLength: 2000),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        KHVKD = c.Decimal(precision: 18, scale: 2),
                        KLHT = c.Decimal(precision: 18, scale: 2),
                        KHVNS = c.Decimal(precision: 18, scale: 2),
                        KHDTN = c.Decimal(precision: 18, scale: 2),
                        KLHTN = c.Decimal(precision: 18, scale: 2),
                        VTUCTH = c.Decimal(precision: 18, scale: 2),
                        KHVKD_NAM = c.Decimal(precision: 18, scale: 2),
                        VTUCTH_NAM = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DUTOAN_THUCHI_NSNN_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHA_DUTOAN_THUCHI_NSNN_REFID = c.String(nullable: false, maxLength: 50),
                        STT = c.String(maxLength: 5),
                        MA_CHITIEU = c.String(maxLength: 20),
                        NOI_DUNG = c.String(maxLength: 200),
                        DONVI_TINH = c.String(maxLength: 20),
                        LOAI_CHITIEU = c.String(nullable: false, maxLength: 1),
                        DUTOAN_NAMSAU = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UOC_NAMNAY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SOSANH_UTH_DT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HESO_LUONGCB = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SO_LUONG = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DINH_MUC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DUTOAN_NAMNAY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SOSANH = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GIAO_DONVI = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TRONGDO_QUYKT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QD_UBND = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QD_HDND = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DUTOAN_THUCHI_NSNN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 10),
                        TEN_DBHC = c.String(maxLength: 255),
                        MA_BAOCAO = c.String(nullable: false, maxLength: 20),
                        TEN_DVQHNS = c.String(maxLength: 255),
                        MA_DVQHNS_CHA = c.String(maxLength: 10),
                        NAM_DUTOAN = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LOAI_DUTOAN = c.String(nullable: false, maxLength: 25),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                        MA_DBHC = c.String(maxLength: 5),
                        MA_DBHC_CHA = c.String(maxLength: 5),
                        CAP = c.String(maxLength: 10),
                        LOAI = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_DUTOAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SEGMENT1 = c.String(maxLength: 50),
                        MA_TKTN = c.String(maxLength: 50),
                        TEN_TKTN = c.String(maxLength: 2000),
                        MA_NHOM = c.String(maxLength: 50),
                        TEN_NHOM = c.String(maxLength: 2000),
                        MA_TIEUNHOM = c.String(maxLength: 50),
                        TEN_TIEUNHOM = c.String(maxLength: 2000),
                        MA_MUC = c.String(maxLength: 50),
                        TEN_MUC = c.String(maxLength: 2000),
                        MA_TIEUMUC = c.String(maxLength: 50),
                        TEN_TIEUMUC = c.String(maxLength: 2000),
                        MA_CAP = c.String(maxLength: 50),
                        TEN_CAP = c.String(maxLength: 2000),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        MA_DIABAN = c.String(maxLength: 50),
                        TEN_DIABAN = c.String(maxLength: 2000),
                        MA_CAPMLNS = c.String(maxLength: 50),
                        TEN_CAPMLNS = c.String(maxLength: 2000),
                        MA_CHUONG = c.String(maxLength: 50),
                        TEN_CHUONG = c.String(maxLength: 2000),
                        MA_NGANHKT = c.String(maxLength: 50),
                        TEN_NGANHKT = c.String(maxLength: 2000),
                        MA_LOAI = c.String(maxLength: 50),
                        TEN_LOAI = c.String(maxLength: 2000),
                        MA_CTMTQG = c.String(maxLength: 50),
                        TEN_CTMTQG = c.String(maxLength: 2000),
                        MA_KBNN = c.String(maxLength: 50),
                        TEN_KBNN = c.String(maxLength: 2000),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        TEN_NGUON_NSNN = c.String(maxLength: 2000),
                        SEGMENT12 = c.String(maxLength: 50),
                        SET_OF_BOOKS_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        SOB_NAME = c.String(maxLength: 30),
                        PERIOD_NAME = c.String(maxLength: 50),
                        NGAY_KET_SO = c.DateTime(),
                        NGAY_HIEU_LUC = c.DateTime(),
                        ENTERED_DR = c.Decimal(precision: 18, scale: 2),
                        ENTERED_CR = c.Decimal(precision: 18, scale: 2),
                        ACCOUNTED_DR = c.Decimal(precision: 18, scale: 2),
                        ACCOUNTED_CR = c.Decimal(precision: 18, scale: 2),
                        ACTUAL_FLAG = c.String(maxLength: 1),
                        CURRENCY_CODE = c.String(maxLength: 50),
                        TRANSFORM_DATE = c.DateTime(nullable: false),
                        VOUCHER_DATE = c.DateTime(nullable: false),
                        ATTRIBUTE8 = c.String(maxLength: 15),
                        MA_NGHIEPVU = c.String(maxLength: 50),
                        GIA_TRI_HACH_TOAN = c.Decimal(precision: 18, scale: 2),
                        MA_NVC = c.String(maxLength: 50),
                        TEN_NVC = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_HACHTOAN_CHI",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SEGMENT1 = c.String(maxLength: 50),
                        MA_TKTN = c.String(maxLength: 50),
                        TEN_TKTN = c.String(maxLength: 2000),
                        MA_NHOM = c.String(maxLength: 50),
                        TEN_NHOM = c.String(maxLength: 2000),
                        MA_TIEUNHOM = c.String(maxLength: 50),
                        TEN_TIEUNHOM = c.String(maxLength: 2000),
                        MA_MUC = c.String(maxLength: 50),
                        TEN_MUC = c.String(maxLength: 2000),
                        MA_TIEUMUC = c.String(maxLength: 50),
                        TEN_TIEUMUC = c.String(maxLength: 2000),
                        MA_CAP = c.String(maxLength: 50),
                        TEN_CAP = c.String(maxLength: 2000),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        MA_DIABAN = c.String(maxLength: 50),
                        TEN_DIABAN = c.String(maxLength: 2000),
                        MA_CAPMLNS = c.String(maxLength: 50),
                        TEN_CAPMLNS = c.String(maxLength: 2000),
                        MA_CHUONG = c.String(maxLength: 50),
                        TEN_CHUONG = c.String(maxLength: 2000),
                        MA_NGANHKT = c.String(maxLength: 50),
                        TEN_NGANHKT = c.String(maxLength: 2000),
                        MA_LOAI = c.String(maxLength: 50),
                        TEN_LOAI = c.String(maxLength: 2000),
                        MA_CTMTQG = c.String(maxLength: 50),
                        TEN_CTMTQG = c.String(maxLength: 2000),
                        MA_KBNN = c.String(maxLength: 50),
                        TEN_KBNN = c.String(maxLength: 2000),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        TEN_NGUON_NSNN = c.String(maxLength: 2000),
                        SEGMENT12 = c.String(maxLength: 50),
                        SET_OF_BOOKS_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        SOB_NAME = c.String(maxLength: 30),
                        PERIOD_NAME = c.String(maxLength: 50),
                        NGAY_KET_SO = c.DateTime(),
                        NGAY_HIEU_LUC = c.DateTime(),
                        ENTERED_DR = c.Decimal(precision: 18, scale: 2),
                        ENTERED_CR = c.Decimal(precision: 18, scale: 2),
                        ACCOUNTED_DR = c.Decimal(precision: 18, scale: 2),
                        ACCOUNTED_CR = c.Decimal(precision: 18, scale: 2),
                        ACTUAL_FLAG = c.String(maxLength: 1),
                        CURRENCY_CODE = c.String(maxLength: 50),
                        TRANSFORM_DATE = c.DateTime(nullable: false),
                        VOUCHER_DATE = c.DateTime(nullable: false),
                        ATTRIBUTE8 = c.String(maxLength: 15),
                        MA_NGHIEPVU = c.String(maxLength: 50),
                        GIA_TRI_HACH_TOAN = c.Decimal(precision: 18, scale: 2),
                        MA_NVC = c.String(maxLength: 50),
                        TEN_NVC = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_HACHTOAN_KHAC",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SEGMENT1 = c.String(maxLength: 50),
                        MA_TKTN = c.String(maxLength: 50),
                        TEN_TKTN = c.String(maxLength: 2000),
                        MA_NHOM = c.String(maxLength: 50),
                        TEN_NHOM = c.String(maxLength: 2000),
                        MA_TIEUNHOM = c.String(maxLength: 50),
                        TEN_TIEUNHOM = c.String(maxLength: 2000),
                        MA_MUC = c.String(maxLength: 50),
                        TEN_MUC = c.String(maxLength: 2000),
                        MA_TIEUMUC = c.String(maxLength: 50),
                        TEN_TIEUMUC = c.String(maxLength: 2000),
                        MA_CAP = c.String(maxLength: 50),
                        TEN_CAP = c.String(maxLength: 2000),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        MA_DIABAN = c.String(maxLength: 50),
                        TEN_DIABAN = c.String(maxLength: 2000),
                        MA_CAPMLNS = c.String(maxLength: 50),
                        TEN_CAPMLNS = c.String(maxLength: 2000),
                        MA_CHUONG = c.String(maxLength: 50),
                        TEN_CHUONG = c.String(maxLength: 2000),
                        MA_NGANHKT = c.String(maxLength: 50),
                        TEN_NGANHKT = c.String(maxLength: 2000),
                        MA_LOAI = c.String(maxLength: 50),
                        TEN_LOAI = c.String(maxLength: 2000),
                        MA_CTMTQG = c.String(maxLength: 50),
                        TEN_CTMTQG = c.String(maxLength: 2000),
                        MA_KBNN = c.String(maxLength: 50),
                        TEN_KBNN = c.String(maxLength: 2000),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        TEN_NGUON_NSNN = c.String(maxLength: 2000),
                        SEGMENT12 = c.String(maxLength: 50),
                        SET_OF_BOOKS_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        SOB_NAME = c.String(maxLength: 30),
                        PERIOD_NAME = c.String(maxLength: 50),
                        NGAY_KET_SO = c.DateTime(),
                        NGAY_HIEU_LUC = c.DateTime(),
                        ENTERED_DR = c.Decimal(precision: 18, scale: 2),
                        ENTERED_CR = c.Decimal(precision: 18, scale: 2),
                        ACCOUNTED_DR = c.Decimal(precision: 18, scale: 2),
                        ACCOUNTED_CR = c.Decimal(precision: 18, scale: 2),
                        ACTUAL_FLAG = c.String(maxLength: 1),
                        CURRENCY_CODE = c.String(maxLength: 50),
                        TRANSFORM_DATE = c.DateTime(nullable: false),
                        VOUCHER_DATE = c.DateTime(nullable: false),
                        ATTRIBUTE8 = c.String(maxLength: 15),
                        MA_NGHIEPVU = c.String(maxLength: 50),
                        GIA_TRI_HACH_TOAN = c.Decimal(precision: 18, scale: 2),
                        MA_NVC = c.String(maxLength: 50),
                        TEN_NVC = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_HACHTOAN_THU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SEGMENT1 = c.String(maxLength: 50),
                        MA_TKTN = c.String(maxLength: 50),
                        TEN_TKTN = c.String(maxLength: 2000),
                        MA_NHOM = c.String(maxLength: 50),
                        TEN_NHOM = c.String(maxLength: 2000),
                        MA_TIEUNHOM = c.String(maxLength: 50),
                        TEN_TIEUNHOM = c.String(maxLength: 2000),
                        MA_MUC = c.String(maxLength: 50),
                        TEN_MUC = c.String(maxLength: 2000),
                        MA_TIEUMUC = c.String(maxLength: 50),
                        TEN_TIEUMUC = c.String(maxLength: 2000),
                        MA_CAP = c.String(maxLength: 50),
                        TEN_CAP = c.String(maxLength: 2000),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        MA_DIABAN = c.String(maxLength: 50),
                        TEN_DIABAN = c.String(maxLength: 2000),
                        MA_CAPMLNS = c.String(maxLength: 50),
                        TEN_CAPMLNS = c.String(maxLength: 2000),
                        MA_CHUONG = c.String(maxLength: 50),
                        TEN_CHUONG = c.String(maxLength: 2000),
                        MA_NGANHKT = c.String(maxLength: 50),
                        TEN_NGANHKT = c.String(maxLength: 2000),
                        MA_LOAI = c.String(maxLength: 50),
                        TEN_LOAI = c.String(maxLength: 2000),
                        MA_CTMTQG = c.String(maxLength: 50),
                        TEN_CTMTQG = c.String(maxLength: 2000),
                        MA_KBNN = c.String(maxLength: 50),
                        TEN_KBNN = c.String(maxLength: 2000),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        TEN_NGUON_NSNN = c.String(maxLength: 2000),
                        SEGMENT12 = c.String(maxLength: 50),
                        SET_OF_BOOKS_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        SOB_NAME = c.String(maxLength: 30),
                        PERIOD_NAME = c.String(maxLength: 50),
                        NGAY_KET_SO = c.DateTime(),
                        NGAY_HIEU_LUC = c.DateTime(),
                        ENTERED_DR = c.Decimal(precision: 18, scale: 2),
                        ENTERED_CR = c.Decimal(precision: 18, scale: 2),
                        ACCOUNTED_DR = c.Decimal(precision: 18, scale: 2),
                        ACCOUNTED_CR = c.Decimal(precision: 18, scale: 2),
                        ACTUAL_FLAG = c.String(maxLength: 1),
                        CURRENCY_CODE = c.String(maxLength: 50),
                        TRANSFORM_DATE = c.DateTime(nullable: false),
                        VOUCHER_DATE = c.DateTime(nullable: false),
                        ATTRIBUTE8 = c.String(maxLength: 15),
                        MA_NGHIEPVU = c.String(maxLength: 50),
                        GIA_TRI_HACH_TOAN = c.Decimal(precision: 18, scale: 2),
                        MA_NVC = c.String(maxLength: 50),
                        TEN_NVC = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_KBQT01",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_BAOCAO = c.String(maxLength: 50),
                        MA_CAP = c.String(maxLength: 50),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_NGUON_NSNN = c.String(maxLength: 2000),
                        TONG_MUC_DTU = c.Decimal(precision: 18, scale: 2),
                        MA_DUAN = c.String(maxLength: 50),
                        TEN_DUAN = c.String(maxLength: 2000),
                        SHKB = c.String(maxLength: 50),
                        STT = c.String(maxLength: 50),
                        COT1_01 = c.String(maxLength: 50),
                        COT2_01 = c.String(maxLength: 2000),
                        COT3_01 = c.String(maxLength: 50),
                        COT4_01 = c.Decimal(precision: 18, scale: 2),
                        COT5_01 = c.Decimal(precision: 18, scale: 2),
                        COT6_01 = c.Decimal(precision: 18, scale: 2),
                        COT7_01 = c.Decimal(precision: 18, scale: 2),
                        COT8_01 = c.Decimal(precision: 18, scale: 2),
                        COT9_01 = c.Decimal(precision: 18, scale: 2),
                        COT10_01 = c.Decimal(precision: 18, scale: 2),
                        COT11_01 = c.Decimal(precision: 18, scale: 2),
                        COT12_01 = c.Decimal(precision: 18, scale: 2),
                        COT13_01 = c.Decimal(precision: 18, scale: 2),
                        COT14_01 = c.Decimal(precision: 18, scale: 2),
                        COT15_01 = c.Decimal(precision: 18, scale: 2),
                        COT16_01 = c.Decimal(precision: 18, scale: 2),
                        COT17_01 = c.Decimal(precision: 18, scale: 2),
                        COT18_01 = c.Decimal(precision: 18, scale: 2),
                        COT19_01 = c.Decimal(precision: 18, scale: 2),
                        COT20_01 = c.Decimal(precision: 18, scale: 2),
                        COT21_01 = c.Decimal(precision: 18, scale: 2),
                        COT22_01 = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_KBQT82",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_BAOCAO = c.String(maxLength: 50),
                        MA_CAP = c.String(maxLength: 50),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_NGUON_NSNN = c.String(maxLength: 2000),
                        MA_CTMTQG = c.String(maxLength: 2000),
                        TONG_MUC_DTU = c.Decimal(precision: 18, scale: 2),
                        MA_DUAN = c.String(maxLength: 50),
                        TEN_DUAN = c.String(maxLength: 2000),
                        SHKB = c.String(maxLength: 50),
                        STT = c.String(maxLength: 50),
                        C4 = c.String(maxLength: 50),
                        C6 = c.String(maxLength: 50),
                        C7 = c.String(maxLength: 50),
                        C8 = c.Decimal(precision: 18, scale: 2),
                        C9 = c.Decimal(precision: 18, scale: 2),
                        C10 = c.Decimal(precision: 18, scale: 2),
                        C11 = c.Decimal(precision: 18, scale: 2),
                        C12 = c.Decimal(precision: 18, scale: 2),
                        C13 = c.Decimal(precision: 18, scale: 2),
                        C14 = c.Decimal(precision: 18, scale: 2),
                        C15 = c.Decimal(precision: 18, scale: 2),
                        C16 = c.Decimal(precision: 18, scale: 2),
                        C17 = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_QL_TT_VON_CHITIET",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHA_QL_TT_VON_REFID = c.String(nullable: false, maxLength: 50),
                        MA_DUAN = c.String(nullable: false, maxLength: 50),
                        MA_NGUONVON = c.String(nullable: false, maxLength: 50),
                        MA_NGANHKT = c.String(maxLength: 50),
                        KEHOACH_VON_KEODAI = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SOVON_KLHT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TONG_SO = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SOVON_TAMUNG = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KEHOACH_VON_NAMSAU = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SOVON_CONLAI_CTTHB = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_QL_TT_VON",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_PHIEU = c.String(nullable: false, maxLength: 50),
                        SO_QD = c.String(maxLength: 100),
                        LOAI_KEHOACH_VON = c.Decimal(precision: 10, scale: 0),
                        NGAY_QUYETDINH = c.DateTime(),
                        NGAY_HACHTOAN = c.DateTime(),
                        NAM_KEHOACH_VON = c.Decimal(precision: 10, scale: 0),
                        DIEN_GIAI = c.String(maxLength: 50),
                        LOAI_QLTT_VON = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_THANHTOAN_LUONG_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHA_THANHTOAN_LUONG_REFID = c.String(nullable: false, maxLength: 50),
                        STT = c.String(maxLength: 5),
                        HO_TEN = c.String(maxLength: 100),
                        CHUC_DANH = c.String(maxLength: 200),
                        HO_SO_LUONG = c.Decimal(precision: 18, scale: 2),
                        PC_KV = c.Decimal(precision: 18, scale: 2),
                        PC_CHUC_VU = c.Decimal(precision: 18, scale: 2),
                        PC_THAM_NIEN = c.Decimal(precision: 18, scale: 2),
                        PC_TRACH_NHIEM = c.Decimal(precision: 18, scale: 2),
                        PC_CONG_VU = c.Decimal(precision: 18, scale: 2),
                        PC_LOAI_XA = c.Decimal(precision: 18, scale: 2),
                        PC_LAU_NAM = c.Decimal(precision: 18, scale: 2),
                        PC_THU_HUT = c.Decimal(precision: 18, scale: 2),
                        TONG_HS = c.Decimal(precision: 18, scale: 2),
                        THANH_TIEN = c.Decimal(precision: 18, scale: 2),
                        BHXH = c.Decimal(precision: 18, scale: 2),
                        BHYT = c.Decimal(precision: 18, scale: 2),
                        CONG_CKPT = c.Decimal(precision: 18, scale: 2),
                        THUC_LINH = c.Decimal(precision: 18, scale: 2),
                        KY_NHAN = c.String(maxLength: 200),
                        GHI_CHU = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_THANHTOAN_LUONG",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_DBHC = c.String(maxLength: 5),
                        MA_DBHC_CHA = c.String(maxLength: 5),
                        MA_DVQHNS = c.String(maxLength: 10),
                        TEN_DBHC = c.String(maxLength: 255),
                        TEN_DVQHNS = c.String(maxLength: 255),
                        MA_DVQHNS_CHA = c.String(maxLength: 10),
                        NAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        THANG = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHA_THDT_HCSN_DT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_TKTN = c.String(maxLength: 50),
                        TEN_TKTN = c.String(maxLength: 2000),
                        MA_NHOM = c.String(maxLength: 50),
                        TEN_NHOM = c.String(maxLength: 2000),
                        MA_TIEUNHOM = c.String(maxLength: 50),
                        TEN_TIEUNHOM = c.String(maxLength: 2000),
                        MA_MUC = c.String(maxLength: 50),
                        TEN_MUC = c.String(maxLength: 2000),
                        MA_TIEUMUC = c.String(maxLength: 50),
                        TEN_TIEUMUC = c.String(maxLength: 2000),
                        MA_CAP = c.String(maxLength: 50),
                        TEN_CAP = c.String(maxLength: 2000),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TEN_DVQHNS = c.String(maxLength: 2000),
                        MA_DIABAN_CHA = c.String(maxLength: 50),
                        MA_DIABAN = c.String(maxLength: 50),
                        TEN_DIABAN = c.String(maxLength: 2000),
                        MA_CAPMLNS = c.String(maxLength: 50),
                        TEN_CAPMLNS = c.String(maxLength: 2000),
                        MA_CHUONG = c.String(maxLength: 50),
                        TEN_CHUONG = c.String(maxLength: 2000),
                        MA_NGANHKT = c.String(maxLength: 50),
                        TEN_NGANHKT = c.String(maxLength: 2000),
                        MA_LOAI = c.String(maxLength: 50),
                        TEN_LOAI = c.String(maxLength: 2000),
                        MA_CTMTQG = c.String(maxLength: 50),
                        TEN_CTMTQG = c.String(maxLength: 2000),
                        MA_KBNN = c.String(maxLength: 50),
                        TEN_KBNN = c.String(maxLength: 2000),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        TEN_NGUON_NSNN = c.String(maxLength: 2000),
                        NGAY_KET_SO = c.DateTime(),
                        NGAY_HIEU_LUC = c.DateTime(),
                        ENTERED_DR = c.Decimal(precision: 18, scale: 2),
                        ENTERED_CR = c.Decimal(precision: 18, scale: 2),
                        ACCOUNTED_DR = c.Decimal(precision: 18, scale: 2),
                        ACCOUNTED_CR = c.Decimal(precision: 18, scale: 2),
                        ACTUAL_FLAG = c.String(maxLength: 1),
                        ATTRIBUTE8 = c.String(maxLength: 15),
                        GIA_TRI_HACH_TOAN = c.Decimal(precision: 18, scale: 2),
                        MA_NVC = c.String(maxLength: 50),
                        TEN_NVC = c.String(maxLength: 500),
                        DL_BAOCAO = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU70NS_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU70NS_REFID = c.String(nullable: false, maxLength: 50),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 1000),
                        SO_TIEN_NT = c.Double(nullable: false),
                        SO_TIEN_NBC = c.Double(nullable: false),
                        GIAI_TRINH = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU70NS_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU70NS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_B01BCQT_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_B01BCQT_REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHI_TIEU = c.String(maxLength: 15),
                        MA_SO = c.String(maxLength: 15),
                        TEN_CHI_TIEU = c.String(maxLength: 250),
                        STT_CHI_TIEU = c.String(maxLength: 15),
                        SAP_XEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CONG_THUC = c.String(maxLength: 500),
                        MA_LOAI = c.String(maxLength: 10),
                        MA_KHOAN = c.String(maxLength: 10),
                        GIA_TRI = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_B01BCQT_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHI_TIEU = c.String(maxLength: 15),
                        MA_SO = c.String(maxLength: 15),
                        TEN_CHI_TIEU = c.String(nullable: false, maxLength: 250),
                        STT_CHI_TIEU = c.String(maxLength: 15),
                        SAP_XEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_B01BCQT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_B02BCQT_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_B02BCQT_REFID = c.String(nullable: false, maxLength: 50),
                        STT_CHI_TIEU = c.String(maxLength: 15),
                        MA_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU_CHA = c.String(maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        TEN_CHI_TIEU_OLD = c.String(maxLength: 255),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PHAN = c.String(maxLength: 20),
                        SKN_TONGSO = c.Double(nullable: false),
                        SKN_THANHTRA = c.Double(nullable: false),
                        SKN_KIEMTOAN = c.Double(nullable: false),
                        SKN_TAICHINH = c.Double(nullable: false),
                        SDXL_TONGSO = c.Double(nullable: false),
                        SDXL_THANHTRA = c.Double(nullable: false),
                        SDXL_KIEMTOAN = c.Double(nullable: false),
                        SDXL_TAICHINH = c.Double(nullable: false),
                        SCXL_TONGSO = c.Double(nullable: false),
                        SCXL_THANHTRA = c.Double(nullable: false),
                        SCXL_KIEMTOAN = c.Double(nullable: false),
                        SCXL_TAICHINH = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_B02BCQT_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT_CHI_TIEU = c.String(maxLength: 15),
                        MA_CHI_TIEU = c.String(maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PHAN = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_B02BCQT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_B02BCTC_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_B02BCTC_REFID = c.String(nullable: false, maxLength: 50),
                        STT_CHI_TIEU = c.String(maxLength: 15),
                        MA_CHI_TIEU = c.String(maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PHAN = c.Decimal(nullable: false, precision: 10, scale: 0),
                        THUYET_MINH = c.Double(nullable: false),
                        NAM_NAY = c.Double(nullable: false),
                        NAM_TRUOC = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_B02BCTC_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT_CHI_TIEU = c.String(maxLength: 15),
                        MA_CHI_TIEU = c.String(maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PHAN = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_B02BCTC",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_B02H_II_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_B02H_II_REFID = c.String(nullable: false, maxLength: 50),
                        NOI_DUNG_CHI = c.String(nullable: false, maxLength: 255),
                        MA_LOAI = c.String(maxLength: 3),
                        MA_KHOAN = c.String(maxLength: 3),
                        MA_MUC = c.String(maxLength: 4),
                        MA_TIEU_MUC = c.String(maxLength: 4),
                        MA_SO = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TONG_SO = c.Double(nullable: false),
                        NSNN_TONG_SO = c.Double(nullable: false),
                        NSNN_NSNN_GIAO = c.Double(nullable: false),
                        NSNN_PHI_LEPHI = c.Double(nullable: false),
                        NSNN_VIEN_TRO = c.Double(nullable: false),
                        NGUON_KHAC = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_B02H_II_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        NOI_DUNG_CHI = c.String(nullable: false, maxLength: 255),
                        MA_LOAI = c.String(maxLength: 3),
                        MA_KHOAN = c.String(maxLength: 3),
                        MA_MUC = c.String(maxLength: 4),
                        MA_TIEU_MUC = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_B02H_II",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_B03BCQT_BII1_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_B03BCQT_BII1_REFID = c.String(nullable: false, maxLength: 50),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_NOIDUNGKT = c.String(nullable: false, maxLength: 4),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        TEN_NOIDUNGKT = c.String(maxLength: 255),
                        SAP_XEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TONG_THU = c.Double(nullable: false),
                        TIEN_NSNN = c.Double(nullable: false),
                        TIEN_KHAUTRU = c.Double(nullable: false),
                        GHI_CHU = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_B03BCQT_BII1_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_NOIDUNGKT = c.String(nullable: false, maxLength: 4),
                        TEN_NOIDUNGKT = c.String(nullable: false, maxLength: 255),
                        INDAM = c.Decimal(precision: 10, scale: 0),
                        INNGHIENG = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_B03BCQT_BII1",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU01A_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU01A_REFID = c.String(nullable: false, maxLength: 50),
                        MA_NOIDUNGKT = c.String(nullable: false, maxLength: 4),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        TEN_NOIDUNGKT = c.String(maxLength: 255),
                        MA_CHI_TIEU = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        DT_SOBAOCAO = c.Double(nullable: false),
                        DT_SOXDTD = c.Double(nullable: false),
                        TH_SOBAOCAO = c.Double(nullable: false),
                        TH_SOXDTD = c.Double(nullable: false),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU01A_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_NOIDUNGKT = c.String(nullable: false, maxLength: 4),
                        TEN_NOIDUNGKT = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU01A",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU01B_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU01B_REFID = c.String(nullable: false, maxLength: 50),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 50),
                        MA_CHI_TIEU_OLD = c.String(maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        SO_BC = c.Double(nullable: false),
                        SO_DCKT = c.Double(nullable: false),
                        PHAN = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU01B_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        CONG_THUC = c.String(maxLength: 255),
                        CAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PHAN = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INDAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INNGHIENG = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU01B",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU01C_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU01C_REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHI_TIEU = c.String(maxLength: 15),
                        MA_SO = c.String(maxLength: 15),
                        TEN_CHI_TIEU = c.String(maxLength: 250),
                        STT_CHI_TIEU = c.String(maxLength: 15),
                        SAP_XEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CONG_THUC = c.String(maxLength: 500),
                        MA_LOAI = c.String(maxLength: 10),
                        MA_KHOAN = c.String(maxLength: 10),
                        GIA_TRI_BC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GIA_TRI_DUYET = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU01C_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHI_TIEU = c.String(maxLength: 15),
                        MA_SO = c.String(maxLength: 15),
                        TEN_CHI_TIEU = c.String(nullable: false, maxLength: 250),
                        STT_CHI_TIEU = c.String(maxLength: 15),
                        SAP_XEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU01CP2_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU01CP2_REFID = c.String(nullable: false, maxLength: 50),
                        NOI_DUNG_CHI = c.String(nullable: false, maxLength: 255),
                        MA_LOAI = c.String(maxLength: 3),
                        MA_KHOAN = c.String(maxLength: 3),
                        MA_MUC = c.String(maxLength: 4),
                        MA_TIEU_MUC = c.String(maxLength: 4),
                        TS_SOBAOCAO = c.Double(nullable: false),
                        TS_SOXDTD = c.Double(nullable: false),
                        NSTN_SOBAOCAO = c.Double(nullable: false),
                        NSTN_SOXDTD = c.Double(nullable: false),
                        VT_SOBAOCAO = c.Double(nullable: false),
                        VT_SOXDTD = c.Double(nullable: false),
                        VNNN_SOBAOCAO = c.Double(nullable: false),
                        VNNN_SOXDTD = c.Double(nullable: false),
                        PDKTL_SOBAOCAO = c.Double(nullable: false),
                        PDKTL_SOXDTD = c.Double(nullable: false),
                        NHDKDL_SOBAOCAO = c.Double(nullable: false),
                        NHDKDL_SOXDTD = c.Double(nullable: false),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU01CP2_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHI_TIEU = c.String(maxLength: 15),
                        MA_SO = c.String(maxLength: 15),
                        TEN_CHI_TIEU = c.String(nullable: false, maxLength: 250),
                        STT_CHI_TIEU = c.String(maxLength: 15),
                        SAP_XEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU01CP2",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU01C",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU03_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU03_REFID = c.String(nullable: false, maxLength: 50),
                        STT_CHI_TIEU = c.String(maxLength: 15),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 15),
                        TEN_CHI_TIEU = c.String(nullable: false, maxLength: 250),
                        DU_TOAN_NAM_TRUOC = c.Double(nullable: false),
                        DU_TOAN_DUOC_GIAO = c.Double(nullable: false),
                        DU_TOAN_DUOC_SU_DUNG = c.Double(nullable: false),
                        QUYET_TOAN_NAM = c.Double(nullable: false),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        SAPXEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU03_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT_CHI_TIEU = c.String(maxLength: 15),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 15),
                        TEN_CHI_TIEU = c.String(nullable: false, maxLength: 250),
                        CONG_THUC = c.String(maxLength: 500),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        SAPXEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INDAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INNGHIENG = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU03",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        THUYETMINH_1 = c.String(maxLength: 2000),
                        THUYETMINH_2 = c.String(maxLength: 2000),
                        THUYETMINH_3 = c.String(maxLength: 2000),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU07TT344_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU07TT344_REFID = c.String(nullable: false, maxLength: 50),
                        TONGTHU = c.Double(nullable: false),
                        THU_XAHUONG100 = c.Double(nullable: false),
                        THU_CHIATYLE = c.Double(nullable: false),
                        THU_BOSUNG = c.Double(nullable: false),
                        THU_BOSUNGCANDOINS = c.Double(nullable: false),
                        THU_BOSUNGCOMUCTIEU = c.Double(nullable: false),
                        THU_KETDUNSNAMTRUOC = c.Double(nullable: false),
                        THU_VIENTRO = c.Double(nullable: false),
                        THU_CHUYENNGUON = c.Double(nullable: false),
                        TONGCHI = c.Double(nullable: false),
                        CHI_DAUTUPT = c.Double(nullable: false),
                        CHI_THUONGXUYEN = c.Double(nullable: false),
                        CHI_CHUYENNGUON = c.Double(nullable: false),
                        CHI_NOPTRANS = c.Double(nullable: false),
                        KETDUNS = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU07TT344_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU07TT344_REFID = c.String(nullable: false, maxLength: 50),
                        TONGTHU = c.Double(nullable: false),
                        THU_XAHUONG100 = c.Double(nullable: false),
                        THU_CHIATYLE = c.Double(nullable: false),
                        THU_BOSUNG = c.Double(nullable: false),
                        THU_BOSUNGCANDOINS = c.Double(nullable: false),
                        THU_BOSUNGCOMUCTIEU = c.Double(nullable: false),
                        THU_KETDUNSNAMTRUOC = c.Double(nullable: false),
                        THU_VIENTRO = c.Double(nullable: false),
                        THU_CHUYENNGUON = c.Double(nullable: false),
                        TONGCHI = c.Double(nullable: false),
                        CHI_DAUTUPT = c.Double(nullable: false),
                        CHI_THUONGXUYEN = c.Double(nullable: false),
                        CHI_CHUYENNGUON = c.Double(nullable: false),
                        CHI_NOPTRANS = c.Double(nullable: false),
                        KETDUNS = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU07TT344",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                        TINH = c.String(maxLength: 20),
                        HUYEN = c.String(maxLength: 20),
                        XA = c.String(maxLength: 20),
                        MA_DBHC = c.String(maxLength: 5),
                        MA_DBHC_CHA = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU08TT344_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU08TT344_REFID = c.String(nullable: false, maxLength: 50),
                        SAPXEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PHAN = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NOIDUNG = c.String(maxLength: 250),
                        NOIDUNG_OLD = c.String(maxLength: 250),
                        MA_CHITIEU = c.String(maxLength: 20),
                        DUTOAN_NSNN = c.Double(nullable: false),
                        DUTOAN_NSX = c.Double(nullable: false),
                        QUYETTOAN_NSNN = c.Double(nullable: false),
                        QUYETTOAN_NSX = c.Double(nullable: false),
                        SOSANH_NSNN = c.Double(nullable: false),
                        SOSANH_NSX = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU08TT344_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU08TT344_REFID = c.String(nullable: false, maxLength: 50),
                        SAPXEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PHAN = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NOIDUNG = c.String(maxLength: 250),
                        NOIDUNG_OLD = c.String(maxLength: 250),
                        MA_CHITIEU = c.String(maxLength: 20),
                        DUTOAN_NSNN = c.Double(nullable: false),
                        DUTOAN_NSX = c.Double(nullable: false),
                        QUYETTOAN_NSNN = c.Double(nullable: false),
                        QUYETTOAN_NSX = c.Double(nullable: false),
                        SOSANH_NSNN = c.Double(nullable: false),
                        SOSANH_NSX = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU08TT344",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                        TINH = c.String(maxLength: 20),
                        HUYEN = c.String(maxLength: 20),
                        XA = c.String(maxLength: 20),
                        MA_DBHC = c.String(maxLength: 5),
                        MA_DBHC_CHA = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU09TT344_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU09TT344_REFID = c.String(nullable: false, maxLength: 50),
                        STT_CHI_TIEU = c.String(maxLength: 15),
                        MA_CHI_TIEU = c.String(maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IN_DAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        DT_TONGSO = c.Double(nullable: false),
                        DT_DTPT = c.Double(nullable: false),
                        DT_TX = c.Double(nullable: false),
                        QT_TONGSO = c.Double(nullable: false),
                        QT_DTPT = c.Double(nullable: false),
                        QT_TX = c.Double(nullable: false),
                        SS_TONGSO = c.Double(nullable: false),
                        SS_DTPT = c.Double(nullable: false),
                        SS_TX = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU09TT344_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT_CHI_TIEU = c.String(maxLength: 15),
                        MA_CHI_TIEU = c.String(maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IN_DAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU09TT344",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                        MA_DBHC = c.String(maxLength: 5),
                        MA_DBHC_CHA = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU10TT344_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU10TT344_REFID = c.String(nullable: false, maxLength: 50),
                        STT_HIEN_THI = c.String(maxLength: 15),
                        MA_CHUONG = c.String(maxLength: 3),
                        MA_MUC = c.String(maxLength: 4),
                        MA_TIEU_MUC = c.String(maxLength: 4),
                        DIEN_GIAI = c.String(maxLength: 255),
                        QUYET_TOAN = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU10TT344",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                        MA_DBHC = c.String(maxLength: 5),
                        MA_DBHC_CHA = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU11TT344_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU11TT344_REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(maxLength: 3),
                        MA_LOAI = c.String(maxLength: 3),
                        MA_KHOAN = c.String(maxLength: 3),
                        MA_MUC = c.String(maxLength: 4),
                        MA_TIEU_MUC = c.String(maxLength: 4),
                        DIEN_GIAI = c.String(nullable: false, maxLength: 255),
                        QUYET_TOAN = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU11TT344",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                        TINH = c.String(maxLength: 20),
                        HUYEN = c.String(maxLength: 20),
                        XA = c.String(maxLength: 20),
                        MA_DBHC = c.String(maxLength: 5),
                        MA_DBHC_CHA = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU12TT344_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU12TT344_REFID = c.String(nullable: false, maxLength: 50),
                        TEN_CONG_TRINH = c.String(maxLength: 255),
                        THOI_GIAN = c.DateTime(nullable: false),
                        TONG_SO_DU_TOAN = c.Double(nullable: false),
                        TD_NDG = c.Double(nullable: false),
                        GIA_TRI = c.Double(nullable: false),
                        TONG_SO_THANH_TOAN = c.Double(nullable: false),
                        KHOI_LUONG_NAM_TRUOC = c.Double(nullable: false),
                        NGUON_CAN_DOI = c.Double(nullable: false),
                        NDG = c.Double(nullable: false),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PHAN = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU12TT344",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                        TINH = c.String(maxLength: 20),
                        HUYEN = c.String(maxLength: 20),
                        XA = c.String(maxLength: 20),
                        MA_DBHC = c.String(maxLength: 5),
                        MA_DBHC_CHA = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU2A_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU2A_REFID = c.String(nullable: false, maxLength: 50),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_NOIDUNGKT = c.String(nullable: false, maxLength: 4),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        TEN_NOIDUNGKT = c.String(maxLength: 255),
                        MA_CHI_TIEU = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        DU_TOAN = c.Double(nullable: false),
                        THUC_HIEN = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU2A_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_NOIDUNGKT = c.String(nullable: false, maxLength: 4),
                        TEN_NOIDUNGKT = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU2A",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU2B_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU2B_REFID = c.String(nullable: false, maxLength: 50),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        SO_TIEN = c.Double(nullable: false),
                        PHAN = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TEN_CHI_TIEU_OLD = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU2B_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        CONG_THUC = c.String(maxLength: 255),
                        CAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PHAN = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INDAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INNGHIENG = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU2B",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU2CP1_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU2CP1_REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHI_TIEU = c.String(maxLength: 15),
                        TEN_CHI_TIEU = c.String(maxLength: 250),
                        STT_CHI_TIEU = c.String(maxLength: 15),
                        SAP_XEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_LOAI = c.String(maxLength: 10),
                        MA_KHOAN = c.String(maxLength: 10),
                        GIA_TRI = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU2CP1_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHI_TIEU = c.String(maxLength: 15),
                        TEN_CHI_TIEU = c.String(nullable: false, maxLength: 250),
                        STT_CHI_TIEU = c.String(maxLength: 15),
                        SAP_XEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU2CP1",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU2CP2_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU2CP2_REFID = c.String(nullable: false, maxLength: 50),
                        NOI_DUNG_CHI = c.String(nullable: false, maxLength: 255),
                        MA_LOAI = c.String(maxLength: 3),
                        MA_KHOAN = c.String(maxLength: 3),
                        MA_MUC = c.String(maxLength: 4),
                        MA_TIEU_MUC = c.String(maxLength: 4),
                        NS_TRONGNUOC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VIEN_TRO = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VAY_NO_NN = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PHI_KT_DELAI = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NGUON_KHAC = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU2CP2",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU3A_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU3A_REFID = c.String(nullable: false, maxLength: 50),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU_HIEN_THI = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 50),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        TEN_CHI_TIEU_OLD = c.String(maxLength: 255),
                        DT_SOBC = c.Double(nullable: false),
                        DT_SODCKT = c.Double(nullable: false),
                        TH_SOBC = c.Double(nullable: false),
                        TH_SODCKT = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU3A_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU_HIEN_THI = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU_CHA = c.String(maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        CONG_THUC = c.String(maxLength: 255),
                        CAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        SAP_XEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INDAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INNGHIENG = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU3A",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU3BP1_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU3BP1_REFID = c.String(nullable: false, maxLength: 50),
                        MA_LOAI = c.String(maxLength: 3),
                        MA_KHOAN = c.String(maxLength: 3),
                        MA_MUC = c.String(maxLength: 4),
                        MA_TIEU_MUC = c.String(maxLength: 4),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        SO_BC = c.Double(nullable: false),
                        SO_XDTD = c.Double(nullable: false),
                        PHAN = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU3BP1_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        CONG_THUC = c.String(maxLength: 500),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PHAN = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INDAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INNGHIENG = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU3BP1",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU3BP2_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU3BP2_REFID = c.String(nullable: false, maxLength: 50),
                        MA_LOAI = c.String(maxLength: 3),
                        MA_KHOAN = c.String(maxLength: 3),
                        MA_MUC = c.String(maxLength: 4),
                        MA_TIEU_MUC = c.String(maxLength: 4),
                        NOI_DUNG_CHI = c.String(maxLength: 255),
                        NSTN_SOBC = c.Double(nullable: false),
                        NSTN_SOXDTD = c.Double(nullable: false),
                        VT_SOBC = c.Double(nullable: false),
                        VT_SOXDTD = c.Double(nullable: false),
                        VN_SOBC = c.Double(nullable: false),
                        VN_SOXDTD = c.Double(nullable: false),
                        PKT_SOBC = c.Double(nullable: false),
                        PKT_SOXDTD = c.Double(nullable: false),
                        HDKDL_SOBC = c.Double(nullable: false),
                        HDKDL_SOXDTD = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU3BP2",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU4A_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU4A_REFID = c.String(nullable: false, maxLength: 50),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU_HIEN_THI = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 50),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        TEN_CHI_TIEU_OLD = c.String(maxLength: 255),
                        SO_DUTOAN = c.Double(nullable: false),
                        SO_THUCHIEN = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU4A_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU_HIEN_THI = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU_CHA = c.String(maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        CONG_THUC = c.String(maxLength: 255),
                        CAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        SAP_XEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INDAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INNGHIENG = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU4A",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU4BP1_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU4BP1_REFID = c.String(nullable: false, maxLength: 50),
                        MA_LOAI = c.String(maxLength: 3),
                        MA_KHOAN = c.String(maxLength: 3),
                        MA_MUC = c.String(maxLength: 4),
                        MA_TIEU_MUC = c.String(maxLength: 4),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        SO_TIEN = c.Double(nullable: false),
                        PHAN = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU4BP1_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        CONG_THUC = c.String(maxLength: 500),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PHAN = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INDAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INNGHIENG = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU4BP1",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU4BP2_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU4BP2_REFID = c.String(nullable: false, maxLength: 50),
                        MA_LOAI = c.String(maxLength: 3),
                        MA_KHOAN = c.String(maxLength: 3),
                        MA_MUC = c.String(maxLength: 4),
                        MA_TIEU_MUC = c.String(maxLength: 4),
                        NOI_DUNG_CHI = c.String(maxLength: 255),
                        NSTN = c.Double(nullable: false),
                        VT = c.Double(nullable: false),
                        VN = c.Double(nullable: false),
                        PKT = c.Double(nullable: false),
                        HDKDL = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU4BP2",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU67NS_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU67NS_REFID = c.String(nullable: false, maxLength: 50),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        TONG_SO = c.Double(nullable: false),
                        NS_TINH = c.Double(nullable: false),
                        NS_HUYEN = c.Double(nullable: false),
                        NS_XA = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU67NS_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INDAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INNGHIENG = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU67NS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU68NS_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU68NS_REFID = c.String(nullable: false, maxLength: 50),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        TONG_SO = c.Double(nullable: false),
                        DU_PHONG = c.Double(nullable: false),
                        TANG_THU = c.Double(nullable: false),
                        THUONG_VUOT_DTTHU = c.Double(nullable: false),
                        GHI_CHU = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU68NS_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INDAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INNGHIENG = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU68NS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU69NS_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_BIEU69NS_REFID = c.String(nullable: false, maxLength: 50),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        MA_CHI_TIEU_CHA = c.String(maxLength: 50),
                        SKN_THANHTRA = c.Double(nullable: false),
                        SKN_KIEMTOAN = c.Double(nullable: false),
                        SXL_THANHTRA = c.Double(nullable: false),
                        SXL_KIEMTOAN = c.Double(nullable: false),
                        SCXL_THANHTRA = c.Double(nullable: false),
                        SCXL_KIEMTOAN = c.Double(nullable: false),
                        GHI_CHU = c.String(maxLength: 255),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PHAN = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU69NS_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PHAN = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INDAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INNGHIENG = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_BIEU69NS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B01X_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_C_B01X_REFID = c.String(nullable: false, maxLength: 50),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_TAIKHOAN = c.String(nullable: false, maxLength: 20),
                        TEN_TAIKHOAN = c.String(nullable: false, maxLength: 250),
                        SDDK_NO = c.Double(nullable: false),
                        SDDK_CO = c.Double(nullable: false),
                        PSTK_NO = c.Double(nullable: false),
                        PSTK_CO = c.Double(nullable: false),
                        LUYKE_NO = c.Double(nullable: false),
                        LUYKE_CO = c.Double(nullable: false),
                        SDCK_NO = c.Double(nullable: false),
                        SDCK_CO = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B01X_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_TAIKHOAN = c.String(nullable: false, maxLength: 20),
                        TEN_TAIKHOAN = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B01X",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                        MA_DBHC = c.String(maxLength: 5),
                        MA_DBHC_CHA = c.String(maxLength: 5),
                        TEN_QHNS = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B02AX_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_C_B02AX_REFID = c.String(nullable: false, maxLength: 50),
                        SAP_XEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT = c.String(maxLength: 4),
                        NOI_DUNG = c.String(nullable: false, maxLength: 255),
                        NOI_DUNG_OLD = c.String(maxLength: 255),
                        MA_SO = c.String(maxLength: 3),
                        DU_TOAN = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TH_TRONG_THANG = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TH_LUYKE_DN = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SO_SANH = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B02AX",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                        MA_DBHC = c.String(maxLength: 5),
                        MA_DBHC_CHA = c.String(maxLength: 5),
                        TEN_QHNS = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B02B_X",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                        TINH = c.String(maxLength: 20),
                        HUYEN = c.String(maxLength: 20),
                        XA = c.String(maxLength: 20),
                        MA_DBHC = c.String(maxLength: 5),
                        MA_DBHC_CHA = c.String(maxLength: 5),
                        TEN_QHNS = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B02B_X_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_C_B02B_X_REFID = c.String(nullable: false, maxLength: 50),
                        STT = c.String(maxLength: 5),
                        SAPXEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NOIDUNG = c.String(maxLength: 250),
                        NOIDUNG_OLD = c.String(maxLength: 250),
                        MASO = c.Decimal(nullable: false, precision: 10, scale: 0),
                        DUTOANNAM = c.Double(nullable: false),
                        TRONGTHANG = c.Double(nullable: false),
                        LUYKE = c.Double(nullable: false),
                        SOSANH = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B03A_X_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_C_B03A_X_REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(maxLength: 3),
                        MA_LOAI = c.String(maxLength: 3),
                        MA_KHOAN = c.String(maxLength: 3),
                        MA_MUC = c.String(maxLength: 4),
                        MA_TIEU_MUC = c.String(maxLength: 4),
                        NOI_DUNG_THU = c.String(maxLength: 255),
                        NOI_DUNG_THU_OLD = c.String(maxLength: 255),
                        SO_TIEN = c.Double(nullable: false),
                        LUY_KE = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B03A_X",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                        MA_DBHC = c.String(maxLength: 5),
                        MA_DBHC_CHA = c.String(maxLength: 5),
                        TEN_QHNS = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B03B_X_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_C_B03B_X_REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(maxLength: 3),
                        MA_KHOAN = c.String(maxLength: 3),
                        MA_TIEU_MUC = c.String(maxLength: 4),
                        NOI_DUNG_CHI = c.String(maxLength: 255),
                        NOI_DUNG_CHI_OLD = c.String(maxLength: 255),
                        SO_TIEN = c.Double(nullable: false),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PHAN = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B03B_X",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                        MA_DBHC = c.String(maxLength: 5),
                        MA_DBHC_CHA = c.String(maxLength: 5),
                        TEN_QHNS = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B03C_X_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_C_B03C_X_REFID = c.String(nullable: false, maxLength: 50),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU_CHA = c.String(maxLength: 15),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        DT_TNSNN = c.Double(nullable: false),
                        DT_TNSX = c.Double(nullable: false),
                        QT_TNSNN = c.Double(nullable: false),
                        QT_TNSX = c.Double(nullable: false),
                        SAPXEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PHAN = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B03C_X",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(maxLength: 3),
                        MA_QHNS = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                        MA_DBHC = c.String(maxLength: 5),
                        MA_DBHC_CHA = c.String(maxLength: 5),
                        TEN_QHNS = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B03D_X_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_C_B03D_X_REFID = c.String(nullable: false, maxLength: 50),
                        MACHITIEU = c.String(maxLength: 20),
                        TENCHITIEU = c.String(maxLength: 255),
                        TENCHITIEU_OLD = c.String(maxLength: 255),
                        STTCHITIEU = c.String(maxLength: 20),
                        DUTOANNAM = c.Double(nullable: false),
                        QUYETTOANNAM = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B03D_X_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MACHITIEU = c.String(maxLength: 20),
                        TENCHITIEU = c.String(maxLength: 255),
                        STTCHITIEU = c.String(maxLength: 20),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INDAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INNGHIENG = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B03D_X",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                        MA_DBHC = c.String(maxLength: 5),
                        MA_DBHC_CHA = c.String(maxLength: 5),
                        TEN_QHNS = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B03X_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_C_B03X_REFID = c.String(nullable: false, maxLength: 50),
                        THU_DUTOAN_TONG = c.Double(nullable: false),
                        THU_THUCHIEN_TONG = c.Double(nullable: false),
                        THU_DUTOAN_XAHUONG100 = c.Double(nullable: false),
                        THU_THUCHIEN_XAHUONG100 = c.Double(nullable: false),
                        THU_DUTOAN_PHANCHIATYLE = c.Double(nullable: false),
                        THU_THUCHIEN_PHANCHIATYLE = c.Double(nullable: false),
                        THU_DUTOAN_THUBOSUNG = c.Double(nullable: false),
                        THU_THUCHIEN_THUBOSUNG = c.Double(nullable: false),
                        THU_DUTOAN_BOSUNGCANDOI = c.Double(nullable: false),
                        THU_THUCHIEN_BOSUNGCANDOI = c.Double(nullable: false),
                        THU_DUTOAN_BOSUNGCOMUCTIEU = c.Double(nullable: false),
                        THU_THUCHIEN_BOSUNGCOMUCTIEU = c.Double(nullable: false),
                        THU_DUTOAN_THUCHUYENNGUON = c.Double(nullable: false),
                        THU_THUCHIEN_THUCHUYENNGUON = c.Double(nullable: false),
                        CHI_DUTOAN_TONG = c.Double(nullable: false),
                        CHI_THUCHIEN_TONG = c.Double(nullable: false),
                        CHI_DUTOAN_DTPT = c.Double(nullable: false),
                        CHI_THUCHIEN_DTPT = c.Double(nullable: false),
                        CHI_DUTOAN_CTX = c.Double(nullable: false),
                        CHI_THUCHIEN_CTX = c.Double(nullable: false),
                        CHI_DUTOAN_CHICHUYENNGUON = c.Double(nullable: false),
                        CHI_THUCHIEN_CHICHUYENNGUON = c.Double(nullable: false),
                        KETDU_NGANSACH = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B03X",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                        MA_DBHC = c.String(maxLength: 5),
                        MA_DBHC_CHA = c.String(maxLength: 5),
                        TEN_QHNS = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B04X_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_C_B04X_REFID = c.String(nullable: false, maxLength: 50),
                        CHI_TIEU = c.String(nullable: false, maxLength: 50),
                        CHI_TIEU_OLD = c.String(maxLength: 50),
                        SO_DAUNAM = c.Decimal(precision: 18, scale: 2),
                        PHATSINH_TANG = c.Decimal(precision: 18, scale: 2),
                        PHATSINH_GIAM = c.Decimal(precision: 18, scale: 2),
                        CUOINAM = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B04X",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                        MA_DBHC = c.String(maxLength: 5),
                        MA_DBHC_CHA = c.String(maxLength: 5),
                        TEN_QHNS = c.String(maxLength: 255),
                        DIEN_TICH = c.Decimal(precision: 18, scale: 2),
                        DIEN_TICH_DAT = c.Decimal(precision: 18, scale: 2),
                        DANSO = c.Decimal(precision: 18, scale: 2),
                        NGANH_NGHE = c.String(maxLength: 2000),
                        MUCTIEU_NHIEMVU = c.String(maxLength: 2000),
                        DANH_GIA = c.String(maxLength: 2000),
                        NGUYEN_NHAN = c.String(maxLength: 2000),
                        KHACH_QUAN = c.String(maxLength: 2000),
                        CHU_QUAN = c.String(maxLength: 2000),
                        DENGHI_KIENXUAT = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B06X_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_C_B06X_REFID = c.String(nullable: false, maxLength: 50),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHITIEU = c.String(nullable: false, maxLength: 20),
                        TEN_CHITIEU = c.String(nullable: false, maxLength: 250),
                        TEN_CHITIEU_OLD = c.String(maxLength: 250),
                        SDDK = c.Double(nullable: false),
                        TONG_THU = c.Double(nullable: false),
                        TONG_CHI = c.Double(nullable: false),
                        CON_LAI = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B06X_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHITIEU = c.String(nullable: false, maxLength: 20),
                        TEN_CHITIEU = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_C_B06X",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                        MA_DBHC = c.String(maxLength: 5),
                        MA_DBHC_CHA = c.String(maxLength: 5),
                        TEN_QHNS = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_DM_BAOCAO",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_BAO_CAO = c.String(nullable: false, maxLength: 100),
                        TEN_BAO_CAO = c.String(nullable: false, maxLength: 250),
                        MO_TA = c.String(maxLength: 250),
                        TRANG_THAI = c.String(maxLength: 1),
                        USER_NAME = c.String(maxLength: 20),
                        NGAY_HL = c.DateTime(),
                        TEMPLATE = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_DM_DUAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DA = c.String(nullable: false, maxLength: 15),
                        SOHIEU_DA = c.String(nullable: false, maxLength: 15),
                        TEN_DA = c.String(nullable: false, maxLength: 250),
                        TEN_EN_DUAN = c.String(maxLength: 250),
                        TEN_CTMT = c.String(maxLength: 250),
                        NGAY_BATDAU = c.DateTime(nullable: false),
                        NGAY_KETTHUC = c.DateTime(nullable: false),
                        MA_CHA = c.String(maxLength: 15),
                        CAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        DONVI_THUCHIEN = c.String(maxLength: 250),
                        MO_TA = c.String(maxLength: 250),
                        LOAI_DOI_TUONG = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LA_CHITIET = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LA_HETHONG = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_DM_DVQHNS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_QHNS = c.String(nullable: false, maxLength: 15),
                        TEN_QHNS = c.String(nullable: false, maxLength: 250),
                        MA_CHA = c.String(maxLength: 15),
                        DIA_CHI = c.String(maxLength: 500),
                        CAP_DU_TOAN = c.Decimal(nullable: false, precision: 10, scale: 0),
                        DON_VI_TONG_HOP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.String(nullable: false, maxLength: 1),
                        MA_CHUONG = c.String(nullable: false, maxLength: 15),
                        MA_DBHC = c.String(maxLength: 5),
                        MA_DBHC_CHA = c.String(maxLength: 5),
                        MA_QHNS_DVQL = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_DM_HOATDONG",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        TEN = c.String(nullable: false, maxLength: 250),
                        HOATDONG_CHA = c.Decimal(precision: 10, scale: 0),
                        CAP = c.Decimal(precision: 10, scale: 0),
                        MO_TA = c.String(maxLength: 250),
                        TRANG_THAI = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_DM_LOAI_CAPPHAT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        LOAI_CAPPHAT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TEN_LOAI_CAPPHAT = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_DM_LOAIKHOAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(nullable: false, maxLength: 15),
                        TEN = c.String(nullable: false, maxLength: 250),
                        MA_CHA = c.String(maxLength: 15),
                        CAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LACHITIET = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_DM_LOAINGANSACH",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_LOAINS = c.String(nullable: false, maxLength: 15),
                        TEN_LOAINS = c.String(nullable: false, maxLength: 150),
                        MA_CHA = c.String(maxLength: 15),
                        CAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LA_CHITIET = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MO_TA = c.String(maxLength: 150),
                        TEN_MORONG = c.String(maxLength: 150),
                        TRANG_THAI = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_DM_NGUONNGANSACH",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_NGUONNS = c.String(nullable: false, maxLength: 15),
                        TEN_NGUONNS = c.String(nullable: false, maxLength: 150),
                        MA_CHA = c.String(maxLength: 15),
                        CAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LA_CHITIET = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_DM_NHOMMUCCHI",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_NHOMMC = c.String(nullable: false, maxLength: 10),
                        TEN_NHOMMC = c.String(nullable: false, maxLength: 255),
                        MO_TA = c.String(maxLength: 255),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_DM_NOIDUNGKT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(nullable: false, maxLength: 4),
                        TEN = c.String(nullable: false, maxLength: 255),
                        MA_CHA = c.String(maxLength: 4),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LA_CHITIET = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_NHOMMC = c.String(maxLength: 10),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_DM_TAIKHOAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_TAI_KHOAN = c.String(nullable: false, maxLength: 15),
                        TEN_TAI_KHOAN = c.String(nullable: false, maxLength: 250),
                        MA_CHA = c.String(maxLength: 15),
                        CAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TINH_CHAT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LA_MA_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MO_TA = c.String(maxLength: 250),
                        TRANG_THAI = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_DM_TSCD",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_TSCD = c.String(nullable: false, maxLength: 15),
                        TEN_TSCD = c.String(nullable: false, maxLength: 250),
                        MA_CHA = c.String(maxLength: 15),
                        CAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LACHITIET = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.String(nullable: false, maxLength: 1),
                        MO_TA = c.String(maxLength: 250),
                        DON_VI_TINH = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_DOICHIEUSOLIEU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DVQHNS = c.String(nullable: false, maxLength: 20),
                        TEN_DVQHNS = c.String(nullable: false, maxLength: 240),
                        MA_DVQHNS_CHA = c.String(maxLength: 20),
                        CAP_DUTOAN = c.String(nullable: false, maxLength: 2),
                        LOAI_DULIEU = c.String(maxLength: 3),
                        NAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        MA_DBHC = c.String(maxLength: 5),
                        SOTIEN_DENGHI = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SOTIEN_TABMIS = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_F01_01BCQT_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_F01_01BCQT_REFID = c.String(nullable: false, maxLength: 50),
                        NOI_DUNG_CHI = c.String(nullable: false, maxLength: 255),
                        MA_LOAI = c.String(maxLength: 3),
                        MA_KHOAN = c.String(maxLength: 3),
                        MA_MUC = c.String(maxLength: 4),
                        MA_TIEU_MUC = c.String(maxLength: 4),
                        TONG_SO = c.Double(nullable: false),
                        NSNN_TRONGNUOC = c.Double(nullable: false),
                        VIEN_TRO = c.Double(nullable: false),
                        VAYNO_NUOCNGOAI = c.Double(nullable: false),
                        NP_DELAI = c.Double(nullable: false),
                        NHD_DELAI = c.Double(nullable: false),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_F01_01BCQT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_F01_02BCQT_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_F01_02BCQT_REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHI_TIEU = c.String(maxLength: 15),
                        MA_SO = c.String(maxLength: 15),
                        TEN_CHI_TIEU = c.String(maxLength: 250),
                        STT_CHI_TIEU = c.String(maxLength: 15),
                        SAP_XEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CONG_THUC = c.String(maxLength: 500),
                        MA_LOAI = c.String(maxLength: 10),
                        MA_KHOAN = c.String(maxLength: 10),
                        GIA_TRI_PS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GIA_TRI_LK = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_F01_02BCQT_PII_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_F01_02BCQT_PII_REFID = c.String(nullable: false, maxLength: 50),
                        NOI_DUNG_CHI = c.String(nullable: false, maxLength: 255),
                        MA_LOAI = c.String(maxLength: 3),
                        MA_KHOAN = c.String(maxLength: 3),
                        MA_MUC = c.String(maxLength: 4),
                        MA_TIEU_MUC = c.String(maxLength: 4),
                        TONG_SO_NAM_NAY = c.Double(nullable: false),
                        NSNN_TRONGNUOC_NAM_NAY = c.Double(nullable: false),
                        VIEN_TRO_NAM_NAY = c.Double(nullable: false),
                        VAYNO_NUOCNGOAI_NAM_NAY = c.Double(nullable: false),
                        TONG_SO_LUY_KE = c.Double(nullable: false),
                        NSNN_TRONGNUOC_LUY_KE = c.Double(nullable: false),
                        VIEN_TRO_LUY_KE = c.Double(nullable: false),
                        VAYNO_NUOCNGOAI_LUY_KE = c.Double(nullable: false),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_F01_02BCQT_PII",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_F01_02BCQT_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_TEMPLATE = c.String(nullable: false, maxLength: 15),
                        MA_CHI_TIEU = c.String(maxLength: 15),
                        MA_SO = c.String(maxLength: 15),
                        TEN_CHI_TIEU = c.String(nullable: false, maxLength: 250),
                        STT_CHI_TIEU = c.String(maxLength: 15),
                        SAP_XEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_F01_02BCQT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_PL31_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_PL31_REFID = c.String(nullable: false, maxLength: 50),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU_HIEN_THI = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 50),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        TEN_CHI_TIEU_OLD = c.String(maxLength: 255),
                        DT_SOBC = c.Double(nullable: false),
                        DT_SODCKT = c.Double(nullable: false),
                        TH_SOBC = c.Double(nullable: false),
                        TH_SODCKT = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_PL31_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU_HIEN_THI = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU_CHA = c.String(maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        CONG_THUC = c.String(maxLength: 255),
                        CAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        SAP_XEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INDAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INNGHIENG = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_PL31",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_PL32_P1_TT01_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_PL32_P1_TT01_REFID = c.String(nullable: false, maxLength: 50),
                        MASO = c.String(maxLength: 120),
                        CHITIEU = c.String(maxLength: 250),
                        LOAI_KHOAN = c.String(maxLength: 120),
                        SO_BAOCAO = c.Double(),
                        SO_XETDUYET = c.Double(),
                        CHENH_LECH = c.Double(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_PL32_P1_TT01",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_PL32_P2_TT01_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_PL32_P2_TT01_REFID = c.String(nullable: false, maxLength: 50),
                        MA_LOAI = c.String(maxLength: 3),
                        MA_KHOAN = c.String(maxLength: 3),
                        MA_MUC = c.String(maxLength: 4),
                        MA_TIEU_MUC = c.String(maxLength: 4),
                        NOI_DUNG_CHI = c.String(maxLength: 255),
                        TS_SOBC = c.Double(nullable: false),
                        TS_SOXDTD = c.Double(nullable: false),
                        NSTN_SOBC = c.Double(nullable: false),
                        NSTN_SOXDTD = c.Double(nullable: false),
                        PHI_SOBC = c.Double(nullable: false),
                        PHI_SOXDTD = c.Double(nullable: false),
                        VT_SOBC = c.Double(nullable: false),
                        VT_SOXDTD = c.Double(nullable: false),
                        VN_SOBC = c.Double(nullable: false),
                        VN_SOXDTD = c.Double(nullable: false),
                        HDKDL_SOBC = c.Double(nullable: false),
                        HDKDL_SOXDTD = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_PL32_P2_TT01",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_PL41_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_PL41_REFID = c.String(nullable: false, maxLength: 50),
                        DON_VI = c.String(maxLength: 255),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU_HIEN_THI = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(nullable: false, maxLength: 50),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        TEN_CHI_TIEU_OLD = c.String(maxLength: 255),
                        SO_DUTOAN = c.Double(nullable: false),
                        SO_THUCHIEN = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_PL41_TEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU_HIEN_THI = c.String(maxLength: 50),
                        MA_CHI_TIEU = c.String(maxLength: 50),
                        MA_CHI_TIEU_CHA = c.String(maxLength: 50),
                        TEN_CHI_TIEU = c.String(maxLength: 255),
                        CONG_THUC = c.String(maxLength: 255),
                        CAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        SAP_XEP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INDAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        INNGHIENG = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_PL41",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_PL42_P1_TT01_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHB_PL42_P1_TT01_REFID = c.String(nullable: false, maxLength: 50),
                        MASO = c.String(maxLength: 120),
                        CHITIEU = c.String(maxLength: 250),
                        DON_VI = c.String(maxLength: 120),
                        LOAI_KHOAN = c.String(maxLength: 120),
                        SO_TIEN = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_PL42_P1_TT01",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_CHUONG = c.String(nullable: false, maxLength: 3),
                        MA_QHNS = c.String(nullable: false, maxLength: 10),
                        TEN_QHNS = c.String(maxLength: 255),
                        MA_QHNS_CHA = c.String(maxLength: 10),
                        NAM_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        KY_BC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_TAO = c.DateTime(nullable: false),
                        NGUOI_TAO = c.String(nullable: false, maxLength: 150),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHB_REPORT_FIELD",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_BAO_CAO = c.String(nullable: false, maxLength: 15),
                        HEADER_XML_FIELD = c.String(nullable: false, maxLength: 2000),
                        HEADER_REPORT_FIELD = c.String(nullable: false, maxLength: 2000),
                        DATA_XML_FIELD = c.String(nullable: false, maxLength: 2000),
                        DATA_REPORT_FIELD = c.String(nullable: false, maxLength: 2000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_BIENLAITHUDETAILS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        SO_BIENLAI = c.String(maxLength: 50),
                        TENHO_THU = c.String(maxLength: 500),
                        NOIDUNG_THU = c.String(maxLength: 500),
                        SOTIEN = c.Decimal(precision: 18, scale: 2),
                        NGAY_BIENLAI = c.DateTime(),
                        NGAY_CT = c.DateTime(),
                        NGAY_HT = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_BIENLAITHUHEADER",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        NOIDUNG = c.String(maxLength: 500),
                        TONGTIEN = c.Decimal(precision: 18, scale: 2),
                        NGAY_CT = c.DateTime(),
                        NGAY_HT = c.DateTime(),
                        TRANG_THAI = c.String(maxLength: 1),
                        FILE_NAME = c.String(maxLength: 300),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_CHUNGTUDETAILS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU_DETAIL = c.String(nullable: false, maxLength: 50),
                        MACTMT_NO = c.String(maxLength: 20),
                        MACTMT_CO = c.String(maxLength: 20),
                        MA_NGHIEPVU = c.String(maxLength: 50),
                        TAIKHOAN_NO = c.String(maxLength: 50),
                        TAIKHOAN_CO = c.String(maxLength: 50),
                        SOTIEN = c.Decimal(precision: 18, scale: 2),
                        TIEN_NSNN = c.Decimal(precision: 18, scale: 2),
                        NOIDUNG = c.String(maxLength: 500),
                        MANGUON_NO = c.String(maxLength: 20),
                        MANGUON_CO = c.String(maxLength: 20),
                        MACHUONG_NO = c.String(maxLength: 20),
                        MACHUONG_CO = c.String(maxLength: 20),
                        MALOAI_NO = c.String(maxLength: 20),
                        MALOAI_CO = c.String(maxLength: 20),
                        MAKHOAN_NO = c.String(maxLength: 20),
                        MAKHOAN_CO = c.String(maxLength: 20),
                        MAMUC_NO = c.String(maxLength: 20),
                        MAMUC_CO = c.String(maxLength: 20),
                        MATIEUMUC_NO = c.String(maxLength: 20),
                        MATIEUMUC_CO = c.String(maxLength: 20),
                        MATKKB_NO = c.String(maxLength: 20),
                        MATKKB_CO = c.String(maxLength: 20),
                        MADKTT_NO = c.String(maxLength: 20),
                        MADKTT_CO = c.String(maxLength: 20),
                        MADOITUONG_NO = c.String(maxLength: 20),
                        MADOITUONG_CO = c.String(maxLength: 20),
                        MAHOATDONG_NO = c.String(maxLength: 20),
                        MAHOATDONG_CO = c.String(maxLength: 20),
                        MALOAIXDCB_NO = c.String(maxLength: 20),
                        MALOAIXDCB_CO = c.String(maxLength: 20),
                        MATSCD_NO = c.String(maxLength: 20),
                        MATSCD_CO = c.String(maxLength: 20),
                        MAVATTU_NO = c.String(maxLength: 20),
                        MAVATTU_CO = c.String(maxLength: 20),
                        SOLUONG = c.Decimal(precision: 18, scale: 2),
                        DONGIA = c.Decimal(precision: 18, scale: 2),
                        NOP_THUE = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_CHUNGTUHEADER",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        NGAY_CT = c.DateTime(),
                        NGAY_HT = c.DateTime(),
                        MA_DTTHANHTOAN = c.String(maxLength: 50),
                        ONGBA = c.String(maxLength: 500),
                        DIA_CHI = c.String(maxLength: 250),
                        DIENGIAI = c.String(maxLength: 500),
                        SOLENHCHI = c.String(maxLength: 50),
                        MA_DIABAN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        SOCHUNGTUGOC = c.String(maxLength: 50),
                        MA_KHO = c.String(maxLength: 20),
                        ISDIEUCHINH = c.Decimal(precision: 1, scale: 0),
                        IDORIGINAL = c.Decimal(precision: 10, scale: 0),
                        FILE_NAME = c.String(maxLength: 300),
                        TRANGTHAI = c.Decimal(precision: 10, scale: 0),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_DIEUCHINHKINHPHIDETAILS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        MADANHMUC = c.String(maxLength: 50),
                        TAIKHOAN = c.String(maxLength: 50),
                        MACHUONG = c.String(maxLength: 20),
                        MALOAI = c.String(maxLength: 20),
                        MAKHOAN = c.String(maxLength: 20),
                        MAMUC = c.String(maxLength: 20),
                        MATIEUMUC = c.String(maxLength: 20),
                        SOTIEN = c.Decimal(precision: 18, scale: 2),
                        TAIKHOAN_DIEUCHINH = c.String(maxLength: 50),
                        MACHUONG_DIEUCHINH = c.String(maxLength: 20),
                        MALOAI_DIEUCHINH = c.String(maxLength: 20),
                        MAKHOAN_DIEUCHINH = c.String(maxLength: 20),
                        MAMUC_DIEUCHINH = c.String(maxLength: 20),
                        MATIEUMUC_DIEUCHINH = c.String(maxLength: 20),
                        SOTIEN_DIEUCHINH = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_DIEUCHINHKINHPHIHEADER",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        LOAICHUNGTU = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_HT = c.DateTime(),
                        DIENGIAI = c.String(maxLength: 500),
                        MANGUON = c.String(maxLength: 50),
                        MAKBNN = c.String(maxLength: 50),
                        TRANGTHAI = c.Decimal(precision: 10, scale: 0),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_DOICHIEUSOLIEUDETAILS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        DVQHNS = c.String(nullable: false, maxLength: 25),
                        LOAIDULIEU = c.String(maxLength: 10),
                        MAQUY = c.String(maxLength: 25),
                        MATAIKHOAN = c.String(maxLength: 25),
                        CAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        DBHC = c.String(maxLength: 25),
                        CHUONG = c.String(maxLength: 25),
                        LOAI = c.String(maxLength: 25),
                        KHOAN = c.String(maxLength: 25),
                        MUC = c.String(maxLength: 25),
                        TIEUMUC = c.String(maxLength: 25),
                        NHOM = c.String(maxLength: 25),
                        TIEUNHOM = c.String(maxLength: 25),
                        CTMT = c.String(maxLength: 25),
                        KBNN = c.String(maxLength: 25),
                        MANGUONVON = c.String(maxLength: 25),
                        LOAICHUNGTU = c.String(maxLength: 25),
                        SOTIEN = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NGAYPHATSINH = c.DateTime(),
                        TUNGAY_HIEULUC = c.DateTime(),
                        DENNGAY_HIEULUC = c.DateTime(),
                        KY = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_DOICHIEUSOLIEUHEADER",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        DVQHNS = c.String(nullable: false, maxLength: 25),
                        LOAIDULIEU = c.String(maxLength: 10),
                        SOTIEN = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NGAYPHATSINH = c.DateTime(),
                        TUNGAY_HIEULUC = c.DateTime(),
                        DENNGAY_HIEULUC = c.DateTime(),
                        KY = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TENFILE = c.String(maxLength: 500),
                        DUONGDAN = c.String(maxLength: 1000),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_DT_CHI_MLNS_CHITIET",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SOCHUNGTU = c.String(nullable: false, maxLength: 20),
                        TAIKHOAN_NO = c.String(maxLength: 50),
                        MANGUON = c.String(maxLength: 20),
                        MACHUONG = c.String(maxLength: 3),
                        MAKHOAN = c.String(maxLength: 6),
                        MATIEUMUC = c.String(maxLength: 6),
                        MACTMT = c.String(maxLength: 6),
                        HUYENGIAO = c.Decimal(precision: 18, scale: 2),
                        QUY1 = c.Decimal(precision: 18, scale: 2),
                        QUY2 = c.Decimal(precision: 18, scale: 2),
                        QUY3 = c.Decimal(precision: 18, scale: 2),
                        QUY4 = c.Decimal(precision: 18, scale: 2),
                        THANG1 = c.Decimal(precision: 18, scale: 2),
                        THANG2 = c.Decimal(precision: 18, scale: 2),
                        THANG3 = c.Decimal(precision: 18, scale: 2),
                        THANG4 = c.Decimal(precision: 18, scale: 2),
                        THANG5 = c.Decimal(precision: 18, scale: 2),
                        THANG6 = c.Decimal(precision: 18, scale: 2),
                        THANG7 = c.Decimal(precision: 18, scale: 2),
                        THANG8 = c.Decimal(precision: 18, scale: 2),
                        THANG9 = c.Decimal(precision: 18, scale: 2),
                        THANG10 = c.Decimal(precision: 18, scale: 2),
                        THANG11 = c.Decimal(precision: 18, scale: 2),
                        THANG12 = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_DT_CHI_MLNS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SOCHUNGTU = c.String(nullable: false, maxLength: 50),
                        NGAY_CT = c.DateTime(),
                        NOIDUNG = c.String(maxLength: 500),
                        LOAIPHANBO = c.Decimal(precision: 10, scale: 0),
                        TUDONGPHANBO = c.Decimal(precision: 1, scale: 0),
                        LOAI_DT = c.Decimal(precision: 10, scale: 0),
                        FILE_NAME = c.String(maxLength: 300),
                        SOCHUNGTUGOC = c.String(maxLength: 50),
                        LUUTAM = c.Decimal(precision: 10, scale: 0),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_DT_THU_MLNS_CHITIET",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MADUTOAN = c.String(maxLength: 20),
                        SO_QD = c.Decimal(precision: 10, scale: 0),
                        MANGUON = c.String(maxLength: 20),
                        MACHUONG = c.String(maxLength: 3),
                        MAKHOAN = c.String(maxLength: 6),
                        MATIEUMUC = c.String(maxLength: 6),
                        NSNN = c.Decimal(precision: 18, scale: 2),
                        NSX = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_DT_THU_MLNS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MADUTOAN = c.String(maxLength: 20),
                        NOIDUNG = c.String(maxLength: 500),
                        NGAY_QD = c.DateTime(),
                        NGAY_HT = c.DateTime(),
                        SO_QD = c.Decimal(precision: 10, scale: 0),
                        SO_CTGS = c.Decimal(precision: 10, scale: 0),
                        LOAI_DT = c.Decimal(precision: 10, scale: 0),
                        FILE_NAME = c.String(maxLength: 300),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_DT_THUCHI_NDKT_CHITIET",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MADUTOAN = c.String(maxLength: 20),
                        MACHITIEU = c.String(maxLength: 20),
                        LOAICHITIEU = c.Decimal(precision: 10, scale: 0),
                        NSNN_DAUNAM = c.Decimal(precision: 18, scale: 2),
                        NSX_DAUNAM = c.Decimal(precision: 18, scale: 2),
                        NSNN_BOSUNG = c.Decimal(precision: 18, scale: 2),
                        NSX_BOSUNG = c.Decimal(precision: 18, scale: 2),
                        NSNN_DIEUCHINH = c.Decimal(precision: 18, scale: 2),
                        NSX_DIEUCHINH = c.Decimal(precision: 18, scale: 2),
                        NSNN_HUY = c.Decimal(precision: 18, scale: 2),
                        NSX_HUY = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_DT_THUCHI_NDKT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MADUTOAN = c.String(maxLength: 20),
                        TENDUTOAN = c.String(maxLength: 500),
                        NAM = c.Decimal(precision: 10, scale: 0),
                        LOAICHITIEU = c.Decimal(precision: 10, scale: 0),
                        NGAY_QD = c.DateTime(),
                        NGAY_HT = c.DateTime(),
                        SO_QD = c.Decimal(precision: 10, scale: 0),
                        SO_CTGS = c.Decimal(precision: 10, scale: 0),
                        NOIDUNG = c.String(maxLength: 500),
                        FILE_NAME = c.String(maxLength: 300),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_HMTSCD_DETAILS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        TAISAN = c.String(maxLength: 20),
                        TK_NO = c.String(maxLength: 20),
                        TK_CO = c.String(maxLength: 20),
                        DIENGIAI = c.String(maxLength: 200),
                        SO_TIEN = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_HMTSCD",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        NGAY_CT = c.DateTime(),
                        NGAY_HT = c.DateTime(),
                        ISBOHAOMON = c.Decimal(precision: 1, scale: 0),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_NHAPCHUNGTU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUNGTU = c.String(maxLength: 50),
                        SO_CHUNGTU = c.String(maxLength: 50),
                        SO_LENHCHI = c.String(maxLength: 250),
                        SO_CHUNGTUGOC = c.String(maxLength: 250),
                        NGAY_CT = c.DateTime(),
                        NGAY_HT = c.DateTime(),
                        TEN = c.String(maxLength: 500),
                        DIA_CHI = c.String(maxLength: 500),
                        CTMT = c.String(maxLength: 250),
                        TKKB = c.String(maxLength: 250),
                        CHI_TIET = c.String(maxLength: 250),
                        MA_NV = c.String(maxLength: 50),
                        CO_HOADON = c.String(maxLength: 1),
                        SO_HOADON = c.String(maxLength: 100),
                        NGAY_HOADON = c.DateTime(),
                        NOI_DUNG = c.String(maxLength: 500),
                        TK_NO = c.String(maxLength: 50),
                        TK_NO_NB = c.String(maxLength: 50),
                        NGUON_NO = c.String(maxLength: 50),
                        CHUONG_NO = c.String(maxLength: 50),
                        KHOAN_NO = c.String(maxLength: 50),
                        MUC_NO = c.String(maxLength: 50),
                        TIET_NO = c.String(maxLength: 50),
                        QUY_NO = c.String(maxLength: 50),
                        DOI_TUONG_NO = c.String(maxLength: 50),
                        LOAI_HINH_NO = c.String(maxLength: 50),
                        MA_CHITIET_NO = c.String(maxLength: 50),
                        TK_CO = c.String(maxLength: 50),
                        NGUON_CO = c.String(maxLength: 50),
                        CHUONG_CO = c.String(maxLength: 50),
                        KHOAN_CO = c.String(maxLength: 50),
                        MUC_CO = c.String(maxLength: 50),
                        TIET_CO = c.String(maxLength: 50),
                        QUY_CO = c.String(maxLength: 50),
                        DOI_TUONG_CO = c.String(maxLength: 50),
                        LOAI_HINH_CO = c.String(maxLength: 50),
                        MA_CHITIET_CO = c.String(maxLength: 50),
                        DVT = c.String(maxLength: 50),
                        SO_LUONG = c.Decimal(precision: 18, scale: 2),
                        DON_GIA = c.Decimal(precision: 18, scale: 2),
                        NSNN = c.String(maxLength: 250),
                        DONVI_HUONG = c.String(maxLength: 250),
                        NOP_THUE = c.String(maxLength: 250),
                        SO_TIEN = c.Decimal(precision: 18, scale: 2),
                        SOTIEN_CHUNGTU = c.Decimal(precision: 18, scale: 2),
                        TONG_NSNN = c.Decimal(precision: 18, scale: 2),
                        TONG_PHATSINH = c.Decimal(precision: 18, scale: 2),
                        QUY_TM = c.String(maxLength: 250),
                        TRANG_THAI = c.String(maxLength: 1),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_NHAPSODUDETAILS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        MACTMT = c.String(maxLength: 20),
                        TAIKHOAN = c.String(maxLength: 50),
                        NOI_DUNG_CHITIET = c.String(maxLength: 500),
                        TIEN_NSNN = c.Decimal(precision: 18, scale: 2),
                        NOIDUNG = c.String(maxLength: 500),
                        MANGUON = c.String(maxLength: 20),
                        MACHUONG = c.String(maxLength: 20),
                        MALOAI = c.String(maxLength: 20),
                        MAKHOAN = c.String(maxLength: 20),
                        MAMUC = c.String(maxLength: 20),
                        MATIEUMUC = c.String(maxLength: 20),
                        MATKKB = c.String(maxLength: 20),
                        MADKTT = c.String(maxLength: 20),
                        MADOITUONG = c.String(maxLength: 20),
                        MAHOATDONG = c.String(maxLength: 20),
                        MALOAIXDCB = c.String(maxLength: 20),
                        MATSCD = c.String(maxLength: 20),
                        MAVATTU = c.String(maxLength: 20),
                        SOLUONG = c.Decimal(precision: 18, scale: 2),
                        DONGIA = c.Decimal(precision: 18, scale: 2),
                        SOTIEN_NO = c.Decimal(precision: 18, scale: 2),
                        SOTIEN_CO = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_NHAPSODUHEADER",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        NGAY_HT = c.DateTime(),
                        NOI_DUNG = c.String(maxLength: 500),
                        TRANG_THAI = c.String(maxLength: 1),
                        FILE_NAME = c.String(maxLength: 300),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_PHIEU_BANGKENOPTHUE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(maxLength: 20),
                        NGAY_HT = c.DateTime(),
                        DON_VI = c.String(maxLength: 100),
                        MA_DVQHNS = c.String(maxLength: 10),
                        HINH_THUC_NOP = c.String(maxLength: 1),
                        LOAI_TIEN = c.String(maxLength: 1),
                        NGUOI_NOP = c.String(maxLength: 100),
                        MA_SO_THUE = c.String(maxLength: 20),
                        DIA_CHI = c.String(maxLength: 500),
                        HUYEN = c.String(maxLength: 50),
                        TINH = c.String(maxLength: 50),
                        NGUOI_NOP_THAY = c.String(maxLength: 100),
                        DIA_CHI_NGUOI_NOP_THAY = c.String(maxLength: 500),
                        HUYEN_NGUOI_NOP_THAY = c.String(maxLength: 50),
                        TINH_NGUOI_NOP_THAY = c.String(maxLength: 50),
                        KHO_BAC = c.String(maxLength: 200),
                        TK_KHO_BAC = c.String(maxLength: 50),
                        NOP_NSNN_THEO = c.String(maxLength: 1),
                        TK_KHO_BAC_VAO = c.String(maxLength: 50),
                        TINH_KHO_BAC_VAO = c.String(maxLength: 50),
                        CO_QUAN = c.String(maxLength: 1),
                        CQ_THU = c.String(maxLength: 300),
                        NGAY_IN = c.DateTime(),
                        NGUOI_IN = c.String(maxLength: 100),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_PHIEU_CTTT_IN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        THANH_TOAN_TT = c.Decimal(nullable: false, precision: 1, scale: 0),
                        THANH_TOAN_TAM_UNG = c.Decimal(nullable: false, precision: 1, scale: 0),
                        TAM_UNG = c.Decimal(nullable: false, precision: 1, scale: 0),
                        SO_CHUNGTU = c.String(maxLength: 20),
                        MA_DVSDNS = c.String(maxLength: 50),
                        SO_HOA_DON = c.String(maxLength: 100),
                        NGAY_HD = c.DateTime(),
                        SO_LUONG = c.String(maxLength: 100),
                        DINH_MUC = c.String(maxLength: 100),
                        SO_TIEN = c.String(maxLength: 100),
                        NGAY_IN = c.DateTime(),
                        NGUOI_IN = c.String(maxLength: 100),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_PHIEU_GDNTT_IN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        BO_PHAN = c.String(maxLength: 50),
                        MA_DVSDNS = c.String(maxLength: 100),
                        NGAY_THANG_NAM = c.DateTime(),
                        SO_CHUNGTU = c.String(maxLength: 100),
                        KINH_GUI = c.String(maxLength: 100),
                        NGUOI_DE_NGHI = c.String(maxLength: 100),
                        BO_PHAN_TT = c.String(maxLength: 100),
                        NOI_DUNG = c.String(maxLength: 100),
                        SO_TIEN = c.Decimal(precision: 18, scale: 2),
                        NGAY_IN = c.DateTime(),
                        NGUOI_IN = c.String(maxLength: 100),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_PHIEU_GG_CCDC_IN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(maxLength: 20),
                        DON_VI = c.String(maxLength: 100),
                        BO_PHAN = c.String(maxLength: 100),
                        MA_DVSDNS = c.String(maxLength: 100),
                        NGAY_HT = c.DateTime(),
                        NGAY_IN = c.DateTime(),
                        NGUOI_IN = c.String(maxLength: 100),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_PHIEU_GRDT_IN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        THUC_CHI = c.Decimal(nullable: false, precision: 1, scale: 0),
                        TAM_UNG = c.Decimal(nullable: false, precision: 1, scale: 0),
                        UNG_TRUOC_CHUA_DU = c.Decimal(nullable: false, precision: 1, scale: 0),
                        UNG_TRUOC_DU = c.Decimal(nullable: false, precision: 1, scale: 0),
                        CHUYEN_KHOAN = c.Decimal(nullable: false, precision: 1, scale: 0),
                        TIEN_MAT_KB = c.Decimal(nullable: false, precision: 1, scale: 0),
                        MA_SO_PHIEU = c.String(maxLength: 20),
                        TIEN_MAT_NH = c.Decimal(nullable: false, precision: 1, scale: 0),
                        SO_CHUNGTU = c.String(maxLength: 50),
                        KBNN = c.String(maxLength: 100),
                        TAI_KHOAN = c.String(maxLength: 100),
                        CKC_HDK = c.String(maxLength: 100),
                        CKC_HDTH = c.String(maxLength: 100),
                        DON_VI_NHAN = c.String(maxLength: 100),
                        DIA_CHI_NHAP = c.String(maxLength: 100),
                        KBNN_NHAP = c.String(maxLength: 100),
                        TAI_KHOAN_NHAP = c.String(maxLength: 100),
                        NGUOI_NHAN = c.String(maxLength: 100),
                        CMND = c.String(maxLength: 100),
                        NGAY = c.DateTime(),
                        NOI_CAP = c.String(maxLength: 100),
                        NGAY_IN = c.DateTime(),
                        NGUOI_IN = c.String(maxLength: 100),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_PHIEU_GRT_IN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        MA_SO_PHIEU = c.String(maxLength: 20),
                        DVLT = c.String(maxLength: 100),
                        DIA_CHI = c.String(),
                        MA_DVQHNS = c.String(maxLength: 10),
                        MA_TK = c.String(maxLength: 30),
                        TEN_KBNN = c.String(maxLength: 100),
                        NGUOI_LINH = c.String(maxLength: 50),
                        SO_CMND = c.String(maxLength: 20),
                        NGAY_CAP = c.DateTime(nullable: false),
                        NOI_CAP = c.String(maxLength: 100),
                        NGAY_TAO = c.DateTime(),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_PHIEU_GT_CCDC_IN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(maxLength: 20),
                        DON_VI = c.String(maxLength: 100),
                        BO_PHAN = c.String(maxLength: 100),
                        MA_DVSDNS = c.String(maxLength: 100),
                        NGAY_HT = c.DateTime(),
                        NGAY_IN = c.DateTime(),
                        NGUOI_IN = c.String(maxLength: 100),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_PHIEU_NHAPXUAT_KHO_IN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        LOAI_PHIEU = c.String(maxLength: 20),
                        SO_CHUNGTU = c.String(maxLength: 20),
                        NGAY_HT = c.DateTime(),
                        KHO_BAC = c.String(maxLength: 300),
                        DON_VI = c.String(maxLength: 100),
                        LY_DO = c.String(maxLength: 2000),
                        NGAY_IN = c.DateTime(),
                        NGUOI_IN = c.String(maxLength: 100),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_PHIEU_NOPTIEN_VAONSNN_IN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        NGAY_IN = c.DateTime(nullable: false),
                        SO_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        MST = c.String(maxLength: 50),
                        HINHTHUC = c.String(maxLength: 2),
                        NGUOINOPTHAY = c.String(maxLength: 250),
                        NGUOINOPTHAY_MST = c.String(maxLength: 20),
                        NGUOINOPTHAY_DIACHI = c.String(maxLength: 250),
                        NGUOINOPTHAY_DIACHI_HUYEN = c.String(maxLength: 250),
                        NGUOINOPTHAY_DIACHI_TP = c.String(maxLength: 250),
                        DENGHI_NH = c.String(maxLength: 250),
                        DENGHI_NH_SOTK = c.String(maxLength: 50),
                        THU_TIEN_MAT_DE = c.String(maxLength: 50),
                        TAI_KBNN = c.String(maxLength: 250),
                        KBNN_TINH_TP = c.String(maxLength: 250),
                        MO_TAI_NHTM = c.String(maxLength: 250),
                        NOP_THEO_QD_CQTQ = c.String(maxLength: 50),
                        TEN_CQQL = c.String(maxLength: 250),
                        TKHQ_SO = c.String(maxLength: 50),
                        TKHQ_NGAY = c.DateTime(),
                        LOIAHINH_XNK = c.String(maxLength: 50),
                        MA_CQ_THU = c.String(maxLength: 50),
                        MA_DBHC = c.String(maxLength: 50),
                        MA_NGUON_NSNN = c.String(maxLength: 50),
                        NO_TK = c.String(maxLength: 50),
                        CO_TK = c.String(maxLength: 50),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_PHIEU_NTVTK_IN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(maxLength: 20),
                        NGAY_HT = c.DateTime(),
                        MA_DVNT = c.String(maxLength: 100),
                        TEN_DVNT = c.String(maxLength: 100),
                        MA_TKKB = c.String(maxLength: 100),
                        DIA_CHI_DT = c.String(maxLength: 100),
                        MA_DVSDNS = c.String(maxLength: 100),
                        NGAY_IN = c.DateTime(),
                        NGUOI_IN = c.String(maxLength: 100),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_PHIEU_RVDT_IN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(maxLength: 20),
                        TEN_DA = c.String(maxLength: 200),
                        TAI_KHOANKB = c.String(maxLength: 20),
                        TEN_CDT = c.String(maxLength: 100),
                        NGAY_CKCHDK = c.DateTime(),
                        MA_DVQHNS = c.String(maxLength: 10),
                        TONG_TIEN = c.Decimal(precision: 18, scale: 2),
                        QUYEN_SO = c.String(maxLength: 20),
                        MA_DVNT = c.String(maxLength: 10),
                        MST = c.String(maxLength: 5),
                        MA_NDKT = c.String(maxLength: 5),
                        MA_CHUONG = c.String(maxLength: 5),
                        MA_CQT = c.String(maxLength: 10),
                        CQQL = c.String(maxLength: 10),
                        MA_KBHTT = c.String(maxLength: 10),
                        TEN_KBHTT = c.String(maxLength: 10),
                        TIEN_THUE = c.Decimal(precision: 18, scale: 2),
                        DV_NHANTIEN = c.String(maxLength: 100),
                        DIA_CHI_DVH = c.String(maxLength: 200),
                        TAI_KHOAN_DVH = c.String(maxLength: 20),
                        MA_CTMT_DVH = c.String(maxLength: 20),
                        MA_DA = c.String(maxLength: 20),
                        MA_HTCT = c.String(maxLength: 20),
                        MA_CMND_NL = c.String(maxLength: 20),
                        NGAY_CAP_NL = c.DateTime(),
                        NOI_CAP_NL = c.String(maxLength: 200),
                        TONG_TIENTT_DVH = c.Decimal(precision: 18, scale: 2),
                        NGAY_IN = c.DateTime(),
                        NGUOI_IN = c.String(maxLength: 100),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_PHIEU_UNC_IN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(maxLength: 20),
                        NAM_NS = c.String(maxLength: 20),
                        DON_VI = c.String(maxLength: 20),
                        DIA_CHI = c.String(maxLength: 100),
                        DON_VI_NHAN = c.String(maxLength: 100),
                        DIA_CHI_NHAP = c.String(maxLength: 100),
                        TAI_KHOAN_NHAP = c.String(maxLength: 20),
                        NGAY_IN = c.DateTime(),
                        NGUOI_IN = c.String(maxLength: 100),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_PHIEU_UNT_IN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(maxLength: 20),
                        DON_VI_BAN_HANG = c.String(maxLength: 100),
                        HOP_DONG = c.String(maxLength: 100),
                        KEM_THEO = c.String(maxLength: 100),
                        MA_DVNT = c.String(maxLength: 100),
                        NGAY_CHAM_TRA = c.String(),
                        SO_TIEN_PHAT = c.Decimal(precision: 18, scale: 2),
                        TONG_TIEN_CHUYEN = c.Decimal(precision: 18, scale: 2),
                        NGAY_IN = c.DateTime(),
                        NGUOI_IN = c.String(maxLength: 100),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_PHIEUCHI_IN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(maxLength: 20),
                        NGAY_HT = c.DateTime(),
                        DON_VI = c.String(maxLength: 100),
                        MA_DVQHNS = c.String(maxLength: 10),
                        TK_NO = c.String(maxLength: 5),
                        TK_CO = c.String(maxLength: 5),
                        HO_TEN = c.String(maxLength: 100),
                        DIA_CHI = c.String(maxLength: 300),
                        NOI_DUNG = c.String(maxLength: 500),
                        SO_TIEN = c.Decimal(precision: 18, scale: 2),
                        LOAI_TIEN = c.String(maxLength: 200),
                        KEM_THEO = c.String(maxLength: 500),
                        NGAY_IN = c.DateTime(),
                        NGUOI_IN = c.String(maxLength: 100),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_PHIEUTHU_IN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REFID = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(maxLength: 20),
                        DON_VI = c.String(maxLength: 100),
                        BO_PHAN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 10),
                        NGAY_HT = c.DateTime(),
                        QUYEN_SO = c.String(maxLength: 20),
                        MA_SO_PHIEU = c.String(maxLength: 20),
                        TK_NO = c.String(maxLength: 5),
                        TK_CO = c.String(maxLength: 5),
                        NGUOI_NOP = c.String(maxLength: 100),
                        DIA_CHI = c.String(),
                        SO_TIEN = c.Decimal(precision: 18, scale: 2),
                        KEM_THEO = c.String(maxLength: 200),
                        THU_TRUONG = c.String(maxLength: 100),
                        NGUOI_LAP = c.String(maxLength: 100),
                        THU_QUY = c.String(maxLength: 100),
                        NGAY_TAO = c.DateTime(),
                        NGUOI_TAO = c.String(maxLength: 100),
                        NGAY_SUA = c.DateTime(),
                        NGUOI_SUA = c.String(maxLength: 100),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_THUYETMINHTAICHINHDETAILS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        CHITIEU = c.String(),
                        SODAUNAM = c.Decimal(precision: 18, scale: 2),
                        SOPHATSINH_TANG = c.Decimal(precision: 18, scale: 2),
                        SOPHATSINH_GIAM = c.Decimal(precision: 18, scale: 2),
                        SOCUOINAM = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_THUYETMINHTAICHINHHEADER",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        NAM = c.Decimal(precision: 10, scale: 0),
                        DIENTICH = c.Decimal(precision: 18, scale: 2),
                        DIENTICHDAT = c.Decimal(precision: 18, scale: 2),
                        DANSODEN = c.Decimal(precision: 18, scale: 2),
                        NGANHNGHE = c.String(),
                        MUCTIEUNHIEMVU = c.String(),
                        DANHGIA = c.String(),
                        NGUYENNHAN = c.String(),
                        KHACHQUAN = c.String(),
                        CHUQUAN = c.String(),
                        DENGHIKIENXUAT = c.String(),
                        TRANG_THAI = c.String(maxLength: 1),
                        CODELOCATION = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_TMTCTEMPLATE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        CHITIEU = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_CANBOTHAMGIA_DUAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DUAN = c.String(maxLength: 50),
                        MA_CANBOTHAMGIA = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_CHIPHI_DUAN_DUTOAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_QUYETDINH = c.String(nullable: false, maxLength: 50),
                        MA_DUAN = c.String(nullable: false, maxLength: 50),
                        NGAY_QUYETDINH = c.DateTime(nullable: false),
                        NGAY_CHUNGTU = c.DateTime(nullable: false),
                        DIENGIAI = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_CHITIET_CHIPHI_DUAN_DUTOAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_QUYETDINH = c.String(nullable: false, maxLength: 50),
                        MA_CONGVIEC = c.String(maxLength: 50),
                        MA_CHIPHI = c.String(maxLength: 50),
                        MA_CHIPHI_CHA = c.String(maxLength: 50),
                        MA_NGUONVON = c.String(maxLength: 50),
                        GTDT_DUYET = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GTDT_DIEUCHINH = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_CHITIET_GIAO_KEHOACH_VON",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_CHUNGTU = c.String(maxLength: 50),
                        GOI_THAU = c.String(maxLength: 50),
                        MA_HANGMUC = c.String(maxLength: 50),
                        MA_CHIPHI = c.String(maxLength: 50),
                        NGUON_VON = c.String(maxLength: 50),
                        MA_CHUONG = c.String(maxLength: 50),
                        MA_TIEUMUC = c.String(maxLength: 50),
                        DOITUONG_VON = c.String(maxLength: 50),
                        SOTIEN = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TEP_DINHKEM = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_CHITIET_HOPDONG",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_HOPDONG = c.String(nullable: false, maxLength: 50),
                        LOAI_CHIPHI = c.String(maxLength: 50),
                        CHIPHI_CHA = c.String(maxLength: 50),
                        TEN_CHIPHI = c.String(maxLength: 1000),
                        MA_HANGMUC = c.String(maxLength: 50),
                        LOAI_NGOAITE = c.String(maxLength: 50),
                        SOLUONG = c.Decimal(precision: 18, scale: 2),
                        SOTIEN_NT = c.Decimal(precision: 18, scale: 2),
                        TY_GIA = c.Decimal(precision: 18, scale: 2),
                        SOTIEN_VND = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_CHITIET_KEHOACH_VON_DAUTU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_CHUNGTU = c.String(maxLength: 50),
                        GOI_THAU = c.String(maxLength: 50),
                        NGUON_VON = c.String(maxLength: 50),
                        MA_CHUONG = c.String(maxLength: 50),
                        DACTINH_NGUON_VON = c.String(maxLength: 500),
                        DOITUONG_VON = c.String(maxLength: 50),
                        SOTIEN = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TEP_DINHKEM = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_CHITIET_QUANLY_KL_THICONG",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_KHOILUONG = c.String(maxLength: 50),
                        MA_GOITHAU = c.String(maxLength: 50),
                        MA_CHIPHI = c.String(maxLength: 50),
                        GIATIEN_TRUNGTHAU = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GIATIEN_PHIEUHOANTHANH = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FILE_DINHKEM = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_CHITIET_QUANLY_TAISAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        MA_TAISAN = c.String(maxLength: 50),
                        TEN_TAISAN = c.String(maxLength: 500),
                        DVT = c.String(maxLength: 500),
                        DONGIA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DONGIA_QUYDOI = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SOLUONG = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TONG_NGUYENGIA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TONG_NGUYENGIA_QUYDOI = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_CHITIET_KEHOACH_KETQUA",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_KEHOACH = c.String(maxLength: 50),
                        MA_GOITHAU = c.String(maxLength: 50),
                        TEN_GOITHAU = c.String(maxLength: 500),
                        MA_NGUONVON = c.String(maxLength: 50),
                        DUTOAN_DUOCDUYET = c.String(maxLength: 50),
                        MA_HINHTHUC_LUACHON_NHATHAU = c.String(maxLength: 50),
                        MA_PHUONGTHUC_LUACHON_NHATHAU = c.String(maxLength: 50),
                        MA_HIENTRANG_HOPDONG = c.String(maxLength: 50),
                        MA_LINHVUC = c.String(maxLength: 50),
                        MA_HANGMUC = c.String(),
                        KEHOACH_THOIGIAN_LUACHON = c.String(maxLength: 50),
                        KEHOACH_THOIGIAN_THUCHIEN = c.String(maxLength: 50),
                        KETQUA_THOIGIAN_LUACHON = c.String(maxLength: 50),
                        KETQUA_THOIGIAN_THUCHIEN = c.String(maxLength: 50),
                        GIA_GOITHAU_DUOCDUYET = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MA_DONVI = c.String(maxLength: 50),
                        MA_DONVI_TRUNGTHAU = c.String(maxLength: 50),
                        DC_DONVI_TRUNGTHAU = c.String(),
                        TG_BATDAU_PHATHANH_HSMQT = c.DateTime(),
                        TG_KETTHUC_PHATHANH_HSMQT = c.DateTime(),
                        DIADIEM_PHATHANH = c.String(),
                        THOIDIEM_DONGTHAU = c.DateTime(),
                        THOIDIEM_MOTHAU = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_CT_TT_DT_TMDT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_TT_DT_TMDT = c.String(maxLength: 50),
                        MA_CHIPHI = c.String(maxLength: 50),
                        TEN_CHIPHI = c.String(maxLength: 500),
                        MA_CHA = c.String(maxLength: 50),
                        CONGTHUC = c.String(),
                        LOAI_NGOAITE = c.String(maxLength: 50),
                        TIGIA = c.Double(),
                        DVT = c.String(maxLength: 50),
                        SO_LUONG = c.Decimal(precision: 18, scale: 2),
                        DONGIA_TRUOCTHUE = c.Decimal(precision: 18, scale: 2),
                        VAT = c.Double(),
                        DONGIA_SAUTHUE = c.Decimal(precision: 18, scale: 2),
                        GIATRI_TRUOCTHUE = c.Decimal(precision: 18, scale: 2),
                        GIATRI_SAUTHUE = c.Decimal(precision: 18, scale: 2),
                        GHICHU = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_CAPCONGTRINH",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CAPCONGTRINH = c.String(nullable: false, maxLength: 50),
                        TEN_CAPCONGTRINH = c.String(nullable: false, maxLength: 250),
                        TRANGTHAI = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_CHIPHI",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHIPHI = c.String(nullable: false, maxLength: 50),
                        TEN_CHIPHI = c.String(maxLength: 250),
                        MA_CHIPHI_CHA = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_CONGVIEC",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MaCongViec = c.String(maxLength: 50),
                        MaCha = c.String(maxLength: 50),
                        STT = c.String(maxLength: 50),
                        TenCongViec = c.String(maxLength: 250),
                        ThoiGian = c.Decimal(precision: 10, scale: 0),
                        TuNgay = c.DateTime(),
                        DenNgay = c.DateTime(),
                        NguoiThucHien = c.String(maxLength: 250),
                        NguoiGiamSat = c.String(maxLength: 250),
                        DonViPheDuyet = c.String(maxLength: 250),
                        VanBanDinhKem = c.String(maxLength: 500),
                        TrangThai = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_COQUANBANHANH",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_COQUANBANHANH = c.String(nullable: false, maxLength: 50),
                        TEN_COQUANBANHANH = c.String(maxLength: 500),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANGTHAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_DACTINH_NGUONVON",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DACTINH_NGUONVON = c.String(nullable: false, maxLength: 50),
                        TEN_DACTINH_NGUONVON = c.String(maxLength: 500),
                        MA_CHA = c.String(maxLength: 50),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANGTHAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_DIABAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DIABAN = c.String(nullable: false, maxLength: 50),
                        TEN_DIABAN = c.String(nullable: false, maxLength: 250),
                        TRANGTHAI = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_DOITUONGVON",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DOITUONGVON = c.String(nullable: false, maxLength: 50),
                        TEN_DOITUONGVON = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_DONVIQUANLY",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(nullable: false, maxLength: 50),
                        TEN = c.String(nullable: false, maxLength: 500),
                        MA_DVQHNS_CHA = c.String(maxLength: 50),
                        LOAI = c.String(maxLength: 8),
                        MA_CAP = c.String(maxLength: 50),
                        MA_CHUONG = c.String(maxLength: 500),
                        MA_TINH = c.String(maxLength: 50),
                        MA_HUYEN = c.String(maxLength: 50),
                        MA_XA = c.String(maxLength: 50),
                        FIELDNAME = c.String(maxLength: 8),
                        TRANGTHAI = c.String(maxLength: 1),
                        PARENTID = c.Decimal(precision: 10, scale: 0),
                        DIA_CHI = c.String(maxLength: 500),
                        SDT = c.String(maxLength: 20),
                        FAX = c.String(maxLength: 20),
                        DONVI_SUDUNG = c.Decimal(nullable: false, precision: 1, scale: 0),
                        SO_TAIKHOAN_1 = c.String(maxLength: 50),
                        SO_TAIKHOAN_2 = c.String(maxLength: 50),
                        SO_TAIKHOAN_3 = c.String(maxLength: 50),
                        MASOTHUE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_DU_AN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        CHU_DAU_TU = c.String(nullable: false, maxLength: 20),
                        DONVIQUANLY = c.String(nullable: false, maxLength: 20),
                        MA_QLNB = c.String(nullable: false, maxLength: 20),
                        MA_DUAN = c.String(nullable: false, maxLength: 20),
                        MA_DUAN_CHA = c.String(maxLength: 20),
                        LINH_VUC = c.String(nullable: false, maxLength: 20),
                        TEN_DUAN = c.String(nullable: false, maxLength: 250),
                        LOAI_DUAN = c.String(maxLength: 20),
                        NHOM_DUAN = c.String(maxLength: 20),
                        NGAY_BATDAU = c.DateTime(nullable: false),
                        NGAY_KETTHUC = c.DateTime(nullable: false),
                        SO_QD = c.String(maxLength: 20),
                        NGAY_QD = c.DateTime(nullable: false),
                        CAP_QD = c.String(maxLength: 50),
                        NGUOI_QD = c.String(maxLength: 50),
                        KHAI_TOAN_TONG = c.Double(nullable: false),
                        KINH_PHI_CHUAN_BI = c.Double(nullable: false),
                        CTMT = c.String(maxLength: 20),
                        CHUONG = c.String(maxLength: 20),
                        LOAI_KHOAN = c.String(maxLength: 20),
                        DIA_DIEM_THUC_HIEN = c.String(nullable: false, maxLength: 250),
                        DIA_DIEM_MO_TK = c.String(maxLength: 250),
                        QUY_MO = c.String(maxLength: 50),
                        TRANG_THAI_DUAN = c.String(maxLength: 20),
                        DINH_KEM = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_DUAN_VANBAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DUAN = c.String(maxLength: 50),
                        MA_VANBAN = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_GIAIDOAN_VON",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_GIAIDOAN_VON = c.String(nullable: false, maxLength: 50),
                        TEN_GIAIDOAN_VON = c.String(nullable: false, maxLength: 500),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_HIENTRANG_HOPDONG",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_HIENTRANG_HOPDONG = c.String(nullable: false, maxLength: 50),
                        TEN_HIENTRANG_HOPDONG = c.String(nullable: false, maxLength: 250),
                        TRANGTHAI = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_HINHTHUC_DUAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DUAN = c.String(nullable: false, maxLength: 50),
                        TEN_DUAN = c.String(maxLength: 500),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANGTHAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_HINHTHUC_QLDA",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_HINHTHUC = c.String(nullable: false, maxLength: 50),
                        TEN_HINHTHUC = c.String(maxLength: 500),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANGTHAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_HTLUACHON_NT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_HINHTHUC_LUACHON = c.String(nullable: false, maxLength: 50),
                        TEN_HINHTHUC_LUACHON = c.String(maxLength: 500),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANGTHAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_KHOANCHI",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_KHOANCHI = c.String(nullable: false, maxLength: 50),
                        TEN_KHOANCHI = c.String(nullable: false, maxLength: 500),
                        PHAN_LOAI = c.String(nullable: false, maxLength: 100),
                        MA_KHOANCHI_CHA = c.String(maxLength: 50),
                        LOAI_MUC_CHI = c.String(maxLength: 50),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_LINHVUC_DAUTHAU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_LINHVUC_DAUTHAU = c.String(nullable: false, maxLength: 50),
                        TEN_LINHVUC_DAUTHAU = c.String(maxLength: 500),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANGTHAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_LINHVUC",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_LINHVUC = c.String(nullable: false, maxLength: 50),
                        TEN_LINHVUC = c.String(maxLength: 500),
                        MA_LINHVUC_CHA = c.String(maxLength: 50),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANGTHAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_LOAI_KHVON",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_LOAI_KHVON = c.String(nullable: false, maxLength: 50),
                        TEN_LOAI_KHVON = c.String(nullable: false, maxLength: 500),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_LOAI_PHATSINH",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_LOAI_PHATSINH = c.String(nullable: false, maxLength: 50),
                        TEN_LOAI_PHATSINH = c.String(nullable: false, maxLength: 500),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_LOAI_VANBAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_LOAIVANBAN = c.String(nullable: false, maxLength: 50),
                        TEN_LOAIVANBAN = c.String(maxLength: 500),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_LOAIDONVI",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DONVIQUANLY = c.String(nullable: false, maxLength: 50),
                        TEN_DONVIQUANLY = c.String(nullable: false, maxLength: 500),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_LOAIDUAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_LOAIDUAN = c.String(nullable: false, maxLength: 50),
                        TEN_LOAIDUAN = c.String(nullable: false, maxLength: 500),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_LOAIHOPDONG",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_LOAIHOPDONG = c.String(nullable: false, maxLength: 50),
                        TEN_LOAIHOPDONG = c.String(nullable: false, maxLength: 250),
                        TRANGTHAI = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_NGHIEPVU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_NGHIEPVU = c.String(nullable: false, maxLength: 50),
                        TEN_NGHIEPVU = c.String(nullable: false, maxLength: 500),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_NGUON_VON",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_NGUONVON = c.String(nullable: false, maxLength: 50),
                        TEN_NGUONVON = c.String(maxLength: 500),
                        NGUONVON_CHA = c.String(maxLength: 50),
                        NHOM_NGUONVON = c.String(maxLength: 200),
                        LOAI_NGUONVON = c.String(maxLength: 200),
                        DACTINH_NGUONVON = c.String(maxLength: 50),
                        CAP_NGANSACH = c.String(maxLength: 50),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_NHATHAU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_NHATHAU = c.String(nullable: false, maxLength: 50),
                        TEN_NHATHAU = c.String(maxLength: 500),
                        DIA_CHI = c.String(maxLength: 500),
                        DIEN_THOAI = c.String(maxLength: 20),
                        FAX = c.String(maxLength: 20),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANGTHAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_NHOMDONVI",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_NHOMDONVI = c.String(nullable: false, maxLength: 50),
                        TEN_NHOMDONVI = c.String(nullable: false, maxLength: 500),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_NHOMDUAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_NHOMDUAN = c.String(nullable: false, maxLength: 50),
                        TEN_NHOMDUAN = c.String(maxLength: 500),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANGTHAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_NHOMVANBAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_NHOMVANBAN = c.String(nullable: false, maxLength: 50),
                        TEN_NHOMVANBAN = c.String(nullable: false, maxLength: 250),
                        MA_LOAIVANBAN = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_PHONGBAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_PHONGBAN = c.String(nullable: false, maxLength: 50),
                        TEN_PHONGBAN = c.String(maxLength: 500),
                        GHI_CHU = c.String(maxLength: 500),
                        MA_DVQHNS = c.String(maxLength: 20),
                        MA_DONVI = c.String(maxLength: 50),
                        USER = c.String(),
                        TRANGTHAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_PHUONGTHUC_DAUTHAU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_PHUONGTHUC = c.String(nullable: false, maxLength: 50),
                        TEN_PHUONGTHUC = c.String(maxLength: 500),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANGTHAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_SYS_LIBRARY",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_MUC = c.String(nullable: false, maxLength: 50),
                        TEN_MUC = c.String(maxLength: 250),
                        FIELD_DM = c.String(nullable: false, maxLength: 100),
                        GIA_TRI = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_TAISAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_TAISAN = c.String(nullable: false, maxLength: 50),
                        TEN_TAISAN = c.String(nullable: false, maxLength: 250),
                        DONVITINH = c.String(maxLength: 50),
                        DONGIA = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_TINHCHAT_DUAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_TINHCHAT_DUAN = c.String(nullable: false, maxLength: 50),
                        TEN_TINHCHAT_DUAN = c.String(maxLength: 500),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANGTHAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DM_TRANGTHAI_DUAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_TRANGTHAI_DUAN = c.String(nullable: false, maxLength: 50),
                        TEN_TRANGTHAI_DUAN = c.String(maxLength: 500),
                        GHI_CHU = c.String(maxLength: 500),
                        TRANGTHAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DUAN_CONGVIEC",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DUAN = c.String(maxLength: 50),
                        MA_CONGVIEC = c.String(maxLength: 50),
                        MA_CHA = c.String(maxLength: 50),
                        STT = c.String(maxLength: 50),
                        TENCONGVIEC = c.String(maxLength: 250),
                        THOIGIAN = c.Decimal(precision: 10, scale: 0),
                        TUNGAY = c.DateTime(),
                        DENNGAY = c.DateTime(),
                        NGAYCAPNHAT = c.DateTime(),
                        NGUOITHUCHIEN = c.String(maxLength: 250),
                        NGUOIGIAMSAT = c.String(maxLength: 250),
                        DONVIPHEDUYET = c.String(maxLength: 250),
                        VANBANDINHKEM = c.String(maxLength: 500),
                        TRANGTHAI = c.String(maxLength: 50),
                        GHICHU = c.String(maxLength: 300),
                        FORMNAME = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DUTOAN_DS_DUAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DUTOAN = c.String(nullable: false, maxLength: 50),
                        MA_DUAN = c.String(nullable: false, maxLength: 50),
                        MA_NGUONVON = c.String(maxLength: 50),
                        KHOAN_CHI = c.String(maxLength: 250),
                        GIAI_DOAN_VON = c.String(maxLength: 50),
                        SO_TIEN = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_DUTOAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_VANBAN = c.String(nullable: false, maxLength: 50),
                        MA_DUTOAN = c.String(nullable: false, maxLength: 50),
                        SO_QD = c.String(nullable: false, maxLength: 50),
                        NGAY_TRINH = c.DateTime(nullable: false),
                        NGAY_QD = c.DateTime(nullable: false),
                        LOAI_PHATSINH = c.String(nullable: false, maxLength: 50),
                        DIEN_GIAI = c.String(nullable: false, maxLength: 250),
                        DINH_KEM = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_GIAO_KEHOACH_VON",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        NGAY_CHUNGTU = c.DateTime(nullable: false),
                        SO_CHUNGTU = c.String(maxLength: 50),
                        MA_DUAN = c.String(maxLength: 50),
                        LOAI_DUAN = c.String(maxLength: 50),
                        DIENGIAI = c.String(maxLength: 500),
                        MA_GIAIDOAN_VON = c.String(maxLength: 50),
                        LOAI_KEHOACH_VON = c.String(maxLength: 50),
                        NAM_TAMUNG = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NAM_KEHOACHVON = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LOAI_PHIEU = c.String(maxLength: 50),
                        MA_PHONGBAN = c.String(maxLength: 100),
                        MA_DONVI = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_HOPDONG",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DUAN = c.String(nullable: false, maxLength: 50),
                        MA_GOITHAU = c.String(nullable: false, maxLength: 50),
                        MA_HOPDONG = c.String(maxLength: 50),
                        MA_NHATHAU = c.String(maxLength: 50),
                        TEN_HOPDONG = c.String(maxLength: 500),
                        SO_HOPDONG = c.String(nullable: false, maxLength: 50),
                        NGAY_BATDAU = c.DateTime(),
                        NGAY_KETTHUC = c.DateTime(),
                        SO_QUYETDINH = c.String(maxLength: 50),
                        NGAY_QUYETDINH = c.DateTime(),
                        COQUAN_QUYETDINH = c.String(maxLength: 500),
                        THOIGIAN_THUCHIEN = c.String(maxLength: 50),
                        NGAY_NGHIEMTHU = c.DateTime(),
                        NGAY_THANHLY = c.DateTime(),
                        MA_DONVI = c.String(maxLength: 50),
                        MA_PHONGBAN = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_KEHOACH_VON_DAUTU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        NGAY_CHUNGTU = c.DateTime(nullable: false),
                        SO_CHUNGTU = c.String(maxLength: 50),
                        MA_DUAN = c.String(maxLength: 50),
                        DIENGIAI = c.String(maxLength: 500),
                        MA_GIAIDOAN_VON = c.String(maxLength: 50),
                        LOAI_KEHOACH_VON = c.String(maxLength: 50),
                        NAM_DIEUCHINH = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LOAI_CHUNGTU = c.String(maxLength: 500),
                        LOAI_DUAN = c.String(maxLength: 500),
                        CHITIET_KEHOACH_VON = c.String(maxLength: 500),
                        TYPE_VB = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_KETQUA_DAUTHAU_CHITIET",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_KETQUA = c.String(maxLength: 50),
                        MA_HANGMUC = c.String(maxLength: 50),
                        MA_CHIPHI = c.String(maxLength: 200),
                        MA_CHA = c.String(maxLength: 200),
                        TEN_CHIPHI = c.String(maxLength: 1000),
                        NGOAITE_DT = c.Decimal(precision: 18, scale: 2),
                        DONGIA_DT = c.Decimal(precision: 18, scale: 2),
                        SOLUONG_DT = c.Decimal(precision: 10, scale: 0),
                        THANHTIEN_DT = c.Decimal(precision: 18, scale: 2),
                        NGOAITE_GT = c.Decimal(precision: 18, scale: 2),
                        DONGIA_GT = c.Decimal(precision: 18, scale: 2),
                        SOLUONG_GT = c.Decimal(precision: 10, scale: 0),
                        THANHTIEN_GT = c.Decimal(precision: 18, scale: 2),
                        THOIGIAN_THUCHIEN = c.Decimal(precision: 10, scale: 0),
                        THOIGIAN_LUACHON = c.Decimal(precision: 10, scale: 0),
                        LOAINGOAITE_DT = c.String(maxLength: 50),
                        LOAINGOAITE_GT = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_KETQUA_DAUTHAU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_KETQUA = c.String(maxLength: 50),
                        MA_KEHOACH = c.String(maxLength: 50),
                        MA_DUAN = c.String(maxLength: 50),
                        MA_CONGVIEC = c.String(maxLength: 50),
                        SO_PHEDUYET = c.String(maxLength: 50),
                        NGAY_PHEDUYET = c.DateTime(),
                        MA_DONVI = c.String(maxLength: 50),
                        DIACHI_DONVI = c.String(maxLength: 200),
                        HINHGTHUC_HOPDONG = c.String(maxLength: 200),
                        FILE_DINHKEM = c.String(),
                        NOI_DUNG = c.String(maxLength: 500),
                        THOIGIAN_THUCHIEN = c.Decimal(precision: 10, scale: 0),
                        THOIGIAN_LUACHON = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_KEHOACH_KETQUA",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_KEHOACH = c.String(maxLength: 50),
                        MA_DUAN = c.String(maxLength: 50),
                        SO_PHEDUYET = c.String(maxLength: 50),
                        NGAY_PHEDUYET = c.DateTime(nullable: false),
                        MA_CONGVIEC = c.String(maxLength: 50),
                        NOI_DUNG = c.String(maxLength: 500),
                        MA_VANBAN = c.String(maxLength: 50),
                        FILE_DINHKEM = c.String(),
                        MA_DONVI = c.String(maxLength: 50),
                        LOAI = c.String(maxLength: 50),
                        SO_KQ = c.Decimal(precision: 10, scale: 0),
                        GIATRI_GOITHAU = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_PHANCONG_CANBO",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DUAN = c.String(maxLength: 50),
                        SOHIEU_VANBAN = c.String(maxLength: 100),
                        CANBO_XULY = c.String(),
                        CANBO_PHOIHOP = c.String(),
                        CANBO_PHUCTRACH = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_PHULUC_HOPDONG_CHITIET",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_PHULUC_HOPDONG = c.String(maxLength: 50),
                        MA_HANGMUC = c.String(maxLength: 50),
                        MA_CHIPHI = c.String(maxLength: 200),
                        TEN_CHIPHI = c.String(maxLength: 500),
                        MA_CHA = c.String(maxLength: 200),
                        LOAI_NGOAITE = c.String(maxLength: 50),
                        SOLUONG = c.Decimal(precision: 18, scale: 2),
                        SOTIEN_NT = c.Decimal(precision: 18, scale: 2),
                        TY_GIA = c.Decimal(precision: 18, scale: 2),
                        SOTIEN_VND = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_PHULUC_HOPDONG",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_PHULUC_HOPDONG = c.String(maxLength: 50),
                        TEN_PHULUC_HOPDONG = c.String(),
                        GIATRI_HOPDONG = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GIATRI_DIEUCHINH = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NGAY_KY_PHULUC = c.DateTime(nullable: false),
                        THOIGIAN_DIEUCHINH = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_DIEUCHINH_KETTHUC = c.DateTime(nullable: false),
                        NOIDUNG_PHULUC = c.String(maxLength: 1000),
                        MA_HOPDONG = c.String(maxLength: 50),
                        NGAY_KY_HOPDONG = c.DateTime(nullable: false),
                        DONVI_THUCHIEN = c.String(maxLength: 50),
                        THOIGIAN_THUCHIEN = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_KETTHUC_HD = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_QUANLY_KL_THICONG",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_KHOILUONG = c.String(maxLength: 50),
                        TEN_KHOILUONG = c.String(),
                        NGAY_KHAIBAO = c.DateTime(nullable: false),
                        MA_GOITHAU = c.String(maxLength: 50),
                        MA_DONVI = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_QUANLY_TAISAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        NGAY_CHUNGTU = c.DateTime(),
                        NGAY_SUDUNG = c.DateTime(),
                        LOAI_TAISAN = c.String(maxLength: 500),
                        NOIDUNG = c.String(),
                        NGUONVON_DAUTU = c.String(maxLength: 50),
                        DONVI_SUDUNG = c.String(maxLength: 50),
                        MA_PHONGBAN = c.String(maxLength: 100),
                        MA_DONVI = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_QUANLY_VB_HS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DUAN = c.String(maxLength: 50),
                        MA_LOAIVANBAN = c.String(maxLength: 50),
                        MA_NHOMVANBAN = c.String(maxLength: 50),
                        MA_DONVI_GUI = c.String(maxLength: 2000),
                        MA_DONVI_NHAN = c.String(maxLength: 2000),
                        MA_HOSO = c.String(maxLength: 50),
                        SOHIEU_VANBAN = c.String(nullable: false, maxLength: 100),
                        NGAY_KY = c.DateTime(),
                        NGAY_DEN = c.DateTime(),
                        MA_CANBO = c.String(),
                        MA_CONGVIEC = c.String(),
                        TEP_DINHKEM = c.String(),
                        MA_PHONGBAN = c.String(maxLength: 100),
                        MA_DONVI_ND = c.String(maxLength: 100),
                        TYPE_VANBAN = c.String(maxLength: 50),
                        NOIDUNG = c.String(),
                        SO_DEN = c.Decimal(precision: 10, scale: 0),
                        SO_DI = c.Decimal(precision: 10, scale: 0),
                        CANBO_XULY = c.String(),
                        CANBO_PHOIHOP = c.String(),
                        CANBO_PHUCTRACH = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_THAMDINH_CHITIET",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_TOTRINH = c.String(maxLength: 50),
                        NOI_DUNG = c.String(maxLength: 300),
                        KET_QUA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        SO_BANG = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_THAMDINH",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_THAMDINH = c.String(maxLength: 50),
                        TEN_TOTRINH = c.String(maxLength: 200),
                        SO_TOTRINH = c.String(maxLength: 50),
                        MA_DUAN = c.String(maxLength: 50),
                        MA_CONGVIEC = c.String(maxLength: 50),
                        TO_CHUCTHAMDINH = c.String(maxLength: 50),
                        NGUOI_THAMQUYEN = c.String(maxLength: 50),
                        YKIEN_PHAPLY = c.String(maxLength: 500),
                        YKIEN_PCONGVIEC = c.String(maxLength: 500),
                        MA_PHONGBAN = c.String(maxLength: 100),
                        MA_DONVI = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_THONGTIN_DUAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DUAN = c.String(nullable: false, maxLength: 50),
                        MA_DUAN_CHA = c.String(maxLength: 50),
                        TOCHUC_QUANLY_DUAN = c.String(maxLength: 50),
                        TEN_DUAN = c.String(maxLength: 500),
                        CHU_DAUTU = c.String(maxLength: 50),
                        TOCHUC_LAP_DUAN = c.String(maxLength: 50),
                        CHUNHIEM_LAP_DUAN = c.String(maxLength: 500),
                        MA_HT_DUAN = c.String(maxLength: 50),
                        MA_NHOM_DUAN = c.String(maxLength: 50),
                        MA_HT_QUANLY = c.String(maxLength: 50),
                        MA_LOAI_DUAN = c.String(maxLength: 50),
                        MA_CT_MUCTIEU = c.String(maxLength: 50),
                        MA_LINHVUC = c.String(maxLength: 50),
                        NGAY_BATDAU = c.DateTime(),
                        NGAY_KETTHUC = c.DateTime(),
                        MA_CAP_CONGTRINH = c.String(maxLength: 50),
                        DIADIEM_MO_TAIKHOAN = c.String(maxLength: 500),
                        DIADIEM_XAYDUNG = c.String(maxLength: 500),
                        TONGSO_DAUTU = c.Decimal(precision: 18, scale: 2),
                        NOIDUNG = c.String(maxLength: 1000),
                        MUCTIEU_DAUTU = c.String(maxLength: 500),
                        NANGLUC_THIETKE = c.String(maxLength: 500),
                        TEP_DINHKEM = c.String(maxLength: 500),
                        GIAIDOAN = c.String(maxLength: 500),
                        MA_TC_DUAN = c.String(maxLength: 50),
                        CHUNHIEM_DUAN = c.String(maxLength: 50),
                        MA_PHONGBAN = c.String(maxLength: 100),
                        MA_DONVI = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_TOTRINH_II",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_TOTRINH = c.String(maxLength: 50),
                        GOITHAU = c.String(maxLength: 200),
                        DONVI_THUCHIEN = c.String(maxLength: 200),
                        GIA_TRI = c.Decimal(precision: 18, scale: 2),
                        VANBAN_PHEDUYET = c.String(maxLength: 200),
                        LOAI_TOTRINH = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_TOTRINH_IV",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_TOTRINH = c.String(maxLength: 50),
                        HANGMUC = c.String(maxLength: 500),
                        TEN_GOITHAU = c.String(maxLength: 200),
                        GIA_GOITHAU = c.Decimal(precision: 18, scale: 2),
                        MA_NGUONVON = c.String(maxLength: 50),
                        HINHTHUC_LUACHON_NT = c.String(maxLength: 200),
                        PHUONGTHUC_LUACHON_NT = c.String(maxLength: 200),
                        THOIGIAN_BATDAU = c.DateTime(),
                        LOAI_HOPDONG = c.String(maxLength: 50),
                        THOIGIAN_THUCHIEN = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_TOTRINH",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_TOTRINH = c.String(maxLength: 50),
                        TEN_TOTRINH = c.String(maxLength: 200),
                        MA_DUAN = c.String(maxLength: 50),
                        MA_CONGVIEC = c.String(maxLength: 50),
                        THONGTIN_KHAC = c.String(maxLength: 300),
                        MA_PHONGBAN = c.String(maxLength: 100),
                        MA_DONVI = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_TT_DT_TMDT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_TT_DT_TMDT = c.String(maxLength: 50),
                        TEN_TT_DT_TMDT = c.String(maxLength: 50),
                        LOAI_TT_DT_TMDT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DUAN = c.String(maxLength: 50),
                        MA_CONGVIEC = c.String(maxLength: 50),
                        SO_VANBAN = c.String(maxLength: 50),
                        TONGSO_DT = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_VANBAN_HSPL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DUAN = c.String(nullable: false, maxLength: 50),
                        LOAI_VANBAN = c.String(nullable: false, maxLength: 50),
                        SO_HOSO = c.String(nullable: false, maxLength: 50),
                        TEN_HOSO = c.String(nullable: false, maxLength: 250),
                        NGAY_KY = c.DateTime(nullable: false),
                        COQUAN_DUYET = c.String(nullable: false, maxLength: 250),
                        NGUOI_KY = c.String(maxLength: 100),
                        CHUC_VU = c.String(maxLength: 100),
                        TONG_GIA_TRI = c.Double(nullable: false),
                        DINH_KEM = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHE_VANBAN_PHAPQUY",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        LOAI_VANBAN = c.String(nullable: false, maxLength: 50),
                        SO_VANBAN = c.String(nullable: false, maxLength: 50),
                        TEN_VANBAN = c.String(nullable: false, maxLength: 250),
                        NGAY_BANHANH = c.DateTime(nullable: false),
                        CQBH = c.String(maxLength: 50),
                        NGUOI_KY = c.String(maxLength: 250),
                        DINH_KEM = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_01TT_CQHC",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        NOIDUNG = c.String(maxLength: 1000),
                        NAMTRUOC_LIENKE = c.String(maxLength: 1000),
                        NAMLAP_DUTOAN = c.String(maxLength: 1000),
                        NGUYENNHAN = c.String(maxLength: 1000),
                        GHICHU = c.String(maxLength: 1000),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_01TT_DVSN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DONVI = c.String(maxLength: 50),
                        THOI_KY = c.String(maxLength: 500),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        NOIDUNG_CHI = c.String(maxLength: 1000),
                        THUCTHI_NAM = c.Decimal(precision: 18, scale: 2),
                        QUYETTOAN_CHI_NAM = c.Decimal(precision: 18, scale: 2),
                        THUCTHI_DUOCGIAO = c.Decimal(precision: 18, scale: 2),
                        GHICHU = c.String(),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_01TT_NSDP",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        NOIDUNG = c.String(maxLength: 1000),
                        CONGVIEC = c.String(maxLength: 1000),
                        TRANGTHAI_TRIENKHAI = c.String(maxLength: 200),
                        VANBAN_SAIPHAM = c.String(maxLength: 500),
                        HAUQUA = c.String(maxLength: 1000),
                        NGUYENNHAN = c.String(maxLength: 1000),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_01TT_TCXD",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        TEN_THUTUC = c.String(maxLength: 1000),
                        COQUAN_DUYET = c.String(maxLength: 1000),
                        GIATRI_KHOANMUC = c.String(maxLength: 1000),
                        TRANGTHAI_THUTUC = c.String(maxLength: 1000),
                        NGUYENNHAN_THIEU = c.String(maxLength: 1000),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_02TT_CQHC",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        NOIDUNG = c.String(maxLength: 1000),
                        DUTOAN_DUOCGIAO_LK = c.String(maxLength: 1000),
                        QUYETTOANCHI_LK = c.String(maxLength: 1000),
                        DUTOAN_DONVILAP_NAM = c.String(maxLength: 1000),
                        DUTOAN_DUOCGIAO_NAM = c.String(maxLength: 1000),
                        QUYETTOANCHI_NAM = c.String(maxLength: 1000),
                        NGUYENNHAN = c.String(maxLength: 1000),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_02TT_DVSN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DONVI = c.String(maxLength: 50),
                        THOI_KY = c.String(maxLength: 500),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        NOIDUNG_CHI = c.String(maxLength: 1000),
                        THUCTHI_DUOCGIAO = c.Decimal(precision: 18, scale: 2),
                        THANHTRA_XACDINH = c.Decimal(precision: 18, scale: 2),
                        NGUYENNHAN = c.String(),
                        GHICHU = c.String(),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_02TT_NSDP",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        CHITIEU = c.String(maxLength: 1000),
                        TW_GIAO = c.String(maxLength: 500),
                        HDND_TINH_QD = c.String(maxLength: 300),
                        UBND_TINH_GIAO = c.String(maxLength: 500),
                        SS_HDNS_PHANTRAM = c.String(maxLength: 500),
                        SS_HDNS_CHENHLECH = c.String(maxLength: 500),
                        SS_UBND_PHANTRAM = c.String(maxLength: 500),
                        SS_UBND_CHENHLECH = c.String(maxLength: 500),
                        GHICHU = c.String(maxLength: 1500),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_02TT_TCXD",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        TEN_SAIPHAM = c.String(maxLength: 1000),
                        GIATRI = c.String(maxLength: 1000),
                        NGUYENNHAN = c.String(maxLength: 1000),
                        TRACHNHIEM = c.String(maxLength: 1000),
                        HAUQUA = c.String(maxLength: 1000),
                        GHICHU = c.String(maxLength: 1000),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_03TT_CQHC",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        NOIDUNG = c.String(maxLength: 1000),
                        DUTOAN_DUOCGIAO = c.String(maxLength: 1000),
                        THANHTRA_XACDINH = c.String(maxLength: 1000),
                        DUTOANGIAO_KHONGDUNG = c.String(maxLength: 500),
                        NGUYENNHAN = c.String(maxLength: 1000),
                        GHICHU = c.String(maxLength: 1000),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_03TT_DVSN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DONVI = c.String(maxLength: 50),
                        THOI_KY = c.String(maxLength: 500),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        NGUONTHU = c.String(maxLength: 1000),
                        THUCTHI_DUOCGIAO = c.Decimal(precision: 18, scale: 2),
                        THANHTRA_XACDINH = c.Decimal(precision: 18, scale: 2),
                        NGUYENNHAN = c.String(),
                        GHICHU = c.String(),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_03TT_NSDP",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        CHITIEU = c.String(maxLength: 1000),
                        TW_GIAO = c.String(maxLength: 500),
                        HDND_TINH_QD = c.String(maxLength: 300),
                        UBND_TINH_GIAO = c.String(maxLength: 500),
                        SS_HDNS_PHANTRAM = c.String(maxLength: 500),
                        SS_HDNS_CHENHLECH = c.String(maxLength: 500),
                        SS_UBND_PHANTRAM = c.String(maxLength: 500),
                        SS_UBND_CHENHLECH = c.String(maxLength: 500),
                        GHICHU = c.String(maxLength: 1500),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_03TT_TCXD",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        TEN_CHIPHI_DAUTU = c.String(maxLength: 1000),
                        VON_NSNN_KHV = c.String(maxLength: 1000),
                        VONVAY_KHV = c.String(maxLength: 1000),
                        VONKHAC_KHV = c.String(maxLength: 1000),
                        TONGCONG_KHV = c.String(maxLength: 1000),
                        VON_NSNN_GNV = c.String(maxLength: 1000),
                        VONVAY_GNV = c.String(maxLength: 1000),
                        VONKHAC_GNV = c.String(maxLength: 1000),
                        TONGCONG_GNV = c.String(maxLength: 1000),
                        VON_NSNN_TLGN = c.String(maxLength: 1000),
                        VONVAY_TLGN = c.String(maxLength: 1000),
                        VONKHAC_TLGN = c.String(maxLength: 1000),
                        TONGCONG_TLGN = c.String(maxLength: 1000),
                        NGUYENNHAN = c.String(maxLength: 1000),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_04TT_CQHC",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        NOIDUNG = c.String(maxLength: 1000),
                        CONGVIEC = c.String(maxLength: 1000),
                        TRANGTHAI_TRIENKHAI = c.String(maxLength: 200),
                        VANBAN_SAIPHAM = c.String(maxLength: 500),
                        HAUQUA = c.String(maxLength: 1000),
                        NGUYENNHAN = c.String(maxLength: 1000),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_04TT_DVSN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DONVI = c.String(maxLength: 50),
                        THOI_KY = c.String(maxLength: 500),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        NOIDUNG_THU = c.String(maxLength: 1000),
                        SOTIEN = c.Decimal(precision: 18, scale: 2),
                        NGUYENNHAN = c.String(),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_04TT_TCXD",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        TEN_THUTUC = c.String(maxLength: 1000),
                        GIATRI = c.String(maxLength: 1000),
                        NGUYENNHAN = c.String(maxLength: 1000),
                        KETQUA = c.String(maxLength: 1000),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_05TT_CQHC",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        HO_VATEN = c.String(maxLength: 1000),
                        CHI_LUONG_SCD = c.String(maxLength: 1000),
                        CHI_BHYTBHXH_SCD = c.String(maxLength: 1000),
                        CHI_THUNHAP = c.String(maxLength: 1000),
                        CHI_KHENTHUONG = c.String(maxLength: 1000),
                        CHI_KHAC = c.String(maxLength: 1000),
                        GHI_CHU = c.String(maxLength: 1000),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_05TT_DVSN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DONVI = c.String(maxLength: 50),
                        THOI_KY = c.String(maxLength: 500),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        HOTEN = c.String(maxLength: 1000),
                        CHILUONG_SAI_CHEDO = c.Decimal(precision: 18, scale: 2),
                        CHIBH_SAI_CHEDO = c.Decimal(precision: 18, scale: 2),
                        CHITN_SAI_CHEDO = c.Decimal(precision: 18, scale: 2),
                        CHI_KHAC = c.Decimal(precision: 18, scale: 2),
                        GHICHU = c.String(),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_05TT_NSDP",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        TEN_DUAN = c.String(maxLength: 1000),
                        QUYETDINH_SO = c.String(maxLength: 500),
                        QUYETDINH_NGAY = c.String(maxLength: 300),
                        TONGMUC_DAUTU = c.String(maxLength: 500),
                        THOIGIAN_KC_HT = c.String(maxLength: 500),
                        VON_DUOCGIAO = c.String(maxLength: 500),
                        BOTRI_KEHOACH_VON = c.String(maxLength: 500),
                        THUTU_UUTIEN = c.String(maxLength: 500),
                        VON_KHONGHOPLY = c.String(maxLength: 500),
                        SAIPHAM_KHAC = c.String(maxLength: 500),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_05TT_TCXD",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        TEN_DUTOAN = c.String(maxLength: 1000),
                        GIATRI = c.String(maxLength: 1000),
                        SO = c.String(maxLength: 1000),
                        NGAY = c.String(maxLength: 1000),
                        THAMQUYEN_DUYET = c.String(maxLength: 1000),
                        THUTUC_DACO = c.String(maxLength: 1000),
                        NGUYENNHAN_THIEU = c.String(maxLength: 1000),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_06TT_DVSN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DONVI = c.String(maxLength: 50),
                        THOI_KY = c.String(maxLength: 500),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        NOIDUNG_CHI = c.String(maxLength: 1000),
                        SOTIEN = c.Decimal(precision: 18, scale: 2),
                        NGUYENNHAN = c.String(),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_06TT_TCXD",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        TEN_CONGVIEC = c.String(maxLength: 1000),
                        KL_DUTOAN = c.String(maxLength: 1000),
                        KL_TINHLAI = c.String(maxLength: 1000),
                        KL_CHENHLECH = c.String(maxLength: 1000),
                        DG_DUTOAN = c.String(maxLength: 1000),
                        DG_TINHLAI = c.String(maxLength: 1000),
                        DG_CHENHLECH = c.String(maxLength: 1000),
                        DM_DUTOAN = c.String(maxLength: 1000),
                        DM_TINHLAI = c.String(maxLength: 1000),
                        DM_CHENHLECH = c.String(maxLength: 1000),
                        GIATRI_CHENHLECH = c.String(maxLength: 1000),
                        NGUYENNHAN = c.String(maxLength: 1000),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_07TT_CQHC",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        NOIDUNG_SAIPHAM = c.String(maxLength: 1000),
                        SOTIEN = c.String(maxLength: 1000),
                        TRICHSAI_TYLE = c.String(maxLength: 1000),
                        TRICHKHONG_DUNGNGUON = c.String(maxLength: 1000),
                        GHICHU = c.String(maxLength: 1000),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_07TT_DVSN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DONVI = c.String(maxLength: 50),
                        THOI_KY = c.String(maxLength: 500),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        NOIDUNG = c.String(maxLength: 1000),
                        BAOCAO_DONVI = c.Decimal(precision: 18, scale: 2),
                        THANHTRA_XACDINH = c.Decimal(precision: 18, scale: 2),
                        NGUYENNHAN = c.String(),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_07TT_TCXD",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        TEN_GOITHAU = c.String(maxLength: 1000),
                        DT_DUYET = c.String(maxLength: 1000),
                        DT_TINHLAI = c.String(maxLength: 1000),
                        GGT_DUYET = c.String(maxLength: 1000),
                        GGT_TINHLAI = c.String(maxLength: 1000),
                        GIATRI_HOPDONG = c.String(maxLength: 1000),
                        HINHTHUC_HOPDONG = c.String(maxLength: 1000),
                        GIATRI_HOPDONG_VUOTGIA = c.String(maxLength: 1000),
                        GIATRI_KHOILUONG = c.String(maxLength: 1000),
                        GIATRI_GIAINGAN = c.String(maxLength: 1000),
                        GHICHU = c.String(maxLength: 1000),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_08TT_CQHC",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        HO_VATEN = c.String(maxLength: 1000),
                        SLCDV_THUNHAP_CHIUTHUE = c.String(maxLength: 1000),
                        TTXD_THUNHAP_CHIUTHUE = c.String(maxLength: 1000),
                        SLCDV_SOTHUE_PHAINOP = c.String(maxLength: 1000),
                        TTXD_SOTHUE_PHAINOP = c.String(maxLength: 1000),
                        CL_THUNHAP_CHIUTHUE = c.String(maxLength: 1000),
                        CL_SOTHUE_PHAINOP = c.String(maxLength: 1000),
                        NGUYENNHAN = c.String(maxLength: 1000),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_08TT_DVSN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DONVI = c.String(maxLength: 50),
                        THOI_KY = c.String(maxLength: 500),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        NOIDUNG_CHI = c.String(maxLength: 1000),
                        SOTIEN = c.Decimal(precision: 18, scale: 2),
                        NGUYENNHAN = c.String(),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_08TT_TCXD",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        TEN_HANGMUC = c.String(maxLength: 1000),
                        GIATRI_HOPDONG = c.String(maxLength: 1000),
                        GIATRI_KHOILUONG = c.String(maxLength: 1000),
                        GIATRI_GIAINGAN = c.String(maxLength: 1000),
                        SOSANH_GIAINGAN_KHOILUONG = c.String(maxLength: 1000),
                        NGUYENNHAN = c.String(maxLength: 1000),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_09TT_DVSN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DONVI = c.String(maxLength: 50),
                        THOI_KY = c.String(maxLength: 500),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        HOTEN = c.String(maxLength: 1000),
                        SOLIEU_DV_CHIUTHUE = c.Decimal(precision: 18, scale: 2),
                        SOLIEU_DV_PHAINOP = c.Decimal(precision: 18, scale: 2),
                        THANHTRA_DV_CHIUTHUE = c.Decimal(precision: 18, scale: 2),
                        THANHTRA_DV_PHAINOP = c.Decimal(precision: 18, scale: 2),
                        NGUYENNHAN = c.String(),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_10TT_NSDP",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        TEN_NGUONVON = c.String(maxLength: 1000),
                        DUTOAN = c.String(maxLength: 500),
                        SO_PHANBO = c.String(maxLength: 300),
                        TONGSO_GIAINGAN = c.String(maxLength: 500),
                        TONGSO_THANHTOAN = c.String(maxLength: 500),
                        TONGSO_TAMUNG = c.String(maxLength: 500),
                        TYLE_DUTOAN = c.String(maxLength: 500),
                        TYLE_PHANBO = c.String(maxLength: 500),
                        GHICHU = c.String(maxLength: 1500),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_10TT_TCXD",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        TEN_HANGMUC = c.String(maxLength: 1000),
                        THOIGIAN_QUYETTOAN = c.String(maxLength: 1000),
                        GIATRI_DENGHI = c.String(maxLength: 1000),
                        GIATRI_XACDINH = c.String(maxLength: 1000),
                        CHENHLECH = c.String(maxLength: 1000),
                        THOIGIAN_QUYETTOAN_CHAM = c.String(maxLength: 1000),
                        NGUYENNHAN = c.String(maxLength: 1000),
                        GHICHU = c.String(maxLength: 1000),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_11TT_NSDP",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        TEN_DUAN = c.String(maxLength: 1000),
                        TONG_DUTOAN = c.String(maxLength: 500),
                        KEHOACH_VON = c.String(maxLength: 300),
                        KHOILUONG_TRONGNAM = c.String(maxLength: 500),
                        KHOILUONG_LUYKE = c.String(maxLength: 500),
                        TONGSO_TAMUNG = c.String(maxLength: 500),
                        THANHTOAN_TONGSO = c.String(maxLength: 500),
                        THANHTOAN_THANHTOAN = c.String(maxLength: 500),
                        THANHTOAN_TAMUNG = c.String(maxLength: 500),
                        LUYKE_TONGSO = c.String(maxLength: 500),
                        LUYKE_TAMUNG = c.String(maxLength: 500),
                        GIAINGAN_KHONGDUOC = c.String(maxLength: 500),
                        GIAINGAN_CHAM = c.String(maxLength: 500),
                        SAIPHAM_HOSO = c.String(maxLength: 500),
                        SAIPHAM_NGHIEMTHU = c.String(maxLength: 500),
                        SAIPHAM_THOIGIAN = c.String(maxLength: 500),
                        SAIPHAM_TAMUNG = c.String(maxLength: 500),
                        SAIPHAM_THUHOI = c.String(maxLength: 500),
                        SAIPHAM_BOSUNG = c.String(maxLength: 500),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_12TT_NSDP",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        DUAN = c.String(maxLength: 1000),
                        CHUDAUTU = c.String(maxLength: 500),
                        THOIDIEM_KHOICONG = c.String(maxLength: 300),
                        THOIGIAN_HOANTHANH = c.String(maxLength: 500),
                        GIATRI_HOPDONG = c.String(maxLength: 500),
                        GIATRI_NGHIEMTHU = c.String(maxLength: 500),
                        GIATRI_DUOC_THANHTOAN = c.String(maxLength: 500),
                        GIATRI_CHUA_THANHTOAN = c.String(maxLength: 500),
                        NGUYENNHAN = c.String(maxLength: 1500),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_14TT_NSDP",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        TEN_DUAN = c.String(maxLength: 1000),
                        DUAN_DAUTU = c.String(maxLength: 500),
                        DUAN_DUTOAN = c.String(maxLength: 300),
                        THOIGIAN_HOANTHANH = c.String(maxLength: 500),
                        THOIGIAN_KHOICONG = c.String(maxLength: 500),
                        PHATHIEN_SAIPHAM = c.String(maxLength: 500),
                        PHATHIEN_SOTIEN = c.String(maxLength: 500),
                        KIENNGHI_NOIDUNG = c.String(maxLength: 500),
                        KIENNGHI_SOTIEN = c.String(maxLength: 500),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_15TT_NSDP",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        TEN_DONVI = c.String(maxLength: 1000),
                        NOIDUNG_HOTRO = c.String(maxLength: 500),
                        DUTOAN = c.String(maxLength: 300),
                        THUCHIEN = c.String(maxLength: 500),
                        TYLE_DUTOAN = c.String(maxLength: 500),
                        KHUYETDIEM_NOIDUNG = c.String(maxLength: 500),
                        KHUYETDIEM_HOSO = c.String(maxLength: 500),
                        KHUYETDIEM_QUYETTOAN = c.String(maxLength: 500),
                        KHUYETDIEM_BOSUNG = c.String(maxLength: 500),
                        NGUYENNHAN = c.String(maxLength: 1500),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_16TT_NSDP",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        DOITUONG = c.String(maxLength: 1000),
                        NOIDUNG = c.String(maxLength: 500),
                        NOIDUNG_SOTIEN = c.String(maxLength: 500),
                        NGUYENNHAN = c.String(maxLength: 500),
                        GHICHU = c.String(maxLength: 1000),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_60TT_NSDVN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        STT = c.Decimal(nullable: false, precision: 10, scale: 0),
                        STT_TIEUDE = c.String(maxLength: 5),
                        STT_CHA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        NOIDUNG = c.String(maxLength: 1000),
                        CONGVIEC = c.String(maxLength: 1000),
                        TRANGTHAI_TRIENKHAI = c.String(maxLength: 200),
                        VANBAN_SAIPHAM = c.String(maxLength: 500),
                        HAUQUA = c.String(maxLength: 1000),
                        NGUYENNHAN = c.String(maxLength: 1000),
                        IS_BOLD = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IS_ITALIC = c.Decimal(nullable: false, precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_FILE_CQHC",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        TEN_FILE = c.String(maxLength: 250),
                        NAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DOT = c.String(maxLength: 50),
                        THOIGIAN = c.String(maxLength: 30),
                        TEN_BIEUMAU = c.String(maxLength: 200),
                        TIEUDE_BIEUMAU = c.String(maxLength: 500),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_FILE_DVSN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        TEN_FILE = c.String(maxLength: 250),
                        NAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DOT = c.String(maxLength: 50),
                        THOIGIAN = c.String(maxLength: 30),
                        TEN_BIEUMAU = c.String(maxLength: 200),
                        TIEUDE_BIEUMAU = c.String(maxLength: 500),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_FILE_NSDP",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        TEN_FILE = c.String(maxLength: 250),
                        NAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DOT = c.String(maxLength: 50),
                        THOIGIAN = c.String(maxLength: 30),
                        TEN_BIEUMAU = c.String(maxLength: 200),
                        TIEUDE_BIEUMAU = c.String(maxLength: 500),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_FILE_NSDVN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        TEN_FILE = c.String(maxLength: 250),
                        NAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DOT = c.String(maxLength: 50),
                        THOIGIAN = c.String(maxLength: 30),
                        TEN_BIEUMAU = c.String(maxLength: 200),
                        TIEUDE_BIEUMAU = c.String(maxLength: 500),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_BM_FILE_TCXD",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_FILE = c.String(maxLength: 200),
                        MA_FILE_PK = c.String(maxLength: 200),
                        TEN_FILE = c.String(maxLength: 250),
                        NAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DOT = c.String(maxLength: 50),
                        THOIGIAN = c.String(maxLength: 30),
                        TEN_BIEUMAU = c.String(maxLength: 200),
                        TIEUDE_BIEUMAU = c.String(maxLength: 500),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_DM_CANBO",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CANBO = c.String(nullable: false, maxLength: 50),
                        TEN_CANBO = c.String(nullable: false, maxLength: 500),
                        TRANG_THAI = c.Decimal(precision: 10, scale: 0),
                        MA_PHONG = c.String(maxLength: 50),
                        MA_CHUCVU = c.String(maxLength: 50),
                        GIOI_TINH = c.Decimal(precision: 10, scale: 0),
                        NGAY_SINH = c.DateTime(),
                        SO_PHONG = c.String(maxLength: 50),
                        SO_MAY_LE = c.String(maxLength: 50),
                        SO_DI_DONG = c.String(maxLength: 50),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_DM_DOITUONG",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DOITUONG = c.String(nullable: false, maxLength: 50),
                        TEN_DOITUONG = c.String(nullable: false, maxLength: 500),
                        NAM = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DVQHNS = c.String(maxLength: 50),
                        TRANG_THAI = c.Decimal(precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_DM_DONVI_PHONGBAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(nullable: false, maxLength: 50),
                        MA_CHA = c.String(maxLength: 50),
                        TEN = c.String(nullable: false, maxLength: 500),
                        MA_DVQHNS = c.String(maxLength: 50),
                        LOAI = c.String(maxLength: 8),
                        FIELDNAME = c.String(maxLength: 8),
                        TRANGTHAI = c.Decimal(precision: 10, scale: 0),
                        MADONVI = c.String(maxLength: 50),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_DM_DOTTHANHTRA",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DOT = c.String(nullable: false, maxLength: 50),
                        TEN_DOT = c.String(nullable: false, maxLength: 500),
                        TU_NGAY = c.DateTime(),
                        DEN_NGAY = c.DateTime(),
                        TRANG_THAI = c.Decimal(precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_DM_TAOMA",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        LOAIMA = c.String(maxLength: 50),
                        MA = c.String(maxLength: 50),
                        HIENTAI = c.String(maxLength: 10),
                        MADONVI = c.String(maxLength: 50),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_KH_THANHTRA_COQUAN_CT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_PHIEU = c.String(maxLength: 50),
                        LOAI_THANHTRA = c.String(maxLength: 50),
                        NHOM_THANHTRA = c.String(maxLength: 50),
                        DOITUONG_THANHTRA = c.String(maxLength: 50),
                        COQUAN_THANHTRA = c.String(maxLength: 50),
                        NOIDUNG_THANHTRA = c.String(maxLength: 1000),
                        THOIKY_THANHTRA = c.String(maxLength: 1000),
                        TEP_DINHKEM = c.String(maxLength: 1000),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_KH_THANHTRA_COQUAN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_PHIEU = c.String(nullable: false, maxLength: 50),
                        NGAYTHANG_LUUTRU = c.DateTime(),
                        NOIDUNG = c.String(maxLength: 1000),
                        DOT_THANHTRA = c.String(maxLength: 50),
                        NAM_THANHTRA = c.Decimal(precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_QD_GIAOTHUCHIEN_THANHTRA",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_QUYETDINH = c.String(nullable: false, maxLength: 50),
                        NAM_THANHTRA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_QUYETDINH = c.DateTime(nullable: false),
                        QD_GIAOTHUCHIEN_THANHTRA = c.String(maxLength: 50),
                        DOT_THANHTRA = c.String(maxLength: 100),
                        FILE_DINHKEM = c.String(maxLength: 1000),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_QD_GIAOTHUCHIEN_TT_THUOCBO",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_QUYETDINH = c.String(nullable: false, maxLength: 50),
                        NAM_THANHTRA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        DOT_THANHTRA = c.String(maxLength: 100),
                        NGAY_QUYETDINH = c.DateTime(nullable: false),
                        MA_DONVI = c.String(maxLength: 50),
                        FILE_DINHKEM = c.String(maxLength: 1000),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_QD_PHEDUYET_THANHTRA",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_QUYETDINH = c.String(nullable: false, maxLength: 50),
                        NAM_THANHTRA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        DOT_THANHTRA = c.String(maxLength: 100),
                        NGAY_QUYETDINH = c.DateTime(nullable: false),
                        FILE_DINHKEM = c.String(maxLength: 1000),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_SOANTHAO_THANHTRA_CT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_PHIEU = c.String(nullable: false, maxLength: 50),
                        LOAI_TT = c.String(maxLength: 50),
                        NHOM_TT = c.String(maxLength: 50),
                        DOI_TUONG_TT = c.String(maxLength: 50),
                        COQUAN_TT = c.String(maxLength: 50),
                        NOIDUNG_THANHTRA = c.String(maxLength: 1000),
                        THOIKY_TT = c.String(maxLength: 50),
                        TEP_DINHKEM = c.String(maxLength: 1000),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_SOANTHAO_THANHTRA",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_PHIEU = c.String(nullable: false, maxLength: 50),
                        NAM_THANHTRA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DOITUONG_TT = c.String(maxLength: 50),
                        MA_PHONGBAN = c.String(maxLength: 50),
                        NOI_DUNG = c.String(maxLength: 500),
                        DOT_THANHTRA = c.String(maxLength: 50),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_SYS_TUDIEN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_TUDIEN = c.String(nullable: false, maxLength: 50),
                        MA_TUDIEN_CHA = c.String(maxLength: 50),
                        TEN_TUDIEN = c.String(nullable: false, maxLength: 500),
                        LOAI_TUDIEN = c.String(nullable: false, maxLength: 50),
                        TRANG_THAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DONVI = c.String(maxLength: 50),
                        MA_PHONGBAN = c.String(maxLength: 50),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_THEODOI_CANBO_CT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_PHIEU = c.String(maxLength: 50),
                        TEN_CANBO = c.String(maxLength: 500),
                        CHUCVU = c.String(maxLength: 500),
                        GIOI_TINH = c.Decimal(precision: 10, scale: 0),
                        NGAY_SINH = c.DateTime(),
                        PHONGBAN = c.String(maxLength: 500),
                        SO_MAY_LE = c.String(maxLength: 50),
                        SO_DI_DONG = c.String(maxLength: 50),
                        TEN_DOT_THANHTRA = c.String(maxLength: 500),
                        SO_QUYETDINH = c.String(maxLength: 50),
                        STT = c.Decimal(precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_THEODOI_CANBO",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_PHIEU = c.String(nullable: false, maxLength: 50),
                        TEN_PHIEU = c.String(maxLength: 500),
                        MA_DOITUONG = c.String(maxLength: 50),
                        MA_PHONGBAN = c.String(maxLength: 50),
                        NAM_THANHTRA = c.Decimal(precision: 10, scale: 0),
                        DOT_THANHTRA = c.String(maxLength: 50),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_THUMUC_FILE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        TEN_FILE = c.String(maxLength: 250),
                        TIEU_DE = c.String(maxLength: 50),
                        SO_PHIEU = c.String(maxLength: 50),
                        URL = c.String(maxLength: 250),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_TIENDO_THUCHIEN_KH_CT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_PHIEU = c.String(nullable: false, maxLength: 50),
                        DOI_TUONG_TT = c.String(maxLength: 50),
                        KE_HOACH_TT = c.String(maxLength: 50),
                        LOAI_TT = c.String(maxLength: 50),
                        NHOM_TT = c.String(maxLength: 50),
                        PHONG_TT = c.String(maxLength: 50),
                        TRUONGDOAN_TT = c.String(maxLength: 50),
                        THANHVIEN_DOAN = c.String(maxLength: 500),
                        SO_NGAY_THANG_QG = c.String(maxLength: 50),
                        THOIHAN_TT = c.String(maxLength: 50),
                        NGAY_TRIENKHAI = c.DateTime(),
                        NGAY_KETTHUC = c.DateTime(),
                        GIAMSAT_DOAN = c.String(maxLength: 50),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_TIENDO_THUCHIEN_KH",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_PHIEU = c.String(nullable: false, maxLength: 50),
                        NAM_THANHTRA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DOITUONG_TT = c.String(maxLength: 50),
                        MA_PHONGBAN = c.String(maxLength: 50),
                        MA_DOT = c.String(maxLength: 50),
                        NOI_DUNG = c.String(maxLength: 500),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_TTB_NHATKY",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SO_PHIEU = c.String(maxLength: 50),
                        NGAY_LUUTRU = c.DateTime(),
                        MA_DOITUONG = c.String(maxLength: 50),
                        NGUOI_BAOCAO = c.String(maxLength: 50),
                        MA_PHONGBAN = c.String(maxLength: 50),
                        MA_DOT = c.String(maxLength: 50),
                        NOIDUNG_BAOCAO = c.String(maxLength: 50),
                        TRANG_THAI = c.Decimal(precision: 10, scale: 0),
                        NAM = c.Decimal(precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_XD_KH_THANHTRA_BO_CHITIET",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_PHIEU = c.String(maxLength: 50),
                        KEHOACH_THANHTRA = c.String(maxLength: 50),
                        LOAI_THANHTRA = c.String(maxLength: 50),
                        NHOM_THANHTRA = c.String(maxLength: 50),
                        PHONG_THANHTRA = c.String(maxLength: 50),
                        DOITUONG_THANHTRA = c.String(maxLength: 50),
                        LYDO_THANHTRA = c.String(maxLength: 1000),
                        MA_DOITUONG = c.String(maxLength: 50),
                        MA_DOITUONG_CHA = c.String(maxLength: 50),
                        TEN_DOITUONG = c.String(maxLength: 500),
                        PHONG_CHUTRI = c.String(maxLength: 50),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_XD_KH_THANHTRA_BO",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_PHIEU = c.String(nullable: false, maxLength: 50),
                        NGAY_LAPPHIEU = c.DateTime(),
                        NOIDUNG = c.String(maxLength: 1000),
                        MA_DOITUONG = c.String(maxLength: 50),
                        MA_PHONGBAN = c.String(maxLength: 50),
                        DOT_THANHTRA = c.String(maxLength: 50),
                        NAM = c.Decimal(precision: 10, scale: 0),
                        TUNGAY = c.DateTime(),
                        DENNGAY = c.DateTime(),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_XD_KH_TT_THUOC_BO_CT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_PHIEU = c.String(nullable: false, maxLength: 50),
                        LOAI_THANHTRA = c.String(maxLength: 50),
                        NHOM_THANHTRA = c.String(maxLength: 50),
                        DOITUONG_THANHTRA = c.String(maxLength: 50),
                        COQUAN_THANHTRA = c.String(maxLength: 50),
                        NOIDUNG_THANHTRA = c.String(maxLength: 200),
                        THOIKY_THANHTRA = c.String(maxLength: 200),
                        TEP_DINHKEM = c.String(maxLength: 300),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_XD_KH_TT_THUOC_BO",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_PHIEU = c.String(nullable: false, maxLength: 50),
                        NGAY_LUU_DL = c.DateTime(),
                        MA_DOITUONG = c.String(maxLength: 50),
                        MA_PHONGBAN = c.String(maxLength: 50),
                        DOT_THANHTRA = c.String(maxLength: 50),
                        NAM_THANHTRA = c.Decimal(precision: 10, scale: 0),
                        NOI_DUNG = c.String(maxLength: 500),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_QTXDCB_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        TENCONGTRINH = c.String(nullable: false, maxLength: 1000),
                        THOIGIAN = c.String(maxLength: 200),
                        ISSTYLE = c.Decimal(precision: 1, scale: 0),
                        DISABLE_ADD = c.Decimal(precision: 1, scale: 0),
                        KEY = c.String(maxLength: 1000),
                        DUOCDUYET_TONGSO = c.Decimal(precision: 18, scale: 2),
                        DUOCDUYET_NGUONDONGGOP = c.Decimal(precision: 18, scale: 2),
                        GIATRI_THUCHIEN = c.Decimal(precision: 18, scale: 2),
                        THANHTOAN_TONGSO = c.Decimal(precision: 18, scale: 2),
                        THANHTOAN_KHOILUONG = c.Decimal(precision: 18, scale: 2),
                        THANHTOAN_NGUONCANDOI = c.Decimal(precision: 18, scale: 2),
                        THANHTOAN_NGUONDONGGOP = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_QTXDCB_HEADER",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        TUNGAY = c.DateTime(),
                        DENNGAY = c.DateTime(),
                        TRANG_THAI = c.String(maxLength: 1),
                        TINH = c.String(maxLength: 200),
                        HUYEN = c.String(maxLength: 200),
                        XA = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_S16_X_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        TENHO = c.String(nullable: false, maxLength: 500),
                        DIACHI = c.String(maxLength: 1000),
                        SOPHAITHU_NAMTRUOC = c.Decimal(precision: 18, scale: 2),
                        THUNAMNAY_SL1 = c.Decimal(precision: 18, scale: 2),
                        THUNAMNAY_GT1 = c.Decimal(precision: 18, scale: 2),
                        THUNAMNAY_SL2 = c.Decimal(precision: 18, scale: 2),
                        THUNAMNAY_GT2 = c.Decimal(precision: 18, scale: 2),
                        THUNAMNAY_CONGPHAITHU = c.Decimal(precision: 18, scale: 2),
                        SUM_SPNOP_NAMNAY = c.Decimal(precision: 18, scale: 2),
                        DANOP_VU1 = c.Decimal(precision: 18, scale: 2),
                        DANOP_VU2 = c.Decimal(precision: 18, scale: 2),
                        DANOP_CONGSO = c.Decimal(precision: 18, scale: 2),
                        SOCONNO_NAMSAU = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_S16_X_HEADER",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        TUNGAY = c.DateTime(),
                        DENNGAY = c.DateTime(),
                        TRANG_THAI = c.String(maxLength: 1),
                        HUYEN = c.String(maxLength: 200),
                        XA = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_S17_X_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        NGAY_CT = c.DateTime(),
                        SOHIEU = c.String(maxLength: 50),
                        DIENGIAI = c.String(maxLength: 1000),
                        DONVITINH = c.String(maxLength: 50),
                        SERIAL = c.String(maxLength: 50),
                        QUYENSO = c.String(maxLength: 100),
                        TUSO = c.Decimal(precision: 18, scale: 2),
                        DENSO = c.Decimal(precision: 18, scale: 2),
                        SOLINH = c.Decimal(precision: 18, scale: 2),
                        THANHTOAN_CONG = c.Decimal(precision: 18, scale: 2),
                        THANHTOAN_SOLUONGDUNG = c.Decimal(precision: 18, scale: 2),
                        THANHTOAN_TRALAI = c.Decimal(precision: 18, scale: 2),
                        THANHTOAN_TONTHAT = c.Decimal(precision: 18, scale: 2),
                        THANHTOAN_XOABO = c.Decimal(precision: 18, scale: 2),
                        THANHTOAN_SODATHU = c.Decimal(precision: 18, scale: 2),
                        THANHTOAN_SODANOP = c.Decimal(precision: 18, scale: 2),
                        BIENLAICONLAI_TUSO = c.Decimal(precision: 18, scale: 2),
                        BIENLAICONLAI_DENSO = c.Decimal(precision: 18, scale: 2),
                        BIENLAICONLAI_TTCHUATT = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHC_S17_X_HEADER",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        SO_CHUNGTU = c.String(nullable: false, maxLength: 50),
                        TUNGAY = c.DateTime(),
                        DENNGAY = c.DateTime(),
                        TRANG_THAI = c.String(maxLength: 1),
                        HUYEN = c.String(maxLength: 200),
                        XA = c.String(maxLength: 200),
                        NAM = c.Decimal(precision: 10, scale: 0),
                        DONVITHU = c.String(maxLength: 500),
                        CANBO = c.String(maxLength: 200),
                        TENBIENLAI = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.SYS_CHUCNANG",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PHANHE = c.String(nullable: false, maxLength: 50),
                        MACHUCNANG = c.String(nullable: false, maxLength: 30),
                        TENCHUCNANG = c.String(maxLength: 300),
                        MACHA = c.String(maxLength: 30),
                        STATE = c.String(maxLength: 100),
                        SOTHUTU = c.String(maxLength: 50),
                        TRANGTHAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.SYS_DONVI",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(maxLength: 30),
                        TEN = c.String(maxLength: 500),
                        MA_DVSDNS = c.String(maxLength: 50),
                        LOAI = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ID_CAPTREN = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_DIABAN = c.String(maxLength: 50),
                        MA_CAPTREN = c.String(maxLength: 50),
                        MA_DTNT = c.String(maxLength: 50),
                        MA_T = c.String(maxLength: 50),
                        MA_H = c.String(maxLength: 50),
                        MA_X = c.String(maxLength: 50),
                        VALID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NGAY_PS = c.DateTime(nullable: false),
                        NGAY_SD = c.DateTime(),
                        NGAY_HL = c.DateTime(),
                        NGAY_KT = c.DateTime(),
                        USER_NAME = c.String(maxLength: 20),
                        CAN_CU = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.SYS_DVQHNS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_DVQHNS = c.String(maxLength: 20),
                        TEN_DVQHNS = c.String(maxLength: 240),
                        NGAY_HL = c.DateTime(),
                        NGAY_HET_HL = c.DateTime(),
                        MA_DVQHNS_CHA = c.String(maxLength: 20),
                        TYPE_DVQHNS = c.String(maxLength: 2),
                        MA_LOAIDV = c.String(maxLength: 2),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                        MA_CAP = c.String(maxLength: 1),
                        MA_CHUONG = c.String(maxLength: 3),
                        MA_TINH = c.String(maxLength: 2),
                        MA_XA = c.String(maxLength: 5),
                        MA_HUYEN = c.String(maxLength: 3),
                        CAN_CU = c.String(maxLength: 100),
                        TRANG_THAI = c.String(maxLength: 1),
                        USER_NAME = c.String(maxLength: 20),
                        MA_DA_DP = c.String(maxLength: 9),
                        MA_NHOM_DA = c.String(maxLength: 9),
                        TEN_NHOM_DA = c.String(maxLength: 2000),
                        MA_NKT = c.String(maxLength: 2000),
                        MA_CTMT = c.String(maxLength: 2000),
                        MA_DON_VI = c.String(maxLength: 9),
                        SHKB = c.String(maxLength: 9),
                        NGUON_DL = c.String(maxLength: 9),
                        TINH_TRANG = c.String(maxLength: 9),
                        TM_DTU = c.Decimal(precision: 18, scale: 2),
                        NGAY_KC = c.DateTime(),
                        NGAY_HT = c.DateTime(),
                        CAP_QLY = c.String(maxLength: 9),
                        TRD_TPCP = c.Decimal(precision: 18, scale: 2),
                        NGAY_TAO = c.DateTime(),
                        NGUOI_TAO = c.String(maxLength: 50),
                        NGUOI_QLY = c.String(maxLength: 50),
                        CAP_NS = c.String(maxLength: 9),
                        TEN_DA_DP = c.String(maxLength: 500),
                        NGAY_CHUYEN_DOI = c.DateTime(),
                        MA_BQLDA = c.String(maxLength: 500),
                        CQUAN_TLAP = c.String(maxLength: 9),
                        NVU_THIEN = c.String(maxLength: 9),
                        TRD_NSNN = c.Decimal(precision: 18, scale: 2),
                        TRD_ODA = c.Decimal(precision: 18, scale: 2),
                        MA_NTT = c.String(maxLength: 200),
                        CHUDAUTU = c.String(maxLength: 200),
                        SO_QD = c.String(maxLength: 20),
                        NGAY_QD = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.SYS_THAMSO_HETHONG",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(maxLength: 20),
                        TEN_THAMSO = c.String(maxLength: 500),
                        GIA_TRI = c.String(maxLength: 500),
                        THAYDOI = c.Decimal(precision: 18, scale: 2),
                        KIEU_DULIEU = c.Decimal(precision: 18, scale: 2),
                        LOAI_THAMSO = c.Decimal(precision: 18, scale: 2),
                        GHI_CHU = c.String(maxLength: 250),
                        MA_CHA = c.String(maxLength: 20),
                        SORT = c.Decimal(precision: 10, scale: 0),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.SYS_TONGHOPDL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        LOAI_DULIEU = c.String(maxLength: 20),
                        SO_BANGHI = c.Decimal(precision: 19, scale: 0),
                        TU_NGAY = c.DateTime(),
                        DEN_NGAY = c.DateTime(),
                        NGAY_TONGHOP = c.DateTime(),
                        NGUOI_TONGHOP = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.SYS_TUDIEN",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        FIELDNAME = c.String(maxLength: 20),
                        MA_TUDIEN = c.String(maxLength: 6),
                        NGAY_HL = c.DateTime(),
                        NGAY_HET_HL = c.DateTime(),
                        TRANG_THAI = c.String(maxLength: 1),
                        MO_TA = c.String(maxLength: 2000),
                        USER_NAME = c.String(maxLength: 20),
                        NGAY_PS = c.DateTime(),
                        NGAY_SD = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.SYS_USER",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        USER_NAME = c.String(maxLength: 30),
                        PASSWORD = c.String(maxLength: 500),
                        FULLNAME = c.String(maxLength: 500),
                        EMAIL = c.String(maxLength: 500),
                        PHONE = c.String(maxLength: 20),
                        MA_DV_TKKHOBAC = c.String(maxLength: 500),
                        CHUC_VU = c.String(maxLength: 500),
                        MA_PHONGBAN = c.String(maxLength: 50),
                        MA_DVQHNS = c.String(maxLength: 50),
                        MA_DVQHNS_CHA = c.String(maxLength: 50),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.TABWH_JEL_FCT_V2",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA_QUY = c.String(maxLength: 200),
                        MA_TKTN = c.String(maxLength: 200),
                        MA_TIEUMUC = c.String(maxLength: 200),
                        MA_CAP = c.String(maxLength: 200),
                        MA_DVQHNS = c.String(maxLength: 200),
                        MA_DIABAN = c.String(maxLength: 200),
                        MA_CHUONG = c.String(maxLength: 200),
                        MA_KHOAN = c.String(maxLength: 200),
                        MA_CTMTQG = c.String(maxLength: 200),
                        MA_KBNN = c.String(maxLength: 200),
                        MA_NGUONNS = c.String(maxLength: 200),
                        NGAY_KET_SO = c.DateTime(),
                        NGAY_HIEU_LUC = c.DateTime(),
                        DP = c.String(maxLength: 200),
                        DU_DAU = c.Decimal(precision: 18, scale: 2),
                        DU_CUOI = c.Decimal(precision: 18, scale: 2),
                        PS_NO = c.Decimal(precision: 18, scale: 2),
                        PS_CO = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.TCS_DM_COQUANTHU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(nullable: false, maxLength: 20),
                        TEN = c.String(maxLength: 500),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.TCS_DM_DOITUONGNOPTHUE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(nullable: false, maxLength: 20),
                        TEN = c.String(maxLength: 500),
                        CQTC_MA = c.String(maxLength: 20),
                        DIACHI = c.String(maxLength: 500),
                        CAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CHUONG = c.String(maxLength: 3),
                        LOAI = c.String(maxLength: 3),
                        KHOAN = c.String(maxLength: 3),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.TCS_DM_TYLEDIEUTIET",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MA = c.String(nullable: false, maxLength: 20),
                        TYLE_DIEUTIET = c.String(maxLength: 30),
                        TRANG_THAI = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.TDL_SOLIEU",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SHKB = c.String(maxLength: 20),
                        SHKB_NV = c.String(maxLength: 20),
                        NIEN_DO_KH = c.Decimal(precision: 18, scale: 2),
                        NAM_KH = c.Decimal(precision: 18, scale: 2),
                        SO_HIEU_KY = c.Decimal(precision: 18, scale: 2),
                        MA_DA = c.String(maxLength: 50),
                        TEN_DU_AN = c.String(maxLength: 500),
                        MA_NHOM_DA = c.String(maxLength: 3),
                        TEN_NHOM_DA = c.String(maxLength: 200),
                        MA_DA_DP = c.String(maxLength: 9),
                        TEN_DA_DP = c.String(maxLength: 200),
                        MA_DON_VI = c.String(maxLength: 6),
                        TEN_DON_VI = c.String(maxLength: 300),
                        MA_LOAI_KHV = c.String(maxLength: 1),
                        TEN_LOAI_KHV = c.String(maxLength: 300),
                        MA_NHOM_NV = c.String(maxLength: 20),
                        MA_NVON = c.String(maxLength: 8),
                        TEN_NVON = c.String(maxLength: 500),
                        MA_LV_DA = c.String(maxLength: 20),
                        TEN_LV_DA = c.String(maxLength: 500),
                        MA_LOAI_VON = c.String(maxLength: 20),
                        TEN_LOAI_VON = c.String(maxLength: 500),
                        MA_CHUONG = c.String(maxLength: 20),
                        TEN_CHUONG = c.String(maxLength: 500),
                        CAP_QLY = c.String(maxLength: 20),
                        MA_NKT = c.String(maxLength: 20),
                        TEN_NKT = c.String(maxLength: 500),
                        MA_CTMT = c.String(maxLength: 20),
                        TEN_CTMT = c.String(maxLength: 500),
                        CHI = c.String(maxLength: 20),
                        KEO_DAI = c.String(maxLength: 20),
                        KHV = c.Decimal(precision: 18, scale: 2),
                        CDT_DN_TTOAN = c.Decimal(precision: 18, scale: 2),
                        TAM_UNG = c.Decimal(precision: 18, scale: 2),
                        TTKLHT = c.Decimal(precision: 18, scale: 2),
                        DU_TAM_UNG = c.Decimal(precision: 18, scale: 2),
                        THU_HOI_TAM_UNG = c.Decimal(precision: 18, scale: 2),
                        KH_UNG_TRUOC = c.Decimal(precision: 18, scale: 2),
                        MDB_TINH = c.String(maxLength: 50),
                        NGUOI_CAP_NHAT = c.String(maxLength: 50),
                        NGAY_CAP_NHAT = c.DateTime(),
                        GHI_CHU = c.String(maxLength: 500),
                        TTHAI_KX = c.String(maxLength: 20),
                        NGAY_DIEU_CHINH = c.DateTime(),
                        NGUOI_DIEU_CHINH = c.String(maxLength: 20),
                        TRANG_THAI_DIEU_CHINH = c.String(maxLength: 20),
                        SHKB_PAR = c.String(maxLength: 20),
                        QDINH_HOANTHANH = c.String(maxLength: 200),
                        TT_LANCUOI = c.String(maxLength: 20),
                        TTHAI_KETDU = c.String(maxLength: 20),
                        USER_KETDU = c.String(maxLength: 200),
                        NGAY_KETDU = c.DateTime(),
                        GIAM_TTKLHT = c.Decimal(precision: 18, scale: 2),
                        GIAM_TAM_UNG = c.Decimal(precision: 18, scale: 2),
                        NGUON_DL = c.String(maxLength: 20),
                        MA_NDKT = c.String(maxLength: 20),
                        PKG_ID = c.Decimal(precision: 18, scale: 2),
                        LOAI_DU_LIEU = c.String(maxLength: 20),
                        NGUOI_CHUYEN_DOI = c.String(maxLength: 20),
                        TH_GIAI_NGAN = c.String(maxLength: 300),
                        TCHOI_TTOAN = c.Decimal(precision: 18, scale: 2),
                        THUC_TCHOI_TTOAN = c.Decimal(precision: 18, scale: 2),
                        LDO_TCHOI = c.String(maxLength: 300),
                        NGAY_NHAP = c.DateTime(),
                        TTHAI_GUI = c.String(maxLength: 20),
                        TTHAI_KSOAT = c.String(maxLength: 20),
                        MA_BQLDA = c.String(maxLength: 20),
                        NGUOI_KSOAT = c.String(maxLength: 20),
                        NGAY_KSOAT = c.DateTime(),
                        NGUOI_HUYKS = c.String(maxLength: 20),
                        NGAY_HUYKS = c.DateTime(),
                        NGAY_CHUYEN_DOI = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("BTSTC.TDL_SOLIEU");
            DropTable("BTSTC.TCS_DM_TYLEDIEUTIET");
            DropTable("BTSTC.TCS_DM_DOITUONGNOPTHUE");
            DropTable("BTSTC.TCS_DM_COQUANTHU");
            DropTable("BTSTC.TABWH_JEL_FCT_V2");
            DropTable("BTSTC.SYS_USER");
            DropTable("BTSTC.SYS_TUDIEN");
            DropTable("BTSTC.SYS_TONGHOPDL");
            DropTable("BTSTC.SYS_THAMSO_HETHONG");
            DropTable("BTSTC.SYS_DVQHNS");
            DropTable("BTSTC.SYS_DONVI");
            DropTable("BTSTC.SYS_CHUCNANG");
            DropTable("BTSTC.PHC_S17_X_HEADER");
            DropTable("BTSTC.PHC_S17_X_DETAIL");
            DropTable("BTSTC.PHC_S16_X_HEADER");
            DropTable("BTSTC.PHC_S16_X_DETAIL");
            DropTable("BTSTC.PHC_QTXDCB_HEADER");
            DropTable("BTSTC.PHC_QTXDCB_DETAIL");
            DropTable("BTSTC.PHF_XD_KH_TT_THUOC_BO");
            DropTable("BTSTC.PHF_XD_KH_TT_THUOC_BO_CT");
            DropTable("BTSTC.PHF_XD_KH_THANHTRA_BO");
            DropTable("BTSTC.PHF_XD_KH_THANHTRA_BO_CHITIET");
            DropTable("BTSTC.PHF_TTB_NHATKY");
            DropTable("BTSTC.PHF_TIENDO_THUCHIEN_KH");
            DropTable("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT");
            DropTable("BTSTC.PHF_THUMUC_FILE");
            DropTable("BTSTC.PHF_THEODOI_CANBO");
            DropTable("BTSTC.PHF_THEODOI_CANBO_CT");
            DropTable("BTSTC.PHF_SYS_TUDIEN");
            DropTable("BTSTC.PHF_SOANTHAO_THANHTRA");
            DropTable("BTSTC.PHF_SOANTHAO_THANHTRA_CT");
            DropTable("BTSTC.PHF_QD_PHEDUYET_THANHTRA");
            DropTable("BTSTC.PHF_QD_GIAOTHUCHIEN_TT_THUOCBO");
            DropTable("BTSTC.PHF_QD_GIAOTHUCHIEN_THANHTRA");
            DropTable("BTSTC.PHF_KH_THANHTRA_COQUAN");
            DropTable("BTSTC.PHF_KH_THANHTRA_COQUAN_CT");
            DropTable("BTSTC.PHF_DM_TAOMA");
            DropTable("BTSTC.PHF_DM_DOTTHANHTRA");
            DropTable("BTSTC.PHF_DM_DONVI_PHONGBAN");
            DropTable("BTSTC.PHF_DM_DOITUONG");
            DropTable("BTSTC.PHF_DM_CANBO");
            DropTable("BTSTC.PHF_BM_FILE_TCXD");
            DropTable("BTSTC.PHF_BM_FILE_NSDVN");
            DropTable("BTSTC.PHF_BM_FILE_NSDP");
            DropTable("BTSTC.PHF_BM_FILE_DVSN");
            DropTable("BTSTC.PHF_BM_FILE_CQHC");
            DropTable("BTSTC.PHF_BM_60TT_NSDVN");
            DropTable("BTSTC.PHF_BM_16TT_NSDP");
            DropTable("BTSTC.PHF_BM_15TT_NSDP");
            DropTable("BTSTC.PHF_BM_14TT_NSDP");
            DropTable("BTSTC.PHF_BM_12TT_NSDP");
            DropTable("BTSTC.PHF_BM_11TT_NSDP");
            DropTable("BTSTC.PHF_BM_10TT_TCXD");
            DropTable("BTSTC.PHF_BM_10TT_NSDP");
            DropTable("BTSTC.PHF_BM_09TT_DVSN");
            DropTable("BTSTC.PHF_BM_08TT_TCXD");
            DropTable("BTSTC.PHF_BM_08TT_DVSN");
            DropTable("BTSTC.PHF_BM_08TT_CQHC");
            DropTable("BTSTC.PHF_BM_07TT_TCXD");
            DropTable("BTSTC.PHF_BM_07TT_DVSN");
            DropTable("BTSTC.PHF_BM_07TT_CQHC");
            DropTable("BTSTC.PHF_BM_06TT_TCXD");
            DropTable("BTSTC.PHF_BM_06TT_DVSN");
            DropTable("BTSTC.PHF_BM_05TT_TCXD");
            DropTable("BTSTC.PHF_BM_05TT_NSDP");
            DropTable("BTSTC.PHF_BM_05TT_DVSN");
            DropTable("BTSTC.PHF_BM_05TT_CQHC");
            DropTable("BTSTC.PHF_BM_04TT_TCXD");
            DropTable("BTSTC.PHF_BM_04TT_DVSN");
            DropTable("BTSTC.PHF_BM_04TT_CQHC");
            DropTable("BTSTC.PHF_BM_03TT_TCXD");
            DropTable("BTSTC.PHF_BM_03TT_NSDP");
            DropTable("BTSTC.PHF_BM_03TT_DVSN");
            DropTable("BTSTC.PHF_BM_03TT_CQHC");
            DropTable("BTSTC.PHF_BM_02TT_TCXD");
            DropTable("BTSTC.PHF_BM_02TT_NSDP");
            DropTable("BTSTC.PHF_BM_02TT_DVSN");
            DropTable("BTSTC.PHF_BM_02TT_CQHC");
            DropTable("BTSTC.PHF_BM_01TT_TCXD");
            DropTable("BTSTC.PHF_BM_01TT_NSDP");
            DropTable("BTSTC.PHF_BM_01TT_DVSN");
            DropTable("BTSTC.PHF_BM_01TT_CQHC");
            DropTable("BTSTC.PHE_VANBAN_PHAPQUY");
            DropTable("BTSTC.PHE_VANBAN_HSPL");
            DropTable("BTSTC.PHE_TT_DT_TMDT");
            DropTable("BTSTC.PHE_TOTRINH");
            DropTable("BTSTC.PHE_TOTRINH_IV");
            DropTable("BTSTC.PHE_TOTRINH_II");
            DropTable("BTSTC.PHE_THONGTIN_DUAN");
            DropTable("BTSTC.PHE_THAMDINH");
            DropTable("BTSTC.PHE_THAMDINH_CHITIET");
            DropTable("BTSTC.PHE_QUANLY_VB_HS");
            DropTable("BTSTC.PHE_QUANLY_TAISAN");
            DropTable("BTSTC.PHE_QUANLY_KL_THICONG");
            DropTable("BTSTC.PHE_PHULUC_HOPDONG");
            DropTable("BTSTC.PHE_PHULUC_HOPDONG_CHITIET");
            DropTable("BTSTC.PHE_PHANCONG_CANBO");
            DropTable("BTSTC.PHE_KEHOACH_KETQUA");
            DropTable("BTSTC.PHE_KETQUA_DAUTHAU");
            DropTable("BTSTC.PHE_KETQUA_DAUTHAU_CHITIET");
            DropTable("BTSTC.PHE_KEHOACH_VON_DAUTU");
            DropTable("BTSTC.PHE_HOPDONG");
            DropTable("BTSTC.PHE_GIAO_KEHOACH_VON");
            DropTable("BTSTC.PHE_DUTOAN");
            DropTable("BTSTC.PHE_DUTOAN_DS_DUAN");
            DropTable("BTSTC.PHE_DUAN_CONGVIEC");
            DropTable("BTSTC.PHE_DM_TRANGTHAI_DUAN");
            DropTable("BTSTC.PHE_DM_TINHCHAT_DUAN");
            DropTable("BTSTC.PHE_DM_TAISAN");
            DropTable("BTSTC.PHE_DM_SYS_LIBRARY");
            DropTable("BTSTC.PHE_DM_PHUONGTHUC_DAUTHAU");
            DropTable("BTSTC.PHE_DM_PHONGBAN");
            DropTable("BTSTC.PHE_DM_NHOMVANBAN");
            DropTable("BTSTC.PHE_DM_NHOMDUAN");
            DropTable("BTSTC.PHE_DM_NHOMDONVI");
            DropTable("BTSTC.PHE_DM_NHATHAU");
            DropTable("BTSTC.PHE_DM_NGUON_VON");
            DropTable("BTSTC.PHE_DM_NGHIEPVU");
            DropTable("BTSTC.PHE_DM_LOAIHOPDONG");
            DropTable("BTSTC.PHE_DM_LOAIDUAN");
            DropTable("BTSTC.PHE_DM_LOAIDONVI");
            DropTable("BTSTC.PHE_DM_LOAI_VANBAN");
            DropTable("BTSTC.PHE_DM_LOAI_PHATSINH");
            DropTable("BTSTC.PHE_DM_LOAI_KHVON");
            DropTable("BTSTC.PHE_DM_LINHVUC");
            DropTable("BTSTC.PHE_DM_LINHVUC_DAUTHAU");
            DropTable("BTSTC.PHE_DM_KHOANCHI");
            DropTable("BTSTC.PHE_DM_HTLUACHON_NT");
            DropTable("BTSTC.PHE_DM_HINHTHUC_QLDA");
            DropTable("BTSTC.PHE_DM_HINHTHUC_DUAN");
            DropTable("BTSTC.PHE_DM_HIENTRANG_HOPDONG");
            DropTable("BTSTC.PHE_DM_GIAIDOAN_VON");
            DropTable("BTSTC.PHE_DM_DUAN_VANBAN");
            DropTable("BTSTC.PHE_DM_DU_AN");
            DropTable("BTSTC.PHE_DM_DONVIQUANLY");
            DropTable("BTSTC.PHE_DM_DOITUONGVON");
            DropTable("BTSTC.PHE_DM_DIABAN");
            DropTable("BTSTC.PHE_DM_DACTINH_NGUONVON");
            DropTable("BTSTC.PHE_DM_COQUANBANHANH");
            DropTable("BTSTC.PHE_DM_CONGVIEC");
            DropTable("BTSTC.PHE_DM_CHIPHI");
            DropTable("BTSTC.PHE_DM_CAPCONGTRINH");
            DropTable("BTSTC.PHE_CT_TT_DT_TMDT");
            DropTable("BTSTC.PHE_CHITIET_KEHOACH_KETQUA");
            DropTable("BTSTC.PHE_CHITIET_QUANLY_TAISAN");
            DropTable("BTSTC.PHE_CHITIET_QUANLY_KL_THICONG");
            DropTable("BTSTC.PHE_CHITIET_KEHOACH_VON_DAUTU");
            DropTable("BTSTC.PHE_CHITIET_HOPDONG");
            DropTable("BTSTC.PHE_CHITIET_GIAO_KEHOACH_VON");
            DropTable("BTSTC.PHE_CHITIET_CHIPHI_DUAN_DUTOAN");
            DropTable("BTSTC.PHE_CHIPHI_DUAN_DUTOAN");
            DropTable("BTSTC.PHE_CANBOTHAMGIA_DUAN");
            DropTable("BTSTC.PHC_TMTCTEMPLATE");
            DropTable("BTSTC.PHC_THUYETMINHTAICHINHHEADER");
            DropTable("BTSTC.PHC_THUYETMINHTAICHINHDETAILS");
            DropTable("BTSTC.PHC_PHIEUTHU_IN");
            DropTable("BTSTC.PHC_PHIEUCHI_IN");
            DropTable("BTSTC.PHC_PHIEU_UNT_IN");
            DropTable("BTSTC.PHC_PHIEU_UNC_IN");
            DropTable("BTSTC.PHC_PHIEU_RVDT_IN");
            DropTable("BTSTC.PHC_PHIEU_NTVTK_IN");
            DropTable("BTSTC.PHC_PHIEU_NOPTIEN_VAONSNN_IN");
            DropTable("BTSTC.PHC_PHIEU_NHAPXUAT_KHO_IN");
            DropTable("BTSTC.PHC_PHIEU_GT_CCDC_IN");
            DropTable("BTSTC.PHC_PHIEU_GRT_IN");
            DropTable("BTSTC.PHC_PHIEU_GRDT_IN");
            DropTable("BTSTC.PHC_PHIEU_GG_CCDC_IN");
            DropTable("BTSTC.PHC_PHIEU_GDNTT_IN");
            DropTable("BTSTC.PHC_PHIEU_CTTT_IN");
            DropTable("BTSTC.PHC_PHIEU_BANGKENOPTHUE");
            DropTable("BTSTC.PHC_NHAPSODUHEADER");
            DropTable("BTSTC.PHC_NHAPSODUDETAILS");
            DropTable("BTSTC.PHC_NHAPCHUNGTU");
            DropTable("BTSTC.PHC_HMTSCD");
            DropTable("BTSTC.PHC_HMTSCD_DETAILS");
            DropTable("BTSTC.PHC_DT_THUCHI_NDKT");
            DropTable("BTSTC.PHC_DT_THUCHI_NDKT_CHITIET");
            DropTable("BTSTC.PHC_DT_THU_MLNS");
            DropTable("BTSTC.PHC_DT_THU_MLNS_CHITIET");
            DropTable("BTSTC.PHC_DT_CHI_MLNS");
            DropTable("BTSTC.PHC_DT_CHI_MLNS_CHITIET");
            DropTable("BTSTC.PHC_DOICHIEUSOLIEUHEADER");
            DropTable("BTSTC.PHC_DOICHIEUSOLIEUDETAILS");
            DropTable("BTSTC.PHC_DIEUCHINHKINHPHIHEADER");
            DropTable("BTSTC.PHC_DIEUCHINHKINHPHIDETAILS");
            DropTable("BTSTC.PHC_CHUNGTUHEADER");
            DropTable("BTSTC.PHC_CHUNGTUDETAILS");
            DropTable("BTSTC.PHC_BIENLAITHUHEADER");
            DropTable("BTSTC.PHC_BIENLAITHUDETAILS");
            DropTable("BTSTC.PHB_REPORT_FIELD");
            DropTable("BTSTC.PHB_PL42_P1_TT01");
            DropTable("BTSTC.PHB_PL42_P1_TT01_DETAIL");
            DropTable("BTSTC.PHB_PL41");
            DropTable("BTSTC.PHB_PL41_TEMPLATE");
            DropTable("BTSTC.PHB_PL41_DETAIL");
            DropTable("BTSTC.PHB_PL32_P2_TT01");
            DropTable("BTSTC.PHB_PL32_P2_TT01_DETAIL");
            DropTable("BTSTC.PHB_PL32_P1_TT01");
            DropTable("BTSTC.PHB_PL32_P1_TT01_DETAIL");
            DropTable("BTSTC.PHB_PL31");
            DropTable("BTSTC.PHB_PL31_TEMPLATE");
            DropTable("BTSTC.PHB_PL31_DETAIL");
            DropTable("BTSTC.PHB_F01_02BCQT");
            DropTable("BTSTC.PHB_F01_02BCQT_TEMPLATE");
            DropTable("BTSTC.PHB_F01_02BCQT_PII");
            DropTable("BTSTC.PHB_F01_02BCQT_PII_DETAIL");
            DropTable("BTSTC.PHB_F01_02BCQT_DETAIL");
            DropTable("BTSTC.PHB_F01_01BCQT");
            DropTable("BTSTC.PHB_F01_01BCQT_DETAIL");
            DropTable("BTSTC.PHB_DOICHIEUSOLIEU");
            DropTable("BTSTC.PHB_DM_TSCD");
            DropTable("BTSTC.PHB_DM_TAIKHOAN");
            DropTable("BTSTC.PHB_DM_NOIDUNGKT");
            DropTable("BTSTC.PHB_DM_NHOMMUCCHI");
            DropTable("BTSTC.PHB_DM_NGUONNGANSACH");
            DropTable("BTSTC.PHB_DM_LOAINGANSACH");
            DropTable("BTSTC.PHB_DM_LOAIKHOAN");
            DropTable("BTSTC.PHB_DM_LOAI_CAPPHAT");
            DropTable("BTSTC.PHB_DM_HOATDONG");
            DropTable("BTSTC.PHB_DM_DVQHNS");
            DropTable("BTSTC.PHB_DM_DUAN");
            DropTable("BTSTC.PHB_DM_BAOCAO");
            DropTable("BTSTC.PHB_C_B06X");
            DropTable("BTSTC.PHB_C_B06X_TEMPLATE");
            DropTable("BTSTC.PHB_C_B06X_DETAIL");
            DropTable("BTSTC.PHB_C_B04X");
            DropTable("BTSTC.PHB_C_B04X_DETAIL");
            DropTable("BTSTC.PHB_C_B03X");
            DropTable("BTSTC.PHB_C_B03X_DETAIL");
            DropTable("BTSTC.PHB_C_B03D_X");
            DropTable("BTSTC.PHB_C_B03D_X_TEMPLATE");
            DropTable("BTSTC.PHB_C_B03D_X_DETAIL");
            DropTable("BTSTC.PHB_C_B03C_X");
            DropTable("BTSTC.PHB_C_B03C_X_DETAIL");
            DropTable("BTSTC.PHB_C_B03B_X");
            DropTable("BTSTC.PHB_C_B03B_X_DETAIL");
            DropTable("BTSTC.PHB_C_B03A_X");
            DropTable("BTSTC.PHB_C_B03A_X_DETAIL");
            DropTable("BTSTC.PHB_C_B02B_X_DETAIL");
            DropTable("BTSTC.PHB_C_B02B_X");
            DropTable("BTSTC.PHB_C_B02AX");
            DropTable("BTSTC.PHB_C_B02AX_DETAIL");
            DropTable("BTSTC.PHB_C_B01X");
            DropTable("BTSTC.PHB_C_B01X_TEMPLATE");
            DropTable("BTSTC.PHB_C_B01X_DETAIL");
            DropTable("BTSTC.PHB_BIEU69NS");
            DropTable("BTSTC.PHB_BIEU69NS_TEMPLATE");
            DropTable("BTSTC.PHB_BIEU69NS_DETAIL");
            DropTable("BTSTC.PHB_BIEU68NS");
            DropTable("BTSTC.PHB_BIEU68NS_TEMPLATE");
            DropTable("BTSTC.PHB_BIEU68NS_DETAIL");
            DropTable("BTSTC.PHB_BIEU67NS");
            DropTable("BTSTC.PHB_BIEU67NS_TEMPLATE");
            DropTable("BTSTC.PHB_BIEU67NS_DETAIL");
            DropTable("BTSTC.PHB_BIEU4BP2");
            DropTable("BTSTC.PHB_BIEU4BP2_DETAIL");
            DropTable("BTSTC.PHB_BIEU4BP1");
            DropTable("BTSTC.PHB_BIEU4BP1_TEMPLATE");
            DropTable("BTSTC.PHB_BIEU4BP1_DETAIL");
            DropTable("BTSTC.PHB_BIEU4A");
            DropTable("BTSTC.PHB_BIEU4A_TEMPLATE");
            DropTable("BTSTC.PHB_BIEU4A_DETAIL");
            DropTable("BTSTC.PHB_BIEU3BP2");
            DropTable("BTSTC.PHB_BIEU3BP2_DETAIL");
            DropTable("BTSTC.PHB_BIEU3BP1");
            DropTable("BTSTC.PHB_BIEU3BP1_TEMPLATE");
            DropTable("BTSTC.PHB_BIEU3BP1_DETAIL");
            DropTable("BTSTC.PHB_BIEU3A");
            DropTable("BTSTC.PHB_BIEU3A_TEMPLATE");
            DropTable("BTSTC.PHB_BIEU3A_DETAIL");
            DropTable("BTSTC.PHB_BIEU2CP2");
            DropTable("BTSTC.PHB_BIEU2CP2_DETAIL");
            DropTable("BTSTC.PHB_BIEU2CP1");
            DropTable("BTSTC.PHB_BIEU2CP1_TEMPLATE");
            DropTable("BTSTC.PHB_BIEU2CP1_DETAIL");
            DropTable("BTSTC.PHB_BIEU2B");
            DropTable("BTSTC.PHB_BIEU2B_TEMPLATE");
            DropTable("BTSTC.PHB_BIEU2B_DETAIL");
            DropTable("BTSTC.PHB_BIEU2A");
            DropTable("BTSTC.PHB_BIEU2A_TEMPLATE");
            DropTable("BTSTC.PHB_BIEU2A_DETAIL");
            DropTable("BTSTC.PHB_BIEU12TT344");
            DropTable("BTSTC.PHB_BIEU12TT344_DETAIL");
            DropTable("BTSTC.PHB_BIEU11TT344");
            DropTable("BTSTC.PHB_BIEU11TT344_DETAIL");
            DropTable("BTSTC.PHB_BIEU10TT344");
            DropTable("BTSTC.PHB_BIEU10TT344_DETAIL");
            DropTable("BTSTC.PHB_BIEU09TT344");
            DropTable("BTSTC.PHB_BIEU09TT344_TEMPLATE");
            DropTable("BTSTC.PHB_BIEU09TT344_DETAIL");
            DropTable("BTSTC.PHB_BIEU08TT344");
            DropTable("BTSTC.PHB_BIEU08TT344_TEMPLATE");
            DropTable("BTSTC.PHB_BIEU08TT344_DETAIL");
            DropTable("BTSTC.PHB_BIEU07TT344");
            DropTable("BTSTC.PHB_BIEU07TT344_TEMPLATE");
            DropTable("BTSTC.PHB_BIEU07TT344_DETAIL");
            DropTable("BTSTC.PHB_BIEU03");
            DropTable("BTSTC.PHB_BIEU03_TEMPLATE");
            DropTable("BTSTC.PHB_BIEU03_DETAIL");
            DropTable("BTSTC.PHB_BIEU01C");
            DropTable("BTSTC.PHB_BIEU01CP2");
            DropTable("BTSTC.PHB_BIEU01CP2_TEMPLATE");
            DropTable("BTSTC.PHB_BIEU01CP2_DETAIL");
            DropTable("BTSTC.PHB_BIEU01C_TEMPLATE");
            DropTable("BTSTC.PHB_BIEU01C_DETAIL");
            DropTable("BTSTC.PHB_BIEU01B");
            DropTable("BTSTC.PHB_BIEU01B_TEMPLATE");
            DropTable("BTSTC.PHB_BIEU01B_DETAIL");
            DropTable("BTSTC.PHB_BIEU01A");
            DropTable("BTSTC.PHB_BIEU01A_TEMPLATE");
            DropTable("BTSTC.PHB_BIEU01A_DETAIL");
            DropTable("BTSTC.PHB_B03BCQT_BII1");
            DropTable("BTSTC.PHB_B03BCQT_BII1_TEMPLATE");
            DropTable("BTSTC.PHB_B03BCQT_BII1_DETAIL");
            DropTable("BTSTC.PHB_B02H_II");
            DropTable("BTSTC.PHB_B02H_II_TEMPLATE");
            DropTable("BTSTC.PHB_B02H_II_DETAIL");
            DropTable("BTSTC.PHB_B02BCTC");
            DropTable("BTSTC.PHB_B02BCTC_TEMPLATE");
            DropTable("BTSTC.PHB_B02BCTC_DETAIL");
            DropTable("BTSTC.PHB_B02BCQT");
            DropTable("BTSTC.PHB_B02BCQT_TEMPLATE");
            DropTable("BTSTC.PHB_B02BCQT_DETAIL");
            DropTable("BTSTC.PHB_B01BCQT");
            DropTable("BTSTC.PHB_B01BCQT_TEMPLATE");
            DropTable("BTSTC.PHB_B01BCQT_DETAIL");
            DropTable("BTSTC.PHB_BIEU70NS");
            DropTable("BTSTC.PHB_BIEU70NS_TEMPLATE");
            DropTable("BTSTC.PHB_BIEU70NS_DETAIL");
            DropTable("BTSTC.PHA_THDT_HCSN_DT");
            DropTable("BTSTC.PHA_THANHTOAN_LUONG");
            DropTable("BTSTC.PHA_THANHTOAN_LUONG_DETAIL");
            DropTable("BTSTC.PHA_QL_TT_VON");
            DropTable("BTSTC.PHA_QL_TT_VON_CHITIET");
            DropTable("BTSTC.PHA_KBQT82");
            DropTable("BTSTC.PHA_KBQT01");
            DropTable("BTSTC.PHA_HACHTOAN_THU");
            DropTable("BTSTC.PHA_HACHTOAN_KHAC");
            DropTable("BTSTC.PHA_HACHTOAN_CHI");
            DropTable("BTSTC.PHA_DUTOAN");
            DropTable("BTSTC.PHA_DUTOAN_THUCHI_NSNN");
            DropTable("BTSTC.PHA_DUTOAN_THUCHI_NSNN_DETAIL");
            DropTable("BTSTC.PHA_DTXDBG04_9");
            DropTable("BTSTC.PHA_DTXDBG04_8");
            DropTable("BTSTC.PHA_DTXDBG04_7");
            DropTable("BTSTC.PHA_DTXDBG04_6");
            DropTable("BTSTC.PHA_DTXDBG04_5");
            DropTable("BTSTC.PHA_DTXDBG04_4");
            DropTable("BTSTC.PHA_DTXDBG04_3");
            DropTable("BTSTC.PHA_DTXDBG04_2");
            DropTable("BTSTC.PHA_DTXDBG04_1");
            DropTable("BTSTC.PHA_DTXDBG04_10");
            DropTable("BTSTC.PHA_DTXD01_7");
            DropTable("BTSTC.PHA_DTXD01_6");
            DropTable("BTSTC.PHA_DTXD01_5");
            DropTable("BTSTC.PHA_DTXD01_4");
            DropTable("BTSTC.PHA_DTXD01_3");
            DropTable("BTSTC.PHA_DTXD01_2");
            DropTable("BTSTC.PHA_DTXD01_1");
            DropTable("BTSTC.PHA_DASHBOARD");
            DropTable("BTSTC.PHA_BC_NS");
            DropTable("BTSTC.PHA_BC_NS_CHITIET");
            DropTable("BTSTC.PHA_AU_NHOMQUYEN");
            DropTable("BTSTC.PHA_AU_NHOMQUYEN_CHUCNANG");
            DropTable("BTSTC.PHA_AU_NGUOIDUNG_QUYEN");
            DropTable("BTSTC.PHA_AU_NGUOIDUNG_NHOMQUYEN");
            DropTable("BTSTC.MBL_PHA_TC_TOANTINH");
            DropTable("BTSTC.MBL_PHA_T_NSNN");
            DropTable("BTSTC.MBL_PHA_T_NSDP");
            DropTable("BTSTC.MBL_PHA_T_DIABAN");
            DropTable("BTSTC.MBL_PHA_QTTDB");
            DropTable("BTSTC.MBL_PHA_CQ_THU");
            DropTable("BTSTC.MBL_PHA_C_NSDP");
            DropTable("BTSTC.MBL_PHA_C_DTTX");
            DropTable("BTSTC.LOG_SIGNIN");
            DropTable("BTSTC.DM_TKTN");
            DropTable("BTSTC.DM_TIEUNHOM");
            DropTable("BTSTC.DM_TIEUMUC");
            DropTable("BTSTC.DM_NGANHKT");
            DropTable("BTSTC.DM_MUC");
            DropTable("BTSTC.DM_CTMTQG");
            DropTable("BTSTC.DM_CHUONG");
            DropTable("BTSTC.DM_VATTU");
            DropTable("BTSTC.DM_TSCD");
            DropTable("BTSTC.DM_TKKHOBAC");
            DropTable("BTSTC.DM_TINHCHATNGUON");
            DropTable("BTSTC.DM_TINHCHAT_DONGTIEN");
            DropTable("BTSTC.DM_TAIKHOAN");
            DropTable("BTSTC.DM_QUY");
            DropTable("BTSTC.DM_PHONGBAN");
            DropTable("BTSTC.DM_PHC_NGHIEPVU");
            DropTable("BTSTC.DM_PHC_CONGTHUC_CHITIEUTHU_CHI");
            DropTable("BTSTC.DM_PHC_CHITIEUTHUCHI");
            DropTable("BTSTC.DM_PHC_CHITIEU_HAS_CONGTHUC");
            DropTable("BTSTC.DM_NGUONVON");
            DropTable("BTSTC.DM_NGUON_NSNN");
            DropTable("BTSTC.DM_NGUON_DIA_PHUONG");
            DropTable("BTSTC.DM_NGHIEPVU");
            DropTable("BTSTC.DM_MAUBAOCAOTHU");
            DropTable("BTSTC.DM_MAUBAOCAO");
            DropTable("BTSTC.DM_MAUBAOCAOCHI");
            DropTable("BTSTC.DM_MA_LOAIVON");
            DropTable("BTSTC.DM_LOAIPHI");
            DropTable("BTSTC.DM_LOAIHINH");
            DropTable("BTSTC.DM_LOAIDUTOAN");
            DropTable("BTSTC.DM_LOAICT");
            DropTable("BTSTC.DM_LOAI_TSCD");
            DropTable("BTSTC.DM_LOAI_KHV");
            DropTable("BTSTC.DM_KHO");
            DropTable("BTSTC.DM_IDBUILDER");
            DropTable("BTSTC.DM_HACHTOANTUDONG");
            DropTable("BTSTC.DM_DTTHANHTOAN");
            DropTable("BTSTC.DM_DONVI_CHUDAUTU");
            DropTable("BTSTC.DM_DBHC");
            DropTable("BTSTC.DM_DAUTU_XDCB");
            DropTable("BTSTC.DM_DANHMUC");
            DropTable("BTSTC.DM_CTMUCTIEU");
            DropTable("BTSTC.DM_CHUCVU");
            DropTable("BTSTC.DM_CHITIEU");
            DropTable("BTSTC.DM_CHITIEU_DUTOAN");
            DropTable("BTSTC.DM_CHITIEU_COT");
            DropTable("BTSTC.DM_CHITIEU_COT_SOLIEU");
            DropTable("BTSTC.DM_CHITIEU_BAOCAO");
            DropTable("BTSTC.DM_CHITIEU_BAOCAO_COL");
            DropTable("BTSTC.DM_BAOCAO");
            DropTable("BTSTC.DM_BAOCAO_DETAIL");
            DropTable("BTSTC.AU_PROCESS");
            DropTable("BTSTC.AU_NHOMQUYEN");
            DropTable("BTSTC.AU_NHOMQUYEN_CHUCNANG");
            DropTable("BTSTC.AU_NGUOIDUNG");
            DropTable("BTSTC.AU_NGUOIDUNG_QUYEN");
            DropTable("BTSTC.AU_NGUOIDUNG_NHOMQUYEN");
            DropTable("BTSTC.AU_KYKETOAN");
        }
    }
}
