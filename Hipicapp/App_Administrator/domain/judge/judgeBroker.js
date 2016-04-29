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

    amplify.request.define("judges/findByWithAssignment", brokerUtils.REQUEST_TYPE, brokerUtils
            .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
                urlUtils.joinPath(brokerUtils.requestMappings.JUDGES,
                    brokerUtils.requestMappings.FINDWITHASSIGNMENT), brokerUtils.verb.POST, CACHE_NAME));

    amplify.request.define("judges/findById", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.JUDGES,
                brokerUtils.requestMappings.GET, brokerUtils.requestMappings.ID), brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("judges/save", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.JUDGES, brokerUtils.requestMappings.SAVE), brokerUtils.verb.POST));

    amplify.request.define("judges/update", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.JUDGES, brokerUtils.requestMappings.UPDATE), brokerUtils.verb.PUT));

    amplify.request.define("judges/erase", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.JUDGES, brokerUtils.requestMappings.DELETE), brokerUtils.verb.DELETE));

    function findBy(findRequest) {
        return amplify.request("judges/findBy", findRequest);
    }

    function findByWithAssignment(findRequest) {
        return amplify.request("judges/findByWithAssignment", findRequest);
    }

    function findById(id) {
        return amplify.request("judges/findById", {
            id: id
        });
    }

    function save(entity) {
        return amplify.request("judges/save", entity).always(CACHE.evict);
    }

    function update(entity) {
        return amplify.request("judges/update", entity).always(CACHE.evict);
    }

    function erase(entity) {
        return amplify.request("judges/erase", entity).always(CACHE.evict);
    }

    function getListUrl() {
        return brokerUtils.HASH_CHAR + urlUtils.joinPath(brokerUtils.requestMappings.JUDGES);
    }

    function getDetailUrlById(judgeId) {
        return brokerUtils.HASH_CHAR +
            urlUtils.joinPath(brokerUtils.requestMappings.JUDGE, judgeId);
    }

    function getImagesUrlById(judgeId) {
        return brokerUtils.HASH_CHAR +
            urlUtils.joinPath(brokerUtils.requestMappings.JUDGE, judgeId,
                brokerUtils.requestMappings.IMAGES);
    }

    function getFileuploadUrlById(entityId) {
        return brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.JUDGE,
                brokerUtils.requestMappings.UPLOAD, entityId);
    }

    function evictCache() {
        CACHE.evict();
    }

    broker.evictCache = evictCache;

    // request revelation
    broker.findBy = findBy;
    broker.findByWithAssignment = findByWithAssignment;
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