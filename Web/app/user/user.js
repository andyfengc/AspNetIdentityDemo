(function () {
	'use strict';
	angular.module('securityApp.user', ['ngRoute'])

	.config(['$routeProvider', function ($routeProvider) {
		$routeProvider.when('/user', {
			templateUrl: 'user/user.html',
			controller: 'userCtroller'
		});
}])

	.controller('userCtroller', ['$scope','$http', 'appSettings', function ($scope, $http, appSettings) {
		$scope.indexUrl = appSettings.indexUrl;
		$http.get(appSettings.indexUrl)
		.then(function(){
			alert('login succeeded');
		}, function(response){
			if (response.data == null){
				alert("failed to connect");
			}
			else{
				alert('login failed: ' + response.data.Message);
			}
			
		});
}]);
})();
