define(['controllers/auth/AuNhomQuyen'], function () {
    'use strict';
    var app = angular.module('AuNguoiDungNhomQuyen', ['AuNhomQuyen']);
    app.factory('AuNguoiDungNhomQuyenService', ['$http', 'configService', function ($http, configService) {
        var serviceUrl = configService.rootUrlWebApi + '/auth/AuNguoiDungNhomQuyen';
        var result = {
            post: function (data) {
                return $http.post(serviceUrl + '/Post', data);
            },
            deleteItem: function (data) {
                return $http.delete(serviceUrl + '/' + data.ID);
            },
            getByUsername:function(data) {
                return $http.get(serviceUrl + '/GetByUsername/'+data);
            },
            config:function(data) {
                return $http.post(serviceUrl + '/Config', data);
            }
        }
        return result;
    }]);

    app.controller('AuNguoiDungNhomQuyenCreateCtrl', [
        '$scope', '$filter', '$location', 'AuNguoiDungNhomQuyenService', 'configService', 'toaster', '$uibModalInstance', 'AuNhomQuyenService', 'targetData',
        function ($scope, $filter, $location, service, configService, toaster, $uibModalInstance, AuNhomQuyenService, targetData) {
            $scope.config = {
                label: angular.copy(configService.label)
            };
            $scope.title = "Thêm mới phân quyền";

            $scope.data = [];
            $scope.lstNhomQuyen = [];
            $scope.lstAdd = [];
            $scope.lstDelete = [];

            function loadNhomQuyenByUser() {
                service.getByUsername(targetData.USERNAME).then(function (successRes) {
                    if (successRes && successRes.status == 200 && !successRes.data.Error) {
                        $scope.data = successRes.data.Data;
                        return $scope.data;
                    } else {
                        toaster.pop('error', "Lỗi:", successRes.data.Message);
                        return null;
                    }
                }, function(errorRes) {
                    console.log(errorRes);
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                }).then(function(data) {
                    if (data) {
                        AuNhomQuyenService.getNhomQuyenConfig(targetData.USERNAME).then(function (successRes) {
                            if (successRes && successRes.status == 200 && !successRes.data.Error) {
                                $scope.lstNhomQuyen = successRes.data.Data;
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

            loadNhomQuyenByUser();

            $scope.selectNhomQuyen = function (item) {
                var obj = {
                    USERNAME: targetData.USERNAME,
                    MANHOMQUYEN: item.Value,
                    TENNHOMQUYEN: item.Text
                };
                $scope.lstAdd.push(obj);
                var filteredData = $filter('filter')($scope.lstNhomQuyen, { Value: item.Value }, true);
                if (filteredData && filteredData.length > 0) {
                    var index = $scope.lstNhomQuyen.indexOf(filteredData[0]);
                    if (index != -1) $scope.lstNhomQuyen.splice(index, 1);
                }
            };

            $scope.deSelectNhomQuyen = function (item) {
                $scope.lstNhomQuyen.push({
                    Value: item.MANHOMQUYEN,
                    Text: item.TENNHOMQUYEN
                });
                var filteredData = $filter('filter')($scope.data, { MANHOMQUYEN: item.MANHOMQUYEN }, true);
                if (filteredData && filteredData.length > 0) {
                    var index = $scope.data.indexOf(filteredData[0]);
                    if (index != -1) $scope.data.splice(index, 1);
                    if (filteredData[0].ID > 0) {
                        $scope.lstDelete.push({
                            ID: filteredData[0].ID,
                            MANHOMQUYEN: filteredData[0].MANHOMQUYEN,
                            USERNAME: filteredData[0].USERNAME
                        });
                    }
                }
            };

            $scope.deSelectNhomQuyenAdd = function (item) {
                $scope.lstNhomQuyen.push({
                    Value: item.MANHOMQUYEN,
                    Text: item.TENNHOMQUYEN
                });
                var filteredData = $filter('filter')($scope.lstAdd, { MANHOMQUYEN: item.MANHOMQUYEN }, true);
                if (filteredData && filteredData.length > 0) {
                    var index = $scope.lstAdd.indexOf(filteredData[0]);
                    if (index != -1) $scope.lstAdd.splice(index, 1);
                }
            };


            $scope.save = function () {
                var obj = {
                    USERNAME: targetData.USERNAME,
                    LstAdd: $scope.lstAdd,
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
                    toaster.pop('error', "Lỗi:", errorRes.statusText + errorRes.data.Message);
                });
            };

            $scope.cancel = function () {
                $uibModalInstance.close();
            };
        }]);

    return app;
});

