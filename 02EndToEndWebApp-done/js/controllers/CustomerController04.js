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
        alert($scope.name);
    };

});