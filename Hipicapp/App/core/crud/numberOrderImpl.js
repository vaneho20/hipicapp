/* global define: false */
define(["core/crud/orderImpl"], function numberOrderImpl(orderImpl) {
    // TODO numberOrderImpl qunit

    "use strict";

    return function numberOrderImpl(property, direction) {
        var numberOrder = orderImpl(property, direction);

        function getIconClassSuffixByType() {
            return "-by-order";
        }

        numberOrder.getIconClassSuffixByType = getIconClassSuffixByType;

        return numberOrder;
    };
});