var demoApp = angular.module('demoApp', []);



demoApp.controller("CustomerListCtrl", function ($scope, $http) {
    $scope.title = "Kund Controller";

    var customerListPromise = $http.get("/customers");

    customerListPromise.success(function (data) {
        $scope.customerList = data;
    });

    customerListPromise.error(function (object, error) {
        console.log("Ajaja, det gick åt pipan: " + error);
    });

});

demoApp.controller("CustomerCreateCtrl", function ($scope, $http) {

    $scope.createNewCustomer = function () {
        var customer = {}
        customer.Name = $scope.name;
        customer.CustomerId = $scope.customerId;
        customer.StreetAddress = $scope.address;

        var promise = $http.post("/customers/create", customer);
        promise.success(function (data) {
            $scope.name = $scope.customerId = $scope.address = "";
        });
    };
});


demoApp.controller("CustomerCountCtrl", function ($scope, $timeout, $http) {
    $scope.updateCustomerCount = function () {
        var promise = customerService.getCustomerCount();

        promise.success(function (data) {
            $scope.numberOfCustomers = data;

            $timeout(function () {
                $scope.updateCustomerCount();
            }, 2000);
        });
    };

    $scope.updateCustomerCount();
});