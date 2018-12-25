define([], function () {
    'use strict';
    var app = angular.module('sysDvqhns', []);
    app.factory('SysDvqhnsService', ['$http', 'configService', function ($http, configService) {
        var serviceUrl = configService.rootUrlWebApi + '/sys/sysDvqhns';
        var result = {
            paging: function (data) {
                return $http.post(serviceUrl + '/paging', data);
            },
            pagingForReport: function (data) {
                return $http.post(serviceUrl + '/pagingForReport', data);
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
            getSelectData: function () {
                return $http.get(serviceUrl + '/GetSelectData');
            },
            getByMaDvqhns: function (data) {
                return $http.get(serviceUrl + '/GetByMaDvqhns/' + data);
            },
            getByMaChuong: function (data) {
                return $http.get(serviceUrl + '/GetByMaChuong/' + data);
            },
            getDsDvQhnsByUser: function () {
                return $http.get(serviceUrl + '/GetDsDvQhnsByUser');
            },
            //get danh muc PHA
            getAllDBHC: function () {
                return $http.get(serviceUrl + '/GetAllDBHC');
            },
            getSelectDataLoaiNamBat: function () {
                return $http.get(serviceUrl + '/GetSelectDataLoaiNamBat');
            },
            pagingCTMT: function (data) {
                return $http.post(serviceUrl + '/PagingCTMT', data);
            },
            pagingLOAI: function (data) {
                return $http.post(serviceUrl + '/PagingLOAI', data);
            },
            pagingNGANHKT: function (data) {
                return $http.post(serviceUrl + '/PagingNGANHKT', data);
            },
            pagingMUC: function (data) {
                return $http.post(serviceUrl + '/PagingMUC', data);
            },
            pagingTIEUMUC: function (data) {
                return $http.post(serviceUrl + '/PagingTIEUMUC', data);
            },
        }
        return result;
    }]);
    app.controller('SysDvqhnsViewCtrl', ['$scope', '$location', 'SysDvqhnsService', 'configService', '$state', 'tempDataService', '$filter', 'securityService', 'toaster',
        function ($scope, $location, service, configService, $state, tempDataService, $filter, securityService, toaster) {
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
                        console.log(errorRes);
                        toaster.pop('error', "Lỗi:", errorRes.statusText);
                    });
                }
            };

            function loadAccessList() {
                securityService.getAccessList('sysDvqhns').then(function (successRes) {
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
            }

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
        }]);
    app.controller('selectMultidataKhoanController', ['$scope', 'dataKhoan', '$uibModalInstance', '$location', 'SysDvqhnsService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster',
     function ($scope, dataKhoan, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster) {
         $scope.config = {
             label: angular.copy(configService.label)
         };
         console.log("dataKhoan", dataKhoan);
         $scope.paged = angular.copy(configService.pageDefault);
         $scope.filtered = angular.copy(configService.filterDefault);
         $scope.tempData = tempDataService.tempData;
         $scope.accessList = {};
         $scope.listSelectedData = [];
         function filterData() {
             $scope.isLoading = true;
             $scope.filtered.isAdvance = false;
             var postdata = { paged: $scope.paged, filtered: $scope.filtered };
             service.pagingNGANHKT(JSON.stringify(postdata)).then(function (response) {
                 console.log("responseNGHAN", response);
                 $scope.isLoading = false;
                 if (response.status && response.data.Data.Data) {
                     $scope.data = response.data.Data.Data;
                     for (var i = 0; i < dataKhoan.length; i++) {
                         for (var j = 0; j < $scope.data.length; j++) {
                             if ($scope.data[j].Id == dataKhoan[i].Id) {
                                 $scope.data[j].Selected = true;
                                 $scope.listSelectedData.push($scope.data[j]);
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
             if (item) {
                 var tmp = $filter('filter')($scope.listSelectedData, { $: item.Id }, true);
                 if (item.Selected) {
                     if ($scope.listSelectedData.indexOf(tmp[0]) < 0) {
                         $scope.listSelectedData.push(item);
                     }
                 } else {
                     console.log("XOA", tmp[0]);
                     console.log("indexxxx", $scope.listSelectedData.indexOf(tmp[0]));
                     $scope.listSelectedData.splice($scope.listSelectedData.indexOf(tmp[0]), 1);
                 }
             }
             else {
                 angular.forEach($scope.data, function (v, k) {
                     $scope.data[k].Selected = $scope.all;
                     var isSelected = $scope.listSelectedData.some(function (element, index, array) {
                         if (!element) return false;
                         return element.Id == v.Id;
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
         $scope.sortType = 'Value';

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
    app.controller('selectMultidataCTMTController', ['$scope', 'dataCTMT', '$uibModalInstance', '$location', 'SysDvqhnsService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster',
     function ($scope, dataCTMT, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster) {
         $scope.config = {
             label: angular.copy(configService.label)
         };
         console.log("dataCTMT", dataCTMT);
         $scope.paged = angular.copy(configService.pageDefault);
         $scope.filtered = angular.copy(configService.filterDefault);
         $scope.tempData = tempDataService.tempData;
         $scope.accessList = {};
         $scope.listSelectedData = [];
         function filterData() {
             $scope.isLoading = true;
             $scope.filtered.isAdvance = false;
             var postdata = { paged: $scope.paged, filtered: $scope.filtered };
             service.pagingCTMT(JSON.stringify(postdata)).then(function (response) {
                 $scope.isLoading = false;
                 if (response.status && response.data.Data.Data) {
                     $scope.data = response.data.Data.Data;
                     for (var i = 0; i < dataCTMT.length; i++) {
                         for (var j = 0; j < $scope.data.length; j++) {
                             if ($scope.data[j].Id == dataCTMT[i].Id) {
                                 $scope.data[j].Selected = true;
                                 $scope.listSelectedData.push($scope.data[j]);
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
             if (item) {
                 var tmp = $filter('filter')($scope.listSelectedData, { $: item.Id }, true);
                 if (item.Selected) {
                     if ($scope.listSelectedData.indexOf(tmp[0]) < 0) {
                         $scope.listSelectedData.push(item);
                     }
                 } else {
                     console.log("XOA", tmp[0]);
                     console.log("indexxxx", $scope.listSelectedData.indexOf(tmp[0]));
                     $scope.listSelectedData.splice($scope.listSelectedData.indexOf(tmp[0]), 1);
                 }
             }
             else {
                 angular.forEach($scope.data, function (v, k) {
                     $scope.data[k].Selected = $scope.all;
                     var isSelected = $scope.listSelectedData.some(function (element, index, array) {
                         if (!element) return false;
                         return element.Id == v.Id;
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
         $scope.sortType = 'Value';

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
    app.controller('selectMultidataLOAIController', ['$scope', 'dataLOAI', '$uibModalInstance', '$location', 'SysDvqhnsService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster',
    function ($scope, dataLOAI, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster) {
        $scope.config = {
            label: angular.copy(configService.label)
        };
        console.log("dataLOAI", dataLOAI);
        $scope.paged = angular.copy(configService.pageDefault);
        $scope.filtered = angular.copy(configService.filterDefault);
        $scope.tempData = tempDataService.tempData;
        $scope.accessList = {};
        $scope.listSelectedData = [];
        function filterData() {
            $scope.isLoading = true;
            $scope.filtered.isAdvance = false;
            var postdata = { paged: $scope.paged, filtered: $scope.filtered };
            service.pagingLOAI(JSON.stringify(postdata)).then(function (response) {
                $scope.isLoading = false;
                if (response.status && response.data.Data.Data) {
                    $scope.data = response.data.Data.Data;
                    for (var i = 0; i < dataLOAI.length; i++) {
                        for (var j = 0; j < $scope.data.length; j++) {
                            if ($scope.data[j].Id == dataLOAI[i].Id) {
                                $scope.data[j].Selected = true;
                                $scope.listSelectedData.push($scope.data[j]);
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
            if (item) {
                var tmp = $filter('filter')($scope.listSelectedData, { $: item.Id }, true);
                if (item.Selected) {
                    if ($scope.listSelectedData.indexOf(tmp[0]) < 0) {
                        $scope.listSelectedData.push(item);
                    }
                } else {
                    console.log("XOA", tmp[0]);
                    console.log("indexxxx", $scope.listSelectedData.indexOf(tmp[0]));
                    $scope.listSelectedData.splice($scope.listSelectedData.indexOf(tmp[0]), 1);
                }
            }
            else {
                angular.forEach($scope.data, function (v, k) {
                    $scope.data[k].Selected = $scope.all;
                    var isSelected = $scope.listSelectedData.some(function (element, index, array) {
                        if (!element) return false;
                        return element.Id == v.Id;
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
        $scope.sortType = 'Value';

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
    app.controller('selectMultidataMUCController', ['$scope', 'dataMUC', '$uibModalInstance', '$location', 'SysDvqhnsService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster',
    function ($scope, dataMUC, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster) {
        $scope.config = {
            label: angular.copy(configService.label)
        };
        console.log("dataMUC", dataMUC);
        $scope.paged = angular.copy(configService.pageDefault);
        $scope.filtered = angular.copy(configService.filterDefault);
        $scope.tempData = tempDataService.tempData;
        $scope.accessList = {};
        $scope.listSelectedData = [];
        function filterData() {
            $scope.isLoading = true;
            $scope.filtered.isAdvance = false;
            var postdata = { paged: $scope.paged, filtered: $scope.filtered };
            service.pagingMUC(JSON.stringify(postdata)).then(function (response) {
                $scope.isLoading = false;
                if (response.status && response.data.Data.Data) {
                    $scope.data = response.data.Data.Data;
                    for (var i = 0; i < dataMUC.length; i++) {
                        for (var j = 0; j < $scope.data.length; j++) {
                            if ($scope.data[j].Id == dataMUC[i].Id) {
                                $scope.data[j].Selected = true;
                                $scope.listSelectedData.push($scope.data[j]);
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
            if (item) {
                var tmp = $filter('filter')($scope.listSelectedData, { $: item.Id }, true);
                if (item.Selected) {
                    if ($scope.listSelectedData.indexOf(tmp[0]) < 0) {
                        $scope.listSelectedData.push(item);
                    }
                } else {
                    console.log("XOA", tmp[0]);
                    console.log("indexxxx", $scope.listSelectedData.indexOf(tmp[0]));
                    $scope.listSelectedData.splice($scope.listSelectedData.indexOf(tmp[0]), 1);
                }
            }
            else {
                angular.forEach($scope.data, function (v, k) {
                    $scope.data[k].Selected = $scope.all;
                    var isSelected = $scope.listSelectedData.some(function (element, index, array) {
                        if (!element) return false;
                        return element.Id == v.Id;
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
        $scope.sortType = 'Value';

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
    app.controller('selectMultidataTIEUMUCController', ['$scope', 'dataTIEUMUC', '$uibModalInstance', '$location', 'SysDvqhnsService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster',
    function ($scope, dataTIEUMUC, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster) {
        $scope.config = {
            label: angular.copy(configService.label)
        };
        console.log("dataTIEUMUC", dataTIEUMUC);
        $scope.paged = angular.copy(configService.pageDefault);
        $scope.filtered = angular.copy(configService.filterDefault);
        $scope.tempData = tempDataService.tempData;
        $scope.accessList = {};
        $scope.listSelectedData = [];
        function filterData() {
            $scope.isLoading = true;
            $scope.filtered.isAdvance = false;
            var postdata = { paged: $scope.paged, filtered: $scope.filtered };
            service.pagingTIEUMUC(JSON.stringify(postdata)).then(function (response) {
                $scope.isLoading = false;
                if (response.status && response.data.Data.Data) {
                    $scope.data = response.data.Data.Data;
                    for (var i = 0; i < dataTIEUMUC.length; i++) {
                        for (var j = 0; j < $scope.data.length; j++) {
                            if ($scope.data[j].Id == dataTIEUMUC[i].Id) {
                                $scope.data[j].Selected = true;
                                $scope.listSelectedData.push($scope.data[j]);
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
            if (item) {
                var tmp = $filter('filter')($scope.listSelectedData, { $: item.Id }, true);
                if (item.Selected) {
                    if ($scope.listSelectedData.indexOf(tmp[0]) < 0) {
                        $scope.listSelectedData.push(item);
                    }
                } else {
                    console.log("XOA", tmp[0]);
                    console.log("indexxxx", $scope.listSelectedData.indexOf(tmp[0]));
                    $scope.listSelectedData.splice($scope.listSelectedData.indexOf(tmp[0]), 1);
                }
            }
            else {
                angular.forEach($scope.data, function (v, k) {
                    $scope.data[k].Selected = $scope.all;
                    var isSelected = $scope.listSelectedData.some(function (element, index, array) {
                        if (!element) return false;
                        return element.Id == v.Id;
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
        $scope.sortType = 'Value';

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

