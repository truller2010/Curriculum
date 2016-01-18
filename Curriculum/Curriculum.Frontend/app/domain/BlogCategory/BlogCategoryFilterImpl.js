/* global define: false, ko: false */
define(function BlogCategoryFilterImplModule() {
    "use strict";

    return function BlogCategoryFilterImpl(descripcion, activo) {
        var filter = {};

        filter.descripcion = ko.observable(descripcion);
        filter.activo = ko.observable(activo);

        return filter;
    };
});