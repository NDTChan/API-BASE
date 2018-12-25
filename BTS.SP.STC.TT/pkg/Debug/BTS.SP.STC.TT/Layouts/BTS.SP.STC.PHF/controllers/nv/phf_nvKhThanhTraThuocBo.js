define(['controllers/dm/phf_dmKeHoachThanhTra', 'controllers/dm/phf_dmLoaiThanhTra', 'controllers/dm/phf_dmNhomThanhTra', 'controllers/dm/phf_dmDoiTuong', 'controllers/dm/phf_dmDonViPhongBan', 'controllers/dm/phf_dmDotThanhTra'], function () {
    'use strict';
    var app = angular.module('phf_KeHoachThanhTraThuocBo', ['phf_dmKeHoachThanhTra', 'phf_dmLoaiThanhTra', 'phf_dmNhomThanhTra', 'phf_dmDoiTuong', 'phf_dmDonViPhongBan', 'phf_dmDotThanhTra']);

    app.factory('KeHoachThanhTraThuocBoService', [
        '$http', 'configService', function ($http, configService) {
            var serviceUrl = configService.rootUrlWebApi + '/nv/phf_nvXayDungKeHoachThuocBo';
            var result = {
                taoMaChungTu: function () {
                    return $http.get(serviceUrl + '/TaoMaChungTu');
                },
                paging: function (data) {
                    return $http.post(serviceUrl + '/Paging', data);
                },
                post: function (data) {
                    return $http.post(serviceUrl + '/AddNew', data);
                },
                update: function (params) {
                    return $http.put(serviceUrl + '/' + params.Id, params);
                },
                deleteItem: function (params) {
                    return $http.delete(serviceUrl + '/' + params.Id, params);
                },
                getDetails: function (params) {
                    return $http.post(serviceUrl + '/GetDetails', params);
                },
                getNewInstance: function () {
                    return $http.get(serviceUrl + '/GetNewInstance');
                },
                GetDetailByRefId: function (refid) {
                    return $http.get(serviceUrl + '/GetDetailByRefId/' + refid);
                },
                UpdateThuMucFile: function (data) {
                    return $http.post(serviceUrl + '/UpdateThuMucFile', data);
                },
            }
            return result;
        }
    ]);

    app.controller('KeHoachThanhTraThuocBoViewCtrl', ['$scope', '$stateParams', '$location', 'KeHoachThanhTraThuocBoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster', 'ngNotify', 'DmDoiTuongService', 'DmDonViPhongBanService', 'DmDotThanhTraService', 'CacheFactory',
    function ($scope, $stateParams, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster, ngNotify, dmDoiTuongService, dmDonViPhongBanService, dmDotThanhTraService, CacheFactory) {
        console.log($stateParams);
        $scope.config = {
            label: angular.copy(configService.label)
        }
        $scope.paged = angular.copy(configService.pageDefault);
        $scope.filtered = angular.copy(configService.filterDefault);
        $scope.filtered.AdvanceData.NAM = new Date().getFullYear();
        $scope.tempData = tempDataService.tempData;
        $scope.accessList = {};
        $scope.target = {};
        var dataCache = CacheFactory.get('dataCache');

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
            securityService.getAccessList('phf_nvKhThanhTraThuocBo').then(function (successRes) {
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
            dmDonViPhongBanService.getSelectDataDonViTB().then(function (successRes) {
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
                if ($stateParams.MA_DOT != "") {
                    $scope.filtered.AdvanceData.MA_DOT = $stateParams.MA_DOT;
                    $scope.doSearch();
                }
            }, function (errorRes) {
                toaster.pop('error', "Lỗi:", errorRes.statusText);
            });
        }
        loadDmDotThanhTra();

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
                templateUrl: configService.buildUrl('nv/phf_nvKhThanhTraThuocBo', 'add'),
                controller: 'KeHoachThanhTraThuocBoCreateViewCtrl',
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
                windowClass: 'app-modal-window',
                templateUrl: configService.buildUrl('nv/phf_nvKhThanhTraThuocBo', 'edit'),
                controller: 'KeHoachThanhTraThuocBoEditViewCtrl',
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
                windowClass: 'app-modal-window',
                templateUrl: configService.buildUrl('nv/phf_nvKhThanhTraThuocBo', 'detail'),
                controller: 'KeHoachThanhTraThuocBoDetailViewCtrl',
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
                templateUrl: configService.buildUrl('nv/phf_nvKhThanhTraThuocBo', 'delete'),
                controller: 'KeHoachThanhTraThuocBoDeleteViewCtrl',
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

    app.controller('KeHoachThanhTraThuocBoCreateViewCtrl', ['$scope', '$uibModalInstance', '$location', 'KeHoachThanhTraThuocBoService', 'DmKeHoachThanhTraService', 'IDM_SYS_TUDIENService', 'DmNhomThanhTraService', 'DmDoiTuongService', 'DmDonViPhongBanService', 'DmDotThanhTraService',
        'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify', 'blockModalService',
        function ($scope, $uibModalInstance, $location, service, DmKeHoachThanhTraService, IDM_SYS_TUDIENService, DmNhomThanhTraService, DmDoiTuongService, DmDonViPhongBanService, DmDotThanhTraService,
            configService, $state, tempDataService, $filter, $uibModal, $log, ngNotify, blockModalService) {
            $scope.config = angular.copy(configService);
            $scope.tempData = tempDataService.tempData;
            $scope.lstDmDotThanhTra = [];
            $scope.lstDmKeHoachThanhTra = [];
            $scope.lstDmLoaiThanhTra = [];
            $scope.lstDmNhomThanhTra = [];
            $scope.lstDmPhongThanhTra = [];
            $scope.lstDmDoiTuongThanhTra = [];
            $scope.target = {};
            $scope.isLoading = false;
            $scope.title = function () { return 'Thêm mới phân công kế hoạch thanh tra, kiểm tra'; };

            $scope.formatLabel = function (model, module) {
                console.log('module', module);
                if (!model) return "";
                var data = $filter('filter')(module, { Value: model }, true);
                if (data && data.length == 1) {
                    return data[0].Value + ' - ' + data[0].Text;
                }
                return "";
            };

            function GetNewInstance() {
                service.getNewInstance($scope.target).then(function (successRes) {
                    console.log("successRes in GetNewInstance", successRes)
                    $scope.target = successRes.data.Data;
                    $scope.target.NGAY_LUU_DL = new Date($scope.target.NGAY_LUU_DL);
                }, function (errorRes) { });

            }
            GetNewInstance();

            function loadDmDotThanhTra() {
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
            loadDmDotThanhTra();

            function loadDmPhongThanhTra() {
                DmDonViPhongBanService.getSelectDataDonViTB().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.lstDmPhongThanhTra = successRes.data;
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            loadDmPhongThanhTra();

            function loadDmKeHoachThanhTra() {
                DmKeHoachThanhTraService.getSelectData().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.lstDmKeHoachThanhTra = successRes.data;
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            loadDmKeHoachThanhTra();
            function loadDmLoaiThanhTra() {
                IDM_SYS_TUDIENService.getSelectData().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.lstDmLoaiThanhTra = successRes.data;
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            loadDmLoaiThanhTra();
            function loadDmNhomThanhTra() {
                DmNhomThanhTraService.getSelectData().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.lstDmNhomThanhTra = successRes.data;
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            loadDmNhomThanhTra();
            function loadDmDoiTuongThanhTra() {
                DmDoiTuongService.getSelectData().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.lstDmDoiTuongThanhTra = successRes.data;
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            loadDmDoiTuongThanhTra();

            $scope.formatLabel = function (code, listData) {
                if (!code) return "";
                var data = $filter('filter')(listData, { Value: code }, true);
                if (data && data.length > 0) {
                    return data[0].Text;
                }
            };

            $scope.addRow = function () {
                var newItemTemp = angular.copy($scope.newItem);
                $scope.target.DETAILS.push(newItemTemp);
                $scope.pageChanged();
            };

            $scope.removeItem = function (index) {
                var currentPageIndex = 0;
                var currentPage = $scope.paged.currentPage;
                var itemsPerPage = $scope.paged.itemsPerPage;
                currentPageIndex = (currentPage - 1) * itemsPerPage + index;
                $scope.target.DETAILS.splice(currentPageIndex, 1);
                $scope.pageChanged();
            }

            $scope.pageChanged = function () {
                var currentPage = $scope.paged.currentPage;
                $scope.itemsPerPage = 5;
                $scope.paged.totalItems = $scope.target.DETAILS.length;
                $scope.data = [];
                if ($scope.target.DETAILS) {
                    for (var i = (currentPage - 1) * $scope.itemsPerPage; i < currentPage * $scope.itemsPerPage && i < $scope.target.DETAILS.length; i++) {
                        $scope.data.push($scope.target.DETAILS[i]);
                    }
                }
            }

            $scope.save = function () {
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

    app.controller('KeHoachThanhTraThuocBoEditViewCtrl', ['$scope', '$uibModalInstance', '$location', 'KeHoachThanhTraThuocBoService', 'DmKeHoachThanhTraService', 'IDM_SYS_TUDIENService', 'DmNhomThanhTraService', 'DmDoiTuongService', 'DmDonViPhongBanService', 'DmDotThanhTraService',
        'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify', '$timeout',
        function ($scope, $uibModalInstance, $location, service, DmKeHoachThanhTraService, IDM_SYS_TUDIENService, DmNhomThanhTraService, DmDoiTuongService, DmDonViPhongBanService, DmDotThanhTraService,
            configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify, $timeout) {
            $scope.target = targetData;
            $scope.targetData = angular.copy(targetData);
            $scope.config = angular.copy(configService);
            $scope.isLoading = false;
            $scope.target = {};
            $scope.lstDmDotThanhTra = [];
            $scope.lstDmKeHoachThanhTra = [];
            $scope.lstDmLoaiThanhTra = [];
            $scope.lstDmNhomThanhTra = [];
            $scope.lstDmPhongThanhTra = [];
            $scope.lstDmDoiTuongThanhTra = [];

            $scope.title = function () { return 'Cập nhật phân công kế hoạch thanh tra, kiểm tra'; };

            function loadDmDotThanhTra() {
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
            loadDmDotThanhTra();

            function loadDmKeHoachThanhTra() {
                DmKeHoachThanhTraService.getSelectData().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.lstDmKeHoachThanhTra = successRes.data;
                        console.log($scope.lstDmKeHoachThanhTra);
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            loadDmKeHoachThanhTra();

            function loadDmLoaiThanhTra() {
                IDM_SYS_TUDIENService.getSelectData().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.lstDmLoaiThanhTra = successRes.data;
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            loadDmLoaiThanhTra();

            function loadDmNhomThanhTra() {
                DmNhomThanhTraService.getSelectData().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.lstDmNhomThanhTra = successRes.data;
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            loadDmNhomThanhTra();

            function loadDmDoiTuongThanhTra() {
                DmDoiTuongService.getSelectData().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.lstDmDoiTuongThanhTra = successRes.data;
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            loadDmDoiTuongThanhTra();

            function loadDmPhongThanhTra() {
                DmDonViPhongBanService.getSelectDataDonViTB().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.lstDmPhongThanhTra = successRes.data;
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            loadDmPhongThanhTra();

            $scope.formatLabel = function (model, module) {
                console.log('module', module);
                if (!model) return "";
                var data = $filter('filter')(module, { Value: model }, true);
                if (data && data.length == 1) {
                    return data[0].Value + ' - ' + data[0].Text;
                }
                return "";
            };

            $scope.addRow = function () {
                var newItemTemp = angular.copy($scope.newItem);
                $scope.target.DETAILS.push(newItemTemp);
                $scope.pageChanged();
            };
            $scope.removeItem = function (index) {
                var currentPageIndex = 0;
                var currentPage = $scope.paged.currentPage;
                var itemsPerPage = $scope.paged.itemsPerPage;
                currentPageIndex = (currentPage - 1) * itemsPerPage + index;
                $scope.target.DETAILS.splice(currentPageIndex, 1);
                $scope.pageChanged();
            }
            $scope.pageChanged = function () {
                var currentPage = $scope.paged.currentPage;
                $scope.itemsPerPage = 5;
                $scope.paged.totalItems = $scope.target.DETAILS.length;
                $scope.data = [];
                if ($scope.target.DETAILS) {
                    for (var i = (currentPage - 1) * $scope.itemsPerPage; i < currentPage * $scope.itemsPerPage && i < $scope.target.DETAILS.length; i++) {
                        $scope.data.push($scope.target.DETAILS[i]);
                    }
                }
            }
            function loadDataDetails() {
                service.GetDetailByRefId(targetData.MA_PHIEU).then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        console.log("successResDetails", successRes);
                        console.log("$scope.target", $scope.target);
                        $scope.target = successRes.data.Data;
                        $scope.target.NGAY_LUU_DL = new Date($scope.target.NGAY_LUU_DL);
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            $timeout(function () {
                loadDataDetails();
            }, 350)

            $scope.save = function () {
                console.log($scope.target);
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
    app.controller('KeHoachThanhTraThuocBoDetailViewCtrl', ['$scope', '$uibModalInstance', '$location', 'KeHoachThanhTraThuocBoService', 'DmKeHoachThanhTraService', 'IDM_SYS_TUDIENService', 'DmNhomThanhTraService', 'DmDoiTuongService', 'DmDonViPhongBanService', 'DmDotThanhTraService',
        'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify', '$timeout',
    function ($scope, $uibModalInstance, $location, service, DmKeHoachThanhTraService, IDM_SYS_TUDIENService, DmNhomThanhTraService, DmDoiTuongService, DmDonViPhongBanService, DmDotThanhTraService,
         configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify, $timeout) {
        $scope.tempData = tempDataService.tempData;
        $scope.config = tempDataService.config;
        $scope.target = targetData;
        $scope.targetData = angular.copy(targetData);
        $scope.config = angular.copy(configService);
        $scope.isLoading = false;
        $scope.target = {};
        $scope.lstDmDotThanhTra = [];
        $scope.lstDmKeHoachThanhTra = [];
        $scope.lstDmLoaiThanhTra = [];
        $scope.lstDmNhomThanhTra = [];
        $scope.lstDmPhongThanhTra = [];
        $scope.lstDmDoiTuongThanhTra = [];

        $scope.title = function () { return 'Chi tiết trạng thái dự án'; };

        function loadDmDotThanhTra() {
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
        loadDmDotThanhTra();

        function loadDmKeHoachThanhTra() {
            DmKeHoachThanhTraService.getSelectData().then(function (successRes) {
                if (successRes && successRes.status == 200 && successRes.data) {
                    $scope.lstDmKeHoachThanhTra = successRes.data;
                    console.log($scope.lstDmKeHoachThanhTra);
                } else {
                    console.log('successRes', successRes);
                }
            }, function (errorRes) {
                console.log('errorRes', errorRes);
            });
        }
        loadDmKeHoachThanhTra();

        function loadDmLoaiThanhTra() {
            IDM_SYS_TUDIENService.getSelectData().then(function (successRes) {
                if (successRes && successRes.status == 200 && successRes.data) {
                    $scope.lstDmLoaiThanhTra = successRes.data;
                } else {
                    console.log('successRes', successRes);
                }
            }, function (errorRes) {
                console.log('errorRes', errorRes);
            });
        }
        loadDmLoaiThanhTra();

        function loadDmNhomThanhTra() {
            DmNhomThanhTraService.getSelectData().then(function (successRes) {
                if (successRes && successRes.status == 200 && successRes.data) {
                    $scope.lstDmNhomThanhTra = successRes.data;
                } else {
                    console.log('successRes', successRes);
                }
            }, function (errorRes) {
                console.log('errorRes', errorRes);
            });
        }
        loadDmNhomThanhTra();

        function loadDmDoiTuongThanhTra() {
            DmDoiTuongService.getSelectData().then(function (successRes) {
                if (successRes && successRes.status == 200 && successRes.data) {
                    $scope.lstDmDoiTuongThanhTra = successRes.data;
                } else {
                    console.log('successRes', successRes);
                }
            }, function (errorRes) {
                console.log('errorRes', errorRes);
            });
        }
        loadDmDoiTuongThanhTra();

        function loadDmPhongThanhTra() {
            DmDonViPhongBanService.getSelectDataDonViTB().then(function (successRes) {
                if (successRes && successRes.status == 200 && successRes.data) {
                    $scope.lstDmPhongThanhTra = successRes.data;
                } else {
                    console.log('successRes', successRes);
                }
            }, function (errorRes) {
                console.log('errorRes', errorRes);
            });
        }
        loadDmPhongThanhTra();

        $scope.formatLabel = function (model, module) {
            console.log('module', module);
            if (!model) return "";
            var data = $filter('filter')(module, { Value: model }, true);
            if (data && data.length == 1) {
                return data[0].Value + ' - ' + data[0].Text;
            }
            return "";
        };

        $scope.addRow = function () {
            var newItemTemp = angular.copy($scope.newItem);
            $scope.target.DETAILS.push(newItemTemp);
            $scope.pageChanged();
        };
        $scope.removeItem = function (index) {
            var currentPageIndex = 0;
            var currentPage = $scope.paged.currentPage;
            var itemsPerPage = $scope.paged.itemsPerPage;
            currentPageIndex = (currentPage - 1) * itemsPerPage + index;
            $scope.target.DETAILS.splice(currentPageIndex, 1);
            $scope.pageChanged();
        }
        $scope.pageChanged = function () {
            var currentPage = $scope.paged.currentPage;
            $scope.itemsPerPage = 5;
            $scope.paged.totalItems = $scope.target.DETAILS.length;
            $scope.data = [];
            if ($scope.target.DETAILS) {
                for (var i = (currentPage - 1) * $scope.itemsPerPage; i < currentPage * $scope.itemsPerPage && i < $scope.target.DETAILS.length; i++) {
                    $scope.data.push($scope.target.DETAILS[i]);
                }
            }
        }
        function loadDataDetails() {
            service.GetDetailByRefId(targetData.MA_PHIEU).then(function (successRes) {
                if (successRes && successRes.status == 200 && successRes.data) {
                    console.log("successResDetails", successRes);
                    console.log("$scope.target", $scope.target);
                    $scope.target = successRes.data.Data;
                    $scope.target.NGAY_LUU_DL = new Date($scope.target.NGAY_LUU_DL);
                } else {
                    console.log('successRes', successRes);
                }
            }, function (errorRes) {
                console.log('errorRes', errorRes);
            });
        }
        $timeout(function () {
            loadDataDetails();
        }, 350)
        $scope.save = function () {
            console.log($scope.target);
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

    app.controller('KeHoachThanhTraThuocBoDeleteViewCtrl', ['$scope', '$uibModalInstance', '$location', 'KeHoachThanhTraThuocBoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify) {
            $scope.target = targetData;
            $scope.config = angular.copy(configService);
            $scope.targetData = angular.copy(targetData);
            $scope.isLoading = false;

            $scope.title = function () { return 'Xóa trạng thái dự án'; };

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