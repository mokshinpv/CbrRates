window.Cbr = window.Cbr || {};

requirejs.config({
    baseUrl: "app",
    map: {
        '*': {
            'knockout': "ko"
        }
    },
    paths: {
        'text': "../libs/requirejs-text/text",
        'durandal': "../libs/Durandal/js",
        'plugins': "../libs/Durandal/js/plugins",
        'transitions': "../libs/Durandal/js/transitions",
        'ko': "../libs/knockout/dist/knockout.debug",
        'jquery': "../libs/jquery/jquery",
        'bootstrap': "../libs/bootstrap/dist/js/bootstrap",
        underscore: "../libs/underscore/underscore",
        moment: "../libs/moment/moment",
        chartjs: "../libs/chart.js/dist/Chart"
    },
    shim: {
        bootstrap: { deps: ["jquery"], exports: "jQuery" },
        'shell': { deps: ["text!shell.html"] },
        'currency-page/currencyPageViewModel': { deps: ["text!currency-page/currencyPageViewModel.html"] }
    },
    config: {
        i18n: {
            locale: "ru-ru"
        }
    }
});

define(["durandal/system", "durandal/app", "durandal/viewLocator", "bootstrap", "customBindings"], function (system, app, viewLocator) {
    app.title = "Курсы ЦБ";
    
    app.configurePlugins({
        router: true
    });

    app.start().then(function () {
        viewLocator.convertModuleIdToViewId(function(moduleId) {
            return moduleId;
        });
        app.setRoot("shell", "entrance");
    });
});