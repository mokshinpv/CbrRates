﻿window.Cbr = window.Cbr || {};

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
    },
    config: {
        i18n: {
            locale: 'ru-ru'
        }
    }
});

require(['jquery', 'currency-page/currencyPageViewModel'], function ($, currencyPageViewModelDef) {
    'use strict';

    var viewModel = new currencyPageViewModelDef();
});