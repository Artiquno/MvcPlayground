angular.module("chat", [])
    .directive("chat", ["$http", function ($http) {
        return {
            templateUrl: "/Scripts/angular/templates/chat.html",
            restrict: "E",
            scope: {
                chat: "=chatObject"
            },
            link: function ($scope, $element, $attrs) {
                $scope.minimize = function () {
                    $($element).find(".chat").slideToggle(300, 'swing');
                }

                $scope.close = function (e) {
                    e.stopPropagation();
                    $($element).find(".live-chat").fadeOut(300);
                }
            } 
        }        
    }]);