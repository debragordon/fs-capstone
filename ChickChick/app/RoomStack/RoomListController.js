app.controller("RoomListController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    $scope.rooms = {};
    var getRooms = function () {
        $http.get('api/room')
        .then(function (res) {
            $scope.rooms = res.data;
        });
    }
    getRooms();

    $scope.deleteRoom = function (roomId) {
        $http.delete(`api/room/${roomId}`)
            .then(function (res) {
                getRooms();
            });
    };

    }
]);