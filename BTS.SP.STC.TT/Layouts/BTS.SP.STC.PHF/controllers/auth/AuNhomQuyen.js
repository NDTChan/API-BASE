define(['controllers/auth/AuNhomQuyenChucNang'], function () {
    'use strict';
    var app = angular.module('AuNhomQuyen', ['AuNhomQuyenChucNang']);
    app.factory('AuNhomQuyenService', ['$http', 'configService', function ($http, configService) {
        var serviceUrl = configService.rootUrlWebApi + '/auth/AuNhomQuyen';
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
            update: function (params) {
                return $http.put(serviceUrl + '/' + params.ID, params);
            },
            deleteItem: function (params) {
                return $http.delete(serviceUrl + '/' + params.ID);
            },
            getNhomQuyenConfig: function (data) {
                return $http.get(serviceUrl + '/getNhomQuyenConfig/' + data);
            },
            getSelectData:function() {
                return $http.get(serviceUrl + '/getSelectData');
            }
        }
        return result;
    }]);

    app.controller('AuNhomQuyenViewCtrl', ['$scope', '$filter', '$location', 'AuNhomQuyenService', 'configService', 'tempDataService', 'securityService',
        'toaster', '$uibModal', '$ngConfirm', '$log', '$state',
        function ($scope, $filter, $location, service, configService, tempDataService, securityService, toaster, $uibModal, $ngConfirm, $log, $state) {
            $scope.config = {
                label: angular.copy(configService.label)
            }
            $scope.paged = angular.copy(configService.pageDefault);
            $scope.filtered = angular.copy(configService.filterDefault);
            $scope.tempData = tempDataService.tempData;
            $scope.accessList = {};
            function filterData() {
                if ($scope.accessList.View) {
                    var postdata = { paged: $scope.paged, filtered: $scope.filtered };
                    service.paging(postdata).then(function (successRes) {
                        if (successRes && successRes.status == 200 && successRes.data && !successRes.data.Error) {
                            $scope.data = successRes.data.Data.Data;
                            $scope.paged.totalItems = successRes.data.Data.totalItems;
                        } else {
                            $scope.data = [];
                            $scope.paged.totalItems = 0;
                            toaster.pop('error', "Lỗi:", successRes.data.Message);
                        }
                    }, function (errorRes) {
                        toaster.pop('error', "Lỗi:", errorRes.statusText);
                    });
                }
            };

            function loadAccessList() {
                securityService.getAccessList('auNhomQuyen').then(function (successRes) {
                    if (successRes && successRes.status == 200) {
                        $scope.accessList = successRes.data;
                        if (!$scope.accessList.View) {
                            toaster.pop('error', "Lỗi:", "Không có quyền truy cập !");
                        } else {
                            filterData();
                        }
                    } else {
                        toaster.pop('error', "Lỗi:", "Không có quyền truy cập !");
                    }
                }, function (errorRes) {
                    console.log(errorRes);
                    toaster.pop('error', "Lỗi:", "Không có quyền truy cập !");
                    $scope.accessList = null;
                });
            }
            loadAccessList();

            $scope.displayHepler = function (module, value) {
                var data = $filter('filter')($scope.tempData(module), { Value: value }, true);
                if (data.length == 1) {
                    return data[0].Text;
                } else {
                    return value;
                }
            };

            $scope.setPage = function (pageNo) {
                $scope.paged.currentPage = pageNo;
                filterData();
            };

            $scope.doSearch = function () {
                $scope.paged.currentPage = 1;
                filterData();
            };

            $scope.pageChanged = function () {
                filterData();
            };

            $scope.goHome = function () {
                $state.go('home');
            };

            $scope.refresh = function () {
                $scope.setPage($scope.paged.currentPage);
            };

            $scope.detail = function (item) {
                $uibModal.open({
                    backdrop: 'static',
                    size: 'md',
                    templateUrl: configService.buildUrl('auth/AuNhomQuyen', 'detail'),
                    controller: 'AuNhomQuyenDetailCtrl',
                    resolve: {
                        targetData: function () {
                            return item;
                        }
                    }
                });
            };

            $scope.create = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    size: 'md',
                    templateUrl: configService.buildUrl('auth/AuNhomQuyen', 'add'),
                    controller: 'AuNhomQuyenCreateCtrl',
                    resolve: {}
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.refresh();
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };
            $scope.edit = function (item) {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    size: 'md',
                    templateUrl: configService.buildUrl('auth/AuNhomQuyen', 'edit'),
                    controller: 'AuNhomQuyenEditCtrl',
                    resolve: {
                        targetData: function () {
                            return item;
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.refresh();
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };

            $scope.delete = function (item) {
                var jc = $ngConfirm({
                    title: 'Xóa bản ghi.',
                    content: 'Xóa bản ghi có thể tác động đến các dữ liệu liên quan. Chắc chắn xóa ?',
                    icon: 'fa fa-warning',
                    buttons: {
                        confirm: {
                            text: 'Xóa!',
                            btnClass: 'btn-warning',
                            action: function () {
                                service.deleteItem(item).then(function (successRes) {
                                    if (successRes && successRes.status == 200 && !successRes.data.Error) {
                                        toaster.pop('success', "Thông báo", successRes.data.Message, 2000);
                                        jc.close();
                                        filterData();
                                    } else {
                                        toaster.pop('error', "Lỗi:", successRes.data.Message);
                                        jc.close();
                                    }
                                }, function (errorRes) {
                                    console.log(errorRes);
                                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                                    jc.close();
                                });
                            }
                        },
                        cancel: {
                            text: 'Hủy',
                            action: function () {
                                jc.close();
                            }
                        }
                    }
                });
            };

            $scope.configItem = function (item) {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    size: 'lg',
                    windowClass: 'app-modal-window',
                    templateUrl: configService.buildUrl('auth/AuNhomQuyenChucNang', 'config'),
                    controller: 'AuNhomQuyenChucNangConfigCtrl',
                    resolve: {
                        targetData: function () {
                            return item;
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $log.info('Modal dismissed at: ' + new Date());
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };
        }]);

    app.controller('AuNhomQuyenDetailCtrl', [
        '$scope', '$location', 'AuNhomQuyenService', 'configService', 'tempDataService', 'toaster', '$uibModalInstance', 'targetData', 'AuNhomQuyenChucNangService',
        function ($scope, $location, service, configService, tempDataService, toaster, $uibModalInstance, targetData, AuNhomQuyenChucNangService) {
            $scope.config = {
                label: angular.copy(configService.label)
            };
            $scope.title = "Chi tiết nhóm quyền : " + targetData.MANHOMQUYEN;
            $scope.tempData = tempDataService.tempData;
            function loadData() {
                AuNhomQuyenChucNangService.getByMaNhomQuyen(targetData.MANHOMQUYEN).then(function (successRes) {
                    if (successRes && successRes.status == 200 && !successRes.data.Error) {
                        $scope.data = successRes.data.Data;
                    } else {
                        toaster.pop('error', "Lỗi:", successRes.data.Message);
                    }
                }, function (errorRes) {
                    console.log(errorRes);
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadData();

            $scope.cancel = function () {
                $uibModalInstance.close();
            };
        }]);

    app.controller('AuNhomQuyenCreateCtrl', [
        '$scope', '$filter', '$location', 'AuNhomQuyenService', 'configService', 'tempDataService', 'toaster', '$uibModalInstance',
        function ($scope, $filter, $location, service, configService, tempDataService, toaster, $uibModalInstance) {
            $scope.config = {
                label: angular.copy(configService.label)
            };
            $scope.title = "Thêm mới nhóm quyền.";
            $scope.tempData = tempDataService.tempData;
            $scope.target = { PHANHE: 'E' };
            $scope.save = function () {
                service.post($scope.target).then(function (successRes) {
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

    app.controller('AuNhomQuyenEditCtrl', [
        '$scope', '$filter', '$location', 'AuNhomQuyenService', 'configService', 'tempDataService', 'toaster', '$uibModalInstance', 'targetData',
        function ($scope, $filter, $location, service, configService, tempDataService, toaster, $uibModalInstance, targetData) {
            $scope.config = {
                label: angular.copy(configService.label)
            };
            $scope.title = "Sửa nhóm quyền.";
            $scope.tempData = tempDataService.tempData;
            $scope.target = angular.copy(targetData);
            $scope.save = function () {
                service.update($scope.target).then(function (successRes) {
                    if (successRes && successRes.status == 200 && !successRes.data.Error) {
                        toaster.pop('success', "Thông báo", successRes.data.Message, 2000);
                        $uibModalInstance.close(successRes.data.Data);
                    } else {
                        toaster.pop('error', "Lỗi:", successRes.statusText);
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

