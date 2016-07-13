/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/horse/horseBroker",
    "domain/horse/horseImpl", "viewmodels/athlete", "viewmodels/alerts", "viewmodels/shell"
], function athleteHorseViewModel(i18n, router, securityContext, stringUtils, urlUtils, validationUtils,
    horseBroker, horseImpl, athleteViewModel, alerts, shell) {
    "use strict";

    // state definition
    var viewModel = $.extend(false, {}, athleteViewModel), superActivate = viewModel.activate,
        currentHorseEntity = ko.observable(horseImpl()), superCurrentEntity = viewModel.currentEntity, navs = {
            BASIC_DATA: "BASIC_DATA",
            IMAGES: "IMAGES"
        }, nav = ko.observable(), superAvailableGenders = viewModel.availableGenders, availableGenders = [
            {
                value: "male",
                text: i18n.t("app:GENDER_MALE")
            }, {
                value: "female",
                text: i18n.t("app:GENDER_FEMALE")
            }
        ];

    // lifecycle definition
    function activate(horseId) {
        if (horseId) {
            // allways return a promise
            return $.when(superActivate(), loadEntityByHorseId(horseId)).done(refreshNav);
        } else {
            return $.when(superActivate().done(function onSuccess() {
                refreshCurrentEntity();
                refreshNav();
            }));
        }
    }

    function refreshNav() {
        nav(navs.BASIC_DATA);
    }

    // behaviour definition
    function refreshCurrentEntity(data) {
        currentHorseEntity(horseImpl(data));
        currentHorseEntity.valueHasMutated();
    }

    function loadEntityByHorseId(id) {
        return horseBroker.findById(id).done(refreshCurrentEntity);
    }

    function save() {
        var promise;
        currentHorseEntity().athleteId = superCurrentEntity().id;
        if (currentHorseEntity().id) {
            promise = horseBroker.update(currentHorseEntity());
        } else {
            promise = horseBroker.save(currentHorseEntity());
        }
        return promise.done(function success() {
            router.navigateToProfile();
        });
    }

    // module revelation
    viewModel.i18n = i18n;
    viewModel.router = router;
    viewModel.securityContext = securityContext;
    viewModel.validationUtils = validationUtils;
    viewModel.athleteBroker = athleteViewModel.athleteBroker;
    viewModel.competitionBroker = athleteViewModel.competitionBroker;
    viewModel.fileBroker = athleteViewModel.fileBroker;
    viewModel.horseBroker = athleteViewModel.horseBroker;
    viewModel.judgeBroker = athleteViewModel.judgeBroker;
    viewModel.specialtyBroker = athleteViewModel.specialtyBroker;

    // state revelation
    viewModel.currentHorseEntity = currentHorseEntity;
    viewModel.superCurrentEntity = superCurrentEntity;
    viewModel.navs = navs;
    viewModel.nav = nav;
    viewModel.availableGenders = availableGenders;
    viewModel.superAvailableGenders = superAvailableGenders;

    // lifecycle revelation
    viewModel.activate = activate;

    // behaviour revelation
    viewModel.save = save;

    return viewModel;
});