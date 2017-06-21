app.controller("StudentDetailController", ["$scope", "$http", "$location", "$routeParams", function ($scope, $http, $location, $routeParams) {
    $scope.student = {};
    $scope.studentId = $routeParams.id;
    
    var getStudent = function () {
        $http.get(`api/student/${$scope.studentId}`)
        .then(function (res) {
            $scope.student = res.data;
            $scope.student.calculatedAge = calculateAge(res.data.Birthday);
            $scope.student.formattedBirthdate = moment(res.data.Birthday).format("MMM Do YYYY");
            $scope.student.ageInMonths = moment(res.data.Birthday).fromNow().slice(0, -3);
        });
    }
    getStudent();

    var calculateAge = function calculateAge(birthdayToConvert) {
        var ageDifMs = Date.now() - new Date(birthdayToConvert).getTime();
        var ageDate = new Date(ageDifMs);
        return Math.abs(ageDate.getUTCFullYear() - 1970);
    }

    $scope.deleteStudent = function () {
        $scope.check = false;
        $http.delete(`api/student/${$scope.studentId}`)
        .then(function (res) {
            $location.path("/students");
        });
    };
}
]);