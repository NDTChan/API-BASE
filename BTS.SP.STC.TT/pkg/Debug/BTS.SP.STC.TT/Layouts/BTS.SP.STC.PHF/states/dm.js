define([
], function () {
    var layoutUrl = "/_layouts/15/BTS.SP.STC.PHF/views/dm/";
    var controlUrl = "/_layouts/15/BTS.SP.STC.PHF/controllers/dm/";
    var states = [
        {
            name: 'dmPhongBan',
            url: '/dmPhongBan',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "DmPhongBan/index.html",
                    controller: "DmPhongBanViewCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_DmPhongBan.js"
        },

        {
            name: 'dmChucVu',
            url: '/dmChucVu',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_dmChucVu/index.html",
                    controller: "DmChucVuCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_dmChucVu.js"
        },

        {
            name: 'dmLoaiThanhTra',
            url: '/dmLoaiThanhTra',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_dmLoaiThanhTra/index.html",
                    controller: "DmLoaiThanhTraCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_dmLoaiThanhTra.js"
        },

        {
            name: 'dmNhomThanhTra',
            url: '/dmNhomThanhTra',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_dmNhomThanhTra/index.html",
                    controller: "DmNhomThanhTraCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_dmNhomThanhTra.js"
        },

        {
            name: 'dmKeHoachThanhTra',
            url: '/dmKeHoachThanhTra',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_dmKeHoachThanhTra/index.html",
                    controller: "DmKeHoachThanhTraCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_dmKeHoachThanhTra.js"
        },       
        {
            name: 'phf_DmCanBo',
            url: '/phf_DmCanBo',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_dmCanBo/index.html",
                    controller: "DmCanBoCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_dmCanBo.js"
        },      

         {
             name: 'dmDotThanhTra',
             url: '/dmDotThanhTra',
             parent: 'layout',
             abstract: false,
             views: {
                 'viewMain@root': {
                     templateUrl: layoutUrl + "phf_dmDotThanhTra/index.html",
                     controller: "DmDotThanhTraCtrl as ctrl"
                 }
             },
             moduleUrl: controlUrl + "phf_dmDotThanhTra.js"
         },

         {
             name: 'dmDoiTuong',
             url: '/dmDoiTuong',
             parent: 'layout',
             abstract: false,
             views: {
                 'viewMain@root': {
                     templateUrl: layoutUrl + "phf_dmDoiTuong/index.html",
                     controller: "DmDoiTuongCtrl as ctrl"
                 }
             },
             moduleUrl: controlUrl + "phf_dmDoiTuong.js"
         },

        {
            name: 'dmDonViPhongBan',
            url: '/dmDonViPhongBan',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_dmDonViPhongBan/index.html",
                    controller: "DmDonViPhongBanCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_dmDonViPhongBan.js"
        },

    ];
    return states;
});