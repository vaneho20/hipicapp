/* global define: false*/
define(function horseFilterImpl() {
    "use strict";

    return function horseFilterImpl(athleteId) {
        var filter = {};

        filter.name = ko.observable(null);
        filter.gender = ko.observable(null);
        filter.athleteId = ko.observable(athleteId);
        filter.specialtyId = ko.observable(null);
        filter.competitionId = ko.observable(null);

        return filter;
    };
});