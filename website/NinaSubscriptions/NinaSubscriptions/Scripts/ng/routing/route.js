ninapp.config(['$routeProvider',
  function($routeProvider) {
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