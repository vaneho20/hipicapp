/* global amplify: false, define: false, require: false */
/* jshint maxstatements: 35 */
define([
    "core/broker", "core/cacheImpl", "core/util/urlUtils"
], function judgeBroker(brokerUtils, cacheImpl, urlUtils) {
    "use strict";

    var broker = {}, CACHE_NAME = "judges", CACHE = cacheImpl(CACHE_NAME);

    // cache definition
    /* jshint camelcase: false */
    amplify.request_original.cache[CACHE_NAME] = CACHE;

    // request definition
    amplify.request.define("judges/findBy", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.JUDGES,
                brokerUtils.requestMappings.FIND), brokerUtils.verb.POST, CACHE_NAME));

    amplify.request.define("judges/findById", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.JUDGES,
                brokerUtils.requestMappings.GET, brokerUtils.requestMappings.ID), brokerUtils.verb.GET, CACHE_NAME));

    function findBy(findRequest) {
        return amplify.request("judges/findBy", findRequest);
    }

    function findById(id) {
        return amplify.request("judges/findById", {
            id: id
        });
    }

    function getListUrl(specialtyId) {
        return brokerUtils.HASH_CHAR + urlUtils.joinPath(brokerUtils.requestMappings.SPECIALTY, specialtyId, brokerUtils.requestMappings.JUDGES);
    }

    function getDetailUrlById(judgeId) {
        return brokerUtils.HASH_CHAR +
            urlUtils.joinPath(brokerUtils.requestMappings.JUDGE, judgeId);
    }

    function evictCache() {
        CACHE.evict();
    }

    broker.evictCache = evictCache;

    // request revelation
    broker.findBy = findBy;
    broker.findById = findById;
    broker.getListUrl = getListUrl;
    broker.getDetailUrlById = getDetailUrlById;

    return broker;
});