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
    var viewModel = {}, tileCount = ko.observable(), lastCompetitions = ko.observableArray([]),
        registrations = ko.observableArray([]);

    // lifecycle definition
    function activate() {
        // allways return a promise
        return $.when(loadTileCount(), loadLastCompetitions(), loadRegistrations());
    }

    function attached() {
        var plot = $.plot($("#placeholder3xx3"), [{
            label: "Registros",
            data: registrations(),
            lines: {
                fillColor: "rgba(150, 202, 89, 0.12)"
            },
            points: {
                fillColor: "#fff"
            }
        }], {
            series: {
                lines: {
                    show: true,
                    fill: true,
                    lineWidth: 2,
                    steps: false
                },
                points: {
                    show: true,
                    radius: 4.5,
                    symbol: "circle",
                    lineWidth: 3.0
                }
            },
            colors: ["#96CA59", "#3F97EB", "#72c380", "#6f7a8a", "#f7cb38", "#5a8022", "#2c7282"],
            grid: {
                show: true,
                aboveData: true,
                color: "#3f3f3f",
                labelMargin: 10,
                axisMargin: 0,
                borderWidth: 0,
                borderColor: null,
                minBorderMargin: 5,
                clickable: true,
                hoverable: true,
                autoHighlight: true,
                mouseActiveRadius: 100
            },
            xaxis: {
                mode: "time",
                minTickSize: [1, "day"],
                timeformat: "%d/%m/%y",
                min: moment().startOf("week").valueOf(),
                max: moment().endOf("week").valueOf()
            },
            yaxis: {
                min: 0,
                tickDecimals: 0
            },
            legend: {
                position: "ne",
                margin: [0, 15],
                noColumns: 0,
                labelBoxBorderColor: null,
                labelFormatter: function (label, series) {
                    return label + '&nbsp;&nbsp;';
                },
                width: 40,
                height: 1
            },
            shadowSize: 0,
            tooltip: true,
            tooltipOpts: {
                content: "%s: %y.0",
                xDateFormat: "%d/%m",
                shifts: {
                    x: -30,
                    y: -50
                },
                defaultTheme: false
            }
        });

        $('#world-map-gdp').vectorMap({
            map: 'es_mill',
            backgroundColor: 'transparent',
            series: {
                regions: [{
                    values: gdpData,
                    scale: ['#E6F2F0', '#149B7E'],
                    normalizeFunction: 'polynomial'
                }]
            },
            onRegionTipShow: function (e, el, code) {
                //el.html(el.html() + ' (GDP - ' + gdpData[code] + ')');
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

    function refreshRegistrations(data) {
        registrations([]);
        _.map(data, function items(item) {
            registrations.push([item.date, item.amount]);
        });
        registrations.valueHasMutated();
    }

    function loadRegistrations() {
        return userBroker.getRegistrationsBetweenDates({
            ini: moment().startOf("week").valueOf(), end: moment().endOf("week").valueOf()
        }).done(refreshRegistrations);
    }

    function getTimeAgo(competition) {
        return moment.duration(moment().diff(moment(competition.creationDate))).humanize(true);
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
    viewModel.registrations = registrations;

    // lifecycle revelation
    viewModel.activate = activate;
    viewModel.attached = attached;

    // behaviour revelation
    viewModel.getTimeAgo = getTimeAgo;

    return viewModel;
});