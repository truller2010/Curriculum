/* global define: false, ko: false, moment: false */
define(function currencyFormatBinding() {
	"use strict";

	var binding = {};

	function init(element, valueAccessor, allBindings, viewModel,
			bindingContext) {

		

	}

	function update(element, valueAccessor, allBindings, viewModel,
			bindingContext) {

		// Update the control only when clear the form
		var value = valueAccessor();
		
		
		if(value!=undefined){
			//it isn't observable
			if(typeof value != "function"){
					value = numeral(value).format('0,0.00');
			}
			//it's observable
			else {
				if(value()!= undefined){
					value = numeral(value()).format('0,0.00');
				}
				else{
					value = "-";
				}
			}
		} else {
			value = "-";
		}
		
		if (element.tagName.toLowerCase() === 'input') {
			ko.applyBindingsToNode(element, {
				value : value
			});
		} else {
			ko.applyBindingsToNode(element, {
				text : value
			});
		}
		
		
	}

	binding.init = init;
	binding.update = update;

	return binding;
});