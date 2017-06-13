app.controller("RoomDetailController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    console.log("RoomDetailController connected");

    $scope.room = {};

    var getRoom = function (roomId) {
        $http.get('api/room')
        .then(function (res) {
            $scope.room = res.data;
        });
    }

    $scope.students = {};

    var getStudents = function (roomId) {
        $http.get('api/student')
        .then(function (res) {
            $scope.students = res.data;
        });
    }

    getStudents();

    $scope.deleteRoom = function (roomId) {
        $http.delete(`api/room/${roomId}`)
            .then(function (res) {
                getRoom();
            });
    };
    }
]);