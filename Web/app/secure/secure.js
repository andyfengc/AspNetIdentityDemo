(function () {
	'use strict';

	angular.module('securityApp.secure', ['ngRoute'])

	.config(['$routeProvider', function ($routeProvider) {
		$routeProvider.when('/secure', {
			templateUrl: 'secure/secure.html',
			controller: 'SecureController'
		});
}])
 
	.controller('SecureController', ['$scope', '$http', 'appSettings', function ($scope, $http, appSettings) {
		alert(appSettings.secureUrl);
		$http.get(appSettings.secureUrl).then(
			function(response){
				alert("authrize succeed " + response.data);
			}, function(response){
				alert("authorize failed " + response.data.Message);
			})
}]);
})();
