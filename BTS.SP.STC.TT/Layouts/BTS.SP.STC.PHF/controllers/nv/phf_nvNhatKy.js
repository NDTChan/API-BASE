define(['controllers/dm/phf_dmDoiTuong', 'controllers/dm/phf_dmDonViPhongBan', 'controllers/dm/phf_dmDotThanhTra', 'controllers/dm/phf_dmCanBo'], function () {
    'use strict';
    var app = angular.module('phf_nvNhatKy', ['phf_dmDoiTuong', 'phf_dmDonViPhongBan', 'phf_dmDotThanhTra', 'phf_dmCanBo']);
    app.factory('NvNhatKyService', ['$http', 'configService', 'Upload', function ($http, configService, Upload) {
        var serviceUrl = configService.rootUrlWebApi + '/nv/phf_nvNhatKy';
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
            GetUrlDownloadTemplate: function (report) {
                return $http.get(serviceUrl + '/GetUrlDownloadTemplate/' + report);
            },
            UploadReportFile: function (data) {
                return Upload.upload({
                    url: serviceUrl + '/UploadReportFile',
                    data: {
                        file: data.URL
                    }
                });
            },
            GetThuMucFileBySoPhieu: function (data) {
                return $http.get(serviceUrl + '/GetThuMucFileBySoPhieu/' + data);
            },
            InsertThuMucFile: function (data) {
                return $http.post(serviceUrl + '/InsertThuMucFile', data);
            },

            EditThuMucFile: function (params) {
                return $http.put(serviceUrl + '/EditThuMucFile', params);
            },
            DeleteThuMucFile: function (params) {
                return $http.delete(serviceUrl + '/DeleteThuMucFiles/' + params.Id);
            },
            GetLinkDownload: function (data) {
                return $http.post(serviceUrl + '/GetLinkDownload', data);
            },
        }
        return result;
    }]);
    app.controller('NvNhatKyViewCtrl', ['$scope', '$timeout', '$stateParams', '$location', 'NvNhatKyService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster', 'ngNotify', 'blockModalService', 'DmDoiTuongService', 'DmDonViPhongBanService', 'DmDotThanhTraService', 'DmCanBoService', 'CacheFactory',
        function ($scope, $timeout, $stateParams, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster, ngNotify, blockModalService, dmDoiTuongService, dmDonViPhongBanService, dmDotThanhTraService, dmCanBoService, CacheFactory) {

            $scope.config = {
                label: angular.copy(configService.label)
            }
            $scope.paged = angular.copy(configService.pageDefault);
            $scope.filtered = angular.copy(configService.filterDefault);
            //$scope.target = angular.copy($stateParams);
            $scope.target = {};
            $scope.target.MA_DOT = '';
            $scope.listDmDoiTuong = [];
            $scope.target.NAM = new Date().getFullYear();
            $scope.tempData = tempDataService.tempData;
            var dataCache = CacheFactory.get('dataCache');
            $scope.accessList = {};
            $scope.listDmCanBo = {};
            //Timeline

            //

            function loadDmDoiTuong() {
                if (!dataCache.get('listDmDoiTuong')) {
                    dmDoiTuongService.getSelectData().then(function (successRes) {
                        if (successRes && successRes.status === 200 && successRes.data.length > 0) {
                            $scope.listDmDoiTuong = successRes.data;
                            dataCache.put('listDmDoiTuong', successRes.data);

                        }
                    }, function (errorRes) {
                        console.log('errorRes', errorRes);
                    });
                } else {
                    $scope.listDmDoiTuong = dataCache.get('listDmDoiTuong');
                }
            };

            loadDmDoiTuong();

            function loadDmPhongBan() {
                dmDonViPhongBanService.getSelectDataDonVi().then(function (successRes) {
                    $scope.listDmPhongBan = successRes.data;

                    if (!tempDataService.tempData('listDmPhongBan')) {
                        tempDataService.putTempData('listDmPhongBan', successRes.data);
                    }
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmPhongBan();

            function loadDmDotThanhTra() {
                dmDotThanhTraService.getSelectData().then(function (successRes) {
                    $scope.listDmDotThanhTra = successRes.data;

                    if ($stateParams.MA_DOT != "") {
                        $scope.target.MA_DOT = $stateParams.MA_DOT;
                        $scope.doSearch();
                    }
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmDotThanhTra();
            function loadDmCanBo() {
                dmCanBoService.GetSelectData().then(function (successRes) {
                    console.log('successRes in loadDmCanBo', successRes)
                    $scope.listDmCanBo = successRes.data;
                    if (!tempDataService.tempData('listDmCanBo')) {
                        tempDataService.putTempData('listDmCanBo', successRes.data);
                    }
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmCanBo();
            function filterData() {
                if ($scope.accessList.View) {
                    var postdata = {
                        paged: $scope.paged,
                        filtered: $scope.filtered
                    };
                    service.paging(postdata).then(function (successRes) {
                        if (successRes && successRes.status == 200 && successRes.data && !successRes.data.Error) {
                            $scope.data = successRes.data.Data.Data;
                            $scope.data.map(function (index) {
                                $scope.listDmCanBo.map(function (index1) {
                                    if (index.NGUOI_BAOCAO == index1.Value) {
                                        index.NGUOI_BAOCAO = index1.Text;
                                        //  index.NGAY_LUUTRU = new Date($filter('date')(index.NGAY_LUUTRU, 'dd-MM-yyyy'));
                                    }
                                });
                            });
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
                securityService.getAccessList('phf_nvNhatKy').then(function (successRes) {
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

            $scope.displayHepler = function (module, value) {
                var data = $filter('filter')($scope.tempData(module), {
                    Value: value
                }, true);
                if (data && data.length == 1) {
                    return data[0].Text;
                } else {
                    return value;
                }
            };

            $scope.formatLabel = function (code, listData) {
                if (!code) return "";
                var data = $filter('filter')(listData, {
                    Value: code
                }, true);
                if (data && data.length > 0) {
                    return data[0].Text;
                }
            };

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
                    templateUrl: configService.buildUrl('nv/phf_nvNhatKy', 'add'),
                    controller: 'NvNhatKyCreateCtrl',
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
                    templateUrl: configService.buildUrl('nv/phf_nvNhatKy', 'edit'),
                    controller: 'NvNhatKyEditCtrl',
                    resolve: {
                        targetData: function () {
                            return target;
                        },
                        targetThuMuc: function () {
                            return
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

            $scope.detail = function (target) {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('nv/phf_nvNhatKy', 'detail'),
                    controller: 'NvNhatKyDetailCtrl',
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
            $scope.print = function (item) {
                console.log("itemp in print", item)
                service.GetUrlDownloadTemplate(item.SO_PHIEU).then(function (response) {
                    console.log(response);

                    if (response && response.status == 200 && response.data && response.data.Status && response.data.Data) {
                        var url = configService.apiServiceBaseUri + response.data.Data
                        window.open(url);
                    } else {
                        ngNotify.set(response.data.Message, {
                            duration: 2000,
                            type: 'error'
                        });
                    }
                });
            };
            $scope.delete = function (target) {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('nv/phf_nvNhatKy', 'delete'),
                    controller: 'NvNhatKyDeleteCtrl',
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
    app.controller('NvNhatKyCreateCtrl', ['$scope', '$uibModalInstance', '$location', 'NvNhatKyService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify', 'blockModalService', 'DmDoiTuongService', 'DmDonViPhongBanService', 'DmDotThanhTraService', 'DmCanBoService',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, ngNotify, blockModalService, dmDoiTuongService, dmDonViPhongBanService, dmDotThanhTraService, dmCanBoService) {
            $scope.config = angular.copy(configService);
            $scope.tempData = tempDataService.tempData;
            $scope.target = {};
            $scope.dataUpload = {};
            $scope.isLoading = false;
            $scope.target.TRANG_THAI = "1";
            $scope.target.NGAY_LUUTRU = new Date();
            $scope.target.TU_NGAY = new Date();
            $scope.target.TU_NGAY.setDate($scope.target.TU_NGAY.getDate() - 7);
            $scope.target.DEN_NGAY = new Date();
            $scope.target.NAM = $scope.target.NGAY_LUUTRU.getFullYear();
            $scope.title = function () {
                return 'Thêm mới nhật ký';
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
            };
            $scope.formatLabel = function (code, listData) {
                if (!code) return "";
                var data = $filter('filter')(listData, {
                    Value: code
                }, true);
                if (data && data.length > 0) {
                    return data[0].Text;
                }
            };

            function loadDmDoiTuong() {
                dmDoiTuongService.getSelectData().then(function (successRes) {
                    $scope.listDmDoiTuong = successRes.data;
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
                    if (!tempDataService.tempData('listDmPhongBan')) {
                        tempDataService.putTempData('listDmPhongBan', successRes.data);
                    }
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmPhongBan();


            function loadDmDotThanhTra() {
                dmDotThanhTraService.getSelectData().then(function (successRes) {
                    $scope.listDmDotThanhTra = successRes.data;
                    if (!tempDataService.tempData('listDmDotThanhTra')) {
                        tempDataService.putTempData('listDmDotThanhTra', successRes.data);
                    }
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmDotThanhTra();

            function loadDmCanBo() {
                dmCanBoService.GetSelectData().then(function (successRes) {
                    console.log('successRes in loadDmCanBo', successRes)
                    $scope.listDmCanBo = successRes.data;
                    if (!tempDataService.tempData('listDmCanBo')) {
                        tempDataService.putTempData('listDmCanBo', successRes.data);
                    }
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmCanBo();

            function GetNewInstance() {
                service.GetNewInstance($scope.target).then(function (successRes) {
                    $scope.target.SO_PHIEU = successRes.data.Data;
                }, function (errorRes) { });
            }
            GetNewInstance();

            $scope.save = function () {
                console.log('$scope.target.SO_PHIEU in GetNewInstance', $scope.target)
                service.post($scope.target).then(function (successRes) {

                    $scope.dataUpload.SO_PHIEU = $scope.target.SO_PHIEU;
                    service.InsertThuMucFile($scope.dataUpload).then(function (successRes1) { });
                    if (successRes && successRes.status === 200 && !successRes.data.Error) {
                        ngNotify.set(successRes.data.Message, {
                            type: 'success'
                        });
                        $uibModalInstance.close($scope.target);
                        $state.go($state.current, {}, { reload: true });
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
                    console.log('successRes in UploadReportFile', successRes)
                    $scope.target.TENTEP = successRes.data.Message;
                    $scope.dataUpload.URL = successRes.data.Data;
                    $scope.dataUpload.TEN_FILE = successRes.data.Message;
                    $scope.resultUploadBanCung = successRes.data;
                    blockModalService.setValue(false);
                }, function (errorRes) {
                    blockModalService.setValue(false);
                    ngNotify.set(errorRes.statusText, {
                        duration: 5000,
                        type: 'error'
                    });
                    $scope.resultUploadBanCung = false;
                }, function (evt) {
                    $scope.progressPercentageBanCung = parseInt(100.0 * evt.loaded / evt.total);
                });
            };
            $scope.cancel = function () {
                $uibModalInstance.close();
            };

        }
    ]);
    app.controller('NvNhatKyEditCtrl', ['$scope', '$window', '$uibModalInstance', '$location', 'NvNhatKyService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify', 'blockModalService', 'DmDoiTuongService', 'DmDonViPhongBanService', 'DmDotThanhTraService', 'DmCanBoService',
        function ($scope, $window, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify, blockModalService, dmDoiTuongService, dmDonViPhongBanService, dmDotThanhTraService, dmCanBoService) {
            $scope.target = targetData;
            $scope.config = angular.copy(configService);
            $scope.targetData = angular.copy(targetData);
            $scope.dataUpload = {};
            $scope.dataUpload.SO_PHIEU = $scope.target.SO_PHIEU;
            $scope.tempData = tempDataService.tempData;
            $scope.isLoading = false;
            $scope.title = function () {
                return 'Cập nhật Nhật Ký';
            };
            if (targetData.NGAY_LUUTRU != null)
                $scope.target.NGAY_LUUTRU = new Date($filter('date')(targetData.NGAY_LUUTRU, 'yyyy-MM-dd'));
            if (targetData.TU_NGAY != null)
                $scope.target.TU_NGAY = new Date($filter('date')(targetData.TU_NGAY, 'yyyy-MM-dd'));
            if (targetData.DEN_NGAY != null)
                $scope.target.DEN_NGAY = new Date($filter('date')(targetData.DEN_NGAY, 'yyyy-MM-dd'));
            $scope.listDmPhongBan = [];
            $scope.listDmDotThanhTra = [];
            $scope.listDmDoiTuong = [];
            $scope.listDmCanBo = [];
            $scope.getDoiTuongByMa = {};
            $scope.getDotByMa = {};
            $scope.getPhongBanByMa = {};
            $scope.getCanBoByMa = {};
            console.log('$scope.target in NvNhatKyEditCtrl', $scope.target)
            $scope.displayHepler = function (module, value) {
                var data = $filter('filter')($scope.tempData(module), {
                    Value: value
                }, true);
                if (data.length == 1) {
                    return data[0].Text;
                } else {
                    return value;
                }
            };
            $scope.formatLabel = function (code, listData) {
                if (!code) return "";
                var data = $filter('filter')(listData, {
                    Value: code
                }, true);
                if (data && data.length > 0) {
                    return data[0].Text;
                }
            };

            function loadDmDoiTuong() {
                dmDoiTuongService.getSelectData().then(function (successRes) {
                    $scope.listDmDoiTuong = successRes.data;
                    if (!tempDataService.tempData('listDmDoiTuong')) {
                        tempDataService.putTempData('listDmDoiTuong', successRes.data);
                    }
                    $scope.listDmDoiTuong.forEach(element => {
                        if (element.Value === $scope.target.MA_DOITUONG) {
                            $scope.getDoiTuongByMa = element.Text;
                        }

                    })
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmDoiTuong();

            function loadDmPhongBan() {
                dmDonViPhongBanService.getSelectData().then(function (successRes) {
                    $scope.listDmPhongBan = successRes.data;
                    if (!tempDataService.tempData('listDmPhongBan')) {
                        tempDataService.putTempData('listDmPhongBan', successRes.data);
                    }
                    $scope.listDmPhongBan.forEach(element => {
                        if (element.Value === $scope.target.MA_PHONGBAN) {
                            $scope.getPhongBanByMa = element.Text;
                        }

                    })
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmPhongBan();


            function loadDmDotThanhTra() {
                dmDotThanhTraService.getSelectData().then(function (successRes) {
                    $scope.listDmDotThanhTra = successRes.data;
                    if (!tempDataService.tempData('listDmPhongBan')) {
                        tempDataService.putTempData('listDmPhongBan', successRes.data);
                    }
                    $scope.listDmDotThanhTra.forEach(element => {
                        if (element.Value === $scope.target.MA_DOT) {
                            $scope.getDotByMa = element.Text;
                        }

                    })
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmDotThanhTra();

            function loadDmCanBo() {
                dmCanBoService.GetSelectData().then(function (successRes) {
                    console.log('successRes in loadDmCanBo', successRes)
                    $scope.listDmCanBo = successRes.data;
                    if (!tempDataService.tempData('listDmCanBo')) {
                        tempDataService.putTempData('listDmCanBo', successRes.data);
                    }
                    $scope.listDmCanBo.forEach(element => {
                        if (element.Value === $scope.target.NGUOI_BAOCAO) {
                            $scope.getCanBoByMa = element.Text;
                        }
                    })
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmCanBo();



            function GETIDTHUMUC() {
                service.GetThuMucFileBySoPhieu($scope.dataUpload.SO_PHIEU).then(function (successRes) {
                    if (successRes && successRes.status == 200 && !successRes.data.Error) {
                        $scope.dataUpload.Id = successRes.data.Data;
                    } else { }
                },
                    function (errorRes) { });
            }
            GETIDTHUMUC();
            $scope.save = function () {
                service.update($scope.target).then(function (successRes1) {
                    if (successRes1 && successRes1.status == 200 && !successRes1.data.Error) {
                        // ngNotify.set(successRes.data.Message, { type: 'success' });
                        // $uibModalInstance.close($scope.target);

                        service.EditThuMucFile($scope.dataUpload).then(function (successRes) {
                            if (successRes && successRes.status == 200 && !successRes.data.Error) {
                                ngNotify.set(successRes.data.Message, {
                                    type: 'success'
                                });
                                $uibModalInstance.close($scope.target);
                                $state.go($state.current, {}, { reload: true });
                            } else {
                                ngNotify.set(successRes.data.Message, {
                                    duration: 3000,
                                    type: 'error'
                                });
                            }
                        },
                            function (errorRes) { });

                    } else {
                        ngNotify.set(successRes1.data.Message, {
                            duration: 3000,
                            type: 'error'
                        });
                    }


                },
                    function (errorRes) { });
            };
            $scope.upload = function () {
                blockModalService.setValue(true);
                $scope.resultUploadBanCung = [];
                service.UploadReportFile($scope.target).then(function (successRes) {
                    console.log('successRes in UploadReportFile', successRes)
                    $scope.target.TENTEP = successRes.data.Message;
                    $scope.dataUpload.URL = successRes.data.Data;
                    $scope.dataUpload.TEN_FILE = successRes.data.Message;
                    $scope.resultUploadBanCung = successRes.data;
                    blockModalService.setValue(false);
                }, function (errorRes) {
                    blockModalService.setValue(false);
                    ngNotify.set(errorRes.statusText, {
                        duration: 5000,
                        type: 'error'
                    });
                    $scope.resultUploadBanCung = false;
                }, function (evt) {
                    $scope.progressPercentageBanCung = parseInt(100.0 * evt.loaded / evt.total);
                });
            };
            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
            };
        }
    ]);
    app.controller('NvNhatKyDetailCtrl', ['$scope', '$uibModalInstance', '$location', 'NvNhatKyService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'DmDoiTuongService', 'DmDonViPhongBanService', 'DmDotThanhTraService', 'DmCanBoService',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, dmDoiTuongService, dmDonViPhongBanService, dmDotThanhTraService, dmCanBoService) {
            $scope.tempData = tempDataService.tempData;
            $scope.config = angular.copy(configService);
            $scope.target = targetData;
            $scope.title = function () {
                return 'Chi tiết nhật ký';
            };
            if (targetData.NGAY_LUUTRU != null)
                $scope.target.NGAY_LUUTRU = new Date($filter('date')(targetData.NGAY_LUUTRU, 'yyyy-MM-dd'));
            if (targetData.TU_NGAY != null)
                $scope.target.TU_NGAY = new Date($filter('date')(targetData.TU_NGAY, 'yyyy-MM-dd'));
            if (targetData.DEN_NGAY != null)
                $scope.target.DEN_NGAY = new Date($filter('date')(targetData.DEN_NGAY, 'yyyy-MM-dd'));

            function loadDmDoiTuong() {
                dmDoiTuongService.getSelectData().then(function (successRes) {
                    $scope.listDmDoiTuong = successRes.data;
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
                    if (!tempDataService.tempData('listDmPhongBan')) {
                        tempDataService.putTempData('listDmPhongBan', successRes.data);
                    }
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmPhongBan();


            function loadDmDotThanhTra() {
                dmDotThanhTraService.getSelectData().then(function (successRes) {
                    $scope.listDmDotThanhTra = successRes.data;
                    if (!tempDataService.tempData('listDmPhongBan')) {
                        tempDataService.putTempData('listDmPhongBan', successRes.data);
                    }
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmDotThanhTra();

            function loadDmCanBo() {
                dmCanBoService.GetSelectData().then(function (successRes) {
                    console.log('successRes in loadDmCanBo', successRes)
                    $scope.listDmCanBo = successRes.data;
                    if (!tempDataService.tempData('listDmCanBo')) {
                        tempDataService.putTempData('listDmCanBo', successRes.data);
                    }
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmCanBo();
            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
            };
        }
    ]);
    app.controller('NvNhatKyDeleteCtrl', ['$scope', '$uibModalInstance', '$location', 'NvNhatKyService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify) {
            $scope.target = targetData;
            $scope.config = angular.copy(configService);
            $scope.targetData = angular.copy(targetData);
            $scope.isLoading = false;
            $scope.dataUpload = {}

            $scope.dataUpload.SO_PHIEU = $scope.target.SO_PHIEU;
            $scope.title = function () {
                return 'Xóa nhật ký';
            };
            $scope.save = function () {
                service.deleteItem($scope.target).then(function (successRes1) {
                    if (successRes1 && successRes1.status == 200 && !successRes1.data.Error) {
                        ngNotify.set(successRes1.data.Message, {
                            type: 'success'
                        });
                        $uibModalInstance.close($scope.target);
                    } else {
                        ngNotify.set(successRes1.data.Message, {
                            duration: 3000,
                            type: 'error'
                        });
                    }
                },
                    function (errorRes) { });
            };
            $scope.close = function () {
                $uibModalInstance.dismiss('cancel');
            };
        }
    ]);
    return app
});