/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/athlete/athleteBroker",
    "domain/banner/bannerBroker", "domain/competition/competitionBroker", "domain/file/fileBroker",
    "domain/horse/horseBroker", "domain/judge/judgeBroker", "domain/specialty/specialtyBroker",
    "domain/specialty/specialtyImpl", "viewmodels/shell", "viewmodels/alerts"
], function specialtyViewModel(i18n, router, securityContext, stringUtils, urlUtils, validationUtils,
    athleteBroker, bannerBroker, competitionBroker, fileBroker, horseBroker, judgeBroker, specialtyBroker,
    specialtyImpl, shell, alerts) {
    "use strict";

    // state definition
    var viewModel = {}, currentEntity = ko.observable(specialtyImpl()), ranking = ko.observableArray([]);

    // lifecycle definition
    function activate(id) {
        if (id) {
            // allways return a promise
            return $.when(loadEntityBySpecialtyId(id), loadRankingBySpecialtyId(id));
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
        return competitionBroker.fullAdultRankingsBySpecialtyId(specialtyId).done(refreshRanking);
    }

    // module revelation
    viewModel.i18n = i18n;
    viewModel.router = router;
    viewModel.securityContext = securityContext;
    viewModel.validationUtils = validationUtils;
    viewModel.athleteBroker = athleteBroker;
    viewModel.competitionBroker = competitionBroker;
    viewModel.fileBroker = fileBroker;
    viewModel.horseBroker = horseBroker;
    viewModel.judgeBroker = judgeBroker;
    viewModel.specialtyBroker = specialtyBroker;
    viewModel.shell = shell;

    // state revelation
    viewModel.currentEntity = currentEntity;
    viewModel.ranking = ranking;

    // lifecycle revelation
    viewModel.activate = activate;

    // behaviour revelation

    return viewModel;
});