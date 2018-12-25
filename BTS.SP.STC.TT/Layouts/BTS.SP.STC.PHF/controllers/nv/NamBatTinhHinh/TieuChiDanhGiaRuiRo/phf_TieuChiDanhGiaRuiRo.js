define(['controllers/dm/phf_dmLoaiThanhTra', 'controllers/dm/phf_dmDotThanhTra'], function () {
    'use strict';
    var app = angular.module('phf_TieuChiDanhGiaRuiRo', ['phf_dmLoaiThanhTra', 'phf_dmDotThanhTra']);
    app.factory('phf_TieuChiDanhGiaRuiRoService', ['$http', 'configService', function ($http, configService) {
        var serviceUrl = configService.rootUrlWebApi + '/nv/phf_TieuChiDanhGiaRuiRo';
        var result = {
            //CHẬM NỘP BÁO CÁO QUYẾT TOÁN
            pagingChamNopBaoCao: function (data) {
                return $http.post(serviceUrl + '/PagingChamNopBaoCao', data);
            },
            postChamNopBaoCao: function (data) {
                return $http.post(serviceUrl + '/PostChamNopBaoCao', data);
            },
            getChamNopBaoCao: function (params) {
                return $http.get(serviceUrl + '/GetChamNopBaoCao/' + params.Id);
            },
            updateChamNopBaoCao: function (params) {
                return $http.put(serviceUrl + '/UpdateChamNopBaoCao/' + params.Id, params);
            },
            deleteChamNopBaoCao: function (params) {
                return $http.delete(serviceUrl + '/DeleteChamNopBaoCao/' + params.Id, params);
            }
            //END CHẬM NỘP BÁO CÁO QUYẾT TOÁN
        };
        return result;
    }]);
    //CHẬM NỘP BÁO CÁO QUYẾT TOÁN
    app.controller('phf_ChamNopBaoCaoQuyetToanCtrl', ['$scope', '$state', 'securityService', 'toaster', 'configService', 'phf_TieuChiDanhGiaRuiRoService', '$uibModal', '$ngConfirm', 'ngNotify',
        function ($scope, $state, securityService, toaster, configService, service, $uibModal, $ngConfirm, ngNotify) {
            $scope.config = { label: angular.copy(configService.label) };
            $scope.paged = angular.copy(configService.pageDefault);
            $scope.filtered = angular.copy(configService.filterDefault);
            $scope.sortType = 'ID';
            $scope.sortReverse = false;
            $scope.accessList = {};
            function filterData() {
                if ($scope.accessList.View) {
                    var postdata = { paged: $scope.paged, filtered: $scope.filtered };
                    service.pagingChamNopBaoCao(postdata).then(function (successRes) {
                        if (successRes && successRes.status === 200 && successRes.data && !successRes.data.Error) {
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
            }
            function loadAccessList() {
                securityService.getAccessList('phf_ChamNopBaoCaoQuyetToanCtrl').then(function (successRes) {
                    if (successRes && successRes.status === 200) {
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
                    toaster.pop('error', "Lỗi:", "Không có quyền truy cập !");
                    $scope.accessList = {};
                });
            }
            loadAccessList();

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

            $scope.refresh = function () {
                $scope.setPage($scope.paged.currentPage);
            };

            $scope.goHome = function () {
                $state.go('home');
            };

            $scope.create = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    size: 'md',
                    templateUrl: configService.buildUrl('nv/NamBatTinhHinh/TieuChiDanhGiaRuiRo/ChamNopBaoCaoQuyetToan', 'add'),
                    controller: 'phf_ChamNopBaoCaoQuyetToanCreateCtrl',
                    resolve: {}
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.refresh();
                });
            };

            $scope.edit = function (item) {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('nv/NamBatTinhHinh/TieuChiDanhGiaRuiRo/ChamNopBaoCaoQuyetToan', 'edit'),
                    controller: 'phf_ChamNopBaoCaoQuyetToanEditCtrl',
                    resolve: {
                        targetData: function () {
                            return item;
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    var index = $scope.data.indexOf(item);
                    if (index !== -1) {
                        $scope.data[index] = updatedData;
                    }
                });
            };

            $scope.delete = function (item) {
                if ($scope.accessList.Delete) {
                    var cp = $ngConfirm({
                        icon: 'fa fa-warning',
                        title: 'Xác nhận!',
                        content: 'Bạn <strong>chắc chắn</strong> muốn xóa ID:<strong>' + item.Id + '</strong> ?',
                        buttons: {
                            'ok': {
                                text: 'Xóa',
                                btnClass: 'btn-blue',
                                action: function () {
                                    service.deleteChamNopBaoCao(item).then(function (response) {
                                        if (!response.data.error) {
                                            ngNotify.set(response.data.Message, { type: 'success' });
                                            $scope.refresh();
                                            cp.close();
                                        } else {
                                            ngNotify.set(response.data.Message, { duration: 3000, type: 'error' });
                                        }
                                    }, function (response) {
                                        ngNotify.set(response.statusText, { duration: 3000, type: 'error' });
                                    });
                                    return false;
                                }
                            },
                            'cancel': {
                                text: "Hủy bỏ"
                            }
                        }
                    });
                } else {
                    toastr.error("Bạn không có quyền xóa", 'Error');
                }
            };
        }]);
    app.controller('phf_ChamNopBaoCaoQuyetToanCreateCtrl', ['$scope', 'configService', '$uibModalInstance', 'DmDotThanhTraService', 'IDM_SYS_TUDIENService', 'phf_TieuChiDanhGiaRuiRoService', 'ngNotify',
        function ($scope, configService, $uibModalInstance, dotThanhTraService, loaiThanhTraService, service, ngNotify) {
            $scope.config = angular.copy(configService);
            $scope.target = {
                DETAILS: []
            };
            function loadLoaiThanhTra() {
                loaiThanhTraService.getSelectData().then(function (response) {
                    $scope.lstLoaiThanhTra = response.data;
                }, function (error) {
                });
            }
            function loadDotThanhTra() {
                dotThanhTraService.getSelectData().then(function (response) {
                    $scope.lstDotThanhTra = response.data;
                }, function (error) {
                });
            }

            loadLoaiThanhTra();
            loadDotThanhTra();

            $scope.addRow = function () {
                $scope.target.DETAILS.push($scope.newItem);
                $scope.newItem = {};
            };

            $scope.save = function () {
                service.postChamNopBaoCao($scope.target).then(function (successRes) {
                    if (successRes && successRes.status === 200 && !successRes.data.Error) {
                        ngNotify.set(successRes.data.Message, { type: 'success' });
                        $uibModalInstance.close($scope.target);
                    } else {
                        ngNotify.set(successRes.data.Message, { duration: 3000, type: 'error' });
                    }
                });
            };

            $scope.cancel = function () {
                $uibModalInstance.close();
            };
        }]);
    app.controller('phf_ChamNopBaoCaoQuyetToanEditCtrl', ['$scope', 'configService', '$uibModalInstance', 'DmDotThanhTraService', 'IDM_SYS_TUDIENService', 'phf_TieuChiDanhGiaRuiRoService', 'targetData', 'ngNotify',
        function ($scope, configService, $uibModalInstance, dotThanhTraService, loaiThanhTraService, service, targetData, ngNotify) {
            $scope.config = angular.copy(configService);
            $scope.target = angular.copy(targetData);
            function loadLoaiThanhTra() {
                loaiThanhTraService.getSelectData().then(function (response) {
                    $scope.lstLoaiThanhTra = response.data;
                }, function (error) {
                });
            }
            function loadDotThanhTra() {
                dotThanhTraService.getSelectData().then(function (response) {
                    $scope.lstDotThanhTra = response.data;
                }, function (error) {
                });
            }
            loadLoaiThanhTra();
            loadDotThanhTra();

            function loadItem() {
                service.getChamNopBaoCao(targetData).then(function (response) {
                    console.log(response);
                }, function (error) {

                });
            }
            loadItem();

            $scope.addRow = function () {
                $scope.target.DETAILS.push($scope.newItem);
                $scope.newItem = {};
            };

            $scope.save = function () {
                service.updateChamNopBaoCao($scope.target).then(function (successRes) {
                    if (successRes && successRes.status === 200 && !successRes.data.Error) {
                        ngNotify.set(successRes.data.Message, { type: 'success' });
                        $uibModalInstance.close($scope.target);
                    } else {
                        ngNotify.set(successRes.data.Message, { duration: 3000, type: 'error' });
                    }
                });
            };

            $scope.cancel = function () {
                $uibModalInstance.close();
            };
        }]);
    //END CHẬM NỘP BÁO CÁO QUYẾT TOÁN
    return app;
});