/* global _: false, define: false, ko: false */
define(["jquery", "core/util/csrfUtils", "core/exceptionHandler", "core/util/validationUtils"],
    function select2Binding($, csrfUtils, exceptionHandler, validationUtils) {
    "use strict";

    var binding = {};

    function init(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var $element = $(element), options = ko.toJS(valueAccessor()) || {}, allBindings = allBindingsAccessor(),
            lookupKey = allBindings.lookupKey, open = allBindings.open, setValue = allBindings.setValue,
            isObservable = ko.isObservable(allBindings.options), multiple = element.multiple,
            lockedId = allBindings.lockedId, selectProperty = allBindings.selectProperty;

        function format(state) {
            if (multiple && lockedId && state.id === lockedId.toString()) {
                var $originalOption = $(state.element);
                $originalOption.data("locked", true);
                $originalOption.attr("disabled", "disabled");
                state.locked = true;
                state.disabled = true;
            }
            return state.text;
        }

        setTimeout(function doAfterBinding() {
            options.formatSelection = format;
            $element.select2(options).on("change", function (e) {
                if (e.val === undefined) {
                    return;
                }

                if (multiple) {
                    console.log(e.val);

                    if (selectProperty) {

                        

                        var options = _.filter(isObservable ? allBindings.options() : allBindings.options, setValue.bind(this, e.val));
                        
                        var selected = [];
                        _.each(options, function (element) {
                            selected.push(element[selectProperty]);
                        });

                        allBindings.selectedOptionsObject(selected);

                    } else {
                        allBindings.selectedOptionsObject(_.filter(isObservable ? allBindings.options() : allBindings.options, setValue.bind(this, e.val)));
                    }
                }
                else {
                    
                    var value = e.val;

                    if (allBindings.asInt && parseInt(value) !== NaN) {
                        value = parseInt(value);
                    }
                    
                    if (allBindings.valueObject && allBindings.valueObject() !== value) {
                        allBindings.valueObject(value);
                    }
                	//allBindings.setValue(e.val||"");
                    //allBindings.valueObject(_.find(isObservable ? allBindings.options() : allBindings.options, setValue.bind(this, e.val)));
                }
            });
            if (open && multiple) {
                // TODO descomentar para un select abierto permanetemente y poner unos 100 milisegundos al setTimeout
                /*$element.select2("open");
                $element.on("select2-close", function (e) {
                    $element.select2("open");
                });*/
            }

            if (allBindings.selectedOptionsObject) {
                if (multiple) {
                    // ldiaz - val no carga los datos en un select múltiple
                    $element.select2('data', allBindings.selectedOptionsObject()).trigger('change');
                } else {
                    $element.val(allBindings.selectedOptionsObject()).trigger('change');
                }
            }

            
            
            if (allBindings.valueObject) {
                if (ko.isObservable(allBindings.valueObject)) {
                $element.val(allBindings.valueObject()).trigger('change');

                    allBindings.valueObject.subscribe(function (newval) {
                        $element.val(newval).trigger('change');
                    });
                } else {
                    $element.val(allBindings.valueObject).trigger('change');
                }
            }
        }, 0);

        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).select2('destroy');
        });
    }
    
    function update(element, valueAccessor, allBindingsAccessor, viewModel) {
    	var $element = $(element);
    }

    binding.init = init;
    binding.update = update;

    return binding;
    });