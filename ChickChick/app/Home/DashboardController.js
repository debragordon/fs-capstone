app.controller("DashboardController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    $scope.rooms = {};
    $scope.enrolledStudents = {};
    $scope.waitingStudents = {};

    var getAllRooms = function(){
        $http.get('api/room')
        .then(function (res) {
            $scope.rooms = res.data;
            $scope.totalRooms = $scope.rooms.length;
            getAllEnrolledStudents();
        });
    }
    getAllRooms();

    var getAllEnrolledStudents = function () {
        $http.get('api/student/enrolled')
        .then(function (res) {
            $scope.enrolledStudents = res.data;
            $scope.totalEnrolled = $scope.enrolledStudents.length;
            getEnrolledPercentage();
        });
    }

    $http.get('api/student/waiting')
    .then(function (res) {
        $scope.waitingStudents = res.data;
        $scope.totalWaiting = $scope.waitingStudents.length;
    });

   var getEnrolledPercentage = function () {
       var occupancy = 0;
        for (var i = 0; i < $scope.rooms.length; i++) {
            var temp = parseInt($scope.rooms[i].OccupancyMax);
            occupancy += temp;
        }
        $scope.totalEnrolledPercentage = Math.round($scope.totalEnrolled / occupancy * 100);
        calculateTotalMonthlyEnrollmentAmount();
   }

   var calculateTotalMonthlyEnrollmentAmount = function () {
       var total = 0;
       for (var i = 0; i < $scope.enrolledStudents.length; i++) {
           var oneRate = parseInt($scope.enrolledStudents[i].Rate);
            total += oneRate;
       }
       $scope.rateTotal = total;
       $scope.rateTotalYear = total * 52;
   }
}
]);