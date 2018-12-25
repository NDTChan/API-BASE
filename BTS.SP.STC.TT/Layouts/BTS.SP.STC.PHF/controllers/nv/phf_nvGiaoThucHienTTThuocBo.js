define([], function () {
    'use strict';
    var app = angular.module('phf_nvGiaoThucHienTTThuocBo', ["kendo.directives"]);

    app.factory('GiaoThucHienTTThuocBoService', ['$http', 'configService', function ($http, configService) {
        var serviceUrl = configService.rootUrlWebApi + '/nv/phf_nvGiaoThucHienTTThuocBo';
        var result = {
            paging: function (data) {
                return $http.post(serviceUrl + '/Paging', data);
            },
            GetUrlDownloadTemplate: function (report) {
                return $http.get(serviceUrl + '/GetUrlDownloadTemplate/' + report);
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
            },
            getAllDonVi: function () {
                return $http.get(serviceUrl + '/GetAllDonVi');
            },
            FilterWordOnWeb: function (data) {
                return $http.post(serviceUrl + '/FilterWordOnWeb', data);
            },
            defaultFilterWordOnWeb: function () {
                return $http.get(serviceUrl + '/defaultFilterWordOnWeb');
            },
        }
        return result;
    }]);

    app.controller('NvGiaoThucHienTTThuocBoCtrl', ['$scope', '$sce', '$location', 'GiaoThucHienTTThuocBoService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster', 'ngNotify',
    function ($scope, $sce, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster, ngNotify) {
        $scope.config = {
            label: angular.copy(configService.label)
        }
        $scope.title = function () {
            return 'Giao thực hiện kế hoạch thanh tra';
        };
        var NAM_THANHTRA = '';
        var DOT_THANHTRA = '';
        var MA_DONVI = '';
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

        var lstNam = [{ value: 2016, text: "Năm 2016" }, { value: 2017, text: "Năm 2017" }, { value: 2018, text: "Năm 2018" }, { value: 2019, text: "Năm 2019" }, ]
        NAM_THANHTRA = lstNam[0].value
        var lstDotThanhTra = [{ value: "Đợt tháng 8" }, { value: "Đợt tháng 9" }, { value: "Đợt tháng 10" }, { value: "Đợt tháng 11" }, ]
        DOT_THANHTRA = lstDotThanhTra[0].value

        $("#dropdownNam").kendoDropDownList({
            dataTextField: "value",
            dataValueField: "value",
            dataSource: lstNam,
            change: function (e) {
                NAM_THANHTRA = this.value();
            }
        });

        $("#dropdownDotThanhTra").kendoDropDownList({
            dataTextField: "value",
            dataValueField: "value",
            dataSource: lstDotThanhTra,
            change: function (e) {
                DOT_THANHTRA = this.value();
            }
        });

        function loadDonVi() {
            service.getAllDonVi().then(function (response) {
                if (response && response.status === 200 && response.data && response.data.Data) {
                    console.log(response.data.Data);
                    MA_DONVI = response.data.Data[0].MA
                    $("#dropdownDonVi").kendoDropDownList({
                        dataTextField: "TEN",
                        dataValueField: "MA",
                        dataSource: response.data.Data,
                        change: function (e) {
                            MA_DONVI = this.value();
                        }
                    });
                }
            });
        }
        loadDonVi();

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
                    e.success(e.data);
                    console.log(e.data);
                    e.data.MA_DONVI = MA_DONVI
                    e.data.DOT_THANHTRA = DOT_THANHTRA
                    e.data.NAM_THANHTRA = NAM_THANHTRA
                    service.post(e.data).then(function (successRes) {
                        if (successRes && successRes.status === 200 && !successRes.data.Error) {
                            ngNotify.set(successRes.data.Message, { type: 'success' });
                        } else {
                            console.log('successRes', successRes);
                            ngNotify.set(successRes.data.Message, { duration: 3000, type: 'error' });
                        }
                    },

                    function (errorRes) {
                        console.log('errorRes', errorRes);
                    });
                },
                destroy: function (e) {
                    console.log(e)
                    e.success(e.data);
                    service.deleteItem(e.data).then(function (successRes) {
                        console.log(successRes)
                        if (successRes && successRes.status == 200 && !successRes.data.Error) {
                            ngNotify.set(successRes.data.Message, { type: 'success' });

                        } else {
                            console.log('successRes', successRes);
                            ngNotify.set(successRes.data.Message, { duration: 3000, type: 'error' });
                        }
                    },
					function (errorRes) {
					    console.log('errorRes', errorRes);
					});

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
            console.log('item in Click', item)
            service.FilterWordOnWeb(item).then(function (successRes) {
                $scope.content = successRes.data.Message;
                console.log('successRes', successRes)
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


    return app;
});

