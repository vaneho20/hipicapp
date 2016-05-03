/* global define: false */
define([
    "core/authentication/authenticationBroker", "core/authentication/securityContext",
    "core/router", "core/i18n"
], function passwordResetViewModel(authenticationBroker, securityContext, router, i18n) {
    "use strict";

    // state definition
    var viewModel = {}, userName = ko.observable().extend({ required: true, email: true }),
        mailSent = ko.observable();

    // lifecycle definition
    function activate(route) {
        mailSent(false);
    }

    function reset() {
        return authenticationBroker.resetPassword(userName()).done(function onSuccess() {
            mailSent(true);
        });
    }

    viewModel.i18n = i18n;

    viewModel.userName = userName;
    viewModel.mailSent = mailSent;

    // lifecycle revelation
    viewModel.activate = activate;

    // behaviour revelation
    viewModel.reset = reset;

    return viewModel;
});