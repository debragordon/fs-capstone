app.controller("RoomFormController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
        $scope.room = {};
        $scope.editing = false;
        $scope.addRoom = function () {
            $http.post('/api/room', $scope.room)
                .then(function() {
                    $location.path("/classrooms");
                    $scope.room = {};
                });
        }
    }
]);