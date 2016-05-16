/* global amplify: false, define: false */
define([
    "core/broker", "core/cacheImpl", "core/config", "core/util/urlUtils"
], function authenticationBroker(brokerUtils, cacheImpl, config, urlUtils) {
    "use strict";

    var broker = {}, CACHE_NAME = "authentication", CACHE = cacheImpl();

    // cache definition
    /* jshint camelcase: false */
    amplify.request_original.cache[CACHE_NAME] = CACHE;

    // request definition
    amplify.request.define("authentication/setup", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(urlUtils.joinPath(brokerUtils.requestMappings.BACKEND,
            brokerUtils.requestMappings.AUTHENTICATION, brokerUtils.requestMappings.SETUP),
            brokerUtils.verb.POST), CACHE_NAME);

    amplify.request.define("authentication/login", brokerUtils.REQUEST_TYPE, brokerUtils
        .getLoginRequestSettings(urlUtils.joinPath(brokerUtils.requestMappings.BACKEND,
        brokerUtils.requestMappings.TOKEN), brokerUtils.verb.POST));

    amplify.request.define("authentication/save", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(urlUtils.joinPath(brokerUtils.requestMappings.BACKEND,
            brokerUtils.requestMappings.AUTHENTICATION, brokerUtils.requestMappings.SAVE),
            brokerUtils.verb.PUT));

    amplify.request.define("authentication/signIn", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(urlUtils.joinPath(brokerUtils.requestMappings.BACKEND,
            brokerUtils.requestMappings.AUTHENTICATION, brokerUtils.requestMappings.SIGN_IN),
            brokerUtils.verb.PUT));

    amplify.request.define("authentication/resetPassword", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(urlUtils.joinPath(brokerUtils.requestMappings.BACKEND,
            brokerUtils.requestMappings.AUTHENTICATION,
            brokerUtils.requestMappings.EMAIL, brokerUtils.requestMappings.RESET_PASSWORD),
            brokerUtils.verb.POST));

    amplify.request.define("authentication/checkTicket", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(urlUtils.joinPath(brokerUtils.requestMappings.BACKEND,
            brokerUtils.requestMappings.AUTHENTICATION,
            brokerUtils.requestMappings.KEY, brokerUtils.requestMappings.CHECK_TICKET),
            brokerUtils.verb.POST));

    amplify.request.define("authentication/updatePassword", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(urlUtils.joinPath(brokerUtils.requestMappings.BACKEND,
            brokerUtils.requestMappings.AUTHENTICATION, brokerUtils.requestMappings.UPDATE_PASSWORD),
            brokerUtils.verb.PUT));

    function setup() {
        return amplify.request("authentication/setup");
    }

    function login(credentials) {
        credentials["grant_type"] = "password";
        credentials["client_id"] = config.CLIENT_ID;
        credentials["client_secret"] = config.CLIENT_SECRET;
        return amplify.request("authentication/login", credentials);
    }

    function logout() {
        var defer = $.Deferred();

        defer.resolve(true);

        return defer.promise();
    }

    function save(entity) {
        return amplify.request("authentication/save", entity).done(CACHE.evict);
    }

    function signIn(entity) {
        return amplify.request("authentication/signIn", entity).done(CACHE.evict);
    }

    function resetPassword(userName) {
        return amplify.request("authentication/resetPassword", { userName: userName }).done(CACHE.evict);
    }

    function checkTicket(key) {
        return amplify.request("authentication/checkTicket", { key: key }).done(CACHE.evict);
    }

    function updatePassword(entity) {
        return amplify.request("authentication/updatePassword", entity).done(CACHE.evict);
    }

    // request revelation user
    broker.setup = setup;
    broker.login = login;
    broker.logout = logout;
    broker.save = save;
    broker.signIn = signIn;
    broker.resetPassword = resetPassword;
    broker.checkTicket = checkTicket;
    broker.updatePassword = updatePassword;

    return broker;
});