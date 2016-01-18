/* global define: false */
define([], function testImplModule() {

    "use strict";

    var PROPERTIES = {
        ID: "Id",
        NOMBRE: "Nombre",
        DESCRIPCION: "Descripcion",
        IMPORTE: "Importe",
        FECHA: "Fecha",
        ACTIVO: "Activo"
    }

    function testImpl(currentTest) {
        var test = {},
		id = ko.observable(),
        nombre = ko.observable(),
		descripcion = ko.observable(),
        importe = ko.observable(),
        fecha = ko.observable(),
        activo = ko.observable();

        if (currentTest) {
            id(currentTest.id);
            nombre(currentTest.nombre);
            descripcion(currentTest.descripcion);
            importe(currentTest.importe);
            fecha(currentTest.fecha);
            activo(currentTest.activo);
        }

        test.id = id;
        test.nombre = nombre;
        test.descripcion = descripcion;
        test.importe = importe;
        test.fecha = fecha;
        test.activo = activo;

        return test;
    }

    testImpl.properties = PROPERTIES;

    return testImpl;

});