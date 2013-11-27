// Check out http://angularjs.org services

function CustomerController03($scope, $http) {
    $scope.title = "Kund Controller";

    var customerListPromise = $http.get("/customers");

    customerListPromise.success(function (data) {
        $scope.customerList = data;
    });

    customerListPromise.error(function (object, error) {
        console.log("Ajaja, det gick åt pipan: " + error);
    });
   
}