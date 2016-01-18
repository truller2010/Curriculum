/* global _: false, define: false, ko: false */
define(
    [
        "jquery", "core/config", "core/i18n"
    ],
    function AboutViewModel($, config, i18n) {
        var viewModel = {};

        // lifecycle definition
        function activate() {
            return $.when(loadCurrentPage());
        }

        function loadCurrentPage() {
            return true;
        }

        // state revelation
        viewModel.i18n = i18n;

        // lifecycle revelation
        viewModel.activate = activate;

        return viewModel;
    });