/* global define: false, ko: false, moment: false */
define(function bootstrapPopoverBinding() {
	"use strict";

	var binding = {};

	function init(element, valueAccessor, allBindings, viewModel,
			bindingContext) {
		
        ko.utils.registerEventHandler(element, 'click', function(event) {
           event.cancelBubble = true;
           if (event.stopPropagation) {
                event.stopPropagation();
           }                
        });
        
        ko.bindingHandlers.popover.init(element, valueAccessor, allBindings, viewModel, bindingContext); 
	}

	function update(element, valueAccessor, allBindings, viewModel,
			bindingContext) {
		
	}

	binding.init = init;
	binding.update = update;

	return binding;
});