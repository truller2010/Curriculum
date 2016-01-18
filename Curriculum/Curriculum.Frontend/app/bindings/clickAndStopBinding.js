/* global define: false, ko: false, moment: false */
define(function clickAndStopBinding() {
	"use strict";

	var binding = {};

	function init(element, valueAccessor, allBindings, viewModel,
			bindingContext) {

		var handler = ko.utils.unwrapObservable(valueAccessor()),
        newValueAccessor = function() {
            return function(data, event) {
                handler.call(viewModel, data, event);
                event.cancelBubble = true;
                if (event.stopPropagation) event.stopPropagation();
            };
        };

        ko.bindingHandlers.click.init(element, newValueAccessor, allBindings, viewModel, bindingContext); 
	}

	function update(element, valueAccessor, allBindings, viewModel,
			bindingContext) {
		
	}

	binding.init = init;
	binding.update = update;

	return binding;
});