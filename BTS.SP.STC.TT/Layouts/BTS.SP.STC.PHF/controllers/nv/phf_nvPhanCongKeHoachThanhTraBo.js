define(['controllers/sys/sysTuDienCtrl'], function () {
    'use strict';
    var app = angular.module('phf_nvPhanCongKeHoachThanhTraBo', ['sysTuDien']);
    app.factory('PhanCongKeHoachService', ['$http', 'configService', function ($http, configService) {
        var serviceUrl = configService.rootUrlWebApi + '/nv/phf_phanCongKeHoach';
        var serviceUrl_DoiTuong = configService.rootUrlWebApi + '/dm/phf_dmDoiTuong';
        var serviceUrl_PhongBan = configService.rootUrlWebApi + '/dm/phf_dmDonViPhongBan';
        var serviceUrl_DotThanhTra = configService.rootUrlWebApi + '/dm/phf_dmDotThanhTra';
        var serviceUrl_KeHoachThanhTra = configService.rootUrlWebApi + '/dm/phf_dmKeHoachThanhTra';
        var serviceUrl_LoaiThanhTra = configService.rootUrlWebApi + '/dm/dmLoaiThanhTra';
        var serviceUrl_NhomThanhTra = configService.rootUrlWebApi + '/dm/phf_dmNhomThanhTra';

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
            GetYearData: function () {
                return $http.get(serviceUrl + '/GetYearData');
            },
            GetDetailByRefId: function (refid) {
                return $http.get(serviceUrl + '/GetDetailByRefId/' + refid);
            },
            getSelectData_DoiTuong: function () {
                return $http.get(serviceUrl_DoiTuong + '/GetSelectData');
            },
            getSelectData_PhongBan: function () {
                return $http.get(serviceUrl_PhongBan + '/getSelectDataDonVi');
            },
            getSelectData_DotThanhTra: function () {
                return $http.get(serviceUrl_DotThanhTra + '/GetSelectData');
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
            Export: function (data) {
                return $http.post(serviceUrl + '/Export', data, { responseType: 'arraybuffer' });
            }
        }
        return result;
    }]);

    app.controller('PhanCongKeHoachViewCtrl', ['$scope', '$stateParams', '$location', 'PhanCongKeHoachService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'securityService', 'toaster', 'ngNotify',
        function ($scope, $stateParams, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, securityService, toaster, ngNotify) {
            $scope.config = {
                label: angular.copy(configService.label)
            }
            $scope.paged = angular.copy(configService.pageDefault);
            $scope.filtered = angular.copy(configService.filterDefault);
            $scope.tempData = tempDataService.tempData;
            $scope.accessList = {};
            $scope.target = {};
            $scope.target.NAM = new Date().getFullYear();
            $scope.lstDmDoiTuongThanhTra = [];
            $scope.lstDmDotThanhTra = [];
            $scope.lstDmPhongThanhTra = [];
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
                securityService.getAccessList('phf_phanCongKeHoach').then(function (successRes) {
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
                        }
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            loadDmDotThanhTra();

            $scope.formatLabel = function (code, listData) {
                if (!code) return "";
                var data = $filter('filter')(listData, { Value: code }, true);
                if (data && data.length > 0) {
                    return data[0].Text;
                }
            };

            $scope.displayHepler = function (module, value) {
                var data = $filter('filter')($scope.tempData(module), { Value: value }, true);
                if (data.length == 1) {
                    return data[0].Text;
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
                    size: 'md',
                    templateUrl: configService.buildUrl('nv/phf_nvPhanCongKeHoachThanhTraBo', 'add'),
                    controller: 'PhanCongKeHoachCreateViewCtrl',
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
                    templateUrl: configService.buildUrl('nv/phf_nvPhanCongKeHoachThanhTraBo', 'edit'),
                    controller: 'PhanCongKeHoachEditViewCtrl',
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
                    templateUrl: configService.buildUrl('nv/phf_nvPhanCongKeHoachThanhTraBo', 'detail'),
                    controller: 'PhanCongKeHoachDetailViewCtrl',
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
                    templateUrl: configService.buildUrl('nv/phf_nvPhanCongKeHoachThanhTraBo', 'delete'),
                    controller: 'PhanCongKeHoachDeleteViewCtrl',
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

            $scope.linkTienDo = function (item) {
                console.log('$scope.target', $scope.target);
                var url = $state.href('phf_nvTienDoThucHienTT', { MA_DOT: item.DOT_THANHTRA });
                console.log('url', url);
                window.open(url, '_blank');
            }

        }]);

    app.controller('PhanCongKeHoachCreateViewCtrl', ['$scope', '$uibModalInstance', '$location', 'PhanCongKeHoachService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, ngNotify) {
            $scope.config = angular.copy(configService);
            $scope.tempData = tempDataService.tempData;
            $scope.lstDmDotThanhTra = [];
            $scope.lstDmKeHoachThanhTra = [];
            $scope.lstDmLoaiThanhTra = [];
            $scope.lstDmNhomThanhTra = [];
            $scope.lstDmPhongThanhTra = [];
            $scope.lstDmDoiTuongThanhTra = [];
            $scope.target = {};
            $scope.target.DETAILS = [];
            $scope.target.NGAY_LAPPHIEU = new Date();
            $scope.isLoading = false;
            $scope.listPhongBan = [];
            $scope.title = function () { return 'Thêm mới phân công kế hoạch thanh tra, kiểm tra'; };
            $scope.formatLabel = function (model, module) {
                console.log('module', module);
                if (!model) return "";
                var data = $filter('filter')(module, { Value: model }, true);
                if (data && data.length == 1) {
                    return data[0].Value + ' - ' + data[0].Text;
                }
                return "";
            };
            $scope.dataSource = [
                {
                    "Value": 0,
                    "Text": " PHÂN CÔNG KẾ HOẠCH THANH TRA, KIỂM TRA TÀI CHÍNH NĂM 2018",
                    "Parent": null,
                    "Phong": null
                },
                {
                    "Value": 1,
                    "Text": "A. KẾ HOẠCH THANH TRA",
                    "Parent": "0",
                    "Phong": null
                },
                {
                    "Value": 2,
                    "Text": "THANH TRA NGÂN SÁCH ĐỊA PHƯƠNG",
                    "Parent": "1",
                    "Phong": null
                },
                {
                    "Value": 3,
                    "Text": "Kế hoạch chính thức",
                    "Parent": "2",
                    "Phong": null
                },
                {
                    "Value": 4,
                    "Text": "Kế hoạch dự phòng",
                    "Parent": "2",
                    "Phong": null
                },
                {
                    "Value": 5,
                    "Text": "THANH TRA TÀI CHÍNH BỘ, NGÀNH",
                    "Parent": "1",
                    "Phong": null
                },
                {
                    "Value": 6,
                    "Text": "Kế hoạch chính thức",
                    "Parent": "5",
                    "Phong": null
                },
                {
                    "Value": 7,
                    "Text": "Kế hoạch dự phòng",
                    "Parent": "5",
                    "Phong": null
                },
                {
                    "Value": 8,
                    "Text": "THANH TRA TÀI CHÍNH DOANH NGHIỆP VÀ GIÁ",
                    "Parent": "1",
                    "Phong": null
                },
                {
                    "Value": 9,
                    "Text": "Kế hoạch chính thức",
                    "Parent": "8",
                    "Phong": null
                },
                {
                    "Value": 10,
                    "Text": "Kế hoạch dự phòng",
                    "Parent": "8",
                    "Phong": null
                },
                {
                    "Value": 11,
                    "Text": "THANH TRA VỐN ĐẦU TƯ XÂY DỰNG",
                    "Parent": "1",
                    "Phong": null
                },
                {
                    "Value": 12,
                    "Text": "Kế hoạch chính thức",
                    "Parent": "11",
                    "Phong": null
                },
                {
                    "Value": 13,
                    "Text": "Kế hoạch dự phòng",
                    "Parent": "11",
                    "Phong": null
                },
                {
                    "Value": 14,
                    "Text": "THANH TRA HÀNH CHÍNH",
                    "Parent": "1",
                    "Phong": null
                },
                {
                    "Value": 15,
                    "Text": "Kế hoạch chính thức",
                    "Parent": "14",
                    "Phong": null
                },
                {
                    "Value": 16,
                    "Text": "Kế hoạch dự phòng",
                    "Parent": "14",
                    "Phong": null
                },
                {
                    "Value": 17,
                    "Text": "B. KẾ HOẠCH KIỂM TRA",
                    "Parent": "0",
                    "Phong": null
                },
                {
                    "Value": 18,
                    "Text": "Kế hoạch chính thức",
                    "Parent": "17",
                    "Phong": null
                },
                {
                    "Value": 19,
                    "Text": "Kế hoạch dự phòng",
                    "Parent": "17",
                    "Phong": null
                },
            ]

            function genKenDo() {
                var dataSources = new kendo.data.TreeListDataSource({
                    data: $scope.dataSource,
                    schema: {
                        model: {
                            id: "Value",
                            parentId: "Parent",
                            fields: {
                                Value: { field: "Value", nullable: true },
                                Parent: { field: "Parent", type: "number" },
                            },
                            expanded: true
                        }
                    },
                    transport: {
                        read: function (e) {
                            e.success($scope.dataSource)
                        },
                        update: function (e) {
                            $scope.dataSource.forEach(function (element) {
                                if (element.Value == e.data.Value) {
                                    element.Phong = e.data.Value.Phong
                                }
                            })
                            console.log('$scope.dataSource', $scope.dataSource)
                            e.success(e.data)
                        },
                        destroy: function (e) {
                            for (var i = $scope.dataSource.length - 1; i >= 0; i--) {
                                if ($scope.dataSource[i].Value === e.data.Value) {
                                    $scope.dataSource.splice(i, 1);
                                }
                            }
                            e.success(e.data)
                        },
                        parameterMap: function (options, operation) {
                            if (operation !== "read" && options.models) {
                                return { models: kendo.stringify(options.models) };
                            }
                        }
                    },
                });
                $("#treelist").kendoTreeList({
                    dataSource: dataSources,
                    editable: true,
                    height: 540,
                    expand: function (e) {

                    },
                    columns: [
                        { field: "Text", expandable: true, title: "ĐỐI TƯỢNG THANH TRA, KIỂM TRA", width: 220 },
                        {
                            field: "Phong",
                            title: "PHÒNG TRỤ TRÌ",
                            width: 100,
                            editor: function (container, options) {
                                // create an input element
                                var input = $("<input/>");
                                // set its name to the field to which the column is bound ('lastName' in this case)
                                input.attr("name", options.field);
                                // append it to the container
                                input.appendTo(container);
                                // initialize a Kendo UI AutoComplete
                                input.kendoAutoComplete({
                                    dataTextField: "Text",
                                    dataValueField: "Value",
                                    dataSource: $scope.lstDmPhongThanhTra
                                });
                            }
                        },
                        {
                            command: [
                              {
                                  name: "popUpCreate",
                                  text: "Thêm",
                                  click: function (e) {
                                      var tr = $(e.target).closest("tr"); // get the current table row (tr)
                                      addChild(e, this.dataItem(tr))
                                  }
                              }, {
                                  name: "edit",
                                  text: "Sửa",
                              }, {
                                  name: "destroy",
                                  text: "Xóa",
                              },
                            ],
                            width: 300
                        }
                    ]
                })
                var treeList = $("#treelist").data("kendoTreeList");
            }

            function addChild(e, dataItem) {
                // get the data bound to the current table row
                var data = dataItem;
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    size: 'md',
                    templateUrl: configService.buildUrl('sys/sysTuDien', 'selectMultiData'),
                    controller: 'sysTuDienSelectData_ctrl',
                    resolve: {

                    }
                });
                modalInstance.result.then(function (updatedData) {
                    for (var i = 0 ; i < updatedData.length; i++) {
                        var d = new Date();
                        var n = d.getTime();
                        var obj = {}
                        obj.Value = n + i;
                        obj.Text = updatedData[i].Text
                        obj.Parent = data.Value.toString()
                        obj.Phong = null
                        $scope.dataSource.push(obj)
                    }
                    $scope.target.DETAILS.push($scope.dataSource);
                    var treelist = $("#treelist").data("kendoTreeList");
                    var dataSourceTemp = new kendo.data.TreeListDataSource({
                        data: $scope.dataSource,
                        schema: {
                            model: {
                                id: "Value",
                                parentId: "Parent",
                                fields: {
                                    Value: { field: "Value", nullable: true },
                                    Parent: { field: "Parent", type: "number" },
                                },
                                expanded: true
                            }
                        }
                    });
                    treelist.setDataSource(dataSourceTemp);
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }

            function loadDmDotThanhTra() {
                service.getSelectData_DotThanhTra().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.lstDmDotThanhTra = successRes.data;
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
            function loadDmDoiTuongThanhTra() {
                service.getSelectData_DoiTuong().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.lstDmDoiTuongThanhTra = successRes.data;
                        genKenDo();
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }
            loadDmDoiTuongThanhTra();

            $scope.removeItem = function (index) {
                var currentPageIndex = 0;
                var currentPage = $scope.paged.currentPage;
                var itemsPerPage = $scope.paged.itemsPerPage;
                currentPageIndex = (currentPage - 1) * itemsPerPage + index;
                $scope.target.DETAILS.splice(currentPageIndex, 1);
                $scope.pageChanged();
            }
            $scope.pageChanged = function () {
                var currentPage = $scope.paged.currentPage;
                $scope.itemsPerPage = 5;
                $scope.paged.totalItems = $scope.target.DETAILS.length;
                $scope.data = [];
                if ($scope.target.DETAILS) {
                    for (var i = (currentPage - 1) * $scope.itemsPerPage; i < currentPage * $scope.itemsPerPage && i < $scope.target.DETAILS.length; i++) {
                        $scope.data.push($scope.target.DETAILS[i]);
                    }
                }
            }

            $scope.add = function () {
                $scope.dataSource.forEach(function (element) {
                    var obj = {}
                    obj.MA_DOITUONG = element.Value
                    obj.MA_DOITUONG_CHA = element.Parent
                    obj.TEN_DOITUONG = element.Text
                    obj.PHONG_CHUTRI = element.Phong
                    $scope.target.DETAILS.push(obj);
                })
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
                $uibModalInstance.close();
            };
        }]);

    app.controller('PhanCongKeHoachEditViewCtrl', ['$scope', '$uibModalInstance', '$location', 'PhanCongKeHoachService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify', '$timeout',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify, $timeout) {
            $timeout(function () {
                $scope.target = targetData;
                $scope.targetData = angular.copy(targetData);
                $scope.target.NGAY_LAPPHIEU = new Date($scope.target.NGAY_LAPPHIEU);
                $scope.target.TUNGAY = new Date($scope.target.TUNGAY);
                $scope.target.DENNGAY = new Date($scope.target.DENNGAY);
                loadDataDetails();
            }, 250);
            $scope.config = angular.copy(configService);
            $scope.isLoading = false;
            $scope.lstDmDotThanhTra = [];
            $scope.lstDmKeHoachThanhTra = [];
            $scope.lstDmLoaiThanhTra = [];
            $scope.lstDmNhomThanhTra = [];
            $scope.lstDmPhongThanhTra = [];
            $scope.lstDmDoiTuongThanhTra = [];
            $scope.dataSource = [];
            $scope.formatLabel = function (model, module) {
                console.log('module', module);
                if (!model) return "";
                var data = $filter('filter')(module, { Value: model }, true);
                if (data && data.length == 1) {
                    return data[0].Value + ' - ' + data[0].Text;
                }
                return "";
            };

            $scope.title = function () { return 'Cập nhật phân công kế hoạch thanh tra, kiểm tra'; };

            function loadDmDotThanhTra() {
                service.getSelectData_DotThanhTra().then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.lstDmDotThanhTra = successRes.data;
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

            function genKenDo() {
                var dataSources = new kendo.data.TreeListDataSource({
                    data: $scope.dataSource,
                    schema: {
                        model: {
                            id: "Value",
                            parentId: "Parent",
                            fields: {
                                Value: { field: "Value", nullable: true },
                                Parent: { field: "Parent", type: "number" },
                            },
                            expanded: true
                        }
                    },
                    transport: {
                        read: function (e) {
                            e.success($scope.dataSource)
                        },
                        update: function (e) {
                            $scope.dataSource.forEach(function (element) {
                                if (element.Value == e.data.Value) {
                                    element.Phong = e.data.Value.Phong
                                }
                            })
                            console.log('$scope.dataSource', $scope.dataSource)
                            e.success(e.data)
                        },
                        destroy: function (e) {
                            for (var i = $scope.dataSource.length - 1; i >= 0; i--) {
                                if ($scope.dataSource[i].Value === e.data.Value) {
                                    $scope.dataSource.splice(i, 1);
                                }
                            }
                            e.success(e.data)
                        },
                        parameterMap: function (options, operation) {
                            if (operation !== "read" && options.models) {
                                return { models: kendo.stringify(options.models) };
                            }
                        }
                    },
                });
                $("#treelist").kendoTreeList({
                    dataSource: dataSources,
                    editable: true,
                    height: 540,
                    expand: function (e) {
                        console.log("expand");
                    },
                    columns: [
                        {
                            field: "Text",
                            expandable: true,
                            title: "ĐỐI TƯỢNG THANH TRA, KIỂM TRA",
                            width: 220
                        },
                        {
                            field: "Phong",
                            title: "PHÒNG TRỤ TRÌ",
                            width: 100,
                            editor: function (container, options) {
                                // create an input element
                                var input = $("<input/>");
                                // set its name to the field to which the column is bound ('lastName' in this case)
                                input.attr("name", options.field);
                                // append it to the container
                                input.appendTo(container);
                                // initialize a Kendo UI AutoComplete
                                input.kendoAutoComplete({
                                    dataTextField: "Text",
                                    dataValueField: "Value",
                                    dataSource: $scope.lstDmPhongThanhTra
                                });
                            }
                        },
                        {
                            command: [
                              {
                                  name: "popUpCreate",
                                  text: "Thêm",
                                  click: function (e) {
                                      var tr = $(e.target).closest("tr"); // get the current table row (tr)
                                      addChild(e, this.dataItem(tr))
                                  }
                              }, {
                                  name: "edit",
                                  text: "Sửa",
                              }, {
                                  name: "destroy",
                                  text: "Xóa",
                              },
                            ],
                            width: 300
                        }
                    ]
                });
                var treeList = $("#treelist").data("kendoTreeList");
            }

            function addChild(e, dataItem) {
                // get the data bound to the current table row
                var data = dataItem;
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    size: 'md',
                    templateUrl: configService.buildUrl('sys/sysTuDien', 'selectMultiData'),
                    controller: 'sysTuDienSelectData_ctrl',
                    resolve: {

                    }
                });
                modalInstance.result.then(function (updatedData) {
                    for (var i = 0 ; i < updatedData.length; i++) {
                        var d = new Date();
                        var n = d.getTime();
                        var obj = {}
                        obj.Value = n + i;
                        obj.Text = updatedData[i].Text
                        obj.Parent = data.Value.toString()
                        obj.Phong = null
                        $scope.dataSource.push(obj)
                    }
                    $scope.target.DETAILS.push($scope.dataSource);
                    var treelist = $("#treelist").data("kendoTreeList");
                    var dataSourceTemp = new kendo.data.TreeListDataSource({
                        data: $scope.dataSource,
                        schema: {
                            model: {
                                id: "Value",
                                parentId: "Parent",
                                fields: {
                                    Value: { field: "Value", nullable: true },
                                    Parent: { field: "Parent", type: "number" },
                                },
                                expanded: true
                            }
                        }
                    });

                    treelist.setDataSource(dataSourceTemp);
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }

            function convertArray(array) {
                array.forEach(function (element) {
                    var obj = {}
                    obj.Value = element.MA_DOITUONG
                    obj.Text = element.TEN_DOITUONG
                    obj.Parent = element.MA_DOITUONG_CHA
                    obj.Phong = element.PHONG_CHUTRI
                    $scope.dataSource.push(obj)
                })
            }

            function loadDataDetails() {
                service.GetDetailByRefId($scope.target.MA_PHIEU).then(function (successRes) {
                    if (successRes && successRes.status == 200 && successRes.data) {
                        $scope.target.DOT_THANHTRA = targetData.DOT_THANHTRA;
                        $scope.target.DETAILS = successRes.data.Data.DETAILS;
                        convertArray($scope.target.DETAILS)
                        genKenDo()
                    } else {
                        console.log('successRes', successRes);
                    }
                }, function (errorRes) {
                    console.log('errorRes', errorRes);
                });
            }

            $scope.save = function () {
                $scope.target.DETAILS.splice(0, $scope.target.DETAILS.length)
                $scope.dataSource.forEach(function (element) {
                    var obj = {}
                    obj.MA_DOITUONG = element.Value
                    obj.MA_DOITUONG_CHA = element.Parent
                    obj.TEN_DOITUONG = element.Text
                    obj.PHONG_CHUTRI = element.Phong
                    $scope.target.DETAILS.push(obj);
                })
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

            $scope.sendDirect = function () {
                console.log('$scope.target', $scope.target);
                var url = $state.href('phf_nvTienDoThucHienTT', { MA_DOT: $scope.target.DOT_THANHTRA });
                console.log('url', url);
                window.open(url, '_blank');
            }

            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
            };

        }]);

    app.controller('PhanCongKeHoachDetailViewCtrl', ['$scope', '$uibModalInstance', '$location', 'PhanCongKeHoachService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData',
	function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData) {
	    $scope.tempData = tempDataService.tempData;
	    $scope.config = tempDataService.config;
	    $scope.target = targetData;
	    $scope.title = function () { return 'Chi tiết trạng thái dự án'; };

	    $scope.cancel = function () {
	        $uibModalInstance.dismiss('cancel');
	    };

	}]);
    app.controller('PhanCongKeHoachDeleteViewCtrl', ['$scope', '$uibModalInstance', '$location', 'PhanCongKeHoachService', 'configService', '$state', 'tempDataService', '$filter', '$uibModal', '$log', 'targetData', 'ngNotify',
        function ($scope, $uibModalInstance, $location, service, configService, $state, tempDataService, $filter, $uibModal, $log, targetData, ngNotify) {
            $scope.target = targetData;
            $scope.config = angular.copy(configService);
            $scope.targetData = angular.copy(targetData);
            $scope.isLoading = false;

            $scope.title = function () { return 'Xóa trạng thái dự án'; };

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