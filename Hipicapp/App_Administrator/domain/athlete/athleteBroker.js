/* global amplify: false, define: false, require: false */
/* jshint maxstatements: 35 */
define([
    "core/broker", "domain/user/userBroker", "core/cacheImpl", "core/util/urlUtils"
], function athleteBroker(brokerUtils, userBroker, cacheImpl, urlUtils) {
    "use strict";

    var broker = {}, CACHE_NAME = "athletes", CACHE = cacheImpl(CACHE_NAME);

    // cache definition
    /* jshint camelcase: false */
    amplify.request_original.cache[CACHE_NAME] = CACHE;

    // request definition
    amplify.request.define("athletes/findBy", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETE,
                brokerUtils.requestMappings.FIND), brokerUtils.verb.POST, CACHE_NAME));

    amplify.request.define("athletes/findById", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETE,
                brokerUtils.requestMappings.GET, brokerUtils.requestMappings.ID), brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("athletes/save", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETE, brokerUtils.requestMappings.SAVE), brokerUtils.verb.POST));

    amplify.request.define("athletes/update", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETE, brokerUtils.requestMappings.UPDATE), brokerUtils.verb.PUT));

    amplify.request.define("athletes/erase", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETE), brokerUtils.verb.DELETE));

    function findBy(findRequest) {
        return amplify.request("athletes/findBy", findRequest);
    }

    function findById(id) {
        return amplify.request("athletes/findById", {
            id: id
        });
    }

    function save(entity) {
        return amplify.request("athletes/save", entity).always(CACHE.evict);
    }

    function update(entity) {
        return amplify.request("athletes/update", entity).always(CACHE.evict);
    }

    function erase(entity) {
        return amplify.request("athletes/erase", entity).always(CACHE.evict).always(userBroker.evictCache);
    }

    function getListUrl() {
        return brokerUtils.HASH_CHAR + urlUtils.joinPath(brokerUtils.requestMappings.ATHLETES);
    }

    function getDetailUrlById(athleteId) {
        return brokerUtils.HASH_CHAR +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETE, athleteId);
    }

    function getImagesUrlById(athleteId) {
        return brokerUtils.HASH_CHAR +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETE, athleteId,
                brokerUtils.requestMappings.IMAGES);
    }

    function getHorsesUrlById(athleteId) {
        return brokerUtils.HASH_CHAR +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETE, athleteId,
                brokerUtils.requestMappings.HORSES);
    }

    function getFileuploadUrlById(entityId) {
        return brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETE,
                brokerUtils.requestMappings.UPLOAD, entityId);
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
    broker.getHorsesUrlById = getHorsesUrlById;
    broker.getFileuploadUrlById = getFileuploadUrlById;

    return broker;
});