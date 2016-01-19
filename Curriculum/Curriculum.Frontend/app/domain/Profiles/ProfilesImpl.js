/* global define: false */
define([
    "jquery",
    "core/authentication/securityContext",
    "domain/Profiles/ProfilesImpl",
], function ProfilesImplModule($, securityContext, ProfilesImpl) {
    "use strict";

    var PROPERTIES = {
        ID: "ID",
        PostTitle: "PostTitle",
        Photo: "Photo",
        ResumeText: "ResumeText ",
        PostText: "PostText",
        Created: "Created",
        CreatedBy: "CreatedBy",
        Updated: "Updated",
        UpdatedBy: "UpdatedBy",
        Deleted: "Deleted",
        DeletedBy: "DeletedBy",

    };

    function ProfilesImpl(currentProfiles) {
        var Profiles = {
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
        };

        if (currentProfiles) {

            currentProfiles = ko.mapping.fromJS(currentProfiles);

            $.extend(Profiles, currentProfiles);
        }
        return Profiles;
    }

    ProfilesImpl.properties = PROPERTIES;

    return ProfilesImpl;
});