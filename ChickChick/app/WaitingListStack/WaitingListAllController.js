app.controller("WaitingListALLController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    console.log("WaitingListALLController connected");

    $scope.students = {};

    var getStudents = function () {
        $http.get('api/studentsInCenter') ////////
            .then(function (res) {
                $scope.students = res.data;
            });
    }

    getStudents();

}
]);