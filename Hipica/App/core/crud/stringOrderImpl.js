/* global define: false */
define(["core/crud/orderImpl"], function stringOrderImpl(orderImpl) {
    // TODO qunit stringOrderImpl

    "use strict";

    return function stringOrderImpl(property, direction) {
        var stringOrder = orderImpl(property, direction);

        function getIconClassSuffixByType() {
            return "-by-alphabet";
        }

        stringOrder.getIconClassSuffixByType = getIconClassSuffixByType;

        return stringOrder;
    };
});