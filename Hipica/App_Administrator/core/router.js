/* global define: false, location: false */
define([
    "plugins/router"
], function routerDecorator(router) {
    // TODO qunit routerDecorator

    "use strict";

    function reloadCurrentLocation() {
        return location.reload();
    }

    router.reloadCurrentLocation = reloadCurrentLocation;

    return router;
});