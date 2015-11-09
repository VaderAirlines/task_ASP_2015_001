ninapp.config(['$routeProvider',
  function($routeProvider) {
    $routeProvider
       .when('bekijk-aanbod', {
        templateUrl: 'views/bekijkAanbod.html',
        controller: 'bekijkAanbodController',
      })
      .otherwise({
          templateUrl: 'Views/bekijkAanbod.html',
          controller: 'bekijkAanbodController'
      })
}]);