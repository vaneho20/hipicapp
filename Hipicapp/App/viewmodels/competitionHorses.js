/* global _: false, define: false, ko: false */
/* jshint maxparams: 15, maxstatements: 100 */
define([
    "core/config", "core/i18n", "core/router", "core/crud/findRequestImpl", "core/crud/pageImpl", "core/crud/pagerImpl",
    "core/crud/pageRequestImpl", "domain/athlete/athleteBroker", "domain/file/fileBroker", "domain/horse/horseBroker",
    "domain/horse/horseFilterImpl", "domain/horse/horseSortImpl", "domain/horse/horseImpl", "durandal/app",
    "viewmodels/competition", "viewmodels/shell"
], function athleteHorses(config, i18n, router, findRequestImpl, pageImpl, pagerImpl, pageRequestImpl, athleteBroker,
    fileBroker, horseBroker, horseFilterImpl, horseSortImpl, horseImpl, app, competitionViewModel, shell) {
    "use strict";

    // state definition
    var viewModel = $.extend(false, {}, competitionViewModel), superActivate = viewModel.activate,
        PAGE_SIZE = config.PAGE_SIZE, PAGE_SIZES = config.PAGE_SIZES, nextFilter = ko.observable(horseFilterImpl()),
        currentFilter = horseFilterImpl(), currentSort = ko.observable(horseSortImpl()),
        currentPage = ko.observable(pageImpl()), currentPager = ko.observable(pagerImpl()),
        currentPageSize = ko.observable(PAGE_SIZE), currentEntity = viewModel.currentEntity, availableGenders = {
            "male": i18n.t("app:GENDER_MALE"), "female": i18n.t("app:GENDER_FEMALE")
        }, isEnrolled = ko.observable(false);

    // lifecycle definition
    function activate(competitionId) {
        currentFilter.competitionId(competitionId);
        nextFilter().competitionId(competitionId);

        return $.when(hasEnrolled(competitionId), superActivate(competitionId).done(function onSuccess() {
            return loadCurrentPage();
        }));
    }

    // behaviour definition
    function refreshCurrentPage(data) {
        currentPage(pageImpl(data));
        currentPager(pagerImpl(data));
    }

    function loadPageByIndex(index, totalElements) {
        if (index === 0 || index > 0 && index < currentPage().totalPages) {
            return horseBroker.findByCurrentUser(
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

    function hasEnrolled(competitionId) {
        return athleteBroker.hasEnrolled(competitionId).done(function success(data) {
            isEnrolled(data);
        });
    }

    function enroll(horse) {
        return athleteBroker.inscription(nextFilter().competitionId(), horse.id).done(function success() {
            router.navigateToAthlete();
        });
    }

    function getRowClass(row) {
        var rowClass = "";

        if (row.assign) {
            rowClass = "danger";
        }

        return rowClass;
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
    viewModel.currentEntity = currentEntity;
    viewModel.availablePageSizes = PAGE_SIZES;
    viewModel.availableGenders = availableGenders;
    viewModel.isEnrolled = isEnrolled;

    // lifecycle revelation
    viewModel.activate = activate;

    // behaviour revelation
    viewModel.refreshCurrentPage = refreshCurrentPage;
    viewModel.loadPageByIndex = loadPageByIndex;
    viewModel.loadFirstPage = loadFirstPage;
    viewModel.loadCurrentPage = loadCurrentPage;
    viewModel.loadLastPage = loadLastPage;
    viewModel.search = search;
    viewModel.enroll = enroll;
    viewModel.clearFilter = clearFilter;
    viewModel.getRowClass = getRowClass;

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