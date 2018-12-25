define(['controllers/auth/AuNguoiDungNhomQuyen', 'controllers/auth/AuNguoiDungQuyen', 'controllers/dm/phf_DmDonViPhongBan'], function () {
    'use strict';
    var app = angular.module('AuNguoiDung', ['AuNguoiDungNhomQuyen', 'AuNguoiDungQuyen', 'phf_DmDonViPhongBan']);
    app.factory('AuNguoiDungService', ['$http', 'configService', 'CacheFactory', function ($http, configService) {
        var serviceUrl = configService.rootUrlWebApi + '/auth/AuNguoiDung';
        var result = {
            pagingData: function (obj) {
                return $http.post(serviceUrl + '/pagingData', obj);
            },
            addNew: function (data) {
                return $http.post(serviceUrl + '/AddNew', data);
            },
            getItem: function (id) {
                return $http.get(serviceUrl + '/' + id);
            },
            update: function (params) {
                return $http.put(serviceUrl + '/' + params.id, params);
            },
            deleteItem: function (params) {
                return $http.delete(serviceUrl + '/' + params.id);
            },
            getInfoUserByUserName: function (obj) {
                return $http.post(serviceUrl + '/GetInfoUserByUserName', obj);
            },
            checkExistCode: function (code) {
                return $http.get(serviceUrl + '/CheckExistCode/' + code);
            }
        }
        return result;
    }]);
    app.controller('AuNguoiDungViewCtrl', ['$scope', '$filter', '$state', '$log', 'AuNguoiDungService', 'configService', 'tempDataService', 'securityService', 'toaster', '$uibModal', '$ngConfirm', 'DmDonViPhongBanService', 'CacheFactory',
        function ($scope, $filter, $state, $log, service, configService, tempDataService, securityService, toaster, $uibModal, $ngConfirm, DmDonViPhongBanService, cacheFactory) {
            $scope.config = {
                label: angular.copy(configService.label)
            }
            $scope.title = "Người dùng hệ thống";
            $scope.tempData = tempDataService.tempData;
            $scope.accessList = {};
            function treeify(list, idAttr, parentAttr, childrenAttr) {
                if (!idAttr) idAttr = 'id';
                if (!parentAttr) parentAttr = 'parentId';
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
                        obj.expanded = false;
                        obj.spriteCssClass = "image";
                        lookup[obj[parentAttr]][childrenAttr].push(obj);
                    } else {
                        obj.expanded = true;
                        obj.spriteCssClass = "folder";
                        result[childrenAttr].push(obj);
                    }
                });
                return result;
            };
            function detailInit(e) {
                var obj = {
                    MA_DONVI: e.data.mA_DONVI,
                    USERNAME: e.data.username
                };
                var detailRow = e.detailRow;
                var dataSource = new kendo.data.DataSource({
                    type: "odata",
                    transport: {
                        read: function (e) {
                            service.getInfoUserByUserName(obj).then(function (response) {
                                if (response && response.status === 200 && response.data && response.data.data) {
                                }
                            });
                        },
                        dataType: "json"
                    },
                    schema: {
                        data: function (data) {
                            return data.value;
                        },
                        total: function (data) {
                            return data['odata.count'];
                        }
                    },
                    pageSize: 5,
                    serverPaging: true
                });
                dataSource.fetch(function () {
                    console.log(dataSource.view().length); // displays "20"
                });
            };
            function update(e) {
                e.preventDefault();
                var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
                console.log(dataItem);
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    size: 'md',
                    templateUrl: configService.buildUrl('auth/AuNguoiDung', 'edit'),
                    controller: 'AuNguoiDungEditCtrl',
                    resolve: {
                        targetData: function () {
                            return dataItem;
                        }
                    }
                });
                modalInstance.result.then(function () {
                    $("#grid").data("kendoGrid").refresh();
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };
            function bindingData(listDataSource) {
                $("#grid").kendoGrid({
                    dataSource: {
                        data: listDataSource,
                        schema: {
                            model: {
                                fields: {
                                    id: { type: "number" },
                                    username: { type: "string" },
                                    fullname: { type: "string" },
                                    email: { type: "string" },
                                    phone: { type: "string" },
                                    ghichu: { type: "string" },
                                    trangthai: { type: "number" }
                                }
                            }
                        },
                        pageSize: 20
                    },
                    selectable: true,
                    height: 550,
                    scrollable: true,
                    sortable: true,
                    filterable: true,
                    pageable: {
                        input: true,
                        numeric: false
                    },
                    detailTemplate: kendo.template($("#template").html()),
                    detailInit: detailInit,
                    dataBound: function () {
                    },
                    columns: [
                        { field: "username", title: "Tài khoản", width: "90px" },
                        { field: "fullname", title: "Tên đầy đủ", width: "200px" },
                        { field: "trangthai", title: "Trạng thái", width: "90px", template: '#= (trangthai == 1 ) ? "Sử dụng" : "Không sử dụng" #' },
                        { command: [{ name: "update", text: "", click: update }, { name: "destroy", text: "" }], title: "&nbsp;&nbsp;&nbsp;Hành động", width: "100px" }
                    ],
                    noRecords: true,
                    messages: {
                        noRecords: "Không tồn tại tài khoản thuộc đơn vị này!"
                    },
                    editable: "popup"
                });
                $("#grid").data("kendoGrid").refresh();
            };

            function filterDataByDonViPhongBan(obj) {
                service.pagingData(obj).then(function (successRes) {
                    if (successRes && successRes.status === 200 && successRes.data && successRes.data.data && successRes.data.data.length > 0) {
                        if (successRes.data.data.length > 0) {
                            bindingData(successRes.data.data);
                        }
                    } else {
                        bindingData([]);

                    }
                }, function (errorRes) {
                    console.log($scope.listData);
                });
            };
            function onSelect(e) {
                e.preventDefault();
                var treeview = $("#treeview").data("kendoTreeView");
                var item = treeview.dataItem(e.node);
                if (item) {
                    item.selected = true;
                    var obj = {
                        ma_donvi: item.ma
                    };
                    filterDataByDonViPhongBan(obj);
                }
            };
            function onChange(e) {
                e.preventDefault();
            }
            function bidingDataTreeView(listDataSource) {
                $("#treeview").kendoTreeView({
                    template: kendo.template($("#treeview-template").html()),
                    dataSource: listDataSource,
                    dataTextField: "ten",
                    dataValueField: "ma",
                    select: onSelect,
                    change: onChange,
                    expanded: true,
                    selectable: true
                });
            };
            function filterData() {
                if ($scope.accessList.view) {
                    DmDonViPhongBanService.pagingData().then(function (successRes) {
                        if (successRes && successRes.status === 200 && successRes.data && successRes.data.data && successRes.data.data.length > 0) {
                            $scope.dataDonVi = treeify(successRes.data.data).items;
                            bidingDataTreeView($scope.dataDonVi);
                            var obj = {
                                ma_donvi: null
                            };
                            filterDataByDonViPhongBan(obj);
                        } else {
                            bidingDataTreeView(null);
                            toaster.pop('error', "Lỗi:", successRes.data.Message);
                        }
                    }, function (errorRes) {
                        console.log(errorRes);
                        toaster.pop('error', "Lỗi:", errorRes.statusText);
                    });
                }
            };
            function loadAccessList() {
                securityService.getAccessList('auNguoiDung').then(function (successRes) {
                    if (successRes && successRes.status === 200) {
                        $scope.accessList = successRes.data;
                        if (!$scope.accessList.view) {
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
                if (data.length === 1) {
                    return data[0].Text;
                } else {
                    return value;
                }
            };

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
            $(document).on("click", ".create", function (e) {
                e.preventDefault();
                var treeview = $("#treeview").data("kendoTreeView");
                var dataItem = treeview.dataItem("#treeview_tv_active");
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    size: 'lg',
                    templateUrl: configService.buildUrl('auth/AuNguoiDung', 'add'),
                    controller: 'AuNguoiDungCreateCtrl',
                    resolve: {
                        targetData: function () {
                            return dataItem;
                        }
                    }
                });
                modalInstance.result.then(function () {
                    $("#grid").data("kendoGrid").refresh();
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            });
            $scope.delete = function (item) {
                var jc = $ngConfirm({
                    title: 'Xóa bản ghi.',
                    content: 'Xóa bản ghi có thể tác động đến các dữ liệu liên quan. Chắc chắn xóa ?',
                    icon: 'fa fa-warning',
                    buttons: {
                        confirm: {
                            text: 'Xóa!',
                            btnClass: 'btn-warning',
                            action: function () {
                                service.deleteItem(item).then(function (successRes) {
                                    if (successRes && successRes.status == 200 && !successRes.data.Error) {
                                        toaster.pop('success', "Thông báo", successRes.data.Message, 2000);
                                        jc.close();
                                        filterData();
                                    } else {
                                        toaster.pop('error', "Lỗi:", successRes.data.Message);
                                        jc.close();
                                    }
                                }, function (errorRes) {
                                    console.log(errorRes);
                                    toaster.pop('error', "Lỗi:", errorRes.statusText);
                                    jc.close();
                                });
                            }
                        },
                        cancel: {
                            text: 'Hủy',
                            action: function () {
                                jc.close();
                            }
                        }
                    }
                });
            };

            $scope.addVaiTro = function (item) {
                $uibModal.open({
                    backdrop: 'static',
                    size: 'md',
                    templateUrl: configService.buildUrl('auth/AuNguoiDungNhomQuyen', 'add'),
                    controller: 'AuNguoiDungNhomQuyenCreateCtrl',
                    resolve: {
                        targetData: function () {
                            return item;
                        }
                    }
                });
            };

            $scope.addQuyen = function (item) {
                $uibModal.open({
                    backdrop: 'static',
                    size: 'lg',
                    windowClass: 'app-modal-window',
                    templateUrl: configService.buildUrl('auth/AuNguoiDungQuyen', 'add'),
                    controller: 'AuNguoiDungQuyenCreateCtrl',
                    resolve: {
                        targetData: function () {
                            return item;
                        }
                    }
                });
            };
        }]);

    app.controller('AuNguoiDungCreateCtrl', ['$scope', '$filter', '$location', 'AuNguoiDungService', 'configService', 'tempDataService', 'toaster', '$uibModalInstance', 'targetData', 'DmDonViPhongBanService',
        function ($scope, $filter, $location, service, configService, tempDataService, toaster, $uibModalInstance, targetData, DmDonViPhongBanService) {
            $scope.config = {
                label: angular.copy(configService.label)
            };
            $scope.title = "Thêm mới";
            $scope.lstTrangThai = tempDataService.tempData('statusInt');
            $scope.target = targetData;
            console.log($scope.target);
            function notification() {
                var notificationElement = $("#notification");
                notificationElement.kendoNotification();
                var notificationWidget = notificationElement.data("kendoNotification");
                return notificationWidget;
            };
            function treeify(list, idAttr, parentAttr, childrenAttr) {
                if (!idAttr) idAttr = 'id';
                if (!parentAttr) parentAttr = 'parentId';
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
            function onChange(e) {
                e.preventDefault();
                if (this.value() && this.value().length > 0) {
                    $scope.target.ma_donvi = this.value()[0].ma;
                    document.getElementById('USERNAME').focus();
                }
            };
            DmDonViPhongBanService.pagingData().then(function (successRes) {
                if (successRes && successRes.status === 200 && successRes.data && successRes.data.data) {
                    $("#dropdowntree").kendoDropDownTree({
                        template: kendo.template($("#dropdowntree-template").html()),
                        valueTemplate: kendo.template($("#dropdowntree-value-template").html()),
                        dataTextField: "ten",
                        checkboxes: true,
                        dataSpriteCssClassField: "spriteCssClass",
                        dataSource: treeify(successRes.data.data).items,
                        filter: "startswith",
                        change: onChange
                    });
                }
            }, function (errorRes) {
                console.log(errorRes);
                toaster.pop('error', "Lỗi:", errorRes.statusText);
            });
            $scope.checkExistCode = function (userName) {
                if (userName) {
                    service.checkExistCode(userName.trim()).then(function (response) {
                        if (response && response.status === 200 && response.data) {
                            notification().warning("Mã này đã được sử dụng!");
                            $scope.target.username = "";
                            document.getElementById('USERNAME').focus();
                        }
                        else {
                            notification().success("Bạn có thể sử dụng tài khoản này");
                            document.getElementById('FULLNAME').focus();
                        }
                    });
                }
            };
            $scope.comparePassword = function (passConfirm) {
                if (passConfirm && $scope.target.password) {
                    if (passConfirm !== $scope.target.password) {
                        notification().warning("Mật khẩu xác thực không đúng!");
                        $scope.target.confirmpassword = "";
                        document.getElementById('CONFIRMPASSWORD').focus();
                    }
                }
            };
            $scope.save = function () {
                $scope.target.trangthai = 1;
                service.addNew($scope.target).then(function (successRes) {
                    console.log(successRes);
                    if (successRes && successRes.status === 200 && successRes.data.message === "Oke") {
                        notification().success("Thành công!");
                        $uibModalInstance.close();
                    } else {
                        notification().warning("Xảy ra lỗi");
                    }
                }, function (errorRes) {
                    console.log(errorRes);
                    notification().warning("Xảy ra lỗi");
                });
            };
            $scope.cancel = function () {
                $uibModalInstance.close();
            };
        }]);

    app.controller('AuNguoiDungEditCtrl', [
        '$scope', '$filter', '$location', 'AuNguoiDungService', 'configService', 'tempDataService', 'toaster', '$uibModalInstance', 'DmDonViPhongBanService', 'targetData',
        function ($scope, $filter, $location, service, configService, tempDataService, toaster, $uibModalInstance, DmDonViPhongBanService, targetData) {
            $scope.config = {
                label: angular.copy(configService.label)
            };
            $scope.title = "Cập nhật";
            $scope.target = targetData;
            $scope.target.ma_donvi = targetData.mA_DONVI;
            $scope.lstTrangThai = tempDataService.tempData('statusInt');
            function notification() {
                var notificationElement = $("#notification");
                notificationElement.kendoNotification();
                var notificationWidget = notificationElement.data("kendoNotification");
                return notificationWidget;
            };
            function treeify(list, idAttr, parentAttr, childrenAttr) {
                if (!idAttr) idAttr = 'id';
                if (!parentAttr) parentAttr = 'parentId';
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
            function onChange(e) {
                e.preventDefault();
                if (this.value() && this.value().length > 0) {
                    $scope.target.ma_donvi = this.value()[0].ma;
                    document.getElementById('USERNAME').focus();
                }
            };
            DmDonViPhongBanService.pagingData().then(function (successRes) {
                if (successRes && successRes.status === 200 && successRes.data && successRes.data.data) {
                    $("#dropdowntree").kendoDropDownTree({
                        template: kendo.template($("#dropdowntree-template").html()),
                        valueTemplate: kendo.template($("#dropdowntree-value-template").html()),
                        dataTextField: "ten",
                        checkboxes: true,
                        dataSpriteCssClassField: "spriteCssClass",
                        dataSource: treeify(successRes.data.data).items,
                        filter: "startswith",
                        change: onChange
                    });
                }
            }, function (errorRes) {
                console.log(errorRes);
                toaster.pop('error', "Lỗi:", errorRes.statusText);
            });
            $scope.comparePassword = function (passConfirm) {
                if (passConfirm && $scope.target.password) {
                    if (passConfirm !== $scope.target.password) {
                        notification().warning("Mật khẩu xác thực không đúng!");
                        $scope.target.confirmpassword = "";
                        document.getElementById('CONFIRMPASSWORD').focus();
                    }
                }
            };
            $scope.save = function () {
                service.update($scope.target).then(function (successRes) {
                    if (successRes && successRes.status === 200 && successRes.data.message === "Oke") {
                        $uibModalInstance.close();
                    } else {
                        notification().warning("Xảy ra lỗi");
                    }
                }, function (errorRes) {
                    console.log(errorRes);
                    notification().warning("Xảy ra lỗi");
                });
            };
            $scope.cancel = function () {
                $uibModalInstance.close();
            };
        }]);
    return app;
});