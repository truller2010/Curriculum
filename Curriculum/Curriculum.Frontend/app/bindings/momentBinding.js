/* global define: false, ko: false, moment: false */
define(function momentBinding() {
    "use strict";

    var binding = {};

    function init(element, valueAccessor, allBindings, viewModel, bindingContext) {

    }

    function update(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {

        var value = valueAccessor();
        var allBindings = allBindingsAccessor();
        var valueUnwrapped = ko.utils.unwrapObservable(value);

        // Date formats: http://momentjs.com/docs/#/displaying/format/
        var pattern = allBindings.format || 'L';
        var patternFrom = allBindings.formatFrom || undefined;

        element.textContent = moment(value, patternFrom).format(pattern);
    }

    binding.init = init;
    binding.update = update;

    return binding;
});