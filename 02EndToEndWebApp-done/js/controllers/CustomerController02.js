// Check out http://angularjs.org services

function CustomerController02($scope, $timeout) {
    $scope.counter = 1;
    $scope.title = "Kund Controller";


    $scope.updateCounter = function () {
        $scope.counter++;

        $timeout(function () {
            $scope.updateCounter();
        }, 2000);
    };

    $scope.updateCounter();
}