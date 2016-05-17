/* global amplify: false, define: false, require: false */
/* jshint maxstatements: 35 */
define([
    "core/broker", "core/cacheImpl", "core/util/urlUtils"
], function horseBroker(brokerUtils, cacheImpl, urlUtils) {
    "use strict";

    var broker = {}, CACHE_NAME = "horses", CACHE = cacheImpl(CACHE_NAME);

    // cache definition
    /* jshint camelcase: false */
    amplify.request_original.cache[CACHE_NAME] = CACHE;

    // request definition
    amplify.request.define("horses/findBy", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.HORSES,
                brokerUtils.requestMappings.FIND), brokerUtils.verb.POST, CACHE_NAME));

    amplify.request.define("horses/findByCurrentUser", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.HORSES,
                brokerUtils.requestMappings.FIND_BY_CURRENT_USER), brokerUtils.verb.POST, CACHE_NAME));

    function findBy(findRequest) {
        return amplify.request("horses/findBy", findRequest);
    }

    function findByCurrentUser(findRequest) {
        return amplify.request("horses/findByCurrentUser", findRequest);
    }

    function getDetailUrlById(horseId) {
        return brokerUtils.HASH_CHAR +
            urlUtils.joinPath(brokerUtils.requestMappings.HORSE, horseId);
    }

    function getListUrl(specialtyId) {
        return brokerUtils.HASH_CHAR + urlUtils.joinPath(brokerUtils.requestMappings.SPECIALTY, specialtyId, brokerUtils.requestMappings.HORSES);
    }

    function evictCache() {
        CACHE.evict();
    }

    broker.evictCache = evictCache;

    // request revelation
    broker.findBy = findBy;
    broker.findByCurrentUser = findByCurrentUser;
    broker.getDetailUrlById = getDetailUrlById;
    broker.getListUrl = getListUrl;

    return broker;
});