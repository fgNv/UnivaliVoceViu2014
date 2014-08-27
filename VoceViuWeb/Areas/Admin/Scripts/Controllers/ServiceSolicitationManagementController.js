(function () {

    app.controller("serviceSolicitationManagementController", ["$scope", "ServiceSolicitationResource",
        function ($scope, ServiceSolicitationResource) {
            $scope = $scope || {};

            $scope.pendingRequests = 0;
            $scope.serviceSolicitations = [];

            $scope.approve = function (serviceSolicitation) {
                ServiceSolicitationResource.approve(
                    { id: serviceSolicitation },
                    function (response) {

                    },
                    function (response) {

                    });
            };

            $scope.deny = function (serviceSolicitation) {
                ServiceSolicitationResource.deny(
                    { id: serviceSolicitation },
                    function (response) {

                    },
                    function (response) {

                    });
            };

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