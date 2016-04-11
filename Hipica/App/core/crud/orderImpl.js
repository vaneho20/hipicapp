/* global define: false, ko: false */
define(function orderImpl() {
    // TODO orderImpl qunit

    "use strict";

    var NONE = null, ASC = "ASC", DESC = "DESC";

    return function orderImpl(property, sortDirection) {
        var order = {}, direction = ko.observable(sortDirection);

        function cycleOrder() {
            if (!direction()) {
                direction(ASC);
            } else if (direction() === ASC) {
                direction(DESC);
            } else if (direction() === DESC) {
                direction(undefined);
            }
        }

        function getIconClassSuffixByType() {
            return "-by-attributes";
        }

        function getIconTitle() {
            var iconTitle;

            if (direction() === ASC) {
                iconTitle = "ORDER_DESC_TITLE";
            } else if (direction() === DESC) {
                iconTitle = "ORDER_NONE_TITLE";
            } else {
                iconTitle = "ORDER_ASC_TITLE";
            }

            return iconTitle;
        }

        function getIconClass() {
            var iconClass = "fa fa-sort", typeSuffix = "";

            if (direction() !== NONE) {
                typeSuffix = order.getIconClassSuffixByType ? order.getIconClassSuffixByType() : "";
                if (direction() === ASC) {
                    iconClass = iconClass + typeSuffix;
                } else if (direction() === DESC) {
                    iconClass = iconClass + typeSuffix + "-alt";
                }
            }

            return iconClass;
        }

        order.property = property;
        order.direction = direction;
        order.cycleOrder = cycleOrder;

        order.getIconTitle = ko.computed(getIconTitle);
        order.getIconClass = ko.computed(getIconClass);
        order.getIconClassSuffixByType = getIconClassSuffixByType;

        return order;
    };
});