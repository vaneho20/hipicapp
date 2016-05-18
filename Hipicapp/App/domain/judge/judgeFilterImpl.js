/* global define: false*/
define(function judgeFilterImpl() {
    "use strict";

    return function judgeFilterImpl() {
        var filter = {};

        filter.name = ko.observable(null);
        filter.specialtyId = ko.observable(null);
        filter.competitionId = ko.observable(null);

        return filter;
    };
});