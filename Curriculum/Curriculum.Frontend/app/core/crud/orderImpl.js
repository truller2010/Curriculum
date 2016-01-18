/* global define: false, ko: false */
define(function orderImpl() {

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
            }
            else {
                iconTitle = "ORDER_ASC_TITLE";
            }

            return iconTitle;
        }

        function getIconClass() {

            var iconClass = "fa fa-sort";

            if (direction() !== NONE) {
               
                if (direction() === ASC) {
                	iconClass = iconClass + "-up";
                	
                } else if (direction() === DESC) {
                	iconClass = iconClass + "-down";
                }
            }

            return iconClass;
        }

        order.property = property;
        order.direction = direction;
        order.cycleOrder = cycleOrder;

        order.getIconTitle = getIconTitle;
        order.getIconClass = getIconClass;
        order.getIconClassSuffixByType = getIconClassSuffixByType;

        return order;
    };
});