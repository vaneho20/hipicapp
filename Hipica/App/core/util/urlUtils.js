/* global define: false*/
define(['core/util/arrayUtils', 'core/util/stringUtils'], function urlUtils(arrayUtils,
    stringUtils) {
    // TODO qunit urlUtils

    "use strict";

    var utils = {};

    function joinPath() {
        return "/" + arrayUtils.valueOfArguments(arguments).join("/");
    }

    function toUrlTitle() {
        var separator = "-", title = arrayUtils.valueOfArguments(arguments).join(separator);

        return stringUtils.normalize(title).toLowerCase().replace(/[^a-zA-Z0-9]+/g, " ").trim()
            .replace(/\s+/g, separator);
    }

    utils.joinPath = joinPath;
    utils.toUrlTitle = toUrlTitle;

    return utils;
});