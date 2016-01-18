/* global define: false, ko: false */
define(function BlogTagFilterImplModule() {
    "use strict";

    return function BlogTagFilterImpl(descripcion, activo) {
        var filter = {};

        filter.descripcion = ko.observable(descripcion);
        filter.activo = ko.observable(activo);

        return filter;
    };
});