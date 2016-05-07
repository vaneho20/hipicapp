/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/judge/judgeBroker",
    "domain/judge/judgeImpl", "viewmodels/shell", "viewmodels/alerts"
], function judgeViewModel(i18n, router, securityContext, stringUtils, urlUtils,
                                 validationUtils, judgeBroker, judgeImpl, shell, alerts) {
        "use strict";

        // state definition
        var viewModel = {}, currentEntity = ko.observable(judgeImpl()), navs = {
            BASIC_DATA: "BASIC_DATA",
            IMAGES: "IMAGES"
        }, nav = ko.observable(), availableGenders = [
            {
                value: "male",
                text: i18n.t("app:GENDER_MALE")
            }, {
                value: "female",
                text: i18n.t("app:GENDER_FEMALE")
            }
        ];

        // lifecycle definition
        function activate(id) {
            if (id) {
                // allways return a promise
                return loadEntityByJudgeId(id).done(refreshNav);
            } else {
                refreshCurrentEntity();
                refreshNav();
            }
        }

        function refreshNav() {
            nav(navs.BASIC_DATA);
        }

        // behaviour definition
        function refreshCurrentEntity(data) {
            currentEntity(judgeImpl(data));
            /*if (securityContext.getPrincipal().autoLogin) {
                alerts.warn(i18n.ATHLETE_COMPLETE_REGISTRATION);
                securityContext.getPrincipal().autoLogin = false;
            }*/
        }

        function loadEntityByJudgeId(id) {
            return judgeBroker.findById(id).done(refreshCurrentEntity);
        }

        function save() {
            var promise;
            if (currentEntity().id) {
                promise = judgeBroker.update(currentEntity());
            } else {
                promise = judgeBroker.save(currentEntity());
            }
            return promise.done(refreshCurrentEntity);
        }

        // module revelation
        viewModel.i18n = i18n;
        viewModel.securityContext = securityContext;
        viewModel.validationUtils = validationUtils;
        viewModel.judgeBroker = judgeBroker;

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