app.controller("StudentFormController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    console.log("StudentFormController connected");

    $scope.editing = false;

    $scope.rooms = [];
    $http.get('api/room')
        .then(function (res) {
            $scope.rooms = res.data;
        });

    $scope.student = {};

    $scope.addStudent = function () {
        $http.post('/api/student', $scope.student)
            .then(function () {
                console.log("new student", $scope.student);
                $location.path("/students");
                $scope.student = {};
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