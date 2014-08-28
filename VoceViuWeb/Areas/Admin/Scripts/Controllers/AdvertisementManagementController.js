(function () {

    app.controller("AdvertisementManagementController", ["$scope", "AdvertisementResource",
        function ($scope, AdvertisementResource) {

            $scope = $scope || {};

            $scope.comment = "";
            $scope.contentDenialRequested = false;
            $scope.pendingRequests = 0;
            $scope.advertisements = [];
            $scope.currentAdvertisement = {};

            $scope.approveContent = function (advertisement) {
                $scope.pendingRequests++;
                AdvertisementResource.approveContent(
                    { id: advertisement.Id },
                    {},
                    function (response) {
                        notificationHandler.AddSuccessNotificiation("Conteúdo aprovado com sucesso");
                        _loadServiceSolicitations();
                        $scope.pendingRequests--;
                    },
                    function (response) {
                        var title = "Houve uma falha ao aprovar o conteúdo";
                        if (!response.data.messages) {
                            notificationHandler.AddNotificiation(title, ["Não foi possível conectar ao servidor"], "error");
                            return;
                        }
                        notificationHandler.AddNotificiation(title, response.data.messages, "error");
                        $scope.pendingRequests--;
                    });
            };

            $scope.requestContentDenialFeedback = function (advertisement) {
                $scope.currentAdvertisement = advertisement;
                $scope.contentDenialRequested = true;
            };

            $scope.cancelContentDenial = function () {
                $scope.currentAdvertisement = {};
                $scope.contentDenialRequested = false;
            };

            $scope.denyContent = function () {
                $scope.pendingRequests++;
                AdvertisementResource.denyContent(
                    { id: $scope.currentAdvertisement.Id },
                    { Comment : $scope.comment},
                    function (response) {
                        notificationHandler.AddSuccessNotificiation("Conteúdo reprovado com sucesso");
                        _loadServiceSolicitations();
                        $scope.pendingRequests--;
                        $scope.contentDenialRequested = false;
                    },
                    function (response) {
                        var title = "Houve uma falha ao aprovar o conteúdo";
                        if (!response.data.messages) {
                            notificationHandler.AddNotificiation(title, ["Não foi possível conectar ao servidor"], "error");
                            return;
                        }
                        notificationHandler.AddNotificiation(title, response.data.messages, "error");
                        $scope.pendingRequests--;
                    });
            };

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