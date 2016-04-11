/* global define: false */
define(
    ["core/crud/sortBase", "core/crud/orderImpl", "core/crud/numberOrderImpl",
        "core/crud/stringOrderImpl", "domain/judge/judgeImpl"],
    function judgeSortImpl(sortBase, orderImpl, numberOrderImpl, stringOrderImpl, judgeImpl) {
        "use strict";

        return function judgeSortImpl() {
            var sort =
                sortBase([stringOrderImpl(judgeImpl.properties.NAME), stringOrderImpl(judgeImpl.properties.SURNAMES)]);

            return sort;
        };
    });