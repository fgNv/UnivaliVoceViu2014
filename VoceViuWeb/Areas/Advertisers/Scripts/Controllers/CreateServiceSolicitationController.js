/// <reference path="../../../../Scripts/App/Models/NewServiceSolicitation.js" />

(function () {

    app.controller("createServiceSolicitationController", ["$scope", "ServiceSolicitationResource", "LocationResource", "ContractModelResource",
        function ($scope, ServiceSolicitationResource, LocationResource, ContractModelResource) {

            $scope = $scope || {};

            $scope.pendingRequests = 0;
            $scope.locations = [];
            $scope.months = [];
            $scope.contractModels = [];

            $scope.form = new NewServiceSolicitation();

            $scope.send = function () {

                var errorTitle = "Houve uma falha na solicitação de serviço";

                var errors = $scope.form.Validate();
                if (errors.length > 0) {
                    notificationHandler.AddNotificiation(errorTitle, errors, "warning");
                    return;
                }

                $scope.pendingRequests++;
                LocationResource.add(
                    $scope.form,
                    function (response) {
                        notificationHandler.AddSuccessNotificiation("Solicitação de serviço enviada com sucesso");
                        $scope.pendingRequests--;
                    },
                    function (response) {
                        if (!response.data.messages) {
                            notificationHandler.AddNotificiation(errorTitle, ["Não foi possível conectar ao servidor"], "error");
                            return;
                        }
                        notificationHandler.AddNotificiation(errorTitle, response.data.messages, "error");
                        $scope.pendingRequests--;
                    });
            };

            var _getAvailableMonth = function () {
                $scope.pendingRequests++;
                ServiceSolicitationResource.getAvailableMonths(
                    {},
                    function (response) {
                        $scope.months = response;
                        $scope.pendingRequests--;
                    },
                    function (response) {
                        $scope.pendingRequests--;
                    });
            };

            var _getLocations = function () {
                $scope.pendingRequests++;
                LocationResource.getAll(
                    {},
                    function (response) {
                        $scope.locations = response;
                        $scope.pendingRequests--;
                    },
                    function (response) {
                        $scope.pendingRequests--;
                    });
            };

            var _getContractModels = function () {
                $scope.pendingRequests++;
                ContractModelResource.getAll(
                    {},
                    function (response) {
                        $scope.contractModels = response;
                        $scope.pendingRequests--;
                    },
                    function (response) {
                        $scope.pendingRequests--;
                    })
            };

            var _init = function () {
                _getAvailableMonth();
                _getLocations();
            };

            _init();

        }]);

})();