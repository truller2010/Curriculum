/* global define: false */
define(
    [
        "core/crud/sortBase", "core/crud/orderImpl", "core/crud/numberOrderImpl",
        "core/crud/stringOrderImpl", "domain/Profiles/ProfilesImpl"
    ],
    function ProfilesSortImplModule(sortBase, orderImpl, numberOrderImpl, stringOrderImpl, ProfilesImpl) {
        "use strict";

        return function ProfilesSortImpl() {
            var sort =
                sortBase([numberOrderImpl(ProfilesImpl.properties.ID, "ASC")]);

            return sort;
        };
    });