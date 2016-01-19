define(
    [
        "core/authentication/securityContext", "i18next", "core/util/csrfUtils",
        "core/exceptionHandler", "durandal/app", "viewmodels/alerts", "core/config", "knockout", "jquery"
    ],
    function brokerUtils(securityContext, i18n, csrfUtils, exceptionHandler, app, alerts, config, ko, $) {
        "use strict";
        var utils = {},
            HASH_CHAR = "#",
            BASE_URL = config.BASE_URL,
            BACKEND_URL = BASE_URL + "/api",
            FRONTEND_URL = config.BASE_FRONT_URL,
            currentRequests = ko.observable(0),

            requestMappings = {
                AUTHENTICATION: "/user",
                GET_ALL_PAGINATED: "GetAllPaginated",
                PAGINATED: "Paginated",
                FIND: "Find",
                URL: "url",
                FIND_ALL: "FindAll",
                BY_ID: "{id}",

                SETUP: "setup",
                LOGIN: "login",
                LOGOUT: "logout",

                GET: "Get",
                GET_ALL: "GetAll",
                SAVE: "Save",
                UPDATE: "Update",

                //BlogPost
                Profiles: "Profiles",
            },

            requestCount = ko.observable(0),

            REQUEST_TYPE = "ajax",
            verb = { HEAD: "HEAD", GET: "GET", POST: "POST", PUT: "PUT", DELETE: "DELETE" },
            CONTENT_TYPE = "application/json; charset=utf-8",
            CONTENT_TYPE_WWW_FORM_ENCODED = "application/x-www-form-urlencoded; charset=UTF-8",
            DATA_TYPE = "json",
            CONTENT_TYPE_MULTIPART = "multipart/form-data;",
            DATA_TYPE_FORMDATA = "form-data",
            DEFAULT_CACHE_TIMEOUT = config.DEFAULT_CACHE_TIMEOUT,
            EXCEPTION_HANDLER_DECODER = "exceptionHandler",
            previousRequestMoment = null,
            ALERT_CLEARING_INTERVAL = 5000,

            bgRequests = [
                "fichaInventarioBase/getTotalesTecnico",
                "fichaInventarioBase/getTotalesDCPRH",
                "fichaInventarioBase/getTotalesDARH",
                "fichaInventarioBase/getTotalesAAA",
                "fichaInventarioBase/getTotalesALA",
                "monitoreosPiezometricos/getTotales",
                "mediciones/getTotales",
                "monitoreosHidroquimicos/getTotales",
                "getTotalesAprobarInicioActividad",
                "getTotalesDeclararEnergiaProducida",
                "getTotalesVolumenesPendientesValidacion",
                "getTotalesVolumenesPendientesDeclaracion",
                "Recibos/GetTotalRecibosImpagados",
                "ConsultarAutorizacionesVencidas/getTotales",
                "monitoreosCalidad/getTotalesCurso",
                "monitoreosCalidad/getTotalesValidar",
                "monitoreosCalidad/getTotalesRevisar",
                "FichaDerechoUso/findByCur",
                "declaracionVolumen/getTotales"
            ];

        amplify.subscribe("request.before", function incrementRequestCount(settings) {
            if (!_.contains(bgRequests, settings.resourceId)) {
                currentRequests(currentRequests() + 1);
            }
        });

        amplify.subscribe("request.complete", function incrementRequestCount(settings, data, status) {
            if (!_.contains(bgRequests, settings.resourceId)) {
                if (currentRequests() > 0) {
                    currentRequests(currentRequests() - 1);
                }
            }
        });

        function doBefore(xhr) {
            var actualMoment = moment(), difference;
            if (previousRequestMoment) {
                difference = moment().diff(previousRequestMoment);
                if (difference > ALERT_CLEARING_INTERVAL) {
                    alerts.removeAllAlerts();
                }
            }
            previousRequestMoment = actualMoment;

            xhr.setRequestHeader("Authorization", "Bearer " + securityContext.getAuthenticationToken());

            return csrfUtils.appendXsrfToXhr(xhr) && csrfUtils.appendCsrfToXhr(xhr);
        }

        function beforeWrite(xhr) {
            xhr.write = true;
            xhr.splash = true;

            return doBefore(xhr);
        }

        function beforeRead(xhr) {
            xhr.read = true;
            xhr.splash = true;

            return doBefore(xhr);
        }

        function beforeReadNoSplash(xhr) {
            xhr.read = true;
            xhr.splash = false;

            return doBefore(xhr);
        }

        function beforeAuthentication(xhr) {
            xhr.authentication = true;
            xhr.splash = true;

            return doBefore(xhr);
        }

        function dataMap(data) {
            return _.isEmpty(data) ? undefined : ko.mapping.toJSON(data);
        }

        amplify.request.decoders.exceptionHandler =
            function handler(data, status, xhr, success, error, settings) {
                if (status === "success") {
                    handleOk(data, status, xhr, success);
                } else if (xhr.status === 401) {
                    handleUnauthorized(xhr, settings);
                } else if (xhr.status === 400) {
                    handleBadRequest(data, status, error, xhr);
                } else if (xhr.status === 409) {
                    handleConflict(xhr);
                } else if (xhr.status === 500) {
                    handleInternalServerError(data, status, error);
                } else if (status !== "nocontent") {
                    handleInternalServerError(data, status, error);
                }
            };

        function handleOk(data, status, xhr, success) {
            success(data, status);
            if (xhr.write || data === "download" || data === "send") {
                alerts.removeAllAlerts();
                alerts.success(i18n.t("SUCCESS_ALERT_TEXT"));
            }
        }

        function handleBadRequest(data, status, error, xhr) {
            if (data) {
                error(data, status);

                if (xhr.authentication) {
                    data.exceptionType = "System.AuthenticationError";
                } else {
                    data.exceptionType = "System.ValidationError";
                }

                exceptionHandler.handle({
                    status: "fail",
                    data: data
                });
            }
        }

        function handleUnauthorized(xhr, settings) {
            if (xhr.authentication) {
                securityContext.clear();

                exceptionHandler
                    .handle({
                        status: "fail",
                        data: {
                            exceptionType: "errors.BadCredentialsException"
                        }
                    });
            } else {
                var authBroker = require("core/authentication/authenticationBroker");

                return authBroker.refreshToken(securityContext.getRefreshToken()).done(function(data) {
                    securityContext.refresh(data);

                    return $.ajax(settings);
                });
            }
        }

        function handleConflict(xhr) {
            securityContext.clear();
            if (xhr.login || !xhr.authentication) {
                exceptionHandler
                    .handle({
                        status: "fail",
                        data: {
                            exceptionType: "errors.SessionAuthenticationException"
                        }
                    });
            }
        }

        function handleInternalServerError(data, status, error) {
            if (data) {
                error(data, status);

                exceptionHandler.handle({
                    status: "fail",
                    data: data
                });
            } else {
                exceptionHandler
                    .handle({
                        status: "fail",
                        data: {
                            exceptionType: "System.Exception"
                        }
                    });
            }
        }

        function getUploadFileRequestSettings(url, verb, cacheName) {
            return {
                type: verb,
                url: url,
                contentType: false,
                processData: false,
                beforeSend: beforeRead,
                decoder: EXCEPTION_HANDLER_DECODER
            };
        }

        function getReadOnlyRequestSettings(url, verb, cacheName, cacheExpires) {
            return {
                url: url,
                beforeSend: beforeRead,
                crossDomain: true,
                type: verb,
                contentType: CONTENT_TYPE,
                dataType: DATA_TYPE,
                cache: {
                    type: cacheName ? cacheName : undefined,
                    expires: cacheExpires ? cacheExpires : DEFAULT_CACHE_TIMEOUT
                },
                dataMap: dataMap,
                decoder: EXCEPTION_HANDLER_DECODER
            };
        }

        function getBinaryRequestSettings(url, verb, cacheName, cacheExpires) {
            return {
                url: url,
                beforeSend: beforeRead,
                crossDomain: true,
                type: verb,
                contentType: CONTENT_TYPE,
                dataType: "binary",
                responseType: "arraybuffer",
                dataMap: dataMap,
                decoder: EXCEPTION_HANDLER_DECODER
            };
        }

        function getReadOnlyRequestSettingsNoData(url, verb, cacheName, cacheExpires) {
            return {
                url: url,
                beforeSend: beforeRead,
                crossDomain: true,
                type: verb,
                contentType: CONTENT_TYPE,
                //dataType: DATA_TYPE,
                cache: {
                    type: cacheName ? cacheName : undefined,
                    expires: cacheExpires ? cacheExpires : DEFAULT_CACHE_TIMEOUT
                },
                dataMap: dataMap,
                decoder: EXCEPTION_HANDLER_DECODER
            };
        }

        function getReadOnlyRequestSettingsNoSplash(url, verb, cacheName, cacheExpires) {
            return {
                url: url,
                beforeSend: beforeReadNoSplash,
                crossDomain: true,
                type: verb,
                contentType: CONTENT_TYPE,
                dataType: DATA_TYPE,
                cache: {
                    type: cacheName ? cacheName : undefined,
                    expires: cacheExpires ? cacheExpires : DEFAULT_CACHE_TIMEOUT
                },
                dataMap: dataMap,
                decoder: EXCEPTION_HANDLER_DECODER
            };
        }

        function getWriteRequestSettings(url, verb) {
            return {
                url: url,
                beforeSend: beforeWrite,
                type: verb,
                contentType: CONTENT_TYPE,
                dataType: DATA_TYPE,
                dataMap: dataMap,
                decoder: EXCEPTION_HANDLER_DECODER
            };
        }

        function getAuthenticationRequestSettings(url, verb) {
            return {
                url: url,
                beforeSend: beforeAuthentication,
                dataType: DATA_TYPE,
                contentType: CONTENT_TYPE_WWW_FORM_ENCODED,
                type: verb,
                decoder: EXCEPTION_HANDLER_DECODER
            };
        }

        utils.HASH_CHAR = HASH_CHAR;
        utils.BACKEND_URL = BACKEND_URL;
        utils.FRONTEND_URL = FRONTEND_URL;
        utils.requestMappings = requestMappings;
        utils.REQUEST_TYPE = REQUEST_TYPE;
        utils.verb = verb;
        utils.CONTENT_TYPE = CONTENT_TYPE;
        utils.DATA_TYPE = DATA_TYPE;
        utils.EXCEPTION_HANDLER_DECODER = EXCEPTION_HANDLER_DECODER;

        utils.DATA_MAP_CALLBACK = dataMap;
        utils.getReadOnlyRequestSettings = getReadOnlyRequestSettings;
        utils.getReadOnlyRequestSettingsNoData = getReadOnlyRequestSettingsNoData;
        utils.getReadOnlyRequestSettingsNoSplash = getReadOnlyRequestSettingsNoSplash;
        utils.getUploadFileRequestSettings = getUploadFileRequestSettings;
        utils.getWriteRequestSettings = getWriteRequestSettings;
        utils.getAuthenticationRequestSettings = getAuthenticationRequestSettings;
        utils.currentRequests = currentRequests;
        utils.getBinaryRequestSettings = getBinaryRequestSettings;

        return utils;
    });