(function () {
    "use strict";

    app.controller("contractModelController", ["$scope", "ContractModelResource", function ($scope, ContractModelResource) {

        $scope = $scope || {};
        $scope.pendingRequests = 0;
        $scope.step = 'list';
        $scope.form = {};
        $scope.contractModels = [];

        $scope.edit = function (contractModel) {
            $scope.formTitle = "Editar modelo de contrato";
            $scope.form = new ContractModelForm(contractModel);
            _showForm();
        };

        $scope.remove = function (contractModel) {
            var data = new ContractModelForm(contractModel);
            $scope.pendingRequests++;
            ContractModelResource.remove(
                { id: data.Id },
                {},
                function (response) {
                    notificationHandler.AddSuccessNotificiation("Modelo de contrato excluido com sucesso");
                    _getContractModels();
                    $scope.pendingRequests--;
                    if ($scope.form.Id == data.Id)
                        $scope.clear();
                },
                function (response) {
                    $scope.pendingRequests--;
                    var title = "Houve uma falha ao excluir o modelo de contrato";
                    if (!response.data.messages) {
                        notificationHandler.AddNotificiation(title, ["Não foi possível conectar ao servidor"], "error");
                        return;
                    }
                    notificationHandler.AddNotificiation(title, response.data.messages, "error");
                });
        };

        $scope.clear = function () {
            $scope.formTitle = "Criar novo modelo de contrato";
            $scope.form = new ContractModelForm();
        };

        $scope.goToClearedForm = function () {
            $scope.clear();
            _showForm();
        };

        $scope.showList = function () {
            $scope.step = 'list';
        };

        $scope.save = function () {
            if (!$scope.form.Id)
                _add();
            else
                _update();
        }

        var _showForm = function () {
            $scope.step = 'form';
        };

        var _update = function () {

            var errors = $scope.form.Validate();
            var errorTitle = "Houve uma falha ao atualizar o modelo de contrato";

            if (errors.length > 0) {
                notificationHandler.AddNotificiation(errorTitle, errors, "error");
                return;
            }

            $scope.pendingRequests++;
            ContractModelResource.update(
                { id: $scope.form.Id },
                $scope.form,
                function (response) {
                    notificationHandler.AddSuccessNotificiation("Modelo de contrato atualizado com sucesso");
                    _getContractModels();
                    $scope.pendingRequests--;
                },
                function (response) {
                    $scope.pendingRequests--;
                    if (!response.data.messages) {
                        notificationHandler.AddNotificiation(errorTitle, ["Não foi possível conectar ao servidor"], "error");
                        return;
                    }
                    notificationHandler.AddNotificiation(errorTitle, response.data.messages, "error");
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
                });
        };

        var _add = function () {

            var errors = $scope.form.Validate();
            var errorTitle = "Houve uma falha ao criar o modelo de contrato";

            if (errors.length > 0) {
                notificationHandler.AddNotificiation(errorTitle, errors, "error");
                return;
            }

            $scope.pendingRequests++;
            ContractModelResource.add(
                $scope.form,
                function (response) {
                    notificationHandler.AddSuccessNotificiation("Modelo de contrato criado com sucesso");
                    _getContractModels();
                    $scope.clear();
                    $scope.showList();
                    $scope.pendingRequests--;
                },
                function (response) {
                    $scope.pendingRequests--;
                    if (!response.data.messages) {
                        notificationHandler.AddNotificiation(errorTitle, ["Não foi possível conectar ao servidor"], "error");
                        return;
                    }
                    notificationHandler.AddNotificiation(errorTitle, response.data.messages, "error");
                });
        };

        var _init = function () {
            _getContractModels();
            $scope.clear();
        };

        _init();
    }]);

})();