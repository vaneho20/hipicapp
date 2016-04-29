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

    function save(entity) {
        return amplify.request("horses/save", entity).always(CACHE.evict);
    }

    function update(entity) {
        return amplify.request("horses/update", entity).always(CACHE.evict);
    }

    function erase(entity) {
        return amplify.request("horses/erase", entity).always(CACHE.evict);
    }

    function getListUrl(athleteId) {
        return brokerUtils.HASH_CHAR + urlUtils.joinPath(brokerUtils.requestMappings.ATHLETE, athleteId, brokerUtils.requestMappings.HORSES);
    }

    function getDetailUrlById(athleteId, horseId) {
        return brokerUtils.HASH_CHAR +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETE, athleteId, brokerUtils.requestMappings.HORSE, horseId);
    }

    function getImagesUrlById(athleteId, horseId) {
        return brokerUtils.HASH_CHAR +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETE, athleteId, brokerUtils.requestMappings.HORSE, horseId,
                brokerUtils.requestMappings.IMAGES);
    }

    function getFileuploadUrlById(entityId) {
        return brokerUtils.requestMappings.BACKEND + urlUtils.joinPath(brokerUtils.requestMappings.HORSE, brokerUtils.requestMappings.UPLOAD, entityId);
    }

    function evictCache() {
        CACHE.evict();
    }

    broker.evictCache = evictCache;

    // request revelation
    broker.findBy = findBy;
    broker.save = save;
    broker.update = update;
    broker.erase = erase;
    broker.findById = findById;
    broker.getListUrl = getListUrl;
    broker.getDetailUrlById = getDetailUrlById;
    broker.getImagesUrlById = getImagesUrlById;
    broker.getFileuploadUrlById = getFileuploadUrlById;

    return broker;
});