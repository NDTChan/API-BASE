define([], function () {
    'use strict';
    var app = angular.module('phf_dmDotThanhTra', []);
    var listDotThanhTra = [];
    app.factory('DmDotThanhTraService', ['$http', 'configService', function ($http, configService) {
        var serviceUrl = configService.rootUrlWebApi + '/dm/phf_dmDotThanhTra';
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
            CheckCodeExist: function (Id) {
                return $http.get(serviceUrl + '/CheckCodeExist/' + Id);
            }
        }
        return result;
    }]);

    app.controller('DmDotThanhTraCtrl', ['$scope', '$stateParams', '$location', 'DmDotThanhTraService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster', 'ngNotify',
        function ($scope, $stateParams, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster, ngNotify) {

            $scope.title = function () {
                return 'Cập nhật Đợt thanh tra';
            };

            $scope.paged = angular.copy(configService.pageDefault);
            $scope.filtered = angular.copy(configService.filterDefault);
            $scope.tempData = tempDataService.tempData;
            $scope.config = angular.copy(configService);

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
                        toaster.pop('error', "Lỗi:", errorRes.statusText);
                    });
                }
            };

            function loadAccessList() {
                securityService.getAccessList('phf_dmDotThanhTra').then(function (successRes) {
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

            $scope.create = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    size: 'md',
                    templateUrl: configService.buildUrl('dm/phf_dmDotThanhTra', 'add'),
                    controller: 'DmDotThanhTraCreateCtrl',
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
                    templateUrl: configService.buildUrl('dm/phf_dmDotThanhTra', 'edit'),
                    controller: 'DmDotThanhTraEditCtrl',
                    resolve: {
                        targetData: function () {
                            return target;
                        }
                    }
                });
                console.log(target);
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
                    templateUrl: configService.buildUrl('dm/phf_dmDotThanhTra', 'detail'),
                    controller: 'DmDotThanhTraDetailCtrl',
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
                    templateUrl: configService.buildUrl('dm/phf_dmDotThanhTra', 'delete'),
                    controller: 'DmDotThanhTraDeleteCtrl',
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

            var dataSource = new kendo.data.DataSource({
                transport: {
                    read: function (e) {
                        var postdata = { paged: $scope.paged, filtered: $scope.filtered };
                        service.paging(postdata).then(function (successRes) {
                            console.log(successRes)
                            if (successRes && successRes.status == 200 && successRes.data && !successRes.data.Error) {
                                $scope.data = successRes.data.Data.Data;
                                $scope.paged.totalItems = successRes.data.Data.totalItems;
                                e.success(successRes.data.Data.Data);
                            } else {
                                $scope.data = [];
                                $scope.paged.totalItems = 0;
                                toaster.pop('error', "Lỗi:", successRes.data.Message);
                            }
                        }, function (errorRes) {
                            toaster.pop('error', "Lỗi:", errorRes.statusText);
                        });
                    },
                    update: function (e) {
                        if (!e.data.TU_NGAY) {
                            ngNotify.set(" Từ ngày không được để trống! ", { type: 'error' });
                        } else if (!e.data.DEN_NGAY) {
                            ngNotify.set(" Đến ngày không được để trống! ", { type: 'error' });
                        } else if (e.data.TU_NGAY > e.data.DEN_NGAY) {
                            ngNotify.set(" Từ ngày không được lớn hơn đến ngày! ", { type: 'error' });
                        } else {
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
                        }
                        e.success(e.data);
                    },
                    create: function (e) {
                        if (!e.data.TU_NGAY) {
                            ngNotify.set("Từ ngày không được để trống!", { type: 'error' });
                        } else if (!e.data.DEN_NGAY) {
                            ngNotify.set("Đến ngày không được để trống!", { type: 'error' });
                        } else if (e.data.TU_NGAY > e.data.DEN_NGAY) {
                            ngNotify.set("Từ ngày không được lớn hơn đến ngày!", { type: 'error' });
                        } else {
                            service.post(e.data).then(function (successRes) {
                                if (successRes && successRes.status === 200 && !successRes.data.Error) {
                                    ngNotify.set(successRes.data.Message, { type: 'success' });
                                    $uibModalInstance.close($scope.target);
                                } else {
                                    console.log('successRes', successRes);
                                    ngNotify.set(successRes.data.Message, { duration: 3000, type: 'error' });
                                }
                            }, function (errorRes) { });
                        }
                        e.success(e.data);
                    },
                    destroy: function (e) {
                        service.deleteItem(e.data).then(function (successRes) {
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
                        e.success(e.data);
                    },
                },
                pageSize: 4,
                schema: {
                    model: {
                        id: "MA_DOT",
                        fields: {
                            MA_DOT: { editable: true, nullable: false },
                            TEN_DOT: { editable: true, nullable: false },
                            TU_NGAY: { editable: true, nullable: false },
                            DEN_NGAY: { editable: true, nullable: false }
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

            $("#listView").on('click', '.k-track-changes-enable-button', function (e) {
                var li = $(e.currentTarget).parent(),
                dataItem = listView.dataItem(li);
                console.log(dataItem);
                var url = $state.href('phf_nvNhatKy', { MA_DOT: dataItem.MA_DOT });
                window.open(url, '_blank');
            })

            $("#listView").on('click', '.k-link-horizontal-button', function (e) {
                var li = $(e.currentTarget).parent(),
                dataItem = listView.dataItem(li);
                console.log(dataItem);
                var url = $state.href('phf_phanCongKeHoach', { MA_DOT: dataItem.MA_DOT });
                window.open(url, '_blank');
            })

            $("#listView").on('click', '.k-filter-add-expression-button', function (e) {
                var li = $(e.currentTarget).parent(),
                dataItem = listView.dataItem(li);
                console.log(dataItem);
                var url = $state.href('phf_nvKhThanhTraThuocBo', { MA_DOT: dataItem.MA_DOT });
                window.open(url, '_blank');
            })

            function SaveFile(name, type, data) {
                var ieEDGE = navigator.userAgent.match(/Edge/g);
                var ie = navigator.userAgent.match(/.NET/g); // IE 11+
                var oldIE = navigator.userAgent.match(/MSIE/g);
                if (ie || oldIE || ieEDGE) {
                    var blob = new window.Blob([data], { type: type });
                    window.navigator.msSaveBlob(blob, name);
                }
                else {
                    var a = $("<a style='display: none;'/>");
                    var url = window.URL.createObjectURL(new Blob([data], { type: type }));
                    a.attr("href", url);
                    a.attr("download", name);
                    $("body").append(a);
                    a[0].click();
                    window.URL.revokeObjectURL(url);
                    a.remove();
                }
            }

            $scope.export = function () {
                $scope.isLoading = true;
                service.Export().then(function (successRes) {
                    if (successRes && successRes.status === 200 && successRes.data) {
                        $scope.isLoading = false;
                        var date = new Date();
                        var tmp = date.getDate() + '-' + (date.getMonth() + 1) + '-' + date.getFullYear();
                        SaveFile('Export_DM_DotThanhTra_(' + tmp + ').xls', 'application/vnd.ms-excel', successRes.data);
                        ngNotify.set('Xuất file thành công !', { duration: 3000, type: 'success' });
                    }
                }, function (errorRes) {
                    ngNotify.set('Lỗi: ' + errorRes, { duration: 3000, type: 'error' });
                });
            }

            $scope.nhatKyThanhTra = function () {
                var url = $state.href('phf_nvNhatKy', { MA_DOT: item.MA_DOT });
                window.open(url, '_blank');
            }
        }]);

    app.controller('DmDotThanhTraEditCtrl', ['$scope', '$uibModalInstance', '$location', 'DmDotThanhTraService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify) {
            $scope.target = targetData;
            $scope.config = angular.copy(configService);
            $scope.targetData = angular.copy(targetData);
            $scope.tempData = tempDataService.tempData;
            $scope.target.TU_NGAY = new Date($scope.target.TU_NGAY);
            $scope.target.DEN_NGAY = new Date($scope.target.DEN_NGAY);
            $scope.isLoading = false;

            $scope.title = function () { return 'Cập nhật đợt thanh tra'; };

            $scope.save = function () {
                if (!$scope.target.TU_NGAY) {
                    ngNotify.set(" Từ ngày không được để trống! ", { type: 'error' });
                } else if (!$scope.target.DEN_NGAY) {
                    ngNotify.set(" Đến ngày không được để trống! ", { type: 'error' });
                } else if ($scope.target.TU_NGAY > $scope.target.DEN_NGAY) {
                    ngNotify.set(" Từ ngày không được lớn hơn đến ngày! ", { type: 'error' });
                } else {
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
                }
            };
            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
            };
            $scope.nhatKyThanhTra = function (hRefState) {
                var url = $state.href(hRefState, { MA_DOT: $scope.target.MA_DOT });
                window.open(url, '_blank');
            }

        }]);

    app.controller('DmDotThanhTraDetailCtrl', ['$scope', '$uibModalInstance', '$location', 'DmDotThanhTraService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData',
	function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData) {
	    $scope.tempData = tempDataService.tempData;
	    $scope.config = tempDataService.config;
	    $scope.target = targetData;
	    $scope.config = angular.copy(configService);
	    $scope.target.TU_NGAY = new Date($scope.target.TU_NGAY);
	    $scope.target.DEN_NGAY = new Date($scope.target.DEN_NGAY);
	    $scope.title = function () { return 'Chi tiết đợt thanh tra'; };

	    $scope.cancel = function () {
	        $uibModalInstance.dismiss('cancel');
	    };

	    $scope.nhatKyThanhTra = function (hRefState) {
	        
	    }

	}]);

    app.controller('DmDotThanhTraDeleteCtrl', ['$scope', '$uibModalInstance', '$location', 'DmDotThanhTraService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify) {
            $scope.target = targetData;
            $scope.config = angular.copy(configService);
            $scope.targetData = angular.copy(targetData);
            $scope.isLoading = false;

            $scope.title = function () { return 'Xóa đợt thanh tra'; };

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


