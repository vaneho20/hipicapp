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
    amplify.request.define("banners/findAll", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.BANNERS,
                brokerUtils.requestMappings.FIND_ALL), brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("banners/findBy", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.BANNERS,
                brokerUtils.requestMappings.FIND), brokerUtils.verb.POST, CACHE_NAME));

    amplify.request.define("banners/findById", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.BANNERS,
                brokerUtils.requestMappings.GET, brokerUtils.requestMappings.ID), brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("banners/save", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.BANNERS, brokerUtils.requestMappings.SAVE), brokerUtils.verb.POST));

    amplify.request.define("banners/update", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.BANNERS, brokerUtils.requestMappings.UPDATE), brokerUtils.verb.PUT));

    amplify.request.define("banners/erase", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.BANNERS, brokerUtils.requestMappings.DELETE), brokerUtils.verb.DELETE));

    function findAll() {
        return amplify.request("banners/findAll");
    }

    function findBy(findRequest) {
        return amplify.request("banners/findBy", findRequest);
    }

    function findById(id) {
        return amplify.request("banners/findById", {
            id: id
        });
    }

    function save(entity) {
        return amplify.request("banners/save", entity).always(CACHE.evict);
    }

    function update(entity) {
        return amplify.request("banners/update", entity).always(CACHE.evict);
    }

    function erase(entity) {
        return amplify.request("banners/erase", entity).always(CACHE.evict);
    }

    function getListUrl() {
        return brokerUtils.HASH_CHAR + urlUtils.joinPath(brokerUtils.requestMappings.BANNERS);
    }

    function getDetailUrlById(id) {
        return brokerUtils.HASH_CHAR + urlUtils.joinPath(brokerUtils.requestMappings.BANNER, id);
    }

    function getImagesUrlById(bannerId) {
        return brokerUtils.HASH_CHAR +
            urlUtils.joinPath(brokerUtils.requestMappings.BANNER, bannerId,
                brokerUtils.requestMappings.IMAGES);
    }

    function getFileuploadUrlById(entityId) {
        return brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.BANNERS,
                brokerUtils.requestMappings.UPLOAD, entityId);
    }

    function evictCache() {
        CACHE.evict();
    }

    broker.evictCache = evictCache;

    // request revelation
    broker.findAll = findAll;
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