/* global amplify: false, define: false */
/* jshint maxstatements: 50 */
define([
    "core/broker", "core/cacheImpl", "core/util/urlUtils"
], function userBroker(brokerUtils, cacheImpl, urlUtils) {
    "use strict";

    var broker = {}, CACHE_NAME = "users", CACHE = cacheImpl(CACHE_NAME);

    // cache definition
    /* jshint camelcase: false */
    amplify.request_original.cache[CACHE_NAME] = CACHE;

    // request definition
    amplify.request.define("users/findBy", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(urlUtils.joinPath(brokerUtils.requestMappings.BACKEND,
            brokerUtils.requestMappings.USERS, brokerUtils.requestMappings.FIND),
            brokerUtils.verb.POST), CACHE_NAME);

    amplify.request.define("users/findByUserId", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.USERS,
                brokerUtils.requestMappings.GET, brokerUtils.requestMappings.ID), brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("users/getTileCount", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.USERS,
                brokerUtils.requestMappings.GET_TILE_COUNT), brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("users/register", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.USERS,
                brokerUtils.requestMappings.REGISTER, brokerUtils.requestMappings.AGGREGATORS),
            brokerUtils.verb.POST));

    amplify.request.define("users/save", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.USERS, brokerUtils.requestMappings.SAVE), brokerUtils.verb.POST));

    amplify.request.define("users/changePassword", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils
                .joinPath(brokerUtils.requestMappings.USERS, brokerUtils.requestMappings.CHANGE),
            brokerUtils.verb.POST));

    amplify.request.define("users/disable", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.USERS,
                brokerUtils.requestMappings.DISABLE), brokerUtils.verb.PUT));

    amplify.request.define("users/enable", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils
                .joinPath(brokerUtils.requestMappings.USERS, brokerUtils.requestMappings.ENABLE, brokerUtils.requestMappings.ENABLE),
            brokerUtils.verb.PUT));

    amplify.request.define("users/erase", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.USERS, brokerUtils.requestMappings.DISABLE), brokerUtils.verb.DELETE));

    function evictCache() {
        CACHE.evict();
    }

    function findBy(findRequest) {
        return amplify.request("users/findBy", findRequest);
    }

    function findByUserId(userId) {
        return amplify.request("users/findByUserId", {
            userId: userId
        });
    }

    function getTileCount() {
        return amplify.request("users/getTileCount");
    }

    function register(client) {
        return amplify.request("users/register", client).always(CACHE.evict);
    }

    function save(entity) {
        return amplify.request("users/save", entity).always(CACHE.evict);
    }

    function changePassword(entity) {
        return amplify.request("users/changePassword", entity).always(CACHE.evict);
    }

    function disable(entity) {
        return amplify.request("users/disable", entity).always(CACHE.evict);
    }

    function enable(entity) {
        return amplify.request("users/enable", entity).always(CACHE.evict);
    }

    function erase(entity) {
        return amplify.request("users/erase", entity).always(CACHE.evict);
    }

    function getListUrl() {
        return brokerUtils.HASH_CHAR + urlUtils.joinPath(brokerUtils.requestMappings.USERS);
    }

    function getDetailUrlByUserId(userId) {
        return brokerUtils.HASH_CHAR + urlUtils.joinPath(brokerUtils.requestMappings.USER, userId);
    }

    function getChangePasswordUrlByUserId(userId) {
        return brokerUtils.HASH_CHAR +
            urlUtils.joinPath(brokerUtils.requestMappings.USER, userId,
                brokerUtils.requestMappings.CHANGE_PASSWORD);
    }

    broker.evictCache = evictCache;

    broker.findBy = findBy;
    broker.findByUserId = findByUserId;
    broker.getTileCount = getTileCount;
    broker.register = register;
    broker.save = save;
    broker.changePassword = changePassword;
    broker.disable = disable;
    broker.enable = enable;
    broker.erase = erase;

    broker.getListUrl = getListUrl;
    broker.getDetailUrlByUserId = getDetailUrlByUserId;
    broker.getChangePasswordUrlByUserId = getChangePasswordUrlByUserId;

    return broker;
});