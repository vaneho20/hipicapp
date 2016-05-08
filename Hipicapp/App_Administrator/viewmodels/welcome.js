/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/competition/competitionBroker",
    "domain/user/userBroker", "viewmodels/shell", "viewmodels/alerts"
], function welcomeViewModel(i18n, router, securityContext, stringUtils, urlUtils,
    validationUtils, competitionBroker, userBroker, shell, alerts) {
    "use strict";

    // state definition
    var viewModel = {}, tileCount = ko.observable(), lastCompetitions = ko.observableArray([]);

    // lifecycle definition
    function activate() {
        // allways return a promise
        return $.when(loadTileCount(), loadLastCompetitions());
    }

    // behaviour definition
    function refreshTileCount(data) {
        tileCount(data);
    }

    function loadTileCount() {
        return userBroker.getTileCount().done(refreshTileCount);
    }

    function refreshLastCompetitions(data) {
        lastCompetitions(data);
    }

    function loadLastCompetitions() {
        return competitionBroker.findLast().done(refreshLastCompetitions);
    }

    // module revelation
    viewModel.i18n = i18n;
    viewModel.securityContext = securityContext;
    viewModel.validationUtils = validationUtils;
    viewModel.competitionBroker = competitionBroker;
    viewModel.userBroker = userBroker;

    // state revelation
    viewModel.lastCompetitions = lastCompetitions;
    viewModel.tileCount = tileCount;

    // lifecycle revelation
    viewModel.activate = activate;

    // behaviour revelation

    return viewModel;
});