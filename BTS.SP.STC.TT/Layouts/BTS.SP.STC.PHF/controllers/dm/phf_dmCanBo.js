define([], function () {
    'use strict';
    var app = angular.module('phf_dmCanBo', []);
    var list = [];
    app.factory('DmCanBoService', ['$http', 'configService', function ($http, configService) {
        var serviceUrl = configService.rootUrlWebApi + '/dm/phf_dmCanBo';
        var serviceUrl_ChucVu = configService.rootUrlWebApi + '/dm/phf_dmChucVu';
        var result = {
            paging: function (data) {
                return $http.post(serviceUrl + '/Paging', data);
            },
            post: function (data) {
                return $http.post(serviceUrl + '/Post', data);
            },
            getSelectData_ChucVu: function () {
                return $http.get(serviceUrl_ChucVu + '/GetSelectData');
            },
            deleteItem: function (params) {
                return $http.delete(serviceUrl + '/' + params.Id, params);
            },
            update: function (params) {
                return $http.put(serviceUrl + '/' + params.Id, params);
            },
            checkCodeExist: function (Id) {
                return $http.get(serviceUrl + '/CheckCodeExist/' + Id);
            },
            GetSelectData: function () {
                return $http.get(serviceUrl + '/GetSelectData');
            }
        }
        return result;
    }]);

    app.controller('DmCanBoCtrl', ['$scope', '$location', 'DmCanBoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster', 'ngNotify', 'blockModalService',
        function ($scope, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster, ngNotify, blockModalService) {
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
                securityService.getAccessList('phf_dmCanBo').then(function (successRes) {
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
            function loadDmChucVu() {
                blockModalService.setValue(true);
                if (!tempDataService.tempData('lstDmCanBo')) {
                    service.getSelectData_ChucVu().then(function (successRes) {
                        if (successRes && successRes.status === 200 && successRes.data) {
                            tempDataService.putTempData('lstDmCanBo', successRes.data);
                            $scope.lstDmCanBo = successRes.data;
                            list = $scope.lstDmCanBo;
                            console.log("lstDmCanBo", $scope.lstDmCanBo);
                            blockModalService.setValue(false);
                        } else {
                            console.log('successRes', successRes);
                            blockModalService.setValue(false);
                        }
                    }, function (errorRes) {
                        console.log('errorRes', errorRes);
                        blockModalService.setValue(false);
                    });
                } else {
                    $scope.lstDmCanBo = tempDataService.tempData('lstDmCanBo');
                    blockModalService.setValue(false);
                }
            }
            loadDmChucVu();
            $scope.displayHepler = function (module, value) {
                var data = $filter('filter')($scope.tempData(module), { value: value }, true);
                if (data.length == 1) {
                    return data[0].text;
                } else {
                    return value;
                }
            }

            $scope.displayHepler2 = function (module, Value) {

                var data = $filter('filter')($scope.lstDmCanBo, { Value: Value }, true);
                if (data.length == 1) {
                    return data[0].Text;
                } else {
                    return Value;
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
                    templateUrl: configService.buildUrl('dm/phf_dmCanBo', 'add'),
                    controller: 'DmCanBoCreateCtrl',
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
                    templateUrl: configService.buildUrl('dm/phf_dmCanBo', 'edit'),
                    controller: 'DmCanBoEditCtrl',
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
                    templateUrl: configService.buildUrl('dm/phf_dmCanBo', 'detail'),
                    controller: 'DmCanBoDetailCtrl',
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
                    templateUrl: configService.buildUrl('dm/phf_dmCanBo', 'delete'),
                    controller: 'DmCanBoDeleteCtrl',
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
                    console.log(successRes);
                    if (successRes && successRes.status === 200 && successRes.data) {
                        $scope.isLoading = false;
                        var date = new Date();
                        var tmp = date.getDate() + '-' + (date.getMonth() + 1) + '-' + date.getFullYear();
                        SaveFile('Export_DM_CanBo_(' + tmp + ').xls', 'application/vnd.ms-excel', successRes.data);
                        ngNotify.set('Xuất file thành công !', { duration: 3000, type: 'success' });
                    }
                }, function (errorRes) {
                    console.log(errorRes);
                    ngNotify.set('Lỗi: ' + errorRes, { duration: 3000, type: 'error' });
                });
            }
        }]);

    app.controller('DmCanBoCreateCtrl', ['$scope', '$uibModalInstance', '$location', 'DmCanBoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify', 'blockModalService',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, ngNotify, blockModalService) {
            $scope.config = angular.copy(configService);
            $scope.tempData = tempDataService.tempData;
            $scope.target = {};
            $scope.isLoading = false;
            $scope.target.TRANG_THAI = "1";
            $scope.title = function () { return 'Thêm mới cán bộ'; };
            $scope.lstDmCanBo = list;
     
            $scope.CheckExist = function (MA_CANBO) {
                if (MA_CANBO) {
                    service.checkCodeExist(MA_CANBO).then(function (response) {
                        if (response && response.status == 200 && !response.data.Error) {
                            if (response.data.Data != null) {
                                document.getElementById("MA_CANBO").focus();
                                $scope.target.MA_CANBO = '';
                                ngNotify.set(" Mã cán bộ " + MA_CANBO + " đã tồn tại! ", { type: 'error' });
                            }
                        }
                    });
                }
            };

            var getDataPhongBan = function (refid) {
                service.getGoiThauByMaDuAn(refid).then(function (successRes) {
                    if (successRes.status == 200) {
                        $scope.lstPhongBanCha = successRes.data;
                        $("#dropdownPhongBan").kendoDropDownTree({
                            placeholder: "--Chọn phòng ban--",
                            height: 500,
                            filter: "contains",
                            dataSource: $scope.lstPhongBanCha,
                            change: function (e) {
                                $scope.target.MA_PHONG = this.value();
                            }
                        });
                    }
                }, function (err) {
                    console.log("Oro", err);
                });
            }


            $scope.save = function () {
                service.post($scope.target).then(function (successRes) {
                    console.log("successRes in save", successRes)
                    console.log("target in save", $scope.target)
                    if (successRes && successRes.status === 200 && !successRes.data.Error) {
                        ngNotify.set(successRes.data.Message, { type: 'success' });
                        $uibModalInstance.close($scope.target);
                    } else {
                        console.log('successRes', successRes);
                        ngNotify.set(successRes.data.Message, { duration: 3000, type: 'error' });
                    }
                },
				function (errorRes) {
				    console.log('error', errorRes);
				});
            };
            $scope.cancel = function () {
                $uibModalInstance.close();
            };
        }]);

    app.controller('DmCanBoEditCtrl', ['$scope', '$uibModalInstance', '$location', 'DmCanBoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify', 'blockModalService',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify, blockModalService) {
            $scope.target = targetData;
            $scope.config = angular.copy(configService);
            $scope.targetData = angular.copy(targetData);
            $scope.tempData = tempDataService.tempData;
            console.log(" $scope.target", $scope.target);
            $scope.isLoading = false;
            $scope.lstDmCanBo = list;
            console.log(" $scope.selectCanBo in EDIT", $scope.selectCanBo)
            $scope.title = function () { return 'Cập nhật cán bộ'; };

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

    app.controller('DmCanBoDetailCtrl', ['$scope', '$uibModalInstance', '$location', 'DmCanBoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData',
	function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData) {
	    $scope.tempData = tempDataService.tempData;
	    $scope.config = angular.copy(configService);
	    $scope.target = targetData;
	    $scope.title = function () { return 'Chi tiết chức vụ'; };
	    $scope.lstDmCanBo = list;
	    $scope.target.NGAY_SINH = new Date($scope.target.NGAY_SINH);
	    $scope.cancel = function () {
	        $uibModalInstance.dismiss('cancel');
	    };
	}]);

    app.controller('DmCanBoDeleteCtrl', ['$scope', '$uibModalInstance', '$location', 'DmCanBoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify) {
            $scope.target = targetData;
            $scope.config = angular.copy(configService);
            $scope.targetData = angular.copy(targetData);
            $scope.isLoading = false;

            $scope.title = function () { return 'Xóa chức vụ'; };

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

    app.controller('DmCanBoSelectMultiDataController', ['$scope', 'dataThanhVien', '$uibModalInstance', '$location', 'DmCanBoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster',
 function ($scope, dataThanhVien, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster) {
     $scope.config = {
         label: angular.copy(configService.label)
     };
     console.log("data", dataThanhVien);
     $scope.paged = angular.copy(configService.pageDefault);
     $scope.filtered = angular.copy(configService.filterDefault);
     $scope.tempData = tempDataService.tempData;
     $scope.accessList = {};
     $scope.listSelectedData = [];
     //$scope.create = function () {
     //    var modalInstance = $uibModal.open({
     //        backdrop: 'static',
     //        size: 'md',
     //        templateUrl: configService.buildUrl('nv/phe_QuanLyVBHS', 'add'),
     //        controller: 'QuanLyVBHSCreateViewCtrl',
     //        resolve: {}
     //    });

     //    modalInstance.result.then(function (updatedData) {
     //        $scope.refresh();
     //    }, function () {
     //        $log.info('Modal dismissed at: ' + new Date());
     //    });
     //};
     function filterData() {
         $scope.isLoading = true;
         $scope.filtered.isAdvance = false;
         var postdata = { paged: $scope.paged, filtered: $scope.filtered };
         service.paging(JSON.stringify(postdata)).then(function (response) {
             console.log("response", response);
             $scope.isLoading = false;
             if (response.status && response.data.Data.Data) {
                 $scope.data = response.data.Data.Data;
                 if (dataThanhVien.THANHVIEN_DOAN != "") {
                     var res = dataThanhVien.THANHVIEN_DOAN.split(",");
                     for (var i = 0; i < res.length; i++) {
                         for (var j = 0; j < $scope.data.length; j++) {
                             if (res[i] == $scope.data[j].MA_CANBO) {
                                 $scope.data[j].Selected = true;
                                 $scope.listSelectedData.push($scope.data[j].MA_CANBO);
                             }
                         }
                     }
                 }
             }
         });
     };
     filterData();
     $scope.cancel = function () {
         $uibModalInstance.dismiss('cancel');
     };
     $scope.doCheck = function (item) {
         console.log("iteemm", item);
         if (item) {
             var tmp = $filter('filter')($scope.listSelectedData, { $: item.MA_CANBO }, true);
             if (item.Selected) {
                 //if (!tmp || tmp.length < 1) {
                 $scope.listSelectedData.push(item.MA_CANBO);
                 //}
             } else {
                 //if (tmp && tmp.length > 0) {
                 console.log(tmp[0]);
                 $scope.listSelectedData.splice($scope.listSelectedData.indexOf(tmp[0]), 1);
                 // }
             }
         }
         else {
             angular.forEach($scope.data, function (v, k) {
                 $scope.data[k].Selected = $scope.all;
                 var isSelected = $scope.listSelectedData.some(function (element, index, array) {
                     if (!element) return false;
                     return element.ID == v.ID;
                 });

                 if ($scope.all) {
                     if (!isSelected) {
                         $scope.listSelectedData.push($scope.data[k]);
                     }
                 } else {
                     if (isSelected) {
                         $scope.listSelectedData.splice($scope.data[k], 1);
                     }
                 }
             });
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
     $scope.save = function () {
         $uibModalInstance.close($scope.listSelectedData);
     };
 }]);

    return app;
});