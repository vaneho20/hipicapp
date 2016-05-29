/* global _: false, define: false, ko: false */
/* jshint maxparams: 15, maxstatements: 40 */
define([
    "core/config", "core/i18n", "core/crud/findRequestImpl", "core/crud/pageImpl",
    "core/crud/pagerImpl", "core/crud/pageRequestImpl", "core/util/validationUtils",
    "domain/competition/competitionBroker", "domain/enrollment/enrollmentFilterImpl",
    "domain/enrollment/enrollmentSortImpl", "domain/enrollment/enrollmentImpl",
    "domain/file/fileBroker", "durandal/app", "viewmodels/alerts", "viewmodels/shell"
], function competitions(config, i18n, findRequestImpl, pageImpl, pagerImpl, pageRequestImpl,
    validationUtils, competitionBroker, enrollmentFilterImpl, enrollmentSortImpl, enrollmentImpl,
    fileBroker, app, alerts, shell) {
    "use strict";

    // state definition
    var viewModel = {}, PAGE_SIZE = config.PAGE_SIZE, PAGE_SIZES = config.PAGE_SIZES,
        nextFilter = ko.observable(enrollmentFilterImpl()), currentFilter = enrollmentFilterImpl(),
        currentSort = ko.observable(enrollmentSortImpl()), currentPage = ko.observable(pageImpl()),
        currentPager = ko.observable(pagerImpl()), currentPageSize = ko.observable(PAGE_SIZE);

    // lifecycle definition
    function activate(competitionId) {
        currentFilter.competitionId(competitionId);
        nextFilter().competitionId(competitionId);

        // allways return a promise
        return $.when(loadCurrentPage());
    }

    // behaviour definition
    function refreshCurrentPage(data) {
        currentPage(pageImpl(data));
        currentPager(pagerImpl(data));
    }

    function loadPageByIndex(index, totalElements) {
        if (index === 0 || index > 0 && index < currentPage().totalPages) {
            return competitionBroker.findInscriptionsBy(
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
        nextFilter(competitionFilterImpl());

        return search();
    }

    function sortByProperty(property) {
        currentSort().setFirstOrderByProperty(property);
        currentSort().getOrderByIndex(0).cycleOrder();

        return loadCurrentPage();
    }

    function deleteRow(competition) {
        app.showMessage(i18n.t('DELETE_MESSAGE_BOX_CONTENT'), i18n.t('DELETE_MESSAGE_BOX_TITLE'), [
            i18n.t('YES'), i18n.t('NO')
        ]).done(function hideMessage(answer) {
            if (answer === i18n.t('YES')) {
                competitionBroker.erase(competition).done(loadCurrentPage);
            }
        });
    }

    // module revelation
    viewModel.shell = shell;
    viewModel.i18n = i18n;
    viewModel.validationUtils = validationUtils;
    viewModel.competitionBroker = competitionBroker;
    viewModel.fileBroker = fileBroker;

    // state revelation
    viewModel.nextFilter = nextFilter;
    viewModel.currentSort = currentSort;
    viewModel.currentPage = currentPage;
    viewModel.currentPager = currentPager;
    viewModel.currentPageSize = currentPageSize;
    viewModel.availablePageSizes = PAGE_SIZES;

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
    viewModel.deleteRow = deleteRow;

    // bind helpers
    /*viewModel.sortByName = _.partial(sortByProperty, "competition." + competitionImpl.properties.NAME);
    viewModel.getOrderIconTitleForName = ko.computed(function getOrderIconTitleForName() {
        return currentSort().getOrderByProperty("competition." + competitionImpl.properties.NAME).getIconTitle();
    });
    viewModel.getOrderIconClassForName = ko.computed(function getOrderIconClassForName() {
        return currentSort().getOrderByProperty("competition." + competitionImpl.properties.NAME).getIconClass();
    });*/

    return viewModel;
});