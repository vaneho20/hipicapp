/* global amplify: false, define: false */
define(function securityContext() {
    // TODO QUnit securityContext

    "use strict";

    var context = {}, CACHE_TIMEOUT = 1800000, CACHE_NAME = "authentication/context",
        CACHE_STORAGE = amplify.store.localStorage(CACHE_NAME) ? amplify.store.localStorage : amplify.store.sessionStorage,
        instance = ko.observable(CACHE_STORAGE(CACHE_NAME) || {}), role = {
            ADMINISTRATOR: "ADMINISTRATOR",
            ATHLETE: "ATHLETE",
            ANONYMOUS: "ANONYMOUS"
        };

    function hasRole(role) {
        return instance() && instance().roles &&
            _.find(instance().roles, function hasRole(authority) {
                return authority === role;
            });
    }

    function isCacheStorage() {
        return CACHE_STORAGE(CACHE_NAME);
    }

    function isAuthenticated() {
        return isCacheStorage() && instance() && instance().authenticated;
    }

    function isAdministrator() {
        return hasRole(role.ADMINISTRATOR);
    }

    function isAthlete() {
        return hasRole(role.ATHLETE);
    }

    function isRememberMe() {
        return instance.rememberMe;
    }

    function getPrincipal() {
        return instance();
    }

    function getAuthorities() {
        return instance().authorities;
    }

    function getCredentials() {
        return instance().credentials;
    }

    function getDetails() {
        return instance.details;
    }

    function getAuthenticationToken() {
        return (isCacheStorage() && instance() && instance().authenticationToken) || 0;
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
        instance(securityContext);
        if (isRememberMe()) {
            CACHE_STORAGE = amplify.store.localStorage;
            amplify.store.sessionStorage(CACHE_NAME, null);
        } else {
            CACHE_STORAGE = amplify.store.sessionStorage;
            amplify.store.localStorage(CACHE_NAME, null);
        }
        CACHE_STORAGE(CACHE_NAME, instance(), {
            expires: CACHE_TIMEOUT
        });
    }

    function clear() {
        if (isRememberMe()) {
            CACHE_STORAGE = amplify.store.localStorage;
        } else {
            CACHE_STORAGE = amplify.store.sessionStorage;
        }
        CACHE_STORAGE(CACHE_NAME, null);
        instance(null);
    }

    context.role = role;
    context.isAuthenticated = isAuthenticated;
    context.isAdministrator = isAdministrator;
    context.isAthlete = isAthlete;
    context.getPrincipal = getPrincipal;
    context.getCredentials = getCredentials;
    context.getAuthorities = getAuthorities;
    context.getDetails = getDetails;
    context.getAuthenticationToken = getAuthenticationToken;
    context.refresh = refresh;
    context.clear = clear;

    return context;
});