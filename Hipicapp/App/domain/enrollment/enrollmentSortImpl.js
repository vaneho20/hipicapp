/* global define: false */
define([
    "core/crud/sortBase", "core/crud/orderImpl", "core/crud/numberOrderImpl",
    "core/crud/stringOrderImpl", "domain/enrollment/enrollmentImpl"
], function enrollmentSortImpl(sortBase, orderImpl, numberOrderImpl, stringOrderImpl, enrollmentImpl) {
    "use strict";

    return function enrollmentSortImpl() {
        var sort =
            sortBase([stringOrderImpl(enrollmentImpl.properties.COMPETITION + "." + enrollmentImpl.competitionImpl.properties.NAME)]);

        return sort;
    };
});