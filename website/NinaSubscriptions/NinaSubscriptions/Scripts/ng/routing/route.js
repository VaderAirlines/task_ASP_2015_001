ninapp.config(['$routeProvider',
  function ($routeProvider) {
  	$routeProvider
	   .when('/mijnGegevens', {
	   	templateUrl: 'views/mijnGegevens.html',
	   	controller: 'mijnGegevensController',
	   })
	   .when('/beheerCursussen', {
	   	templateUrl: 'views/beheerCursussen.html',
	   	controller: 'beheerCursussenController',
	   })
	   .when('/bekijkInschrijvingen', {
	   	templateUrl: 'views/bekijkInschrijvingen.html',
	   	controller: 'bekijkInschrijvingenController',
	   })
	  .when('/bekijkAanbod', {
	  	templateUrl: 'views/bekijkAanbod.html',
	  	controller: 'bekijkAanbodController'
	  })
	  .when('/registerOrLogin', {
	  	templateUrl: 'views/registerOrLogin.html',
	  	controller: 'registerOrLoginController'
	  })
	  .when('/register', {
	  	templateUrl: 'views/register.html',
	  	controller: 'registerController'
	  })
	  .when('/subscribe/:courseID', {
	  	templateUrl: 'views/subscribe.html',
	  	controller: 'subscribeController'
	  })
	  .otherwise({
	  	redirectTo: '/bekijkAanbod'
	  })
  }]);

//ninapp.run(['$rootScope', '$location', '$cookieStore', '$http',
//    function ($rootScope, $location, $cookieStore, $http) {
//    	// keep user logged in after page refresh
//    	$rootScope.globals = $cookieStore.get('globals') || {};
//    	if ($rootScope.globals.currentUser) {
//    		$http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata;
//    	};

//    	$rootScope.$on('$locationChangeStart', function (event, next, current) {
//    		// redirect to login page if not logged in
//    		if ($location.path() !== '/bekijkAanbod' && !$rootScope.globals.currentUser) {
//    			$location.path('/bekijkAanbod');
//    		};
//    	});
//    }]);