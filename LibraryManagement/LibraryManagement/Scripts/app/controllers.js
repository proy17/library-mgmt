var libraryControllers = angular.module('libraryControllers', []);

libraryControllers.controller('BookSearchCtrl', ['$rootScope', '$scope', '$routeParams', '$http', '$location',
    function ($rootScope, $scope, $routeParams, $http, $location) {
        if (!$rootScope.authenticated) $location.path("/");

        var getAllBooks = function () {
            $http.get('/Search/GetAllResults', { params: {userEmail: $rootScope.userEmail, role: $rootScope.role}}).success(function (data) {
                $scope.books = data.bookMetadataModels;
                $scope.title = "All books";
            });
        };
        

        getAllBooks();
        $scope.orderProp = 'Name';

        $scope.borrow = function (bookId, userEmail) { 
            $http.get('/Lending/BorrowItem?bookMetadataId=' + bookId + '&userEmail=' + userEmail).
                success(function (data) {
                    if (!data.success) console.error("Not able to borrow the book!");
                    getAllBooks();
                    if ($rootScope.authenticated) $location.path("/books");
            });
        };

        $scope.return = function (bookId, userEmail) {
            $http.get('/Lending/ReturnItem?bookMetadataId=' + bookId + '&userEmail=' + userEmail).success(function (data) {
                if (!data.success) console.error("Not able to return the book!");
                getAllBooks();
                if ($rootScope.authenticated) $location.path("/books");
            });
        };
    }]);

libraryControllers.controller('OverdueBooksCtrl', ['$rootScope', '$scope', '$routeParams', '$http', '$location',
  function ($rootScope, $scope, $routeParams, $http, $location) {
      if (!$rootScope.authenticated) $location.path("/");

      $http.get('/Search/SearchOverdueBooks/', { params: { userEmail: $rootScope.userEmail, role: $rootScope.role } }).success(function (data) {
          $scope.books = data.bookMetadataViewModels;
          $scope.title = "Overdue books";
          if (!$rootScope.authenticated) $location.path("/");
      });
  }]);



libraryControllers.controller('LoginCtrl', ['$rootScope', '$scope', '$http', '$location', function ($rootScope, $scope, $http, $location) {
    var authenticate = function (credentials, callback) {

        var headers = credentials ? {
            authorization: "Basic "
                + btoa(credentials.username + ":" + credentials.password)
        } : {};

        $http.get('/Account/Login/', { headers: headers }).success(function (data) {
            if (data.userViewModel) {
                $rootScope.authenticated = true;
                $rootScope.role = data.userViewModel.RoleId;
                $rootScope.userEmail = data.userViewModel.UserName;
            } else {
                $rootScope.authenticated = false;
            }
            callback && callback();
        }).error(function () {
            $rootScope.authenticated = false;
            callback && callback();
        });

    };

    authenticate();
    $scope.credentials = {};
    $scope.login = function () {
        authenticate($scope.credentials, function () {
            if ($rootScope.authenticated) {
                $location.path("/books");
                $scope.error = false;
            } else {
                $location.path("/login");
                $scope.error = true;
            }
        });
    };

    $scope.logout = function () {
        $rootScope.authenticated = false;
        $rootScope.role = null;
        $rootScope.userEmail = null;
        $location.path("/");        
    };
}]);

libraryControllers.controller('RegisterCtrl', ['$rootScope', '$scope', '$http', '$location', function ($rootScope, $scope, $http, $location) {
    if (!$rootScope.authenticated) $location.path("/");

    $scope.formInfo = {};
    $scope.register = function () {
        console.log($scope.formInfo);
        var isValid = true;
        if (!$scope.formInfo.FirstName) {
            $scope.firstNameRequired = 'First Name Required';
            isValid = false;
        }

        if (!$scope.formInfo.LastName) {
            $scope.lastNameRequired = 'Last Name Required';
            isValid = false;
        }

        if (!$scope.formInfo.UserEmail) {
            $scope.emailRequired = 'Email Required';
            isValid = false;
        }

        if (!$scope.formInfo.Password) {
            $scope.passwordRequired = 'Password Required';
            isValid = false;
        }

        if (isValid) {
            $http.post('/Account/Register/', { formInfo: JSON.stringify($scope.formInfo) }).success(function (data) {
                console.debug(data);
                $rootScope.registered = data;
                $scope.formInfo = null;
            }).error(function () {
                $rootScope.error = true;
                $location.path("/register");
            });
        }
    };
}]);

libraryControllers.controller('AddBookCtrl', ['$rootScope', '$scope', '$http', '$location', function ($rootScope, $scope, $http, $location) {
    if (!$rootScope.authenticated)
    {
        $location.path("/");
    }
    $scope.formInfo = {};
    $scope.addbook = function () {
        console.log($scope.formInfo);
        var isValid = true;

        if (!$scope.formInfo.BookName) {
            $scope.bookNameRequired = 'Book name Required';
            isValid = false;
        }

        if (!$scope.formInfo.Author) {
            $scope.authorRequired = 'Author name Required';
            isValid = false;
        }

        if (!$scope.formInfo.Language) {
            $scope.languageRequired = 'Language Required';
            isValid = false;
        }

        if (!$scope.formInfo.Version) {
            $scope.versionRequired = 'Book version Required';
            isValid = false;
        }
        if (!$scope.formInfo.Publisher) {
            $scope.publisherRequired = 'Publisher  Required';
            isValid = false;
        }

        if (isValid) {
            $http.post('/Book/InsertBook/', { formInfo: JSON.stringify($scope.formInfo) }).success(function (data) {
                console.debug(data);
                $rootScope.bookAdded = data;
                $location.path("/books");
                $scope.formInfo = null;
            }).error(function () {
                $rootScope.error = true;
            });
        }        
    };
}]);

