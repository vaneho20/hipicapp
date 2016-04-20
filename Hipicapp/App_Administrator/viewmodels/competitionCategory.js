/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/competitionCategory/competitionCategoryBroker",
    "domain/competitionCategory/competitionCategoryImpl", "viewmodels/shell", "viewmodels/alerts"
],
    function competitionCategoryViewModel(i18n, router, securityContext, stringUtils, urlUtils,
                                 validationUtils, competitionCategoryBroker, competitionCategoryImpl, shell,
                                 alerts) {
        "use strict";

        // state definition
        var viewModel = {}, currentEntity = ko.observable(competitionCategoryImpl());

        // lifecycle definition
        function activate(id) {
            if (id) {
                // allways return a promise
                return loadEntityByCompetitionCategoryId(id);
            } else {
                refreshCurrentEntity();
            }
        }

        // behaviour definition
        function refreshCurrentEntity(data) {
            currentEntity(competitionCategoryImpl(data));
        }

        function loadEntityByCompetitionCategoryId(id) {
            return competitionCategoryBroker.findById(id).done(refreshCurrentEntity);
        }

        function save() {
            var promise;
            if (currentEntity().id) {
                promise = competitionCategoryBroker.update(currentEntity());
            } else {
                promise = competitionCategoryBroker.save(currentEntity());
            }
            return promise.done(refreshCurrentEntity);
        }

        // module revelation
        viewModel.i18n = i18n;
        viewModel.securityContext = securityContext;
        viewModel.validationUtils = validationUtils;
        viewModel.competitionCategoryBroker = competitionCategoryBroker;

        // state revelation
        viewModel.currentEntity = currentEntity;

        // lifecycle revelation
        viewModel.activate = activate;

        // behaviour revelation
        viewModel.save = save;

        return viewModel;
    });