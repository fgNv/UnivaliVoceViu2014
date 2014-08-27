(function () {

    app.controller("AdvertisementManagementController", ["$scope", "AdvertisementResource",
        function ($scope, AdvertisementResource) {

            $scope = $scope || {};

            $scope.pendingRequests = 0;
            $scope.advertisements = [];

            var _getAdvertisements = function () {
                $scope.pendingRequests++;

                AdvertisementResource.getAll(function (response) {
                    $scope.advertisements = response;
                    $scope.pendingRequests--;
                },
                function (error) {
                    $scope.pendingRequests--;
                });
            };

            var _init = function () {
                _getAdvertisements();
            };

            _init();
        }]);

})();