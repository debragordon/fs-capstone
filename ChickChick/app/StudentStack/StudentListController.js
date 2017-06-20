﻿app.controller("StudentListController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    console.log("StudentListController connected");

    $scope.students = {};

    var getStudents = function () {
        $http.get('api/student/enrolled')
            .then(function (res) {
                $scope.students = res.data;
            });
    }

    getStudents();

    $scope.rooms = {};

    var getRooms = function () {
        $http.get('api/room')
        .then(function (res) {
            $scope.rooms = res.data;
        });
    }

    getRooms();

}
]);