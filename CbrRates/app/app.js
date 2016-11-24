window.Cbr = window.Cbr || {};

requirejs.config({
    baseUrl: 'app',
    map: {
        '*': {
            'knockout': 'ko'
        }
    },
    paths: {
        'text': '../libs/requirejs-text/text',
        'ko': '../libs/knockout.js/knockout.debug',
        'jquery': '../libs/jquery/dist/jquery',
        'bootstrap': '../libs/bootstrap/dist/js/bootstrap',
        underscore: '../libs/underscore/underscore'
    },
    shim: {
        'shell': { deps: ['text!shell.html'] }
    }
});

requirejs.config({
    config: {
        //Set the config for the i18n
        //module ID
        i18n: {
            locale: Merch.pageSettings.locale === 'en' ? 'en-us' : 'ru-ru'
        }
    }
});

require(['jquery', 'globalConfigurator', 'appConfigurator'],
    function (jquery, globalConfigurator, appConfigurator) {
        'use strict';
        globalConfigurator.init();
        appConfigurator.init();

        // ReSharper disable UndeclaredGlobalVariableUsing
        require(['durandal/system', 'durandal/binder', 'durandal/app', 'notificationService', 'WcfDispatcher', 'WcfDispatcher.CacheExtender', 'WcfDispatcher.FileDownloadExtender'],
            function (system, viewModelBinder, app, notificationService, wcfDispatcher)
                // ReSharper restore UndeclaredGlobalVariableUsing
            {
                //>>excludeStart("build", pragmas.build);
                system.debug(true);
                viewModelBinder.throwOnErrors = true;
                wcfDispatcher.cacheEnabled = true;
                //>>excludeEnd("build");
                wcfDispatcher.HandleUnauthorizedError = false;

                wcfDispatcher.faultHandlers.splice(wcfDispatcher.faultHandlers.length - 1, 0, function (result) {
                    try {
                        var parsedData = jquery.parseJSON(result.responseText);
                        if (parsedData != null && parsedData.Details != null && parsedData.Details !== "") {
                            notificationService.error(parsedData.Details);
                            return false;
                        }
                    } catch (e) {

                    }
                });

                app.start().then(function () {
                    app.setRoot('shell', 'fade');
                });
            });
    });