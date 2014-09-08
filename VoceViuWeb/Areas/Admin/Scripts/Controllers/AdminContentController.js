/// <reference path="../app.js" />
/// <reference path="../../Vendors/LinqJs/linq.js" />
/// <reference path="../NotificationHandler.js" />

(function () {

    app.controller("AdminContentController", ["$scope", "AdminContentResource", function ($scope, AdminContentResource) {

        $scope = $scope || {};
        $scope.pendingRequests = 0;
        $scope.contentSubmissionRequested = false;
        $scope.contents = [];

        $scope.submitContent = function () {
            $scope.pendingRequests++;
            $scope.$apply();
            var formData = new FormData($('form#contentSubmission')[0]);

            $.ajax({
                url: '/Admin/Advertisement/AddContent',
                type: 'POST',
                data: formData,
                async: false,
                cache: false,
                contentType: false,
                processData: false,
                success: function () {
                    notificationHandler.AddSuccessNotificiation("Conteúdo enviado com sucesso");
                    $scope.pendingRequests--;
                    _getContents();
                    $scope.contentSubmissionRequested = false;
                },
                error: function () {
                    $scope.pendingRequests--;
                    alert("Erro ao enviar o conteúdo");
                }
            });
        };

        $scope.remove = function (content) {
            $scope.pendingRequests++;

            AdminContentResource.remove(
                { id: content.ContentId },
                {},
                function (response) {
                    _getContents();
                    notificationHandler.AddSuccessNotificiation("Conteúdo excluído com sucesso");
                    $scope.pendingRequests--;
                },
                function (response) {
                    $scope.pendingRequests--;
                    var title = "Falha ao enviar conteúdo";
                    if (!response.data.Messages) {
                        notificationHandler.AddNotificiation(title, ["Não foi possível conectar ao servidor"], "error");
                        return;
                    }
                    notificationHandler.AddNotificiation(title, response.data.Messages, "error");
                });
        };

        var _getContents = function () {
            $scope.pendingRequests++;
            AdminContentResource.getAll(
                function (response) {
                    $scope.contents = response;
                    $scope.pendingRequests--;
                },
                function (response) {
                    $scope.pendingRequests--;
                });
        };

        var _init = function () {
            _getContents();
        };

        _init();
    }]);

})();