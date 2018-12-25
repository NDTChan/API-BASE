define(['controllers/dm/phf_dmDoiTuong', 'controllers/dm/phf_dmDonViPhongBan', 'controllers/dm/phf_dmDotThanhTra'], function () {
    'use strict';
    var app = angular.module('phf_nvSoanThao', ['phf_dmDoiTuong', 'phf_dmDonViPhongBan', 'phf_dmDotThanhTra']);
    app.factory('NvSoanThaoService', ['$http', 'configService', 'Upload', function ($http, configService, Upload) {
        var serviceUrl = configService.rootUrlWebApi + '/nv/phf_nvSoanThao';
        var result = {
            paging: function (data) {
                return $http.post(serviceUrl + '/Paging', data);
            },
            post: function (data) {
                return $http.post(serviceUrl + '/Post', data);
            },
            GetNewInstance: function (data) {
                return $http.post(serviceUrl + '/GetNewInstance', data);
            },
            update: function (params) {
                return $http.put(serviceUrl + '/' + params.Id, params);
            },
            deleteItem: function (params) {
                return $http.delete(serviceUrl + '/' + params.Id, params);
            },
            UploadReportFile: function (data) {
                return Upload.upload(
                    {
                        url: serviceUrl + '/UploadReportFile',
                        data: {
                            file: data.URL
                        }
                    }
                );
            },
            InsertThuMucFile: function (data) {
                return $http.post(serviceUrl + '/InsertThuMucFile', data);
            },
            UpdateThuMucFile: function (data) {
                return $http.post(serviceUrl + '/UpdateThuMucFile', data);
            },
        }
        return result;
    }]);

    app.controller('NvSoanThaoCtrl', ['$scope', '$location', 'NvSoanThaoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster', 'ngNotify', 'blockModalService', 'DmDoiTuongService', 'DmDotThanhTraService', 'DmDonViPhongBanService',
        function ($scope, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster, ngNotify, blockModalService, dmDoiTuongService, dmDotThanhTraService, dmDonViPhongBanService) {
            $scope.config = {
                label: angular.copy(configService.label)
            }
            $scope.paged = angular.copy(configService.pageDefault);
            $scope.filtered = angular.copy(configService.filterDefault);
            $scope.tempData = tempDataService.tempData;
            $scope.accessList = {};
            $scope.target = {};
            $scope.listDmDoiTuong = [];
            $scope.target.NAM = new Date().getFullYear();

            function filterData() {
                if ($scope.accessList.View) {
                    var postdata = {
                        paged: $scope.paged,
                        filtered: $scope.filtered
                    };
                    service.paging(postdata).then(function (successRes) {
                        if (successRes && successRes.status == 200 && successRes.data && !successRes.data.Error) {
                            $scope.data = successRes.data.Data.Data;
                        } else {
                            $scope.data = [];
                            $scope.paged.totalItems = 0;
                            toaster.pop('error', "Lỗi:", successRes.data.Message);
                        }
                    }, function (errorRes) {
                        console.log(errorRes);
                        toaster.pop('error', "Lỗi:", errorRes.statusText);
                    });
                }
            };

            function loadAccessList() {
                securityService.getAccessList('phf_nvSoanThao').then(function (successRes) {
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
                }, function (errorRes) {;
                    toaster.pop('error', "Lỗi:", "Không có quyền truy cập !");
                    $scope.accessList = null;
                });
            }
            loadAccessList();


            function loadDmDoiTuong() {
                dmDoiTuongService.getSelectData().then(function (successRes) {
                    $scope.listDmDoiTuong = successRes.data;
                    console.log($scope.listDmDoiTuong);
                    if (!tempDataService.tempData('listDmDoiTuong')) {
                        tempDataService.putTempData('listDmDoiTuong', successRes.data);
                    }
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmDoiTuong();

            function loadDmDotThanhTra() {
                dmDotThanhTraService.getSelectData().then(function (successRes) {
                    $scope.listDmDotThanhTra = successRes.data;
                    console.log($scope.listDmDotThanhTra);
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmDotThanhTra();


            function loadDmPhongBan() {
                dmDonViPhongBanService.getSelectDataDonVi().then(function (successRes) {
                    $scope.listDmPhongBan = successRes.data;
                    console.log($scope.listDmPhongBan);
                    if (!tempDataService.tempData('listDmPhongBan')) {
                        tempDataService.putTempData('listDmPhongBan', successRes.data);
                    }
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmPhongBan();   

            $scope.formatLabel = function (code, listData) {
                if (!code) return "";
                var data = $filter('filter')(listData, { Value: code }, true);
                if (data && data.length > 0) {
                    return data[0].Text;
                }
            };

            $scope.displayHepler = function (module, value) {
                var data = $filter('filter')($scope.tempData(module), {
                    Value: value
                }, true);
                if (data.length == 1) {
                    return data[0].Text;
                } else {
                    return value;
                }
            }

            $scope.setPage = function (pageNo) {
                $scope.paged.currentPage = pageNo;
                filterData();
            };

            $scope.sortType = 'ID';

            $scope.sortReverse = false;

            $scope.doSearch = function () {
                $scope.paged.currentPage = 1;
                $scope.filtered.AdvanceData.MA_DOITUONG = $scope.target.MA_DOITUONG;
                $scope.filtered.AdvanceData.MA_PHONGBAN = $scope.target.MA_PHONGBAN;
                $scope.filtered.AdvanceData.MA_DOT = $scope.target.MA_DOT;
                $scope.filtered.AdvanceData.NAM = $scope.target.NAM;
                $scope.filtered.IsAdvance = true;
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

            $scope.create = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    size: 'md',
                    templateUrl: configService.buildUrl('nv/phf_nvSoanThao', 'add'),
                    controller: 'NvSoanThaoCreateCtrl',
                    resolve: {}
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.refresh();
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };

            $scope.edit = function (target) {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('nv/phf_nvSoanThao', 'edit'),
                    controller: 'NvSoanThaoEditCtrl',
                    resolve: {
                        targetData: function () {
                            return target;
                        }
                    }
                });
                console.log(target);
                modalInstance.result.then(function (updatedData) {
                    var index = $scope.data.indexOf(target);
                    if (index !== -1) {
                        $scope.data[index] = updatedData;
                    }
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };

            $scope.detail = function (target) {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('nv/phf_nvSoanThao', 'detail'),
                    controller: 'NvSoanThaoDetailCtrl',
                    resolve: {
                        targetData: function () {
                            return target;
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    var index = $scope.data.indexOf(target);
                    if (index !== -1) {
                        $scope.data[index] = updatedData;
                    }
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };

            $scope.delete = function (target) {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('nv/phf_nvSoanThao', 'delete'),
                    controller: 'NvSoanThaoDeleteCtrl',
                    resolve: {
                        targetData: function () {
                            return target;
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    var index = $scope.data.indexOf(target);
                    if (index !== -1) {
                        $scope.data.splice(index, 1);
                    }
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };
        }
    ]);
    app.controller('NvSoanThaoCreateCtrl', ['$scope', '$uibModalInstance', '$location', 'NvSoanThaoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify', 'blockModalService', 'DmDoiTuongService', 'DmDonViPhongBanService',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, ngNotify, blockModalService, dmDoiTuongService, dmDonViPhongBanService) {
            $scope.config = angular.copy(configService);
            $scope.tempData = tempDataService.tempData;
            $scope.target = {};
            $scope.dataUpload = {};
            $scope.isLoading = false;
            $scope.target.NGAY_LUUTRU = new Date();
            $scope.title = function () {
                return 'Thêm mới soạn thảo';
            };

            function loadDmDoiTuong() {
                dmDoiTuongService.getSelectData().then(function (successRes) {
                    $scope.listDmDoiTuong = successRes.data;
                    console.log($scope.listDmDoiTuong);
                    if (!tempDataService.tempData('listDmDoiTuong')) {
                        tempDataService.putTempData('listDmDoiTuong', successRes.data);
                    }
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmDoiTuong();

            function loadDmPhongBan() {
                dmDonViPhongBanService.getSelectData().then(function (successRes) {
                    $scope.listDmPhongBan = successRes.data;
                    console.log($scope.listDmPhongBan);
                    if (!tempDataService.tempData('listDmPhongBan')) {
                        tempDataService.putTempData('listDmPhongBan', successRes.data);
                    }
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmPhongBan();

            function GetNewInstance() {
                service.GetNewInstance($scope.target).then(function (successRes) {
                    console.log("successRes in GetNewInstance", successRes)
                    $scope.target.MA_PHIEU = successRes.data.Data;
                }, function (errorRes) { });
            }
            GetNewInstance();

            $scope.save = function () {
                service.post($scope.target).then(function (successRes) {
                    $scope.dataUpload.SO_PHIEU = $scope.target.MA_PHIEU;
                    service.InsertThuMucFile($scope.target1).then(function (successRes1) {
                        console.log('successRes1 in InsertThuMucFile', successRes1);
                    });
                    if (successRes && successRes.status === 200 && !successRes.data.Error) {
                        ngNotify.set(successRes.data.Message, {
                            type: 'success'
                        });
                        $uibModalInstance.close($scope.target);
                    } else {
                        ngNotify.set(successRes.data.Message, {
                            duration: 3000,
                            type: 'error'
                        });
                    }
                }, function (errorRes) { });
            };

            $scope.upload = function () {
                blockModalService.setValue(true);
                $scope.resultUploadBanCung = [];
                service.UploadReportFile($scope.target).then(function (successRes) {
                    console.log('successRes in UploadReportFile', successRes);
                    $scope.dataUpload.URL = successRes.data.Data;
                    $scope.resultUploadBanCung = successRes.data;
                    blockModalService.setValue(false);
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                    blockModalService.setValue(false);
                    ngNotify.set(errorRes.statusText, { duration: 5000, type: 'error' });
                    $scope.resultUploadBanCung = false;
                }, function (evt) {
                    $scope.progressPercentageBanCung = parseInt(100.0 * evt.loaded / evt.total);
                });
                console.log($scope.target);
            };

            $scope.cancel = function () {
                $uibModalInstance.close();
            };
        }
    ]);

    app.controller('NvSoanThaoEditCtrl', ['$scope', '$uibModalInstance', '$location', 'NvSoanThaoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify', 'blockModalService', 'DmDoiTuongService', 'DmDonViPhongBanService',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify, blockModalService, dmDoiTuongService, dmDonViPhongBanService) {
            $scope.target = targetData;
            $scope.config = angular.copy(configService);
            $scope.targetData = angular.copy(targetData);
            $scope.tempData = tempDataService.tempData;
            $scope.isLoading = false;
            $scope.target.NGAY_LUUTRU = new Date();
            $scope.title = function () { return 'Cập nhật soạn thảo'; };

            $scope.save = function () {
                service.update($scope.target).then(function (successRes) {
                    if (successRes && successRes.status == 200 && !successRes.data.Error) {
                        ngNotify.set(successRes.data.Message, { type: 'success' });
                        $uibModalInstance.close($scope.target);
                    } else {
                        console.log('successRes', successRes);
                        ngNotify.set(successRes.data.Message, { duration: 3000, type: 'error' });
                    }
                },
                    function (errorRes) {
                        console.log('errorRes', errorRes);
                    });
            };
            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
            };

            function loadDmDoiTuong() {
                dmDoiTuongService.getSelectData().then(function (successRes) {
                    $scope.listDmDoiTuong = successRes.data;
                    console.log($scope.listDmDoiTuong);
                    if (!tempDataService.tempData('listDmDoiTuong')) {
                        tempDataService.putTempData('listDmDoiTuong', successRes.data);
                    }
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmDoiTuong();

            function loadDmPhongBan() {
                dmDonViPhongBanService.getSelectData().then(function (successRes) {
                    $scope.listDmPhongBan = successRes.data;
                    console.log($scope.listDmPhongBan);
                    if (!tempDataService.tempData('listDmPhongBan')) {
                        tempDataService.putTempData('listDmPhongBan', successRes.data);
                    }
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmPhongBan();

            $scope.upload = function () {
                blockModalService.setValue(true);
                $scope.resultUploadBanCung = [];
                service.UploadReportFile($scope.target).then(function (successRes) {
                    console.log('successRes in UploadReportFile', successRes);
                    $scope.target.URL = successRes.data.Data;
                    $scope.resultUploadBanCung = successRes.data;

                    blockModalService.setValue(false);
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                    blockModalService.setValue(false);
                    ngNotify.set(errorRes.statusText, { duration: 5000, type: 'error' });
                    $scope.resultUploadBanCung = false;
                }, function (evt) {
                    $scope.progressPercentageBanCung = parseInt(100.0 * evt.loaded / evt.total);
                });
                console.log($scope.target);
            };
        }]);

    app.controller('NvSoanThaoDetailCtrl', ['$scope', '$uibModalInstance', '$location', 'NvSoanThaoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'DmDoiTuongService', 'DmDonViPhongBanService',
         function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, dmDoiTuongService, dmDonViPhongBanService) {
             $scope.tempData = tempDataService.tempData;
             $scope.config = angular.copy(configService);
             $scope.target = targetData;
             $scope.title = function () { return 'Chi tiết soạn thảo'; };
             $scope.target.NGAY_LUUTRU = new Date();

             $scope.cancel = function () {
                 $uibModalInstance.dismiss('cancel');
             };

             function loadDmDoiTuong() {
                 dmDoiTuongService.getSelectData().then(function (successRes) {
                     $scope.listDmDoiTuong = successRes.data;
                     console.log($scope.listDmDoiTuong);
                     if (!tempDataService.tempData('listDmDoiTuong')) {
                         tempDataService.putTempData('listDmDoiTuong', successRes.data);
                     }
                 }, function (errorRes) {
                     toaster.pop('error', "Lỗi:", errorRes.statusText);
                 });
             }
             loadDmDoiTuong();

             function loadDmPhongBan() {
                 dmDonViPhongBanService.getSelectData().then(function (successRes) {
                     $scope.listDmPhongBan = successRes.data;
                     console.log($scope.listDmPhongBan);
                     if (!tempDataService.tempData('listDmPhongBan')) {
                         tempDataService.putTempData('listDmPhongBan', successRes.data);
                     }
                 }, function (errorRes) {
                     toaster.pop('error', "Lỗi:", errorRes.statusText);
                 });
             }
             loadDmPhongBan();

             $scope.upload = function () {
                 blockModalService.setValue(true);
                 $scope.resultUploadBanCung = [];
                 service.UploadReportFile($scope.target).then(function (successRes) {
                     console.log('successRes in UploadReportFile', successRes);
                     $scope.target.URL = successRes.data.Data;
                     $scope.resultUploadBanCung = successRes.data;

                     blockModalService.setValue(false);
                 }, function (errorRes) {
                     console.log('errorRes', errorRes);
                     blockModalService.setValue(false);
                     ngNotify.set(errorRes.statusText, { duration: 5000, type: 'error' });
                     $scope.resultUploadBanCung = false;
                 }, function (evt) {
                     $scope.progressPercentageBanCung = parseInt(100.0 * evt.loaded / evt.total);
                 });
                 console.log($scope.target);
             };

         }]);

    app.controller('NvSoanThaoDeleteCtrl', ['$scope', '$uibModalInstance', '$location', 'NvSoanThaoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify',
            function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify) {
                $scope.target = targetData;
                $scope.config = angular.copy(configService);
                $scope.targetData = angular.copy(targetData);
                $scope.isLoading = false;

                $scope.title = function () { return 'Xóa soạn thảo'; };

                $scope.save = function () {
                    service.deleteItem($scope.target).then(function (successRes) {
                        if (successRes && successRes.status == 200 && !successRes.data.Error) {
                            ngNotify.set(successRes.data.Message, { type: 'success' });
                            $uibModalInstance.close($scope.target);
                        } else {
                            console.log('successRes', successRes);
                            ngNotify.set(successRes.data.Message, { duration: 3000, type: 'error' });
                        }
                    },
                        function (errorRes) {
                            console.log('errorRes', errorRes);
                        });
                };
                $scope.close = function () {
                    $uibModalInstance.dismiss('cancel');
                };
            }]);
    return app
});