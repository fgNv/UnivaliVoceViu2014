(function () {

    app.controller("AdvertisementManagementController", ["$scope", "AdvertisementResource",
        function ($scope, AdvertisementResource) {

            $scope = $scope || {};

            $scope.comment = "";
            $scope.contentDenialRequested = false;
            $scope.pendingRequests = 0;
            $scope.advertisements = [];
            $scope.currentAdvertisement = {};
            $scope.advertisementStatuses = [];
            $scope.currentStatus = '';

            var _getAdvertisementStatuses = function () {
                $scope.pendingRequests++;
                AdvertisementResource.getStatuses(
                    function (response) {
                        $scope.advertisementStatuses = response;
                        if (!$scope.currentStatus || $scope.currentStatus == "")
                            $scope.currentStatus = response[0].Value;
                        $scope.pendingRequests--;
                    },
                    function (response) {
                        $scope.pendingRequests--;
                    });

            };

            var _verifyInitialFilter = function () {
                var initialFilterParamKey = "InitialFilter";
                var queryString = window.location.search;
                var indexOfinitialFilter = queryString.indexOf(initialFilterParamKey);

                if (indexOfinitialFilter == -1)
                    return;

                var initialFilter = queryString.substr(indexOfinitialFilter).split("=")[1];
                $scope.setCurrentStatus({ Value: initialFilter });
            };

            $scope.isCurrentStatus = function (advertisement) {
                return advertisement.Status == $scope.currentStatus;
            };

            $scope.anyEntriesWithCurrentFilter = function () {
                var advertisements = Enumerable.From($scope.advertisements);
                return advertisements.Any(function (i) { return i.Status == $scope.currentStatus; });
            };

            $scope.setCurrentStatus = function (status) {
                $scope.currentStatus = status.Value;
            };

            $scope.approveContent = function (advertisement) {
                $scope.pendingRequests++;
                AdvertisementResource.approveContent(
                    { id: advertisement.Id },
                    {},
                    function (response) {
                        notificationHandler.AddSuccessNotificiation("Conteúdo aprovado com sucesso");
                        _getAdvertisements();
                        $scope.pendingRequests--;
                    },
                    function (response) {
                        var title = "Houve uma falha ao aprovar o conteúdo";
                        if (!response.data.Messages) {
                            notificationHandler.AddNotificiation(title, ["Não foi possível conectar ao servidor"], "error");
                            return;
                        }
                        notificationHandler.AddNotificiation(title, response.data.Messages, "error");
                        $scope.pendingRequests--;
                    });
            };

            $scope.setAsPaid = function (advertisement) {
                $scope.pendingRequests++;
                AdvertisementResource.setAsPaid(
                    { id: advertisement.Id },
                    {},
                    function (response) {
                        notificationHandler.AddSuccessNotificiation("Anúncio marcado como pago com sucesso");
                        _getAdvertisements();
                        $scope.pendingRequests--;
                    },
                    function (response) {
                        var title = "Falha ao marcar anúncio como pago";
                        if (!response.data.Messages) {
                            notificationHandler.AddNotificiation(title, ["Não foi possível conectar ao servidor"], "error");
                            return;
                        }
                        notificationHandler.AddNotificiation(title, response.data.Messages, "error");
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
                    { Comment: $scope.comment },
                    function (response) {
                        notificationHandler.AddSuccessNotificiation("Conteúdo reprovado com sucesso");
                        _loadServiceSolicitations();
                        $scope.pendingRequests--;
                        $scope.contentDenialRequested = false;
                    },
                    function (response) {
                        var title = "Houve uma falha ao aprovar o conteúdo";
                        if (!response.data.Messages) {
                            notificationHandler.AddNotificiation(title, ["Não foi possível conectar ao servidor"], "error");
                            return;
                        }
                        notificationHandler.AddNotificiation(title, response.data.Messages, "error");
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
                _getAdvertisementStatuses();
                _verifyInitialFilter();
            };

            _init();
        }]);

})();