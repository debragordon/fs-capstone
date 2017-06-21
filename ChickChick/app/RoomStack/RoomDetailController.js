app.controller("RoomDetailController", ["$scope", "$http", "$location", "$routeParams", function ($scope, $http, $location, $routeParams) {
    $scope.room = {};
    $scope.roomId = $routeParams.id;

    var getRoom = function () {
        $http.get(`api/room/${$scope.roomId}`)
        .then(function (res) {
            $scope.room = res.data;
        });
    }
    getRoom();

    $scope.students = {};
    var getStudents = function () {
        $http.get(`api/student/enrolled/${$scope.roomId}`)
        .then(function (res) {
            $scope.students = res.data;
        });
    }
    getStudents();

    $scope.deleteRoom = function () {
        $scope.check = false;
        $http.delete(`api/room/${$scope.roomId}`)
            .then(function (res) {
                getRoom();
                $location.path("/classrooms");
            });
    };
    }
]);