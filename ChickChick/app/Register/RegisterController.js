app.controller("RegisterController", ["$scope", "$http", "$location", "$rootScope", function ($scope, $http, $location, $rootScope) {
        console.log("Register controller connected");
        $scope.email = "";
        $scope.password = "";
        $scope.passwordConfirm = "";

        $scope.registerNew = function () {
            $http({
                    method: 'POST',
                    url: "api/Account/Register",
                    data: {
                        "Email": $scope.email,
                        "Password": $scope.password,
                        "ConfirmPassword": $scope.passwordConfirm
                    }
                })
                .then(function (result) {
                    console.log("result", result);
                    $location.path("/login");
                });
        }
    }
]);