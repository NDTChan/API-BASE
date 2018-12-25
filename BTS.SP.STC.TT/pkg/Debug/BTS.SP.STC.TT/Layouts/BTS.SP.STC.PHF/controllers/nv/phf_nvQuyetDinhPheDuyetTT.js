define([], function () {
    'use strict';
    var app = angular.module('phf_nvQuyetDinhPheDuyetTT', ["kendo.directives"]);

    app.factory('QuyetDinhPheDuyetTTService', ['$http', 'configService', function ($http, configService) {
        var serviceUrl = configService.rootUrlWebApi + '/nv/phf_nvQuyetDinhPheDuyetTT';
        var serviceUrl_DotThanhTra = configService.rootUrlWebApi + '/dm/phf_dmDotThanhTra';
        var serviceUrl_PhanCongKeHoach = configService.rootUrlWebApi + '/nv/phf_phanCongKeHoach';
        var result = {
            paging: function (data) {
                return $http.post(serviceUrl + '/Paging', data);
            },
            GetUrlDownloadTemplate: function (report) {
                return $http.get(serviceUrl + '/GetUrlDownloadTemplate/' + report);
            },
            FilterWordOnWeb: function (data) {
                return $http.post(serviceUrl + '/FilterWordOnWeb', data);
            },
            defaultFilterWordOnWeb: function () {
                return $http.get(serviceUrl + '/defaultFilterWordOnWeb');
            },
            post: function (data) {
                return $http.post(serviceUrl + '/Post', data);
            },
            update: function (params) {
                return $http.put(serviceUrl + '/' + params.Id, params);
            },
            deleteItem: function (params) {
                return $http.delete(serviceUrl + '/' + params.Id, params);
            },
            downloadWord: function (data) {
                return $http.post(serviceUrl + '/DownloadWord', data);
            },
            GetDetailByRefId: function (refid) {
                return $http.get(serviceUrl_PhanCongKeHoach + '/GetDetailByRefId/' + refid);
            },
            getSelectData_DotThanhTra: function () {
                return $http.get(serviceUrl_DotThanhTra + '/GetSelectData');
            },
            GetYearData: function () {
                return $http.get(serviceUrl_PhanCongKeHoach + '/GetYearData');
            },
            UploadFile: function (data) {
                return Upload.upload(
                    {
                        url: serviceUrl + '/UploadFile',
                        data: {
                            file: data.DINH_KEM
                        }
                    }
                );
            },

            getAllQuyetDinh: function () {
                return $http.get(serviceUrl + '/GetAllQuyetDinh');
            }
        }
        return result;
    }]);

    app.controller('QuyetDinhPheDuyetTTViewCtrl', ['$scope', '$sce', '$location', 'QuyetDinhPheDuyetTTService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster', 'ngNotify',
    function ($scope, $sce, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster, ngNotify) {
        $scope.config = {
            label: angular.copy(configService.label)
        }
        $scope.title = function () {
            return 'Cập nhật quyết định phê duyệt thanh tra';
        };
        $scope.lstDmDotThanhTra = [];
        $scope.lstDmNamThanhTra = [];
        $scope.select_dotTT = {};
        $scope.select_namTT = {};

        $scope.options = {
            language: 'vi',
            allowedContent: true,
            entities: false,
            width: '100%',
            height: 800,
            toolbar: [
				{ name: 'clipboard', items: ['PasteFromWord', '-', 'Undo', 'Redo'] },
				{ name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'RemoveFormat', 'Subscript', 'Superscript'] },
				{ name: 'links', items: ['Link', 'Unlink'] },
				{ name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote'] },
				{ name: 'insert', items: ['Image', 'Table'] },
				{ name: 'editing', items: ['Scayt'] },
				'/',

				{ name: 'styles', items: ['Format', 'Font', 'FontSize'] },
				{ name: 'colors', items: ['TextColor', 'BGColor', 'CopyFormatting'] },
				{ name: 'align', items: ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'] },
				{ name: 'document', items: ['Print', 'Source'] }
            ],
        };
        function uniq(a) {
            var seen = {};
            return a.filter(function (item) {
                return seen.hasOwnProperty(item) ? false : (seen[item] = true);
            });
        }
        function loadDmDotThanhTra() {
            service.getSelectData_DotThanhTra().then(function (successRes) {
                if (successRes && successRes.status == 200 && successRes.data) {
                    $scope.lstDmDotThanhTra = successRes.data;
                    console.log(' $scope.lstDmDotThanhTra', successRes.data)
                    $scope.select_dotTT = successRes.data[0].Value;
                    $("#dropdownDotThanhTra").kendoDropDownList({
                        dataTextField: "Text",
                        dataValueField: "Value",
                        dataSource: $scope.lstDmDotThanhTra,
                        change: function (e) {
                            $scope.select_dotTT = this.value();
                            console.log('$scope.select_dotTT', $scope.select_dotTT);
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
        function uniq(a) {
            return a.sort().filter(function (item, pos, ary) {
                return !pos || item != ary[pos - 1];
            })
        }
        function loadNamThanhTra() {
            service.GetYearData().then(function (successRes) {
                if (successRes && successRes.status == 200 && successRes.data) {
                    $scope.lstDmNamThanhTra = successRes.data;
                    console.log('successRes.data', successRes.data)
                    var arrayNam = [];
                    $scope.lstDmNamThanhTra.forEach(element => {
                        arrayNam.push(element.NAM);
                    });
                    var arrayNam_object = [];
                    uniq(arrayNam).forEach(element => {
                        arrayNam_object.push({ value: element, text: element })
                    });
                    $scope.select_namTT = successRes.data[0].NAM;
                    $("#dropdownNam").kendoDropDownList({
                        dataTextField: "text",
                        dataValueField: "value",
                        value: arrayNam[0],
                        dataSource: arrayNam_object,

                        change: function (e) {
                            $scope.select_namTT = this.value();
                            console.log('$scope.select_namTT', $scope.select_namTT);
                        }
                    });
                } else {
                    console.log('successRes', successRes);
                }
            }, function (errorRes) {
                console.log('errorRes', errorRes);
            });
        }
        loadNamThanhTra();

        function defaultFilterWordOnWeb() {
            service.defaultFilterWordOnWeb().then(function (successRes) {
                $scope.content = successRes.data.Message;
                console.log('$scope.content in defaultFilterWordOnWeb', successRes)
            }, function (errorRes) {
                console.log('errorRes in defaultFilterWordOnWeb', errorRes);
            });
        }
        defaultFilterWordOnWeb();

        var dataSource = new kendo.data.DataSource({
            transport: {
                read: function (e) {
                    service.getAllQuyetDinh().then(function (response) {
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
                    $scope.delete = function () {
                        var modalInstance = $uibModal.open({
                            backdrop: 'static',
                            templateUrl: configService.buildUrl('nv/phf_nvQuyetDinhPheDuyetTT', 'delete'),
                            controller: 'QuyetDinhPheDuyetTTDeleteCtrl',
                            resolve: {
                                targetData: function () {
                                    return e.data;
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
                },
            },
            pageSize: 4,
            schema: {
                model: {
                    id: "SO_QUYETDINH",
                    fields: {
                        SO_QUYETDINH: { editable: true, nullable: false },
                        NGAY_QUYETDINH: { editable: true, nullable: false },
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
            item.NAM_THANHTRA_PHULUC = $scope.select_namTT;
            item.DOT_THANHTRA = $scope.select_dotTT;
            console.log('item in Click', item)
            service.FilterWordOnWeb(item).then(function (successRes) {
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


        $scope.goHome = function () {
            $state.go('home');
        };

    }]);

    app.controller('QuyetDinhPheDuyetTTDeleteCtrl', ['$scope', '$uibModalInstance', '$location', 'NvNhatKyService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify',
            function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify) {
                $scope.target = targetData;
                $scope.config = angular.copy(configService);
                $scope.targetData = angular.copy(targetData);
                $scope.isLoading = false;

                $scope.title = function () { return 'Xóa quyết định'; };

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
    return app
});

