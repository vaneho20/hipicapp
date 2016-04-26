/* global define: false */
define(
    ["core/crud/sortBase", "core/crud/orderImpl", "core/crud/numberOrderImpl",
        "core/crud/stringOrderImpl", "domain/specialty/specialtyImpl"],
    function specialtySortImpl(sortBase, orderImpl, numberOrderImpl, stringOrderImpl, specialtyImpl) {
        "use strict";

        return function specialtySortImpl() {
            var sort =
                sortBase([stringOrderImpl(specialtyImpl.properties.NAME)]);

            return sort;
        };
    });