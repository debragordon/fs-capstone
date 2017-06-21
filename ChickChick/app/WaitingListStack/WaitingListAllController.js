app.controller("WaitingListAllController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    console.log("WaitingListAllController connected");

    $scope.students = [];
    $scope.sortProperty = "FullName";

    var getStudents = function () {
        $http.get('api/student/waiting')
            .then(function (res) {
                $scope.students = res.data;
            });
    }

    getStudents();

    $scope.clear = function () {
        document.getElementById("search").value = "";
        $scope.searchText = "";
    };

}
]);