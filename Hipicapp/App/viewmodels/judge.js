/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/athlete/athleteBroker",
    "domain/competition/competitionBroker", "domain/file/fileBroker", "domain/horse/horseBroker",
    "domain/judge/judgeBroker", "domain/judge/judgeImpl", "domain/specialty/specialtyBroker",
    "viewmodels/shell", "viewmodels/alerts"
], function judgeViewModel(i18n, router, securityContext, stringUtils, urlUtils,
    validationUtils, athleteBroker, competitionBroker, fileBroker, horseBroker, judgeBroker, judgeImpl,
    specialtyBroker, shell, alerts) {
    "use strict";

    // state definition
    var viewModel = {}, currentEntity = ko.observable(judgeImpl()), availableGenders = {
        "male": i18n.t("app:GENDER_MALE"), "female": i18n.t("app:GENDER_FEMALE")
    }, availableCategories = ko.observable();

    // lifecycle definition
    function activate(id) {
        if (id) {
            // allways return a promise
            return loadEntityByJudgeId(id);
        } else {
            refreshCurrentEntity();
        }
    }

    // behaviour definition
    function refreshCurrentEntity(data) {
        currentEntity(judgeImpl(data));
    }

    function loadEntityByJudgeId(id) {
        return judgeBroker.findById(id).done(refreshCurrentEntity);
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

    return viewModel;
});