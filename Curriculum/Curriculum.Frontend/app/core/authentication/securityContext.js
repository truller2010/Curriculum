/* global _:false, amplify: false, define: false */
define(['durandal/system'], function securityContext(system) {
    // TODO QUnit securityContext
    "use strict";
    //var context = {}, CACHE_STORAGE = amplify.store.sessionStorage
    //		|| amplify.store.memory, CACHE_NAME = "authentication/context", instance = CACHE_STORAGE(CACHE_NAME)
    //		|| {}, role = {
    //	ANONYMOUS : "ROLE_ANONYMOUS",
    //	ADMINISTRATOR : "ROLE_ADMINISTRATOR"
    //};
    var context = {}, instance = {}, roles = {
        ADMIN: {
            id: 1,
            name: 'ADMIN'
        },
    };

    function save() {
        if (isRememberMe()) {
            sessionStorage.removeItem('authentication');
            localStorage.setItem('authentication', JSON.stringify(instance));
        } else {
            localStorage.removeItem('authentication');
            sessionStorage.setItem('authentication', JSON.stringify(instance));
        }
    }

    function load() {
        instance = JSON.parse(localStorage.getItem('authentication')) || JSON.parse(sessionStorage.getItem('authentication')) || {};
        console.log('Loaded identity: ', instance);
        console.log(instance);
    }

    function getPrincipal() {
        return instance.username;
    }

    function getFormattedPrincipal() {
        var principal = getPrincipal();
        if (instance.externo == 0) {
                principal += " - " + instance.roles[0];
        }
        return principal;
    }

    function getId() {
        return instance.id;
    }

    function getAuthorities() {
        return instance.authorities;
    }

    function getCredentials() {
        return instance.credentials;
    }

    function getDetails() {
        return instance.details;
    }

    function refresh(securityContext) {
        if (securityContext.access_token === undefined || securityContext.access_token === '') {
            securityContext.authenticated = false;
        }
        else {
            securityContext.authenticationToken = securityContext.access_token;
            securityContext.refreshToken = securityContext.refresh_token;
            securityContext.authenticated = true;
            securityContext.roles = securityContext.roles.split(",");
        }
        instance = securityContext;
        save();
    }

    function clear() {
        localStorage.removeItem('authentication');
        sessionStorage.removeItem('authentication');
        sessionStorage.removeItem("typeMenu");
        instance = {};
    }

    function getAuthenticationToken() {
        return instance.authenticationToken || 0;
    }

    function setAuthenticationToken(authenticationToken) {
        instance.authenticationToken = authenticationToken;
        save();
    }

    function getRefreshToken() {
        return instance.refreshToken || 0;
    }

    function setRefreshToken(refreshToken) {
        instance.refreshToken = refreshToken;
        save();
    }

    function hasRole(role) {
        return instance && instance.roles && _.find(instance.roles, function hasRole(authority) {
            return authority === role;
        }) !== undefined;
    }

    function getRoles() {
        return instance.roles;
    }

    function isAuthenticated() {
        return instance.authenticated;
    }

    function isRememberMe() {
        return instance.rememberMe;
    }

    function isAnonymous() {
        return !instance.authorities || (instance.authorities.length === 1 && instance.authorities[0].authority === role.ANONYMOUS);
    }

    function isAdministrator() {
        return hasRole(role.ADMINISTRATOR);
    }

    function isAla() {
        return hasRole(roles.ALA.name);
    }

    function isAaa() {
        return hasRole(roles.AAA.name);
    }

    function isDcprh() {
        return hasRole(roles.DCPRH.name);
    }

    function isDgcrh() {
        return hasRole(roles.DGCRH.name);
    }

    function isDarh() {
        return hasRole(roles.DARH.name);
    }

    function isPtecnico() {
        return hasRole(roles.PTECNICO.name);
    }

    function isJu() {
        return hasRole(roles.JU.name);
    }

    function isBu() {
        return hasRole(roles.BU.name);
    }

    function isAna() {
        return hasRole(roles.ANA.name);
    }

    function getIdAAA() {
        return instance.idAAA;
    }

    function getIdAla() {
        return instance.idAla;
    }

    load();

    context.roles = roles;
    context.getPrincipal = getPrincipal;
    context.getFormattedPrincipal = getFormattedPrincipal;
    context.getCredentials = getCredentials;
    context.getAuthorities = getAuthorities;
    context.getDetails = getDetails;
    context.refresh = refresh;
    context.clear = clear;
    context.getAuthenticationToken = getAuthenticationToken;
    context.setAuthenticationToken = setAuthenticationToken;
    context.getRefreshToken = getRefreshToken;
    context.setRefreshToken = setRefreshToken;
    context.hasRole = hasRole;
    context.isAnonymous = isAnonymous;
    context.isAuthenticated = isAuthenticated;
    context.isAdministrator = isAdministrator;
    context.isAla = isAla;
    context.isAaa = isAaa;
    context.isDcprh = isDcprh;
    context.isDgcrh = isDgcrh;
    context.isDarh = isDarh;
    context.isPtecnico = isPtecnico;
    context.isAna = isAna;
    context.isJu = isJu;
    context.isBu = isBu;
    context.getIdAAA = getIdAAA;
    context.getIdAla = getIdAla;
    context.getId = getId;
    context.getRoles = getRoles;

    return context;
});