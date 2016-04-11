/* global define: false */
define([
    "core/authentication/authenticationBroker", "core/authentication/securityContext",
    "core/router", "core/i18n", "durandal/app", "viewmodels/login", "viewmodels/shell"
], function sidebar(authenticationBroker, securityContext, router, i18n, app, login, shell) {
    "use strict";

    var viewModel = {};

    function search() {
    }

    viewModel.search = search;

    viewModel.shell = shell;
    viewModel.login = login;
    viewModel.securityContext = securityContext;

    return viewModel;
});