define([
], function () {
    var layoutUrl = "/_layouts/15/BTS.SP.STC.PHF/views/report/";
    var controlUrl = "/_layouts/15/BTS.SP.STC.PHF/controllers/report/";
    var states = [
        {
            name: 'dmBaoCaoThanhTra',
            url: '/dmBaoCaoThanhTra',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "phf_dmBaoCaoThanhTra/index.html",
                    controller: "DmBaoCaoThanhTraCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "phf_dmBaoCaoThanhTra.js"
        }

    ];
    return states;
});