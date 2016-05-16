/* global amplify: false, define: false, require: false */
/* jshint maxstatements: 35 */
define([
    "core/broker", "core/cacheImpl", "core/util/urlUtils"
], function bannerBroker(brokerUtils, cacheImpl, urlUtils) {
    "use strict";

    var broker = {}, CACHE_NAME = "banners", CACHE = cacheImpl(CACHE_NAME);

    // cache definition
    /* jshint camelcase: false */
    amplify.request_original.cache[CACHE_NAME] = CACHE;

    // request definition
    amplify.request.define("banners/findVisibleBySpecialtyId", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.BANNERS,
                brokerUtils.requestMappings.FIND_VISIBLE_BY_SPECIALTY_ID,
                brokerUtils.requestMappings.SPECIALTY_ID), brokerUtils.verb.GET, CACHE_NAME));

    function findVisibleBySpecialtyId(specialtyId) {
        return amplify.request("banners/findVisibleBySpecialtyId", {
            specialtyId: specialtyId
        });
    }

    function evictCache() {
        CACHE.evict();
    }

    broker.evictCache = evictCache;

    // request revelation
    broker.findVisibleBySpecialtyId = findVisibleBySpecialtyId;

    return broker;
});