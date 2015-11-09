ninapp.config(function($routeProvider, $locationProvider) {
  $routeProvider
   .when('/home', {
    templateUrl: '../book.html',
    controller: 'BookController',
  })
  .when('/Book/:bookId/ch/:chapterId', {
    templateUrl: 'chapter.html',
    controller: 'ChapterController'
  });
});