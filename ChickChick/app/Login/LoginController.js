app.controller("LoginController", ["$scope", "$http", "$location", function ($scope, $http, $location) {

    console.log("LoginController connected");

    $scope.email = "";
    $scope.password = "";
    $scope.login = function () {
        $http({
                method: 'POST',
                url: "/Token",
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                transformRequest: function (obj) {
                    var str = [];
                    for (var p in obj)
                        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                    return str.join("&");
                },
                data: { grant_type: "password", userName: $scope.email, password: $scope.password }
            })
            .then(function (result) {
                console.log("result", result);

                sessionStorage.setItem('token', result.data.access_token);

                $http.defaults.headers.common['Authorization'] = `bearer ${result.data.access_token}`;

                $location.path("/home");
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