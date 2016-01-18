/* global _: false, define: false */
define([
    "i18next", "durandal/system", 'durandal/app', 'knockout', 'text!views/toast/validation.html'
], function exceptionHandler(i18n, system, app, ko, toastValidationTemplate) {
    "use strict";

    var handler = {}, exceptionHandlers = { 
        'System.ValidationError': function handler(data) {
            ko.applyBindings({ messages: _.flatten(data.modelState) }, app.showToast(app.toast.types.ERROR, toastValidationTemplate)[0], i18n.t('app:errors.ValidationError'));
        },
        'System.AuthenticationError': function handler(data) {
            app.showToast(app.toast.types.ERROR, i18n.t('app:errors.AuthenticationError'));
        }
    };

    function handleException(data) {
        app.showToast(app.toast.types.ERROR, data.exceptionMessage || i18n.t('app:errors.FATAL_ALERT_TEXT'), data.message);
    }

    function handleRuntimeException(data) {
        handleException(data);
    }

    function handleApplicationException(data) {
        var handler = exceptionHandlers[data.exceptionType];

        if (handler) {
            handler(data);
        } else {
            if (data.exceptionType && data.exceptionType === "KotikoBlog.Services.Exceptions.DuplicatedException") {
                app.showToast(app.toast.types.ERROR, i18n.t('app:errors.' + data.exceptionType.replace(/\./g, '')), data.message);
            } else {
                app.showToast(app.toast.types.ERROR, data.exceptionMessage || i18n.t('app:errors.FATAL_ALERT_TEXT'), data.message);
            }
        }
    }

    function handle(exception) {
    	
        if (exception.status === "fail") {
            handleApplicationException(exception.data);
        } else {
            handleRuntimeException(exception.data);
        }
    }

    handler.handle = handle;

    return handler;
});