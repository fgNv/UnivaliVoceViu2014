(function () {

    app.controller("AdvertiserManagementController", ["$scope", "AdvertiserResource", function ($scope, AdvertiserResource) {

        $scope = $scope || {};
        $scope.pendingRequests = 0;
        $scope.advertisers = [];

        var _getAdvertisers = function () {
            $scope.pendingRequests++;
            AdvertiserResource.getAll(
                function (response) {
                    $scope.advertisers = response;
                    $scope.pendingRequests--;
                },
                function (response) {
                    $scope.pendingRequests--;
                });
        };
        
        $scope.remove = function (advertiser) {
            $scope.pendingRequests++;
            AdvertiserResource.remove(
                { id : advertiser.Id},
                {},
                function (response) {
                    notificationHandler.AddSuccessNotificiation("Anunciante excluido com sucesso");
                    _getAdvertisers();
                    $scope.pendingRequests--;
                },
                function (response) {
                    debugger;
                    $scope.pendingRequests--;
                    var title = "Houve uma falha ao excluir o anunciante";
                    if (!response.data.Messages) {
                        notificationHandler.AddNotificiation(title, ["Não foi possível conectar ao servidor"], "error");
                        return;
                    }
                    notificationHandler.AddNotificiation(title, response.data.Messages, "error");
                });
        };

        var _init = function () {
            _getAdvertisers();
        };

        _init();


    }]);

})();