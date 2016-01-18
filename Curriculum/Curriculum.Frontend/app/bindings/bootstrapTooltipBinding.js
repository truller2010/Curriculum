/* global define: false, ko: false, moment: false */
define(function bootstrapTooltipBinding() {
	"use strict";

	var binding = {};

	function init(element, valueAccessor, allBindings, viewModel,
			bindingContext) {
		
      ko.utils.registerEventHandler(element, 'mouseenter', function(event) {
    	 
           event.cancelBubble = true;
           if (event.stopPropagation) {
                event.stopPropagation();
           }                
        });
        
    
        ko.bindingHandlers.tooltip.update(element, valueAccessor, allBindings, viewModel, bindingContext); 
   
	}

	function update(element, valueAccessor, allBindings, viewModel,
			bindingContext) {
		
	}

	binding.init = init;
	binding.update = update;

	return binding;
});