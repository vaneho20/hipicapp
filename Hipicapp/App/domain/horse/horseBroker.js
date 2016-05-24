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

    amplify.request.define("horses/findById", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.HORSES,
                brokerUtils.requestMappings.GET, brokerUtils.requestMappings.ID), brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("horses/findByCurrentUser", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.HORSES,
                brokerUtils.requestMappings.FIND_BY_CURRENT_USER), brokerUtils.verb.POST, CACHE_NAME));

    amplify.request.define("horses/save", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.HORSES, brokerUtils.requestMappings.SAVE), brokerUtils.verb.POST));

    amplify.request.define("horses/update", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.HORSES, brokerUtils.requestMappings.UPDATE), brokerUtils.verb.PUT));

    amplify.request.define("horses/erase", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.HORSES, brokerUtils.requestMappings.DELETE), brokerUtils.verb.DELETE));

    function findBy(findRequest) {
        return amplify.request("horses/findBy", findRequest);
    }

    function findById(id) {
        return amplify.request("horses/findById", {
            id: id
        });
    }

    function findByCurrentUser(findRequest) {
        return amplify.request("horses/findByCurrentUser", findRequest);
    }

    function save(entity) {
        return amplify.request("horses/save", entity).always(CACHE.evict);
    }

    function update(entity) {
        return amplify.request("horses/update", entity).always(CACHE.evict);
    }

    function erase(entity) {
        return amplify.request("horses/erase", entity).always(CACHE.evict);
    }

    function getDetailUrlById(horseId) {
        return brokerUtils.HASH_CHAR +
            urlUtils.joinPath(brokerUtils.requestMappings.HORSE, horseId);
    }

    function getEditUrlById(horseId) {
        return brokerUtils.HASH_CHAR +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETE + "-" + brokerUtils.requestMappings.HORSE, horseId);
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
    broker.findById = findById;
    broker.findByCurrentUser = findByCurrentUser;
    broker.save = save;
    broker.update = update;
    broker.erase = erase;
    broker.getDetailUrlById = getDetailUrlById;
    broker.getEditUrlById = getEditUrlById;
    broker.getListUrl = getListUrl;

    return broker;
});