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

        //var pattern = allBindings.get('pattern') || 'L';
        var pattern = "L";
        if (allBindings().pattern) {
            pattern = allBindings().pattern;
        }

        if (typeof value != "function") {
            if (value && value != "") {
                element.textContent = moment(value, ["YYYY-MM-DDTHH:mm:ss", "YYYYMMDD", "DD/MM/YYYY", "YYYY-MM-DD"]).format(pattern);
            } else {
                element.textContent = "-";
            }
        } else {
            if (value() && value() != "") {
                element.textContent = moment(value(), ["YYYY-MM-DDTHH:mm:ss", "YYYYMMDD", "DD/MM/YYYY", "YYYY-MM-DD"]).format(pattern);
            } else {
                element.textContent = "-";
            }
        }

    }

    binding.init = init;
    binding.update = update;

    return binding;
});