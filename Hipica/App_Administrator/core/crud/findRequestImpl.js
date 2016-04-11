/* global define: false */
define(function findRequestImpl() {
    // TODO findRequestImpl qunit

    "use strict";

    return function findRequestImpl(filter, pageRequest) {
        var findRequest = {};

        findRequest.filter = filter;
        findRequest.pageRequest = pageRequest;

        return findRequest;
    };
});