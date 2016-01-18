/* global define: false */
define(['knockout'],
function BlogTagImplModule(ko) {
    "use strict";

    var PROPERTIES = {
        ID: "id",
        DESCRIPCION: "Descripcion",
        ACTIVO: "activo",
        FECHA_BAJA: "fechaBaja"
    }

    function BlogTagImpl(currentBlogTag)
    {
        var BlogTag = {},
            id = ko.observable(null),
            descripcion = ko.observable(null),
            activo = ko.observable(null),
            fechaBaja = ko.observable(null);

        if (currentBlogTag)
        {
            id(currentBlogTag.id);
            descripcion(currentBlogTag.descripcion);
            activo(currentBlogTag.activo);
            fechaBaja(currentBlogTag.fechaBaja);
        }
        else
        {
            activo(1);
        }

        BlogTag.id = id;
        BlogTag.descripcion = descripcion;
        BlogTag.activo = activo;
        BlogTag.fechaBaja = fechaBaja;

        return BlogTag;
    }

    BlogTagImpl.properties = PROPERTIES;

    return BlogTagImpl;
});