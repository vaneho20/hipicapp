/* global define: false */
define([
    "core/authentication/authenticationBroker", "core/authentication/securityContext",
    "core/router", "i18next", "viewmodels/shell"
], function signinViewModel(authenticationBroker, securityContext, router, i18n, shell) {
    "use strict";

    // state definition
    var viewModel = {}, currentEntity = ko.observable(profileImpl()), availableMusicalStudyLevels = ko.observableArray([])
        , availableInstruments = ko.observableArray([]), availableGenders = [
            {
                genderId: profileImpl.gender.MALE,
                description: i18n.PROFILE_GENDER_MALE
            }, {
                genderId: profileImpl.gender.FEMALE,
                description: i18n.PROFILE_GENDER_FEMALE
            }
        ];

    // lifecycle definition
    function activate(route) {
        // allways return a promise
        return loadEntity();
    }

    // behaviour definition
    function refreshCurrentEntity(data) {
        currentEntity(profileImpl(data));
        if (data) {
            availableMusicalStudyLevels(data.MusicalStudyLevels);
            availableInstruments(data.Instruments);
        }
    }

    // Promise
    function loadEntity() {
        return authenticationBroker.newUserProfile().done(refreshCurrentEntity);
    }

    function signIn() {
        var entity = currentEntity();
        entity.dateOfBirth(moment(entity.dateOfBirth()));
        var modal = this.modal;
        return authenticationBroker.signIn(entity).done(function onSuccess() {
            modal.close();
        });
    }

    function close() {
        this.modal.close();
    }

    viewModel.i18n = i18n;

    viewModel.currentEntity = currentEntity;
    viewModel.availableGenders = availableGenders;
    viewModel.availableMusicalStudyLevels = availableMusicalStudyLevels;
    viewModel.availableInstruments = availableInstruments;

    // lifecycle revelation
    viewModel.activate = activate;

    // behaviour revelation
    viewModel.signIn = signIn;
    viewModel.close = close;

    return viewModel;
});