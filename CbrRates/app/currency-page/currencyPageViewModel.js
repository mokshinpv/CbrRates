define(["jquery", "underscore", "knockout", "moment", "currency-page/currencyPageService"], function($, _, ko, moment, CurrencyPageServiceDef) {
    "use strict";

    function CurrencyPageViewModel() {
        this.supportedCurrencies = ko.observableArray([]);
        this.selectedCurrency = ko.observable(null);
        this.ratesChartData = ko.observable({});
        
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
                this.ratesChartData(this.mapResponseToChartData(response));
            }, this));
        },
        mapResponseToChartData: function(response) {
            return {
                labels: _.map(response.records, function(r) {
                    return moment(r.date).format("D MMM");
                }),
                datasets: [{
                    data: _.pluck(response.records, "value"),
                    fill: false,
                    borderColor: "#ff0000",
                    borderWidth: 2,
                    pointBackgroundColor: "#ff0000"
                }]
            };
        }
    });

    return CurrencyPageViewModel;
});