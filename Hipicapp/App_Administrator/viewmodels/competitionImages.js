/* global define: false */
define([
    "core/i18n", "core/util/validationUtils", "domain/file/fileBroker",
    "domain/competition/competitionBroker", "viewmodels/competition"
], function competitionImages(i18n, validationUtils, fileBroker, competitionBroker,
    competitionViewModel) {
    "use strict";

    // state definition
    var viewModel = $.extend(false, {}, competitionViewModel), superActivate = viewModel.activate;

    function activate(competitionId) {
        return superActivate(competitionId).done(refreshNav);
    }

    function refreshNav() {
        viewModel.nav(viewModel.navs.IMAGES);
    }

    // module revelation
    viewModel.fileBroker = fileBroker;
    viewModel.competitionBroker = competitionBroker;

    // behaviour revelation
    viewModel.activate = activate;

    return viewModel;
});