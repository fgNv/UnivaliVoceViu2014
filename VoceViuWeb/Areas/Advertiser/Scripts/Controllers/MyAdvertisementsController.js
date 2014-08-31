(function () {

    app.controller("myAdvertisementsController", ["$scope", "AdvertisementResource",
        function ($scope, AdvertisementResource) {
            $scope = $scope || {};

            $scope.pendingRequests = 0;
            $scope.advertisements = [];
            $scope.advertisementStatuses = [];
            $scope.currentStatus = '';
            $scope.currentAdvertisement = {};
            $scope.contentSubmissionRequested = false;

            var _getAdvertisementStatuses = function () {
                $scope.pendingRequests++;
                AdvertisementResource.getStatuses(
                    function (response) {
                        $scope.advertisementStatuses = response;
                        $scope.currentStatus = response[0].Value;
                        $scope.pendingRequests--;
                    },
                    function (response) {
                        $scope.pendingRequests--;
                    });
            };

            $scope.submitContent = function () {
                $scope.pendingRequests++;
                var formData = new FormData($('form#contentSubmission')[0]);

                $.ajax({
                    url: '/Advertiser/Advertisement/SubmitContent',
                    type: 'POST',
                    data: formData,
                    async: false,
                    cache: false,
                    contentType: false,
                    processData: false,
                    success: function () {
                        notificationHandler.AddSuccessNotificiation("Conteúdo enviado com sucesso");
                        $scope.pendingRequests--;
                        _getAdvertisements();
                        $scope.cancelContentSubmission();
                    },
                    error: function () {
                        $scope.pendingRequests--;
                        alert("erro ao enviar o conteúdo");
                    }
                });
            };

            $scope.showContentSubmissionForm = function (advertisement) {
                $scope.currentAdvertisement = advertisement;
                $scope.contentSubmissionRequested = true;
            };

            $scope.cancelContentSubmission = function () {
                $scope.currentAdvertisement = {};
                $scope.contentSubmissionRequested = false;
            };

            $scope.anyEntriesWithCurrentFilter = function () {
                var advertisements = Enumerable.From($scope.advertisements);
                return advertisements.Any(function (i) { return i.Status == $scope.currentStatus; });
            };

            $scope.setCurrentStatus = function (status) {
                $scope.currentStatus = status.Value;
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
            };

            _init();
        }]);

})();