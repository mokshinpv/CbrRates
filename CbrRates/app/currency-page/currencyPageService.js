define(["jquery", "underscore"], function($, _) {
    "use strict";

    function CurrencyPageService() {
    }

    _.extend(CurrencyPageService.prototype, {
        baseUrl: "/api/Rates/",
        callService: function (settings) {
            var ajaxSettings = {
                type: settings.method || "POST",
                contentType: settings.contentType || "application/json; charset=utf-8",
                url: this.baseUrl + settings.url,
                data: settings.data ? ((settings.method === "GET" || settings.data + "" === settings.data) ? settings.data : JSON.stringify(settings.data)) : undefined
            };

            return $.ajax(ajaxSettings);
        },
        getSupportedCurrencies: function() {
            return this.callService({
                method: "GET",
                url: "GetSupportedCurrencies"
            });
        },
        getRatesDynamics: function(currencyId) {
            return this.callService({
                method: "GET",
                url: "GetRatesDynamics?currencyId=" + currencyId
            });
        }
    });

    return CurrencyPageService;
});