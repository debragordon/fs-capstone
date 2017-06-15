app.controller("WaitingListAllController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    console.log("WaitingListAllController connected");

    $scope.students = {};

    var getStudents = function () {
        $http.get('api/studentsOnAllWaitingLists') ////////
            .then(function (res) {
                $scope.students = res.data;
            });
    }

    getStudents();

}
]);