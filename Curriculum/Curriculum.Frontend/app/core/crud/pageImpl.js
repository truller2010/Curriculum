/* global define:false */
define(function pageImpl() {
    // TODO pageImpl qunit

    "use strict";

    return function pageImpl(currentPage) {
        var page = {},
            content = [],
            size = 0,
            number = 0,
            numberOfElements = 0,
            totalPages = 0,
            sort = null,
            totalElements =
                0,
            firstPage = true,
            lastPage = true,
            pageSize = 0;

        if (currentPage) {
            content = currentPage.content;
            size = currentPage.size;
            pageSize = currentPage.pageSize;
            number = currentPage.number;
            numberOfElements = currentPage.numberOfElements;
            totalPages = currentPage.totalPages;
            sort = currentPage.sort;
            totalElements = currentPage.totalElements;
            firstPage = currentPage.firstPage;
            lastPage = currentPage.lastPage;
        }

        function isEmpty() {
            return totalPages < 1;
        }

        function getFirstRowIndex() {
            return pageSize * number + 1;
        }

        function getLastRowIndex() {
            return pageSize * number + numberOfElements;
        }

        page.content = content;
        page.size = size;
        page.pageSize = pageSize;
        page.number = number;
        page.numberOfElements = numberOfElements;
        page.totalPages = totalPages;
        page.sort = sort;
        page.totalElements = totalElements;
        page.firstPage = firstPage;
        page.lastPage = lastPage;

        page.isEmpty = isEmpty;
        page.getFirstRowIndex = getFirstRowIndex;
        page.getLastRowIndex = getLastRowIndex;

        return page;
    };
});