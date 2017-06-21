app.controller("RoomFormUpdateController", ["$scope", "$http", "$location", "$routeParams", function ($scope, $http, $location, $routeParams) {
    console.log("RoomFormUpdareController connected");

    $scope.editing = true;
    $scope.roomId = $routeParams.id;
    $scope.room = {};

    var getRoom = function () {
        $http.get(`api/room/${$scope.roomId}`)
        .then(function (res) {
            $scope.room = res.data;
            console.log($scope.room);
        });
    }

    getRoom();

    $scope.saveRoom = function () {
        $http.put('/api/room', $scope.room)
            .then(function () {
                $location.path("/classrooms");
                $scope.room = {};
            });
    }
}
]);