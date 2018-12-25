define(['controllers/nv/phf_nvQuyetDinhPheDuyetTT'], function () {
    'use strict';
    var app = angular.module('phf_nvQDGiaoThucHienThanhTra', ['phf_nvQuyetDinhPheDuyetTT']);
    var list = [];
    app.factory('NvQDGiaoThucHienThanhTraService', ['$http', 'configService', 'Upload', function ($http, configService, Upload) {
        var serviceUrl = configService.rootUrlWebApi + '/nv/phf_nvQDGiaoThucHienThanhTra';
        var result = {
            paging: function (data) {
                return $http.post(serviceUrl + '/Paging', data);
            },
            post: function (data) {
                return $http.post(serviceUrl + '/Post', data);
            },
            deleteItem: function (params) {
                return $http.delete(serviceUrl + '/' + params.Id, params);
            },
            update: function (params) {
                return $http.put(serviceUrl + '/' + params.Id, params);
            },
            UploadReportFile: function (data) {
                return Upload.upload(
                    {
                        url: serviceUrl + '/UploadReportFile',
                        data: {
                            file: data.URL
                        }
                    }
                );
            },
            downloadWord: function (data) {
                return $http.post(serviceUrl + '/DownloadWord', data);
            },
            FilterWordOnWeb: function (data) {
                return $http.post(serviceUrl + '/FilterWordOnWeb', data);
            },
            getAllQuyetDinh: function () {
                return $http.get(serviceUrl + '/GetAllQuyetDinh');
            },
        }
        return result;
    }]);

    app.controller('NvQDGiaoThucHienThanhTraCtrl', ['$scope', '$location', 'NvQDGiaoThucHienThanhTraService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster', 'ngNotify', 'blockModalService', 'QuyetDinhPheDuyetTTService',
        function ($scope, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster, ngNotify, blockModalService, QuyetDinhPheDuyetTTService) {
            $scope.config = {
                label: angular.copy(configService.label)
            }
            $scope.title = function () {
                return 'Cập nhật quyết định giao kế hoạch thanh tra';
            };

            $scope.lstNam = [{ value: 2016, text: "Năm 2016" }, { value: 2017, text: "Năm 2017" }, { value: 2018, text: "Năm 2018" }, { value: 2019, text: "Năm 2019" }, ]
            $scope.lstDotThanhTra = [{ value: "Đợt tháng 8" }, { value: "Đợt tháng 9" }, { value: "Đợt tháng 10" }, { value: "Đợt tháng 11" }, ]

            $("#dropdownNam").kendoDropDownList({
                dataTextField: "text",
                dataValueField: "value",
                dataSource: $scope.lstNam,
                change: function (e) {
                    $scope.nam = this.value();
                }
            });

            $("#dropdownDotThanhTra").kendoDropDownList({
                dataTextField: "value",
                dataValueField: "value",
                dataSource: $scope.lstDotThanhTra,
                change: function (e) {
                    $scope.dotThanhTra = this.value();
                }
            });

            var dataSource = new kendo.data.DataSource({
                transport: {
                    read: function (e) {
                        service.getAllQuyetDinh().then(function (response) {
                            console.log('response:', response);
                            if (response && response.status === 200 && response.data && response.data.Data) {
                                e.success(response.data.Data);
                            }
                        });
                    },
                    update: function (e) {
                        e.success(e.data);
                        service.update(e.data).then(function (successRes) {
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
                    },
                    create: function (e) {
                        e.data.NAM_THANHTRA = $scope.nam
                        service.post(e.data).then(function (successRes) {
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
                        e.success(e.data);
                    },
                    destroy: function (e) {
                        console.log(e)
                        e.success(e.data);
                    },
                },
                pageSize: 4,
                schema: {
                    model: {
                        id: "SO_QUYETDINH",
                        fields: {
                            SO_QUYETDINH: { editable: true, nullable: false },
                            NGAY_QUYETDINH: { editable: true, nullable: false },
                            QD_GIAOTHUCHIEN_THANHTRA: { editable: true, nullable: false },
                        }
                    }
                }
            });


            $("#pager").kendoPager({
                dataSource: dataSource
            });

            var listView = $("#listView").kendoListView({
                dataSource: dataSource,
                selectable: "multiple",
                template: kendo.template($("#template").html()),
                editTemplate: kendo.template($("#editTemplate").html()),
            }).data("kendoListView");
            listView.bind("change", function (e) {
                var index = e.sender.select().index();
                var item = e.sender.dataSource.view()[index];
                service.FilterWordOnWeb(item).then(function (successRes) {
                    console.log('item in in getTestHtml', item);
                    console.log('successRes in getTestHtml', successRes);
                    $scope.content = successRes.data.Message;
                }, function (errorRes) {
                    console.log('errorRes in getTestHtml', errorRes);
                });

            });

            $(".k-add-button").click(function (e) {
                listView.add();
                e.preventDefault();
            });

            $("#listView").on('click', '.k-print-button', function (e) {
                var li = $(e.currentTarget).parent(),
                dataItem = listView.dataItem(li);
                console.log(dataItem);
                service.downloadWord(dataItem).then(function (response) {
                    console.log(response);
                    if (response && response.status === 200 && response.data !== 'NotFound') {
                        $scope.linkDownload = configService.apiServiceBaseUri + response.data;
                        window.open($scope.linkDownload);
                    }
                    else {
                        ngNotify.set("Xảy ra lỗi", { duration: 3000, type: 'error' });
                    }
                });
            })

            $("#listView").on('click', '.k-upload-button', function (e) {
                var li = $(e.currentTarget).parent(),
                dataItem = listView.dataItem(li);
                console.log(dataItem);
            })


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
                securityService.getAccessList('phf_nvQDGiaoThucHienThanhTra').then(function (successRes) {
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

            $scope.displayHepler2 = function (module, Value) {

                var data = $filter('filter')($scope.lstNvQDGiaoThucHienThanhTra, { Value: Value }, true);
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

            $scope.print = function (target) {
                service.downloadWord(target).then(function (response) {
                    console.log(response);
                    if (response && response.status === 200 && response.data !== 'NotFound') {
                        $scope.linkDownload = configService.apiServiceBaseUri + response.data;
                        window.open($scope.linkDownload);
                    }
                    else {
                        ngNotify.set("Xảy ra lỗi", { duration: 3000, type: 'error' });
                    }
                });
            };

            $scope.delete = function (target) {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('nv/phf_nvQDGiaoThucHienThanhTra', 'delete'),
                    controller: 'NvQDGiaoThucHienThanhTraDeleteCtrl',
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

    app.controller('NvQDGiaoThucHienThanhTraCreateCtrl', ['$scope', '$uibModalInstance', '$location', 'NvQDGiaoThucHienThanhTraService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify', 'blockModalService', 'QuyetDinhPheDuyetTTService',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, ngNotify, blockModalService, QuyetDinhPheDuyetTTService) {
            $scope.config = angular.copy(configService);
            $scope.tempData = tempDataService.tempData;
            $scope.target = {};
            $scope.isLoading = false;
            $scope.target.TRANG_THAI = "1";
            $scope.target.NGAY_QUYETDINH = new Date();
            $scope.title = function () { return 'Thêm mới Quyết định giao thực hiện'; };

            function getDataQuyetDinh() {
                QuyetDinhPheDuyetTTService.getAllQuyetDinh().then(function (successRes) {
                    if (successRes.status == 200) {
                        $scope.lstQuyetDinh = successRes.data.Data;
                        console.log('$scope.lstQuyetDinh', $scope.lstQuyetDinh)
                        $scope.target.QD_GIAOTHUCHIEN_THANHTRA = $scope.lstQuyetDinh[0].SO_QUYETDINH
                        $("#dropdownQuyetDinh").kendoDropDownList({
                            placeholder: "--Chọn Số quyết định--",
                            height: 500,
                            filter: "contains",
                            dataSource: $scope.lstQuyetDinh,
                            dataTextField: "SO_QUYETDINH",
                            dataValueField: "SO_QUYETDINH",
                            change: function (e) {
                                console.log(this.value())
                                $scope.target.QD_GIAOTHUCHIEN_THANHTRA = this.value();
                            }
                        });
                    }
                }, function (err) {
                    console.log("Oro", err);
                });
            }
            getDataQuyetDinh()

            $scope.upload = function () {
                blockModalService.setValue(true);
                $scope.resultUploadBanCung = [];
                service.UploadReportFile($scope.target).then(function (successRes) {
                    console.log('successRes in UploadReportFile', successRes);
                    $scope.resultUploadBanCung = successRes.data;

                    blockModalService.setValue(false);
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                    blockModalService.setValue(false);
                    ngNotify.set(errorRes.statusText, { duration: 5000, type: 'error' });
                    $scope.resultUploadBanCung = false;
                }, function (evt) {
                    $scope.progressPercentageBanCung = parseInt(100.0 * evt.loaded / evt.total);
                });
                console.log($scope.target);
            };

            $scope.save = function () {
                console.log("target in save", $scope.target)
                service.post($scope.target).then(function (successRes) {
                    console.log("successRes in save", successRes)
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

    app.controller('NvQDGiaoThucHienThanhTraEditCtrl', ['$scope', '$uibModalInstance', '$location', 'NvQDGiaoThucHienThanhTraService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify', 'blockModalService','QuyetDinhPheDuyetTTService',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify, blockModalService, QuyetDinhPheDuyetTTService) {
            $scope.target = targetData;
            $scope.config = angular.copy(configService);
            $scope.targetData = angular.copy(targetData);
            $scope.tempData = tempDataService.tempData;
            console.log(" $scope.target", $scope.target);
            $scope.target.NGAY_QUYETDINH = new Date($filter('date')(targetData.NGAY_QUYETDINH, 'yyyy-MM-dd'))
            $scope.isLoading = false;
            $scope.lstNvQDGiaoThucHienThanhTra = list;
            console.log(" $scope.selectCanBo in EDIT", $scope.selectCanBo)
            $scope.title = function () { return 'Cập nhật cán bộ'; };


            function getDataQuyetDinh() {
                QuyetDinhPheDuyetTTService.getAllQuyetDinh().then(function (successRes) {
                    if (successRes.status == 200) {
                        $scope.lstQuyetDinh = successRes.data.Data;
                        console.log('$scope.lstQuyetDinh', $scope.lstQuyetDinh)
                        $scope.target.QD_GIAOTHUCHIEN_THANHTRA = $scope.lstQuyetDinh[0].SO_QUYETDINH
                        $("#dropdownQuyetDinh").kendoDropDownList({
                            placeholder: "--Chọn Số quyết định--",
                            height: 500,
                            filter: "contains",
                            dataSource: $scope.lstQuyetDinh,
                            dataTextField: "SO_QUYETDINH",
                            dataValueField: "SO_QUYETDINH",
                            change: function (e) {
                                console.log(this.value())
                                $scope.target.QD_GIAOTHUCHIEN_THANHTRA = this.value();
                            }
                        });
                    }
                }, function (err) {
                    console.log("Oro", err);
                });
            }
            getDataQuyetDinh()

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


    app.controller('NvQDGiaoThucHienThanhTraDeleteCtrl', ['$scope', '$uibModalInstance', '$location', 'NvQDGiaoThucHienThanhTraService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify',
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