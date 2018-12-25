define([
], function () {
    var layoutUrl = "/_layouts/15/BTS.SP.STC.PHF/views/nv/";
    var controlUrl = "/_layouts/15/BTS.SP.STC.PHF/controllers/nv/";
    var states = [
        {
            name: 'phf_doivoittbo',
            url: '/khthanhtrabo',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "KhThanhTra_Bo/index.html",
                    controller: "nvKhThanhTra_BoViewCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_nvKhThanhTra_Bo.js"
        },
        {
            name: 'phf_nvSoanThao',
            url: '/phf_nvSoanThao',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_nvSoanThao/index.html",
                    controller: "NvSoanThaoCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_nvSoanThao.js"
        },
        {
            name: 'phf_nvNhatKy',
            url: '/phf_nvNhatKy/:MA_DOT',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_nvNhatKy/index.html",
                    controller: "NvNhatKyViewCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_nvNhatKy.js"
        },
        {
            name: 'phf_capNhatKetQuaThanhTra',
            url: '/capNhatKetQuaThanhTra',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_nvCapNhatKetQuaThanhTra/index.html",
                    controller: "CapNhatKetQuaThanhTraViewCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_nvCapNhatKetQuaThanhTra.js"
        },
        {
            name: 'phf_nvTienDoThucHienTT',
            url: '/phf_nvTienDoThucHienTT/:MA_DOT',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_nvTienDoThucHienTT/index.html",
                    controller: "TienDoThucHienTTViewCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_nvTienDoThucHienTT.js"
        },
        {
            name: 'phf_phanCongKeHoach',
            url: '/phf_phanCongKeHoach/:MA_DOT',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_nvPhanCongKeHoachThanhTraBo/index.html",
                    controller: "PhanCongKeHoachViewCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_nvPhanCongKeHoachThanhTraBo.js"
        },
        {
            name: 'phf_nvKhThanhTraThuocBo',
            url: '/phf_nvKhThanhTraThuocBo/:MA_DOT',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_nvKhThanhTraThuocBo/index.html",
                    controller: "KeHoachThanhTraThuocBoViewCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_nvKhThanhTraThuocBo.js"
        },
        {
            name: 'phf_nvQuyetDinhPheDuyetTT',
            url: '/quyetDinhPheDuyetTT',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_nvQuyetDinhPheDuyetTT/index.html",
                    controller: "QuyetDinhPheDuyetTTViewCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_nvQuyetDinhPheDuyetTT.js"
        },
        {
            name: 'phf_nvGiaoThucHienTTThuocBo',
            url: '/giaoThucHienTTThuocBo',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_nvGiaoThucHienTTThuocBo/index.html",
                    controller: "NvGiaoThucHienTTThuocBoCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_nvGiaoThucHienTTThuocBo.js"
        },
        {
            name: 'phf_nvQDGiaoThucHienThanhTra',
            url: '/giaoThucHienTT',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_nvQDGiaoThucHienThanhTra/index.html",
                    controller: "NvQDGiaoThucHienThanhTraCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_nvQDGiaoThucHienThanhTra.js"
        },
        {
            name: 'phf_nvTheoDoiCanBo',
            url: '/phf_nvTheoDoiCanBo',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_nvTheoDoiCanBo/index.html",
                    controller: "TheoDoiCanBoViewCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_nvTheoDoiCanBo.js"
        },
        /* NAMBATTINHHINH */
        {
            name: 'phf_bieu02',
            url: '/phf_bieu02',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "NamBatTinhHinh/Bieu02/index.html",
                    controller: "bieu02Ctrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "NamBatTinhHinh/bieu02Ctrl.js"
        },
        /* END_NAMBATTINHHINH */
        {
            name: 'phf_nvBaoCaoTTTCXD',
            url: '/phf_nvBaoCaoTTTCXD',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_nvBaoCaoTTTCXD/index.html",
                    controller: "BaoCaoTTTCXDViewCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_nvBaoCaoTTTCXD.js"
        },
        {
            name: 'phf_nvBaoCaoTTDVSN',
            url: '/phf_nvBaoCaoTTDVSN',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_nvBaoCaoTTDVSN/index.html",
                    controller: "BaoCaoTTDVSNViewCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_nvBaoCaoTTDVSN.js"
        },
        {
            name: 'phf_nvBaoCaoNSDVN',
            url: '/phf_nvBaoCaoNSDVN',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_nvBaoCaoNSDVN/index.html",
                    controller: "BaoCaoNSDVNViewCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_nvBaoCaoNSDVN.js"
        },
        {
            name: 'phf_nvBaoCaoTTCQHC',
            url: '/phf_nvBaoCaoTTCQHC',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_nvBaoCaoTTCQHC/index.html",
                    controller: "BaoCaoTTCQHCViewCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_nvBaoCaoTTCQHC.js"
        },
        //ĐÁNH GIÁ TIÊU CHÍ RỦI RO
        {
            name: 'phf_ChamNopBaoCaoQuyetToan',
            url: '/phf_TieuChiDanhGiaRuiRo/ChamNopBaoCaoQuyetToan',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "NamBatTinhHinh/TieuChiDanhGiaRuiRo/ChamNopBaoCaoQuyetToan/index.html",
                    controller: "phf_ChamNopBaoCaoQuyetToanCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "NamBatTinhHinh/TieuChiDanhGiaRuiRo/" + "phf_TieuChiDanhGiaRuiRo.js"
        },
        {
            name: 'phf_KeHoachKiemToanNhaNuoc',
            url: '/phf_TieuChiDanhGiaRuiRo/KeHoachKiemToanNhaNuoc',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "NamBatTinhHinh/TieuChiDanhGiaRuiRo/KeHoachKiemToanNhaNuoc/index.html",
                    controller: "phf_KeHoachKiemToanNhaNuocCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "NamBatTinhHinh/TieuChiDanhGiaRuiRo/" + "phf_TieuChiDanhGiaRuiRo.js"
        },
        {
            name: 'phf_DeNghiCuaCucTaiChinh',
            url: '/phf_TieuChiDanhGiaRuiRo/DeNghiCuaCucTaiChinh',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "NamBatTinhHinh/TieuChiDanhGiaRuiRo/DeNghiCuaCucTaiChinh/index.html",
                    controller: "phf_DeNghiCuaCucTaiChinhCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "NamBatTinhHinh/TieuChiDanhGiaRuiRo/" + "phf_TieuChiDanhGiaRuiRo.js"
        }
        //END ĐÁNH GIÁ TIÊU CHÍ RỦI RO
    ];
    return states;
});