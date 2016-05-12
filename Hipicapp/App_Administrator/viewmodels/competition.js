/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/competition/competitionBroker",
    "domain/competition/competitionImpl", "domain/competitionCategory/competitionCategoryBroker",
    "domain/specialty/specialtyBroker", "viewmodels/shell", "viewmodels/alerts"
], function competitionViewModel(i18n, router, securityContext, stringUtils, urlUtils,
    validationUtils, competitionBroker, competitionImpl, competitionCategoryBroker,
    specialtyBroker, shell, alerts) {
    "use strict";

    // state definition
    var viewModel = {}, currentEntity = ko.observable(competitionImpl()), navs = {
        BASIC_DATA: "BASIC_DATA",
        IMAGES: "JUDGES"
    }, nav = ko.observable(), availableCategories = ko.observable(), availableSpecialties = ko.observable();

    // lifecycle definition
    function activate(id) {
        nav(navs.BASIC_DATA);
        if (id) {
            // allways return a promise
            return $.when(loadEntityByCompetitionId(id), loadAvailableCategories(), loadAvailableSpecialties());
        } else {
            return $.when(loadAvailableCategories(), loadAvailableSpecialties()).done(function onSuccess() {
                return refreshCurrentEntity();
            });
        }
    }

    // behaviour definition
    function refreshCurrentEntity(data) {
        currentEntity(competitionImpl(data));
        currentEntity().address.valueHasMutated();
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

    function refreshSpecialties(data) {
        availableSpecialties(data);
    }

    function loadAvailableSpecialties() {
        return specialtyBroker.findAll().done(refreshSpecialties);
    }

    function save() {
        var promise;
        if (currentEntity().id) {
            promise = competitionBroker.update(currentEntity());
        } else {
            promise = competitionBroker.save(currentEntity());
        }
        return promise.done(refreshCurrentEntity);
    }

    // module revelation
    viewModel.i18n = i18n;
    viewModel.securityContext = securityContext;
    viewModel.validationUtils = validationUtils;
    viewModel.competitionBroker = competitionBroker;

    // state revelation
    viewModel.currentEntity = currentEntity;
    viewModel.navs = navs;
    viewModel.nav = nav;
    viewModel.availableCategories = availableCategories;
    viewModel.availableSpecialties = availableSpecialties;

    // lifecycle revelation
    viewModel.activate = activate;

    // behaviour revelation
    viewModel.save = save;

    return viewModel;
});