/* global define: false */
define(
    ["core/crud/sortBase", "core/crud/orderImpl", "core/crud/numberOrderImpl",
        "core/crud/stringOrderImpl", "domain/BlogCategory/BlogCategoryImpl"],
    function BlogCategorySortImplModule(sortBase, orderImpl, numberOrderImpl, stringOrderImpl, BlogCategoryImpl) {
        "use strict";

        return function BlogCategorySortImpl() {
            var sort =
                sortBase([numberOrderImpl(BlogCategoryImpl.properties.DESCRIPCION, 'ASC')]);

            return sort;
        };
    });