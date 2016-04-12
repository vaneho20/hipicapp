/* global define: false */
define([
    "core/crud/sortBase", "core/crud/orderImpl", "core/crud/numberOrderImpl",
    "core/crud/stringOrderImpl", "domain/user/userImpl"
], function userSortImpl(sortBase, orderImpl, numberOrderImpl, stringOrderImpl, userImpl) {
    "use strict";

    return function userSortImpl() {
        var sort =
            sortBase([
                stringOrderImpl(userImpl.properties.USER_NAME)
            ]);

        return sort;
    };
});