/* global define: false */
define(
    ["core/crud/sortBase", "core/crud/orderImpl", "core/crud/numberOrderImpl",
        "core/crud/stringOrderImpl", "domain/competition/competitionImpl"],
    function competitionSortImpl(sortBase, orderImpl, numberOrderImpl, stringOrderImpl, competitionImpl) {
        "use strict";

        return function competitionSortImpl() {
            var sort =
                sortBase([stringOrderImpl(competitionImpl.properties.NAME)]);

            return sort;
        };
    });