/* global define: false*/
define(function competitionFilterImpl() {
    "use strict";

    return function competitionFilterImpl(athleteId) {
        var filter = {};

        filter.athleteId = ko.observable(athleteId);
        filter.specialtyId = ko.observable(null);

        return filter;
    };
});