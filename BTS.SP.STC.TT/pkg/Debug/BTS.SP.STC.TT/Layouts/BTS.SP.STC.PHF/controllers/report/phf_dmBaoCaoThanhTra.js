/*
    * Create by: Binh, 14/9/2017 version 1
    * Last modify:
    * View: BTS.SP.STC.PHA/views/htdm/dmchitieubaocao
    * Sevices: Dm/PHA/dmchitieubaocao
    * Class sevices: DM_CHITIEU_BAOCAOSercive  , DM_CHITIEU_BAOCAOSerciveVm
    * Entity: Models/Dm/PHC/DM_CHITIEU_BAOCAO
    * Menu: Danh muc -> 2.15 Danh muc chi tieu
   */
define(['ui-bootstrap', 'controllers/dm/phf_dmDoiTuong'], function () {
    'use strict';
    var app = angular.module('phf_dmBaoCaoThanhTra', []);
    app.factory('DmBaoCaoThanhTraService', ['$http', 'configService', function ($http, configService) {
        var serviceUrl = configService.rootUrlWebApi + '/dm/phf_dmBaoCaoThanhTra';
        var result = {
            Select_byLoaibaocao: function (data) {
                return $http.get(serviceUrl + '/Select_byLoaibaocao/' + data);
            },
        }
        return result;
    }]);
    /* controller list */
    app.controller('DmBaoCaoThanhTraCtrl', ['$scope', '$location', '$http', 'configService', 'DmBaoCaoThanhTraService', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify', 'securityService', 'userService', 'dmdbhc_Service', function ($scope, $location, $http, configService, service, tempDataService, $filter, $uibModal, $log, ngNotify, securityService, userService, serviceHtdmDiaBanHanhChinh) {
        $scope.config = angular.copy(configService);
        $scope.paged = angular.copy(configService.pageDefault);
        $scope.filtered = angular.copy(configService.paramDefault);
        $scope.donViTiens = tempDataService.tempData('donViTiens');
        $scope.Kybaocao = tempDataService.tempData('Kybaocao');
        $scope.maHuyen = tempDataService.tempData('maHuyen');
        $scope.target = {
            KYBC: '', DONVI_TIEN: '', P_HUYEN: '', DonViLap: '', DonVIChuQuan: '', MaDiaBanThap: '', MaCapCao: '', MaCapThap: '', P_CAP: '', MaKhoBacThap: '', MaKhoBacCao: '', MaChuongThap: '', MaChuongCao: '', MaLoaiThap: '', MaLoaiCao: '', MaKhoanThap: '', MaKhoanCao: '', MaNhomThap: '', MaNhomCao: ''
						, MaTieuNhomThap: '', MaTieuNhomCao: '', MaMucThap: '', MaMucCao: '', MaTieuMucThap: '', MaTieuMucCao: '', MaCTMTThap: '', MaCTMTCao: ''
        };
        $scope.target.KYBC = $scope.Kybaocao[0].Value;
        $scope.target.DONVI_TIEN = $scope.donViTiens[0].Value;
        $scope.target.P_HUYEN = $scope.maHuyen[0].Value;
        $scope.target.LOAI_BC_DH_QT = 'DH';

        $scope.target.TUNGAY_HL = new Date($filter('date')((new Date()).getFullYear() + '-01-01', 'yyyy-MM-dd'));
        $scope.target.DENNGAY_HL = new Date($filter('date')((new Date()).getFullYear() + '-12-31', 'yyyy-MM-dd'));
        $scope.target.TUNGAY_KS = new Date($filter('date')((new Date()).getFullYear() + '-01-01', 'yyyy-MM-dd'));
        $scope.target.DENNGAY_KS = new Date($filter('date')((new Date()).getFullYear() + '-12-31', 'yyyy-MM-dd'));
        var currentUser = userService.GetCurrentUser();
        if (currentUser) {
            $scope.target.P_MA_DBHC = currentUser.maDBHC;
            $scope.target.P_USER_NAME = currentUser.userName;
        }
        $scope.ISNHAPTAY = false;

        function loadAccessList() {
            securityService.getAccessList('nvBaoCao_QT').then(function (successRes) {
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

        loadAccessList();

        function filterData() {
            $scope.isLoading = true;
            service.Select_byLoaibaocao('nvBaoCao_QT').then(function (successRes) {
                console.log(successRes);
                if (successRes && successRes.status == 200 && successRes.data && successRes.data.Status) {
                    $scope.isLoading = false;
                    $scope.LoaiBaoCaos = successRes.data.Data;
                }
            }, function (errorRes) {
                console.log(errorRes);
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



        /* function  changekybaocao */
        $scope.changekybaocao = function (value) {
            var arr = value.split('_');
            if (arr.length > 0) {
                var arr_name = arr[0];
                var arr_Value = arr[1];
                var den_thang = '12';
                var den_ngay = '31';
                var tu_thang = '01';
                var tu_ngay = '01';
                if (arr_name == 'QUY' && arr_Value == '1') { tu_ngay = '01'; den_ngay = '31'; tu_thang = '01'; den_thang = '03'; }
                if (arr_name == 'QUY' && arr_Value == '2') { tu_ngay = '01'; den_ngay = '30'; tu_thang = '03'; den_thang = '06'; }
                if (arr_name == 'QUY' && arr_Value == '3') { tu_ngay = '01'; den_ngay = '30'; tu_thang = '07'; den_thang = '09'; }
                if (arr_name == 'QUY' && arr_Value == '4') { tu_ngay = '01'; den_ngay = '31'; tu_thang = '09'; den_thang = '12'; }
                if (arr_name == 'THANG' && arr_Value == '1') { tu_ngay = '01'; den_ngay = '31'; tu_thang = '01'; den_thang = '01'; }
                if (arr_name == 'THANG' && arr_Value == '2') { tu_ngay = '01'; den_ngay = '28'; tu_thang = '02'; den_thang = '02'; }
                if (arr_name == 'THANG' && arr_Value == '3') { tu_ngay = '01'; den_ngay = '31'; tu_thang = '03'; den_thang = '03'; }
                if (arr_name == 'THANG' && arr_Value == '4') { tu_ngay = '01'; den_ngay = '30'; tu_thang = '04'; den_thang = '04'; }
                if (arr_name == 'THANG' && arr_Value == '5') { tu_ngay = '01'; den_ngay = '31'; tu_thang = '05'; den_thang = '05'; }
                if (arr_name == 'THANG' && arr_Value == '6') { tu_ngay = '01'; den_ngay = '31'; tu_thang = '06'; den_thang = '06'; }
                if (arr_name == 'THANG' && arr_Value == '7') { tu_ngay = '01'; den_ngay = '31'; tu_thang = '07'; den_thang = '07'; }
                if (arr_name == 'THANG' && arr_Value == '8') { tu_ngay = '01'; den_ngay = '31'; tu_thang = '08'; den_thang = '08'; }
                if (arr_name == 'THANG' && arr_Value == '9') { tu_ngay = '01'; den_ngay = '31'; tu_thang = '09'; den_thang = '09'; }
                if (arr_name == 'THANG' && arr_Value == '10') { tu_ngay = '01'; den_ngay = '31'; tu_thang = '10'; den_thang = '10'; }
                if (arr_name == 'THANG' && arr_Value == '11') { tu_ngay = '01'; den_ngay = '31'; tu_thang = '11'; den_thang = '11'; }
                if (arr_name == 'THANG' && arr_Value == '12') { tu_ngay = '01'; den_ngay = '31'; tu_thang = '12'; den_thang = '12'; }


                $scope.target.TUNGAY_HL = new Date($filter('date')((new Date()).getFullYear() + '/' + tu_thang + '/' + tu_ngay, 'dd/MM/yyyy'));
                $scope.target.DENNGAY_HL = new Date($filter('date')((new Date()).getFullYear() + '/' + den_thang + '/' + den_ngay, 'dd/MM/yyyy'));
                //$scope.target.TUNGAY_HL = new Date($filter('date')((new Date()).getFullYear() + '-' + tu_thang + '-' + tu_ngay, 'yyyy-MM-dd'));
                //$scope.target.DENNGAY_HL = new Date($filter('date')((new Date()).getFullYear() + '-' + den_thang + '-' + den_ngay, 'yyyy-MM-dd'));
                $scope.target.TUNGAY_KS = new Date($filter('date')((new Date()).getFullYear() + '-' + tu_thang + '-' + tu_ngay, 'yyyy-MM-dd'));
                $scope.target.DENNGAY_KS = new Date($filter('date')((new Date()).getFullYear() + '-' + den_thang + '-' + den_ngay, 'yyyy-MM-dd'));

            }
        }
        /*function  createCongThuc */
        $scope.select = function (item) {
            $scope.target.showdiv = false;
            var data = $filter('filter')($scope.LoaiBaoCaos, { MABAOCAO: item }, true);
            if (data && data.length > 0) {
                console.log(data[0].ISNHAPTAY);
                $scope.target.MABAOCAO = data[0].MABAOCAO;
                $scope.target.TENBAOCAO = data[0].TENBAOCAO;
                $scope.target.PART_REPORT = data[0].PART_REPORT;
                $scope.ISNHAPTAY = data[0].ISNHAPTAY;
                // lấy mã báo cáo
                $scope.MaBaoCao_temp = item;
                if (item == 'PL08_BM05_XP') {
                    $scope.target.showdiv = true;
                }
            }
        }
        /* function  report */
        function LoadModalBox(ctr) {
            var modalInstance = $uibModal.open({
                backdrop: 'static',
                size: 'lg',
                windowClass: 'class-window',
                templateUrl: configService.buildUrl('baocao', 'reports.template'),
                controller: ctr,
                resolve: {
                    obj: function () {
                        return $scope.target;
                    }
                }
            });
            modalInstance.result.then(function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        }
        $scope.report = function () {
            $scope.target.TUNGAY_HL = new Date($scope.target.TUNGAY_HL);
            $scope.target.DENNGAY_HL = new Date($scope.target.DENNGAY_HL);
            $scope.target.TUNGAY_KS = new Date($scope.target.TUNGAY_KS);
            $scope.target.DENNGAY_KS = new Date($scope.target.DENNGAY_KS);
            $scope.target.P_CAP = $scope.target.MaCapCao;
            createCongThuc($scope.target);
            if ($scope.target.TUNGAY_HL && $scope.target.DENNGAY_HL && Date.parse($scope.target.DENNGAY_HL) < Date.parse($scope.target.TUNGAY_HL)) {
                ngNotify.set("Từ Ngày Hiệu Lực không được nhỏ hơn đến Ngày Hiệu Lực", { duration: 2000, type: 'error' });
                return;
            }
            if ($scope.target.TUNGAY_KS && $scope.target.DENNGAY_KS && Date.parse($scope.target.DENNGAY_KS) < Date.parse($scope.target.TUNGAY_KS)) {
                ngNotify.set("Từ Ngày Kết Sổ không được nhỏ hơn đến Ngày Kết Sổ", { duration: 2000, type: 'error' });
                return;
            }
            if ($scope.target.MaKhoBacThap != '' && $scope.target.MaKhoBacCao != '' && $scope.target.MaKhoBacThap > $scope.target.MaKhoBacCao) {
                ngNotify.set("Mã kho bạc bên thấp không được lớn hơn bên cao", { duration: 2000, type: 'error' });
                return;
            }
            if ($scope.target.MaCapThap != '' && $scope.target.MaCapCao != '' && $scope.target.MaCapThap > $scope.target.MaCapCao) {
                ngNotify.set("Mã cấp bên thấp không được lớn hơn bên cao (Cấp lớn nhất là cấp 1)", { duration: 2000, type: 'error' });
                return;
            }
            if ($scope.target.MaChuongThap != '' && $scope.target.MaChuongCao != '' && $scope.target.MaChuongThap > $scope.target.MaChuongCao) {
                ngNotify.set("Mã chương bên thấp không được lớn hơn bên cao", { duration: 2000, type: 'error' });
                return;
            }
            if ($scope.target.MaLoaiThap != '' && $scope.target.MaLoaiCao != '' && $scope.target.MaLoaiThap > $scope.target.MaLoaiCao) {
                ngNotify.set("Mã loại bên thấp không được lớn hơn bên cao", { duration: 2000, type: 'error' });
                return;
            }
            if ($scope.target.MaKhoanThap != '' && $scope.target.MaKhoanCao != '' && $scope.target.MaKhoanThap > $scope.target.MaKhoanCao) {
                ngNotify.set("Mã khoản bên thấp không được lớn hơn bên cao", { duration: 2000, type: 'error' });
                return;
            }
            if ($scope.target.MaNhomThap != '' && $scope.target.MaNhomCao != '' && $scope.target.MaNhomThap > $scope.target.MaNhomCao) {
                ngNotify.set("Mã nhóm bên thấp không được lớn hơn bên cao", { duration: 2000, type: 'error' });
                return;
            }
            if ($scope.target.MaTieuNhomThap != '' && $scope.target.MaTieuNhomCao != '' && $scope.target.MaTieuNhomThap > $scope.target.MaTieuNhomCao) {
                ngNotify.set("Mã tiểu nhóm bên thấp không được lớn hơn bên cao", { duration: 2000, type: 'error' });
                return;
            }
            if ($scope.target.MaMucThap != '' && $scope.target.MaMucCao != '' && $scope.target.MaMucThap > $scope.target.MaMucCao) {
                ngNotify.set("Mã mục bên thấp không được lớn hơn bên cao", { duration: 2000, type: 'error' });
                return;
            }
            if ($scope.target.MaTieuMucThap != '' && $scope.target.MaTieuMucCao != '' && $scope.target.MaTieuMucThap > $scope.target.MaTieuMucCao) {
                ngNotify.set("Mã tiểu mục bên thấp không được lớn hơn bên cao", { duration: 2000, type: 'error' });
                return;
            }

            if ($scope.target.MaCTMTThap != '' && $scope.target.MaCTMTCao != '' && $scope.target.MaCTMTThap > $scope.target.MaCTMTCao) {
                ngNotify.set("Mã chương trình mục tiêu bên thấp không được lớn hơn bên cao", { duration: 2000, type: 'error' });
                return;
            }
            if ($scope.target.MABAOCAO === 'BM54_ND31_CT' || $scope.target.MABAOCAO === 'BM54_ND31_HX' || $scope.target.MABAOCAO === 'BM54_ND31') {
                if ($scope.target.MaCapCao === '') {
                    ngNotify.set("Chưa chọn cấp xem báo cáo ", { duration: 2000, type: 'error' });
                    return;
                }
            }
            if ($scope.target.MABAOCAO) {
                if ($scope.target.MABAOCAO === 'PL08_BM05_XP') {
                    LoadModalBox('nvBaoCaoXaPhuongController');
                } else {
                    LoadModalBox('ShowReportController');
                }
            }

        };

        function createCongThuc(target) {
            $scope.condition = {
                para: [],
            };
            // truyen gia tri vào P_CONGTHUC
            $scope.congthuc = "";
            $scope.parameter = [];
            $scope.para = [];
            $scope.condition.display = '';
            function isUndefined(value) {
                var result = '';
                if (typeof value === "undefined") {
                    result = '';
                }
                else {
                    result = value;
                }
                return result;
            }
            var item_mabc = $scope.MaBaoCao_temp;
            console.log($scope.MaBaoCao_temp);
            //theo địa bàn hành chính
            if (item_mabc == 'BM58_ND31' || item_mabc == 'BM58_ND31_CT' || item_mabc == 'PL06_BM48_01' || item_mabc == 'PL06_BM48_A' || item_mabc == 'BM59_ND31' || item_mabc == 'PL06_BM52_NS_HD') {
                $scope.congthuc = 'KB' + "'" + isUndefined(target.MaKhoBacThap) + "'" + "." + 'KB' + "'" + isUndefined(target.MaKhoBacCao) + "'" + ';' +
								   'CA' + "'" + isUndefined(target.MaCapThap) + "'" + "." + 'CA' + "'" + isUndefined(target.MaCapCao) + "'" + ';' +
								   'CH' + "'" + isUndefined(target.MaChuongThap) + "'" + "." + 'CH' + "'" + isUndefined(target.MaChuongCao) + "'" + ';' +
								   'L' + "'" + isUndefined(target.MaLoaiThap) + "'" + "." + 'L' + "'" + isUndefined(target.MaLoaiCao) + "'" + ';' +
								   'KH' + "'" + isUndefined(target.MaKhoanThap) + "'" + "." + 'KH' + "'" + isUndefined(target.MaKhoanCao) + "'" + ';' +
								   'NH' + "'" + isUndefined(target.MaNhomThap) + "'" + "." + 'NH' + "'" + isUndefined(target.MaNhomCao) + "'" + ';' +
								   'TN' + "'" + isUndefined(target.MaTieuNhomThap) + "'" + "." + 'TN' + "'" + isUndefined(target.MaTieuNhomCao) + "'" + ';' +
								   'MC' + "'" + isUndefined(target.MaMucThap) + "'" + "." + 'MC' + "'" + isUndefined(target.MaMucCao) + "'" + ';' +
								   'TM' + "'" + isUndefined(target.MaTieuMucThap) + "'" + "." + 'TM' + "'" + isUndefined(target.MaTieuMucCao) + "'" + ';' +
								   'CT' + "'" + isUndefined(target.MaCTMTThap) + "'" + "." + 'CT' + "'" + isUndefined(target.MaCTMTCao) + "'" + ';' +
								   'DV' + "'" + isUndefined(target.MaDVNSThap) + "'" + "." + 'DV' + "'" + isUndefined(target.MaDVNSCao) + "'";
            }
                //theo đơn vị quan hệ ngân sách
            else if (item_mabc == 'BM54_ND31' || item_mabc == 'BM54_ND31_CT' || item_mabc == 'BM54_ND31_HX' || item_mabc == 'BM58_ND31' || item_mabc == 'BM58_ND31_CT') {
                $scope.congthuc = 'KB' + "'" + isUndefined(target.MaKhoBacThap) + "'" + "." + 'KB' + "'" + isUndefined(target.MaKhoBacCao) + "'" + ';' +
								   'CH' + "'" + isUndefined(target.MaChuongThap) + "'" + "." + 'CH' + "'" + isUndefined(target.MaChuongCao) + "'" + ';' +
								   'L' + "'" + isUndefined(target.MaLoaiThap) + "'" + "." + 'L' + "'" + isUndefined(target.MaLoaiCao) + "'" + ';' +
								   'KH' + "'" + isUndefined(target.MaKhoanThap) + "'" + "." + 'KH' + "'" + isUndefined(target.MaKhoanCao) + "'" + ';' +
								   'NH' + "'" + isUndefined(target.MaNhomThap) + "'" + "." + 'NH' + "'" + isUndefined(target.MaNhomCao) + "'" + ';' +
								   'TN' + "'" + isUndefined(target.MaTieuNhomThap) + "'" + "." + 'TN' + "'" + isUndefined(target.MaTieuNhomCao) + "'" + ';' +
								   'MC' + "'" + isUndefined(target.MaMucThap) + "'" + "." + 'MC' + "'" + isUndefined(target.MaMucCao) + "'" + ';' +
								   'TM' + "'" + isUndefined(target.MaTieuMucThap) + "'" + "." + 'TM' + "'" + isUndefined(target.MaTieuMucCao) + "'" + ';' +
								   'CT' + "'" + isUndefined(target.MaCTMTThap) + "'" + "." + 'CT' + "'" + isUndefined(target.MaCTMTCao) + "'" + ';' +
								   'DB' + "'" + isUndefined(target.MaDiaBanThap) + "'" + "." + 'DB' + "'" + isUndefined(target.MaDiaBanCao) + "'";
            }
            else if (item_mabc == 'BM55_ND31' || item_mabc == 'BM55_ND31_CT' || item_mabc == 'BM56_ND31' || item_mabc == 'BM56_ND31_CT' || item_mabc == 'BM57_ND31' || item_mabc == 'BM57_ND31_CT' || item_mabc == 'BM60_ND31' || item_mabc == 'BM60_ND31_CT' || item_mabc == 'BM61_ND31' || item_mabc == 'BM61_ND31_CT' || item_mabc == 'BM61_ND31_TT') {
                $scope.congthuc = 'KB' + "'" + isUndefined(target.MaKhoBacThap) + "'" + "." + 'KB' + "'" + isUndefined(target.MaKhoBacCao) + "'" + ';' +
                                'CH' + "'" + isUndefined(target.MaChuongThap) + "'" + "." + 'CH' + "'" + isUndefined(target.MaChuongCao) + "'" + ';' +
                                'L' + "'" + isUndefined(target.MaLoaiThap) + "'" + "." + 'L' + "'" + isUndefined(target.MaLoaiCao) + "'" + ';' +
                                'KH' + "'" + isUndefined(target.MaKhoanThap) + "'" + "." + 'KH' + "'" + isUndefined(target.MaKhoanCao) + "'" + ';' +
                                'NH' + "'" + isUndefined(target.MaNhomThap) + "'" + "." + 'NH' + "'" + isUndefined(target.MaNhomCao) + "'" + ';' +
                                'TN' + "'" + isUndefined(target.MaTieuNhomThap) + "'" + "." + 'TN' + "'" + isUndefined(target.MaTieuNhomCao) + "'" + ';' +
                                'MC' + "'" + isUndefined(target.MaMucThap) + "'" + "." + 'MC' + "'" + isUndefined(target.MaMucCao) + "'" + ';' +
                                'TM' + "'" + isUndefined(target.MaTieuMucThap) + "'" + "." + 'TM' + "'" + isUndefined(target.MaTieuMucCao) + "'" + ';' +
                                'CT' + "'" + isUndefined(target.MaCTMTThap) + "'" + "." + 'CT' + "'" + isUndefined(target.MaCTMTCao) + "'" + ';' +
                                'DB' + "'" + isUndefined(target.MaDiaBanThap) + "'" + "." + 'DB' + "'" + isUndefined(target.MaDiaBanCao) + "'" + ';' +
                                'DV' + "'" + isUndefined(target.MaDVNSThap) + "'" + "." + 'DV' + "'" + isUndefined(target.MaDVNSCao) + "'";

            }
            else  // theo chỉ tiêu
            {
                $scope.congthuc = 'KB' + "'" + isUndefined(target.MaKhoBacThap) + "'" + "." + 'KB' + "'" + isUndefined(target.MaKhoBacCao) + "'" + ';' +
								   'CA' + "'" + isUndefined(target.MaCapThap) + "'" + "." + 'CA' + "'" + isUndefined(target.MaCapCao) + "'" + ';' +
								   'CH' + "'" + isUndefined(target.MaChuongThap) + "'" + "." + 'CH' + "'" + isUndefined(target.MaChuongCao) + "'" + ';' +
								   'L' + "'" + isUndefined(target.MaLoaiThap) + "'" + "." + 'L' + "'" + isUndefined(target.MaLoaiCao) + "'" + ';' +
								   'KH' + "'" + isUndefined(target.MaKhoanThap) + "'" + "." + 'KH' + "'" + isUndefined(target.MaKhoanCao) + "'" + ';' +
								   'NH' + "'" + isUndefined(target.MaNhomThap) + "'" + "." + 'NH' + "'" + isUndefined(target.MaNhomCao) + "'" + ';' +
								   'TN' + "'" + isUndefined(target.MaTieuNhomThap) + "'" + "." + 'TN' + "'" + isUndefined(target.MaTieuNhomCao) + "'" + ';' +
								   'MC' + "'" + isUndefined(target.MaMucThap) + "'" + "." + 'MC' + "'" + isUndefined(target.MaMucCao) + "'" + ';' +
								   'TM' + "'" + isUndefined(target.MaTieuMucThap) + "'" + "." + 'TM' + "'" + isUndefined(target.MaTieuMucCao) + "'" + ';' +
								   'CT' + "'" + isUndefined(target.MaCTMTThap) + "'" + "." + 'CT' + "'" + isUndefined(target.MaCTMTCao) + "'" + ';' +
								   'DB' + "'" + isUndefined(target.MaDiaBanThap) + "'" + "." + 'DB' + "'" + isUndefined(target.MaDiaBanCao) + "'" + ';' +
								   'DV' + "'" + isUndefined(target.MaDVNSThap) + "'" + "." + 'DV' + "'" + isUndefined(target.MaDVNSCao) + "'";
            }

            $scope.allCongThuc = $scope.congthuc.split(';');
            angular.forEach($scope.allCongThuc, function (value, index) {
                if (value.includes('\'\'')) {
                    var dieukien = value.substring(0, value.indexOf('\''));
                    var dkReplace = '\'\'' + '.' + dieukien + '';
                    if (value.includes(dkReplace)) ////KB''.KB'1113' ,  L''.L'2000'
                    {
                        dkReplace = '' + dieukien + '';
                        var num = value.lastIndexOf(dkReplace);
                        var ma = value.substring(num, value.lastIndexOf('\''));//KB'1113'
                        var ma = ma.substring(ma.indexOf('\'') + 1, ma.length);//KB'1113'
                        var ma = '\'' + ma + '\''
                        var data = value.replace('\'\'', '' + ma + '');
                        var stringReplace = '\'.' + dieukien + '\'';
                        var record = data.replace(stringReplace, '~');
                        record = record.replace('\'', '[');
                        record = record.replace('\'', ']')
                        $scope.parameter.push(record);
                    }
                    else ////KB'1113'.KB'', L'1002'.L''
                    {
                        dkReplace = '.' + dieukien + '\'';
                        var begin = value.indexOf('\'');
                        var num = value.substring(begin + 1, value.indexOf(dkReplace) - 1);
                        var ma = num;
                        var ma = '\'' + ma + '\''
                        var data = value.replace('\'\'', '' + ma + '');
                        var stringReplace = '\'.' + dieukien + '\'';
                        var record = data.replace(stringReplace, '~');
                        record = record.replace('\'', '[');
                        record = record.replace('\'', ']')
                        $scope.parameter.push(record);
                    }
                }
                else {//KB'1111'.KB'1113'
                    var dieukien = value.substring(0, value.indexOf('\''));
                    var stringReplace = '\'.' + dieukien + '\'';
                    var data = value.replace(stringReplace, '~');
                    data = data.replace('\'', '[');
                    data = data.replace('\'', ']')
                    $scope.parameter.push(data);
                }
            });
            if ($scope.parameter.length > 0) {
                angular.forEach($scope.parameter, function (value, index) {
                    if (value.includes('[~]') || value.includes('[]~') || value.includes('[]~\'')) {

                    }
                    else {
                        $scope.para.push(value);
                    }
                });
                $scope.para = $scope.para.toString();
                $scope.para = $scope.para.replace(/,/g, '+');
            }
            $scope.condition.para = $scope.para;
            $scope.target.P_CONGTHUC = $scope.para;
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

        $scope.loadHtdmDiaBanHanhChinh = function () {
            serviceHtdmDiaBanHanhChinh.getAll_DanhMucDiaBanHanhChinh().then(function (responseDbhc) {
                if (responseDbhc.data.Status && responseDbhc.data.Data.length > 0) {
                    if (responseDbhc.data.Data.length > 0) {
                        var data = $filter('filter')(responseDbhc.data.Data, { Value: currentUser.maDBHC }, true);
                        console.log(data);
                        if (data && data.length === 1) {
                            $scope.target.P_MA_DBHC = data[0].Value;
                            $scope.target.DonViLap = data[0].Description
                        }
                        var data1 = $filter('filter')(responseDbhc.data.Data, { Value: $scope.target.MaDiaBanThap }, true);
                        console.log(data1);
                        if ($scope.target.MaDiaBanThap === '') {
                            $scope.target.MA_DBHC_CON = $scope.target.P_MA_DBHC;
                            $scope.target.DonVIChuQuan = $scope.target.DonViLap;
                        }
                        else {
                            if (data1 && data1.length === 1) {
                                $scope.target.MA_DBHC_CON = data1[0].Value;
                                $scope.target.DonVIChuQuan = data1[0].Description;
                            }
                        }
                    }

                }
            }
            , function (errorRes) {
                console.log('errorRes', errorRes);
            });
        }
        $scope.loadHtdmDiaBanHanhChinh();

    }]);




    /* controller ShowReportController */
    app.controller('ShowReportController', ['$scope', '$uibModalInstance', '$location', '$http', 'configService', 'obj', 'baocao_qt_Service', 'tempDataService', '$filter', '$uibModal', '$log', function ($scope, $uibModalInstance, $location, $http, configService, obj, service, tempDataService, $filter, $uibModal, $log) {
        $scope.para = angular.copy(obj);
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

            /*name: "BTS.SP.API.PHA.Reports.B3_01.DEMOPA,BTS.SP.API.PHA",*/
            name: "BTS.SP.API.PHA.Reports.BCQT." + $scope.para.PART_REPORT + ",BTS.SP.API.PHA",
            title: $scope.para.TENBAOCAO,
            params: $scope.para
        }
        console.log($scope.para);

    }]);

    app.controller('nvBaoCaoXaPhuongController', ['$scope', '$uibModalInstance', '$location', '$http', 'configService', 'obj', 'baocao_qt_Service', 'tempDataService', '$filter', '$uibModal', '$log', function ($scope, $uibModalInstance, $location, $http, configService, obj, service, tempDataService, $filter, $uibModal, $log) {
        $scope.para = angular.copy(obj);
        /*
                var month = $scope.para.TUNGAY_HL.getMonth(); //months from 1-12
                var day = $scope.para.TUNGAY_HL.getDate();
                var year = $scope.para.TUNGAY_HL.getFullYear();
                $scope.para.TUNGAY_HL = new Date(year, month, day, 7, 0, 0);
        
                console.log('TUNGAY_HL=', $scope.para.TUNGAY_HL)
        */
        var tpl = '';
        switch ($scope.para.P_HUYEN) {
            case 258: tpl = 'PL08_B05_YP'; break;
            case 264: tpl = 'PL08_B05_LT'; break;
            case 260: tpl = 'PL08_B05_TD'; break;
            case 259: tpl = 'PL08_B05_QV'; break;
            case 262: tpl = 'PL08_B05_TT'; break;
            case 256: tpl = 'PL08_B05_TPBN'; break;
            case 261: tpl = 'PL08_B05_TS'; break;
            case 263: tpl = 'PL08_B05_GB'; break;
            default: tpl = 'PL08_B05_TPBN'; break;
                // console.log('TUNGAY_HL=', $scope.para.TUNGAY_HL)
                $scope.cancel = function () {
                    $uibModalInstance.close();
                };
        }
        $scope.report = {


            name: "BTS.SP.API.PHA.Reports.BCQT.PHA.PL08_B05." + tpl + ",BTS.SP.API.PHA",
            title: $scope.para.TENBAOCAO,
            params: $scope.para
        }
        console.log($scope.para);

    }]);

    return app;
});