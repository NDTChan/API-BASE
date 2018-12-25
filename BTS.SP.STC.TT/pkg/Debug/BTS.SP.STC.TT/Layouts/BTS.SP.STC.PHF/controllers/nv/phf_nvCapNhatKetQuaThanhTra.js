define(['controllers/auth/AuController', 'controllers/dm/phf_dmDoiTuong'], function () {
    'use strict';
    var app = angular.module('phf_nvCapNhatKetQuaThanhTra', ['authModule', 'phf_dmDoiTuong']);
    var list = [];
    app.factory('CapNhatKetQuaThanhTraService', ['$http', 'configService', 'Upload', function ($http, configService, Upload) {
        var serviceUrl = configService.rootUrlWebApi + '/nv/capNhatKetQuaThanhTra';
        var result = {
            paging: function (data) {
                return $http.post(serviceUrl + '/Paging', data);
            },
            post: function (data) {
                return $http.post(serviceUrl + '/Post', data);
            },
            getUrlDownloadTemplate: function (report) {
                return $http.get(serviceUrl + '/GetUrlDownloadTemplate/' + report);
            },
            getDataReport: function (fileName, fileNamePk) {
                return $http.get(serviceUrl + '/GetDataReport/' + fileName + '/' + fileNamePk);
            },
            getPeriodTest: function () {
                return $http.get(serviceUrl + '/GetPeriodTest');
            },
            getUnitDepartment: function () {
                return $http.get(serviceUrl + '/GetUnitDepartment');
            },
            uploadFileReport: function (data) {
                return Upload.upload(
                    {
                        url: serviceUrl + '/UploadFileReport',
                        data: {
                            file: data.URL,
                            unitCode: data.UNITCODE,
                            report: data.REPORT,
                            period: data.PERIOD
                        }
                    }
                );
            },
            overwriteReport: function (data) {
                return Upload.upload(
                    {
                        url: serviceUrl + '/OverWriteReport',
                        data: {
                            file: data.URL,
                            unitCode: data.UNITCODE,
                            report: data.REPORT,
                            period: data.PERIOD
                        }
                    }
                );
            }
        }
        return result;
    }]);

    app.controller('CapNhatKetQuaThanhTraViewCtrl', ['$scope', '$location', 'CapNhatKetQuaThanhTraService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster', 'ngNotify', 'blockModalService', 'CacheFactory', 'DmDoiTuongService', '$timeout',
        function ($scope, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster, ngNotify, blockModalService, CacheFactory, dmDoiTuongService, $timeout) {
            $scope.title = function () {
                return 'Cập nhật kết quả thanh tra';
            };
            $scope.config = {
                label: angular.copy(configService.label)
            };
            $scope.paged = angular.copy(configService.pageDefault);
            $scope.filtered = angular.copy(configService.filterDefault);
            $scope.tempData = tempDataService.tempData;
            $scope.accessList = {};
            var dataCache = CacheFactory.get('dataCache');
            $scope.listReport = [
			{
			    id: 1,
			    value: 'rpThanhTraNganSach',
			    text: 'Báo cáo thanh tra ngân sách',
			    description: 'Báo cáo thanh tra ngân sách',
			    parent: null,
			    expanded: true,
			    spriteCssClass: "rootfolder",
			    items: [
					{
					    id: 2,
					    value: 'rp01_TTTC_NSDP',
					    text: 'Biểu số 01/TTTC-NSĐP',
					    description: 'Biểu số 01/TTTC-NSĐP',
					    template: 'TEMPLATE_BM_01TT_NSDP',
					    parent: 1,
					    spriteCssClass: "folder"
					},
					{
					    id: 3,
					    value: 'rp02_TTTC_NSDP',
					    text: 'Biểu số 02/TTTC-NSĐP ',
					    description: 'BẢNG TỔNG HỢP SỐ LIỆU, QUYẾT ĐỊNH GIAO DỰ TOÁN THU NGÂN SÁCH ĐỊA PHƯƠNG',
					    parent: 1,
					    template: 'TEMPLATE_BM_02TT_NSDP',
					    spriteCssClass: "folder"
					},
					{
					    id: 4,
					    value: 'rp03_TTTC_NSDP',
					    text: 'Biểu số 03/TTTC-NSĐP',
					    description: 'BẢNG TỔNG HỢP SỐ LIỆU, QUYẾT ĐỊNH GIAO DỰ TOÁN CHI NGÂN SÁCH ĐỊA PHƯƠNG',
					    parent: 1,
					    template: 'TEMPLATE_BM_03TT_NSDP',
					    spriteCssClass: "folder"
					},
					{
					    id: 5,
					    value: 'rp05_TTTC_NSDP',
					    text: 'Biểu số 05/TTTC-NSĐP',
					    description: 'TỔNG HỢP SAI PHẠM, KHUYẾT ĐIỂM TRONG BỐ TRÍ KẾ HOẠCH VỐN ĐẦU TƯ XÂY DỰNG CHO CÁC DỰ ÁN',
					    template: 'TEMPLATE_BM_05TT_NSDP',
					    parent: 1,
					    spriteCssClass: "folder"
					},
					{
					    id: 6,
					    value: 'rp10_TTTC_NSDP',
					    text: 'Biểu số 10/TTTC-NSĐP',
					    description: 'BẢNG TỔNG HỢP SỐ LIỆU THỰC HIỆN KẾ HOẠCH VỐN ĐẦU TƯ XÂY DỰNG CƠ BẢN',
					    template: 'TEMPLATE_BM_10TT_NSDP',
					    parent: 1,
					    spriteCssClass: "folder"
					},
					{
					    id: 7,
					    value: 'rp11_TTTC_NSDP',
					    text: 'Biểu số 11/TTTC-NSĐP',
					    description: 'TỔNG HỢP NHỮNG TỒN TẠI KHUYẾT ĐIỂM TRONG GIẢI NGÂN THANH TOÁN CÁC DỰ ÁN ĐẦU TƯ XÂY DỰNG CƠ BẢN',
					    parent: 1,
					    template: 'TEMPLATE_BM_11TT_NSDP',
					    spriteCssClass: "folder"
					},
					{
					    id: 8,
					    value: 'rp12_TTTC_NSDP',
					    text: 'Biểu số 12/TTTC-NSĐP',
					    description: 'TỔNG HỢP DỰ ÁN CÓ KHỐI LƯỢNG HOÀN THÀNH NGHIỆM THU CHƯA ĐƯỢC THANH TOÁN',
					    template: 'TEMPLATE_BM_12TT_NSDP',
					    parent: 1,
					    spriteCssClass: "folder"
					},
					{
					    id: 9,
					    value: 'rp14_TTTC_NSDP',
					    text: 'Biểu số 14/TTTC-NSĐP',
					    description: 'TỔNG HỢP CÁC SAI PHẠM, KHUYẾT ĐIỂM QUA THANH TRA CÁC DỰ ÁN ĐẦU TƯ XÂY CƠ BẢN',
					    parent: 1,
					    template: 'TEMPLATE_BM_14TT_NSDP',
					    spriteCssClass: "folder"
					},
					{
					    id: 10,
					    value: 'rp15_TTTC_NSDP',
					    text: 'Biểu số 15/TTTC-NSĐP',
					    description: 'TỔNG HỢP TỒN TẠI, KHUYẾT ĐIỂM TRONG CHI ĐẦU TƯ HỖ TRỢ DOANH NGHIỆP CÁC TỔ CHỨC KINH TẾ TÀI CHÍNH',
					    parent: 1,
					    template: 'TEMPLATE_BM_15TT_NSDP',
					    spriteCssClass: "folder"
					},
					{
					    id: 11,
					    value: 'rp16_TTTC_NSDP',
					    text: 'Biểu số 16/TTTC-NSĐP',
					    description: 'BẢNG TỔNG HỢP SAI PHẠM, KHUYẾT ĐIỂM QUẢN LÝ CHI THƯỜNG XUYÊN',
					    parent: 1,
					    template: 'TEMPLATE_BM_16TT_NSDP',
					    spriteCssClass: "folder"
					}
			    ]
			}
            ];
            dataCache.put('listReport', $scope.listReport);

            $("#dropdowntree").kendoDropDownTree({
                template: kendo.template($("#dropdowntree-template").html()),
                valueTemplate: kendo.template($("#dropdowntree-value-template").html()),
                dataTextField: "text",
                dataSpriteCssClassField: "spriteCssClass",
                dataSource: $scope.listReport,
                filter: "startswith",
                change: function (e) {
                    var choiceValue = this.value();
                    $scope.reportName = choiceValue;
                    if ($scope.listReport && $scope.listReport.length > 0) {
                        var baocao = $filter('filter')($scope.listReport, { value: choiceValue }, true);
                        if (baocao && baocao.length === 1) {
                            if (baocao[0].spriteCssClass == 'rootfolder') {

                            }
                        }
                        else {
                            angular.forEach($scope.listReport, function (v, k) {
                                if (v && v.spriteCssClass == 'rootfolder' && v.items && v.items.length > 0) {
                                    var sub = $filter('filter')(v.items, { value: choiceValue }, true);
                                    if (sub && sub.length == 1) {
                                        $scope.filtered.AdvanceData.MA_FILE = sub[0].template;
                                        $scope.filtered.IsAdvance = true;
                                    }
                                }
                            });
                        }
                    }
                    filterData();
                }
            });

            service.getPeriodTest().then(function (response) {
                if (response && response.status === 200 && response.data && !response.data.Error) {
                    $scope.listKyBaoCao = response.data.Data;
                    $timeout(function () {
                        var tree = $("#dropdowntreeKyBaoCao").kendoDropDownTree({
                            template: kendo.template($("#dropdowntree-template-kyBaoCao").html()),
                            valueTemplate: kendo.template($("#dropdowntree-value-template-kyBaoCao").html()),
                            dataTextField: "text",
                            dataSpriteCssClassField: "spriteCssClass",
                            filter: "startswith",
                            dataSource: response.data.Data,
                            change: function (e) {
                                var choiceValue = this.value();
                                $scope.kyThanhTra = choiceValue;
                                if ($scope.listKyBaoCao && $scope.listKyBaoCao.length > 0) {
                                    var ky = $filter('filter')($scope.listKyBaoCao, { value: choiceValue }, true);
                                    if (ky && ky.length === 1) {
                                        $scope.filtered.AdvanceData.NAM = choiceValue;
                                        $scope.filtered.IsAdvance = true;
                                    }
                                    else {
                                        angular.forEach($scope.listKyBaoCao, function (v, k) {
                                            if (v && v.spriteCssClass == 'rootfolder' && v.items && v.items.length > 0) {
                                                var sub = $filter('filter')(v.items, { value: choiceValue }, true);
                                                if (sub && sub.length == 1) {
                                                    $scope.filtered.AdvanceData.MA_DOT = sub[0].value;
                                                    $scope.filtered.IsAdvance = true;
                                                }
                                            }
                                        });
                                    }
                                }
                                filterData();
                            }
                        });
                    }, 50);
                }
            });

            service.getUnitDepartment().then(function (response) {
                if (response && response.status === 200 && response.data && !response.data.Error) {
                    $scope.listDonVi = response.data.Data;
                    $timeout(function () {
                        var tree = $("#dropdowntreeDonVi").kendoDropDownTree({
                            template: kendo.template($("#dropdowntree-template-donVi").html()),
                            valueTemplate: kendo.template($("#dropdowntree-value-template-donVi").html()),
                            dataTextField: "text",
                            dataSpriteCssClassField: "spriteCssClass",
                            filter: "startswith",
                            dataSource: response.data.Data,
                            change: function (e) {
                                var choiceValue = this.value();
                                if ($scope.listDonVi && $scope.listDonVi.length > 0) {
                                    var donVi = $filter('filter')($scope.listDonVi, { value: choiceValue }, true);
                                    if (donVi && donVi.length === 1) {
                                        $scope.donVi = donVi[0].value;
                                    }
                                    else {
                                        angular.forEach($scope.listDonVi, function (v, k) {
                                            if (v && v.spriteCssClass == 'rootfolder' && v.items && v.items.length > 0) {
                                                var sub = $filter('filter')(v.items, { value: choiceValue }, true);
                                                if (sub && sub.length == 1) {
                                                    $scope.donVi = sub[0].value;
                                                }
                                                else {
                                                    angular.forEach(v.items, function (v, k) {
                                                        if (v && v.items && v.items.length > 0) {
                                                            var sub = $filter('filter')(v.items, { value: choiceValue }, true);
                                                            if (sub && sub.length == 1) {
                                                                $scope.donVi = sub[0].value;
                                                            }
                                                        }
                                                    });
                                                }
                                            }
                                        });
                                    }
                                }
                            }
                        });
                    }, 50);
                }
            });


            $scope.doiTuongDataSource = {
                transport: {
                    read: function (e) {
                        dmDoiTuongService.getSelectData().then(function (response) {
                            if (response && response.status === 200 && response.data) {
                                e.success(response.data);
                                dataCache.put('listDmDoiTuong', response.data);
                            }
                        });
                    },
                    dataType: "json"
                }
            };

            function filterData() {
                if ($scope.accessList.View) {
                    var postdata = {
                        paged: $scope.paged,
                        filtered: $scope.filtered
                    };
                    service.paging(postdata).then(function (successRes) {
                        if (successRes && successRes.status == 200 && successRes.data && !successRes.data.Error && successRes.data.Data && successRes.data.Data.Data.length > 0) {
                            $scope.data = successRes.data.Data.Data;
                        } else {
                            $scope.data = [];
                            $scope.paged.totalItems = 0;
                        }
                    }, function (errorRes) {
                        console.log(errorRes);
                        toaster.pop('error', "Lỗi:", errorRes.statusText);
                    });
                }
            };

            function loadAccessList() {
                securityService.getAccessList('phf_capNhatKetQuaThanhTra').then(function (successRes) {
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
                var data = $filter('filter')($scope.tempData(module), {
                    value: value
                }, true);
                if (data.length == 1) {
                    return data[0].text;
                } else {
                    return value;
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
            $scope.exportExcel = function () {
                if (!$scope.reportName) {
                    ngNotify.set("Chưa chọn báo cáo", {
                        duration: 2000,
                        type: 'error'
                    });
                }
                else {
                    var report = $filter('filter')($scope.listReport[0].items, { value: $scope.reportName }, true);
                    if (report && report.length === 1) {
                        if (report[0].template) {
                            service.getUrlDownloadTemplate(report[0].template).then(function (response) {
                                if (response && response.status == 200 && response.data && response.data.Status && response.data.Data) {
                                    var url = configService.apiServiceBaseUri + response.data.Data
                                    window.open(url);
                                }
                                else {
                                    ngNotify.set(response.data.Message, {
                                        duration: 2000,
                                        type: 'error'
                                    });
                                }
                            });
                        }
                        else {
                            ngNotify.set("Chưa khai báo Template Excel cho báo cáo này", {
                                duration: 2000,
                                type: 'error'
                            });
                        }
                    } else {
                        ngNotify.set("Không tìm thấy thông tin báo cáo", {
                            duration: 2000,
                            type: 'error'
                        });
                    }
                }
            };
            $scope.importExcel = function () {
                if (!$scope.kyThanhTra) {
                    ngNotify.set("Chưa chọn kỳ thanh tra", {
                        duration: 2000,
                        type: 'error'
                    });
                }
                else if (!$scope.reportName) {
                    ngNotify.set("Chưa chọn báo cáo", {
                        duration: 2000,
                        type: 'error'
                    });
                }
                else if (!$scope.donVi) {
                    ngNotify.set("Chưa chọn đơn vị", {
                        duration: 2000,
                        type: 'error'
                    });
                }
                else {
                    var modalInstanceImport = $uibModal.open({
                        backdrop: 'static',
                        size: 'sm',
                        templateUrl: configService.buildUrl('nv/phf_nvCapNhatKetQuaThanhTra', 'importFile'),
                        controller: 'CapNhatKetQuaThanhTraImportFileCtrl',
                        resolve: {
                            kyThanhTra: function () {
                                return $scope.kyThanhTra
                            },
                            reportName: function () {
                                return $scope.reportName
                            },
                            donVi: function () {
                                return $scope.donVi
                            }
                        }
                    });
                    modalInstanceImport.result.then(function (updatedData) {
                        $scope.refresh();
                    }, function () {
                        $log.info('Modal dismissed at: ' + new Date());
                    });
                }
            };
            $scope.create = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    size: 'md',
                    templateUrl: configService.buildUrl('nv/phf_nvCapNhatKetQuaThanhTra', 'add'),
                    controller: 'CapNhatKetQuaThanhTraCreateCtrl',
                    resolve: {}
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.refresh();
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };
            $scope.detail = function (target) {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('nv/phf_nvCapNhatKetQuaThanhTra', 'detail'),
                    controller: 'CapNhatKetQuaThanhTraDetailCtrl',
                    resolve: {
                        targetData: function () {
                            return target;
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    v
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };

            $scope.edit = function (target) {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('nv/phf_nvCapNhatKetQuaThanhTra', 'edit'),
                    controller: 'CapNhatKetQuaThanhTraEditCtrl',
                    windowClass: 'app-modal-window',
                    resolve: {
                        targetData: function () {
                            return target;
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };


        }
    ]);
    app.controller('CapNhatKetQuaThanhTraImportFileCtrl', ['$scope', '$uibModalInstance', '$location', 'CapNhatKetQuaThanhTraService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify', 'kyThanhTra', 'reportName', 'donVi', 'blockModalService', 'userService',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, ngNotify, kyThanhTra, reportName, donVi, blockModalService, userService) {
            $scope.config = angular.copy(configService);
            $scope.tempData = tempDataService.tempData;
            $scope.target = {};
            $scope.isLoading = false;
            $scope.title = function () {
                return 'Nhận file báo cáo';
            };
            $scope.listReport = [];
            $scope.listReport = $scope.tempData('listReport');
            if (!userService.CurrentUser.unitCode && userService.CurrentUser.unitCode == '') {
                ngNotify.set("Mã đơn vị trống", {
                    duration: 2000,
                    type: 'error'
                });
            } else {
                if (reportName) {
                    if ($scope.listReport && $scope.listReport.length > 0) {
                        var baocao = $filter('filter')($scope.listReport, { value: reportName }, true);
                        if (baocao && baocao.length === 1) {
                            if (baocao[0].spriteCssClass == 'rootfolder') {

                            }
                        }
                        else {
                            angular.forEach($scope.listReport, function (v, k) {
                                if (v && v.spriteCssClass == 'rootfolder' && v.items && v.items.length > 0) {
                                    var sub = $filter('filter')(v.items, { value: reportName }, true);
                                    if (sub && sub.length == 1) {
                                        $scope.target.REPORT = sub[0].template;
                                    }
                                }
                            });
                        }
                    }
                }
                $scope.upload = function () {
                    blockModalService.setValue(true);
                    $scope.result = [];
                    $scope.message = {};
                    $scope.target.UNITCODE = donVi;
                    $scope.target.PERIOD = kyThanhTra;
                    service.uploadFileReport($scope.target).then(function (successRes) {
                        if (successRes && successRes.status == 200 && successRes.data && !successRes.data.Error && successRes.data.Message == 'Inserted') {
                            $scope.result = true;
                            $scope.message = "Tải file thành công";
                            ngNotify.set($scope.message, {
                                type: 'success'
                            });
                            $uibModalInstance.close($scope.target);
                        } else if (successRes && successRes.status == 200 && successRes.data && successRes.data.Error && successRes.data.Message == 'Existed') {
                            $scope.result = false;
                            $scope.message = "Phiếu đã tồn tại";
                            //ngNotify.set($scope.message, { duration: 4000, type: 'error' });
                            if (confirm("Bạn có muốn ghi đè phiếu đã tồn tại")) {
                                console.log("Replace");
                                service.overwriteReport($scope.target).then(function (response) {
                                    if (response && response.status == 200 && response.data && !response.data.Error && response.data.Message == 'Overwrited') {
                                        $scope.result = true;
                                        $scope.message = "Ghi đè file thành công";
                                        ngNotify.set($scope.message, {
                                            type: 'success'
                                        });
                                        $uibModalInstance.close($scope.target);
                                    }
                                });
                            }
                        } else if (successRes && successRes.status == 200 && successRes.data && successRes.data.Error && successRes.data.Message == 'UnitCodeIsNull') {
                            $scope.result = false;
                            $scope.message = "Mã đơn vị rỗng";
                            ngNotify.set($scope.message, { duration: 2000, type: 'error' });
                        } else if (successRes && successRes.status == 200 && successRes.data && successRes.data.Error && successRes.data.Message == 'NotTemplate') {
                            $scope.result = false;
                            $scope.message = "Không đúng định dạng Template";
                            ngNotify.set($scope.message, { duration: 2000, type: 'error' });
                        } else if (successRes && successRes.status == 200 && successRes.data && successRes.data.Error && successRes.data.Message == 'NotWorkSheet') {
                            $scope.result = false;
                            $scope.message = "Không tồn tại Worksheet Excel Template";
                            ngNotify.set($scope.message, { duration: 2000, type: 'error' });
                        } else if (successRes && successRes.status == 200 && successRes.data && successRes.data.Error && successRes.data.Message == 'Error') {
                            $scope.result = false;
                            $scope.message = "Xảy ra lỗi khi đọc dữ liệu từ Excel Template";
                            ngNotify.set($scope.message, { duration: 2000, type: 'error' });
                        } else {
                            $scope.result = false;
                            $scope.message = "Xảy ra lỗi";
                            ngNotify.set($scope.message, { duration: 2000, type: 'error' });
                        }
                    }, function (errorRes) {
                        $scope.result = false;
                        ngNotify.set(errorRes.statusText, { duration: 2000, type: 'error' });
                    }, function (evt) {
                        $scope.progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                    });
                    blockModalService.setValue(false);
                };
            }
            $scope.cancel = function () {
                $uibModalInstance.close();
            };
        }
    ]);

    app.controller('CapNhatKetQuaThanhTraCreateCtrl', ['$scope', '$uibModalInstance', '$location', 'CapNhatKetQuaThanhTraService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, ngNotify) {
            $scope.config = angular.copy(configService);
            $scope.tempData = tempDataService.tempData;
            $scope.target = {};
            $scope.isLoading = false;
            $scope.title = function () {
                return 'Thêm mới';
            };
            $scope.save = function () {
                service.post($scope.target).then(function (successRes) {
                    if (successRes && successRes.status === 200 && !successRes.data.Error) {
                        ngNotify.set(successRes.data.Message, {
                            type: 'success'
                        });
                        $uibModalInstance.close($scope.target);
                    } else {
                        console.log('successRes', successRes);
                        ngNotify.set(successRes.data.Message, {
                            duration: 3000,
                            type: 'error'
                        });
                    }
                }, function (errorRes) { });
            };
            $scope.cancel = function () {
                $uibModalInstance.close();
            };
        }
    ]);
    app.controller('CapNhatKetQuaThanhTraDetailCtrl', ['$scope', '$uibModalInstance', 'CapNhatKetQuaThanhTraService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify', 'targetData', 'userService',
        function ($scope, $uibModalInstance, service, configService, $state, tempDataService, $filter, $uibModal, $log, ngNotify, targetData, userService) {
            $scope.config = angular.copy(configService);
            $scope.tempData = tempDataService.tempData;
            $scope.target = angular.copy(targetData);
            $scope.isLoading = false;
            $scope.title = function () {
                return 'Chi tiết file báo cáo';
            };
            if ($scope.target.MA_FILE && $scope.target.MA_FILE_PK) {
                if (userService.CurrentUser.unitCode && userService.CurrentUser.unitCode != '') {
                    $scope.urlFile = configService.apiServiceBaseUri + '/UploadFile/' + userService.CurrentUser.unitCode + '/CapNhatKetQua/' + $scope.target.MA_FILE_PK + '.xlsx';
                    console.log($scope.urlFile);
                }
            }
            $scope.cancel = function () {
                $uibModalInstance.close();
            };
        }
    ]);

    app.controller('CapNhatKetQuaThanhTraEditCtrl', ['$scope', '$uibModalInstance', 'CapNhatKetQuaThanhTraService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify', 'targetData', 'userService',
       function ($scope, $uibModalInstance, service, configService, $state, tempDataService, $filter, $uibModal, $log, ngNotify, targetData, userService) {
           $scope.config = angular.copy(configService);
           $scope.tempData = tempDataService.tempData;
           $scope.target = angular.copy(targetData);
           $scope.isLoading = false;
           $scope.title = function () {
               return 'Cập nhật báo cáo';
           };
           function filterData() {
               if ($scope.target.MA_FILE_PK && $scope.target.MA_FILE_PK != '' && $scope.target.MA_FILE && $scope.target.MA_FILE != '') {
                   service.getDataReport($scope.target.MA_FILE, $scope.target.MA_FILE_PK).then(function (response) {
                       if (response && response.status === 200 && response.data && !response.data.Error && response.data.Data) {
                           $scope.data = response.data.Data;
                       }
                   });
               }
           };
           filterData();

           $scope.cancel = function () {
               $uibModalInstance.close();
           };
       }
    ]);
    return app;
});