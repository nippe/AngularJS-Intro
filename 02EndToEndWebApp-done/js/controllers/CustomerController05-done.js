var demoApp = angular.module('demoApp', []);

demoApp.factory("customerService", function ($http) {
    return {
        allCustomers: function () {
            return $http.get("/customers");
        },
        createNewCustomer: function (customerToCreate) {
            return $http.post("/customers/create", customerToCreate);
        },
        getCustomerCount: function () {
            return $http.get("/customers/count");
        }
    };
});

demoApp.controller("CustomerListCtrl", function ($scope, customerService) {
    $scope.title = "Kund Controller";

    var customerListPromise = customerService.allCustomers();

    customerListPromise.success(function (data) {
        $scope.customerList = data;
    });

    customerListPromise.error(function (object, error) {
        console.log("Ajaja, det gick åt pipan: " + error);
    });

});

demoApp.controller("CustomerCreateCtrl", function ($scope, customerService) {

    $scope.createNewCustomer = function () {
        var customer = {}
        customer.Name = $scope.name;
        customer.CustomerId = $scope.customerId;
        customer.StreetAddress = $scope.address;

        var promise = customerService.createNewCustomer(customer);
        promise.success(function (data) {
            $scope.name = $scope.customerId = $scope.address = "";
        });
    };
});


demoApp.controller("CustomerCountCtrl", function ($scope, $timeout, customerService) {
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