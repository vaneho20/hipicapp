/* global amplify: false, define: false, require: false */
/* jshint maxstatements: 35 */
define([
    "core/broker", "core/cacheImpl", "core/util/urlUtils"
], function specialtyBroker(brokerUtils, cacheImpl, urlUtils) {
    "use strict";

    var broker = {}, CACHE_NAME = "specialties", CACHE = cacheImpl(CACHE_NAME);

    // cache definition
    /* jshint camelcase: false */
    amplify.request_original.cache[CACHE_NAME] = CACHE;

    // request definition
    amplify.request.define("specialties/findAll", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.SPECIALTIES,
                brokerUtils.requestMappings.FIND_ALL), brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("specialties/findBy", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.SPECIALTIES,
                brokerUtils.requestMappings.FIND), brokerUtils.verb.POST, CACHE_NAME));

    amplify.request.define("specialties/findById", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.SPECIALTIES,
                brokerUtils.requestMappings.GET, brokerUtils.requestMappings.ID), brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("specialties/save", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.SPECIALTIES, brokerUtils.requestMappings.SAVE), brokerUtils.verb.POST));

    amplify.request.define("specialties/update", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.SPECIALTIES, brokerUtils.requestMappings.UPDATE), brokerUtils.verb.PUT));

    amplify.request.define("specialties/erase", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.SPECIALTIES), brokerUtils.verb.DELETE));

    function findAll() {
        return amplify.request("specialties/findAll");
    }

    function findBy(findRequest) {
        return amplify.request("specialties/findBy", findRequest);
    }

    function findById(id) {
        return amplify.request("specialties/findById", {
            id: id
        });
    }

    function save(entity) {
        return amplify.request("specialties/save", entity).always(CACHE.evict);
    }

    function update(entity) {
        return amplify.request("specialties/update", entity).always(CACHE.evict);
    }

    function erase(entity) {
        return amplify.request("specialties/erase", entity).always(CACHE.evict);
    }

    function getListUrl() {
        return brokerUtils.HASH_CHAR + urlUtils.joinPath(brokerUtils.requestMappings.SPECIALTIES);
    }

    function getDetailUrlById(id) {
        return brokerUtils.HASH_CHAR + urlUtils.joinPath(brokerUtils.requestMappings.SPECIALTY, id);
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

    return broker;
});