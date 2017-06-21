app.controller("RegisterController", ["$scope", "$http", "$location", "$rootScope", function ($scope, $http, $location, $rootScope) {
        $scope.newUser = {};
        $scope.registerNew = function () {
            $http({
                    method: 'POST',
                    url: "api/Account/Register",
                    data: {
                        "Email": $scope.newUser.email,
                        "Location": $scope.newUser.location,
                        "Password": $scope.newUser.password,
                        "ConfirmPassword": $scope.newUser.passwordConfirm
                    }
                })
                .then(function (result) {
                    $location.path("/login");
                });
        }
    }
]);