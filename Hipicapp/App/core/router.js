/* global define: false, location: false */
define([
    "plugins/router"
], function routerDecorator(router) {
    // TODO qunit routerDecorator

    "use strict";

    function reloadCurrentLocation() {
        return location.reload();
    }

    function navigateToLogin() {
        return router.navigate("#login");
    }

    function navigateToRegister() {
        return router.navigate("#register");
    }


    router.reloadCurrentLocation = reloadCurrentLocation;

    router.navigateToLogin = navigateToLogin;
    router.navigateToRegister = navigateToRegister;

    return router;
});