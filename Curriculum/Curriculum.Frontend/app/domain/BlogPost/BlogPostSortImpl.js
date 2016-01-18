/* global define: false */
define(
    ["core/crud/sortBase", "core/crud/orderImpl", "core/crud/numberOrderImpl",
        "core/crud/stringOrderImpl", "domain/BlogPost/BlogPostImpl"],
    function BlogPostSortImplModule(sortBase, orderImpl, numberOrderImpl, stringOrderImpl, BlogPostImpl) {
        "use strict";

        return function BlogPostSortImpl() {
            var sort =
                sortBase([numberOrderImpl(BlogPostImpl.properties.ID, 'ASC')]);

            return sort;
        };
    });