var libraryApp = angular.module('libraryApp', [
  'ngRoute',
  'libraryControllers'
]);

libraryApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/books', {
            templateUrl: '/Template/BookSearchTmpl',
            controller: 'BookSearchCtrl'
        }).
        when('/books/overdue', {
            templateUrl: '/Template/BookSearchTmpl',
            controller: 'OverdueBooksCtrl'
        }).
        when('/login', {
           templateUrl: '/Template/LoginTmpl',
           controller: 'LoginCtrl'
        }).        
        when('/register', {
          templateUrl: '/Template/RegisterTmpl',
          controller: 'RegisterCtrl'
        }).
        when('/book/addbook', {
            templateUrl: '/Template/AddBookTmpl',
            controller: 'AddBookCtrl'
        }).
        otherwise({
            redirectTo: '/login'
        });      
  }]);