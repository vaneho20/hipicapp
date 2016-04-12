/* global define: false, ko: false */
define(function userFilterImpl() {
    "use strict";

    return function userFilterImpl(enabled, userName) {
        var filter = {};

        filter.enabled = ko.observable(enabled);
        filter.userName = ko.observable(userName);

        return filter;
    };
});