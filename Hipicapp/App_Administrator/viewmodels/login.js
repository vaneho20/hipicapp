/* global define: false */
define([
    "core/authentication/authenticationBroker", "core/authentication/securityContext",
    "core/router", "core/util/validationUtils", "durandal/app", "viewmodels/shell", "core/i18n"
], function loginViewModel(authenticationBroker, securityContext, router, validationUtils, app, shell, i18n) {
    "use strict";

    var viewModel = {}, credentials = {
        userName: null,
        password: ko.observable(null),
        rememberMe: null
    };

    function refreshSecurityContext(data) {
        credentials.password(null);
        securityContext.refresh(data);
        router.reloadCurrentLocation();
    }

    function login() {
        var promise = authenticationBroker.login(credentials).done(refreshSecurityContext);

        return promise;
    }

    viewModel.i18n = i18n;
    viewModel.validationUtils = validationUtils;

    viewModel.credentials = credentials;

    viewModel.login = login;

    return viewModel;
});