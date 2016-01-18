/* global define: false */
define([
    'i18next',
    'jquery'
], function WelcomeViewModel(
    i18n,
    $,
    dialog
    ) {
    "use strict";
    var self = this;
    ;

    var viewModel = {};

    function activate() {
        return $.when(loadCurrentPage());
    }

    function loadCurrentPage() {
        return true;
    }

    viewModel.i18n = i18n;
    viewModel.activate = activate;

    return viewModel;
});