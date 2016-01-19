define([
    "plugins/router", "durandal/app", "core/broker", "core/i18n", "jquery", "core/authentication/authenticationBroker", "core/authentication/securityContext"
], function(router, app, brokerUtils, i18n, $, authenticationBroker, securityContext) {
    return {
        isLoading: ko.computed(function() {
            return brokerUtils.requestCount > 0 || router.isNavigating();
        }),
        router: router,
        brokerUtils: brokerUtils,
        i18n: i18n,
        activate: function() {
            var routes = [];

            routes = [
                { route: "", title: "Inicio", moduleId: "viewmodels/welcome", nav: true },
                { route: "profiles", title: "Posts", moduleId: "viewmodels/profiles/profiles", nav: true, hash: "#profiles" },
                { route: "404", title: "Posts", moduleId: "viewmodels/404", nav: true, hash: "#404" },
            ];

            return router.map(routes).buildNavigationModel().activate();
        },
        attached: function() {

        }
    };
});