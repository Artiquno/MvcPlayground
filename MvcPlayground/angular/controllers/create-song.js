var module = angular.module('create-song', ['ui.bootstrap', 'ngFileUpload']);
module.controller('CreateSongController', ['$scope', '$http', function ($scope, $http) {
    $scope.song = {
        releaseDate: new Date(),
        length: moment().hour(),
        rating: '3'
    };
    console.log($scope.song);

    function openDatepicker(datepicker) {
        var tester = document.createElement('input');
        tester.type = 'date';
        if (tester.type != 'date') {
            datepicker.opened = true;
        }
    }
    $scope.datepickers = {
        releaseDate: {
            formats: [
                "M!/d!/yyyy"  
            ],
            opened: false,
            config: {
                startingDay: 1
            },
            open: function () {
                openDatepicker(this);
            }
        }
    }
}]);