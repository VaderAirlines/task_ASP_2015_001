ninapp.controller('registerController', function($scope) {
    $scope.title = 'Registratieformulier';

    $scope.user = {
        username: '',
        name: '',
        firstname: '',
        email: '',
        phone: '',
        showPassword: false,
        password: '',
        repeatPassword: ''
    };

    $scope.register = function() {
        alert('U bent geregistreerd, ' + $scope.user.username);
    };

    // TODO: create watcher for checkbox value change
});