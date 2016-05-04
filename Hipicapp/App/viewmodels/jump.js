/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils"
], function jumpViewModel(i18n, router, securityContext, stringUtils, urlUtils, validationUtils) {
    "use strict";

    // state definition
    var viewModel = {};

    // lifecycle definition
    function activate() {
        return true;
    }

    // module revelation
    viewModel.i18n = i18n;
    viewModel.router = router;
    viewModel.securityContext = securityContext;
    viewModel.validationUtils = validationUtils;

    // state revelation

    // lifecycle revelation
    viewModel.activate = activate;

    // behaviour revelation

    return viewModel;
});