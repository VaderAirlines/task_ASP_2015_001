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

        if ($scope.lf.isLoggedIn) { 
            $scope.lf.username = '';
            $scope.lf.password = '';

            $location.path($scope.pf.gotoPath); 
        } else {
            console.log("combinatie niet gevonden");
        };
    };

    $scope.register = function () {
        $location.path('/register');
    };
});