/* global define: false*/
define(["core/util/arrayUtils", "core/util/stringUtils", "jquery"],
    function urlUtils(arrayUtils, stringUtils, $) {
        // TODO qunit urlUtils

        "use strict";

        var utils = {};

        function joinPath() {
            var joinedPath = arrayUtils.valueOfArguments(arguments).join("/");
            return "/" + joinedPath.replace(/\/$/g, "");
        }

        function toUrlTitle() {
            var separator = "-", title = arrayUtils.valueOfArguments(arguments).join(separator);

            return stringUtils.normalize(title).toLowerCase().replace(/[^a-zA-Z0-9]+/g, " ").trim()
                .replace(/\s+/g, separator);
        }

        function imageExists(image_url) {

            var http = new XMLHttpRequest();

            http.open("HEAD", image_url, false);
            http.send();

            return http.status != 404;

        }

        utils.joinPath = joinPath;
        utils.toUrlTitle = toUrlTitle;
        utils.imageExists = imageExists;

        return utils;
    });