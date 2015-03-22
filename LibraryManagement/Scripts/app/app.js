var libraryApp = angular.module('libraryApp', [
  'ngRoute',
  'libraryControllers'
]);

libraryApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/books', {
            templateUrl: '/Search/GetAllResults',
            controller: 'BookSearchCtrl'
        }).
        when('/books/:bookName', {
            templateUrl: '/Search/BookDetailsTmpl',
            controller: 'BookDetailsCtrl'
        }).
        when('/borrow/:bookId/:userEmail', {
            templateUrl: '/Search/BookDetailsTmpl',
            controller: 'BookBorrowCtrl'
        }).
        when('books/overdue', {
            templateUrl: '/Search/BookSearchTmpl',
            controller: 'OverdueBooksCtrl'
        }).
        otherwise({
            redirectTo: '/books'
        });
  }]);