(function () {

    var notificationHandler = new NotificationHandler();

    app.controller("NewAdvertiserAccountController", ["$scope", "AccountResource",
        function ($scope, AccountResource) {

            $scope.form = new NewAccountRequest();
            $scope.pendingRequests = 0;

            $scope.submit = function () {

                var errors = $scope.form.Validate();
                if (errors.length > 0) {
                    notificationHandler.AddNotificiation("Falha ao realizar o cadastro", errors, "warning");
                    return;
                }

                $scope.pendingRequests++;

                AccountResource.createNewAdvertiser(
                    $scope.form,
                    function (response) {
                        notificationHandler.AddSuccessNotificiation("Conta cadastrada com sucesso", "success");
                        setTimeout(function () {
                            window.location = response.ReturnUrl;
                        },2000)
                    },
                    function (response) {
                        notificationHandler.AddNotificiation("Falha ao realizar cadastro", response.data.Messages, response.data.Type);
                        $scope.pendingRequests--;
                    }
                );
            };
        }]);
})();