/// <reference path="../../../../Scripts/Vendors/LinqJs/linq.js" />
(function () {

    app.controller("locationsController", ["$scope", "LocationResource", function ($scope, LocationResource) {

        $scope = $scope || {};
        $scope.pendingRequests = 0;
        $scope.step = 'list';
        $scope.locations = [];

        $scope.showList = function () {
            $scope.step = 'list';
        };

        $scope.edit = function (location) {
            $scope.formTitle = "Editar local";
            $scope.form = new LocationForm(location);
            _showForm();
        };

        $scope.clear = function () {
            $scope.formTitle = "Criar novo local";
            $scope.form = new LocationForm();
        };

        $scope.remove = function (location) {
            var data = new LocationForm(location);
            $scope.pendingRequests++;
            LocationResource.remove(
                { id: data.Id },
                {},
                function (response) {
                    notificationHandler.AddSuccessNotificiation("Local excluido com sucesso");
                    _getLocations();
                    $scope.pendingRequests--;
                    if ($scope.form.Id == data.Id)
                        $scope.clear();
                },
                function (response) {
                    $scope.pendingRequests--;
                    var title = "Houve uma falha ao excluir o local";
                    if (!response.data.messages) {
                        notificationHandler.AddNotificiation(title, ["Não foi possível conectar ao servidor"], "error");
                        return;
                    }
                    notificationHandler.AddNotificiation(title, response.data.messages, "error");
                });
        };

        $scope.save = function () {
            if (!$scope.form.Id)
                _add();
            else
                _update();
        };

        $scope.goToClearedForm = function () {
            $scope.clear();
            _showForm();
        };

        var _showForm = function () {
            $scope.step = 'form';
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

        var _add = function () {
            var errors = $scope.form.Validate();

            var errorTitle = "Houve uma falha ao criar o local";
            if (errors.length > 0) {
                notificationHandler.AddNotificiation(errorTitle, errors, "error");
                return;
            }

            $scope.pendingRequests++;
            LocationResource.add(
                $scope.form,
                function (response) {
                    notificationHandler.AddSuccessNotificiation("Local criado com sucesso");
                    _getLocations();
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
        }

        var _update = function () {
            var errors = $scope.form.Validate();

            var errorTitle = "Houve uma falha ao atualizar o local";
            if (errors.length > 0) {
                notificationHandler.AddNotificiation(errorTitle, errors, "error");
                return;
            }

            $scope.pendingRequests++;
            LocationResource.update(
                { id: $scope.form .Id},
                $scope.form,
                function (response) {
                    notificationHandler.AddSuccessNotificiation("Local atualizado com sucesso");
                    _getLocations();
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
            $scope.clear();
            _getLocations();
        };

        _init();

    }]);

})();