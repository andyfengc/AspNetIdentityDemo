'use strict';

// Declare app level module which depends on views, and components
angular.module('securityApp', [
	'ngRoute',
	'securityApp.user',
	'securityApp.role',
	'securityApp.secure',
]).
config(['$locationProvider', '$routeProvider', function ($locationProvider, $routeProvider) {
	$locationProvider.hashPrefix('!');

	//$routeProvider.otherwise({redirectTo: '/view1'});
}]);