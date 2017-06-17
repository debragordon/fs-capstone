app.controller("DashboardController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    console.log("DashboardController connected");

    $scope.rooms = {};
    $scope.enrolledStudents = {};
    $scope.waitingStudents = {};

    $http.get('api/room')
        .then(function (res) {
            $scope.rooms = res.data;
            $scope.totalRooms = $scope.rooms.length;
        });

    $http.get('api/student/enrolled')
        .then(function (res) {
            $scope.enrolledStudents = res.data;
            $scope.totalEnrolled = $scope.enrolledStudents.length;

        });

    $http.get('api/student/waiting')
    .then(function (res) {
        $scope.waitingStudents = res.data;
        $scope.totalWaiting = $scope.waitingStudents.length;
    });

}
]);