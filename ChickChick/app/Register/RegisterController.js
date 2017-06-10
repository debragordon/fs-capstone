app.controller("RegisterController", ["$scope", "$http", "$location", "$rootScope", function ($scope, $http, $location, $rootScope) {
        console.log("Register controller connected");
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
                    console.log("result", result);
                    $location.path("/login");
                });
        }

        $(window, document, undefined).ready(function () {

            $('input').blur(function () {
                var $this = $(this);
                if ($this.val())
                    $this.addClass('used');
                else
                    $this.removeClass('used');
            });

            var $ripples = $('.ripples');

            $ripples.on('click.Ripples', function (e) {

                var $this = $(this);
                var $offset = $this.parent().offset();
                var $circle = $this.find('.ripplesCircle');

                var x = e.pageX - $offset.left;
                var y = e.pageY - $offset.top;

                $circle.css({
                    top: y + 'px',
                    left: x + 'px'
                });

                $this.addClass('is-active');

            });

            $ripples.on('animationend webkitAnimationEnd mozAnimationEnd oanimationend MSAnimationEnd', function (e) {
                $(this).removeClass('is-active');
            });

        });
    }
]);