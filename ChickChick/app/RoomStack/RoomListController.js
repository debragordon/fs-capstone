app.controller("RoomListController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    console.log("RoomListController connected");
    $scope.rooms = {};
    $http.get('api/room')
        .then(function(res) {
            $scope.rooms = res.data;
        });
    }
]);