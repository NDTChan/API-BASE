define(['angular', 'controllers/auth/AuController', 'controllers/sys/SysChucNang'], function (angular) {
    var app = angular.module('headerModule', ['authModule', 'configModule', 'sysChucNang']);
    var layoutUrl = "/_layouts/15/BTS.SP.STC.PHF/";
    app.directive('tree', function () {
        return {
            restrict: "E",
            replace: true,
            scope: {
                tree: '='
            },
            templateUrl: layoutUrl + 'utils/tree/template-ul.html'
        };
    });
    app.directive('leaf', function ($compile) {
        return {
            restrict: "E",
            replace: true,
            scope: {
                leaf: "="
            },
            templateUrl: layoutUrl + 'utils/tree/template-li.html',
            link: function (scope, element, attrs) {
                if (angular.isArray(scope.leaf.Children) && scope.leaf.Children.length > 0) {
                    element.append("<tree tree='leaf.Children'></tree>");
                    element.addClass('dropdown-submenu');
                    $compile(element.contents())(scope);
                } else {
                }
            }
        };
    });
    app.controller('HeaderCtrl', ['$scope', 'configService', '$state', 'accountService', '$log', 'userService', 'SysChucNangService',
    function ($scope, configService, $state, accountService, $log, userService, sysChucNangService) {
        function treeify(list, idAttr, parentAttr, childrenAttr) {
            if (!idAttr) idAttr = 'Value';
            if (!parentAttr) parentAttr = 'Parent';
            if (!childrenAttr) childrenAttr = 'Children';
            var lookup = {};
            var result = {};
            result[childrenAttr] = [];
            list.forEach(function (obj) {
                lookup[obj[idAttr]] = obj;
                obj[childrenAttr] = [];
            });
            list.forEach(function (obj) {
                if (obj[parentAttr] != null) {
                    lookup[obj[parentAttr]][childrenAttr].push(obj);
                } else {
                    result[childrenAttr].push(obj);
                }
            });
            return result;
        };

        function loadUser() {
            $scope.currentUser = userService.GetCurrentUser();
            if (!$scope.currentUser) {
                $state.go('login');
            }
            sysChucNangService.getSelectData().then(function (response) {
                if (response && response.data && response.data.length > 0) {
                    $scope.lstMenu = angular.copy(response.data);
                    $scope.treeMenu = treeify($scope.lstMenu);
                } else {
                    console.log(response);
                }
            }, function (response) {
                console.log(response);
            });

        }
        loadUser();

        $scope.logOut = function () {
            accountService.logout();
        };
    }]);
    return app;
});