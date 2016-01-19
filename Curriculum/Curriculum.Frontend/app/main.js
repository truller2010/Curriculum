requirejs.config({
    //urlArgs: "bust=" + (new Date()).getTime(),
    paths: {
        'text': "../js/text",
        'i18next': "../js/i18next",
        'i18n': "../js/require-i18next",
        'durandal': "../js/durandal",
        'plugins': "../js/durandal/plugins",
        'transitions': "../js/durandal/transitions"
    },
    i18next: {
        ns: "app",
        fallbackLng: "en",
        detectLngQS: "locale",
        lowerCaseLng: true,
        useCookie: false,
        resGetPath: "__lng__/__ns__.json",
        supportedLngs: {
            es: [
                "app"
            ]
        }
    }
});

define("jquery", function() { return jQuery; });
define("knockout", ko);
define("underscore", function() { return _; });
define("toastr", toastr);

define([
        "plugins/dialog", "durandal/system", "durandal/app", "durandal/viewLocator", "durandal/binder",
        "i18n!nls", "core/authentication/authenticationBroker", "core/authentication/securityContext",
        "bindings/fileUploadBinding", "bindings/updateFileUploadBinding", "bindings/select2Binding", "jquery",
        "bindings/datePickerBinding", "bindings/dateFormatBinding", "bindings/currencyFormatBinding",
        "bindings/clickAndStopBinding", "bindings/preventBubbleBinding", "bindings/validateBinding", "bindings/selectedOptionsObjectBinding"
    ],
    function(dialog, system, app, viewLocator, binder, i18n, authenticationBroker,
        securityContext, fileUploadBinding, updateFileUploadBinding, select2Binding, $,
        datePickerBinding, dateFormatBinding, currencyFormatBinding, clickAndStopBinding,
        preventBubbleBinding, validateBinding, selectedOptionsObjectBinding) {
        //>>excludeStart("build", true);
        system.debug(true);
        //>>excludeEnd("build");

        var i18NOptions = {
            detectFromHeaders: false,
            //lng: window.navigator.userLanguage || window.navigator.language || 'es-ES',
            lng: "es-ES",
            fallbackLang: "es",
            ns: "app",
            resGetPath: "app/nls/__lng__/__ns__.json",
            useCookie: false
        };

        dialog.addContext("bootstrap", {
            addHost: function(dialogInstance) {
                var body = $("body"), //style="overflow-y: scroll;"
                    host = $('<div id="durandal-modal" class="modal fade" ><div class="modal-dialog"><div class="modal-content"><div class="modal-header"><button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button></div></div></div></div>');
                host.appendTo(body);
                dialogInstance.host = host.find(".modal-content").get(0);
                dialogInstance.modalHost = host;
            },
            removeHost: function(dialogInstance) {
                $(dialogInstance.modalHost).modal("hide");
                $("body").removeClass("modal-open");
                $(".modal-backdrop").remove();
            },
            compositionComplete: function(child, parent, context) {
                var dialogInstance = dialog.getDialog(context.model),
                    $child = $(child);
                $(dialogInstance.modalHost).modal({ backdrop: "static", keyboard: false, show: true });
                //Setting a short timeout is need in IE8, otherwise we could do this straight away
                setTimeout(function() {
                    $child.find(".autofocus").first().focus();
                }, 1);
                if ($child.hasClass("autoclose") || context.model.autoclose) {
                    $(dialogInstance.blockout).click(function() {
                        dialogInstance.close();
                    });
                }
            }
        });
        //rebind dialog.show to default to a new context
        var oldShow = dialog.show;
        dialog.show = function(obj, data, context) {
            return oldShow.call(dialog, obj, data, context || "bootstrap");
        };

        ko.bindingHandlers.fileUpload = fileUploadBinding;
        ko.bindingHandlers.updateFileUpload = updateFileUploadBinding;
        ko.bindingHandlers.select2 = select2Binding;
        ko.bindingHandlers.datePicker = datePickerBinding;
        ko.bindingHandlers.dateFormat = dateFormatBinding;
        ko.bindingHandlers.currencyFormat = currencyFormatBinding;
        ko.bindingHandlers.clickAndStop = clickAndStopBinding;
        ko.bindingHandlers.preventBubble = preventBubbleBinding;
        ko.bindingHandlers.validate = validateBinding;
        ko.bindingHandlers.selectedOptionsObject = selectedOptionsObjectBinding;

        app.Title = "SNIRH";

        app.configurePlugins({
            router: true,
            dialog: true,
            toastr: true,
            widget: {
                kinds: ["grid"]
            }
        });

        app.start().then(function() {
            i18n.init(i18NOptions, function() {
                console.log(i18n);
                app.title = i18n.t("app:Title");

                //Replace 'viewmodels' in the moduleId with 'views' to locate the view.
                //Look for partial views in a 'views' folder in the root.
                viewLocator.useConvention();

                //Call localization on view before binding...
                binder.binding = function(obj, view) {
                    $(view).i18n();
                };

                app.setRoot("viewmodels/shell", "entrance");

            });

            //var userLang = i18n.detectLanguage();
            //userLang = userLang.substring(0,3) + userLang.substr(3).toUpperCase();
            // Por defecto es-ES
            var userLang = "es-ES";
            $.datepicker.setDefaults($.datepicker.regional[userLang]);
            moment.locale(userLang);
            numeral.languageData = numeral.language(userLang);
        });
    });