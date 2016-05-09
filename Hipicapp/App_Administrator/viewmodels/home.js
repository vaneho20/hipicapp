/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/competition/competitionBroker",
    "domain/user/userBroker", "viewmodels/shell", "viewmodels/alerts"
], function welcomeViewModel(i18n, router, securityContext, stringUtils, urlUtils,
    validationUtils, competitionBroker, userBroker, shell, alerts) {
    "use strict";

    // state definition
    var viewModel = {}, tileCount = ko.observable(), lastCompetitions = ko.observableArray([]);

    // lifecycle definition
    function activate() {
        // allways return a promise
        return $.when(loadTileCount(), loadLastCompetitions());
    }

    function attached() {
        //random data
        var d1 = [
          [0, 1],
          [1, 9],
          [2, 6],
          [3, 10],
          [4, 5],
          [5, 17],
          [6, 6],
          [7, 10],
          [8, 7],
          [9, 11],
          [10, 35],
          [11, 9],
          [12, 12],
          [13, 5],
          [14, 3],
          [15, 4],
          [16, 9]
        ];

        //flot options
        var plot = $.plot($("#placeholder3xx3"), [{
            label: "Registros",
            data: d1,
            lines: {
                fillColor: "rgba(150, 202, 89, 0.12)"
            }, //#96CA59 rgba(150, 202, 89, 0.42)
            points: {
                fillColor: "#fff"
            }
        }], {
            series: {
                curvedLines: {
                    apply: true,
                    active: true,
                    monotonicFit: true
                }
            },
            colors: ["#26B99A"],
            grid: {
                borderWidth: {
                    top: 0,
                    right: 0,
                    bottom: 1,
                    left: 1
                },
                borderColor: {
                    bottom: "#7F8790",
                    left: "#7F8790"
                }
            }
        });

        $('#world-map-gdp').vectorMap({
            map: 'world_mill_en',
            backgroundColor: 'transparent',
            zoomOnScroll: false,
            series: {
                regions: [{
                    values: gdpData,
                    scale: ['#E6F2F0', '#149B7E'],
                    normalizeFunction: 'polynomial'
                }]
            },
            onRegionTipShow: function (e, el, code) {
                el.html(el.html() + ' (GDP - ' + gdpData[code] + ')');
            }
        });
    }

    // behaviour definition
    function refreshTileCount(data) {
        tileCount(data);
    }

    function loadTileCount() {
        return userBroker.getTileCount().done(refreshTileCount);
    }

    function refreshLastCompetitions(data) {
        lastCompetitions(data);
    }

    function loadLastCompetitions() {
        return competitionBroker.findLast().done(refreshLastCompetitions);
    }

    // module revelation
    viewModel.i18n = i18n;
    viewModel.securityContext = securityContext;
    viewModel.validationUtils = validationUtils;
    viewModel.competitionBroker = competitionBroker;
    viewModel.userBroker = userBroker;

    // state revelation
    viewModel.lastCompetitions = lastCompetitions;
    viewModel.tileCount = tileCount;

    // lifecycle revelation
    viewModel.activate = activate;
    viewModel.attached = attached;

    // behaviour revelation

    return viewModel;
});