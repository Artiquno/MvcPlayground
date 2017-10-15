var module = angular.module('playground')
.controller('PlaygroundController', ['$scope', 'Upload', '$http', '$localStorage', function($scope, $upload, $http, $localStorage) {
    $scope.$storage = $localStorage;

    $('[ngf-drop]').on('dragover', function (e) {
        e.preventDefault();
        $('.newspaper-sound').get(0).play();
    });

    $scope.user = {};
    if ($scope.$storage.user) {
        $.extend(true, $scope.user, $scope.$storage.user);
    }
    
    $scope.imageResizeOptions = {
        width: 256,
        height: 256,
        quality: 1.0,
        centerCrop: true
    };

    $scope.submit = function ($event) {
        $event.preventDefault();
        if ($scope.form.$valid) {
            $upload.upload({
                url: "/api/register",
                data: $scope.user
            }).then(function (res) {
                console.log(res);
                $scope.$storage.user = {};
                $.extend(true, $scope.$storage.user, res.data);
                $scope.$storage.user.arr = null;
                $scope.$storage.user.randomFinish = null;
                console.log($scope.$storage.user);
            });
        } else {
            console.log("You have a few issues there Jack", $scope.form.$error);
        }
    }
}]);