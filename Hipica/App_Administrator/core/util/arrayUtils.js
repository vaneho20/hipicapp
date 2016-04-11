/* global define: false */
define(function arrayUtils() {
    // TODO qunit arrayUtils

    "use strict";

    var utils = {};

    function valueOfArguments(args) {
        return Array.prototype.slice.apply(args);
    }

    utils.valueOfArguments = valueOfArguments;

    return utils;
});