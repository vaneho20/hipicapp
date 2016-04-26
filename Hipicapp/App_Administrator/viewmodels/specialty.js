/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/specialty/specialtyBroker",
    "domain/specialty/specialtyImpl", "viewmodels/shell", "viewmodels/alerts"
],
    function specialtyViewModel(i18n, router, securityContext, stringUtils, urlUtils,
                                 validationUtils, specialtyBroker, specialtyImpl, shell,
                                 alerts) {
        "use strict";

        // state definition
        var viewModel = {}, currentEntity = ko.observable(specialtyImpl());

        // lifecycle definition
        function activate(id) {
            if (id) {
                // allways return a promise
                return loadEntityBySpecialtyId(id);
            } else {
                refreshCurrentEntity();
            }
        }

        // behaviour definition
        function refreshCurrentEntity(data) {
            currentEntity(specialtyImpl(data));
        }

        function loadEntityBySpecialtyId(id) {
            return specialtyBroker.findById(id).done(refreshCurrentEntity);
        }

        function save() {
            var promise;
            if (currentEntity().id) {
                promise = specialtyBroker.update(currentEntity());
            } else {
                promise = specialtyBroker.save(currentEntity());
            }
            return promise.done(refreshCurrentEntity);
        }

        // module revelation
        viewModel.i18n = i18n;
        viewModel.securityContext = securityContext;
        viewModel.validationUtils = validationUtils;
        viewModel.specialtyBroker = specialtyBroker;

        // state revelation
        viewModel.currentEntity = currentEntity;

        // lifecycle revelation
        viewModel.activate = activate;

        // behaviour revelation
        viewModel.save = save;

        return viewModel;
    });