/* global _: false, define: false, ko: false */
/* jshint maxparams: 20, maxstatements: 100 */
define(
    [
        "core/config", "core/i18n", "core/authentication/securityContext", "core/util/stringUtils",
        "core/crud/findRequestImpl", "core/crud/pageImpl", "core/crud/pagerImpl",
        "core/crud/pageRequestImpl", "core/util/validationUtils",
        "domain/user/userBroker", "domain/user/userFilterImpl", "domain/user/userSortImpl",
        "domain/user/userImpl", "durandal/app", "viewmodels/alerts", "viewmodels/shell"
    ],
    function users(config, i18n, securityContext, stringUtils, findRequestImpl, pageImpl,
                   pagerImpl, pageRequestImpl, validationUtils, userBroker,
                   userFilterImpl, userSortImpl, userImpl, app, alerts, shell) {
        "use strict";

        // state definition
        var viewModel = {}, PAGE_SIZE = config.PAGE_SIZE, PAGE_SIZES = config.PAGE_SIZES, nextFilter =
            ko.observable(userFilterImpl(true, null, null, null)), currentFilter =
            userFilterImpl(true, null, null, null), currentSort =
            ko.observable(userSortImpl()), currentPage = ko.observable(pageImpl()), currentPager =
            ko.observable(pagerImpl()), currentPageSize = ko.observable(PAGE_SIZE)/*, availableBooleans = [
            {
                value: true,
                description: i18n.t('app:ENABLED
            }, {
                value: false,
                description: i18n.t('app:DISABLED
            }
            ], availableUserTypes = [
            {
                value: userImpl.userType.USER,
                description: i18n.t('app:TYPE_USER
            }, {
                value: userImpl.userType.CLIENT,
                description: i18n.t('app:TYPE_CLIENT
            }, {
                value: userImpl.userType.CONSUMER,
                description: i18n.t('app:TYPE_CONSUMER
            }
            ]*/;

        // lifecycle definition
        function activate() {
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
                return userBroker.findBy(
                    findRequestImpl(currentFilter, pageRequestImpl(index, currentPageSize,
                        getCurrentSortByUserType(), totalElements))).done(
                    refreshCurrentPage);
            }
        }

        function getCurrentSortByUserType(userType) {
            /* jshint maxlen: 999*/
            return currentSort;
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
            nextFilter(userFilterImpl(true));

            return search();
        }

        function sortByProperty(property) {
            currentSort().setFirstOrderByProperty(property);
            currentSort().getOrderByIndex(0).cycleOrder();

            return loadCurrentPage();
        }

        function deleteRow(user) {
            app.showMessage(i18n.t('app:DELETE_MESSAGE_BOX_CONTENT'), i18n.t('app:DELETE_MESSAGE_BOX_TITLE'), [
                i18n.t('app:YES'), i18n.t('app:NO')
            ]).done(function hideMessage(answer) {
                if (answer === i18n.t('app:YES')) {
                    userBroker.erase(userImpl(user)).done(loadCurrentPage);
                }
            });
        }

        function disableRow(user) {
            app.showMessage(i18n.t('app:DISABLE_MESSAGE_BOX_CONTENT'), i18n.t('app:DISABLE_MESSAGE_BOX_TITLE'), [
                i18n.t('app:YES'), i18n.t('app:NO')
            ]).done(function hideMessage(answer) {
                if (answer === i18n.t('app:YES')) {
                    userBroker.disable(userImpl(user)).done(loadCurrentPage);
                }
            });
        }

        function enableRow(user) {
            app.showMessage(i18n.t('app:ENABLE_MESSAGE_BOX_CONTENT'), i18n.t('app:ENABLE_MESSAGE_BOX_TITLE'), [
                i18n.t('app:YES'), i18n.t('app:NO')
            ]).done(function hideMessage(answer) {
                if (answer === i18n.t('app:YES')) {
                    userBroker.enable(userImpl(user)).done(loadCurrentPage);
                }
            });
        }

        function getRowClass(row) {
            var rowClass = "";

            if (!row.enabled) {
                rowClass = "danger";
            }/* else if (row.userType === userImpl.userType.CLIENT) {
                rowClass = "warning";
            } else if (row.userType === userImpl.userType.CONSUMER) {
                rowClass = "success";
            } else if (row.userType === userImpl.userType.USER) {
                rowClass = "info";
            }*/

            return rowClass;
        }

        function getDetailUrlBy(row) {
            return userBroker.getDetailUrlByUserId(row.id);
        }

        // state revelation
        viewModel.shell = shell;
        viewModel.i18n = i18n;
        viewModel.validationUtils = validationUtils;
        viewModel.userImpl = userImpl;
        viewModel.userBroker = userBroker;
        viewModel.nextFilter = nextFilter;
        viewModel.currentSort = currentSort;
        viewModel.currentPage = currentPage;
        viewModel.currentPager = currentPager;
        viewModel.currentPageSize = currentPageSize;
        viewModel.availablePageSizes = PAGE_SIZES;
        //viewModel.availableBooleans = availableBooleans;
        //viewModel.availableUserTypes = availableUserTypes;

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
        viewModel.disableRow = disableRow;
        viewModel.enableRow = enableRow;
        viewModel.getRowClass = getRowClass;
        viewModel.getDetailUrlBy = getDetailUrlBy;

        // bind helpers
        viewModel.sortByUserName = _.partial(sortByProperty, userImpl.properties.USER_NAME);

        viewModel.getOrderIconTitleForUserName = ko.computed(function getOrderIconTitleForUserName() {
            return currentSort().getOrderByProperty(userImpl.properties.USER_NAME).getIconTitle();
        });

        viewModel.getOrderIconClassForUserName = ko.computed(function getOrderIconClassForUserName() {
            return currentSort().getOrderByProperty(userImpl.properties.USER_NAME).getIconClass();
        });

        return viewModel;
    });