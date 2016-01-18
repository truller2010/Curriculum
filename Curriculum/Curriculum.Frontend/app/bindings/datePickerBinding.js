/* global define: false, ko: false, moment: false */
define(function datePickerBinding() {
    "use strict";

    var binding = {};

    function init(element, valueAccessor, allBindingsAccessor) {
        //initialize datepicker with some optional options
        var options = allBindingsAccessor().datePickerOptions || {};
        $(element).datetimepicker(options);

        //when a user changes the date, update the view model
        ko.utils.registerEventHandler(element, "changeDate", function (event) {
            var value = valueAccessor();
            if (ko.isObservable(value)) {
                value(event.date);
            }
        });

        // Register change callbacks to update the model
        // if the control changes.
        /*ko.utils.registerEventHandler(element, "change",
				function() {
					var value = valueAccessor();
					if (element.value) {
						var formated = moment(element.value, ["L", "YYYY-MM-DD"]).format("DD/MM/YYYY");
						value(formated);
					}else{
						value(null);
					}
				});*/
    }

    function update(element, valueAccessor) {
        var widget = $(element).data("datetimepicker");
        //when the view model is updated, update the widget
        if (widget) {
            widget.date = ko.utils.unwrapObservable(valueAccessor());
            widget.setValue();
        }
        /*var value = valueAccessor();

		// Always Update
		if (typeof value() !== "undefined") {
			element.value = value();
		}*/
    }

    binding.init = init;
    binding.update = update;

    return binding;
});