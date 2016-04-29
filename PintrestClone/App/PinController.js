(function () {
    'use strict';

    angular
        .module('app')
        .controller('pinController', pinController);

    pinController.$inject = ['$scope', '$location', 'pinFactory'];

    function pinController($scope, $location, pinFactory) {
        /* jshint validthis:true */

        activate();

        $scope.savePin = function () {
            console.log("I did a thing!");
            pinFactory.savePin($scope.newPinInfo).then(function (data) {
                $scope.pins.push({
                    PhotoUrl: data.data.PhotoUrl,
                    Body: data.data.Body,
                    PinUrl: data.data.PinUrl,
                    Id: data.data.Id
                });
            });


        };

        function activate() {

            pinFactory.getPins().then(function (data) {
                $scope.pins = data.data;

            });
        }
    }
})();