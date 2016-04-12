/* global _:false, define: false */
define(function pagerImpl() {
    // TODO pagerImpl qunit

    "use strict";

    return function pagerImpl(currentPage) {
        var pager = {}, minPage = 0, maxPage = currentPage ? currentPage.totalPages - 1 : 0, maxPagesParam =
            5, maxPages = maxPagesParam % 2 === 0 ? maxPagesParam + 1 : maxPagesParam, maxPagesBefore =
            (maxPages - 1) / 2, maxPagesAfter = maxPagesBefore, firstPage =
            currentPage ? currentPage.number : 0, lastPage = currentPage ? currentPage.number : 0, pages =
            [], remainingPages = maxPages - 1, i = 0, imax = maxPagesBefore, j = 0, jmax =
            maxPagesAfter;

        function setup() {
            if (maxPages % 2 === 0) {
                maxPages = maxPages + 1;
            }

            if (maxPage >= maxPages) {
                for (i = 0; i < imax && firstPage > minPage; i = i + 1) {
                    firstPage = firstPage - 1;
                    remainingPages = remainingPages - 1;
                }
                for (j = 0; j < jmax && lastPage < maxPage; j = j + 1) {
                    lastPage = lastPage + 1;
                    remainingPages = remainingPages - 1;
                }
            } else {
                firstPage = minPage;
                lastPage = maxPage;
            }

            if (firstPage >= 0 && lastPage + 1 >= firstPage) {
                pages = _.range(firstPage, lastPage + 1);
            }
        }

        function getPages() {
            return pages;
        }

        function getFirstPage() {
            return firstPage;
        }

        function getLastPage() {
            return lastPage;
        }

        function hasPrevPages() {
            return firstPage > minPage;
        }

        function hasNextPages() {
            return lastPage < maxPage;
        }

        setup();

        pager.getPages = getPages;
        pager.getFirstPage = getFirstPage;
        pager.getLastPage = getLastPage;
        pager.hasPrevPages = hasPrevPages;
        pager.hasNextPages = hasNextPages;

        return pager;
    };
});