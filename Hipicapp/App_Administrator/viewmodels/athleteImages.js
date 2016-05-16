/* global define: false */
define([
    "core/i18n", "core/util/validationUtils", "domain/file/fileBroker",
    "domain/athlete/athleteBroker", "viewmodels/athlete"
], function athleteImages(i18n, validationUtils, fileBroker, athleteBroker,
                             athleteViewModel) {
    "use strict";

    // state definition
    var viewModel = $.extend(false, {}, athleteViewModel), superActivate = viewModel.activate;

    function activate(athleteId) {
        return superActivate(athleteId).done(refreshNav);
    }

    function refreshNav() {
        viewModel.nav(viewModel.navs.IMAGES);
    }

    // module revelation
    viewModel.fileBroker = fileBroker;
    viewModel.athleteBroker = athleteBroker;

    // behaviour revelation
    viewModel.activate = activate;

    return viewModel;
});