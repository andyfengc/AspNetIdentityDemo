(function(){
	angular.module('securityApp')
	.value('appSettings', {
		indexUrl: 'http://localhost:47048/api/index',
		loginUrl : 'http://localhost:3087/api/home/login',
		secureUrl : 'http://localhost:3087/api/home/secure'
	})
})();