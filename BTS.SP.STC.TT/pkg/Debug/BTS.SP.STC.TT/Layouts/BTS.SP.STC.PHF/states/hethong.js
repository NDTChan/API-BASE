define([
], function () {
    var layoutUrl = "/_layouts/15/BTS.SP.STC.PHF/views/sys/";
    var controlUrl = "/_layouts/15/BTS.SP.STC.PHF/controllers/sys/";
    var states = [
        {
            name: 'sysChucNang',
            url: '/sysChucNang',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "SysChucNang/index.html",
                    controller: "SysChucNangCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "SysChucNang.js"
        },
        {
            name: 'sysDvqhns',
            url: '/sysDvqhns',
            parent: 'layout',
            abstract: false,
            views: {
                'viewMain@root': {
                    templateUrl: layoutUrl + "sysDvqhns/index.html",
                    controller: "SysDvqhnsViewCtrl as ctrl"
                }
            },
            moduleUrl: controlUrl + "SysDvqhns.js"
        }
    ];
    return states;
});