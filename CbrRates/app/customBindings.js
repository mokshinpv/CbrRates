define(["jquery", "underscore", "ko", "chartjs"], function($, _, ko, Chart) {
    ko.bindingHandlers.chartjs = {
        init: function (element, valueAccessor) {
            var chart = new Chart(element, {
                type: "line",
                data: ko.unwrap(valueAccessor()),
                options: {
                    legend: {
                        display: false
                    },
                    scales: {
                        xAxes: [{
                            ticks: {
                                autoSkipPadding: 10
                            }
                        }]
                    }
                }
            });

            var sub = null;
            if (ko.isObservable(valueAccessor())) {
                sub = valueAccessor().subscribe(function(newValue) {
                    chart.data.datasets = newValue.datasets;
                    chart.data.labels = newValue.labels;
                    chart.update();
                });
            }
            
            ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
                if (sub != null) {
                    sub.dispose();
                }
                chart.destroy();
                chart = null;
            });
        }
    };
});