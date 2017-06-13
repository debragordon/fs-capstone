app.controller("StudentDetailController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    console.log("StudentDetailController connected");

    $scope.student = {};

    var getStudent = function (studentId) {
        $http.get('api/student')
        .then(function (res) {
            $scope.student = res.data;
        });
    }

    getStudent();

    $scope.deleteStudent = function (studentId) {
        $http.delete(`api/student/${studentId}`)
            .then(function (res) {
                getStudent();
            });
    };
}
]);