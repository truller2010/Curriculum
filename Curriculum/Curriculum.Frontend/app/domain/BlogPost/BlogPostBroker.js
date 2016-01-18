/* global _:false, amplify: false, define: false */
define([
        "core/config", "core/i18n", "core/authentication/securityContext", "core/broker",
        "core/cacheImpl", "core/util/urlUtils",
],
function samplebeanContext(config, i18n, securityContext, brokerUtils, cacheImpl, urlUtils) {
    "use strict";

    var broker = {}, CACHE_NAME = "BlogPost", CACHE = cacheImpl();

    // cache definition
    /* jshint camelcase: false */
    amplify.request_original.cache[CACHE_NAME] = CACHE;

    // request definition
    amplify.request.define("BlogPost/save", brokerUtils.REQUEST_TYPE,
        brokerUtils
        .getReadOnlyRequestSettings(
            brokerUtils.BACKEND_URL + urlUtils.joinPath(
            brokerUtils.requestMappings.BlogPost,
            brokerUtils.requestMappings.SAVE),
            brokerUtils.verb.POST,
            CACHE_NAME));

    amplify.request.define('BlogPost/getAllPaginated', brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(
            brokerUtils.BACKEND_URL + urlUtils.joinPath(
            brokerUtils.requestMappings.BlogPost,
            brokerUtils.requestMappings.FIND),
            brokerUtils.verb.POST,
            CACHE_NAME));

    amplify.request.define('BlogPost/getAllPaginatedByTag', brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(
            brokerUtils.BACKEND_URL + urlUtils.joinPath(
            brokerUtils.requestMappings.BlogPost,
            brokerUtils.requestMappings.FindByTag),
            brokerUtils.verb.POST,
            CACHE_NAME));

    amplify.request.define('BlogPost/getAllPaginatedByCategory', brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(
            brokerUtils.BACKEND_URL + urlUtils.joinPath(
            brokerUtils.requestMappings.BlogPost,
            brokerUtils.requestMappings.FindByCategory),
            brokerUtils.verb.POST,
            CACHE_NAME));

    amplify.request.define('BlogPost/getAllPaginatedByIdTitle', brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(
            brokerUtils.BACKEND_URL + urlUtils.joinPath(
            brokerUtils.requestMappings.BlogPost,
            brokerUtils.requestMappings.FindByIdTitle),
            brokerUtils.verb.POST,
            CACHE_NAME));
    amplify.request.define('BlogPost/getAllPaginatedByArchives', brokerUtils.REQUEST_TYPE, brokerUtils
    .getReadOnlyRequestSettings(
        brokerUtils.BACKEND_URL + urlUtils.joinPath(
        brokerUtils.requestMappings.BlogPost,
        brokerUtils.requestMappings.FindByArchives),
        brokerUtils.verb.POST,
        CACHE_NAME));

    



    amplify.request.define("BlogPost/getAll", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(
            brokerUtils.BACKEND_URL + urlUtils.joinPath(
            brokerUtils.requestMappings.BlogPost,
            brokerUtils.requestMappings.GET_ALL),
            brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("BlogPost/get", brokerUtils.REQUEST_TYPE, brokerUtils
       .getReadOnlyRequestSettings(
           brokerUtils.BACKEND_URL + urlUtils.joinPath(
           brokerUtils.requestMappings.BlogPost,
           brokerUtils.requestMappings.GET,
           brokerUtils.requestMappings.BY_ID),
           brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("BlogPost/getArchives", brokerUtils.REQUEST_TYPE, brokerUtils
       .getReadOnlyRequestSettings(
           brokerUtils.BACKEND_URL + urlUtils.joinPath(
           brokerUtils.requestMappings.BlogPost,
           brokerUtils.requestMappings.GET_ARCHIVES),
           brokerUtils.verb.GET, CACHE_NAME));

    function evictCache()
    {
        CACHE.evict();
    }

    function save(laboratorio)
    {
        return amplify.request("BlogPost/save", laboratorio).done(evictCache);
    }

    function getAll()
    {
        return amplify.request("BlogPost/getAll").done(evictCache);
    }

    function get(id) {
        if (id) {
            return amplify.request("BlogPost/get", { id: id }).done(evictCache);
        }
        else {
            return null;
        }
    }

    function getArchives() {
        return amplify.request("BlogPost/getArchives").done(evictCache);
    }

    function getAllPaginated(findRequest) {
        
        return amplify.request("BlogPost/getAllPaginated", findRequest).done(evictCache);
    }

    function getAllPaginatedByTag(findRequest) {

        return amplify.request("BlogPost/getAllPaginatedByTag", findRequest).done(evictCache);
    }

    function getAllPaginatedByCategory(findRequest) {

        return amplify.request("BlogPost/getAllPaginatedByCategory", findRequest).done(evictCache);
    }
    function getAllPaginatedByIdTitle(findRequest) {

        return amplify.request("BlogPost/getAllPaginatedByIdTitle", findRequest).done(evictCache);
    } 

    function getAllPaginatedByArchives(findRequest) {

        return amplify.request("BlogPost/getAllPaginatedByArchives", findRequest).done(evictCache);
    } 


    broker.save = save;
    broker.evictCache = evictCache;
    broker.getAll = getAll;
    broker.getAllPaginated = getAllPaginated;
    broker.getAllPaginatedByTag = getAllPaginatedByTag;
    broker.getAllPaginatedByCategory = getAllPaginatedByCategory;
    broker.getAllPaginatedByIdTitle = getAllPaginatedByIdTitle;
    broker.getAllPaginatedByArchives = getAllPaginatedByArchives;
    broker.getArchives = getArchives;
    broker.get = get;

    return broker;
});