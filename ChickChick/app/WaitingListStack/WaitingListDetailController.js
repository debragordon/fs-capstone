app.controller("WaitingListDetailController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    console.log("WaitingListDetailController connected");

    $scope.students = {};

    var getStudents = function () {
        $http.get('api/studentsOnSingleWaitingList') ////////
            .then(function (res) {
                $scope.students = res.data;
            });
    }

    getStudents();

}
]);