/* global define: false */
define([
    "core/i18n", "core/util/validationUtils", "domain/file/fileBroker",
    "domain/banner/bannerBroker", "viewmodels/banner"
], function bannerImages(i18n, validationUtils, fileBroker, bannerBroker, bannerViewModel) {
    "use strict";

    // state definition
    var viewModel = $.extend(false, {}, bannerViewModel), superActivate = viewModel.activate;

    function activate(bannerId) {
        return superActivate(bannerId).done(refreshNav);
    }

    function refreshNav() {
        viewModel.nav(viewModel.navs.IMAGES);
    }

    // module revelation
    viewModel.fileBroker = fileBroker;
    viewModel.bannerBroker = bannerBroker;

    // behaviour revelation
    viewModel.activate = activate;

    return viewModel;
});