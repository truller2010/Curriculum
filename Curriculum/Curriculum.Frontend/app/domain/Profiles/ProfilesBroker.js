/* global _:false, amplify: false, define: false */
define([
        "core/config", "core/i18n", "core/authentication/securityContext", "core/broker",
        "core/cacheImpl", "core/util/urlUtils",
    ],
    function samplebeanContext(config, i18n, securityContext, brokerUtils, cacheImpl, urlUtils) {
        "use strict";

        var broker = {}, CACHE_NAME = "Profiles", CACHE = cacheImpl();

        // cache definition
        /* jshint camelcase: false */
        amplify.request_original.cache[CACHE_NAME] = CACHE;

        // request definition
        amplify.request.define("Profiles/save", brokerUtils.REQUEST_TYPE,
            brokerUtils
            .getReadOnlyRequestSettings(
                brokerUtils.BACKEND_URL + urlUtils.joinPath(
                    brokerUtils.requestMappings.Profiles,
                    brokerUtils.requestMappings.SAVE),
                brokerUtils.verb.POST,
                CACHE_NAME));

        amplify.request.define("Profiles/getAllPaginated", brokerUtils.REQUEST_TYPE, brokerUtils
            .getReadOnlyRequestSettings(
                brokerUtils.BACKEND_URL + urlUtils.joinPath(
                    brokerUtils.requestMappings.Profiles,
                    brokerUtils.requestMappings.FIND),
                brokerUtils.verb.POST,
                CACHE_NAME));

        amplify.request.define("Profiles/getAll", brokerUtils.REQUEST_TYPE, brokerUtils
            .getReadOnlyRequestSettings(
                brokerUtils.BACKEND_URL + urlUtils.joinPath(
                    brokerUtils.requestMappings.Profiles,
                    brokerUtils.requestMappings.GET_ALL),
                brokerUtils.verb.GET, CACHE_NAME));

        amplify.request.define("Profiles/get", brokerUtils.REQUEST_TYPE, brokerUtils
            .getReadOnlyRequestSettings(
                brokerUtils.BACKEND_URL + urlUtils.joinPath(
                    brokerUtils.requestMappings.Profiles,
                    brokerUtils.requestMappings.GET,
                    brokerUtils.requestMappings.BY_ID),
                brokerUtils.verb.GET, CACHE_NAME));


        function evictCache() {
            CACHE.evict();
        }

        function save(laboratorio) {
            return amplify.request("Profiles/save", laboratorio).done(evictCache);
        }

        function getAll() {
            return amplify.request("Profiles/getAll").done(evictCache);
        }

        function get(id) {
            if (id) {
                return amplify.request("Profiles/get", { id: id }).done(evictCache);
            } else {
                return null;
            }
        }

        function getAllPaginated(findRequest) {

            return amplify.request("Profiles/getAllPaginated", findRequest).done(evictCache);
        }



        broker.save = save;
        broker.evictCache = evictCache;
        broker.getAll = getAll;
        broker.getAllPaginated = getAllPaginated;
        broker.get = get;

        return broker;
    });