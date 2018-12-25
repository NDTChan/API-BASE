define(['controllers/auth/AuController'], function () {
    'use strict';
    var app = angular.module('phf_nvBaoCaoNSDVN', ['authModule']);
    var list = [];
    app.factory('BaoCaoNSDVNService', ['$http', 'configService', 'Upload', function ($http, configService, Upload) {
        var serviceUrl = configService.rootUrlWebApi + '/nv/phf_nvBaoCaoNSDVN';
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

    app.controller('BaoCaoNSDVNViewCtrl', ['$scope', '$location', 'BaoCaoNSDVNService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster', 'ngNotify', 'blockModalService', 'CacheFactory',
        function ($scope, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster, ngNotify, blockModalService, CacheFactory) {
            $scope.title = function () {
                return 'Báo cáo ngân sách đơn vị nộp';
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
			    value: 'rpNSDVN',
			    text: 'Báo cáo ngân sách đơn bị nộp',
			    description: 'Báo cáo ngân sách đơn bị nộp',
			    parent: null,
			    expanded: true,
			    spriteCssClass: "rootfolder",
			    items: [
					{
					    id: 2,
					    value: 'rp60_TTTC_NSDVN',
					    text: 'Biểu số 60/TT-342',
					    description: 'Biểu số 60/TT-342',
					    template: 'TEMPLATE_BM_60TT_NSDVN',
					    parent: 1,
					    spriteCssClass: "folder"
					},
					{
					    id: 3,
					    value: 'rp61_TTTC_NSDVN',
					    text: 'Biểu số 61/TT-342 ',
					    description: 'Biểu số 61/TT-342',
					    parent: 1,
					    template: 'TEMPLATE_BM_61TT_NSDVN',
					    spriteCssClass: "folder"
					},
					{
					    id: 4,
					    value: 'rp62_TTTC_NSDVN',
					    text: 'Biểu số 62/TT-342 ',
					    description: 'Biểu số 62/TT-342 ',
					    parent: 1,
					    template: 'TEMPLATE_BM_62TT_NSDVN',
					    spriteCssClass: "folder"
					},
					{
					    id: 5,
					    value: 'rp63_TTTC_NSDVN',
					    text: 'Biểu số 63/TT-342 ',
					    description: 'Biểu số 63/TT-342 ',
					    parent: 1,
					    template: 'TEMPLATE_BM_63TT_NSDVN',
					    spriteCssClass: "folder"
					},
					{
					    id: 6,
					    value: 'rp64_TTTC_NSDVN',
					    text: 'Biểu số 64/TT-342 ',
					    description: 'Biểu số 64/TT-342 ',
					    parent: 1,
					    template: 'TEMPLATE_BM_64TT_NSDVN',
					    spriteCssClass: "folder"
					},
					{
					    id: 7,
					    value: 'rp65_TTTC_NSDVN',
					    text: 'Biểu số 65/TT-342 ',
					    description: 'Biểu số 65/TT-342 ',
					    parent: 1,
					    template: 'TEMPLATE_BM_65TT_NSDVN',
					    spriteCssClass: "folder"
					}

			    ]
			}
            ];
            dataCache.put('listReport', $scope.listReport);


            $scope.listDonVi = [
			{
			    id: '01',
			    value: 'TTr',
			    text: 'Thanh tra tổng',
			    description: 'Thanh tra tổng',
			    parent: null,
			    expanded: true,
			    madvqhns: '01',
			    spriteCssClass: "rootfolder",
			    items: [
					{
					    id: '02',
					    value: 'TTr1',
					    text: 'Thanh tra Bộ',
					    description: 'Thanh tra Bộ',
					    parent: '01',
					    madvqhns: '02',
					    spriteCssClass: "folder"
					},
					{
					    id: '03',
					    value: 'TTr1-PTH',
					    text: 'Phòng Tổng hợp',
					    description: 'Phòng Tổng hợp',
					    parent: '01',
					    madvqhns: '03',
					    spriteCssClass: "folder",
					    expanded: true,
					    items: [
                           {
                               id: '04',
                               value: 'TTr1-PB1',
                               text: 'Phòng thanh tra số 1',
                               description: 'Phòng thanh tra số 1',
                               parent: '03',
                               madvqhns: '04',
                               spriteCssClass: "folder"
                           },
                           {
                               id: '05',
                               value: 'TTr1-PB2',
                               text: 'Phòng thanh tra 2',
                               description: 'Phòng thanh tra 2',
                               parent: '03',
                               madvqhns: '05',
                               spriteCssClass: "folder"
                           },
                           {
                               id: '06',
                               value: 'TTr1-PB3',
                               text: 'Phòng thanh tra 3',
                               description: 'Phòng thanh tra số 3',
                               parent: '03',
                               madvqhns: '06',
                               spriteCssClass: "folder"
                           }
					    ]
					}
			    ]
			}
            ];

            dataCache.put('listDonVi', $scope.listDonVi);
            var tree = $("#dropdowntreeDonVi").kendoDropDownTree({
                template: kendo.template($("#dropdowntree-template-donVi").html()),
                valueTemplate: kendo.template($("#dropdowntree-value-template-donVi").html()),
                dataTextField: "text",
                dataSpriteCssClassField: "spriteCssClass",
                filter: "startswith",
                placeholder: "Chọn đơn vị thanh tra",
                dataSource: $scope.listDonVi,
                change: function (e) {
                    var choiceValue = this.value();
                    if ($scope.listDonVi && $scope.listDonVi.length > 0) {
                        var donVi = $filter('filter')($scope.listDonVi, { value: choiceValue }, true);
                        if (donVi && donVi.length === 1) {
                            $scope.donVi = donVi[0].madvqhns;
                        }
                        else {
                            angular.forEach($scope.listDonVi, function (v, k) {
                                if (v && v.spriteCssClass == 'rootfolder' && v.items && v.items.length > 0) {
                                    var sub = $filter('filter')(v.items, { value: choiceValue }, true);
                                    if (sub && sub.length == 1) {
                                        $scope.donVi = sub[0].madvqhns;
                                    }
                                }
                            });
                        }
                    }
                }
            });

            $scope.listDoiTuong = [
              {
                  value: 2018, text: "Năm 2018", expanded: true, spriteCssClass: "rootfolder", items: [
                      { value: 'DTT0101', text: "Công tác quản lý tài chính tại Bộ Thông Tin và truyền thông", spriteCssClass: "folder" },
                      { value: 'DTT0102', text: "Công tác quản lý tài chính tại Bộ Tư pháp", spriteCssClass: "folder" }
                  ]
              },
              {
                  value: 2017, text: "Năm 2017", expanded: true, spriteCssClass: "rootfolder", items: [
                       { value: 'DTT0103', text: "Công tác quản lý tài chính tại Dự án Hỗ trợ xử lý rác thải bệnh viện thuộc lĩnh vực quản lý của Bộ Y tế", spriteCssClass: "folder" },
                      { value: 'DTT0104', text: "Công tác quản lý tài chính tại Bộ Công thương", spriteCssClass: "folder" }
                  ]
              }
            ];

            //function loadDmDoiTuong() {
            //    dmDoiTuongService.getSelectData().then(function (successRes) {
            //        $scope.listDmDoiTuong = successRes.data;
            //        console.log($scope.listDmDoiTuong);
            //        if (!tempDataService.tempData('listDmDoiTuong')) {
            //            tempDataService.putTempData('listDmDoiTuong', successRes.data);
            //        }
            //    }, function (errorRes) {
            //        toaster.pop('error', "Lỗi:", errorRes.statusText);
            //    });
            //}
            //loadDmDoiTuong();

            dataCache.put('listDoiTuong', $scope.listDoiTuong);
            var tree = $("#dropdowntreeDoiTuong").kendoDropDownTree({
                template: kendo.template($("#dropdowntree-template-doituong").html()),
                valueTemplate: kendo.template($("#dropdowntree-value-template-doituong").html()),
                dataTextField: "text",
                dataSpriteCssClassField: "spriteCssClass",
                filter: "startswith",
                placeholder: "Chọn đối tượng thanh tra",
                dataSource: $scope.listDoiTuong,
                change: function (e) {
                    var choiceValue = this.value();
                    if ($scope.listDoiTuong && $scope.listDoiTuong.length > 0) {
                        var doituong = $filter('filter')($scope.listDoiTuong, { value: choiceValue }, true);
                        if (doituong && doituong.length === 1) {
                            $scope.doituong = doituong[0].madvqhns;
                        }
                        else {
                            angular.forEach($scope.listDoiTuong, function (v, k) {
                                if (v && v.spriteCssClass == 'rootfolder' && v.items && v.items.length > 0) {
                                    var sub = $filter('filter')(v.items, { value: choiceValue }, true);
                                    if (sub && sub.length == 1) {
                                        $scope.doituong = sub[0].madvqhns;
                                    }
                                }
                            });
                        }
                    }
                }
            });

            $("#dropdowntree").kendoDropDownTree({
                template: kendo.template($("#dropdowntree-template").html()),
                valueTemplate: kendo.template($("#dropdowntree-value-template").html()),
                dataTextField: "text",
                dataSpriteCssClassField: "spriteCssClass",
                dataSource: $scope.listReport,
                filter: "startswith",
                placeholder: "Chọn biểu mẫu",
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

            $scope.listKyBaoCao = [
				{
				    value: 2018, text: "Năm 2018", expanded: true, spriteCssClass: "rootfolder", items: [
						{ value: 'DTT0101', text: "Đợt thanh tra tháng 9", spriteCssClass: "folder" },
						{ value: 'DTT0102', text: "Đợt thanh tra tháng 10", spriteCssClass: "folder" }
				    ]
				},
				{
				    value: 2017, text: "Năm 2017", expanded: true, spriteCssClass: "rootfolder", items: [
						 { value: 'DTT0103', text: "Đợt thanh tra tháng 9", spriteCssClass: "folder" },
						{ value: 'DTT0104', text: "Đợt thanh tra tháng 10", spriteCssClass: "folder" }
				    ]
				}
            ];
            var tree = $("#dropdowntreeKyBaoCao").kendoDropDownTree({
                template: kendo.template($("#dropdowntree-template-kyBaoCao").html()),
                valueTemplate: kendo.template($("#dropdowntree-value-template-kyBaoCao").html()),
                dataTextField: "text",
                dataSpriteCssClassField: "spriteCssClass",
                filter: "startswith",
                placeholder: "Chọn đợt thanh tra",
                dataSource: $scope.listKyBaoCao,
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
                        templateUrl: configService.buildUrl('nv/phf_nvBaoCaoNSDVN', 'importFile'),
                        controller: 'BaoCaoNSDVNImportFileCtrl',
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
                    templateUrl: configService.buildUrl('nv/phf_nvBaoCaoNSDVN', 'add'),
                    controller: 'BaoCaoNSDVNCreateCtrl',
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
                    templateUrl: configService.buildUrl('nv/phf_nvBaoCaoNSDVN', 'detail'),
                    controller: 'BaoCaoNSDVNDetailCtrl',
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

            $scope.edit = function (target) {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('nv/phf_nvBaoCaoNSDVN', 'edit'),
                    controller: 'BaoCaoNSDVNEditCtrl',
                    windowClass: 'app-modal-window',
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


        }
    ]);
    app.controller('BaoCaoNSDVNImportFileCtrl', ['$scope', '$uibModalInstance', '$location', 'BaoCaoNSDVNService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify', 'kyThanhTra', 'reportName', 'donVi', 'blockModalService', 'userService',
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

    app.controller('BaoCaoNSDVNCreateCtrl', ['$scope', '$uibModalInstance', '$location', 'BaoCaoNSDVNService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify',
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

    app.controller('BaoCaoNSDVNDetailCtrl', ['$scope', '$uibModalInstance', 'BaoCaoNSDVNService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify', 'targetData', 'userService',
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

    app.controller('BaoCaoNSDVNEditCtrl', ['$scope', '$uibModalInstance', 'BaoCaoNSDVNService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify', 'targetData', 'userService',
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