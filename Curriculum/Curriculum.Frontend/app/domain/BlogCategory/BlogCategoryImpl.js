/* global define: false */
define(['jquery', 'core/authentication/securityContext',
], function BlogCategoryImplModule($, securityContext) {
    "use strict";

    var PROPERTIES = {
        ID: "ID",
        CategoryName: "CategoryName"

    }

    function BlogCategoryImpl(currentBlogCategory) {
        var BlogCategory = {
            "ID": null,
            "CategoryName": ko.observable(null),
        };

        if (currentBlogCategory) {
            
            currentBlogCategory = ko.mapping.fromJS(currentBlogCategory);

            $.extend(BlogCategory, currentBlogCategory);
        }
        return BlogCategory;
    }

    BlogCategoryImpl.properties = PROPERTIES;

    return BlogCategoryImpl;
});