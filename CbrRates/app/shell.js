define(["plugins/router"], function (router) {
    return {
        router: router,
        activate: function () {
            router.map([
                { route: "", title: "", moduleId: "currency-page/currencyPageViewModel", nav: true }
            ]).buildNavigationModel();
            
            return router.activate();
        }
    };
});