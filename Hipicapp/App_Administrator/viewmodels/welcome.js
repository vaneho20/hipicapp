/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/user/userBroker",
    "viewmodels/shell", "viewmodels/alerts"
], function welcomeViewModel(i18n, router, securityContext, stringUtils, urlUtils,
                                 validationUtils, userBroker, shell, alerts) {
    "use strict";

    // state definition
    var viewModel = {}, tileCount = ko.observable();

    // lifecycle definition
    function activate() {
        // allways return a promise
        return loadTileCount();
    }

    // behaviour definition
    function refreshTileCount(data) {
        tileCount(data);
    }

    function loadTileCount() {
        return userBroker.getTileCount().done(refreshTileCount);
    }

    // module revelation
    viewModel.i18n = i18n;
    viewModel.securityContext = securityContext;
    viewModel.validationUtils = validationUtils;
    viewModel.userBroker = userBroker;

    // state revelation
    viewModel.tileCount = tileCount;

    // lifecycle revelation
    viewModel.activate = activate;

    // behaviour revelation

    return viewModel;
});