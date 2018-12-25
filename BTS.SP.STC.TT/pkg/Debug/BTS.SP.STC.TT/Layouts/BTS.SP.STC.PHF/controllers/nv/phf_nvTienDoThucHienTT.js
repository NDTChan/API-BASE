define(['controllers/dm/phf_dmDonViPhongBan', 'controllers/dm/phf_dmCanBo', 'controllers/dm/phf_dmDotThanhTra'], function () {
    'use strict';
    var app = angular.module('phf_nvTienDoThucHienTT', ['phf_dmDonViPhongBan', 'phf_dmCanBo', 'phf_dmDotThanhTra']);
    app.factory('serviceSelected', function () {
        var selectedData = [];
        var result = {
            getSelectData: function () {
                return selectedData;
            },
            setSelectData: function (array) {
                selectedData = array;
            }
        }
        return result;
    });

    app.factory('TienDoThucHienTTService', ['$http', 'configService', function ($http, configService) {
        var serviceUrl = configService.rootUrlWebApi + '/nv/phf_nvTienDoThucHienTT';
        var serviceUrlDoiTuong = configService.rootUrlWebApi + '/dm/phf_dmDoiTuong';
        var serviceUrlPhanCongKeHoach = configService.rootUrlWebApi + '/nv/phf_phanCongKeHoach';
        var serviceUrl_DoiTuong = configService.rootUrlWebApi + '/dm/phf_dmDoiTuong';
        var serviceUrl_PhongBan = configService.rootUrlWebApi + '/dm/phf_dmDonViPhongBan';
        var serviceUrl_KeHoachThanhTra = configService.rootUrlWebApi + '/dm/phf_dmKeHoachThanhTra';
        var serviceUrl_LoaiThanhTra = configService.rootUrlWebApi + '/dm/dmLoaiThanhTra';
        var serviceUrl_NhomThanhTra = configService.rootUrlWebApi + '/dm/phf_dmNhomThanhTra';
        var serviceUrl_DotThanhTra = configService.rootUrlWebApi + '/dm/phf_dmDotThanhTra';
        var serviceUrl_CanBo = configService.rootUrlWebApi + '/dm/phf_dmCanBo';
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
            GetDoiTuongByDot: function (maDot) {
                return $http.get(serviceUrl + '/GetDoiTuongByDot/' + maDot);
            },
            GetDataDetailByYear: function (year) {
                return $http.get(serviceUrlDoiTuong + '/GetDataDetailByYear/' + year);
            },
            GetObjectByDoiTuong: function (maPhieu) {
                return $http.get(serviceUrlPhanCongKeHoach + '/GetObjectByDoiTuong/' + maPhieu);
            },
            getSelectData_DoiTuong: function () {
                return $http.get(serviceUrl_DoiTuong + '/GetSelectData');
            },
            getSelectData_PhongBan: function () {
                return $http.get(serviceUrl_PhongBan + '/GetSelectDataDonVi');
            },
            getSelectData_CanBo: function () {
                return $http.get(serviceUrl_CanBo + '/GetSelectData');
            },
            getSelectData_KeHoachThanhTra: function () {
                return $http.get(serviceUrl_KeHoachThanhTra + '/GetSelectData');
            },
            getSelectData_LoaiThanhTra: function () {
                return $http.get(serviceUrl_LoaiThanhTra + '/GetSelectData');
            },
            getSelectData_NhomThanhTra: function () {
                return $http.get(serviceUrl_NhomThanhTra + '/GetSelectData');
            },
            getSelectData_DotThanhTra: function () {
                return $http.get(serviceUrl_DotThanhTra + '/GetSelectData');
            },
            GetDetailByRefId: function (refid) {
                return $http.get(serviceUrl + '/GetDetailByRefId/' + refid);
            }
        }
        return result;
    }]);

    app.controller('TienDoThucHienTTViewCtrl', ['$scope', '$location', '$stateParams', 'TienDoThucHienTTService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster', 'ngNotify',
    function ($scope, $location, $stateParams, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster, ngNotify) {
        $scope.config = {
            label: angular.copy(configService.label)
        }
        $scope.paged = angular.copy(configService.pageDefault);
        $scope.filtered = angular.copy(configService.filterDefault);
        $scope.tempData = tempDataService.tempData;
        $scope.accessList = {};
        $scope.target = {};
        $scope.target.NAM = new Date().getFullYear();
        if ($stateParams.MA_DOT != "") {
            $scope.target.MA_DOT = $stateParams.MA_DOT;
        }
        $scope.filtered.AdvanceData = angular.copy($scope.target);
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
            securityService.getAccessList('phf_nvTienDoThucHienTT').then(function (successRes) {
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

        function loadDmDoiTuongThanhTra() {
            service.getSelectData_DoiTuong().then(function (successRes) {
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
            service.getSelectData_PhongBan().then(function (successRes) {
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

        function loadDmDotThanhTra() {
            service.getSelectData_DotThanhTra().then(function (successRes) {
                if (successRes && successRes.status == 200 && successRes.data) {
                    $scope.lstDmDotThanhTra = successRes.data;
                    console.log('$stateParams', $stateParams);
                    if ($stateParams.MA_DOT != "") {
                        $scope.target.MA_DOT = $stateParams.MA_DOT;
                        $scope.doSearch();
                        $scope.create();
                    }

                } else {
                    console.log('successRes', successRes);
                }
            }, function (errorRes) {
                console.log('errorRes', errorRes);
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
                templateUrl: configService.buildUrl('nv/phf_nvTienDoThucHienTT', 'add'),
                controller: 'TienDoThucHienTTCreateViewCtrl',
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
                templateUrl: configService.buildUrl('nv/phf_nvTienDoThucHienTT', 'edit'),
                controller: 'TienDoThucHienTTEditViewCtrl',
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
                templateUrl: configService.buildUrl('nv/phf_nvTienDoThucHienTT', 'detail'),
                controller: 'TienDoThucHienTTDetailViewCtrl',
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
                templateUrl: configService.buildUrl('nv/phf_nvTienDoThucHienTT', 'delete'),
                controller: 'TienDoThucHienTTDeleteViewCtrl',
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

    app.controller('TienDoThucHienTTCreateViewCtrl', ['$scope', '$uibModalInstance', '$location', 'TienDoThucHienTTService', 'DmDonViPhongBanService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', 'ngNotify', 'serviceSelected', 'DmDotThanhTraService',
    function ($scope, $uibModalInstance, $location, service, DmDonViPhongBanService, configService, $state, tempDataService, $filter, $uibModal, ngNotify, serviceSelected, DmDotThanhTraService) {
        $scope.config = angular.copy(configService);
        $scope.tempData = tempDataService.tempData;
        $scope.lstDmKeHoachThanhTra = [];
        $scope.lstDmLoaiThanhTra = [];
        $scope.lstDmCanBo = [];
        $scope.lstDmNhomThanhTra = [];
        $scope.lstDmPhongThanhTra = [];
        $scope.lstDmDoiTuongThanhTra = [];
        $scope.target = {};
        $scope.dataSources = [];
        $scope.target.MA_PHIEU = "";
        $scope.target.NAM_THANHTRA = (new Date()).getFullYear();
        $scope.target.DETAILS = [];
        $scope.isLoading = false;
        var data = []
        $scope.title = function () { return 'Thêm mới phiếu theo dõi cán bộ thanh tra'; };
        $scope.formatLabel = function (model, module) {
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
        $scope.ChangYear = function (year) {
            var cuYear = year.toString();
            loadDmDoiTuongThanhTra(cuYear);
        }
        $scope.ChangDoiTuong = function (item) {
            if (item.DOI_TUONG_TT == null) {
                $(".input-add-tv").attr('disabled', 'disabled');
            } else {
                $(".input-add-tv").removeAttr('disabled');
            }
            console.log("itemm", item);
            var DoiTuongTemp = {};
            service.GetDataDetailByMaDoiTuong(item.DOI_TUONG_TT).then(function (successRes) {
                if (successRes && successRes.status == 200 && successRes.data) {
                    console.log("successRes2", successRes);
                    DoiTuongTemp = successRes.data.Data;
                    if (DoiTuongTemp != null) {
                        service.GetObjectByDoiTuong(DoiTuongTemp.MA_PHIEU).then(function (successRes) {
                            if (successRes && successRes.status == 200 && successRes.data) {
                                console.log("successRes3", successRes);
                                var ObjectTemp = successRes.data.Data;
                                item.DOI_TUONG_TT = DoiTuongTemp.DOITUONG_THANHTRA;
                                item.KE_HOACH_TT = DoiTuongTemp.KEHOACH_THANHTRA;
                                item.LOAI_TT = DoiTuongTemp.LOAI_THANHTRA;
                                item.NHOM_TT = DoiTuongTemp.NHOM_THANHTRA;
                                item.PHONG_TT = DoiTuongTemp.PHONG_THANHTRA;
                                item.NGAY_TRIENKHAI = new Date(ObjectTemp.TUNGAY);
                                item.NGAY_KETTHUC = new Date(ObjectTemp.DENNGAY);

                                $scope.ChangeDateTime(item);
                                //$scope.target.DETAILS.push(item);
                            } else {
                                console.log('successRes', successRes);
                            }
                        }, function (errorRes) {
                            console.log('errorRes', errorRes);
                        });
                    } else {
                        item.KE_HOACH_TT = "";
                        item.LOAI_TT = "";
                        item.NHOM_TT = "";
                        item.PHONG_TT = "";
                        item.NGAY_TRIENKHAI = null;
                        item.NGAY_KETTHUC = null;
                        $scope.ChangeDateTime(item);
                    }
                } else {
                    console.log('successRes', successRes);
                }
            }, function (errorRes) {
                console.log('errorRes', errorRes);
            });
        }
        $scope.ChangeDateTime = function (item) {
            var oneDay = 24 * 60 * 60 * 1000;
            var startDate = new Date(item.NGAY_TRIENKHAI);
            var endDate = new Date(item.NGAY_KETTHUC);
            var seconds = Math.round(Math.abs((startDate.getTime() - endDate.getTime()) / (oneDay)));
            item.THOIHAN_TT = seconds;
        }

        function loadDataSourceKendo() {
            service.GetDoiTuongByDot($scope.target.DOT_THANHTRA).then(function (successRes) {
                if (successRes && successRes.status == 200 && successRes.data) {
                    var data = successRes.data.Data
                    for (var i = 0; i < data.PHF_XD_KH_THANHTRA_BO_CHITIETs.length; i++) {
                        var tmpDetails = {}
                        tmpDetails.id = data.PHF_XD_KH_THANHTRA_BO_CHITIETs[i].MA_DOITUONG
                        tmpDetails.Text = data.PHF_XD_KH_THANHTRA_BO_CHITIETs[i].TEN_DOITUONG
                        tmpDetails.PHONG_CHUTRI = data.PHF_XD_KH_THANHTRA_BO_CHITIETs[i].PHONG_CHUTRI
                        tmpDetails.parentId = data.PHF_XD_KH_THANHTRA_BO_CHITIETs[i].MA_DOITUONG_CHA
                        $scope.dataSources.push(tmpDetails)

                    }
                    if ($scope.dataSources != null) {
                        genKenDo()
                    }

                } else {
                    console.log('successRes', successRes);
                }
            }, function (errorRes) {
                console.log('errorRes', errorRes);
            });
        }

        function genKenDo() {
            var dataSources = new kendo.data.TreeListDataSource({
                data: $scope.dataSources,
                transport: {
                    read: function (e) {
                        e.success($scope.dataSources)
                    },
                    update: function (e) {
                        e.success(e.data)
                    },
                    parameterMap: function (options, operation) {
                        if (operation !== "read" && options.models) {
                            return { models: kendo.stringify(options.models) };
                        }
                    }
                },
                schema: {
                    model: {
                        id: "id",
                        parentId: "parentId",
                        fields: {
                            PHONG_CHUTRI: { field: "PHONG_CHUTRI", nullable: true },
                            TRUONGDOAN_TT: { field: "TRUONGDOAN_TT", nullable: true },
                            THANHVIEN_DOAN: { field: "THANHVIEN_DOAN", nullable: true },
                            SO_NGAY_THANG_QG: { field: "SO_NGAY_THANG_QG", nullable: true },
                            THOIHAN_TT: { field: "THOIHAN_TT", type: "number", nullable: true },
                            NGAY_TRIENKHAI: { field: "NGAY_TRIENKHAI", nullable: true },
                            NGAY_KETTHUC: { field: "NGAY_KETTHUC", nullable: true },
                            GIAMSAT_DOAN: { field: "GIAMSAT_DOAN", nullable: true },
                        },
                        expanded: false
                    }
                },
            });
            $("#treelist").kendoTreeList({
                dataSource: dataSources,
                editable: "popup",
                height: 540,
                resizable: true,
                edit: function (e) {
                    $(e.container).parent().css({
                        width: '500px',
                    });
                },
                expand: function (e) {

                },
                columns: [
                    {
                        field: "Text",
                        expandable: true,
                        width: 350,
                        title: "ĐỐI TƯỢNG THANH TRA, KIỂM TRA",
                        editor: function (container, options) {
                            var input = $("<input/>");
                            input.attr("name", options.field);
                            input.appendTo(container);
                            input.attr("style", 'width:100%');
                            input.kendoMaskedTextBox({
                                mask: ""
                            });
                        }
                    },
                    {
                        field: "PHONG_CHUTRI",
                        title: "PHÒNG TRỤ TRÌ",
                        editor: function (container, options) {
                            var input = $("<input/>");
                            input.attr("name", options.field);
                            input.appendTo(container);
                            input.attr("style", 'width:100%');
                            input.attr("disable", 'true');
                            input.kendoMaskedTextBox({
                                mask: ""
                            });
                        }
                    },
                    {
                        field: "TRUONGDOAN_TT",
                        title: "Trưởng đoàn thanh tra",
                        editor: function (container, options) {
                            var input = $("<input/>");
                            input.attr("name", options.field);
                            input.appendTo(container);
                            input.attr("style", 'width:100%');
                            input.kendoAutoComplete({
                                placeholder: "Chọn...",
                                dataTextField: "Text",
                                dataValueField: "Value",
                                dataSource: $scope.lstDmCanBo
                            });
                        }
                    },
                    {
                        field: "THANHVIEN_DOAN",
                        title: "Thành viên đoàn",
                        width: 120,
                        template: "# if(THANHVIEN_DOAN){for (var i=0; i<THANHVIEN_DOAN.length; i++){# #: THANHVIEN_DOAN[i].Text + ',' ## }} #",
                        editor: function (container, options) {
                            var input = $("<input/>");
                            input.attr("name", options.field);
                            input.attr("style", 'width:100%');
                            input.appendTo(container);
                            input.kendoMultiSelect({
                                placeholder: "Chọn...",
                                dataTextField: "Text",
                                dataValueField: "Value",
                                height: 200,
                                dataSource: $scope.lstDmCanBo,
                            });
                        }
                    },
                    {
                        field: "SO_NGAY_THANG_QG",
                        title: "Số ngày tháng QG",
                        template: "#= kendo.toString(SO_NGAY_THANG_QG, 'dd/MM/yyyy') #",
                        editor: function (container, options) {
                            var input = $("<input/>");
                            input.attr("style", 'width:100%');
                            input.attr("name", options.field);
                            input.appendTo(container);
                            input.kendoDatePicker();
                        }
                    },
                    {
                        field: "THOIHAN_TT",
                        title: "Thời hạn thanh tra",
                        editor: function (container, options) {
                            var input = $("<input/>");
                            input.attr("name", options.field);
                            input.appendTo(container);
                            input.attr("style", 'width:100%');
                            input.kendoMaskedTextBox({
                                mask: ""
                            });
                        }
                    },
                    {
                        field: "NGAY_TRIENKHAI",
                        title: "Ngày tháng triển khai theo đơn vị",
                        template: "#= kendo.toString(NGAY_TRIENKHAI, 'dd/MM/yyyy') #",
                        editor: function (container, options) {
                            var input = $("<input/>");
                            input.attr("style", 'width:100%');
                            input.attr("name", options.field);
                            input.appendTo(container);
                            input.kendoDatePicker();
                        }
                    },
                    {
                        field: "NGAY_KETTHUC",
                        title: "Ngày tháng kết thúc theo đơn vị",
                        template: "#= kendo.toString(NGAY_KETTHUC, 'dd/MM/yyyy') #",
                        editor: function (container, options) {
                            var input = $("<input/>");
                            input.attr("name", options.field);
                            input.attr("style", 'width:100%');
                            input.appendTo(container);
                            input.kendoDatePicker();
                        }
                    },
                    {
                        field: "GIAMSAT_DOAN",
                        title: "Giám sát đoàn thanh tra",
                        editor: function (container, options) {
                            var input = $("<input/>");
                            input.attr("name", options.field);
                            input.attr("style", 'width:100%');
                            input.appendTo(container);
                            input.kendoAutoComplete({
                                placeholder: "Chọn...",
                                dataTextField: "Text",
                                dataValueField: "Value",
                                dataSource: $scope.lstDmCanBo
                            });
                        }
                    },
                    {
                        command: [
                            {
                                name: "edit",
                                text: "Sửa",
                            },
                        ],
                        width: 100
                    }
                ]
            })
        }

        function loadDmCanBo() {
            service.getSelectData_CanBo().then(function (successRes) {
                if (successRes && successRes.status == 200 && successRes.data) {
                    $scope.lstDmCanBo = successRes.data;
                } else {
                    console.log('successRes', successRes);
                }
            }, function (errorRes) {
                console.log('errorRes', errorRes);
            });
        }
        loadDmCanBo();
        function loadDmDotThanhTra() {
            DmDotThanhTraService.getSelectData().then(function (successRes) {
                if (successRes && successRes.status == 200 && successRes.data) {
                    $scope.lstDmDotThanhTra = successRes.data;
                    $scope.target.DOT_THANHTRA = $scope.lstDmDotThanhTra[0].Value;
                    loadDataSourceKendo();
                    $("#dropdownDotThanhTra").kendoDropDownList({
                        dataTextField: "Text",
                        dataValueField: "Value",
                        dataSource: $scope.lstDmDotThanhTra,
                        change: function (e) {
                            $scope.target.DOT_THANHTRA = this.value();
                            loadDataSourceKendo();
                        }
                    });
                } else {
                    console.log('successRes', successRes);
                }
            }, function (errorRes) {
                console.log('errorRes', errorRes);
            });
        }
        loadDmDotThanhTra();
        function loadDmKeHoachThanhTra() {
            service.getSelectData_KeHoachThanhTra().then(function (successRes) {
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
            service.getSelectData_LoaiThanhTra().then(function (successRes) {
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
            service.getSelectData_NhomThanhTra().then(function (successRes) {
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
        function loadDmPhongThanhTra() {
            service.getSelectData_PhongBan().then(function (successRes) {
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
        function loadDmDoiTuongThanhTra(year) {
            service.GetDataDetailByYear(year).then(function (successRes) {
                if (successRes && successRes.status == 200 && successRes.data) {
                    $scope.lstDmDoiTuongThanhTra = successRes.data;
                } else {
                    console.log('successRes', successRes);
                }
            }, function (errorRes) {
                console.log('errorRes', errorRes);
            });
        }
        loadDmDoiTuongThanhTra($scope.target.NAM_THANHTRA.toString());

        function convertToDetail() {
            $scope.target.DETAILS = [];
            for (var i = 0 ; i < $scope.dataSources.length; i++) {
                var tmp = {};
                tmp.DOI_TUONG_TT = $scope.dataSources[i].Text
                tmp.TRUONGDOAN_TT = $scope.dataSources[i].TRUONGDOAN_TT
                tmp.PHONG_TT = $scope.dataSources[i].PHONG_CHUTRI
                var thanhvien = ''
                if ($scope.dataSources[i].THANHVIEN_DOAN != null) {
                    for (var j = 0; j < $scope.dataSources[i].THANHVIEN_DOAN.length; j++) {
                        thanhvien += $scope.dataSources[i].THANHVIEN_DOAN[j].Text + ','
                    }
                }
                tmp.THANHVIEN_DOAN = thanhvien
                tmp.SO_NGAY_THANG_QG = $scope.dataSources[i].SO_NGAY_THANG_QG
                tmp.THOIHAN_TT = $scope.dataSources[i].THOIHAN_TT
                tmp.NGAY_TRIENKHAI = $scope.dataSources[i].NGAY_TRIENKHAI
                tmp.NGAY_KETTHUC = $scope.dataSources[i].NGAY_KETTHUC
                tmp.GIAMSAT_DOAN = $scope.dataSources[i].GIAMSAT_DOAN
                tmp.MA_DOITUONG = $scope.dataSources[i].id
                tmp.MA_DOITUONG_CHA = $scope.dataSources[i].parentId
                $scope.target.DETAILS.push(tmp)
            }
            console.log('$scope.target.DETAILS', $scope.target.DETAILS)
        }
        $scope.add = function () {
            convertToDetail()
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
            //convertToDetail()
            $uibModalInstance.close();
        };
    }]);

    app.controller('TienDoThucHienTTEditViewCtrl', ['$scope', '$uibModalInstance', '$location', 'TienDoThucHienTTService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify', '$timeout',
    function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify, $timeout) {
        $timeout(function () {
            $scope.target = targetData;
            $scope.targetData = angular.copy(targetData);
            loadDmDoiTuongThanhTra($scope.target.NAM_THANHTRA.toString());
            loadDataDetails();
        }, 250);
        $scope.lstDmKeHoachThanhTra = [];
        $scope.lstDmLoaiThanhTra = [];
        $scope.lstDmCanBo = [];
        $scope.lstDmNhomThanhTra = [];
        $scope.lstDmPhongThanhTra = [];
        $scope.lstDmDoiTuongThanhTra = [];
        $scope.dataSources = [];
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

        $scope.title = function () { return 'Cập nhật phiếu theo dõi cán bộ thanh tra'; };

        function genKenDo() {
            console.log('$scope.dataSources', $scope.dataSources)
            var dataSources = new kendo.data.TreeListDataSource({
                data: $scope.dataSources,
                transport: {
                    read: function (e) {
                        e.success($scope.dataSources)
                    },
                    update: function (e) {
                        e.success(e.data)
                    },
                    parameterMap: function (options, operation) {
                        if (operation !== "read" && options.models) {
                            return { models: kendo.stringify(options.models) };
                        }
                    }
                },
                schema: {
                    model: {
                        id: "MA_DOITUONG",
                        parentId: "MA_DOITUONG_CHA",
                        fields: {
                            MA_DOITUONG: { field: "MA_DOITUONG", nullable: false },
                            MA_DOITUONG_CHA: { field: "MA_DOITUONG_CHA", nullable: true, type: 'number' },
                            DOI_TUONG_TT: { field: "DOI_TUONG_TT", nullable: true },
                            PHONG_TT: { field: "PHONG_TT", nullable: true },
                            TRUONGDOAN_TT: { field: "TRUONGDOAN_TT", nullable: true },
                            THANHVIEN_DOAN: { field: "THANHVIEN_DOAN", nullable: true },
                            SO_NGAY_THANG_QG: { field: "SO_NGAY_THANG_QG", nullable: true, type: 'date' },
                            THOIHAN_TT: { field: "THOIHAN_TT", type: "number", nullable: true },
                            NGAY_TRIENKHAI: { field: "NGAY_TRIENKHAI", nullable: true, type: 'date' },
                            NGAY_KETTHUC: { field: "NGAY_KETTHUC", nullable: true, type: 'date' },
                            GIAMSAT_DOAN: { field: "GIAMSAT_DOAN", nullable: true },
                        },
                        expanded: false
                    }
                },
            });
            $("#treelist").kendoTreeList({
                dataSource: dataSources,
                editable: "popup",
                height: 540,
                resizable: true,
                edit: function (e) {
                    $(e.container).parent().css({
                        width: '500px',
                    });
                },
                expand: function (e) {

                },
                columns: [
                    {
                        field: "DOI_TUONG_TT",
                        expandable: true,
                        width: 350,
                        title: "ĐỐI TƯỢNG THANH TRA, KIỂM TRA",
                        editor: function (container, options) {
                            var input = $("<input/>");
                            input.attr("name", options.field);
                            input.appendTo(container);
                            input.attr("style", 'width:100%');
                            input.kendoMaskedTextBox({
                                mask: ""
                            });
                        }
                    },
                    {
                        field: "PHONG_TT",
                        title: "PHÒNG TRỤ TRÌ",
                        editor: function (container, options) {
                            var input = $("<input/>");
                            input.attr("name", options.field);
                            input.appendTo(container);
                            input.attr("style", 'width:100%');
                            input.attr("disable", 'true');
                            input.kendoMaskedTextBox({
                                mask: ""
                            });
                        }
                    },
                    {
                        field: "TRUONGDOAN_TT",
                        title: "Trưởng đoàn thanh tra",
                        editor: function (container, options) {
                            var input = $("<input/>");
                            input.attr("name", options.field);
                            input.appendTo(container);
                            input.attr("style", 'width:100%');
                            input.kendoAutoComplete({
                                placeholder: "Chọn...",
                                dataTextField: "Text",
                                dataValueField: "Value",
                                dataSource: $scope.lstDmCanBo
                            });
                        }
                    },
                    {
                        field: "THANHVIEN_DOAN",
                        title: "Thành viên đoàn",
                        width: 120,
                        template: "# if(THANHVIEN_DOAN){for (var i=0; i<THANHVIEN_DOAN.length; i++){# #: THANHVIEN_DOAN[i].Text + ',' ## }} #",
                        editor: function (container, options) {
                            var input = $("<input/>");
                            input.attr("name", options.field);
                            input.attr("style", 'width:100%');
                            input.appendTo(container);
                            input.kendoMultiSelect({
                                placeholder: "Chọn...",
                                dataTextField: "Text",
                                dataValueField: "Value",
                                height: 200,
                                dataSource: $scope.lstDmCanBo,
                            });
                        }
                    },
                    {
                        field: "SO_NGAY_THANG_QG",
                        title: "Số ngày tháng QG",
                        template: "#= kendo.toString(SO_NGAY_THANG_QG != null ? SO_NGAY_THANG_QG : '', 'dd/MM/yyyy') #",
                        editor: function (container, options) {
                            var input = $("<input/>");
                            input.attr("style", 'width:100%');
                            input.attr("name", options.field);
                            input.appendTo(container);
                            input.kendoDatePicker();
                        }
                    },
                    {
                        field: "THOIHAN_TT",
                        title: "Thời hạn thanh tra",
                        editor: function (container, options) {
                            var input = $("<input/>");
                            input.attr("name", options.field);
                            input.appendTo(container);
                            input.attr("style", 'width:100%');
                            input.kendoMaskedTextBox({
                                mask: ""
                            });
                        }
                    },
                    {
                        field: "NGAY_TRIENKHAI",
                        title: "Ngày tháng triển khai theo đơn vị",
                        template: "#= kendo.toString(NGAY_TRIENKHAI != null ? NGAY_TRIENKHAI : '', 'dd/MM/yyyy') #",
                        editor: function (container, options) {
                            var input = $("<input/>");
                            input.attr("style", 'width:100%');
                            input.attr("name", options.field);
                            input.appendTo(container);
                            input.kendoDatePicker();
                        }
                    },
                    {
                        field: "NGAY_KETTHUC",
                        title: "Ngày tháng kết thúc theo đơn vị",
                        template: "#= kendo.toString(NGAY_KETTHUC != null ? NGAY_KETTHUC : '', 'dd/MM/yyyy') #",
                        editor: function (container, options) {
                            var input = $("<input/>");
                            input.attr("name", options.field);
                            input.attr("style", 'width:100%');
                            input.appendTo(container);
                            input.kendoDatePicker();
                        }
                    },
                    {
                        field: "GIAMSAT_DOAN",
                        title: "Giám sát đoàn thanh tra",
                        editor: function (container, options) {
                            var input = $("<input/>");
                            input.attr("name", options.field);
                            input.attr("style", 'width:100%');
                            input.appendTo(container);
                            input.kendoAutoComplete({
                                placeholder: "Chọn...",
                                dataTextField: "Text",
                                dataValueField: "Value",
                                dataSource: $scope.lstDmCanBo
                            });
                        }
                    },
                    {
                        command: [
                            {
                                name: "edit",
                                text: "Sửa",
                            },
                        ],
                        width: 100
                    }
                ]
            })
        }

        $scope.ChangYear = function (year) {
            var cuYear = year.toString();
            loadDmDoiTuongThanhTra(cuYear);
        }
        $scope.ChangDoiTuong = function (item) {
            if (item.DOI_TUONG_TT == null) {
                $(".input-add-tv").attr('disabled', 'disabled');
            } else {
                $(".input-add-tv").removeAttr('disabled');
            }
            console.log("itemm", item);
            var DoiTuongTemp = {};
            service.GetDataDetailByMaDoiTuong(item.DOI_TUONG_TT).then(function (successRes) {
                if (successRes && successRes.status == 200 && successRes.data) {
                    console.log("successRes2", successRes);
                    DoiTuongTemp = successRes.data.Data;
                    if (DoiTuongTemp != null) {
                        service.GetObjectByDoiTuong(DoiTuongTemp.MA_PHIEU).then(function (successRes) {
                            if (successRes && successRes.status == 200 && successRes.data) {
                                console.log("successRes3", successRes);
                                var ObjectTemp = successRes.data.Data;
                                item.DOI_TUONG_TT = DoiTuongTemp.DOITUONG_THANHTRA;
                                item.KE_HOACH_TT = DoiTuongTemp.KEHOACH_THANHTRA;
                                item.LOAI_TT = DoiTuongTemp.LOAI_THANHTRA;
                                item.NHOM_TT = DoiTuongTemp.NHOM_THANHTRA;
                                item.PHONG_TT = DoiTuongTemp.PHONG_THANHTRA;
                                item.NGAY_TRIENKHAI = new Date(ObjectTemp.TUNGAY);
                                item.NGAY_KETTHUC = new Date(ObjectTemp.DENNGAY);

                                $scope.ChangeDateTime(item);
                                //$scope.target.DETAILS.push(item);
                            } else {
                                console.log('successRes', successRes);
                            }
                        }, function (errorRes) {
                            console.log('errorRes', errorRes);
                        });
                    } else {
                        item.KE_HOACH_TT = "";
                        item.LOAI_TT = "";
                        item.NHOM_TT = "";
                        item.PHONG_TT = "";
                        item.NGAY_TRIENKHAI = null;
                        item.NGAY_KETTHUC = null;
                        $scope.ChangeDateTime(item);
                    }
                } else {
                    console.log('successRes', successRes);
                }
            }, function (errorRes) {
                console.log('errorRes', errorRes);
            });
        }
        $scope.ChangeDateTime = function (item) {
            var oneDay = 24 * 60 * 60 * 1000;
            var startDate = new Date(item.NGAY_TRIENKHAI);
            var endDate = new Date(item.NGAY_KETTHUC);
            var seconds = Math.round(Math.abs((startDate.getTime() - endDate.getTime()) / (oneDay)));
            item.THOIHAN_TT = seconds;
        }
        function loadDmCanBo() {
            service.getSelectData_CanBo().then(function (successRes) {
                if (successRes && successRes.status == 200 && successRes.data) {
                    $scope.lstDmCanBo = successRes.data;
                } else {
                    console.log('successRes', successRes);
                }
            }, function (errorRes) {
                console.log('errorRes', errorRes);
            });
        }
        loadDmCanBo();
        function loadDmKeHoachThanhTra() {
            service.getSelectData_KeHoachThanhTra().then(function (successRes) {
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
            service.getSelectData_LoaiThanhTra().then(function (successRes) {
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
            service.getSelectData_NhomThanhTra().then(function (successRes) {
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
        function loadDmPhongThanhTra() {
            service.getSelectData_PhongBan().then(function (successRes) {
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
        function loadDmDoiTuongThanhTra(year) {
            service.GetDataDetailByYear(year).then(function (successRes) {
                if (successRes && successRes.status == 200 && successRes.data) {
                    console.log("successRessuccessRes", successRes);
                    $scope.lstDmDoiTuongThanhTra = successRes.data;
                } else {
                    console.log('successRes', successRes);
                }
            }, function (errorRes) {
                console.log('errorRes', errorRes);
            });
        }
        function loadDataDetails() {
            service.GetDetailByRefId($scope.target.MA_PHIEU).then(function (successRes) {
                if (successRes && successRes.status == 200 && successRes.data) {
                    $scope.dataSources = successRes.data.Data.DETAILS
                    convertToDataSource()
                    genKenDo()
                } else {
                    console.log('successRes', successRes);
                }
            }, function (errorRes) {
                console.log('errorRes', errorRes);
            });
        }
        //loadDataDetails();

        function convertToDataSource() {
            var tmpThanhVien = []
            for (var i = 0; i < $scope.dataSources.length; i++) {
                if ($scope.dataSources[i].THANHVIEN_DOAN) {
                    var thanhvien = $scope.dataSources[i].THANHVIEN_DOAN.split(',')
                    thanhvien.splice(-1, 1)
                    for (var j = 0; j < thanhvien.length; j++) {
                        var tmpObject = {}
                        tmpObject.Text = thanhvien[j]
                        tmpThanhVien.push(tmpObject)
                    }
                    $scope.dataSources[i].THANHVIEN_DOAN = tmpThanhVien
                }
            }
        }

        function convertToDetail() {
            $scope.target.DETAILS = [];
            for (var i = 0 ; i < $scope.dataSources.length; i++) {
                var tmp = {};
                tmp.DOI_TUONG_TT = $scope.dataSources[i].DOI_TUONG_TT
                tmp.PHONG_TT = $scope.dataSources[i].PHONG_TT
                tmp.TRUONGDOAN_TT = $scope.dataSources[i].TRUONGDOAN_TT 
                var thanhvien = ''
                if ($scope.dataSources[i].THANHVIEN_DOAN != null) {
                    for (var j = 0; j < $scope.dataSources[i].THANHVIEN_DOAN.length; j++) {
                        thanhvien += $scope.dataSources[i].THANHVIEN_DOAN[j].Text + ','
                    }
                }
                tmp.THANHVIEN_DOAN = thanhvien
                tmp.SO_NGAY_THANG_QG = $scope.dataSources[i].SO_NGAY_THANG_QG
                tmp.THOIHAN_TT = $scope.dataSources[i].THOIHAN_TT
                tmp.NGAY_TRIENKHAI = $scope.dataSources[i].NGAY_TRIENKHAI
                tmp.NGAY_KETTHUC = $scope.dataSources[i].NGAY_KETTHUC
                tmp.GIAMSAT_DOAN = $scope.dataSources[i].GIAMSAT_DOAN
                tmp.MA_DOITUONG = $scope.dataSources[i].MA_DOITUONG
                tmp.MA_DOITUONG_CHA = $scope.dataSources[i].MA_DOITUONG_CHA
                $scope.target.DETAILS.push(tmp)
            }
        }

        $scope.save = function () {
            convertToDetail()
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

    app.controller('TienDoThucHienTTDetailViewCtrl', ['$scope', '$uibModalInstance', '$location', 'TienDoThucHienTTService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData',
	function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData) {
	    $scope.tempData = tempDataService.tempData;
	    $scope.config = tempDataService.config;
	    $scope.target = targetData;
	    $scope.title = function () { return 'Chi tiết trạng thái dự án'; };

	    $scope.cancel = function () {
	        $uibModalInstance.dismiss('cancel');
	    };

	}]);

    app.controller('TienDoThucHienTTDeleteViewCtrl', ['$scope', '$uibModalInstance', '$location', 'TienDoThucHienTTService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify',
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