/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/banner/bannerBroker",
    "domain/banner/bannerImpl", "domain/specialty/specialtyBroker", "viewmodels/shell", "viewmodels/alerts"
], function bannerViewModel(i18n, router, securityContext, stringUtils, urlUtils,
    validationUtils, bannerBroker, bannerImpl, specialtyBroker, shell, alerts) {
    "use strict";

    // state definition
    var viewModel = {}, currentEntity = ko.observable(bannerImpl()), navs = {
        BASIC_DATA: "BASIC_DATA",
        IMAGES: "IMAGES"
    }, nav = ko.observable(), availableSpecialties = ko.observable();

    // lifecycle definition
    function activate(id) {
        nav(navs.BASIC_DATA);

        if (id) {
            // allways return a promise
            return $.when(loadEntityByBannerId(id), loadAvailableSpecialties());
        } else {
            return $.when(loadAvailableSpecialties()).done(function onSuccess() {
                return refreshCurrentEntity();
            });
        }
    }

    // behaviour definition
    function refreshCurrentEntity(data) {
        currentEntity(bannerImpl(data));
    }

    function loadEntityByBannerId(id) {
        return bannerBroker.findById(id).done(refreshCurrentEntity);
    }

    function refreshSpecialties(data) {
        availableSpecialties(data);
    }

    function loadAvailableSpecialties() {
        return specialtyBroker.findAll().done(refreshSpecialties);
    }

    function save() {
        var promise;
        if (currentEntity().id) {
            promise = bannerBroker.update(currentEntity());
        } else {
            promise = bannerBroker.save(currentEntity());
        }
        return promise.done(refreshCurrentEntity);
    }

    // module revelation
    viewModel.i18n = i18n;
    viewModel.securityContext = securityContext;
    viewModel.validationUtils = validationUtils;
    viewModel.bannerBroker = bannerBroker;

    // state revelation
    viewModel.currentEntity = currentEntity;
    viewModel.navs = navs;
    viewModel.nav = nav;
    viewModel.availableSpecialties = availableSpecialties;

    // lifecycle revelation
    viewModel.activate = activate;

    // behaviour revelation
    viewModel.save = save;

    return viewModel;
});