/* global amplify: false, define: false, require: false */
/* jshint maxstatements: 35 */
define([
    "core/broker", "core/cacheImpl", "core/util/urlUtils", "domain/competition/competitionBroker"
], function athleteBroker(brokerUtils, cacheImpl, urlUtils, competitionBroker) {
    "use strict";

    var broker = {}, CACHE_NAME = "athletes", CACHE = cacheImpl(CACHE_NAME);

    // cache definition
    /* jshint camelcase: false */
    amplify.request_original.cache[CACHE_NAME] = CACHE;

    // request definition
    amplify.request.define("athletes/findBy", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETES,
                brokerUtils.requestMappings.FIND), brokerUtils.verb.POST, CACHE_NAME));

    amplify.request.define("athletes/findById", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETES,
                brokerUtils.requestMappings.GET, brokerUtils.requestMappings.ID), brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("athletes/getByCurrentUser", brokerUtils.REQUEST_TYPE, brokerUtils
        .getReadOnlyRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETES,
                brokerUtils.requestMappings.GET_BY_CURRENT_USER), brokerUtils.verb.GET, CACHE_NAME));

    amplify.request.define("athletes/register", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETES, brokerUtils.requestMappings.REGISTER), brokerUtils.verb.POST));

    amplify.request.define("athletes/inscription", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETES, brokerUtils.requestMappings.INSCRIPTION), brokerUtils.verb.POST));

    amplify.request.define("athletes/update", brokerUtils.REQUEST_TYPE, brokerUtils
        .getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETES, brokerUtils.requestMappings.UPDATE), brokerUtils.verb.PUT));

    amplify.request.define("athletes/hasEnrolled", brokerUtils.REQUEST_TYPE,
        brokerUtils.getWriteRequestSettings(brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETES,
                brokerUtils.requestMappings.HAS_ENROLLED,
                brokerUtils.requestMappings.COMPETITION_ID), brokerUtils.verb.POST));

    function findBy(findRequest) {
        return amplify.request("athletes/findBy", findRequest);
    }

    function findById(id) {
        return amplify.request("athletes/findById", {
            id: id
        });
    }

    function getByCurrentUser() {
        return amplify.request("athletes/getByCurrentUser");
    }

    function register(entity) {
        return amplify.request("athletes/register", entity).always(CACHE.evict);
    }

    function inscription(competitionId, horseId) {
        return amplify.request("athletes/inscription", {
            competitionId: competitionId,
            horseId: horseId
        }).always(CACHE.evict).always(competitionBroker.evictCache);
    }

    function update(entity) {
        return amplify.request("athletes/update", entity).always(CACHE.evict);
    }

    function hasEnrolled(competitionId) {

        return amplify.request("athletes/hasEnrolled", {
            competitionId: competitionId
        }).always(competitionBroker.evictCache).always(CACHE.evict);
    }

    function getListUrl(specialtyId) {
        return brokerUtils.HASH_CHAR + urlUtils.joinPath(brokerUtils.requestMappings.SPECIALTY, specialtyId, brokerUtils.requestMappings.ATHLETES);
    }

    function getDetailUrlById(athleteId) {
        return brokerUtils.HASH_CHAR +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETE, athleteId);
    }

    function getEditUrlById(athleteId) {
        return brokerUtils.HASH_CHAR +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETE, athleteId, brokerUtils.requestMappings.PERSONAL_INFORMATION);
    }

    function getImagesUrlById(athleteId) {
        return brokerUtils.HASH_CHAR +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETE, athleteId,
                brokerUtils.requestMappings.IMAGES);
    }

    function getFileuploadUrlById(entityId) {
        return brokerUtils.requestMappings.BACKEND +
            urlUtils.joinPath(brokerUtils.requestMappings.ATHLETES,
                brokerUtils.requestMappings.UPLOAD, entityId);
    }

    function evictCache() {
        CACHE.evict();
    }

    broker.evictCache = evictCache;

    // request revelation
    broker.findBy = findBy;
    broker.findById = findById;
    broker.getByCurrentUser = getByCurrentUser;
    broker.register = register;
    broker.inscription = inscription;
    broker.update = update;
    broker.hasEnrolled = hasEnrolled;

    broker.getListUrl = getListUrl;
    broker.getDetailUrlById = getDetailUrlById;
    broker.getEditUrlById = getEditUrlById;
    broker.getImagesUrlById = getImagesUrlById;
    broker.getFileuploadUrlById = getFileuploadUrlById;

    return broker;
});