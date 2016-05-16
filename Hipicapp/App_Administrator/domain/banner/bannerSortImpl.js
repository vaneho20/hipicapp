/* global define: false */
define(
    ["core/crud/sortBase", "core/crud/orderImpl", "core/crud/numberOrderImpl",
        "core/crud/stringOrderImpl", "domain/banner/bannerImpl"],
    function bannerSortImpl(sortBase, orderImpl, numberOrderImpl, stringOrderImpl, bannerImpl) {
        "use strict";

        return function bannerSortImpl() {
            var sort =
                sortBase([stringOrderImpl(bannerImpl.properties.TITLE)]);

            return sort;
        };
    });