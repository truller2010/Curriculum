/* global define: false */
define(
    ["core/crud/sortBase", "core/crud/orderImpl", "core/crud/numberOrderImpl",
        "core/crud/stringOrderImpl", "domain/BlogTag/BlogTagImpl"],
    function BlogTagSortImplModule(sortBase, orderImpl, numberOrderImpl, stringOrderImpl, BlogTagImpl) {
        "use strict";

        return function BlogTagSortImpl() {
            var sort =
                sortBase([numberOrderImpl(BlogTagImpl.properties.DESCRIPCION, 'ASC')]);

            return sort;
        };
    });