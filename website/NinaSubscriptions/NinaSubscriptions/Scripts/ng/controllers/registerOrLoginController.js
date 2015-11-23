ninapp.controller('registerOrLoginController', function($scope) {
    $scope.title = 'Aanmelden (of registeren)';

    $scope.user = {
        username: '',
        password: ''
    };

    $scope.login = function () {
        alert('log maar in ' + $scope.user.username + ' met als paswoord ' + $scope.user.password + '!');
    };

    $scope.register = function () {
        alert('registreer maar ' + $scope.user.username + ' met als paswoord ' + $scope.user.password + '!');
    };
});