/* global _:false, amplify: false, define: false */
define([
        "core/config", "core/i18n", "core/authentication/securityContext", "core/broker",
        "core/cacheImpl", "core/util/urlUtils",
],
function samplebeanContext(config, i18n, securityContext, brokerUtils, cacheImpl, urlUtils) {
    "use strict";

    var broker = {}, CACHE_NAME = "BlogTag", CACHE = cacheImpl();

    // cache definition
    /* jshint camelcase: false */
    amplify.request_original.cache[CACHE_NAME] = CACHE;

    // request definition
    amplify.request.define("BlogTag/save", brokerUtils.REQUEST_TYPE,
        brokerUtils
        .getReadOnlyRequestSettings(
            brokerUtils.BACKEND_URL + urlUtils.joinPath(
            brokerUtils.requestMappings.BlogTag,
            brokerUtils.requestMappings.SAVE),
            brokerUtils.verb.POST,
            CACHE_NAME));

    amplify.request.define('BlogTag/getAllPaginated', brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(
            brokerUtils.BACKEND_URL + urlUtils.joinPath(
            brokerUtils.requestMappings.BlogTag,
            brokerUtils.requestMappings.FIND),
            brokerUtils.verb.POST,
            CACHE_NAME));

    amplify.request.define("BlogTag/getAll", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(
            brokerUtils.BACKEND_URL + urlUtils.joinPath(
            brokerUtils.requestMappings.BlogTag,
            brokerUtils.requestMappings.GET_ALL),
            brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("BlogTag/get", brokerUtils.REQUEST_TYPE, brokerUtils
       .getReadOnlyRequestSettings(
           brokerUtils.BACKEND_URL + urlUtils.joinPath(
           brokerUtils.requestMappings.BlogTag,
           brokerUtils.requestMappings.GET,
           brokerUtils.requestMappings.BY_ID),
           brokerUtils.verb.GET, CACHE_NAME));

    function evictCache()
    {
        CACHE.evict();
    }

    function save(laboratorio)
    {
        return amplify.request("BlogTag/save", laboratorio).done(evictCache);
    }

    function getAll()
    {
        return amplify.request("BlogTag/getAll").done(evictCache);
    }

    function getAllPaginated(findRequest)
    {
        return amplify.request("BlogTag/getAllPaginated", findRequest).done(evictCache);
    }

    function get(id)
    {
        if (id)
        {
            return amplify.request("BlogTag/get", { id: id }).done(evictCache);
        }
        else
        {
            return null;
        }
    }

    broker.save = save;
    broker.evictCache = evictCache;
    broker.getAll = getAll;
    broker.getAllPaginated = getAllPaginated;
    broker.get = get;

    return broker;
});