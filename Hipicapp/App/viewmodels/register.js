/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/athlete/athleteBroker",
    "domain/athlete/athleteImpl", "domain/specialty/specialtyBroker", "durandal/app",
    "viewmodels/shell", "viewmodels/alerts"
], function registerViewModel(i18n, router, securityContext, stringUtils, urlUtils,
    validationUtils, athleteBroker, athleteImpl, specialtyBroker, app, shell, alerts) {
    "use strict";

    // state definition
    var viewModel = {}, currentEntity = ko.observable(athleteImpl()), availableGenders = [
        {
            value: "male",
            text: i18n.t("app:GENDER_MALE")
        }, {
            value: "female",
            text: i18n.t("app:GENDER_FEMALE")
        }
    ], availableSpecialties = ko.observable();

    // lifecycle definition
    function activate() {
        return $.when(loadAvailableSpecialties());
    }

    // behaviour definition
    function refreshCurrentEntity(data) {
        securityContext.refresh(data);
        router.navigate("#athlete");
        router.reloadCurrentLocation();
    }

    function refreshSpecialties(data) {
        availableSpecialties(data);
    }

    function loadAvailableSpecialties() {
        return specialtyBroker.findAll().done(refreshSpecialties);
    }

    function signIn() {
        return athleteBroker.register(currentEntity()).done(refreshCurrentEntity);
    }

    // module revelation
    viewModel.i18n = i18n;
    viewModel.securityContext = securityContext;
    viewModel.validationUtils = validationUtils;
    viewModel.athleteBroker = athleteBroker;

    // state revelation
    viewModel.currentEntity = currentEntity;
    viewModel.availableGenders = availableGenders;
    viewModel.availableSpecialties = availableSpecialties;

    // lifecycle revelation
    viewModel.activate = activate;

    // behaviour revelation
    viewModel.signIn = signIn;

    return viewModel;
});