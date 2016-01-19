/**
 * Toastr plugin https://github.com/CodeSeven/toastr
 */
define(["durandal/app", "jquery", "toastr"], function(app, $, toastr) {

    var toastrPlugin = {},
        types = {
            SUCCESS: "success",
            ERROR: "error",
            WARNING: "warning",
            INFO: "info"
        };

    function showToast(type, message, title, options) {
        return toastr[type](message, title, options);
    }

    function install(config) {

        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": true,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };

        app.showToast = function(type, message, title, options) {
            return toastrPlugin.showToast(type, message, title, options);
        };

        app.toast = {
            types: types
        };
    }

    toastrPlugin.types = types;
    toastrPlugin.install = install;
    toastrPlugin.showToast = showToast;

    return toastrPlugin;

});