app.controller("StudentFormUpdateController", ["$scope", "$http", "$location", "$routeParams", function ($scope, $http, $location, $routeParams) {
    console.log("StudentFormUpdateController connected");

    $scope.editing = true;
    $scope.studentId = $routeParams.id;
    $scope.rooms = [];
    $scope.student = {};

    $http.get('api/room')
        .then(function (res) {
            $scope.rooms = res.data;
        });

    var getStudent = function () {
        $http.get(`api/student/${$scope.studentId}`)
        .then(function (res) {
            var dt = new Date(res.data.Birthday);
            res.data.Birthday = dt;
            $scope.student = res.data;            
            console.log($scope.student);
        });
    }
    getStudent();

    $scope.saveStudent = function () {
        $http.put('/api/student', $scope.student)
            .then(function () {
                $location.path("/students");
                $scope.student = {};
            });
    }
}
]);