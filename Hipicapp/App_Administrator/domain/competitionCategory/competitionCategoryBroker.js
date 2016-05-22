/* global amplify: false, define: false, require: false */
/* jshint maxstatements: 35 */
define([
    "core/broker", "core/cacheImpl", "core/util/urlUtils"
], function competitionCategoryBroker(brokerUtils, cacheImpl, urlUtils) {
    "use strict";

    var broker = {}, CACHE_NAME = "competitionCategories", CACHE = cacheImpl(CACHE_NAME);

    // cache definition
    /* jshint camelcase: false */
    amplify.request_original.cache[CACHE_NAME] = CACHE;

    // request definition
    amplify.request.define("competitionCategories/findAll", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.COMPETITION_CATEGORIES,
                brokerUtils.requestMappings.FIND_ALL), brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("competitionCategories/findBy", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.COMPETITION_CATEGORIES,
                brokerUtils.requestMappings.FIND), brokerUtils.verb.POST, CACHE_NAME));

    amplify.request.define("competitionCategories/findById", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.COMPETITION_CATEGORIES,
                brokerUtils.requestMappings.GET, brokerUtils.requestMappings.ID), brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("competitionCategories/save", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.COMPETITION_CATEGORIES, brokerUtils.requestMappings.SAVE), brokerUtils.verb.POST));

    amplify.request.define("competitionCategories/update", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.COMPETITION_CATEGORIES, brokerUtils.requestMappings.UPDATE), brokerUtils.verb.PUT));

    amplify.request.define("competitionCategories/erase", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.COMPETITION_CATEGORIES, brokerUtils.requestMappings.DELETE), brokerUtils.verb.DELETE));

    function findAll() {
        return amplify.request("competitionCategories/findAll");
    }

    function findBy(findRequest) {
        return amplify.request("competitionCategories/findBy", findRequest);
    }

    function findById(id) {
        return amplify.request("competitionCategories/findById", {
            id: id
        });
    }

    function save(entity) {
        return amplify.request("competitionCategories/save", entity).always(CACHE.evict);
    }

    function update(entity) {
        return amplify.request("competitionCategories/update", entity).always(CACHE.evict);
    }

    function erase(entity) {
        return amplify.request("competitionCategories/erase", entity).always(CACHE.evict);
    }

    function getListUrl() {
        return brokerUtils.HASH_CHAR + urlUtils.joinPath(brokerUtils.requestMappings.CATEGORIES);
    }

    function getDetailUrlById(id) {
        return brokerUtils.HASH_CHAR + urlUtils.joinPath(brokerUtils.requestMappings.CATEGORY, id);
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