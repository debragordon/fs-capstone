var app = angular.module("DuckDuckApp", ["ngRoute"]);

var isAuth = function () {
    return sessionStorage.getItem("token") ? true : false;
};

app.run(($rootScope, $location, $http) => {

    $rootScope.$on('$routeChangeStart', function (event, currRoute, prevRoute) {
        var logged = isAuth();
        var appTo;
        if (currRoute.originalPath) {
            appTo = currRoute.originalPath.indexOf('/login') !== -1 || currRoute.originalPath.indexOf('/register') !== -1;
        }
        if (!appTo && !logged) {
            event.preventDefault();
            $location.path('/login');
        }
    });

    var token = sessionStorage.getItem('token');

    if (token)
        $http.defaults.headers.common['Authorization'] = `bearer ${token}`;
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
            .when("/classrooms/form",
                {
                    templateUrl: "app/RoomStack/RoomForm.html",
                    controller: "RoomFormController",
                    resolve: { isAuth }
                })
            .when("/classrooms/update/:id",
                {
                    templateUrl: "app/RoomStack/RoomForm.html",
                    controller: "RoomFormUpdateController",
                    resolve: { isAuth }
                })
            .when("/classrooms/:id",
                {
                    templateUrl: "app/RoomStack/RoomDetail.html",
                    controller: "RoomDetailController",
                    resolve: { isAuth }
                })
            .when("/students",
                {
                    templateUrl: "app/StudentStack/StudentList.html",
                    controller: "StudentListController",
                    resolve: { isAuth }
                })
            .when("/students/form",
                {
                    templateUrl: "app/StudentStack/StudentForm.html",
                    controller: "StudentFormController",
                    resolve: { isAuth }
                })
            .when("/students/update/:id",
                {
                    templateUrl: "app/StudentStack/StudentForm.html",
                    controller: "StudentFormUpdateController",
                    resolve: { isAuth }
                })
            .when("/students/:id",
                {
                    templateUrl: "app/StudentStack/StudentDetail.html",
                    controller: "StudentDetailController",
                    resolve: { isAuth }
                })
           .when("/waitinglists",
                {
                    templateUrl: "app/WaitingListStack/WaitingListAll.html",
                    controller: "WaitingListAllController",
                    resolve: { isAuth }
                })
            .when("/waitinglists/:id",
                {
                    templateUrl: "app/WaitingListStack/WaitingListDetail.html",
                    controller: "WaitingListDetailController",
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