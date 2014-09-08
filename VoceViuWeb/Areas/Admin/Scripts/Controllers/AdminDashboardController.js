/// <reference path="../app.js" />
/// <reference path="../../Vendors/LinqJs/linq.js" />
/// <reference path="../NotificationHandler.js" />

(function () {

    app.controller("AdminDashboardController", ["$scope", "DashboardResource", function ($scope, DashboardResource) {

        $scope = $scope || {};
        $scope.pendingRequests = 0;
        $scope.data = {};

        var _getAdminData = function () {
            $scope.pendingRequests++;
            DashboardResource.getAdministratorData(
                function (response) {
                    $scope.data = response;
                    $scope.pendingRequests--;
                },
                function (response) {
                    $scope.pendingRequests--;
                });
        };

        var _init = function () {
            _getAdminData();
        };

        _init();
        

    }]);

})();