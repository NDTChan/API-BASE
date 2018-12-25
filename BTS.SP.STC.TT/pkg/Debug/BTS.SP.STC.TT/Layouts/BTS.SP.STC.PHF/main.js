require.config({
    base: '/',
    paths: {
        'jquery': 'utils/kendo/js/jquery.min',
        'jquery-ui': 'utils/jquery-ui/jquery-ui.min',
        'bootstrap': 'lib/bootstrap.min',
        'angular': 'utils/kendo/js/angular.min',
        'angular-animate': 'lib/angular-animate.min',
        'angular-resource': 'lib/angular-resource.min',
        'angular-sanitize': 'lib/angular-sanitize.min',
        'angular-filter': 'lib/angular-filter.min',
        'angular-cache': 'lib/angular-cache.min',
        'ocLazyLoad': 'lib/ocLazyLoad.require',
        'uiRouter': 'lib/angular-ui-router.min',
        'angularStorage': 'lib/angular-local-storage.min',
        'ui-bootstrap': 'lib/ui-bootstrap-tpls-1.3.3',
        'loading-bar': 'utils/loading-bar/loading-bar.min',
        'toaster': 'utils/toaster/toaster.min',
        'ng-file-upload': 'utils/ng-file-upload-all.min',
        'dynamic-number': 'utils/dynamic-number.min',
        'angular-confirm': 'utils/angular-confirm/angular-confirm.min',
        'ckEditor': 'lib/ckeditor/ckeditor',
        'angular-ckEditor': 'lib/ckeditor/angular-ckeditor.min',
        'kendo.all.min': 'utils/kendo/js/kendo.all.min',
        'ngNotify': 'lib/ng-notify/ng-notify.min',
        'telerikReportViewer': 'utils/telerik/js/telerikReportViewer-11.0.17.118.min',
        //'telerikReportViewer_kendo': 'utils/telerik/js/telerikReportViewer.kendo-11.0.17.118.min',

    },
    shim: {
        'jquery': {
            exports: '$'
        },
        'jquery-ui': ['jquery'],
        'bootstrap': ['jquery'],
        'angular': {
            deps: ['jquery', 'bootstrap'],
            exports: 'angular'
        },
        'ocLazyLoad': ['angular'],
        'uiRouter': ['angular'],
        'angular-animate': ['angular'],
        'angular-resource': ['angular'],
        'angular-filter': ['angular'],
        'angular-cache': ['angular'],
        'angular-sanitize': ['angular'],
        'angularStorage': ['angular'],
        'ui-bootstrap': ['angular'],
        'loading-bar': ['angular'],
        'toaster': ['angular'],
        'ng-file-upload': ['angular'],
        'dynamic-number': ['angular'],
        'angular-confirm': ['angular'],
        'ckEditor': ['jquery'],
        'angular-ckEditor': ['angular', 'ckEditor'],
        'kendo.all.min': {
            deps: ['angular']
        },
        'ngNotify': ['angular'],
        'telerikReportViewer': ['jquery', 'angular'],
        //'telerikReportViewer_kendo': ['jquery', 'angular'],
    },
    waitSeconds: 0
});
// Start the main app logic.
require(['app'], function () {
    angular.bootstrap(document.body, ['myApp']);
});
