/* global define: false, ko: false, moment: false */
define(["jquery"], function zoomElevateBinding($) {
	"use strict";

	var binding = {};

	function init(element, valueAccessor, allBindings, viewModel,
			bindingContext) {
		
		// Apply zoom elevate
		var url = viewModel.pathLocationImg+valueAccessor();
		$(element).attr( "data-zoom-image", url);
		$(element).elevateZoom({cursor: 'pointer'});
	}

	function update(element, valueAccessor, allBindingsAccessor, viewModel,
			bindingContext) {

	}

	binding.init = init;
	binding.update = update;

	return binding;
});