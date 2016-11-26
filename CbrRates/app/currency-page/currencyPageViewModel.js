define(["jquery", "underscore", "knockout", "currency-page/currencyPageService"], function($, _, ko, CurrencyPageServiceDef) {
    "use strict";

    function CurrencyPageViewModel() {
        this.supportedCurrencies = ko.observableArray([]);
        this.selectedCurrency = ko.observable(null);
        this.currencyRates = ko.observable(null);

        this.currencyService = new CurrencyPageServiceDef();
    }

    _.extend(CurrencyPageViewModel.prototype, {
        activate: function() {
            this.currencyService.getSupportedCurrencies().done(_.bind(function(currencies) {
                this.supportedCurrencies(currencies);

                if (currencies.length > 0) {
                    this.selectCurrency(this.supportedCurrencies()[0]);
                }
            }, this));
        },
        selectCurrency: function (currency) {
            if (currency === this.selectedCurrency()) {
                return;
            }

            this.selectedCurrency(currency);
            this.currencyService.getRatesDynamics(currency.id).done(_.bind(function (response) {
                this.currencyRates(response);
                //TODO график
            }, this));
        }
    });

    return CurrencyPageViewModel;
});