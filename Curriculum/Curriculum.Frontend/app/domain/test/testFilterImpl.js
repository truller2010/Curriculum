/* global define: false, ko: false */
define(function testFilterImplModule() {

    "use strict";

    return function testFilterImpl(nombre, activo) {
        var filter = {};

        filter.nombre = ko.observable(nombre);
        filter.activo = ko.observable(activo);

        return filter;
    };
});