ninapp.controller('bekijkAanbodController',function($scope,$location,$timeout,
                                                     pathFactory,
                                                     loginService,loginFactory,
                                                     courseService,courseFactory) {

    // services/factories
    $scope.ls=loginService;
    $scope.lf=loginFactory;
    $scope.cs=courseService;
    $scope.cf=courseFactory;
    $scope.pf=pathFactory;

    // initializers
    $scope.$on("$routeChangeSuccess",function($currentRoute,$previousRoute) {
        $scope.ls.checkLoginSession();
    });

    $scope.cs.getAllCourses();

    // scopers       

    // UI handlers
    $scope.subscribe=function(course) {
        $scope.pf.gotoPath=getSubscribePath(course.id);
        $location.path($scope.lf.isLoggedIn?$scope.pf.gotoPath:'/registerOrLogin');
    };


    // helpers
    function getSubscribePath(courseID) {
        return '/subscribe/'+courseID;
    };
});