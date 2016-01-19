/* global define: false, ko: false, moment: false */
define(["i18next"],
    function finalizadoFormatBinding(i18n) {
        "use strict";

        var binding = {};

        function init(element, valueAccessor, allBindings, viewModel,
            bindingContext) {

        }

        function update(element, valueAccessor, allBindings, viewModel,
            bindingContext) {

            // Update the control only when clear the form
            var value = valueAccessor();
            var text = "";
            if (typeof value == "function") {
                value = value();
            }

            if (value != "") {
                element.innerText = i18n.translate("YES");
            } else {
                element.innerText = i18n.translate("NO");
            }

        }

        binding.init = init;
        binding.update = update;

        return binding;
    });