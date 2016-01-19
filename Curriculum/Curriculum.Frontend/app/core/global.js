define(function globalModule() {
    "use strict";

    var global = {};

    global.tituloPagina = ko.observable();
    global.breadcrumbs = ko.observableArray([]);
    global.userNameLoged = ko.observable();
    global.userRole = ko.observable();

    return global;
});