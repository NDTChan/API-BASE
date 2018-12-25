define([], function () {
    'use strict';
    var app = angular.module('sysTuDien', []);
    app.factory('sysTuDienService', ['$http', 'configService', function ($http, configService) {
        var serviceUrl = configService.rootUrlWebApi + '/sys/SysTuDien';
        var result = {
            postSelectData: function (data) {
                return $http.post(serviceUrl + '/PostSelectData', data);
            },

        }
        return result;
    }]);

    /* controller dmLoai SelectData_ctrl ANHPT*/
    app.controller('sysTuDienSelectData_ctrl', ['$scope', '$uibModalInstance', '$location', '$http', 'configService', 'sysTuDienService', 'tempDataService', '$filter', '$uibModal', '$log', 'ngNotify',
        function ($scope, $uibModalInstance, $location, $http, configService, service, tempDataService, $filter, $uibModal, $log, ngNotify) {
            $scope.config = angular.copy(configService);
            var tempData = tempDataService.tempData;
            $scope.lstLoaiDT = tempData('typeSysTuDien');
            $scope.paged = angular.copy(configService.pageDefault);
            $scope.filtered = angular.copy(configService.paramDefault);
            $scope.filtered.AdvanceData.LOAI_TUDIEN = 'LOAITHANHTRA';
            console.log($scope.filtered);
            $scope.listSelectedData = [];
            function filterData() {
                $scope.isLoading = true;
                var postdata = { paged: $scope.paged, filtered: $scope.filtered };
                service.postSelectData(postdata).then(function (successRes) {
                    console.log(successRes);
                    if (successRes && successRes.status === 200 && successRes.data) {
                        $scope.isLoading = false;
                        $scope.data = successRes.data.Data.Data;
                        angular.forEach($scope.data, function (v, k) {
                            var isSelected = $scope.listSelectedData.some(function (element, index, array) {
                                if (!element) return false;
                                return element.Value == v.Value;
                            });
                            if (isSelected) {
                                $scope.data[k].Selected = true;
                            }
                        })
                        angular.extend($scope.paged, successRes.data.Data);
                    }
                }, function (errorRes) {
                    console.log(errorRes);
                });
            };
            filterData();
            $scope.doSearch = function () {
                filterData();
            };
            $scope.title = function () {
                return 'Danh mục loại';
            };
            $scope.pageChanged = function () {
                filterData();
            };
            $scope.checkLoai = function (item, idx, evt) {
                if (item) {
                    var isSelected = $scope.listSelectedData.some(function (element, idx, array) {
                        return element.ID == item.Id;
                    });
                    if (item.Selected) {
                        if (!isSelected) {
                            $scope.listSelectedData.push(item);
                        }
                    } else {
                        if (isSelected) {
                            $scope.listSelectedData.splice(item, 1);
                        }
                    }
                } else {
                    angular.forEach($scope.data, function (v, k) {
                        $scope.data[k].Selected = $scope.all;
                        var isSelected = $scope.listSelectedData.some(function (element, index, array) {
                            if (!element) return false;
                            return element.ID == v.ID;
                        });
                        if ($scope.all) {
                            if (!isSelected) {
                                $scope.listSelectedData.push($scope.data[k]);
                            }
                        } else {
                            if (isSelected) {
                                $scope.listSelectedData.splice($scope.data[k], 1);
                            }
                        }
                    });
                }
            }
            $scope.save = function () {
                $uibModalInstance.close($scope.listSelectedData);
            };
            $scope.cancel = function () {
                $uibModalInstance.close();
            };
        }]);

    return app;
});
