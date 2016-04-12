/* global define: false*/
define(function horseFilterImpl() {
    "use strict";

    return function horseFilterImpl(athleteId) {
        var filter = {};

        filter.athleteId = ko.observable(athleteId);

        return filter;
    };
});