app.controller("RoomDetailController", ["$scope", "$http", "$location", "$routeParams", function ($scope, $http, $location, $routeParams) {
    console.log("RoomDetailController connected");

    $scope.room = {};
    $scope.roomId = $routeParams.id;

    var getRoom = function () {
        $http.get(`api/room/${$scope.roomId}`)
        .then(function (res) {
            $scope.room = res.data;
            console.log($scope.room);
        });
    }

    getRoom();

    $scope.students = {};

    var getStudents = function () {
        $http.get(`api/student/room/${$scope.roomId}`)
        .then(function (res) {
            $scope.students = res.data;
        });
    }

    getStudents();

    $scope.deleteRoom = function () {
        $http.delete(`api/room/${$scope.roomId}`)
            .then(function (res) {
                getRoom();
            });
    };
    }
]);