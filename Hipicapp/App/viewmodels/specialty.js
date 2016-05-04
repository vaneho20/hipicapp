/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/specialty/specialtyBroker",
    "domain/specialty/specialtyImpl", "domain/competition/competitionBroker", "viewmodels/shell",
    "viewmodels/alerts"
], function specialtyViewModel(i18n, router, securityContext, stringUtils, urlUtils,
    validationUtils, specialtyBroker, specialtyImpl, competitionBroker, shell, alerts) {
    "use strict";

    // state definition
    var viewModel = {}, currentEntity = ko.observable(specialtyImpl()), ranking = ko.observableArray([]);

    // lifecycle definition
    function activate(id) {
        if (id) {
            // allways return a promise
            return loadEntityBySpecialtyId(id);
        } else {
            refreshCurrentEntity();
        }
    }

    // behaviour definition
    function refreshCurrentEntity(data) {
        currentEntity(specialtyImpl(data));
        loadRanking(currentEntity());
    }

    function loadEntityBySpecialtyId(id) {
        return specialtyBroker.findById(id).done(refreshCurrentEntity);
    }

    function refreshRanking(data) {
        ranking(data);
    }

    function loadRanking(specialty) {
        return competitionBroker.adultRankingsBySpecialty(specialty).done(refreshRanking);
    }

    // module revelation
    viewModel.i18n = i18n;
    viewModel.securityContext = securityContext;
    viewModel.validationUtils = validationUtils;
    viewModel.specialtyBroker = specialtyBroker;

    // state revelation
    viewModel.currentEntity = currentEntity;
    viewModel.ranking = ranking;

    // lifecycle revelation
    viewModel.activate = activate;

    // behaviour revelation

    return viewModel;
});