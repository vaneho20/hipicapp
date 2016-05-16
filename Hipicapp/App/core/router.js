/* global define: false, location: false */
define([
    "plugins/router"
], function routerDecorator(router) {
    // TODO qunit routerDecorator

    "use strict";

    function reloadCurrentLocation() {
        return location.reload();
    }

    function navigateToHome() {
        return router.navigate("#home");
    }

    function navigateToLogin() {
        return router.navigate("#login");
    }

    function navigateToPasswordReset() {
        return router.navigate("#reset-password");
    }

    function navigateToRegister() {
        return router.navigate("#register");
    }

    function navigateToAthlete(id) {
        return router.navigate("#athlete" + (id ? "/" + id : ""));
    }

    function navigateToAthletes() {
        return router.navigate("#athletes");
    }

    function navigateToHorses() {
        return router.navigate("#horses");
    }

    function navigateToCompetitions() {
        return router.navigate("#competitions");
    }

    function navigateToJudges() {
        return router.navigate("#judges");
    }

    router.reloadCurrentLocation = reloadCurrentLocation;

    // Private site
    router.navigateToAthlete = navigateToAthlete;

    // Public site
    router.navigateToHome = navigateToHome;
    router.navigateToLogin = navigateToLogin;
    router.navigateToPasswordReset = navigateToPasswordReset;
    router.navigateToRegister = navigateToRegister;
    router.navigateToAthletes = navigateToAthletes;
    router.navigateToHorses = navigateToHorses;
    router.navigateToCompetitions = navigateToCompetitions;
    router.navigateToJudges = navigateToJudges;

    return router;
});