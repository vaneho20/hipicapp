/* global _: false, define: false, ko: false */
/* jshint maxparams: 15, maxstatements: 60 */
define([
    "core/config", "core/i18n", "core/crud/findRequestImpl", "core/crud/pageImpl",
    "core/crud/pagerImpl", "core/crud/pageRequestImpl", "domain/judge/judgeBroker",
    "domain/competition/competitionBroker", "domain/judge/judgeFilterImpl",
    "domain/judge/judgeSortImpl", "domain/judge/judgeImpl", "viewmodels/competition",
    "durandal/app", "viewmodels/shell"
], function competitionJudges(config, i18n, findRequestImpl, pageImpl, pagerImpl, pageRequestImpl,
    judgeBroker, competitionBroker, judgeFilterImpl, judgeSortImpl, judgeImpl, competitionViewModel, app, shell) {
    "use strict";

    // state definition
    var viewModel = $.extend(false, {}, competitionViewModel), superActivate = viewModel.activate,
        PAGE_SIZE = config.PAGE_SIZE, PAGE_SIZES = config.PAGE_SIZES, nextFilter = ko.observable(judgeFilterImpl()),
        currentFilter = judgeFilterImpl(), currentSort = ko.observable(judgeSortImpl()),
        currentPage = ko.observable(pageImpl()), currentPager = ko.observable(pagerImpl()),
        currentPageSize = ko.observable(PAGE_SIZE), availableGenders = {
            "male": i18n.t("app:GENDER_MALE"), "female": i18n.t("app:GENDER_FEMALE")
        };

    // lifecycle definition
    function activate(competitionId) {
        return $.when(superActivate(competitionId).done(function onSuccess() {
            currentFilter.competitionId(viewModel.currentEntity().id);
            nextFilter().competitionId(viewModel.currentEntity().id);
            currentFilter.specialtyId(viewModel.currentEntity().specialtyId);
            nextFilter().specialtyId(viewModel.currentEntity().specialtyId);
        }).then(loadCurrentPage)).done(refreshNav);
    }

    function refreshNav() {
        viewModel.nav(viewModel.navs.JUDGES);
    }

    // behaviour definition
    function refreshCurrentPage(data) {
        currentPage(pageImpl(data));
        currentPager(pagerImpl(data));
    }

    function loadPageByIndex(index, totalElements) {
        if (index === 0 || index > 0 && index < currentPage().totalPages) {
            return judgeBroker.findByWithAssignment(
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
        nextFilter(judgeFilterImpl(currentFilter.competitionId()));

        return search();
    }

    function assignAllJudges() {
        return competitionBroker.assignAllJudges(viewModel.currentEntity().id).done(function onSuccess() {
            loadCurrentPage();
        });
    }

    function assignAllJudgesById() {
        var listJudgesId =
            _.map(currentPage().content, function transform(judgeId) {
                return judgeId.judgeId;
            });

        return competitionBroker.assignAllJudgesById(viewModel.currentEntity().id, listJudgesId)
            .done(function onSuccess() {
                loadCurrentPage();
            });
    }

    function assignAllJudgesByFilter() {
        return competitionBroker.assignAllJudgesByFilter(viewModel.currentEntity().id,
            findRequestImpl(currentFilter, pageRequestImpl(currentPage().number, currentPageSize, currentSort, currentPage().totalElements)))
            .done(function onSuccess() {
                loadCurrentPage();
            });
    }

    function unassignAllJudges() {
        return competitionBroker.unassignAllJudges(viewModel.currentEntity().id).done(function onSuccess() {
            loadCurrentPage();
        });
    }

    function unassignAllJudgesById() {
        var listJudgesId =
            _.map(currentPage().content, function transform(judgeId) {
                return judgeId.judgeId;
            });

        return competitionBroker.unassignAllJudgesById(viewModel.currentEntity().id, listJudgesId)
            .done(function onSuccess() {
                loadCurrentPage();
            });
    }

    function unassignAllJudgesByFilter() {
        return competitionBroker.unassignAllJudgesByFilter(
            viewModel.currentEntity().id,
            findRequestImpl(currentFilter, pageRequestImpl(currentPage().number,
                currentPageSize, currentSort, currentPage().totalElements))).done(
            function onSuccess() {
                loadCurrentPage();
            });
    }

    function assignUnassignJudge(judge) {
        return competitionBroker.assignUnassignJudge(viewModel.currentEntity().id, judge)
            .done(function onSuccess() {
                loadCurrentPage();
            });
    }

    function sortByProperty(property) {
        currentSort().setFirstOrderByProperty(property);
        currentSort().getOrderByIndex(0).cycleOrder();

        return loadCurrentPage();
    }

    // state revelation
    viewModel.shell = shell;
    viewModel.i18n = i18n;
    viewModel.nextFilter = nextFilter;
    viewModel.currentSort = currentSort;
    viewModel.currentPage = currentPage;
    viewModel.currentPager = currentPager;
    viewModel.currentPageSize = currentPageSize;
    viewModel.availablePageSizes = PAGE_SIZES;
    viewModel.availableGenders = availableGenders;
    //viewModel.competitionJudges = competitionJudges;

    // lifecycle revelation
    viewModel.activate = activate;

    // behaviour revelation
    viewModel.refreshCurrentPage = refreshCurrentPage;
    viewModel.loadPageByIndex = loadPageByIndex;
    viewModel.loadFirstPage = loadFirstPage;
    viewModel.loadCurrentPage = loadCurrentPage;
    viewModel.loadLastPage = loadLastPage;
    viewModel.search = search;
    viewModel.assignAllJudges = assignAllJudges;
    viewModel.assignAllJudgesById = assignAllJudgesById;
    viewModel.assignAllJudgesByFilter = assignAllJudgesByFilter;
    viewModel.unassignAllJudges = unassignAllJudges;
    viewModel.unassignAllJudgesById = unassignAllJudgesById;
    viewModel.unassignAllJudgesByFilter = unassignAllJudgesByFilter;
    viewModel.assignUnassignJudge = assignUnassignJudge;
    viewModel.clearFilter = clearFilter;

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