/// <reference path="../Models/AuthenticateRequest.js" />

(function () {

    app.controller("AdvertiserDashboardController", ["$scope", "DashboardResource", function ($scope, DashboardResource) {

        $scope = $scope || {};
        $scope.pendingRequests = 0;
        $scope.data = {};

        var _getAdvertiserData = function () {
            $scope.pendingRequests++;
            DashboardResource.getAdvertiserData(
                function (response) {
                    $scope.data = response;
                    $scope.pendingRequests--;
                },
                function (response) {
                    $scope.pendingRequests--;
                });
        };

        var _init = function () {
            _getAdvertiserData();
        };

        _init();

    }]);
})();