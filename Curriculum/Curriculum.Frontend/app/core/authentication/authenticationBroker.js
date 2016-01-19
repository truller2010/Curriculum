/* global amplify: false, define: false */
define([
    "core/authentication/securityContext", "core/broker", "core/cacheImpl", "core/util/urlUtils", "jquery", "core/config"
], function authenticationBroker(securityContext, brokerUtils, cacheImpl, urlUtils, $, config) {
    "use strict";

    var broker = {}, CACHE_NAME = "authentication", CACHE = cacheImpl();

    // cache definition
    /* jshint camelcase: false */
    amplify.request_original.cache[CACHE_NAME] = CACHE;

    // request definition
    amplify.request.define("authentication/setup", brokerUtils.REQUEST_TYPE, brokerUtils
        .getAuthenticationRequestSettings(brokerUtils.BACKEND_URL +
            urlUtils.joinPath("user",
                brokerUtils.requestMappings.SETUP), brokerUtils.verb.GET));

    amplify.request.define("authentication/login", brokerUtils.REQUEST_TYPE, brokerUtils
        .getAuthenticationRequestSettings(
            brokerUtils.BACKEND_URL + urlUtils.joinPath("token"),
            brokerUtils.verb.POST, CACHE_NAME));

    amplify.request.define("authentication/logout", brokerUtils.REQUEST_TYPE, brokerUtils
        .getAuthenticationRequestSettings(
            brokerUtils.BACKEND_URL + urlUtils.joinPath("user", "logout"),
            brokerUtils.verb.GET, CACHE_NAME));

    function setup() {
        return amplify.request("authentication/setup");
    }

    function login(credentials) {

        credentials["grant_type"] = "password";
        credentials["client_id"] = config.CLIENT_ID;
        credentials["client_secret"] = config.CLIENT_SECRET;

        return amplify.request("authentication/login", credentials);
    }

    function refreshToken(token) {
        var credentials = { 'refresh_token': token };

        credentials["grant_type"] = "refresh_token";
        credentials["client_id"] = config.CLIENT_ID;
        credentials["client_secret"] = config.CLIENT_SECRET;

        return amplify.request("authentication/login", credentials);
    }

    function logout() {
        var defer = $.Deferred();

        defer.resolve(true);

        return defer.promise();
    }

    // request revelation
    broker.setup = setup;
    broker.login = login;
    broker.refreshToken = refreshToken;
    broker.logout = logout;

    return broker;
});