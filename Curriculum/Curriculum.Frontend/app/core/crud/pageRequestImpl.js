/* global define: false */
define(function pageRequestImpl() {
    // TODO pageRequestImpl qunit

    "use strict";

    return function pageRequestImpl(page, size, sort, totalElements) {
        var pageRequest = {};

        if (totalElements != undefined) {
            while (page > 0 && page * size() >= totalElements) {
                page = page - 1;
            }
        }

        pageRequest.page = page;
        pageRequest.size = size;
        pageRequest.sort = sort;

        return pageRequest;
    };
});