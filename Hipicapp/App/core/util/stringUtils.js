/* global define: false, UNorm: false */
define(function stringUtils() {
    // TODO qunit stringUtils

    "use strict";

    var utils = {};

    function areNormalizedEqual(string1, string2) {
        return normalize(string1).toLowerCase() === normalize(string2).toLowerCase();
    }

    function normalize(string) {
        return UNorm.nfd(string).replace(/[\u0300-\u036F]/g, "");
    }

    utils.areNormalizedEqual = areNormalizedEqual;
    utils.normalize = normalize;

    return utils;
});