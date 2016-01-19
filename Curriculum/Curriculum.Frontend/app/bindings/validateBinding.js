/* global _: false, define: false, ko: false */
define(["jquery", "knockout"],
    function validateBinding($, ko) {
        "use strict";

        var binding = {};


        function init(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var rules = ko.toJS(valueAccessor()) || {};
            var $element = $(element);
            $element.parents("form").validate();

            if ($element.rules) {
                $element.rules("add", rules);
            }
        }

        function update(element, valueAccessor, allBindingsAccessor, viewModel) {

        }

        binding.init = init;
        binding.update = update;

        return binding;

    });