app.controller("NavController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    $scope.checkAuth = function () {
        return sessionStorage.getItem("token") ? true : false;
    }
    $scope.logout = function () {
        sessionStorage.clear();
        $location.path("/login");
    }
}
]);