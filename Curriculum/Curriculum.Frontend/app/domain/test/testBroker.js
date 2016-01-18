/* global _:false, amplify: false, define: false */
define([
        "core/config", "core/i18n", "core/authentication/securityContext", "core/broker",
        "core/cacheImpl", "core/util/urlUtils",
],
function samplebeanContext(config, i18n, securityContext, brokerUtils, cacheImpl, urlUtils) {
    "use strict";

    var broker = {}, CACHE_NAME = "test", CACHE = cacheImpl();

    // cache definition
    /* jshint camelcase: false */
    amplify.request_original.cache[CACHE_NAME] = CACHE;

    // request definition
    amplify.request.define("test/getAll", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(
            brokerUtils.BACKEND_URL + urlUtils.joinPath(brokerUtils.requestMappings.TEST, brokerUtils.requestMappings.GET_ALL_TEST),
            brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("test/getAllPaginated", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(
            brokerUtils.BACKEND_URL + urlUtils.joinPath(brokerUtils.requestMappings.TEST, brokerUtils.requestMappings.GET_ALL_PAGINATED),
            brokerUtils.verb.POST, CACHE_NAME));

    function evictCache() {
        CACHE.evict();
    }

    function getAll() {
        return amplify.request("test/getAll").done(evictCache);
    }

    function getAllPaginated(findRequest) {
        return amplify.request("test/getAllPaginated", findRequest).done(evictCache);
    }

    broker.evictCache = evictCache;
    broker.getAll = getAll;
    broker.getAllPaginated = getAllPaginated;

    return broker;


});
