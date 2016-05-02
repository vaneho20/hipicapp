/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/athlete/athleteBroker",
    "domain/athlete/athleteImpl", "viewmodels/shell", "viewmodels/alerts"
],
    function athleteViewModel(i18n, router, securityContext, stringUtils, urlUtils, validationUtils, athleteBroker,
        athleteImpl, shell, alerts) {
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
        ], availableCategories = ko.observable();

        // lifecycle definition
        function activate(id) {
            nav(navs.BASIC_DATA);

            if (securityContext.isAthlete()) {
                id = securityContext.getPrincipal().id;
            }

            if (id) {
                // allways return a promise
                return $.when(loadEntityByAthleteId(id));
            } else {
                return refreshCurrentEntity();
            }
        }

        // behaviour definition
        function refreshCurrentEntity(data) {
            currentEntity(athleteImpl(data));
            /*if (securityContext.getPrincipal().autoLogin) {
                alerts.warn(i18n.ATHLETE_COMPLETE_REGISTRATION);
                securityContext.getPrincipal().autoLogin = false;
            }*/
        }

        function loadEntityByAthleteId(id) {
            return athleteBroker.findById(id).done(refreshCurrentEntity);
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

        // state revelation
        viewModel.currentEntity = currentEntity;
        viewModel.navs = navs;
        viewModel.nav = nav;
        viewModel.availableGenders = availableGenders;

        // lifecycle revelation
        viewModel.activate = activate;

        // behaviour revelation
        viewModel.save = save;

        return viewModel;
    });