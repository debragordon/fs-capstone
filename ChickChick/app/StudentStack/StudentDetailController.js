app.controller("StudentDetailController", ["$scope", "$http", "$location", "$routeParams", function ($scope, $http, $location, $routeParams) {
    console.log("StudentDetailController connected");

    $scope.student = {};
    $scope.studentId = $routeParams.id;

    var getStudent = function () {
        $http.get(`api/student/${$scope.studentId}`)
        .then(function (res) {
            $scope.student = res.data;
        });
    }

    getStudent();

    $scope.deleteStudent = function () {
        $http.delete(`api/student/${$scope.studentId}`)
            .then(function (res) {
                getStudent();
                $location.path("/students");
            });
    };
}
]);