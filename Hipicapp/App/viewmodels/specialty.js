/* global define: false, ko: false */
/* jshint maxparams: 11 */
define([
    "core/i18n", "core/router", "core/authentication/securityContext", "core/util/stringUtils",
    "core/util/urlUtils", "core/util/validationUtils", "domain/athlete/athleteBroker",
    "domain/banner/bannerBroker", "domain/competition/competitionBroker", "domain/file/fileBroker",
    "domain/horse/horseBroker", "domain/judge/judgeBroker", "domain/specialty/specialtyBroker",
    "domain/specialty/specialtyImpl", "gmaps", "viewmodels/shell", "viewmodels/alerts"
], function specialtyViewModel(i18n, router, securityContext, stringUtils, urlUtils, validationUtils,
    athleteBroker, bannerBroker, competitionBroker, fileBroker, horseBroker, judgeBroker, specialtyBroker,
    specialtyImpl, gmaps, shell, alerts) {
    "use strict";

    // state definition
    var viewModel = {}, currentEntity = ko.observable(specialtyImpl()), ranking = ko.observableArray([]),
        nextCompetitions = ko.observableArray([]), geocoder = new gmaps.Geocoder, banners = ko.observableArray([]);

    // lifecycle definition
    function activate(id) {
        if (id) {
            // allways return a promise
            return $.when(loadEntityBySpecialtyId(id), loadRankingBySpecialtyId(id), loadVisibleBySpecialtyId(id),
                loadNextCompetitionsBySpecialtyId(id));
        } else {
            refreshCurrentEntity();
        }
    }

    // behaviour definition
    function refreshCurrentEntity(data) {
        currentEntity(specialtyImpl(data));
    }

    function loadEntityBySpecialtyId(id) {
        return specialtyBroker.findById(id).done(refreshCurrentEntity);
    }

    function refreshRanking(data) {
        ranking(data);
    }

    function loadRankingBySpecialtyId(specialtyId) {
        return competitionBroker.adultRankingsBySpecialtyId(specialtyId).done(refreshRanking);
    }

    function refreshNextCompetitions(data) {
        _.each(data, function competitions(competition) {
            competition.locality = ko.observable(null);
            geocoder.geocode({ placeId: competition.placeId, componentRestrictions: { postalCode: competition.zipCode } }, function (results, status) {
                if (status === gmaps.GeocoderStatus.OK) {
                    competition.locality(_.find(results[0].address_components, function items(item) {
                        return _.contains(item.types, "locality");
                    }).long_name);
                } else {
                    competition.locality(null);
                }
                nextCompetitions.valueHasMutated();
            });
        });
        nextCompetitions(data);
    }

    function loadNextCompetitionsBySpecialtyId(specialtyId) {
        return competitionBroker.findNextBySpecialtyId(specialtyId).done(refreshNextCompetitions);
    }

    function refreshBanners(data) {
        banners(data);
        banners.valueHasMutated();
    }

    function loadVisibleBySpecialtyId(specialtyId) {
        return bannerBroker.findVisibleBySpecialtyId(specialtyId).done(refreshBanners);
    }

    // module revelation
    viewModel.i18n = i18n;
    viewModel.router = router;
    viewModel.securityContext = securityContext;
    viewModel.validationUtils = validationUtils;
    viewModel.athleteBroker = athleteBroker;
    viewModel.competitionBroker = competitionBroker;
    viewModel.fileBroker = fileBroker;
    viewModel.horseBroker = horseBroker;
    viewModel.judgeBroker = judgeBroker;
    viewModel.specialtyBroker = specialtyBroker;

    // state revelation
    viewModel.currentEntity = currentEntity;
    viewModel.ranking = ranking;
    viewModel.nextCompetitions = nextCompetitions;
    viewModel.banners = banners;

    // lifecycle revelation
    viewModel.activate = activate;

    // behaviour revelation

    return viewModel;
});