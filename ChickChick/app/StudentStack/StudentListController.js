app.controller("StudentListController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    console.log("StudentListController connected");

    $scope.students = {};

    var getStudents = function () {
        $http.get('api/studentsInCenter')
            .then(function (res) {
                $scope.students = res.data;
            });
    }

    getStudents();

    $scope.deleteStudent = function (studentId) {
        $http.delete(`api/student/${studentId}`)
            .then(function (res) {
                getStudents();
            });
    };

}
]);