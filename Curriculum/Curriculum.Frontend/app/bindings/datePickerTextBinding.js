/* global define: false, ko: false, moment: false */
define(function datePickerBinding() {
	"use strict";

	var binding = {};

	function update(element, valueAccessor, allBindings, viewModel,
			bindingContext) {

		// Update the control only when clear the form
		var value = valueAccessor();
		
		if(value()){
			element.value= moment(value(), ["YYYYMMDD", "YYYY-MM-DD", "DD/MM/YYYY"]).format("DD/MM/YYYY");
		}else{
			element.value= value();
		}
	}

	binding.update = update;

	return binding;
});