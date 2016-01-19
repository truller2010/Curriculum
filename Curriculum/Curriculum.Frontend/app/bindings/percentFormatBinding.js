/* global define: false, ko: false, moment: false */
define(function dateFormatBinding() {
    "use strict";

    var binding = {};

    function init(element, valueAccessor, allBindings, viewModel,
        bindingContext) {


    }

    function update(element, valueAccessor, allBindings, viewModel,
        bindingContext) {

        // Update the control only when clear the form
        var value = valueAccessor();
        if (value != 0) {
            if (typeof value != "function") {
                element.textContent = numeral(value).divide(100).format("0[.][000]%");
            } else {
                element.textContent = numeral(value()).divide(100).format("0[.][000]%");
            }
        } else
            element.textContent = "\u00a0";

    }

    binding.init = init;
    binding.update = update;

    return binding;
});