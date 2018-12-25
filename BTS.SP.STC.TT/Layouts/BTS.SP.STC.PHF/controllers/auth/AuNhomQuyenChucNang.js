define(['controllers/sys/SysChucNang'], function () {
    'use strict';
    var app = angular.module('AuNhomQuyenChucNang', ['sysChucNang']);
    app.factory('AuNhomQuyenChucNangService', ['$http', 'configService',function ($http, configService) {
        var serviceUrl = configService.rootUrlWebApi + '/auth/AuNhomQuyenChucNang';
        var result = {
            paging: function (data) {
                return $http.post(serviceUrl + '/paging', data);
            },
            post: function (data) {
                return $http.post(serviceUrl + '/Post', data);
            },
            getItem: function (id) {
                return $http.get(serviceUrl + '/' + id);
            },
            getByMaNhomQuyen: function (manhomquyen) {
                return $http.get(serviceUrl + '/GetByMaNhomQuyen/' + manhomquyen);
            },
            update: function (params) {
                return $http.put(serviceUrl + '/' + params.ID, params);
            },
            deleteItem: function (params) {
                return $http.delete(serviceUrl + '/' + params.ID);
            },
            getSelectData: function () {
                return $http.get(serviceUrl + '/GetSelectData');
            },
            config: function (data) {
                return $http.post(serviceUrl + '/Config', data);
            }
        }
        return result;
    }]);

    app.controller('AuNhomQuyenChucNangConfigCtrl', ['$scope', '$filter', '$location','$uibModalInstance', 'configService', 'tempDataService','AuNhomQuyenChucNangService','SysChucNangService','targetData','toaster',
        function ($scope, $filter, $location, $uibModalInstance, configService, tempDataService, service, SysChucNangService, targetData, toaster) {
            $scope.config = {
                label: angular.copy(configService.label)
            };
            $scope.title = "Cấu hình nhóm quyền :" + targetData.TENNHOMQUYEN;
            $scope.tempData = tempDataService.tempData;
            $scope.target = angular.copy(targetData);
            $scope.data = [];
            $scope.lstChucNang = [];
            $scope.lstAdd = [];
            $scope.lstEdit = [];
            $scope.lstDelete = [];
            function loadNhomQuyen() {
                service.getByMaNhomQuyen(targetData.MANHOMQUYEN).then(function (successRes) {
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
                        SysChucNangService.getAllForConfigNhomQuyen(targetData.MANHOMQUYEN).then(function (successRes) {
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
            loadNhomQuyen();

            $scope.selectChucNang = function (item) {
                var obj = angular.copy(item);
                obj.MANHOMQUYEN = targetData.MANHOMQUYEN;
                obj.XEM = true;
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
                            MANHOMQUYEN: filteredData[0].MANHOMQUYEN,
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
                    MANHOMQUYEN: targetData.MANHOMQUYEN,
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
                    toaster.pop('error', "Lỗi:", errorRes.statusText + errorRes.data.Message);
                });
            };

            $scope.cancel = function () {
                $uibModalInstance.close();
            };
    }]);

    
    return app;
});

