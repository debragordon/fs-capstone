app.controller("DashboardController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    console.log("DashboardController connected");

    $scope.rooms = {};
    $scope.enrolledStudents = {};
    $scope.waitingStudents = {};

    $http.get('api/room')
        .then(function (res) {
            $scope.rooms = res.data;
        });

    $http.get('api/student/enrolled')
        .then(function (res) {
            $scope.enrolledStudents = res.data;
        });

    $http.get('api/student/waiting')
    .then(function (res) {
        $scope.waitingStudents = res.data;
    });

    $scope.totalRoomsCount = function() {
        var roomCount = 0;
        for (var i = 0; i < $scope.rooms.length; i++) {
            roomCount ++;
        }
        return roomCount; 
    }
    
    $scope.totalEnrolledCount = function () {
        var enrolledCount = 0;
        for (var i = 0; i < $scope.enrolledStudents.length; i++) {
            enrolledCount++;
        }
        return enrolledCount;
    }

    $scope.totalWaitingCount = function () {
        var waitingCount = 0;
        for (var i = 0; i < $scope.waitingStudents.length; i++) {
            waitingCount++;
        }
        return waitingCount;
    }
}
]);