/* global define: false*/
define(function competitionFilterImpl() {
    "use strict";

    return function competitionFilterImpl() {
        var filter = {};

        filter.athleteId = ko.observable(athleteId);

        return filter;
    };
});