define(['controllers/sys/SysChucNang'], function () {
    'use strict';
    var app = angular.module('AuNguoiDungQuyen', ['sysChucNang']);
    app.factory('AuNguoiDungQuyenService', ['$http', 'configService', function ($http, configService) {
        var serviceUrl = configService.rootUrlWebApi + '/auth/AuNguoiDungQuyen';
        var result = {
            config: function (data) {
                return $http.post(serviceUrl + '/Config', data);
            },
            getByUsername: function (data) {
                return $http.get(serviceUrl + '/GetByUsername/' + data);
            }
        }
        return result;
    }]);

    app.controller('AuNguoiDungQuyenCreateCtrl', ['$scope', '$filter', 'AuNguoiDungQuyenService', 'configService', 'toaster',
    '$uibModalInstance', 'targetData','SysChucNangService',
    function ($scope, $filter, service, configService, toaster, $uibModalInstance, targetData, SysChucNangService) {
        $scope.config = {
            label: angular.copy(configService.label)
        };
        $scope.title = "Thêm mới phân quyền người dùng.";
        $scope.data = [];
        $scope.lstChucNang = [];
        $scope.lstAdd = [];
        $scope.lstEdit = [];
        $scope.lstDelete = [];
        function loadQuyen() {
            service.getByUsername(targetData.USERNAME).then(function (successRes) {
                if (successRes && successRes.status == 200 && !successRes.data.Error) {
                    $scope.data = successRes.data.Data;
                    return $scope.data;
                } else {
                    toaster.pop('error', "Lỗi:", successRes.data.Message);
                    return null;
                }
            }, function (errorRes) {
                console.log(errorRes);
                toaster.pop('error', "Lỗi:", errorRes.statusText);
            }).then(function (data) {
                if (data) {
                    SysChucNangService.getAllForConfigQuyen(targetData.USERNAME).then(function (successRes) {
                        if (successRes && successRes.status == 200 && !successRes.data.Error) {
                            $scope.lstChucNang = successRes.data.Data;
                        } else {
                            toaster.pop('error', "Lỗi:", successRes.data.Message);
                        }
                    }, function (errorRes) {
                        console.log(errorRes);
                        toaster.pop('error', "Lỗi:", errorRes.statusText);
                    });
                }
            });
        }
        loadQuyen();

        $scope.selectChucNang = function (item) {
            var obj = angular.copy(item);
            obj.XEM = true;
            obj.USERNAME = targetData.USERNAME;
            $scope.lstAdd.push(obj);
            var filteredData = $filter('filter')($scope.lstChucNang, { MACHUCNANG: item.MACHUCNANG }, true);
            if (filteredData && filteredData.length > 0) {
                var index = $scope.lstChucNang.indexOf(filteredData[0]);
                if (index != -1) $scope.lstChucNang.splice(index, 1);
            }
        };

        $scope.deSelectChucNang = function (item) {
            $scope.lstChucNang.push({
                MACHUCNANG: item.MACHUCNANG,
                SOTHUTU: item.SOTHUTU,
                STATE: item.STATE,
                TENCHUCNANG: item.TENCHUCNANG
            });
            var filteredData = $filter('filter')($scope.data, { MACHUCNANG: item.MACHUCNANG }, true);
            if (filteredData && filteredData.length > 0) {
                var index = $scope.data.indexOf(filteredData[0]);
                if (index != -1) $scope.data.splice(index, 1);
                if (filteredData[0].ID > 0) {
                    $scope.lstDelete.push({
                        ID: filteredData[0].ID,
                        USERNAME: filteredData[0].USERNAME,
                        MACHUCNANG: filteredData[0].MACHUCNANG
                    });
                }
            }
        };

        $scope.deSelectChucNangAdd = function (item) {
            $scope.lstChucNang.push({
                MACHUCNANG: item.MACHUCNANG,
                SOTHUTU: item.SOTHUTU,
                STATE: item.STATE,
                TENCHUCNANG: item.TENCHUCNANG
            });
            var filteredData = $filter('filter')($scope.lstAdd, { MACHUCNANG: item.MACHUCNANG }, true);
            if (filteredData && filteredData.length > 0) {
                var index = $scope.lstAdd.indexOf(filteredData[0]);
                if (index != -1) $scope.lstAdd.splice(index, 1);
            }
        };

        $scope.modified = function (item) {
            var filteredData = $filter('filter')($scope.lstEdit, { MACHUCNANG: item.MACHUCNANG }, true);
            if (!filteredData || filteredData.length < 1) {
                $scope.lstEdit.push(item);
            }
        };

        $scope.save = function () {
            var obj = {
                USERNAME: targetData.USERNAME,
                LstAdd: $scope.lstAdd,
                LstEdit: $scope.lstEdit,
                LstDelete: $scope.lstDelete
            }
            service.config(obj).then(function (successRes) {
                if (successRes && successRes.status == 200 && !successRes.data.Error) {
                    toaster.pop('success', "Thông báo", successRes.data.Message, 2000);
                    $uibModalInstance.close(successRes.data.Data);
                } else {
                    toaster.pop('error', "Lỗi:", successRes.data.Message);
                }
            }, function (errorRes) {
                console.log(errorRes);
                toaster.pop('error', "Lỗi:", errorRes.statusText);
            });
        };

        $scope.cancel = function () {
            $uibModalInstance.close();
        };
    }]);
    return app;
});

