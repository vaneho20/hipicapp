/* global _: false, define: false, ko: false */
/* jshint maxparams: 15, maxstatements: 100 */
define([
    "core/config", "core/i18n", "core/crud/findRequestImpl", "core/crud/pageImpl", "core/crud/pagerImpl",
    "core/crud/pageRequestImpl", "domain/file/fileBroker", "domain/horse/horseBroker", "domain/horse/horseFilterImpl",
    "domain/horse/horseSortImpl", "domain/horse/horseImpl", "durandal/app", "viewmodels/shell"
], function athleteHorses(config, i18n, findRequestImpl, pageImpl, pagerImpl, pageRequestImpl,
    fileBroker, horseBroker, horseFilterImpl, horseSortImpl, horseImpl, app, shell) {
    "use strict";

    // state definition
    var viewModel = {}, PAGE_SIZE = config.PAGE_SIZE, PAGE_SIZES = config.PAGE_SIZES,
        availableProvinces = ko.observable(), nextFilter = ko.observable(horseFilterImpl()),
        currentFilter = horseFilterImpl(), currentSort = ko.observable(horseSortImpl()),
        currentPage = ko.observable(pageImpl()), currentPager = ko.observable(pagerImpl()),
        currentPageSize = ko.observable(PAGE_SIZE), availableGenders = {
            "male": i18n.t("app:GENDER_MALE"), "female": i18n.t("app:GENDER_FEMALE")
        };

    // lifecycle definition
    function activate(athleteId) {
        currentFilter.athleteId(athleteId);
        nextFilter().athleteId(athleteId);

        return $.when(loadCurrentPage());
    }

    // behaviour definition
    function refreshCurrentPage(data) {
        currentPage(pageImpl(data));
        currentPager(pagerImpl(data));
    }

    function loadPageByIndex(index, totalElements) {
        if (index === 0 || index > 0 && index < currentPage().totalPages) {
            return horseBroker.findBy(
                findRequestImpl(currentFilter, pageRequestImpl(index, currentPageSize,
                    currentSort, totalElements))).done(refreshCurrentPage);
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
        nextFilter(horseFilterImpl(currentFilter.athleteId()));

        return search();
    }

    function sortByProperty(property) {
        currentSort().setFirstOrderByProperty(property);
        currentSort().getOrderByIndex(0).cycleOrder();

        return loadCurrentPage();
    }

    function deleteRow(horse) {
        app.showMessage(i18n.t('DELETE_MESSAGE_BOX_CONTENT'), i18n.t('DELETE_MESSAGE_BOX_TITLE'), [
            i18n.t('YES'), i18n.t('NO')
        ]).done(function hideMessage(answer) {
            if (answer === i18n.t('YES')) {
                horseBroker.erase(horse).done(loadCurrentPage);
            }
        });
    }

    // module revelation
    viewModel.shell = shell;
    viewModel.i18n = i18n;
    viewModel.fileBroker = fileBroker;
    viewModel.horseBroker = horseBroker;

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
    viewModel.deleteRow = deleteRow;

    // bind helpers
    viewModel.sortByName = _.partial(sortByProperty, horseImpl.properties.NAME);

    viewModel.getOrderIconTitleForName =
        ko.computed(function getOrderIconTitleForName() {
            return currentSort().getOrderByProperty(horseImpl.properties.NAME)
                .getIconTitle();
        });

    viewModel.getOrderIconClassForName =
        ko.computed(function getOrderIconClassForName() {
            return currentSort().getOrderByProperty(horseImpl.properties.NAME)
                .getIconClass();
        });

    return viewModel;
});