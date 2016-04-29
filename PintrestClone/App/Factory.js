(function () {
    'use strict';

    angular
        .module("app")
        .factory("pinFactory", factory);

    factory.$inject = ["$http"];

    function factory($http) {
        var service = {
            getPins: getPins,
            savePin: savePin
        };

        return service;

        function getPins() {
            return $http.get("/home/getallpins");
        }

        function savePin(pinInfo) {
            return $http.post("/home/savepin", pinInfo);
        }

    }
})();