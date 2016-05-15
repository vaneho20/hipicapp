/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/athlete/athleteBroker",
    "domain/athlete/athleteImpl", "domain/competition/competitionBroker", "domain/file/fileBroker",
    "domain/horse/horseBroker", "domain/judge/judgeBroker", "domain/specialty/specialtyBroker",
    "viewmodels/shell", "viewmodels/alerts"
], function athleteViewModel(i18n, router, securityContext, stringUtils, urlUtils, validationUtils,
    athleteBroker, athleteImpl, competitionBroker, fileBroker, horseBroker, judgeBroker, specialtyBroker,
    shell, alerts) {
    "use strict";

    // state definition
    var viewModel = {}, currentEntity = ko.observable(athleteImpl()), availableGenders = {
        "male": i18n.t("app:GENDER_MALE"), "female": i18n.t("app:GENDER_FEMALE")
    }, availableCategories = ko.observable();

    // lifecycle definition
    function activate(id) {
        if (id || securityContext.isAthlete()) {
            // allways return a promise
            return $.when(loadEntityByAthleteId(id));
        } else {
            return refreshCurrentEntity();
        }
    }

    // behaviour definition
    function refreshCurrentEntity(data) {
        currentEntity(athleteImpl(data));
    }

    function loadEntityByAthleteId(id) {
        var promise;
        if (securityContext.isAthlete()) {
            promise = athleteBroker.getByCurrentUser().done(refreshCurrentEntity);
        } else {
            promise = athleteBroker.findById(id).done(refreshCurrentEntity);
        }
        return promise;
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
    viewModel.availableGenders = availableGenders;

    // lifecycle revelation
    viewModel.activate = activate;

    // behaviour revelation
    viewModel.save = save;

    return viewModel;
});