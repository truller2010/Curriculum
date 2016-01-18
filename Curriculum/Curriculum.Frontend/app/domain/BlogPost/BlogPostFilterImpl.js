/* global define: false, ko: false */
define(function BlogPostFilterImplModule() {
    "use strict";

    return function BlogPostFilterImpl(texto,category,tag,id,title,month,year) {
        var filter = {};

        filter.texto = ko.observable(texto);
        filter.category = ko.observable(category);
        filter.tag = ko.observable(tag);
        filter.id = ko.observable(id);
        filter.title = ko.observable(title);
        filter.month = ko.observable(month);
        filter.year = ko.observable(year);

        return filter;

    };
});