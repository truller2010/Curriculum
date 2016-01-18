/* global _: false, define: false, ko: false */
define(
    [
        "jquery", "core/config", "core/i18n" 
    ],
    function testViewModel($, config, i18n) {
        var viewModel = {};

        // lifecycle definition
        function activate() {
            // always return a promise
            return true;
        }

        function loadCurrentPage() {
            return true;
        }

        function refreshCurrentPage(data) {
        }

        // state revelation
        viewModel.i18n = i18n;

        // lifecycle revelation
        viewModel.activate = activate;

        return viewModel;
    });