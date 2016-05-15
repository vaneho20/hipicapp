/* global _: false, define: false, ko: false */
/* jshint maxparams: 15, maxstatements: 40 */
define([
    "core/config", "core/i18n", "core/router", "core/crud/findRequestImpl", "core/crud/pageImpl",
    "core/crud/pagerImpl", "core/crud/pageRequestImpl", "core/util/validationUtils", "domain/athlete/athleteBroker",
    "domain/competition/competitionBroker", "domain/file/fileBroker", "domain/horse/horseBroker",
    "domain/judge/judgeBroker", "domain/judge/judgeFilterImpl", "domain/judge/judgeSortImpl",
    "domain/judge/judgeImpl", "domain/specialty/specialtyBroker", "durandal/app", "viewmodels/alerts",
    "viewmodels/shell"
], function judges(config, i18n, router, findRequestImpl, pageImpl, pagerImpl, pageRequestImpl,
    validationUtils, athleteBroker, competitionBroker, fileBroker, horseBroker, judgeBroker,
    judgeFilterImpl, judgeSortImpl, judgeImpl, specialtyBroker, app, alerts, shell) {
    "use strict";

    // state definition
    var viewModel = {}, PAGE_SIZE = config.PAGE_SIZE, PAGE_SIZES = config.PAGE_SIZES, nextFilter =
        ko.observable(judgeFilterImpl()), currentFilter = judgeFilterImpl(), currentSort =
        ko.observable(judgeSortImpl()), currentPage = ko.observable(pageImpl()), currentPager =
        ko.observable(pagerImpl()), currentPageSize = ko.observable(PAGE_SIZE), availableGenders = {
            "male": i18n.t("app:GENDER_MALE"), "female": i18n.t("app:GENDER_FEMALE")
        };

    // lifecycle definition
    function activate(specialtyId) {
        currentFilter.specialtyId(specialtyId);
        nextFilter().specialtyId(specialtyId);

        // allways return a promise
        return loadCurrentPage();
    }

    // behaviour definition
    function refreshCurrentPage(data) {
        currentPage(pageImpl(data));
        currentPager(pagerImpl(data));
    }

    function loadPageByIndex(index, totalElements) {
        if (index === 0 || index > 0 && index < currentPage().totalPages) {
            return judgeBroker.findBy(
                findRequestImpl(currentFilter, pageRequestImpl(index, currentPageSize, currentSort,
                    totalElements))).done(refreshCurrentPage);
        }
    }

    function loadFirstPage() {
        return loadPageByIndex(0);
    }

    function loadCurrentPage() {
        return loadPageByIndex(currentPage().number, currentPage().totalPages);
    }

    function loadLastPage() {
        return loadPageByIndex(currentPage().totalPages - 1);
    }

    function search() {
        // deep copy next filter
        currentFilter = $.extend(true, {}, nextFilter());

        return loadFirstPage();
    }

    function clearFilter() {
        nextFilter(judgeFilterImpl());

        return search();
    }

    function sortByProperty(property) {
        currentSort().setFirstOrderByProperty(property);
        currentSort().getOrderByIndex(0).cycleOrder();

        return loadCurrentPage();
    }

    function getRowClass(row) {
        var rowClass = "";

        /*if (!row.enabled) {
            rowClass = "error";
        } else if (row.userType === userImpl.userType.CLIENT) {
            rowClass = "warning";
        } else if (row.userType === userImpl.userType.CONSUMER) {
            rowClass = "success";
        } else if (row.userType === userImpl.userType.USER) {
            rowClass = "info";
        }*/

        return rowClass;
    }

    // module revelation
    viewModel.shell = shell;
    viewModel.i18n = i18n;
    viewModel.router = router;
    viewModel.validationUtils = validationUtils;
    viewModel.athleteBroker = athleteBroker;
    viewModel.competitionBroker = competitionBroker;
    viewModel.fileBroker = fileBroker;
    viewModel.horseBroker = horseBroker;
    viewModel.judgeBroker = judgeBroker;
    viewModel.specialtyBroker = specialtyBroker;

    // state revelation
    viewModel.nextFilter = nextFilter;
    viewModel.currentSort = currentSort;
    viewModel.currentPage = currentPage;
    viewModel.currentPager = currentPager;
    viewModel.currentPageSize = currentPageSize;
    viewModel.availablePageSizes = PAGE_SIZES;
    viewModel.availableGenders = availableGenders;

    // lifecycle revelation
    viewModel.activate = activate;

    // behaviour revelation
    viewModel.refreshCurrentPage = refreshCurrentPage;
    viewModel.loadPageByIndex = loadPageByIndex;
    viewModel.loadFirstPage = loadFirstPage;
    viewModel.loadCurrentPage = loadCurrentPage;
    viewModel.loadLastPage = loadLastPage;
    viewModel.search = search;
    viewModel.clearFilter = clearFilter;
    viewModel.getRowClass = getRowClass;

    // bind helpers
    viewModel.sortByName = _.partial(sortByProperty, judgeImpl.properties.NAME);
    viewModel.getOrderIconTitleForName = ko.computed(function getOrderIconTitleForName() {
        return currentSort().getOrderByProperty(judgeImpl.properties.NAME).getIconTitle();
    });
    viewModel.getOrderIconClassForName = ko.computed(function getOrderIconClassForName() {
        return currentSort().getOrderByProperty(judgeImpl.properties.NAME).getIconClass();
    });

    viewModel.sortBySurnames = _.partial(sortByProperty, judgeImpl.properties.SURNAMES);
    viewModel.getOrderIconTitleForSurnames = ko.computed(function getOrderIconTitleForSurnames() {
        return currentSort().getOrderByProperty(judgeImpl.properties.SURNAMES).getIconTitle();
    });
    viewModel.getOrderIconClassForSurnames = ko.computed(function getOrderIconClassForSurnames() {
        return currentSort().getOrderByProperty(judgeImpl.properties.SURNAMES).getIconClass();
    });

    return viewModel;
});