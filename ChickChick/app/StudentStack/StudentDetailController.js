app.controller("StudentDetailController", ["$scope", "$http", "$location", "$routeParams", function ($scope, $http, $location, $routeParams) {
    console.log("StudentDetailController connected");

    $scope.student = {};
    $scope.studentId = $routeParams.id;
    
    var getStudent = function () {
        $http.get(`api/student/${$scope.studentId}`)
        .then(function (res) {
            $scope.student = res.data;
            $scope.student.calculatedAge = calculateAge(res.data.Birthday);
        });
    }

    getStudent();

    var calculateAge = function calculateAge(birthdayToConvert) {
        var ageDifMs = Date.now() - new Date(birthdayToConvert).getTime();
        var ageDate = new Date(ageDifMs);
        return Math.abs(ageDate.getUTCFullYear() - 1970);
    }

    $scope.deleteStudent = function () {
        $http.delete(`api/student/${$scope.studentId}`)
            .then(function (res) {
                getStudent();
                $location.path("/students");
            });
    };
}
]);