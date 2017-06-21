app.controller("StudentFormController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    console.log("StudentFormController connected");

    $scope.editing = false;

    $scope.rooms = [];
    $http.get('api/room')
        .then(function (res) {
            $scope.rooms = res.data;
        });

    $scope.student = {};

    $scope.addStudent = function () {
        console.log("new student", $scope.student);

        $http.post('/api/student', $scope.student)
            .then(function () {
                $location.path("/students");
                $scope.student = {};
            });
    }
}
]);