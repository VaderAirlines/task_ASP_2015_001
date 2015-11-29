ninapp.controller('subscribeController', function ($scope, $routeParams) {
    $scope.description = 'you can subscribe here';
    $scope.courseID = $routeParams.courseID;

    (function () {
        alert($scope.courseID);
    })();
});