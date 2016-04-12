/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/athlete/athleteBroker",
    "domain/athlete/athleteImpl", "durandal/app", "viewmodels/shell", "viewmodels/alerts"
],
    function registerViewModel(i18n, router, securityContext, stringUtils, urlUtils,
                                 validationUtils, athleteBroker, athleteImpl, app, shell,
                                 alerts) {
        "use strict";

        // state definition
        var viewModel = {}, currentEntity = ko.observable(athleteImpl()), availableGenders = [
            {
                value: athleteImpl.genders.MALE,
                text: i18n.t("app:ATHLETE_GENDER_MALE")
            }, {
                value: athleteImpl.genders.FEMALE,
                text: i18n.t("app:ATHLETE_GENDER_FEMALE")
            }
        ];

        // lifecycle definition
        function activate() {
            return;
        }

        // behaviour definition
        function refreshCurrentEntity(data) {
            app.setRoot('viewmodels/login', 'entrance');
        }

        function signIn() {
            return athleteBroker.save(currentEntity()).done(refreshCurrentEntity);
        }

        // module revelation
        viewModel.i18n = i18n;
        viewModel.securityContext = securityContext;
        viewModel.validationUtils = validationUtils;
        viewModel.athleteBroker = athleteBroker;

        // state revelation
        viewModel.currentEntity = currentEntity;
        viewModel.availableGenders = availableGenders;

        // lifecycle revelation
        viewModel.activate = activate;

        // behaviour revelation
        viewModel.signIn = signIn;

        return viewModel;
    });