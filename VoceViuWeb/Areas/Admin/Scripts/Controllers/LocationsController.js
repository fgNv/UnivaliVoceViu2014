(function () {

    var LocationForm = function (location) {

        location = location || {};

        this.Name = location.Name || "";
        this.Spot = location.Spot || 0;
        this.IP = location.Ip || "";
        this.Points = location.Points || [];
        this.Id = location.Id || null;

        var self = this;

        this.addPoint = function () {
            self.Points.push(new Point());
        };

        this.removePoint = function(point){
            self.Points = Enumerable.From(self.Points).Where(function (i) { return i != point }).ToArray();
        };
    };

    var Point = function (point) {
        point = point || {};

        this.Name = point.Name || "";
        this.Id = point.Id || null;
    };

    var notificationManager = new NotificationHandler();

    app.controller("locationsController", ["$scope", "LocationResource", function ($scope, LocationResource) {

        $scope = $scope || {};

        $scope.pendingRequests = 0;

        $scope.step = 'list';
        $scope.locations = [];
        $scope.form = new LocationForm();

        $scope.showForm = function () {
            $scope.step = 'form';
        };

        $scope.showList = function () {
            $scope.step = 'list';
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

        $scope.remove = function (location) {
            var data = new LocationForm(location);
            $scope.pendingRequests++;
            LocationResource.remove(
                { id: data.Id },
                {  },
                function (response) {
                    notificationManager.AddSuccessNotificiation("Local excluido com sucesso");
                    _getLocations();
                    $scope.pendingRequests--;
                },
                function (response) {
                    $scope.pendingRequests--;
                    var title = "Houve uma falha ao excluir o local";
                    if (!response.data.messages) {
                        notificationManager.AddNotificiation(title, ["Não foi possível conectar ao servidor"], "error");
                        return;
                    }
                    notificationManager.AddNotificiation(title, response.data.messages, "error");
                });
        };

        $scope.save = function () {
            $scope.pendingRequests++;
            LocationResource.add(
                $scope.form,
                function (response) {
                    notificationManager.AddSuccessNotificiation("Local criado com sucesso");
                    _getLocations();
                    $scope.pendingRequests--;
                },
                function (response) {
                    $scope.pendingRequests--;
                    var title = "Houve uma falha ao criar o local";
                    if (!response.data.messages){
                        notificationManager.AddNotificiation(title, ["Não foi possível conectar ao servidor"], "error");
                        return;
                    }
                    notificationManager.AddNotificiation(title, response.data.messages, "error");
                });
        };

        var _init = function () {
            _getLocations();
        };

        _init();

    }]);

})();