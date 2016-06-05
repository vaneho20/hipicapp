/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils", "core/util/urlUtils",
    "core/util/validationUtils", "domain/athlete/athleteBroker", "domain/athlete/athleteImpl",
    "domain/competition/competitionBroker", "domain/competitionCategory/competitionCategoryBroker", "domain/file/fileBroker",
    "domain/horse/horseBroker", "domain/judge/judgeBroker", "domain/specialty/specialtyBroker", "viewmodels/shell",
    "viewmodels/alerts"
], function athleteViewModel(i18n, router, securityContext, stringUtils, urlUtils, validationUtils,
    athleteBroker, athleteImpl, competitionBroker, competitionCategoryBroker, fileBroker, horseBroker, judgeBroker,
    specialtyBroker, shell, alerts) {
    "use strict";

    // state definition
    var viewModel = {}, currentEntity = ko.observable(athleteImpl()), navs = {
        BASIC_DATA: "BASIC_DATA",
        IMAGES: "IMAGES",
        HORSES: "HORSES"
    }, nav = ko.observable(), availableGenders = [
        {
            value: "male",
            text: i18n.t("app:GENDER_MALE")
        }, {
            value: "female",
            text: i18n.t("app:GENDER_FEMALE")
        }
    ], availableCategories = ko.observable(), availableSpecialties = ko.observable();

    // lifecycle definition
    function activate() {
        nav(navs.BASIC_DATA);

        // allways return a promise
        return $.when(loadEntityByAthleteId(), loadAvailableCategories(), loadAvailableSpecialties());
    }

    // behaviour definition
    function refreshCurrentEntity(data) {
        currentEntity(athleteImpl(data));
    }

    function loadEntityByAthleteId() {
        return athleteBroker.getByCurrentUser().done(refreshCurrentEntity);
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
            promise = athleteBroker.update(currentEntity());
        } else {
            promise = athleteBroker.save(currentEntity());
        }
        return promise.done(refreshCurrentEntity);
    }

    // module revelation
    viewModel.i18n = i18n;
    viewModel.securityContext = securityContext;
    viewModel.validationUtils = validationUtils;
    viewModel.athleteBroker = athleteBroker;
    viewModel.competitionBroker = competitionBroker;
    viewModel.fileBroker = fileBroker;
    viewModel.horseBroker = horseBroker;
    viewModel.judgeBroker = judgeBroker;
    viewModel.specialtyBroker = specialtyBroker;

    // state revelation
    viewModel.currentEntity = currentEntity;
    viewModel.navs = navs;
    viewModel.nav = nav;
    viewModel.availableGenders = availableGenders;
    viewModel.availableCategories = availableCategories;
    viewModel.availableSpecialties = availableSpecialties;

    // lifecycle revelation
    viewModel.activate = activate;

    // behaviour revelation
    viewModel.save = save;

    return viewModel;
});