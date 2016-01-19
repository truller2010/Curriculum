/* global define: false */
define(function validationUtils() {
    // TODO qunit validationUtils

    "use strict";

    var utils = {};

    function isValidColor(value) {
        return /^#?([0-9a-fA-F]{3}|[0-9a-fA-F]{6})$/i.test(value);
    }

    /* function isDistinct(newValue, originalValue)
     {
         if (originalValue !== undefined && originalValue !== newValue)
             return true;
         else
             return false;
     }*/

    utils.MAX_LENGTH = 255;
    utils.MAX_LENGTH_DESCRIPTION = 1024;
    utils.MAX_LENGTH_REDEMPTION_BIDI = 1024;
    utils.MAX_LENGTH_REDEMPTION_CODE = 255;
    utils.MIN_LENGTH_TELEPHONE = 9;
    utils.MAX_LENGTH_TELEPHONE = 25;
    utils.LENGTH_ZIPCODE = 5;
    utils.MAX_LENGTH_URL = 1024;

    utils.MIN_PRICE = 1;
    utils.MAX_PRICE = 999999999;
    utils.MIN_DISCOUNT = 1;
    utils.MAX_DISCOUNT = 100;
    utils.MIN_LATITUDE = -90;
    utils.MAX_LATITUDE = 90;
    utils.MIN_LONGITUDE = -180;
    utils.MAX_LONGITUDE = 180;
    utils.MAX_FILE_SIZE = /* 100KB */100000;
    utils.ACCEPT_FILE_TYPE = /(\.|\/)(gif|jpe?g|png)$/i;
    utils.MONEY_STEP = 0.01;
    utils.GEOPOSITIONAL_STEP = 0.000001;

    utils.isValidColor = isValidColor;
    // utils.isDistinct = isDistinct;

    return utils;
});