/* global define: false */
define([
    'jquery',
    'core/authentication/securityContext',
    'domain/BlogCategory/BlogCategoryImpl',
], function BlogPostImplModule($, securityContext, BlogCategoryImpl) {
    "use strict";

    var PROPERTIES = {
        ID: "ID",
        PostTitle: "PostTitle",
        Photo :"Photo",
        ResumeText :"ResumeText ",
        PostText :"PostText",
        Created :"Created",
        CreatedBy :"CreatedBy",
        Updated :"Updated",
        UpdatedBy :"UpdatedBy",
        Deleted :"Deleted",
        DeletedBy :"DeletedBy",
        BlogCategory: "BlogPostCategories",
        BlogTag: "BlogPostCategories"

    }

    function BlogPostImpl(currentBlogPost) {
        var BlogPost = {
                "ID": null,
             "PostTitle": ko.observable(null),
             "Photo": ko.observable(null),
             "ResumeText ": ko.observable(null),
             "PostText": ko.observable(null),
             "Created": ko.observable(null),
             "CreatedBy": ko.observable(null),
             "Updated": ko.observable(null),
             "UpdatedBy": ko.observable(null),
             "Deleted": ko.observable(null),
             "DeletedBy": ko.observable(null),
             "BlogCategory": ko.observableArray(new BlogCategoryImpl()),
             "BlogTag": ko.observableArray(new BlogTagImpl())
        };

        if (currentBlogPost) {
            
            currentBlogPost = ko.mapping.fromJS(currentBlogPost);

            $.extend(BlogPost, currentBlogPost);
        }
        return BlogPost;
    }

    BlogPostImpl.properties = PROPERTIES;

    return BlogPostImpl;
});