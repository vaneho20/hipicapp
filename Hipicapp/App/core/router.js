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

    function navigateToDressage() {
        return router.navigate("#dressage");
    }

    function navigateToJump() {
        return router.navigate("#jump");
    }

    router.reloadCurrentLocation = reloadCurrentLocation;

    router.navigateToLogin = navigateToLogin;
    router.navigateToRegister = navigateToRegister;
    router.navigateToDressage = navigateToDressage;
    router.navigateToJump = navigateToJump;

    return router;
});