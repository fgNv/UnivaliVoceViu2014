/// <reference path="../app.js" />
/// <reference path="../../Vendors/LinqJs/linq.js" />
/// <reference path="../NotificationHandler.js" />

(function () {

    var notificationHandler = new NotificationHandler();

    app.controller("AdminAuthenticationController", ["$scope", "AdminResource", function ($scope, adminResource) {

        $scope.userName = "";
        $scope.password = "";
        $scope.passwordConfirmation = "";

        var _validate = function(){
            var errors = [];

            if(!$scope.userName)
                errors.push("Deve-se fornecer um usuário");
            
            if(!$scope.password)
                errors.push("Deve-se fornecer uma senha");

            if($scope.password != $scope.passwordConfirmation)
                errors.push("A senha e a confirmação não coincidem");

            return errors;
        };

        $scope.authenticate = function () {

            var errors = _validate();
            if(errors.length > 0){

            }

        };

    }]);

})();