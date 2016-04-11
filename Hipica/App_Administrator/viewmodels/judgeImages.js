/* global define: false */
define([
    "core/i18n", "core/util/validationUtils", "domain/file/fileBroker",
    "domain/judge/judgeBroker", "viewmodels/judge"
], function judgeImages(i18n, validationUtils, fileBroker, judgeBroker,
                             judgeViewModel) {
    "use strict";

    // state definition
    var viewModel = $.extend(false, {}, judgeViewModel), superActivate = viewModel.activate;

    function activate(route) {
        return superActivate(route).done(refreshNav);
    }

    function refreshNav() {
        viewModel.nav(viewModel.navs.IMAGES);
    }

    // module revelation
    viewModel.fileBroker = fileBroker;
    viewModel.judgeBroker = judgeBroker;

    // behaviour revelation
    viewModel.activate = activate;

    return viewModel;
});