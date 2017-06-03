﻿var app = angular.module("ChickChickApp", ["ngRoute"]);

var isAuth = function () {
    return sessionStorage.getItem("token") ? true : false;
};

app.run(($rootScope, $location) => {

    $rootScope.$on('$routeChangeStart', function (event, currRoute, prevRoute) {
        var logged = isAuth();
        var appTo;
        if (currRoute.originalPath) {
            appTo = currRoute.originalPath.indexOf('/login') !== -1;
        }
        if (!appTo && !logged) {
            event.preventDefault();
            $location.path('/login');
        }
    });
});


app.config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {
        $routeProvider
            .when("/login",
                {
                    templateUrl: "app/Login/Login.html",
                    controller: "LoginController"
                })
            .when("/home",
                {
                    templateUrl: "app/Home/Dashboard.html",
                    controller: "DashboardController",
                    resolve: { isAuth }
                })
            .when("/classrooms",
                {
                    templateUrl: "app/RoomStack/RoomList.html",
                    controller: "RoomListController",
                    resolve: { isAuth }
                })
            .when("/classrooms/{id}",
                {
                    templateUrl: "app/RoomStack/RoomDetail.html",
                    controller: "RoomDetailController",
                    resolve: { isAuth }
                })
            .when("/classrooms/form",
                {
                    templateUrl: "app/RoomStack/RoomForm.html",
                    controller: "RoomFormController",
                    resolve: { isAuth }
                })
            .when("/students",
                {
                    templateUrl: "app/StudentStack/StudentList.html",
                    controller: "RoomListController",
                    resolve: { isAuth }
                })
            .when("/students/{id}",
                {
                    templateUrl: "app/StudentStack/StudentDetail.html",
                    controller: "RoomDetailController",
                    resolve: { isAuth }
                })
            .when("/students/form",
                {
                    templateUrl: "app/StudentStack/StudentForm.html",
                    controller: "StudentFormController",
                    resolve: { isAuth }
                })
           .when("/waitinglists",
                {
                    templateUrl: "app/WaitingListStack/WaitingListAll.html",
                    controller: "WaitingListAllController",
                    resolve: { isAuth }
                })
            .when("/waitinglists/{id}",
                {
                    templateUrl: "app/WaitingListStack/WaitingListDetail.html",
                    controller: "WaitingListDetailController",
                    resolve: { isAuth }
                })
            .when("/waitinglists/form",
                {
                    templateUrl: "app/WaitingListStack/WaitingListForm.html",
                    controller: "WaitingListFormController",
                    resolve: { isAuth }
                })
            .when("/register",
                {
                    templateUrl: "app/Register/Register.html",
                    controller: "RegisterController"
                })
            .otherwise({
                redirectTo: '/login'
            });
        $locationProvider.html5Mode(true);
    }
]);