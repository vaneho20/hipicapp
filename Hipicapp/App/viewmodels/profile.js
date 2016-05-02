/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/athlete/athleteBroker",
    "domain/athlete/athleteImpl", "domain/file/fileBroker", "viewmodels/shell", "viewmodels/alerts"
],
    function athleteViewModel(i18n, router, securityContext, stringUtils, urlUtils,
                                 validationUtils, athleteBroker, athleteImpl, fileBroker, shell,
                                 alerts) {
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
        ];

        // lifecycle definition
        function activate() {
            return loadEntityByCurrentUser();
        }

        // behaviour definition
        function refreshCurrentEntity(data) {
            currentEntity(athleteImpl(data));
            /*if (securityContext.getPrincipal().autoLogin) {
                alerts.warn(i18n.ATHLETE_COMPLETE_REGISTRATION);
                securityContext.getPrincipal().autoLogin = false;
            }*/
        }

        function loadEntityByCurrentUser() {
            return athleteBroker.getByCurrentUser().done(refreshCurrentEntity);
        }

        // module revelation
        viewModel.i18n = i18n;
        viewModel.securityContext = securityContext;
        viewModel.validationUtils = validationUtils;
        viewModel.athleteBroker = athleteBroker;
        viewModel.fileBroker = fileBroker;

        // state revelation
        viewModel.currentEntity = currentEntity;
        viewModel.availableGenders = availableGenders;

        // lifecycle revelation
        viewModel.activate = activate;

        // behaviour revelation

        return viewModel;
    });