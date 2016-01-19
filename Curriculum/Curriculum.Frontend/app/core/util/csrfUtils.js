/* global $: false, define: false, sjcl: false */
/**
 * Triple submit xsrf and session token csrf protection
 */
define([
    "core/authentication/securityContext", "jquery"
], function csrfUtils(securityContext, $) {
    "use strict";

    var utils = {},
        xsrfHeader = "X-Xsrf-Token",
        csrfHeader = "X-Csrf-Token",
        xsrfCookiePrefix =
            "xsrf-3",
        cookiePath = "/";

    function getXsrfToken() {
        return "0000-0000-0000-0000";
    }

    function getXsrfCookie() {
        var cookies = $.cookie(), cookie = null;

        for (cookie in cookies) {
            if (cookies.hasOwnProperty(cookie) && cookie.indexOf(xsrfCookiePrefix) === 0) {
                return cookie;
            }
        }
    }

    function createXsrfCookie() {
        var name = xsrfCookiePrefix + getXsrfToken();

        $.cookie(name, null, {
            path: cookiePath
        });

        return name;
    }

    function populateXsrfCookie(token) {
        var cookie = getXsrfCookie();
        if (!cookie) {
            cookie = createXsrfCookie();
        }

        if (cookie) {
            $.cookie.json = false;
            $.cookie(cookie, token, {
                path: cookiePath
            });
        }
    }

    function appendXsrfToXhr(xhr) {
        /*var xsrfToken = getXsrfToken();
        xhr.setRequestHeader(xsrfHeader, xsrfToken);
        populateXsrfCookie(xsrfToken);*/

        return true;
    }

    function appendCsrfToXhr(xhr) {
        //xhr.setRequestHeader(csrfHeader, securityContext.getAuthenticationToken());

        return true;
    }

    function extractCsrfFromXhr(xhr) {
        //securityContext.setAuthenticationToken(xhr.getResponseHeader(csrfHeader));

        return true;
    }

    utils.appendXsrfToXhr = appendXsrfToXhr;
    utils.appendCsrfToXhr = appendCsrfToXhr;
    utils.extractCsrfFromXhr = extractCsrfFromXhr;

    return utils;
});