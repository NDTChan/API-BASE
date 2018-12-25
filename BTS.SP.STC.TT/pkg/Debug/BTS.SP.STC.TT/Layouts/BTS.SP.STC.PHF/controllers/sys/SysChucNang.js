define([], function () {
    'use strict';
    var app = angular.module('sysChucNang', []);
    app.factory('SysChucNangService', ['$http', 'configService', function ($http, configService) {
        var serviceUrl = configService.rootUrlWebApi + '/sys/SysChucNang';
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
                return $http.delete(serviceUrl + '/' + params.ID, params);
            },
            getAllForConfigNhomQuyen: function (params) {
                return $http.get(serviceUrl + '/getAllForConfigNhomQuyen/' + params);
            },
            getAllForConfigQuyen: function (params) {
                return $http.get(serviceUrl + '/GetAllForConfigQuyen/' + params);
            },
            getSelectData: function () {
                return $http.get(serviceUrl + '/GetSelectData');
            },
            //get danh muc PHA
            getAllDBHC: function () {
                return $http.get(serviceUrl + '/GetAllDBHC');
            },

        }
        return result;
    }]);
    app.controller('SysChucNangCtrl', ['$scope', '$log', '$location', 'SysChucNangService', 'configService', '$uibModal', 'securityService', '$state', 'toaster', 'tempDataService',
        function ($scope, $log, $location, service, configService, $uibModal, securityService, $state, toaster, tempDataService) {
            $scope.config = {
                label: angular.copy(configService.label)
            }
            $scope.paged = angular.copy(configService.pageDefault);
            $scope.tempData = tempDataService.tempData;
            $scope.accessList = {};

            function filterData() {
                if ($scope.accessList.View) {
                    service.paging($scope.paged).then(function (successRes) {
                        if (successRes && successRes.status == 200 && successRes.data && !successRes.data.Error) {
                            $scope.data = successRes.data.Data.data;
                            $scope.paged.totalItems = successRes.data.Data.totalItems;
                        } else {
                            $scope.data = [];
                            $scope.paged.totalItems = 0;
                        }
                    }, function (errorRes) {
                        console.log(errorRes);
                    });
                }
            };

            function loadAccessList() {
                securityService.getAccessList('sysChucNang').then(function (successRes) {
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

            $scope.setPage = function (pageNo) {
                $scope.paged.currentPage = pageNo;
                filterData();
            };

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
                    size: 'md',
                    templateUrl: configService.buildUrl('sys/sysChucNang', 'addoredit'),
                    controller: 'SysChucNangCreateOrUpdateCtrl',
                    resolve: {
                        targetData: function () {
                            return null;
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.refresh();
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };

            $scope.edit = function (item) {
                var modalInstance = $uibModal.open({
                    size: 'md',
                    templateUrl: configService.buildUrl('sys/sysChucNang', 'addoredit'),
                    controller: 'SysChucNangCreateOrUpdateCtrl',
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

        }]);

    app.controller('SysChucNangCreateOrUpdateCtrl', ['$scope', '$uibModalInstance', 'SysChucNangService', 'configService', 'targetData', function ($scope, $uibModalInstance, service, configService, targetData) {
        $scope.config = angular.copy(configService);

        $scope.editMode = false;
        if (targetData) {
            $scope.editMode = true;
            $scope.target = angular.copy(targetData);
        }

        function loadParent() {
            service.getMenuCha('B').then(function (successRes) {
                if (successRes && successRes.data && successRes.data.length > 0) {
                    $scope.lstParent = angular.copy(successRes.data);
                } else {
                    console.log(successRes);
                }
            }, function (errorRes) {
                console.log(errorRes);
            });
        }
        loadParent();

        $scope.save = function () {
            $scope.target.PHAN_HE = 'B';
            console.log('target', $scope.target);
            if ($scope.editMode) {
                //update
                service.update($scope.target).then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        if (successRes.data.Status) {
                            console.log("Updated");
                            $uibModalInstance.close(successRes.data.Data); //thành công
                        } else {
                            console.log(successRes.data.Message);//update lỗi hoặc trùng mã
                        }
                    } else {
                        console.log(successRes);
                    }
                }, function (errorRes) {
                    console.log(errorRes);
                });

            } else {
                //add
                service.post($scope.target).then(function (successRes) {
                    if (successRes && successRes.status == 201 && successRes.data && successRes.data.Status) {
                        if (successRes.data.Status) {
                            console.log("Inserted");
                            $uibModalInstance.close(successRes.data.Data); //thành công
                        } else {
                            console.log(successRes.data.Message);//insert lỗi hoặc trùng mã
                        }
                    } else {
                        console.log(successRes);
                    }
                }, function (errorRes) {
                    console.log(errorRes);
                });
            }
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };

    }]);
    return app;
});

