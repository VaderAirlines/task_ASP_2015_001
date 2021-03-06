﻿ninapp.controller('subscribeController', function ($scope, $routeParams, 
                                                   courseFactory, courseService,
                                                   loginFactory, loginService) {

    $scope.cf = courseFactory;
    $scope.lf = loginFactory;
    $scope.courseID = $routeParams.courseID;

    $scope.addExistingChild = false;
    $scope.newChildCreated = false;
    $scope.addNewChild = false;
    $scope.childToAdd = {};

    // get course on id
    courseService.getCourse($scope.courseID);

    // UI handlers
    $scope.subscribe = function(courseID, formData) {
        alert('not implemented yet!');
    };

    $scope.setAddNewChild = function() {
        $scope.addNewChild = true;
    };

    $scope.addChildToSubcribe = function() {
        lf.userData.childrenToSubscribe.push($scope.childToAdd);
    };

    $scope.createChildToAdd = function() {
        $timeout(function() { $scope.childToAdd = lf.userData.createChild(); }, 0);
        $scope.newChildCreated = true;
    };

});