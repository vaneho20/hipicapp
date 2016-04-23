/* global define: false */
define(
    ["core/crud/sortBase", "core/crud/orderImpl", "core/crud/numberOrderImpl",
        "core/crud/stringOrderImpl", "domain/athlete/athleteImpl"],
    function athleteSortImpl(sortBase, orderImpl, numberOrderImpl, stringOrderImpl, athleteImpl) {
        "use strict";

        return function athleteSortImpl() {
            var sort =
                sortBase([stringOrderImpl(athleteImpl.properties.NAME), stringOrderImpl(athleteImpl.properties.SURNAMES),
                    stringOrderImpl(athleteImpl.properties.DNI)/*, orderImpl(athleteImpl.properties.BIRTH_DATE)*/]);

            return sort;
        };
    });