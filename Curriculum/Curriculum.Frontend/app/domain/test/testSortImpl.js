/* global define: false */
define(
    ["core/crud/sortBase", "core/crud/orderImpl", "core/crud/numberOrderImpl",
        "core/crud/stringOrderImpl", "domain/test/testImpl"],
    function testSortImplModule(sortBase, orderImpl, numberOrderImpl, stringOrderImpl, testImpl) {
        "use strict";

        return function testSortImpl() {
            var sort =
                sortBase([stringOrderImpl(testImpl.properties.ACTIVO, 'DESC'),
                            stringOrderImpl(testImpl.properties.NOMBRE),
                            numberOrderImpl(testImpl.properties.IMPORTE),
                            numberOrderImpl(testImpl.properties.ID)]);

            return sort;
        };
    });