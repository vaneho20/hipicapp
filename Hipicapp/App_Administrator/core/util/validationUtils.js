/* global define: false */
define(function validationUtils() {
    // TODO qunit validationUtils

    "use strict";

    var utils = {}, COMPARATOR = {
        EQ: "EQ",
        GE: "GE",
        GT: "GT",
        LT: "LT",
        LE: "LE",
        NE: "NE"
    }, MAX_LENGTH = 255, FLOAT_STEP = 0.01, MAX_FILE_SIZE = /* 100KB */100000,
        ACCEPT_FILE_TYPES = /(\.|\/)(gif|jpe?g|png)$/i;

    function valueOfArguments(args) {
        return Array.prototype.slice.apply(args);
    }

    function isEqual(value, otherValue, comparator) {
        var isValid = !value || !otherValue;
        switch (comparator) {
            case COMPARATOR.EQ:
                isValid = isValid || value === otherValue;
                break;
            case COMPARATOR.GE:
                isValid = isValid || value >= otherValue;
                break;
            case COMPARATOR.GT:
                isValid = isValid || value > otherValue;
                break;
            case COMPARATOR.LT:
                isValid = isValid || value < otherValue;
                break;
            case COMPARATOR.LE:
                isValid = isValid || value <= otherValue;
                break;
            case COMPARATOR.NE:
                isValid = isValid || value !== otherValue;
                break;
            default:
                isValid = isValid || true;
                break;
        }
        return isValid;
    }

    utils.MAX_LENGTH = MAX_LENGTH;
    utils.MIN_PASSWORD_LENGTH = 6;
    utils.PASSWORD_PATTERN = ".{6,}";
    utils.FLOAT_STEP = FLOAT_STEP;
    utils.MAX_FILE_SIZE = MAX_FILE_SIZE;
    utils.ACCEPT_FILE_TYPES = ACCEPT_FILE_TYPES;

    utils.COMPARATOR = COMPARATOR;

    utils.valueOfArguments = valueOfArguments;
    utils.isEqual = isEqual;

    return utils;
});