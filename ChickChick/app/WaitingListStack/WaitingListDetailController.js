app.controller("WaitingListDetailController", ["$scope", "$http", "$location", "$routeParams", function ($scope, $http, $location, $routeParams) {
    console.log("WaitingListDetailController connected");

    $scope.students = {};
    $scope.room = {};
    $scope.roomId = $routeParams.id;

    var getRoom = function () {
        $http.get(`api/room/${$scope.roomId}`)
        .then(function (res) {
            $scope.room = res.data;
        });
    }

    getRoom();

    var getStudents = function () {
        $http.get(`api/student/waiting/${roomId}`)
            .then(function (res) {
                $scope.students = res.data;
            });
    }

    getStudents();

}
]);