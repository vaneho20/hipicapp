/* global define: false*/
define(function athleteFilterImpl() {
    "use strict";

    return function athleteFilterImpl() {
        var filter = {};

        filter.name = ko.observable(null);
        filter.gender = ko.observable(null);
        filter.specialtyId = ko.observable(null);

        return filter;
    };
});