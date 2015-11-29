ninapp.controller('registerOrLoginController', function($scope, $location,
                                                        pathFactory,
                                                        loginFactory, loginService) {
    // services/factories
    $scope.lf = loginFactory;
    $scope.ls = loginService;
    $scope.pf = pathFactory;


    // scopers
    $scope.title = 'Aanmelden (of registeren)';


    // UI handlers
    $scope.login = function () {
        $scope.ls.getLoginStatus();
        alert($scope.pf.gotoPath);
        if ($scope.lf.isLoggedIn) { $location.path($scope.pf.gotoPath); };
    };

    $scope.register = function () {
        $location.path('/register');
    };
});