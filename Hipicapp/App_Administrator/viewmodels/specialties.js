/* global _: false, define: false, ko: false */
/* jshint maxparams: 15, maxstatements: 40 */
define([
    "core/config", "core/i18n", "core/crud/findRequestImpl", "core/crud/pageImpl",
    "core/crud/pagerImpl", "core/crud/pageRequestImpl", "core/util/validationUtils",
    "domain/specialty/specialtyBroker", "domain/specialty/specialtyFilterImpl",
    "domain/specialty/specialtySortImpl", "domain/specialty/specialtyImpl", "durandal/app",
    "viewmodels/alerts", "viewmodels/shell"
], function specialties(config, i18n, findRequestImpl, pageImpl, pagerImpl, pageRequestImpl,
                        validationUtils, specialtyBroker, specialtyFilterImpl,
                        specialtySortImpl, specialtyImpl, app, alerts, shell) {
    "use strict";

    // state definition
    var viewModel = {}, PAGE_SIZE = config.PAGE_SIZE, PAGE_SIZES = config.PAGE_SIZES, nextFilter =
        ko.observable(specialtyFilterImpl()), currentFilter = specialtyFilterImpl(), currentSort =
        ko.observable(specialtySortImpl()), currentPage = ko.observable(pageImpl()), currentPager =
        ko.observable(pagerImpl()), currentPageSize = ko.observable(PAGE_SIZE);

    // lifecycle definition
    function activate() {
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
            return specialtyBroker.findBy(
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
        nextFilter(specialtyFilterImpl());

        return search();
    }

    function sortByProperty(property) {
        currentSort().setFirstOrderByProperty(property);
        currentSort().getOrderByIndex(0).cycleOrder();

        return loadCurrentPage();
    }

    function deleteRow(specialty) {
        app.showMessage(i18n.t('DELETE_MESSAGE_BOX_CONTENT'), i18n.t('DELETE_MESSAGE_BOX_TITLE'), [
            i18n.t('YES'), i18n.t('NO')
        ]).done(function hideMessage(answer) {
            if (answer === i18n.t('YES')) {
                specialtyBroker.erase(specialty).done(loadCurrentPage);
            }
        });
    }

    // module revelation
    viewModel.shell = shell;
    viewModel.i18n = i18n;
    viewModel.validationUtils = validationUtils;
    viewModel.specialtyBroker = specialtyBroker;

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
    viewModel.sortByName = _.partial(sortByProperty, specialtyImpl.properties.NAME);
    viewModel.getOrderIconTitleForName = ko.computed(function getOrderIconTitleForName() {
        return currentSort().getOrderByProperty(specialtyImpl.properties.NAME).getIconTitle();
    });
    viewModel.getOrderIconClassForName = ko.computed(function getOrderIconClassForName() {
        return currentSort().getOrderByProperty(specialtyImpl.properties.NAME).getIconClass();
    });

    return viewModel;
});