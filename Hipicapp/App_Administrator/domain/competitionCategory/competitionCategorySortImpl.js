/* global define: false */
define(
    ["core/crud/sortBase", "core/crud/orderImpl", "core/crud/numberOrderImpl",
        "core/crud/stringOrderImpl", "domain/competitionCategory/competitionCategoryImpl"],
    function competitionCategorySortImpl(sortBase, orderImpl, numberOrderImpl, stringOrderImpl, competitionCategoryImpl) {
        "use strict";

        return function competitionCategorySortImpl() {
            var sort =
                sortBase([stringOrderImpl(competitionCategoryImpl.properties.NAME)]);

            return sort;
        };
    });