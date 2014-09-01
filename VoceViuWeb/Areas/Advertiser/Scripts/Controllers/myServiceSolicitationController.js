(function () {

    app.controller("myServiceSolicitationController", ["$scope", "ServiceSolicitationResource", function ($scope, ServiceSolicitationResource) {
        $scope = $scope || {};

        $scope.pendingRequests = 0;
        $scope.serviceSolicitations = [];

        _loadServiceSolicitations = function () {
            $scope.pendingRequests++;
            ServiceSolicitationResource.getPendingApproval(
                {},
                function (response) {
                    $scope.pendingRequests--;
                    $scope.serviceSolicitations = response;
                }, function (response) {
                    $scope.pendingRequests--;
                });
        };

        _loadServiceSolicitations();
    }]);

})();