/* global _: false, define: false, ko: false */
define([
    "jquery", "core/util/csrfUtils", "core/exceptionHandler", "core/util/validationUtils"
], function updateFileUploadBinding($, csrfUtils, exceptionHandler, validationUtils) {
    "use strict";

    var binding = {};

    function init(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {

        var underlyingValueObservable = valueAccessor().values,
            interceptor =
                ko.computed({
                    read: function read() {
                        return underlyingValueObservable;
                    },
                    write: function write(rawValue) {

                        underlyingValueObservable.valueHasMutated();

                        //refresh fileupload binding to refresh the key: idBrand 
                        if (document.getElementsByClassName("input-file-jobfiles")[0]) {
                            ko.cleanNode(document.getElementsByClassName("input-file-jobfiles")[0]);
                            ko.applyBindings(viewModel, document.getElementsByClassName("input-file-jobfiles")[0]);
                        }


                    }
                });


        ko.applyBindingsToNode(element, {
            value: interceptor
        });


    }

    binding.init = init;

    return binding;
});