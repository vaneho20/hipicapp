/* global define: false, ko: false */
define(function competitionCategoryImplModule() {
    "use strict";

    var properties = {
        NAME: "name"
    };

    /* jshint maxstatements: 35 */
    function competitionCategoryImpl(currentCompetitionCategory) {
        var competitionCategory = {}, id = null, version = ko.observable(), name = null,
            initialYear = ko.observable(moment), finalYear = ko.observable(moment()),
            previous = ko.observable(false), later = ko.observable(false);

        if (currentCompetitionCategory) {
            id = currentCompetitionCategory.id;
            version(currentCompetitionCategory.version);
            name = currentCompetitionCategory.name;

            if (currentCompetitionCategory.initialYear) {
                var m = moment(currentCompetitionCategory.initialYear, ["YYYY-MM-DD"]);
                initialYear(new Date(Date.UTC(m.year(), m.month(), m.date())));
            }

            if (currentCompetitionCategory.finalYear) {
                var m = moment(currentCompetitionCategory.finalYear, ["YYYY-MM-DD"]);
                finalYear(new Date(Date.UTC(m.year(), m.month(), m.date())));
            }

            previous(currentCompetitionCategory.previous);
            later(currentCompetitionCategory.later);
        }

        competitionCategory.id = id;
        competitionCategory.version = version;
        competitionCategory.name = name;
        competitionCategory.initialYear = initialYear;
        competitionCategory.finalYear = finalYear;
        competitionCategory.previous = previous;
        competitionCategory.later = later;

        return competitionCategory;
    }

    competitionCategoryImpl.properties = properties;

    return competitionCategoryImpl;
});