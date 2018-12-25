define([], function () {
    'use strict';
    var app = angular.module('phf_dmKeHoachThanhTra', []);
    var listKeHoachThanhTra = [];
    app.factory('DmKeHoachThanhTraService', ['$http', 'configService', function ($http, configService) {
        var serviceUrl = configService.rootUrlWebApi + '/dm/phf_dmKeHoachThanhTra';
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
            CheckCodeExist: function (Id) {
                return $http.get(serviceUrl + '/CheckCodeExist/' + Id);
            }
        }
        return result;
    }]);

    app.controller('DmKeHoachThanhTraCtrl', ['$scope', '$location', 'DmKeHoachThanhTraService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster', 'ngNotify',
        function ($scope, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster, ngNotify) {
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
                            listKeHoachThanhTra = $scope.data;
                            for (var i = 0; i < $scope.data.length; i++) {
                                for (var j = 0; j < $scope.data.length; j++) {
                                    if ($scope.data[i].MA_TUDIEN == $scope.data[j].MA_TUDIEN_CHA) {
                                        $scope.data[j].TEN_TUDIEN_CHA = $scope.data[i].TEN_TUDIEN;
                                    }
                                }
                            }
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
                securityService.getAccessList('phf_dmKeHoachThanhTra').then(function (successRes) {
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
                var data = $filter('filter')($scope.tempData(module), { value: value }, true);
                if (data.length == 1) {
                    return data[0].text;
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
                    templateUrl: configService.buildUrl('dm/phf_dmKeHoachThanhTra', 'add'),
                    controller: 'DmKeHoachThanhTraCreateCtrl',
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
                    templateUrl: configService.buildUrl('dm/phf_dmKeHoachThanhTra', 'edit'),
                    controller: 'DmKeHoachThanhTraEditCtrl',
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
                    templateUrl: configService.buildUrl('dm/phf_dmKeHoachThanhTra', 'detail'),
                    controller: 'DmKeHoachThanhTraDetailCtrl',
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
                    templateUrl: configService.buildUrl('dm/phf_dmKeHoachThanhTra', 'delete'),
                    controller: 'DmKeHoachThanhTraDeleteCtrl',
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

            function SaveFile(name, type, data) {
                var ieEDGE = navigator.userAgent.match(/Edge/g);
                var ie = navigator.userAgent.match(/.NET/g); // IE 11+
                var oldIE = navigator.userAgent.match(/MSIE/g);
                if (ie || oldIE || ieEDGE) {
                    var blob = new window.Blob([data], { type: type });
                    window.navigator.msSaveBlob(blob, name);
                }
                else {
                    var a = $("<a style='display: none;'/>");
                    var url = window.URL.createObjectURL(new Blob([data], { type: type }));
                    a.attr("href", url);
                    a.attr("download", name);
                    $("body").append(a);
                    a[0].click();
                    window.URL.revokeObjectURL(url);
                    a.remove();
                }
            }

            $scope.export = function () {
                $scope.isLoading = true;
                service.Export().then(function (successRes) {
                    if (successRes && successRes.status === 200 && successRes.data) {
                        $scope.isLoading = false;
                        var date = new Date();
                        var tmp = date.getDate() + '-' + (date.getMonth() + 1) + '-' + date.getFullYear();
                        SaveFile('Export_DM_KeHoachThanhTra_(' + tmp + ').xls', 'application/vnd.ms-excel', successRes.data);
                        ngNotify.set('Xuất file thành công !', { duration: 3000, type: 'success' });
                    }
                }, function (errorRes) {
                    console.log(errorRes);
                    ngNotify.set('Lỗi: ' + errorRes, { duration: 3000, type: 'error' });
                });
            }
        }]);

    app.controller('DmKeHoachThanhTraCreateCtrl', ['$scope', '$uibModalInstance', '$location', 'DmKeHoachThanhTraService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, ngNotify) {
            $scope.config = angular.copy(configService);
            $scope.tempData = tempDataService.tempData;
            $scope.target = {};
            $scope.isLoading = false;
            $scope.target.TRANG_THAI = "1";
            $scope.target.LOAI_TUDIEN = "KEHOACHTHANHTRA";
            $scope.title = function () { return 'Thêm mới kế hoạch thanh tra'; };

            $scope.CheckExist = function (MA_TUDIEN) {
                if (MA_TUDIEN) {
                    service.CheckCodeExist(MA_TUDIEN).then(function (response) {
                        if (response && response.status == 200 && !response.data.Error) {
                            if (response.data.Data != null) {
                                document.getElementById("MA_TUDIEN").focus();
                                $scope.target.MA_TUDIEN = '';
                                ngNotify.set(" Mã kế hoạch thanh tra " + MA_TUDIEN + " đã tồn tại! ", { type: 'error' });
                            }
                        }
                    });
                }
            };

            $scope.save = function () {
                service.post($scope.target).then(function (successRes) {
                    if (successRes && successRes.status === 200 && !successRes.data.Error) {
                        ngNotify.set(successRes.data.Message, { type: 'success' });
                        $uibModalInstance.close($scope.target);
                    } else {

                        ngNotify.set(successRes.data.Message, { duration: 3000, type: 'error' });
                    }
                },
				function (errorRes) {

				});
            };
            $scope.cancel = function () {
                $uibModalInstance.close();
            };
        }]);

    app.controller('DmKeHoachThanhTraEditCtrl', ['$scope', '$uibModalInstance', '$location', 'DmKeHoachThanhTraService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify) {
            $scope.target = targetData;
            $scope.config = angular.copy(configService);
            $scope.targetData = angular.copy(targetData);
            $scope.tempData = tempDataService.tempData;
            $scope.isLoading = false;
            $scope.target.LOAI_TUDIEN = "KEHOACHTHANHTRA";
            $scope.title = function () { return 'Cập nhật kế hoạch thanh tra'; };

            $scope.save = function () {
                service.update($scope.target).then(function (successRes) {
                    if (successRes && successRes.status == 200 && !successRes.data.Error) {
                        ngNotify.set(successRes.data.Message, { type: 'success' });
                        $uibModalInstance.close($scope.target);
                    } else {
                        ngNotify.set(successRes.data.Message, { duration: 3000, type: 'error' });
                    }
                },
                    function (errorRes) {
                    });
            };
            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
            };
        }]);

    app.controller('DmKeHoachThanhTraDetailCtrl', ['$scope', '$uibModalInstance', '$location', 'DmKeHoachThanhTraService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData',
	function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData) {
	    $scope.tempData = tempDataService.tempData;
	    $scope.config = tempDataService.config;
	    $scope.target = targetData;
	    $scope.title = function () { return 'Chi tiết kế hoạch thanh tra'; };
	    for (var j = 0; j < listKeHoachThanhTra.length; j++) {
	        if (listKeHoachThanhTra[j].MA_TUDIEN == $scope.target.MA_TUDIEN_CHA) {
	            $scope.target.TEN_TUDIEN_CHA = listKeHoachThanhTra[j].TEN_TUDIEN;
	        }
	    }
	    $scope.cancel = function () {
	        $uibModalInstance.dismiss('cancel');
	    };
	}]);

    app.controller('DmKeHoachThanhTraDeleteCtrl', ['$scope', '$uibModalInstance', '$location', 'DmKeHoachThanhTraService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify) {
            $scope.target = targetData;
            $scope.config = angular.copy(configService);
            $scope.targetData = angular.copy(targetData);
            $scope.isLoading = false;

            $scope.title = function () { return 'Xóa kế hoạch thanh tra'; };

            $scope.save = function () {
                service.deleteItem($scope.target).then(function (successRes) {
                    if (successRes && successRes.status == 200 && !successRes.data.Error) {
                        ngNotify.set(successRes.data.Message, { type: 'success' });
                        $uibModalInstance.close($scope.target);
                    } else {
                        ngNotify.set(successRes.data.Message, { duration: 3000, type: 'error' });
                    }
                },
                    function (errorRes) {
                    });
            };
            $scope.close = function () {
                $uibModalInstance.dismiss('cancel');
            };
        }]);

    return app;
});


