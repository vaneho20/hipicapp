/* global define: false */
define(function sortBase() {
    // TODO sortBase qunit

    "use strict";

    return function sortBase(orders) {
        var sort = {};

        function getOrderByIndex(index) {
            return orders[index];
        }

        function getOrderByProperty(property) {
            var i = 0, imax = orders.length;

            for (i = 0; i < imax; i = i + 1) {
                if (orders[i].property === property) {
                    return orders[i];
                }
            }
        }

        function setFirstOrderByProperty(property) {
            var i = 0;

            while (orders[i].property !== property) {
                i = i + 1;
            }

            orders.splice(0, 0, orders.splice(i, 1)[0]);
        }

        sort.orders = orders;
        sort.getOrderByIndex = getOrderByIndex;
        sort.getOrderByProperty = getOrderByProperty;
        sort.setFirstOrderByProperty = setFirstOrderByProperty;

        return sort;
    };
});