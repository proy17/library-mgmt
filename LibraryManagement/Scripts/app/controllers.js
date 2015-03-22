var libraryControllers = angular.module('libraryControllers', []);

libraryControllers.controller('BookSearchCtrl', ['$scope', '$routeParams', '$http',
    function ($scope, $routeParams, $http) {        
        $scope.orderProp = 'Name';
    }]);

libraryControllers.controller('BookBorrowCtrl', ['$scope', '$routeParams', '$http',
  function ($scope, $routeParams, $http) {
      $http.get('/Lending/BorrowItem?id=' + $routeParams.bookId + '&userEmail=' + $routeParams.userEmail).success(function (data) {
          $scope.success = data.success;
      });
  }]); 

libraryControllers.controller('BookDetailsCtrl', ['$scope', '$routeParams', '$http',
  function ($scope, $routeParams, $http) {
      $http.get('/Search/GetResultsByName/' + $routeParams.bookName).success(function (data) {
          $scope.book = data.bookMetadataViewModel;
          $("#myModal").modal('show');
      });      
  }]);

libraryControllers.controller('OverdueBooksCtrl', ['$scope', '$routeParams', '$http',
  function ($scope, $routeParams, $http) {
      $http.get('/Search/SearchOverdueBooks/').success(function (data) {
          $scope.books = data.bookMetadataViewModels;
      });
  }]); 