/// <reference path="../Models/AuthenticateRequest.js" />

(function () {

    app.controller("AdvertiserAuthenticationController", ["$scope", "AccountResource", function ($scope, AccountResource) {
        
        $scope = $scope || {};
        $scope.pendingRequests = 0;
        $scope.form = new AuthenticateRequest();

        $scope.authenticate = function () {
            var errors = $scope.form.Validate();
            if (errors.length > 0) {
                notificationHandler.AddNotificiation("Houve uma falha na autenticação", errors, "warning");
                return;
            }

            $scope.pendingRequests++;

            AccountResource.authenticateAdvertiser(
                $scope.form,
                function (response) {
                    notificationHandler.AddSuccessNotificiation("Autenticação efetuada com sucesso");
                    setTimeout(function () {
                        window.location = response.ReturnUrl;
                    },2000);
                },
                function (response) {
                    notificationHandler.AddNotificiation("Houve uma falha na autenticação", response.data.Messages, response.data.Type);
                    $scope.pendingRequests--;
                });
        };

    }]);
})();