(function () {
    angular.module("app")
        .controller("quoteForm", ["$http", "$sce", QuoteFormController]);

    function QuoteFormController($http, $sce) {
        var ctrl = this;
        ctrl.models = {};
        ctrl.loadModels = loadModels;
        ctrl.submit = submit;

        loadMakes();

        function loadMakes() {
            $http.get("api/vehicle/makes", {}).then(function(result) {
                ctrl.makes = result.data;
            });
        }

        function loadModels(makeId) {
            $http.get("api/vehicle/models/" + makeId, {}).then(function(result) {
                ctrl.models = result.data;
            });
        }
        
        function submit() {
            $http.post("Quote/Post", ctrl.model).then(function(result) {
                ctrl.thankYouResult = $sce.trustAsHtml(result.data);
            });
        }
    }
})();