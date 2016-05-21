/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/athlete/athleteBroker",
    "domain/competition/competitionBroker", "domain/file/fileBroker", "domain/horse/horseBroker",
    "domain/horse/horseImpl", "domain/judge/judgeBroker", "domain/specialty/specialtyBroker",
    "viewmodels/shell", "viewmodels/alerts"
], function horseViewModel(i18n, router, securityContext, stringUtils, urlUtils, validationUtils, athleteBroker,
    competitionBroker, fileBroker, horseBroker, horseImpl, judgeBroker, specialtyBroker, shell, alerts) {
    "use strict";

    // state definition
    var viewModel = {}, currentEntity = ko.observable(horseImpl()), availableGenders = {
        "male": i18n.t("app:GENDER_MALE"), "female": i18n.t("app:GENDER_FEMALE")
    };

    // lifecycle definition
    function activate(horseId) {
        if (horseId) {
            // allways return a promise
            return loadEntityByHorseId(horseId);
        } else {
            refreshCurrentEntity();
        }
    }

    // behaviour definition
    function refreshCurrentEntity(data) {
        currentEntity(horseImpl(data));
    }

    function loadEntityByHorseId(id) {
        return horseBroker.findById(id).done(refreshCurrentEntity);
    }

    function save() {
        var promise;
        if (currentEntity().id) {
            promise = horseBroker.update(currentEntity());
        } else {
            promise = horseBroker.save(currentEntity());
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