/* global _: false, define: false, ko: false */
/* jshint maxparams: 25, maxstatements: 100 */
define([
    "core/i18n", "core/util/stringUtils", "core/util/urlUtils", "core/util/validationUtils",
    "domain/user/userBroker", "domain/user/userImpl", "core/router", "viewmodels/shell",
    "viewmodels/alerts"
],
    function userViewModel(i18n, stringUtils, urlUtils, validationUtils, userBroker,
                           userImpl, router, shell, alerts) {

        "use strict";

        // state definition
        var viewModel = {}, currentEntity = ko.observable(userImpl()), navs = {
            BASIC_DATA : "BASIC_DATA",
            CHANGE_PASSWORD : "CHANGE_PASSWORD",
            USER_PROMOTIONS : "USER_PROMOTIONS"
        }, nav = ko.observable();

        // lifecycle definition
        function activate(route) {

            nav(navs.BASIC_DATA);

            if (route && route.id) {
                // allways return a promise
                return $.when(loadEntityByUserId(route.id));
            } else {
                refreshCurrentEntity();
            }
        }

        // behaviour definition
        function refreshCurrentEntity(data) {
            currentEntity(userImpl(data));
        }

        function loadEntityByUserId(id) {
            return userBroker.findByUserId(id).done(refreshCurrentEntity);
        }

        function save() {

            var promise = userBroker.save(userImpl(currentEntity())).done(refreshCurrentEntity);

            return promise;
        }

        // module revelation
        viewModel.i18n = i18n;
        viewModel.validationUtils = validationUtils;
        viewModel.userBroker = userBroker;
        viewModel.userImpl = userImpl;

        // state revelation
        viewModel.currentEntity = currentEntity;
        viewModel.navs = navs;
        viewModel.nav = nav;

        // lifecycle revelation
        viewModel.activate = activate;

        // behaviour revelation
        viewModel.save = save;

        return viewModel;
    });