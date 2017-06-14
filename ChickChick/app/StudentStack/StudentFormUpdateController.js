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

        //document.querySelector(".mdl-textfield").MaterialTextfield.change();
    });

}
]);