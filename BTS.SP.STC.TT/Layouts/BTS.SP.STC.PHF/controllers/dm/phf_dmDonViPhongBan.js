define([], function () {
    'use strict';
    var app = angular.module('phf_dmDonViPhongBan', []);
    var listDotThanhTra = [];
    app.factory('DmDonViPhongBanService', ['$http', 'configService', function ($http, configService) {
        var serviceUrl = configService.rootUrlWebApi + '/dm/phf_dmDonViPhongBan';
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
            getSelectDataDonViTB: function () {
                return $http.get(serviceUrl + '/GetSelectDataDonViTB');
            },
            getSelectDataDonVi: function () {
                return $http.get(serviceUrl + '/GetSelectDataDonVi');
            },
            getAllDonVi: function () {
                return $http.get(serviceUrl + '/GetAllDonVi');
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
    app.controller('DmDonViPhongBanCtrl', ['$scope', '$timeout', '$location', 'DmDonViPhongBanService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster', 'ngNotify', 'blockModalService',
    function ($scope, $timeout, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster, ngNotify, blockModalService) {
        $scope.config = {
            label: angular.copy(configService.label)
        }
        $scope.paged = angular.copy(configService.pageDefault);
        $scope.filtered = angular.copy(configService.filterDefault);
        $scope.tempData = tempDataService.tempData;
        $scope.accessList = {};
        $scope.sortType = 'ID';

        $scope.sortReverse = false;

        $scope.doSearch = function () {
            $scope.paged.currentPage = 1;
            filterData();
        };

        $scope.refresh = function () {
            $scope.setPage($scope.paged.currentPage);
        };

        $scope.setPage = function (pageNo) {
            $scope.paged.currentPage = pageNo;
            filterData();
        };

        function treeify(list, idAttr, parentAttr, childrenAttr) {
            if (!idAttr) idAttr = 'MA_CHA';
            if (!parentAttr) parentAttr = 'MA';
            if (!childrenAttr) childrenAttr = 'items';
            var lookup = {};
            var result = {};
            result[childrenAttr] = [];
            list.forEach(function (obj) {
                lookup[obj[idAttr]] = obj;
                obj[childrenAttr] = [];
            });
            list.forEach(function (obj) {
                if (obj[parentAttr] != null) {
                    obj.spriteCssClass = "folder";
                    lookup[obj[parentAttr]][childrenAttr].push(obj);
                } else {
                    obj.expanded = true;
                    obj.spriteCssClass = "rootfolder";
                    result[childrenAttr].push(obj);
                }
            });
            return result;
        };

        function gentKenDo() {
            $("#treeList").kendoTreeList({
                editable: {
                    mode: "inline"
                },
                messages: {
                    commands: {
                        edit: "Sửa",
                        update: "Lưu",
                        cancel: "Hủy"
                    }
                },
                dataSource: [],
                sortable: true,
                resizable: true,
                selectable: true,
                columns: [
                    {
                        field: "MA",
                        title: "Mã phòng ban",
                        editable: function (dataItem) {
                            return $scope.accessList.Edit;
                        },
                    },
                    {
                        field: "TEN",
                        title: "Tên phòng ban",
                        editable: function (dataItem) {
                            return $scope.accessList.Edit;
                        },
                    },
                    { title: "Sửa", command: ["edit"] },
                          { title: "Xóa", command: ["destroy"] }

                ],
                remove: function (e) {
                    console.log(e.model);
                    //$scope.delete();
                },
                save: function (e) {
                    console.log("save row: ", e.model);
                }

            });
        }
        $timeout(function () {
            gentKenDo();
            loadAccessList();
        }, 100);

        function loadAccessList() {
            securityService.getAccessList('phf_dmDonViPhongBan').then(function (successRes) {
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

        function filterData() {
            if ($scope.accessList.View) {
                var postdata = { paged: $scope.paged, filtered: $scope.filtered };
                service.getAllDonVi().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data && !successRes.data.Error) {
                        $scope.data = successRes.data.Data;
                        console.log('$scope.data', $scope.data);
                        var treeList = $("#treeList").data("kendoTreeList");
                        var dsNew = new kendo.data.TreeListDataSource({
                            data: $scope.data,
                            schema: {
                                model: {
                                    id: "MA",
                                    parentId: "MA_CHA",
                                    fields: {
                                        MA_CHA: { field: "MA_CHA", type: "string", nullable: true },
                                        MA: { field: "MA", type: "string" },
                                    },
                                    expanded: true
                                }
                            }
                        });
                        treeList.setDataSource(dsNew);
                    } else {
                        $scope.data = [];
                        toaster.pop('error', "Lỗi:", successRes.data.Message);
                    }
                }, function (errorRes) {
                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                });
            }
        }

        $scope.create = function () {
            var treeList = $("#treeList").data("kendoTreeList");
            var row = treeList.select();
            var dataSelected = angular.copy(treeList.dataItem(row));
            var modalInstance = $uibModal.open({
                backdrop: 'static',
                size: 'md',
                templateUrl: configService.buildUrl('dm/phf_dmDonViPhongBan', 'add'),
                controller: 'DmDonViPhongBanCreateCtrl',
                resolve: {
                    targetData: function () {
                        return dataSelected;
                    }
                }
            });
            modalInstance.result.then(function (updatedData) {
                $scope.refresh();
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });


        }

        $scope.delete = function (target) {
            var modalInstance = $uibModal.open({
                backdrop: 'static',
                templateUrl: configService.buildUrl('dm/phf_dmDonViPhongBan', 'delete'),
                controller: 'DmDonViPhongBanDeleteCtrl',
                resolve: {
                    targetData: function () {
                        return target;
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

    app.controller('DmDonViPhongBanCreateCtrl', ['$scope', '$timeout', '$uibModalInstance', '$location', 'DmDonViPhongBanService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify', 'blockModalService', 'targetData',
    function ($scope, $timeout, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, ngNotify, blockModalService, targetData) {
        $scope.config = angular.copy(configService);
        $scope.tempData = tempDataService.tempData;
        $scope.target = targetData;
        $scope.target.MA_CHA = targetData.MA;
        $scope.target.MA = '';
        $scope.target.TEN = '';
        $scope.isLoading = false;
        $scope.target.TRANG_THAI = "1";
        $scope.lstDonViPB = [];
        $scope.title = function () { return 'Thêm mới đơn vị'; };
        function gentKenDo() {
            $("#dropdowntree").kendoDropDownTree({
                placeholder: "Chọn đơn vị cha ...",
                height: 400,
                dataTextField: "TEN",
                dataValueField: "MA",
                dataSource: []
            });
        }
        $timeout(function () {
            gentKenDo();

        }, 100);
        $timeout(function () {
            console.log($scope.lstDonViPB);
            var dropdowntree = $("#dropdowntree").data("kendoDropDownTree");
            dropdowntree.setDataSource($scope.lstDonViPB.items);
        }, 500);

        function treeify(list, idAttr, parentAttr, childrenAttr) {
            if (!idAttr) idAttr = 'MA';
            if (!parentAttr) parentAttr = 'MA_CHA';
            if (!childrenAttr) childrenAttr = 'items';
            var lookup = {};
            var result = {};
            result[childrenAttr] = [];
            list.forEach(function (obj) {
                lookup[obj[idAttr]] = obj;
                obj[childrenAttr] = [];
            });
            list.forEach(function (obj) {
                if (obj[parentAttr] != null) {
                    obj.spriteCssClass = "folder";
                    lookup[obj[parentAttr]][childrenAttr].push(obj);
                } else {
                    obj.expanded = true;
                    obj.spriteCssClass = "rootfolder";
                    result[childrenAttr].push(obj);
                }
            });
            return result;
        };

        function filterData() {
            var postdata = { paged: $scope.paged, filtered: $scope.filtered };
            service.getAllDonVi().then(function (successRes) {
                if (successRes && successRes.status == 200 && successRes.data && !successRes.data.Error) {
                    $scope.lstDonViPB = treeify(successRes.data.Data);
                    console.log('$scope.data', $scope.data);
                } else {
                    $scope.data = [];
                    toaster.pop('error', "Lỗi:", successRes.data.Message);
                }
            }, function (errorRes) {
                toaster.pop('error', "Lỗi:", errorRes.statusText);
            });
        }
        filterData();

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

    app.controller('DmDonViPhongBanDeleteCtrl', ['$scope', '$uibModalInstance', '$location', 'DmCanBoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify',
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


    return app;
});


