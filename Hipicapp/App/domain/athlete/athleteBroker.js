/* global amplify: false, define: false, require: false */
/* jshint maxstatements: 35 */
define([
    "core/broker", "core/cacheImpl", "core/util/urlUtils"
], function athleteBroker(brokerUtils, cacheImpl, urlUtils) {
    "use strict";

    var broker = {}, CACHE_NAME = "athletes", CACHE = cacheImpl(CACHE_NAME);

    // cache definition
    /* jshint camelcase: false */
    amplify.request_original.cache[CACHE_NAME] = CACHE;

    // request definition
    amplify.request.define("athletes/getByCurrentUser", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETE,
                brokerUtils.requestMappings.GET_BY_CURRENT_USER), brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("athletes/register", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETE, brokerUtils.requestMappings.REGISTER), brokerUtils.verb.POST));

    function getByCurrentUser() {
        return amplify.request("athletes/getByCurrentUser");
    }

    function register(entity) {
        return amplify.request("athletes/register", entity).always(CACHE.evict);
    }

    function evictCache() {
        CACHE.evict();
    }

    broker.evictCache = evictCache;

    // request revelation
    broker.getByCurrentUser = getByCurrentUser;
    broker.register = register;

    return broker;
});