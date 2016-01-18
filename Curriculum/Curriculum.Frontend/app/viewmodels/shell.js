define([
    'plugins/router', 'durandal/app', 'core/broker', 'core/i18n', 'jquery', 'core/authentication/authenticationBroker', 'core/authentication/securityContext'
], function (router, app, brokerUtils, i18n, $, authenticationBroker, securityContext) {
    return {
        isLoading: ko.computed(function () {
            return brokerUtils.requestCount > 0 || router.isNavigating();
        }),
        router: router,
        brokerUtils: brokerUtils,
        i18n: i18n,
        activate: function () {
            var routes = [];

            routes = [
                { route: '', title: 'Inicio', moduleId: 'viewmodels/welcome', nav: true },
                { route: 'durandal', title: 'Durandal', moduleId: 'viewmodels/Durandal/durandal', nav: true, hash: '#durandal' },
                { route: 'sharepoint', title: 'Sharepoint', moduleId: 'viewmodels/Sharepoin/Sharepoint', nav: true, hash: '#sharepoint' },
                { route: 'csharp', title: 'C# .NET', moduleId: 'viewmodels/Csharp/Csharp', nav: true, hash: '#csharp' },
                { route: 'about', title: 'Sobre mi', moduleId: 'viewmodels/About/About', nav: true, hash: '#about' },
                { route: 'contact', title: 'Contacto', moduleId: 'viewmodels/Contact/Contact', nav: true, hash: '#contact' },

                { route: 'posts', title: 'Posts', moduleId: 'viewmodels/Posts/Posts', nav: true, hash: '#posts' },
                { route: 'showPost(/:id)(/:tag)', title: 'Posts', moduleId: 'viewmodels/Posts/showPost', nav: true, hash: '#showPost(/:id)(/:tag)' },
                { route: 'tag(/:tag)', title: 'Posts', moduleId: 'viewmodels/tag/tag', nav: true, hash: '#tag(/:tag)' },
                { route: 'category(/:cat)', title: 'Posts', moduleId: 'viewmodels/category/category', nav: true, hash: '#category(/:cat)' },
                { route: 'archives(/:year)(/:month)', title: 'Posts', moduleId: 'viewmodels/archives/archives', nav: true, hash: '#archives(/:year)(/:month)' },

                { route: '404', title: 'Posts', moduleId: 'viewmodels/404', nav: true, hash: '#404' },
            ];

            return router.map(routes).buildNavigationModel().activate();
        }
    };
});

