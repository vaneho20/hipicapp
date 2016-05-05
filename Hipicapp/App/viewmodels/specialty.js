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
    var viewModel = {}, currentEntity = ko.observable(specialtyImpl()), ranking = ko.observableArray([]),
        nextCompetitions = ko.observableArray([]);

    // lifecycle definition
    function activate(id) {
        if (id) {
            // allways return a promise
            return $.when(loadEntityBySpecialtyId(id), loadRankingBySpecialtyId(id), loadNextCompetitionsBySpecialtyId(id));
        } else {
            refreshCurrentEntity();
        }
    }

    // behaviour definition
    function refreshCurrentEntity(data) {
        currentEntity(specialtyImpl(data));
    }

    function loadEntityBySpecialtyId(id) {
        return specialtyBroker.findById(id).done(refreshCurrentEntity);
    }

    function refreshRanking(data) {
        ranking(data);
    }

    function loadRankingBySpecialtyId(specialtyId) {
        return competitionBroker.adultRankingsBySpecialtyId(specialtyId).done(refreshRanking);
    }

    function refreshNextCompetitions(data) {
        nextCompetitions(data);
    }

    function loadNextCompetitionsBySpecialtyId(specialtyId) {
        return competitionBroker.findNextBySpecialtyId(specialtyId).done(refreshNextCompetitions);
    }

    // module revelation
    viewModel.i18n = i18n;
    viewModel.router = router;
    viewModel.securityContext = securityContext;
    viewModel.validationUtils = validationUtils;
    viewModel.specialtyBroker = specialtyBroker;

    // state revelation
    viewModel.currentEntity = currentEntity;
    viewModel.ranking = ranking;
    viewModel.nextCompetitions = nextCompetitions;

    // lifecycle revelation
    viewModel.activate = activate;

    // behaviour revelation

    return viewModel;
});