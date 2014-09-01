(function () {

    app.controller("serviceSolicitationManagementController", ["$scope", "ServiceSolicitationResource",
        function ($scope, ServiceSolicitationResource) {
            $scope = $scope || {};

            $scope.pendingRequests = 0;
            $scope.serviceSolicitations = [];

            $scope.approve = function (serviceSolicitation) {
                $scope.pendingRequests++;
                ServiceSolicitationResource.approve(
                    { id: serviceSolicitation.Id },
                    {},
                    function (response) {
                        notificationHandler.AddSuccessNotificiation("Solicitação de serviço aprovada com sucesso");
                        _loadServiceSolicitations();
                        $scope.pendingRequests--;
                    },
                    function (response) {
                        var title = "Houve uma falha ao aprovar a solicitação de serviço";
                        if (!response.data.messages) {
                            notificationHandler.AddNotificiation(title, ["Não foi possível conectar ao servidor"], "error");
                            return;
                        }
                        notificationHandler.AddNotificiation(title, response.data.messages, "error");
                        $scope.pendingRequests--;
                    });
            };

            $scope.deny = function (serviceSolicitation) {
                ServiceSolicitationResource.deny(
                    { id: serviceSolicitation.Id },
                    {},
                    function (response) {
                        notificationHandler.AddSuccessNotificiation("Solicitação de serviço recusada com sucesso");
                        _loadServiceSolicitations();
                        $scope.pendingRequests--;
                    },
                    function (response) {
                        var title = "Houve uma falha ao rejeitar a solicitação de serviço";
                        if (!response.data.messages) {
                            notificationHandler.AddNotificiation(title, ["Não foi possível conectar ao servidor"], "error");
                            return;
                        }
                        notificationHandler.AddNotificiation(title, response.data.messages, "error");
                        $scope.pendingRequests--;
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