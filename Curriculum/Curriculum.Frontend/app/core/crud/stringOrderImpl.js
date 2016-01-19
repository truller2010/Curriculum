/* global define: false */
define(["core/crud/orderImpl"], function stringOrderImpl(orderImpl) {

    "use strict";

    return function stringOrderImpl(property, direction) {

        var stringOrder = orderImpl(property, direction);

        function getIconClassSuffixByType() {
            return "-alpha";
        }


        stringOrder.getIconClassSuffixByType = getIconClassSuffixByType;

        return stringOrder;
    };
});