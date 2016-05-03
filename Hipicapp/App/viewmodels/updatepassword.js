/* global define: false */
define([
    "core/authentication/authenticationBroker", "core/authentication/securityContext",
    "core/router", "core/i18n", "domain/ticket/ticketImpl"
], function updatePasswordViewModel(authenticationBroker, securityContext, router, i18n, ticketImpl) {
    "use strict";

    // state definition
    var viewModel = {}, currentEntity = ko.observable(ticketImpl()),
        updatedPassword = ko.observable();

    // lifecycle definition
    function activate(key) {
        updatedPassword(false);
        // allways return a promise
        return checkTicket(key);
    }

    // behaviour definition
    function refreshCurrentEntity(data) {
        currentEntity(ticketImpl(data));
    }

    // Promise
    function checkTicket(key) {
        return authenticationBroker.checkTicket(key).done(refreshCurrentEntity);
    }

    function update() {
        if (currentEntity().key()) {
            return authenticationBroker.updatePassword(currentEntity()).done(function onSuccess(data) {
                securityContext.refresh(data);
                updatedPassword(true);
            });
        }
    }

    viewModel.i18n = i18n;

    // lifecycle revelation
    viewModel.activate = activate;

    viewModel.currentEntity = currentEntity;
    viewModel.updatedPassword = updatedPassword;

    viewModel.update = update;

    return viewModel;
});