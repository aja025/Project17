var myApp = angular.module("myApp", [ "ui.router", "ngResource" ]);
myApp.controller("MainController", MainController);
myApp.controller("EmployeeController", EmployeeController);
myApp.controller("AlbumController", AlbumController);
myApp.service("$albumService", AlbumService);
myApp.controller("GenreController", GenreController);
myApp.service("$genreService", GenreService);
myApp.controller("ArtistController", ArtistController);
myApp.service("$employeeService", EmployeeService);
myApp.service("$artistService", ArtistService);


myApp.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
    $stateProvider
        .state("home", {
            url: "/",
            templateUrl: "/ngApp/views/main.html",
            controller: MainController,
            controllerAs: "controller"
        }).state("employees", {
            url: "/employees",
            templateUrl: "/ngApp/views/employees.html",
            controller: EmployeeController,
            controllerAs: "controller"
        }).state("albums", {
            url: "/albums",
            templateUrl: "/ngApp/views/albums.html",
            controller: AlbumController,
            controllerAs: "controller"
        }).state("genres", {
            url: "/genres",
            templateUrl: "/ngApp/views/genre.html",
            controller: GenreController,
            controllerAs: "controller"
        }).state("artists", {
            url: "/artists",
            templateUrl: "/ngApp/views/artists.html",
            controller: ArtistController,
            controllerAs: "controller"
        });

    // Handle request for non-existent route
    $urlRouterProvider.otherwise("/notFound");

    // Enable HTML5 navigation
    $locationProvider.html5Mode(true);
});