/*
    * Create by: Binh, 14/9/2017 version 1
    * Last modify:
    * View: BTS.SP.STC.PHA/views/htdm/dmchitieubaocao
    * Sevices: Dm/PHA/dmchitieubaocao
    * Class sevices: DM_CHITIEU_BAOCAOSercive  , DM_CHITIEU_BAOCAOSerciveVm
    * Entity: Models/Dm/PHC/DM_CHITIEU_BAOCAO
    * Menu: Danh muc -> 2.15 Danh muc chi tieu
   */
define(['ui-bootstrap', 'controllers/auth/AuController', 'controllers/sys/SysDvqhns'], function () {
    'use strict';
    var app = angular.module('baocao_dt_Module', ['ui.bootstrap', 'sysDvqhns']);
    app.factory('bieu02Ctrl_Service', ['$http', 'configService', function ($http, configService) {
        var serviceUrl = configService.rootUrlWebApi + '/dm/dmbaocaodetail';
        var result = {
            Select_byLoaibaocao: function (data) {
                return $http.get(serviceUrl + '/Select_byLoaibaocao/' + data);
            }
        }
        return result;
    }]);
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
    /* controller list */
    app.controller('bieu02Ctrl', ['$scope', '$location', '$http', 'configService', 'bieu02Ctrl_Service', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify', 'securityService', 'userService', 'SysDvqhnsService','serviceSelected',
        function ($scope, $location, $http, configService, service, tempDataService, $filter, $uibModal, $log, ngNotify, securityService, userService, SysDvqhnsService, serviceSelected) {
            $scope.config = angular.copy(configService);
            $scope.paged = angular.copy(configService.pageDefault);
            $scope.filtered = angular.copy(configService.paramDefault);
            $scope.open_Search = true;
            $scope.toggleOpen_Search = function () {
                $scope.open_Search = $scope.open_Search === false ? true : false;
            };
            $scope.target = {
                KYBC: '', DONVI_TIEN: '', P_HUYEN: '', DonViLap: '', DonVIChuQuan: '', MaDiaBanThap: '', MaCapCao: '', MaCapThap: '', P_CAP: '', MaKhoBacThap: '', MaKhoBacCao: '', MaChuongThap: '', MaChuongCao: '', MaLoaiThap: '', MaLoaiCao: '', MaKhoanThap: '', MaKhoanCao: '', MaNhomThap: '', MaNhomCao: ''
                           , MaTieuNhomThap: '', MaTieuNhomCao: '', MaMucThap: '', MaMucCao: '', MaTieuMucThap: '', MaTieuMucCao: '', MaCTMTThap: '', MaCTMTCao: '', paramKhoan: '', paramLOAI:'', paramCTMT:'', paramMUC:'', paramTIEUMUC:''
            };

            $scope.target.TUNGAY_HL = new Date($filter('date')((new Date()).getFullYear() + '-01-01', 'yyyy-MM-dd'));
            $scope.target.DENNGAY_HL = new Date($filter('date')((new Date()).getFullYear() + '-12-31', 'yyyy-MM-dd'));
            $scope.target.TUNGAY_KS = new Date($filter('date')((new Date()).getFullYear() + '-01-01', 'yyyy-MM-dd'));
            $scope.target.DENNGAY_KS = new Date($filter('date')((new Date()).getFullYear() + '-12-31', 'yyyy-MM-dd'));

            var currentUser = userService.GetCurrentUser();
            if (currentUser) {
                $scope.target.P_MA_DBHC = currentUser.maDBHC;
            }
            $scope.ISNHAPTAY = false;

            $scope.formatLabel = function (model, module) {
                console.log('module', module);
                if (!model) return "";
                var data = $filter('filter')(module, { Value: model }, true);
                if (data && data.length == 1) {
                    return data[0].Value + ' - ' + data[0].Text;
                }
                return "";
            };

            function loadAccessList() {
                securityService.getAccessList('nvBaoCao_DT').then(function (successRes) {
                    if (successRes && successRes.status == 200) {
                        $scope.accessList = successRes.data;
                        if (!$scope.accessList.View) {
                            //ngNotify.set("Không có quyền truy cập !", { duration: 3000, type: 'error' });
                            window.location.href = "#!/AccessDenied";
                        } else {
                            filterData();
                        }
                    } else {
                        //ngNotify.set("Không có quyền truy cập !", { duration: 3000, type: 'error' });
                        window.location.href = "#!/AccessDenied";
                    }
                }, function (errorRes) {
                    console.log(errorRes);
                    //ngNotify.set("Không có quyền truy cập !", { duration: 3000, type: 'error' });
                    $scope.accessList = null;
                    window.location.href = "#!/AccessDenied";
                });
            }

            //loadAccessList();

            function filterData() {
                $scope.isLoading = true;
                // service.Select_byLoaibaocao('nvBaoCao_DT').then(function (successRes) {
                //     console.log(successRes);
                //     if (successRes && successRes.status == 200 && successRes.data && successRes.data.Status) {
                //         $scope.isLoading = false;
                //         $scope.LoaiBaoCaos = successRes.data.Data;
                //     }
                // }, function (errorRes) {
                //     console.log(errorRes);
                // });
                var postdata = {
                    paged: $scope.paged,
                    filtered: $scope.filtered
                };
                SysDvqhnsService.getAllDBHC().then(function (successRes) {
                    console.log(successRes);
                    if (successRes && successRes.status == 200 && successRes.data && !successRes.data.Error) {
                        $scope.lstDBHC = successRes.data.Data;
                        console.log('$scope.lstDBHC', $scope.lstDBHC);
                    }
                }, function (errorRes) {

                });
                SysDvqhnsService.getSelectDataLoaiNamBat().then(function (successRes) {
                    console.log(successRes);
                    if (successRes && successRes.status == 200 && successRes.data && !successRes.data.Error) {
                        $scope.lstBaoCao = successRes.data;
                        console.log('$scope.lstBaoCao', $scope.lstBaoCao);
                    }
                }, function (errorRes) {

                });
            };

            filterData();
            $scope.open_Search = false;
            $scope.openSearch = function () {
                $scope.open_Search = true;
            };

            $scope.closeSearch = function () {
                $scope.open_Search = false;
            };
            /* function  report */
            $scope.report = function () {
                $scope.target.TUNGAY_HL = new Date($scope.target.TUNGAY_HL);
                $scope.target.DENNGAY_HL = new Date($scope.target.DENNGAY_HL);
                $scope.target.TUNGAY_KS = new Date($scope.target.TUNGAY_KS);
                $scope.target.DENNGAY_KS = new Date($scope.target.DENNGAY_KS);
                $scope.target.P_CAP = $scope.target.MaCapCao;
                //createCongThuc($scope.target);
                //if ($scope.target.TUNGAY_HL && $scope.target.DENNGAY_HL && Date.parse($scope.target.DENNGAY_HL) < Date.parse($scope.target.TUNGAY_HL)) {
                //    ngNotify.set("Từ Ngày Hiệu Lực không được nhỏ hơn đến Ngày Hiệu Lực", { duration: 2000, type: 'error' });
                //    return;
                //}
                //if ($scope.target.TUNGAY_KS && $scope.target.DENNGAY_KS && Date.parse($scope.target.DENNGAY_KS) < Date.parse($scope.target.TUNGAY_KS)) {
                //    ngNotify.set("Từ Ngày Kết Sổ không được nhỏ hơn đến Ngày Kết Sổ", { duration: 2000, type: 'error' });
                //    return;
                //}
                //if ($scope.target.MaKhoBacThap != '' && $scope.target.MaKhoBacCao != '' && $scope.target.MaKhoBacThap > $scope.target.MaKhoBacCao) {
                //    ngNotify.set("Mã kho bạc bên thấp không được lớn hơn bên cao", { duration: 2000, type: 'error' });
                //    return;
                //}
                //if ($scope.target.MaCapThap != '' && $scope.target.MaCapCao != '' && $scope.target.MaCapThap > $scope.target.MaCapCao) {
                //    ngNotify.set("Mã cấp bên thấp không được lớn hơn bên cao (Cấp lớn nhất là cấp 1)", { duration: 2000, type: 'error' });
                //    return;
                //}
                //if ($scope.target.MaChuongThap != '' && $scope.target.MaChuongCao != '' && $scope.target.MaChuongThap > $scope.target.MaChuongCao) {
                //    ngNotify.set("Mã chương bên thấp không được lớn hơn bên cao", { duration: 2000, type: 'error' });
                //    return;
                //}
                //if ($scope.target.MaLoaiThap != '' && $scope.target.MaLoaiCao != '' && $scope.target.MaLoaiThap > $scope.target.MaLoaiCao) {
                //    ngNotify.set("Mã loại bên thấp không được lớn hơn bên cao", { duration: 2000, type: 'error' });
                //    return;
                //}
                //if ($scope.target.MaKhoanThap != '' && $scope.target.MaKhoanCao != '' && $scope.target.MaKhoanThap > $scope.target.MaKhoanCao) {
                //    ngNotify.set("Mã khoản bên thấp không được lớn hơn bên cao", { duration: 2000, type: 'error' });
                //    return;
                //}
                //if ($scope.target.MaNhomThap != '' && $scope.target.MaNhomCao != '' && $scope.target.MaNhomThap > $scope.target.MaNhomCao) {
                //    ngNotify.set("Mã nhóm bên thấp không được lớn hơn bên cao", { duration: 2000, type: 'error' });
                //    return;
                //}
                //if ($scope.target.MaTieuNhomThap != '' && $scope.target.MaTieuNhomCao != '' && $scope.target.MaTieuNhomThap > $scope.target.MaTieuNhomCao) {
                //    ngNotify.set("Mã tiểu nhóm bên thấp không được lớn hơn bên cao", { duration: 2000, type: 'error' });
                //    return;
                //}
                //if ($scope.target.MaMucThap != '' && $scope.target.MaMucCao != '' && $scope.target.MaMucThap > $scope.target.MaMucCao) {
                //    ngNotify.set("Mã mục bên thấp không được lớn hơn bên cao", { duration: 2000, type: 'error' });
                //    return;
                //}
                //if ($scope.target.MaTieuMucThap != '' && $scope.target.MaTieuMucCao != '' && $scope.target.MaTieuMucThap > $scope.target.MaTieuMucCao) {
                //    ngNotify.set("Mã tiểu mục bên thấp không được lớn hơn bên cao", { duration: 2000, type: 'error' });
                //    return;
                //}

                //if ($scope.target.MaCTMTThap != '' && $scope.target.MaCTMTCao != '' && $scope.target.MaCTMTThap > $scope.target.MaCTMTCao) {
                //    ngNotify.set("Mã chương trình mục tiêu bên thấp không được lớn hơn bên cao", { duration: 2000, type: 'error' });
                //    return;
                //}

                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    size: 'lg',
                    windowClass: 'class-window',
                    templateUrl: configService.buildUrl('nv/NamBatTinhHinh', 'reports.template'),
                    controller: 'Showbieu02Ctrl',
                    resolve: {
                        obj: function () {
                            return $scope.target;
                        }
                    }
                });
                modalInstance.result.then(function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };


            /*function  createCongThuc */
            $scope.select = function (item) {
            }

            $scope.goTo = function (item) {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('baocao', 'indexAddCol'),
                    controller: 'nvBAOCAO_ADD_COL_DATAController',
                    windowClass: 'app-modal-window',
                    resolve: {
                        targetData: function () {
                            return item;
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    //$scope.target.DataDetails = updatedData.DataDetails;
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });

            };

            // Select Tài khoản kho bạc
            $scope.selectdmTKKBTu = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmtkkhobac', 'selectData'),
                    controller: 'dmTKKHOBACSelectDataController',
                    resolve: {
                        tagdmTKKhoBacs: function () {
                            return $scope.tagdmTKKhoBacs;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.tagdmTKKhoBacs = angular.copy(updatedData);
                    $scope.target.MaKhoBacThap = updatedData.MA;

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }
            $scope.selectdmTKKBDen = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmtkkhobac', 'selectData'),
                    controller: 'dmTKKHOBACSelectDataController',
                    resolve: {
                        tagdmTKKhoBacs: function () {
                            return $scope.tagdmTKKhoBacs;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.tagdmTKKhoBacs = angular.copy(updatedData);
                    $scope.target.MaKhoBacCao = updatedData.MA;

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }

            // Select CẤP
            $scope.selectdmCAPDen = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmcap', 'selectData'),
                    controller: 'dmCapSelectDataController',
                    resolve: {
                        tagdmCAPs: function () {
                            return $scope.tagdmCAPs;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }

                });
                modalInstance.result.then(function (updatedData) {
                    $scope.target.dmCAPCodes = '';
                    $scope.tagdmCAPs = angular.copy(updatedData);
                    $scope.target.MaCapThap = updatedData.MA_TUDIEN;
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }
            $scope.selectdmCAPTu = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmcap', 'selectData'),
                    controller: 'dmCapSelectDataController',
                    resolve: {
                        tagdmCAPs: function () {
                            return $scope.tagdmCAPs;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }

                });
                modalInstance.result.then(function (updatedData) {
                    $scope.target.dmCAPCodes = '';
                    $scope.tagdmCAPs = angular.copy(updatedData);
                    $scope.target.MaCapCao = updatedData.MA_TUDIEN;
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }

            // Select CHƯƠNG
            $scope.target.MaChuongThap = "";
            $scope.target.MaChuongCao = "";
            $scope.selectdmCHUONGTu = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/DmChuong', 'selectData'),
                    controller: 'dmChuongSelectDataController',
                    resolve: {
                        tagdmCHUONGs: function () {
                            return $scope.tagdmCHUONGs;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.target.P_MaChuong = '';
                    $scope.tagdmCHUONGs = angular.copy(updatedData);
                    $scope.target.MaChuongThap = updatedData.MA_CHUONG;

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }
            $scope.selectdmCHUONGDen = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/DmChuong', 'selectData'),
                    controller: 'dmChuongSelectDataController',
                    resolve: {
                        tagdmCHUONGs: function () {
                            return $scope.tagdmCHUONGs;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.target.P_MaChuong = '';
                    $scope.tagdmCHUONGs = angular.copy(updatedData);
                    $scope.target.MaChuongCao = updatedData.MA_CHUONG;

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }

            // Select Loại
            $scope.target.MaLoaiThap = "";
            $scope.target.MaLoaiCao = "";
            $scope.selectdmLOAIDen = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmloai', 'selectData'),
                    controller: 'dmLoaiSelectDataController',
                    resolve: {
                        tagdmLoais: function () {
                            return $scope.tagdmLoais;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }

                });
                modalInstance.result.then(function (updatedData) {
                    $scope.target.P_MaLoai = '';
                    $scope.tagdmLoais = angular.copy(updatedData);
                    $scope.target.MaLoaiCao = updatedData.MA_TUDIEN;
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }
            $scope.selectdmLOAITu = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmloai', 'selectData'),
                    controller: 'dmLoaiSelectDataController',
                    resolve: {
                        tagdmLoais: function () {
                            return $scope.tagdmLoais;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }

                });
                modalInstance.result.then(function (updatedData) {
                    $scope.target.P_MaLoai = '';
                    $scope.tagdmLoais = angular.copy(updatedData);
                    $scope.target.MaLoaiThap = updatedData.MA_TUDIEN;

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }

            // Select Nhóm
            $scope.target.MaNhomThap = "";
            $scope.target.MaNhomCao = "";
            $scope.selectdmNHOMDen = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmnhom', 'selectData'),
                    controller: 'dmNhomSelectDataController',
                    resolve: {
                        tagdmNhoms: function () {
                            return $scope.tagdmNhoms;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }

                });
                modalInstance.result.then(function (updatedData) {
                    $scope.target.P_MaNhom = '';
                    $scope.tagdmNhoms = angular.copy(updatedData);
                    $scope.target.MaNhomCao = updatedData.MA_TUDIEN;
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }
            $scope.selectdmNHOMTu = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmnhom', 'selectData'),
                    controller: 'dmNhomSelectDataController',
                    resolve: {
                        tagdmNhoms: function () {
                            return $scope.tagdmNhoms;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }

                });
                modalInstance.result.then(function (updatedData) {
                    $scope.target.P_MaNhom = '';
                    $scope.tagdmNhoms = angular.copy(updatedData);
                    $scope.target.MaNhomThap = updatedData.MA_TUDIEN;

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }


            // Select Tiểu Nhóm
            $scope.target.MaTieuNhomThap = "";
            $scope.target.MaTieuNhomCao = "";
            $scope.selectdmTIEUNHOMTu = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmtieunhom', 'selectData'),
                    controller: 'dmTieuNhomSelectDataController',
                    resolve: {
                        tagdmTIEUNHOMs: function () {
                            return $scope.tagdmTIEUNHOMs;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.target.P_MaTieuNhom = '';
                    $scope.tagdmTIEUNHOMs = angular.copy(updatedData);
                    $scope.target.MaTieuNhomThap = updatedData.MA_TIEUNHOM;

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }
            $scope.selectdmTIEUNHOMDen = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmtieunhom', 'selectData'),
                    controller: 'dmTieuNhomSelectDataController',
                    resolve: {
                        tagdmTIEUNHOMs: function () {
                            return $scope.tagdmTIEUNHOMs;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.target.P_MaTieuNhom = '';
                    $scope.tagdmTIEUNHOMs = angular.copy(updatedData);
                    $scope.target.MaTieuNhomCao = updatedData.MA_TIEUNHOM;

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }

            // Select muc
            $scope.target.MaMucThap = "";
            $scope.target.MaMucCao = "";
            $scope.selectdmMUCTu = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmmuc', 'selectData'),
                    controller: 'dmMucSelectDataController',
                    resolve: {
                        tagdmMUCs: function () {
                            return $scope.tagdmMUCs;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.target.P_MaMuc = '';
                    $scope.tagdmMUCs = angular.copy(updatedData);
                    $scope.target.MaMucThap = updatedData.MA_MUC;

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }
            $scope.selectdmMUCDen = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmmuc', 'selectData'),
                    controller: 'dmMucSelectDataController',
                    resolve: {
                        tagdmMUCs: function () {
                            return $scope.tagdmMUCs;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.target.P_MaMuc = '';
                    $scope.tagdmMUCs = angular.copy(updatedData);
                    $scope.target.MaMucCao = updatedData.MA_MUC;

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }

            // Select tieu muc
            $scope.target.MaTieuMucThap = "";
            $scope.target.MaTieuMucCao = "";
            $scope.selectdmTIEUMUCTu = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmtieumuc', 'selectData'),
                    controller: 'dmTieuMucSelectDataController',
                    resolve: {
                        tagdmTIEUMUCs: function () {
                            return $scope.tagdmTIEUMUCs;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.target.P_MaTieuMuc = '';
                    $scope.tagdmTIEUMUCs = angular.copy(updatedData);
                    $scope.target.MaTieuMucThap = updatedData.MA_TIEUMUC;

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }
            $scope.selectdmTIEUMUCDen = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmtieumuc', 'selectData'),
                    controller: 'dmTieuMucSelectDataController',
                    resolve: {
                        tagdmTIEUMUCs: function () {
                            return $scope.tagdmTIEUMUCs;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.target.P_MaTieuMuc = '';
                    $scope.tagdmTIEUMUCs = angular.copy(updatedData);
                    $scope.target.MaTieuMucCao = updatedData.MA_TIEUMUC;

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }

            // Select khoan
            $scope.target.MaKhoanThap = "";
            $scope.target.MaKhoanCao = "";
            $scope.selectdmNGANHKTTu = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmnganhkt', 'selectData'),
                    controller: 'dmNganhKTSelectDataController',
                    resolve: {
                        tagdmNGANHKTs: function () {
                            return $scope.tagdmNGANHKTs;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    // $scope.target.P_MaTieuMuc = '';
                    $scope.tagdmNGANHKTs = angular.copy(updatedData);
                    $scope.target.MaKhoanThap = updatedData.MA_NGANHKT;

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }
            $scope.selectdmNGANHKTDen = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmnganhkt', 'selectData'),
                    controller: 'dmNganhKTSelectDataController',
                    resolve: {
                        tagdmNGANHKTs: function () {
                            return $scope.tagdmNGANHKTs;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    //$scope.target.P_MaTieuMuc = '';
                    $scope.tagdmNGANHKTs = angular.copy(updatedData);
                    $scope.target.MaKhoanCao = updatedData.MA_NGANHKT;

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }

            // Select CTMTQG
            $scope.target.MaCTMTThap = "";
            $scope.target.MaCTMTCao = "";
            $scope.selectdmCTMTQGTu = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmctmtqg', 'selectData'),
                    controller: 'dmCTMTQGSelectDataController',
                    resolve: {
                        tagdmCTMTQGs: function () {
                            return $scope.tagdmCTMTQGs;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    // $scope.target.P_MaTieuMuc = '';
                    $scope.tagdmCTMTQGs = angular.copy(updatedData);
                    $scope.target.MaCTMTThap = updatedData.MA_CTMTQG;

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }
            $scope.selectdmCTMTQGDen = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmctmtqg', 'selectData'),
                    controller: 'dmCTMTQGSelectDataController',
                    resolve: {
                        tagdmCTMTQGs: function () {
                            return $scope.tagdmCTMTQGs;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    //$scope.target.P_MaTieuMuc = '';
                    $scope.tagdmCTMTQGs = angular.copy(updatedData);
                    $scope.target.MaCTMTCao = updatedData.MA_CTMTQG;

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }

            // Select địa bàn hành chính
            $scope.target.MaDiaBanThap = '';
            $scope.selectdmDBHC = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmdbhc', 'selectData'),
                    controller: 'dmDBHCSelectDataController',
                    resolve: {
                        tagdmDBHCs: function () {
                            return $scope.tagdmDBHCs;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.tagdmDBHCs = angular.copy(updatedData);
                    $scope.target.MaDiaBanThap = updatedData.MA_DBHC;
                    $scope.loadHtdmDiaBanHanhChinh();
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }

            // Select đơn vị qhns
            $scope.target.MaDVNSThap = '';
            $scope.selectsysDVQHNS = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('htdm/dmdvqhns', 'selectData'),
                    controller: 'dmDVQHNSSelectDataController',
                    resolve: {
                        tagdmDVQHNSs: function () {
                            return $scope.tagdmDVQHNSs;
                        },
                        filterObject: function () {
                            return {

                            }
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.tagdmDVQHNSs = angular.copy(updatedData);
                    $scope.target.MaDVNSThap = updatedData.MA_DVQHNS;

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }

            //$scope.loadHtdmDiaBanHanhChinh = function () {
            //    serviceHtdmDiaBanHanhChinh.getAll_DanhMucDiaBanHanhChinh().then(function (responseDbhc) {
            //        if (responseDbhc.data.Status && responseDbhc.data.Data.length > 0) {
            //            if (responseDbhc.data.Data.length > 0) {
            //                var data = $filter('filter')(responseDbhc.data.Data, { Value: currentUser.maDBHC }, true);
            //                console.log(data);
            //                if (data && data.length === 1) {
            //                    $scope.target.P_MA_DBHC = data[0].Value;
            //                    $scope.target.DonViLap = data[0].Description
            //                }
            //                var data1 = $filter('filter')(responseDbhc.data.Data, { Value: $scope.target.MaDiaBanThap }, true);
            //                console.log(data1);
            //                if ($scope.target.MaDiaBanThap === '') {
            //                    $scope.target.MA_DBHC_CON = $scope.target.P_MA_DBHC;
            //                    $scope.target.DonVIChuQuan = $scope.target.DonViLap;
            //                }
            //                else {
            //                    if (data1 && data1.length === 1) {
            //                        $scope.target.MA_DBHC_CON = data1[0].Value;
            //                        $scope.target.DonVIChuQuan = data1[0].Description;
            //                    }
            //                }
            //            }

            //        }
            //    }
            //    , function (errorRes) {
            //        console.log('errorRes', errorRes);
            //    });
            //}
            //$scope.loadHtdmDiaBanHanhChinh();
            $scope.listKhoanTemp = [];
            $scope.addKhoan = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('sys/SysDvqhns', 'selectMultidataKhoan'),
                    controller: 'selectMultidataKhoanController',
                    size: 'lg',
                    resolve: {
                        dataKhoan: function () {
                            return $scope.listKhoanTemp;
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.listKhoanTemp = updatedData;
                    if (!updatedData.selected) {
                        console.log(updatedData);
                        var stringVBHS = '';
                        $scope.target.paramKhoan = '';
                        for (var i = 0; i < updatedData.length; i++) {
                            if (i != updatedData.length - 1)
                                stringVBHS += "" + updatedData[i].Value + ",";
                            else
                                stringVBHS += "" + updatedData[i].Value + "";
                        }
                        $scope.target.paramKhoan = stringVBHS;

                    }
                }, function () {

                });
            }

            $scope.listLOAITemp = [];
            $scope.addLOAI = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('sys/SysDvqhns', 'selectMultidataLoai'),
                    controller: 'selectMultidataLOAIController',
                    size: 'lg',
                    resolve: {
                        dataLOAI: function () {
                            return $scope.listLoaiTemp;
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.listLoaiTemp = updatedData;
                    if (!updatedData.selected) {
                        console.log(updatedData);
                        var stringVBHS = '';
                        $scope.target.paramLOAI = '';
                        for (var i = 0; i < updatedData.length; i++) {
                            if (i != updatedData.length - 1)
                                stringVBHS += "" + updatedData[i].Value + ",";
                            else
                                stringVBHS += "" + updatedData[i].Value + "";
                        }
                        $scope.target.paramLOAI = stringVBHS;

                    }
                }, function () {

                });
            }

            $scope.listCTMTTemp = [];
            $scope.addCTMT = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('sys/SysDvqhns', 'selectMultidataCTMT'),
                    controller: 'selectMultidataCTMTController',
                    size: 'lg',
                    resolve: {
                        dataCTMT: function () {
                            return $scope.listCTMTTemp;
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.listCTMTTemp = updatedData;
                    if (!updatedData.selected) {
                        console.log(updatedData);
                        var stringVBHS = '';
                        $scope.target.paramCTMT = ''; 
                        for (var i = 0; i < updatedData.length; i++) {
                            if (i != updatedData.length - 1)
                                stringVBHS += "" + updatedData[i].Value + ",";
                            else
                                stringVBHS += "" + updatedData[i].Value + "";
                        }
                        $scope.target.paramCTMT = stringVBHS;

                    }
                }, function () {

                });
            }

            $scope.listMUCTemp = [];
            $scope.addMUC = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('sys/SysDvqhns', 'selectMultidataMuc'),
                    controller: 'selectMultidataMUCController',
                    size: 'lg',
                    resolve: {
                        dataMUC: function () {
                            return $scope.listMUCTemp;
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.listMUCTemp = updatedData;
                    if (!updatedData.selected) {
                        console.log(updatedData);
                        var stringVBHS = '';
                        $scope.target.paramMUC = ''; 
                        for (var i = 0; i < updatedData.length; i++) {
                            if (i != updatedData.length - 1)
                                stringVBHS += "" + updatedData[i].Value + ",";
                            else
                                stringVBHS += "" + updatedData[i].Value + "";
                        }
                        $scope.target.paramMUC = stringVBHS;

                    }
                }, function () {

                });
            }

            $scope.listTIEUMUCTemp = [];
            $scope.addTIEUMUC = function () {
                var modalInstance = $uibModal.open({
                    backdrop: 'static',
                    templateUrl: configService.buildUrl('sys/SysDvqhns', 'selectMultidataTieuMuc'),
                    controller: 'selectMultidataTIEUMUCController',
                    size: 'lg',
                    resolve: {
                        dataTIEUMUC: function () {
                            return $scope.listTIEUMUCTemp;
                        }
                    }
                });
                modalInstance.result.then(function (updatedData) {
                    $scope.listTIEUMUCTemp = updatedData;
                    if (!updatedData.selected) {
                        console.log(updatedData);
                        var stringVBHS = '';
                        $scope.target.paramTIEUMUC = '';
                        for (var i = 0; i < updatedData.length; i++) {
                            if (i != updatedData.length - 1)
                                stringVBHS += "" + updatedData[i].Value + ",";
                            else
                                stringVBHS += "" + updatedData[i].Value + "";
                        }
                        $scope.target.paramTIEUMUC = stringVBHS; 

                    }
                }, function () {

                });
            }
        }]);




    /* controller ShowReportController */
    app.controller('Showbieu02Ctrl', ['$scope', '$uibModalInstance', '$location', '$http', 'configService', 'obj', 'bieu02Ctrl_Service', 'tempDataService', '$filter', '$uibModal', '$log', function ($scope, $uibModalInstance, $location, $http, configService, obj, service, tempDataService, $filter, $uibModal, $log) {
        $scope.para = angular.copy(obj);
        console.log($scope.para);
        /*
                var month = $scope.para.TUNGAY_HL.getMonth(); //months from 1-12
                var day = $scope.para.TUNGAY_HL.getDate();
                var year = $scope.para.TUNGAY_HL.getFullYear();
                $scope.para.TUNGAY_HL = new Date(year, month, day, 7, 0, 0);
        
                console.log('TUNGAY_HL=', $scope.para.TUNGAY_HL)
        */
        console.log('TUNGAY_HL=', $scope.para.TUNGAY_HL)
        $scope.cancel = function () {
            $uibModalInstance.close();
        };
        $scope.report = {

            name: "BTS.SP.API.PHF.Reports.NamBat." + $scope.para.MABAOCAO + ",BTS.SP.API.PHF",
            title: $scope.para.TENBAOCAO,
            params: $scope.para
        }


    }]);


    return app;
});


