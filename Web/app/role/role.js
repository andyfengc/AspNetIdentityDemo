(function () {
	'use strict';

	angular.module('securityApp.role', ['ngRoute'])

	.config(['$routeProvider', function ($routeProvider) {
		$routeProvider.when('/role', {
			templateUrl: 'role/role.html',
			controller: 'RoleController'
		});
}])
 
	.controller('RoleController', ['$scope', function ($scope) {
$scope.name = "Role";
}]);
})();
