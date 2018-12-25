define(['controllers/dm/phf_dmDonViPhongBan', 'controllers/dm/phf_dmCanBo', 'controllers/dm/phf_dmDotThanhTra',
    'controllers/dm/phf_dmChucVu', 'controllers/dm/phf_dmDonViPhongBan', 'controllers/dm/phf_dmDoiTuong'], function () {
        'use strict';
        var app = angular.module('phf_nvTheoDoiCanBo', ['phf_dmDonViPhongBan', 'phf_dmCanBo', 'phf_dmDotThanhTra', 'phf_dmChucVu', 'phf_dmDoiTuong']);
        app.factory('TheoDoiCanBoService', ['$http', 'configService', function ($http, configService) {
            var serviceUrl = configService.rootUrlWebApi + '/nv/phf_nvTheoDoiCanBo';
            var result = {
                paging: function (data) {
                    return $http.post(serviceUrl + '/Paging', data);
                },
                post: function (data) {
                    return $http.post(serviceUrl + '/Post', data);
                },
                getItem: function (id) {
                    return $http.get(serviceUrl + '/' + id);
                },
                update: function (params) {
                    return $http.put(serviceUrl + '/' + params.Id, params);
                },
                deleteItem: function (params) {
                    return $http.delete(serviceUrl + '/' + params.Id, params);
                },
                getSelectData: function () {
                    return $http.get(serviceUrl + '/GetSelectData');
                },
                Export: function (data) {
                    return $http.post(serviceUrl + '/Export', data, { responseType: 'arraybuffer' });
                },
                getMaxID: function () {
                    return $http.get(serviceUrl + '/GetMaxID');
                },
                GetDetailByRefId: function (refid) {
                    return $http.get(serviceUrl + '/GetDetailByRefId/' + refid);
                },
                getListUserByMaDot: function (maDot) {
                    return $http.get(serviceUrl + '/GetListUserByMaDot/' + maDot);
                }
            }
            return result;
        }]);

        app.controller('TheoDoiCanBoViewCtrl', ['$scope', '$location', 'TheoDoiCanBoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster', 'ngNotify', 'DmDoiTuongService', 'DmDonViPhongBanService', 'DmDotThanhTraService', 'CacheFactory',
        function ($scope, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster, ngNotify, dmDoiTuongService, dmDonViPhongBanService, dmDotThanhTraService, CacheFactory) {
            $scope.config = {
                label: angular.copy(configService.label)
            }
            $scope.paged = angular.copy(configService.pageDefault);
            $scope.filtered = angular.copy(configService.filterDefault);
            $scope.tempData = tempDataService.tempData;
            $scope.accessList = {};
            var dataCache = CacheFactory.get('dataCache');
            $scope.target = {};
            $scope.target.NAM = new Date().getFullYear();
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
                        console.log(errorRes);
                        toaster.pop('error', "Lỗi:", errorRes.statusText);
                    });
                }
            };

            function loadAccessList() {
                securityService.getAccessList('phf_nvTheoDoiCanBo').then(function (successRes) {
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

            function loadDmDoiTuong() {
                if (!dataCache.get('listDmDoiTuong')) {
                    dmDoiTuongService.getSelectData().then(function (successRes) {
                        if (successRes && successRes.status === 200 && successRes.data.length > 0) {
                            $scope.listDmDoiTuong = successRes.data;
                            dataCache.put('listDmDoiTuong', successRes.data);
                        }
                    }
					, function (errorRes) {
					    console.log('errorRes', errorRes);
					});
                }
                else {
                    $scope.listDmDoiTuong = dataCache.get('listDmDoiTuong');
                }
            };
            loadDmDoiTuong();

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

            function loadDmDotThanhTra() {
                dmDotThanhTraService.getSelectData().then(function (successRes) {
                    $scope.listDmDotThanhTra = successRes.data;
                    console.log($scope.listDmDotThanhTra);
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
            loadDmDotThanhTra();

            $scope.displayHepler = function (module, value) {
                var data = $filter('filter')($scope.tempData(module), { Value: value }, true);
                if (data.length == 1) {
                    return data[0].Text;
                } else {
                    return value;
                }
            }

            $scope.formatLabel = function (code, listData) {
                if (!code) return "";
                var data = $filter('filter')(listData, { Value: code }, true);
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
                    windowClass: 'app-modal-window',
                    templateUrl: configService.buildUrl('nv/phf_nvTheoDoiCanBo', 'add'),
                    controller: 'TheoDoiCanBoCreateViewCtrl',
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
                    templateUrl: configService.buildUrl('nv/phf_nvTheoDoiCanBo', 'edit'),
                    controller: 'TheoDoiCanBoEditViewCtrl',
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
            $scope.detail = function (target) {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('nv/phf_nvTheoDoiCanBo', 'detail'),
                    controller: 'TheoDoiCanBoDetailViewCtrl',
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
                    templateUrl: configService.buildUrl('nv/phf_nvTheoDoiCanBo', 'delete'),
                    controller: 'TheoDoiCanBoDeleteViewCtrl',
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

        }]);

        app.controller('TheoDoiCanBoCreateViewCtrl', ['$scope', '$timeout', '$uibModalInstance', '$location', 'TheoDoiCanBoService', 'DmDotThanhTraService', 'DmChucVuService', 'DmDonViPhongBanService', 'DmDoiTuongService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify',
        function ($scope, $timeout, $uibModalInstance, $location, service, DmDotThanhTraService, DmChucVuService, DmDonViPhongBanService, DmDoiTuongService, configService, $state, tempDataService, $filter, $uibModal, $log, ngNotify) {
            $scope.config = angular.copy(configService);
            $scope.tempData = tempDataService.tempData;
            $scope.target = {};
            $scope.target.MA_PHIEU = "";
            $scope.target.NAM_THANHTRA = (new Date()).getFullYear();
            $scope.target.DETAILS = [];
            $scope.lstDmDotThanhTra = [];
            $scope.lstDmDoiTuong = [];
            $scope.lstDmChucVu = [];
            $scope.lstDmPhongBan = [];
            $scope.isLoading = false;
            $scope.title = function () { return 'Thêm mới tiến độ thực hiện'; };
            $scope.formatLabel = function (model, module) {
                console.log('module', module);
                if (!model) return "";
                var data = $filter('filter')(module, { Value: model }, true);
                if (data && data.length == 1) {
                    return data[0].Value + ' - ' + data[0].Text;
                }
                return "";
            };
            function setMaPhieu() {
                service.getMaxID().then(function (successRes) {
                    if (successRes && successRes.status == 200 && !successRes.data.Error) {
                        $scope.target.MA_PHIEU = successRes.data;
                    } else {
                        console.log('successRes', successRes);
                        ngNotify.set(successRes.data.Message, { duration: 3000, type: 'error' });
                    }
                },
                function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            setMaPhieu();
            $scope.changeDotThanhTra = function (maDot) {
                service.getListUserByMaDot(maDot).then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        console.log("lisstttttt", successRes);
                        $scope.target.DETAILS = successRes.data.Data;
                        for (var i = 0; i < $scope.target.DETAILS.length; i++) {
                            if ($scope.target.DETAILS[i].NGAY_SINH != null) {
                                $scope.target.DETAILS[i].NGAY_SINH = new Date($scope.target.DETAILS[i].NGAY_SINH);
                            }
                        }
                        console.log("successResDetails", successRes);
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            function loadDmDoiTuong() {
                DmDoiTuongService.getSelectData().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.lstDmDoiTuong = successRes.data;
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            loadDmDoiTuong();
            function loadDotThanhTra() {
                DmDotThanhTraService.getSelectData().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        console.log("lstDmDotThanhTra", successRes.data);
                        $scope.lstDmDotThanhTra = successRes.data;
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            loadDotThanhTra();
            function loadDmChucVu() {
                DmChucVuService.getSelectData().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.lstDmChucVu = successRes.data;
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            loadDmChucVu();
            function loadDmPhongBan() {
                DmDonViPhongBanService.getSelectData().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.lstDmPhongBan = successRes.data;
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            loadDmPhongBan();
            $scope.addRow = function () {
                var newItemTemp = angular.copy($scope.newItem);
                $scope.target.DETAILS.push(newItemTemp);
                $scope.pageChanged();
            };
            $scope.add = function () {
                service.post($scope.target).then(function (successRes) {
                    if (successRes && successRes.status === 200 && !successRes.data.Error) {
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
                $uibModalInstance.close();
            };
        }]);

        app.controller('TheoDoiCanBoEditViewCtrl', ['$scope', '$timeout', '$uibModalInstance', '$location', 'TheoDoiCanBoService', 'DmDotThanhTraService', 'DmChucVuService', 'DmDonViPhongBanService', 'DmDoiTuongService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify',
        function ($scope, $timeout, $uibModalInstance, $location, service, DmDotThanhTraService, DmChucVuService, DmDonViPhongBanService, DmDoiTuongService, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify) {
            $timeout(function () {
                $scope.target = targetData;
                $scope.target.DETAILS = [];
                console.log("targetDatatargetData", targetData);
                $scope.targetData = angular.copy(targetData);
                loadDataDetails();
            }, 250);
            $scope.lstDmDotThanhTra = [];
            $scope.lstDmDoiTuong = [];
            $scope.lstDmChucVu = [];
            $scope.lstDmPhongBan = [];
            $scope.config = angular.copy(configService);
            $scope.isLoading = false;
            $scope.formatLabel = function (model, module) {
                console.log('module', module);
                if (!model) return "";
                var data = $filter('filter')(module, { Value: model }, true);
                if (data && data.length == 1) {
                    return data[0].Value + ' - ' + data[0].Text;
                }
                return "";
            };

            $scope.title = function () { return 'Cập nhật tiến độ thực hiện'; };

            $scope.changeDotThanhTra = function (maDot) {
                service.getListUserByMaDot(maDot).then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        console.log("lisstttttt", successRes);
                        $scope.target.DETAILS = successRes.data.Data;
                        for (var i = 0; i < $scope.target.DETAILS.length; i++) {
                            if ($scope.target.DETAILS[i].NGAY_SINH != null) {
                                $scope.target.DETAILS[i].NGAY_SINH = new Date($scope.target.DETAILS[i].NGAY_SINH);
                            }
                        }
                        console.log("successResDetails", successRes);
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            function loadDotThanhTra() {
                DmDotThanhTraService.getSelectData().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.lstDmDotThanhTra = successRes.data;
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            loadDotThanhTra();
            function loadDmChucVu() {
                DmChucVuService.getSelectData().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.lstDmChucVu = successRes.data;
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            loadDmChucVu();
            function loadDmPhongBan() {
                DmDonViPhongBanService.getSelectData().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.lstDmPhongBan = successRes.data;
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            loadDmPhongBan();
            $scope.addRow = function () {
                var newItemTemp = angular.copy($scope.newItem);
                $scope.target.DETAILS.push(newItemTemp);
                $scope.pageChanged();
            };
            function loadDataDetails() {
                service.GetDetailByRefId($scope.target.MA_PHIEU).then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        console.log("successResDe", successRes);
                        $scope.target.DETAILS = successRes.data.Data.DETAILS;
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            //loadDataDetails();
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

        }]);

        app.controller('TheoDoiCanBoDetailViewCtrl', ['$scope', '$uibModalInstance', '$location', 'TheoDoiCanBoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData) {
            $scope.tempData = tempDataService.tempData;
            $scope.config = tempDataService.config;
            $scope.target = targetData;
            $scope.title = function () { return 'Chi tiết trạng thái dự án'; };

            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
            };

        }]);

        app.controller('TheoDoiCanBoDeleteViewCtrl', ['$scope', '$uibModalInstance', '$location', 'TheoDoiCanBoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify',
            function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify) {
                $scope.target = targetData;
                $scope.config = angular.copy(configService);
                $scope.targetData = angular.copy(targetData);
                $scope.isLoading = false;

                $scope.title = function () { return 'Xóa tiến độ thực hiện dự án?'; };

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
        return app;
    });