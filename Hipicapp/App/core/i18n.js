/* global define: false */
define(["i18next"], function i18nDecorator(i18n) {
    // TODO qunit i18nDecorator

    "use strict";

    var REGULAR_EXPRESSIONS = [/\{0\}/gm, /\{1\}/gm, /\{2\}/gm], HTML_5_DATE_PATTERN =
        "YYYY-MM-DD", HTML_5_DATETIME_PATTERN = "YYYY-MM-DD hh:mm";

    function format() {
        var pattern = arguments[0], i, imax = arguments.length - 1;

        if (arguments.length > 4) {
            throw new Error("up to 3 arguments supported");
        }

        for (i = 0; i < imax; i = i + 1) {
            pattern = pattern.replace(REGULAR_EXPRESSIONS[i], arguments[i + 1]);
        }

        return pattern;
    }

    function unescape(text) {
        return $("<div/>").html(text).text();
    }

    i18n.HTML_5_DATE_PATTERN = HTML_5_DATE_PATTERN;
    i18n.HTML_5_DATETIME_PATTERN = HTML_5_DATETIME_PATTERN;

    i18n.format = format;
    i18n.unescape = unescape;

    return i18n;
});