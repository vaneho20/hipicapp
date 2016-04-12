/* global define: false */
define(
    ["core/crud/sortBase", "core/crud/orderImpl", "core/crud/numberOrderImpl",
        "core/crud/stringOrderImpl", "domain/horse/horseImpl"],
    function horseSortImpl(sortBase, orderImpl, numberOrderImpl, stringOrderImpl, horseImpl) {
        "use strict";

        return function horseSortImpl() {
            var sort =
                sortBase([stringOrderImpl(horseImpl.properties.NAME)]);

            return sort;
        };
    });