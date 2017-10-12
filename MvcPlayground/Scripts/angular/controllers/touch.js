var module = angular.module('touch');
module.controller('TouchController', ['$scope', '$swipe', function ($scope, $swipe) {
    $scope.swipeLeft = function ($event) {
        console.log($event);
        $('.the-big-bad-box').addClass('leftie').removeClass('rightie');
    };
    $scope.swipeRight = function ($event) {
        console.log($event);
        $('.the-big-bad-box').addClass('rightie').removeClass('leftie');
    }

    $swipe.bind($('.the-big-bad-box'), {
        start: function (coords) {
            console.log('Started');
        },
        move: function (coords) {
            console.log('Moving', coords);
        },
        end: function (coords) {
            console.log('Ending');
        },
        cancel: function (coords) {
            console.log('Cancelling');
        }
    });
}]);