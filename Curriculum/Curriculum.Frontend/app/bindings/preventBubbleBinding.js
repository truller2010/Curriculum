/* global define: false, ko: false, moment: false */
define(function preventBubbleBinding() {
	"use strict";

	var binding = {};

	function init(element, valueAccessor, allBindings, viewModel,
			bindingContext) {

		var eventName = ko.utils.unwrapObservable(valueAccessor());
        ko.utils.registerEventHandler(element, eventName, function(event) {
           event.cancelBubble = true;
           if (event.stopPropagation) {
                event.stopPropagation();
           }                
        });
        
	}

	function update(element, valueAccessor, allBindings, viewModel,
			bindingContext) {
		
	}

	binding.init = init;
	binding.update = update;

	return binding;
});