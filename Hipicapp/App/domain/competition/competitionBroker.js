/* global amplify: false, define: false, require: false */
/* jshint maxstatements: 35 */
define([
    "core/broker", "core/cacheImpl", "core/util/urlUtils"
], function competitionBroker(brokerUtils, cacheImpl, urlUtils) {
    "use strict";

    var broker = {}, CACHE_NAME = "competitions", CACHE = cacheImpl(CACHE_NAME);

    // cache definition
    /* jshint camelcase: false */
    amplify.request_original.cache[CACHE_NAME] = CACHE;

    // request definition
    amplify.request.define("competitions/findBy", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.COMPETITIONS,
                brokerUtils.requestMappings.FIND), brokerUtils.verb.POST, CACHE_NAME));

    amplify.request.define("competitions/findInscriptionsBy", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.COMPETITIONS,
                brokerUtils.requestMappings.FIND_INSCRIPTIONS), brokerUtils.verb.POST, CACHE_NAME));

    amplify.request.define("competitions/adultRankingsBySpecialtyId", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.COMPETITIONS,
                brokerUtils.requestMappings.ADULT_RANKINGS_BY_SPECIALTY_ID, brokerUtils.requestMappings.SPECIALTY_ID), brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("competitions/findNextBySpecialtyId", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.COMPETITIONS,
                brokerUtils.requestMappings.FIND_NEXT_BY_SPECIALTY_ID, brokerUtils.requestMappings.SPECIALTY_ID), brokerUtils.verb.GET, CACHE_NAME));

    function findBy(findRequest) {
        return amplify.request("competitions/findBy", findRequest);
    }

    function findInscriptionsBy(findRequest) {
        return amplify.request("competitions/findInscriptionsBy", findRequest);
    }

    function adultRankingsBySpecialtyId(specialtyId) {
        return amplify.request("competitions/adultRankingsBySpecialtyId", {
            specialtyId: specialtyId
        });
    }

    function findNextBySpecialtyId(specialtyId) {
        return amplify.request("competitions/findNextBySpecialtyId", {
            specialtyId: specialtyId
        });
    }

    function getDetailUrlById(competitionId) {
        return brokerUtils.HASH_CHAR +
            urlUtils.joinPath(brokerUtils.requestMappings.COMPETITION, competitionId);
    }

    function evictCache() {
        CACHE.evict();
    }

    broker.evictCache = evictCache;

    // request revelation
    broker.findBy = findBy;
    broker.findInscriptionsBy = findInscriptionsBy;
    broker.findNextBySpecialtyId = findNextBySpecialtyId;
    broker.adultRankingsBySpecialtyId = adultRankingsBySpecialtyId;

    broker.getDetailUrlById = getDetailUrlById;

    return broker;
});