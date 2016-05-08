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

    function navigateToAthlete(id) {
        return router.navigate("#athlete/" + id);
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
    router.navigateToLogin = navigateToLogin;
    router.navigateToRegister = navigateToRegister;
    router.navigateToDressage = navigateToDressage;
    router.navigateToJump = navigateToJump;
    router.navigateToAthletes = navigateToAthletes;
    router.navigateToHorses = navigateToHorses;
    router.navigateToCompetitions = navigateToCompetitions;
    router.navigateToJudges = navigateToJudges;

    return router;
});