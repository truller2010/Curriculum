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
        if (typeof value != "function" && value != "") {
            element.textContent = moment(value, "DD/MM/YYYY H:mm").format("L HH:mm");
        } else if (value() != "") {
            element.textContent = moment(value(), "DD/MM/YYYY H:mm").format("L HH:mm");
        }

    }

    binding.init = init;
    binding.update = update;

    return binding;
});