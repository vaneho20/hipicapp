/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/competition/competitionBroker",
    "domain/competition/competitionImpl", "domain/competitionCategory/competitionCategoryBroker",
    "viewmodels/shell", "viewmodels/alerts"
],
    function competitionViewModel(i18n, router, securityContext, stringUtils, urlUtils,
                                 validationUtils, competitionBroker, competitionImpl, competitionCategoryBroker,
                                 shell, alerts) {
        "use strict";

        // state definition
        var viewModel = {}, currentEntity = ko.observable(competitionImpl()), availableCategories = ko.observable();

        // lifecycle definition
        function activate(id) {
            if (id) {
                // allways return a promise
                return $.when(loadEntityByCompetitionId(id), loadAvailableCategories());
            } else {
                return $.when(loadAvailableCategories()).done(function onSuccess() {
                    return refreshCurrentEntity();
                });
            }
        }

        // behaviour definition
        function refreshCurrentEntity(data) {
            currentEntity(competitionImpl(data));
        }

        function loadEntityByCompetitionId(id) {
            return competitionBroker.findById(id).done(refreshCurrentEntity);
        }

        function refreshCategories(data) {
            availableCategories(data);
        }

        function loadAvailableCategories() {
            return competitionCategoryBroker.findAll().done(refreshCategories);
        }

        function save() {
            return competitionBroker.save(currentEntity()).done(refreshCurrentEntity);
        }

        // module revelation
        viewModel.i18n = i18n;
        viewModel.securityContext = securityContext;
        viewModel.validationUtils = validationUtils;
        viewModel.competitionBroker = competitionBroker;

        // state revelation
        viewModel.currentEntity = currentEntity;
        viewModel.availableCategories = availableCategories;

        // lifecycle revelation
        viewModel.activate = activate;

        // behaviour revelation
        viewModel.save = save;

        return viewModel;
    });