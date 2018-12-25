define(['controllers/dm/phf_dmKeHoachThanhTra', 'controllers/dm/phf_dmLoaiThanhTra', 'controllers/dm/phf_dmNhomThanhTra', 'controllers/dm/phf_dmDoiTuong', 'controllers/dm/phf_dmDonViPhongBan','controllers/dm/phf_dmDotThanhTra'], function () {
    'use strict';
    var app = angular.module('phf_nvKhThanhTra_Bo', ['phf_dmKeHoachThanhTra', 'phf_dmLoaiThanhTra', 'phf_DmNhomThanhTra', 'phf_DmDoiTuong', 'phf_DmDonViPhongBan', 'phf_dmDotThanhTra']);
    app.factory('nvKhThanhTra_BoService', [
        '$http', 'configService', function ($http, configService) {
            var serviceUrl = configService.rootUrlWebApi + '/nv/keHoachThanhTra';
            var result = {
                taoMaChungTu: function () {
                    return $http.get(serviceUrl + '/TaoMaChungTu');
                },
                pagingData: function () {
                    return $http.post(serviceUrl + '/pagingData');
                },
                post: function (data) {
                    return $http.post(serviceUrl + '/AddNew', data);
                },
                getDetails: function (params) {
                    return $http.post(serviceUrl + '/GetDetails', params);
                }
            }
            return result;
        }
    ]);

    app.controller('nvKhThanhTra_BoViewCtrl', [
        '$scope', '$location', 'nvKhThanhTra_BoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'DM_KEHOACHTHANHTRAService', 'DM_LOAITHANHTRAService', 'DmNhomThanhTraService', 'DmDoiTuongService', 'DmDonViPhongBanService', 'DM_DOTTHANHTRAService', 'CacheFactory',
        function ($scope, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, keHoachThanhTraService, maLoaiThanhTraService, maNhomThanhTraService, maDoiTuongService, maPhongService, maDotThanhTraService, cacheFactory) {
            var dataCache = cacheFactory.get('dataCache');
            $scope.tempData = tempDataService.tempData;
            $scope.title = "Kế hoạch thanh tra Bộ";
            function notification() {
                var notificationElement = $("#notification");
                notificationElement.kendoNotification();
                var notificationWidget = notificationElement.data("kendoNotification");
                return notificationWidget;
            };
            $scope.testWord = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    windowClass: 'app-modal-window',
                    templateUrl: configService.buildUrl('nv/KhThanhTra_Bo', 'testWord'),
                    controller: 'nvTestWordCtrl',
                    resolve: {}
                });
                modalInstance.result.then(function () {

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };
            $scope.lapKeHoach = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    windowClass: 'app-modal-window',
                    templateUrl: configService.buildUrl('nv/KhThanhTra_Bo', 'addNew'),
                    controller: 'nvKhThanhTra_BoCreateCtrl',
                    resolve: {}
                });
                modalInstance.result.then(function () {

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };
            $scope.updateKeHoach = function (e) {
                e.preventDefault();
                var dataItem = this.dataItem;
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    windowClass: 'app-modal-window',
                    templateUrl: configService.buildUrl('nv/KhThanhTra_Bo', 'edit'),
                    controller: 'nvKhThanhTra_BoEditCtrl',
                    resolve: {
                        targetData: function () {
                            return dataItem;
                        }
                    }
                });
                modalInstance.result.then(function () {

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };
            $scope.deleteKeHoach = function (target) {
                console.log(target);
            };
            //load kế hoạch thanh tra
            function getAllDmKeHoachThanhTra() {
                if (!dataCache.get('listKeHoach')) {
                    keHoachThanhTraService.getAll().then(function (response) {
                        if (response && response.status === 200 && response.data.data) {
                            $scope.listKeHoach = response.data.data;
                            dataCache.put('listKeHoach', response.data.data);
                        }
                    });
                } else {
                    $scope.listKeHoach = dataCache.get('listKeHoach');
                }
            };
            //end load đợt thanh tra

            //load đợt thanh tra
            function getAllDmDotThanhTra() {
                if (!dataCache.get('listDot')) {
                    maDotThanhTraService.getAll().then(function (response) {
                        if (response && response.status === 200 && response.data.data) {
                            $scope.listDot = response.data.data;
                            dataCache.put('listDot', response.data.data);
                        }
                    });
                } else {
                    $scope.listDot = dataCache.get('listDot');
                }
            };
            //end load đợt thanh tra

            //load loại thanh tra
            function getAllDmLoaiThanhTra() {
                if (!dataCache.get('listLoai')) {
                    maLoaiThanhTraService.getAll().then(function (response) {
                        if (response && response.status === 200 && response.data.data) {
                            $scope.listLoai = response.data.data;
                            dataCache.put('listLoai', response.data.data);
                        }
                    });
                } else {
                    $scope.listLoai = dataCache.get('listLoai');
                }
            };
            //end load loại thanh tra

            //load nhóm thanh tra
            function getAllDmNhomThanhTra() {
                if (!dataCache.get('listNhom')) {
                    maNhomThanhTraService.getAll().then(function (response) {
                        if (response && response.status === 200 && response.data.data) {
                            $scope.listNhom = response.data.data;
                            dataCache.put('listNhom', response.data.data);
                        }
                    });
                } else {
                    $scope.listNhom = dataCache.get('listNhom');
                }
            };
            //end load nhóm thanh tra

            //load đối tượng thanh tra
            function getAllDmDoiTuongThanhTra() {
                if (!dataCache.get('listDoiTuong')) {
                    maDoiTuongService.getAll().then(function (response) {
                        if (response && response.status === 200 && response.data.data) {
                            $scope.listDoiTuong = response.data.data;
                            dataCache.put('listDoiTuong', response.data.data);
                        }
                    });
                } else {
                    $scope.listDoiTuong = dataCache.get('listDoiTuong');
                }
            };
            //end load đối tượng thanh tra

            //load phòng thanh tra
            function getAllDmPhongThanhTra() {
                if (!dataCache.get('listPhong')) {
                    maPhongService.getAllPhongBan().then(function (response) {
                        if (response && response.status === 200 && response.data.data) {
                            $scope.listPhong = response.data.data;
                            dataCache.put('listPhong', response.data.data);
                        }
                    });
                } else {
                    $scope.listPhong = dataCache.get('listPhong');
                }
            };
            //end load phòng thanh tra
            getAllDmKeHoachThanhTra();
            getAllDmLoaiThanhTra();
            getAllDmNhomThanhTra();
            getAllDmDoiTuongThanhTra();
            getAllDmDotThanhTra();
            getAllDmPhongThanhTra();
            //load nghiệp vụ kế hoạch thanh tra bộ	
            $scope.khttBoDataSource = {
                transport: {
                    read: function (e) {
                        service.pagingData().then(function (response) {
                            if (response && response.status === 200 && response.data.data) {
                                e.success(response.data.data);
                            }
                        });
                    },
                    schema: {
                        data: function (data) {
                            return data;
                        },
                        total: function (data) {
                            return data['odata.count'];
                        }
                    }
                },
                pageSize: 5,
                serverPaging: true,
                serverSorting: true
            };
            //end load kế hoạch thanh tra bộ
            function displayHelper(paraValue, moduleName) {
                var data = $filter('filter')($scope.tempData(moduleName), { value: paraValue }, true);
                if (data && data.length === 1) {
                    return data[0].description;
                } else {
                    return paraValue;
                }
            };
            function filterData() {
                $scope.khttBoGridOptions = {
                    dataSource: $scope.khttBoDataSource,
                    sortable: true,
                    pageable: true,
                    dataBound: function () {
                    },
                    toolbar: [{ name: "lapKeHoach", template: "<a class='k-grid-decreaseIndent k-button' ng-click='lapKeHoach();'><span class='k-icon k-i-plus'></span>&nbsp;&nbsp;Lập kế hoạch</a>" }, { name: "testWord", template: "<a class='k-grid-decreaseIndent k-button' ng-click='testWord();'><span class='k-icon k-i-plus'></span>&nbsp;&nbsp;TestWord</a>" }],
                    editable: "popup",
                    autosync: true,
                    filterable: {
                        operators: dataCache.get('operators')[0]
                    },
                    selectable: true,
                    columns: [
                        {
                            field: "maChungTu",
                            title: "Mã chứng từ",
                            width: "100px"
                        }, {
                            field: "maDot",
                            title: "Đợt thanh tra",
                            width: "120px",
                            template: function (e) { return displayHelper(e.maDot, 'listDot'); }
                        }, {
                            field: "tuNgay",
                            title: "Từ ngày",
                            width: "100px",
                            template: '#= kendo.toString(new Date(tuNgay), "dd/MM/yyyy" ) #',
                            filterable: {
                                ui: function (element) {
                                    element.kendoDatePicker({
                                        format: "dd MM, yyyy"
                                    });
                                }
                            }
                        }, {
                            field: "denNgay",
                            title: "Đến ngày",
                            width: "100px",
                            template: '#= kendo.toString(new Date(denNgay), "dd/MM/yyyy" ) #',
                            filterable: {
                                ui: function (element) {
                                    element.kendoDatePicker({
                                        format: "dd MM, yyyy"
                                    });
                                }
                            }
                        }, {
                            field: "trangThai",
                            title: "Trạng thái",
                            width: "100px",
                            template: '#= (trangThai == 10 ) ? "Sử dụng" : "Không sử dụng" #'
                        },
                        {
                            title: "Hành động", width: 150, command: [
                                { name: "updateKeHoach", template: "<a class='k-grid-decreaseIndent k-button' ng-click='updateKeHoach($event);'><span class='k-icon k-i-edit'></span>&nbsp;&nbsp;Sửa</a>" },
								{ name: "deleteKeHoach", template: "<a class='k-grid-decreaseIndent k-button' ng-click='deleteKeHoach($event);'><span class='k-icon k-i-close'></span>&nbsp;&nbsp;Xóa</a>" }
                            ]
                        }
                    ]
                };

                $scope.detailKhttBoOptions = function (dataItem) {
                    return {
                        dataSource: {
                            transport: {
                                read: function (e) {
                                    service.getDetails(dataItem).then(function (response) {
                                        if (response && response.status === 200 && response.data.data) {
                                            e.success(response.data.data.dataDetails);
                                        }
                                    });
                                },
                                schema: {
                                    data: function (data) {
                                        return data;
                                    },
                                    total: function (data) {
                                        return data['odata.count'];
                                    }
                                }
                            },
                            serverPaging: true,
                            serverSorting: true,
                            serverFiltering: true,
                            pageSize: 5
                        },
                        scrollable: false,
                        sortable: true,
                        pageable: true,
                        columns: [
                            {
                                field: "maLoai",
                                title: "Loại thanh tra",
                                width: "100px",
                                template: function (e) { return displayHelper(e.maLoai, 'listLoai'); }
                            },
                            {
                                field: "maNhom",
                                title: "Nhóm thanh tra",
                                width: "100px",
                                template: function (e) { return displayHelper(e.maNhom, 'listNhom'); }
                            },
                            {
                                field: "maKeHoach",
                                title: "Kế hoạch",
                                width: "100px",
                                template: function (e) { return displayHelper(e.maKeHoach, 'listKeHoach'); }
                            },
                            {
                                field: "maDoiTuong",
                                title: "Đối tượng",
                                width: "100px",
                                template: function (e) { return displayHelper(e.maDoiTuong, 'listDoiTuong'); }
                            },
                            {
                                field: "maPhong",
                                title: "Phòng thanh tra",
                                width: "100px",
                                template: function (e) { return displayHelper(e.maPhong, 'listPhong'); }
                            },
                            {
                                field: "lyDo",
                                title: "Lý do",
                                width: "100px"
                            }
                        ]
                    };
                };
            };
            function loadAccessList() {
                securityService.getAccessList('phf_doivoittbo').then(function (successRes) {
                    if (successRes && successRes.status === 200) {
                        $scope.accessList = successRes.data;
                        if ($scope.accessList.view) {
                            filterData();
                        }
                    }
                }, function (errorRes) {
                    console.log(errorRes);
                    $scope.accessList = null;
                });
            }
            loadAccessList();
        }]);
    app.controller('nvKhThanhTra_BoCreateCtrl', ['$scope', '$uibModalInstance', '$location', 'nvKhThanhTra_BoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'DM_KEHOACHTHANHTRAService', 'DM_LOAITHANHTRAService', 'DmNhomThanhTraService', 'DmDoiTuongService', 'DmDonViPhongBanService', 'DM_DOTTHANHTRAService', 'CacheFactory',
    function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, keHoachThanhTraService, maLoaiThanhTraService, maNhomThanhTraService, maDoiTuongService, maPhongService, maDotThanhTraService, cacheFactory) {
        $scope.config = angular.copy(configService);
        $scope.tempData = tempDataService.tempData;
        $scope.isLoading = false;
        $scope.title = 'Kế hoạch thanh tra bộ';
        $scope.newItem = {};
        $scope.target = {
            dataDetails: []
        };
        var dataCache = cacheFactory.get('dataCache');
        function notification() {
            var notificationElement = $("#notification");
            notificationElement.kendoNotification();
            var notificationWidget = notificationElement.data("kendoNotification");
            return notificationWidget;
        };
        //tạo mã phiếu
        service.taoMaChungTu().then(function (response) {
            if (response && response.status === 200 && response.data) {
                $scope.target.maChungTu = response.data.maChungTu;
                $scope.target.ngayTao = new Date(response.data.ngayTao);
                $scope.target.tuNgay = new Date(response.data.tuNgay);
                $scope.target.denNgay = new Date(response.data.denNgay);
                $scope.target.nguoiTao = response.data.nguoiTao;
                $scope.target.maDonVi = response.data.maDonVi;
            }
        });
        //end tạo mã phiếu
        //load kế hoạch
        $scope.keHoachDataSource = {
            transport: {
                read: function (e) {
                    keHoachThanhTraService.getAll().then(function (response) {
                        if (response && response.status === 200 && response.data.data) {
                            e.success(response.data.data);
                        }
                    });
                },
                dataType: "json"
            }
        };
        //end load kế hoạch

        //load loại kế hoạch
        $scope.maLoaiDataSource = {
            transport: {
                read: function (e) {
                    maLoaiThanhTraService.getAll().then(function (response) {
                        if (response && response.status === 200 && response.data.data) {
                            e.success(response.data.data);
                        }
                    });
                },
                dataType: "json"
            }
        };
        //end load loại kế hoạch

        //load nhóm kế hoạch
        $scope.maNhomDataSource = {
            transport: {
                read: function (e) {
                    maNhomThanhTraService.getAll().then(function (response) {
                        if (response && response.status === 200 && response.data.data) {
                            e.success(response.data.data);
                        }
                    });
                },
                dataType: "json"
            }
        };
        //end load nhóm kế hoạch

        //load đối tượng
        $scope.maDoiTuongDataSource = {
            transport: {
                read: function (e) {
                    maDoiTuongService.getAll().then(function (response) {
                        if (response && response.status === 200 && response.data.data) {
                            e.success(response.data.data);
                        }
                    });
                },
                dataType: "json"
            }
        };
        //end load đối tượng

        //load phòng
        $scope.maPhongDataSource = {
            transport: {
                read: function (e) {
                    maPhongService.getAllPhongBan().then(function (response) {
                        if (response && response.status === 200 && response.data.data) {
                            e.success(response.data.data);
                        }
                    });
                },
                dataType: "json"
            }
        };
        //end load phòng

        //load đợt thanh tra
        $scope.maDotDataSource = {
            transport: {
                read: function (e) {
                    maDotThanhTraService.getAll().then(function (response) {
                        if (response && response.status === 200 && response.data.data) {
                            e.success(response.data.data);
                            dataCache.put('listDot', response.data.data);
                        }
                    });
                },
                dataType: "json"
            }
        };
        //end load đợt thanh tra
        $scope.chonDotThanhTra = function (maDot) {
            if (maDot && dataCache.get('listDot')) {
                var data = $filter('filter')(dataCache.get('listDot'), { value: maDot }, true);
                if (data && data.length === 1) {
                    $scope.target.tuNgay = new Date(data[0].fromDate);
                    $scope.target.denNgay = new Date(data[0].toDate);
                    $scope.target.thongTinDot = "Đợt thanh tra: Mã " + data[0].value + " - Nội dung: " + data[0].description + " - Từ ngày: " + $filter('date')(new Date(data[0].fromDate), "dd-MM-yyyy") + " đến ngày: " + $filter('date')(new Date(data[0].toDate), "dd-MM-yyyy");
                }
            }
        };
        $scope.addRow = function () {
            if (!$scope.newItem.maKeHoach) {
                notification().warning("Mã kế hoạch không được rỗng!");
                $("#MAKEHOACH").data("kendoDropDownList").focus();
            }
            else if (!$scope.newItem.maLoai) {
                notification().warning("Mã loại không được rỗng!");
                $("#MALOAI").data("kendoDropDownList").focus();
            }
            else if (!$scope.newItem.maNhom) {
                notification().warning("Mã nhóm không được rỗng!");
                $("#MANHOM").data("kendoDropDownList").focus();
            }
            else if (!$scope.newItem.maDoiTuong) {
                notification().warning("Mã đối tượng không được rỗng!");
                $("#MADOITUONG").data("kendoDropDownList").focus();
            }
            else if (!$scope.newItem.maPhong) {
                notification().warning("Mã phòng không được rỗng!");
                $("#MAPHONG").data("kendoDropDownList").focus();
            }
            else {
                $scope.target.DataDetails.push($scope.newItem);
                $scope.newItem = {};
                $("#MAKEHOACH").data("kendoDropDownList").focus();
            }
        };

        $scope.save = function () {
            var loaiThanhTra = $filter('filter')($scope.tempData('typeUnit'), { key: 0 }, true);
            if (loaiThanhTra && loaiThanhTra.length === 1) {
                $scope.target.loai = loaiThanhTra[0].value;
            }
            $scope.target.trangThai = 10;
            //index để sắp xếp
            if ($scope.target && $scope.target.dataDetails.length > 0) {
                angular.forEach($scope.target.dataDetails, function (value, index) {
                    value.sapXep = index;
                });
            }
            service.post($scope.target).then(function (response) {
                if (response && response.status === 201 && response.data.status) {
                    notification().success("Thêm mới thành công!");
                    $uibModalInstance.close();
                } else {
                    console.log('error', response);
                    notification().warning("Xảy ra lỗi!");
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


    app.controller('nvTestWordCtrl', ['$scope', '$uibModalInstance', '$location', 'nvKhThanhTra_BoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'FileUploader',
   function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, FileUploader) {
       $scope.config = angular.copy(configService);
       $scope.tempData = tempDataService.tempData;
       $scope.isLoading = false;
       $scope.title = 'Test Word';
       var serviceUrl = configService.rootUrlWebApi + '/nv/keHoachThanhTra';
       var uploader = $scope.uploader = new FileUploader({
           url: serviceUrl + '/UploadWord'
       });
       uploader.filters.push({
           name: 'syncFilter',
           fn: function (item, options) {
               return this.queue.length < 10;
           }
       });
       uploader.filters.push({
           name: 'asyncFilter',
           fn: function (item, options, deferred) {
               setTimeout(deferred.resolve, 1e3);
           }
       });
       uploader.onSuccessItem = function (fileItem, response, status, headers) {
           console.log(response);
       };

       $scope.cancel = function () {
           $uibModalInstance.close();
       };
   }]);
    app.controller('nvKhThanhTra_BoEditCtrl', ['$scope', '$uibModalInstance', '$location', 'nvKhThanhTra_BoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'DM_KEHOACHTHANHTRAService', 'DM_LOAITHANHTRAService', 'DmNhomThanhTraService', 'DmDoiTuongService', 'DmDonViPhongBanService', 'DM_DOTTHANHTRAService', 'CacheFactory', 'targetData',
    function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, keHoachThanhTraService, maLoaiThanhTraService, maNhomThanhTraService, maDoiTuongService, maPhongService, maDotThanhTraService, cacheFactory, targetData) {
        $scope.config = angular.copy(configService);
        $scope.tempData = tempDataService.tempData;
        $scope.isLoading = false;
        $scope.title = 'Cập nhật kế hoạch thanh tra bộ';
        var dataCache = cacheFactory.get('dataCache');
        $scope.newItem = {};
        $scope.target = {};
        function getDetails() {
            service.getDetails(targetData).then(function (response) {
                if (response && response.status === 200 && response.data.data) {
                    $scope.target = response.data.data;
                }
            });
        };
        getDetails();
        console.log($scope.target);
        function notification() {
            var notificationElement = $("#notification");
            notificationElement.kendoNotification();
            var notificationWidget = notificationElement.data("kendoNotification");
            return notificationWidget;
        };
        //tạo mã phiếu
        service.taoMaChungTu().then(function (response) {
            if (response && response.status === 200 && response.data) {
                $scope.target.maChungTu = response.data.maChungTu;
                $scope.target.ngayTao = new Date(response.data.ngayTao);
                $scope.target.tuNgay = new Date(response.data.tuNgay);
                $scope.target.denNgay = new Date(response.data.denNgay);
                $scope.target.nguoiTao = response.data.nguoiTao;
                $scope.target.maDonVi = response.data.maDonVi;
            }
        });
        //end tạo mã phiếu
        //load kế hoạch
        $scope.keHoachDataSource = {
            transport: {
                read: function (e) {
                    keHoachThanhTraService.getAll().then(function (response) {
                        if (response && response.status === 200 && response.data.data) {
                            e.success(response.data.data);
                        }
                    });
                },
                dataType: "json"
            }
        };
        //end load kế hoạch

        //load loại kế hoạch
        $scope.maLoaiDataSource = {
            transport: {
                read: function (e) {
                    maLoaiThanhTraService.getAll().then(function (response) {
                        if (response && response.status === 200 && response.data.data) {
                            e.success(response.data.data);
                        }
                    });
                },
                dataType: "json"
            }
        };
        //end load loại kế hoạch

        //load nhóm kế hoạch
        $scope.maNhomDataSource = {
            transport: {
                read: function (e) {
                    maNhomThanhTraService.getAll().then(function (response) {
                        if (response && response.status === 200 && response.data.data) {
                            e.success(response.data.data);
                        }
                    });
                },
                dataType: "json"
            }
        };
        //end load nhóm kế hoạch

        //load đối tượng
        $scope.maDoiTuongDataSource = {
            transport: {
                read: function (e) {
                    maDoiTuongService.getAll().then(function (response) {
                        if (response && response.status === 200 && response.data.data) {
                            e.success(response.data.data);
                        }
                    });
                },
                dataType: "json"
            }
        };
        //end load đối tượng

        //load phòng
        $scope.maPhongDataSource = {
            transport: {
                read: function (e) {
                    maPhongService.getAllPhongBan().then(function (response) {
                        if (response && response.status === 200 && response.data.data) {
                            e.success(response.data.data);
                        }
                    });
                },
                dataType: "json"
            }
        };
        //end load phòng

        //load đợt thanh tra
        $scope.maDotDataSource = {
            transport: {
                read: function (e) {
                    maDotThanhTraService.getAll().then(function (response) {
                        if (response && response.status === 200 && response.data.data) {
                            e.success(response.data.data);
                            dataCache.put('listDot', response.data.data);
                        }
                    });
                },
                dataType: "json"
            }
        };
        //end load đợt thanh tra
        $scope.chonDotThanhTra = function (maDot) {
            if (maDot && dataCache.get('listDot')) {
                var data = $filter('filter')(dataCache.get('listDot'), { value: maDot }, true);
                if (data && data.length === 1) {
                    $scope.target.tuNgay = new Date(data[0].fromDate);
                    $scope.target.denNgay = new Date(data[0].toDate);
                    $scope.target.thongTinDot = "Đợt thanh tra: Mã " + data[0].value + " - Nội dung: " + data[0].description + " - Từ ngày: " + $filter('date')(new Date(data[0].fromDate), "dd-MM-yyyy") + " đến ngày: " + $filter('date')(new Date(data[0].toDate), "dd-MM-yyyy");
                }
            }
        };
        $scope.addRow = function () {
            if (!$scope.newItem.maKeHoach) {
                notification().warning("Mã kế hoạch không được rỗng!");
                $("#MAKEHOACH").data("kendoDropDownList").focus();
            }
            else if (!$scope.newItem.maLoai) {
                notification().warning("Mã loại không được rỗng!");
                $("#MALOAI").data("kendoDropDownList").focus();
            }
            else if (!$scope.newItem.maNhom) {
                notification().warning("Mã nhóm không được rỗng!");
                $("#MANHOM").data("kendoDropDownList").focus();
            }
            else if (!$scope.newItem.maDoiTuong) {
                notification().warning("Mã đối tượng không được rỗng!");
                $("#MADOITUONG").data("kendoDropDownList").focus();
            }
            else if (!$scope.newItem.maPhong) {
                notification().warning("Mã phòng không được rỗng!");
                $("#MAPHONG").data("kendoDropDownList").focus();
            }
            else {
                $scope.target.dataDetails.push($scope.newItem);
                $scope.newItem = {};
                $("#MAKEHOACH").data("kendoDropDownList").focus();
            }
        };

        $scope.save = function () {
            var loaiThanhTra = $filter('filter')($scope.tempData('typeUnit'), { key: 0 }, true);
            if (loaiThanhTra && loaiThanhTra.length === 1) {
                $scope.target.loai = loaiThanhTra[0].value;
            }
            $scope.target.trangThai = 10;
            //index để sắp xếp
            if ($scope.target && $scope.target.dataDetails.length > 0) {
                angular.forEach($scope.target.dataDetails, function (value, index) {
                    value.sapXep = index;
                });
            }
            service.post($scope.target).then(function (response) {
                if (response && response.status === 201 && response.data.status) {
                    notification().success("Thêm mới thành công!");
                    $uibModalInstance.close();
                } else {
                    console.log('error', response);
                    notification().warning("Xảy ra lỗi!");
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

    return app;
});