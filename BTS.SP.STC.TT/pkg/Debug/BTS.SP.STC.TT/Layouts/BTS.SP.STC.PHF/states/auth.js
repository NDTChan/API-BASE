define([
], function () {
    var layoutUrl = "/_layouts/15/BTS.SP.STC.PHF/views/auth/";
    var controlUrl = "/_layouts/15/BTS.SP.STC.PHF/controllers/auth/";
    var states = [
        {
            name: 'AuNhomQuyen',
            url: '/AuNhomQuyen',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "AuNhomQuyen/index.html",
                    controller: "AuNhomQuyenViewCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "AuNhomQuyen.js"
        },
        {
            name: 'AuNguoiDung',
            url: '/AuNguoiDung',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "AuNguoiDung/index.html",
                    controller: "AuNguoiDungViewCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "AuNguoiDung.js"
        },
        {
            name: 'phf_nguoidung_vaitro',
            url: '/phf_nguoidung_vaitro',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_nguoidung_vaitro/index.html",
                    controller: "AuNguoiDungVaiTroViewCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_nguoidung_vaitro.js"
        }
    ];
    return states;
});