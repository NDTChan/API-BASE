define(['angular'], function (angular) {
    var app = angular.module('authModule', ['configModule']);

	app.service('userService',['localStorageService',function(localStorageService){
		var fac = {};
		fac.CurrentUser = null;
		fac.SetCurrentUser = function (user) {
			fac.CurrentUser = user;
			localStorageService.set('authorizationData', user);
		};
		fac.GetCurrentUser = function () {
		    fac.CurrentUser = localStorageService.get('authorizationData');
			return fac.CurrentUser;
		};
		return fac;
	}]);
	
	app.service('accountService', ['configService', '$http', '$q', 'localStorageService', '$state', 'userService', function (configService, $http, $q, localStorageService, $state, userService) {
		var result={
			login:function(user){
				var obj = {'username':user.username,'password':user.password, 'grant_type': 'password' };
				Object.toparams = function ObjectsToParams(obj) {
                var p = [];
                for (var key in obj) {
                    p.push(key + '=' + encodeURIComponent(obj[key]));
                }
                return p.join('&');
				}
				var defer = $q.defer();
				$http({ method: 'post', url: configService.apiServiceBaseUri + "/token", data: Object.toparams(obj), headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).then(function (response) {
					if(response && response.status===200 && response.data){
						userService.SetCurrentUser(response.data);
						$state.go('home');
					}
					defer.resolve(response);
				}, function (response) {
					defer.reject(response);
				});
            return defer.promise;
			},
			logout:function() {
			    localStorageService.cookie.clearAll();
			    $state.go('login');
			}
		};
		return result;
	}]);
	
    app.controller('loginCrtl', ['$scope', '$location', '$http','localStorageService','accountService','$state', function ($scope, $location,$http,localStorageService,accountService,$state) {
		$scope.user={username:'',password:'',cookie:false,grant_type:'password'};
		$scope.login=function(){
			$scope.msg=null;
			accountService.login($scope.user).then(function(response){
			},function(response){
			    if (response && response.data && response.data.error) {
			        $scope.msg = response.data.error_description;
				}
				$scope.user={username:'',password:'',cookie:false,grant_type:'password'};
				$scope.focusUsername=true;
			});
		};
	}]);

    return app;
});

