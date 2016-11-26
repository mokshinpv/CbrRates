define(["jquery", "underscore", "ko", "chartjs"], function($, _, ko, Chart) {
    ko.bindingHandlers.chartjs = {
        init: function(element, valueAccessor) {
            var chart = new Chart(element, {
                type: "line",
                data: ko.unwrap(valueAccessor())
            });
        }
    };
});