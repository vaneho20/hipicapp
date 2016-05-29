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

    amplify.request.define("competitions/findById", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.COMPETITIONS,
                brokerUtils.requestMappings.GET, brokerUtils.requestMappings.ID), brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("competitions/findInscriptionsBy", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.COMPETITIONS,
                brokerUtils.requestMappings.FIND_INSCRIPTIONS), brokerUtils.verb.POST, CACHE_NAME));

    amplify.request.define("competitions/findSeminaryBy", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.COMPETITIONS,
                brokerUtils.requestMappings.FIND_SEMINARY), brokerUtils.verb.POST, CACHE_NAME));

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

    function findById(id) {
        return amplify.request("competitions/findById", {
            id: id
        });
    }

    function findInscriptionsBy(findRequest) {
        return amplify.request("competitions/findInscriptionsBy", findRequest);
    }

    function findSeminaryBy(findRequest) {
        return amplify.request("competitions/findSeminaryBy", findRequest);
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

    function getListUrl(specialtyId) {
        return brokerUtils.HASH_CHAR + urlUtils.joinPath(brokerUtils.requestMappings.SPECIALTY, specialtyId, brokerUtils.requestMappings.COMPETITIONS);
    }

    function getDetailUrlById(competitionId) {
        return brokerUtils.HASH_CHAR +
            urlUtils.joinPath(brokerUtils.requestMappings.COMPETITION, competitionId);
    }

    function getHorsesUrlById(competitionId) {
        return brokerUtils.HASH_CHAR +
            urlUtils.joinPath(brokerUtils.requestMappings.COMPETITION, competitionId,
                brokerUtils.requestMappings.HORSES);
    }

    function downloadAdvanceProgramById(competitionId) {
        return brokerUtils.requestMappings.BACKEND + urlUtils.joinPath(brokerUtils.requestMappings.COMPETITIONS,
            brokerUtils.requestMappings.DOWNLOAD_ADVANCE_PROGRAM, competitionId);
    }

    function evictCache() {
        CACHE.evict();
    }

    broker.evictCache = evictCache;

    // request revelation
    broker.findBy = findBy;
    broker.findById = findById;
    broker.findInscriptionsBy = findInscriptionsBy;
    broker.findSeminaryBy = findSeminaryBy;
    broker.findNextBySpecialtyId = findNextBySpecialtyId;
    broker.adultRankingsBySpecialtyId = adultRankingsBySpecialtyId;

    broker.getListUrl = getListUrl;
    broker.getDetailUrlById = getDetailUrlById;
    broker.getHorsesUrlById = getHorsesUrlById;

    broker.downloadAdvanceProgramById = downloadAdvanceProgramById;

    return broker;
});