/* global define: false*/
define(function judgeFilterImpl() {
    "use strict";

    return function judgeFilterImpl() {
        var filter = {};

        filter.competitionId = ko.observable();
        filter.specialtyId = ko.observable();

        return filter;
    };
});