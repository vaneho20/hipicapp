/* global define:false */
define(function pageImpl() {
    // TODO pageImpl qunit

    "use strict";

    return function pageImpl(currentPage, wrapperImpl) {
        var page = {}, content = [], size = 0, number = 0, numberOfElements = 0, totalPages = 0, sort = null, totalElements =
            0, firstPage = true, lastPage = true;

        if (currentPage) {
            if (wrapperImpl) {
                ko.utils.arrayForEach(currentPage.content, function (element) {
                    content.push(wrapperImpl(element));
                });
            }
            else {
                content = currentPage.content;
            }
            size = currentPage.size;
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
            return size * number + 1;
        }

        function getLastRowIndex() {
            return size * number + numberOfElements;
        }

        page.content = content;
        page.size = size;
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