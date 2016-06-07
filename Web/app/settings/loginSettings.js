(
	function(){
		angular.module('loginApp')
		.value('loginSettings', {
			loginUrl : 'http://localhost:3087/api/home/login',
		})
	}
)();