/* global define: false, ko: false */
define(function competitionCategoryImplModule() {
    "use strict";

    var properties = {
        NAME: "name"
    };

    /* jshint maxstatements: 35 */
    function competitionCategoryImpl(currentCompetitionCategory) {
        var competitionCategory = {}, id = null, version = ko.observable(), name = null, from = null, to = null,
            previous = ko.observable(false), later = ko.observable(false);

        if (currentCompetitionCategory) {
            id = currentCompetitionCategory.id;
            version(currentCompetitionCategory.version);
            name = currentCompetitionCategory.name;
            from = currentCompetitionCategory.from;
            to = currentCompetitionCategory.to;
            previous(currentCompetitionCategory.previous);
            later(currentCompetitionCategory.later);
        }

        competitionCategory.id = id;
        competitionCategory.version = version;
        competitionCategory.name = name;
        competitionCategory.from = from;
        competitionCategory.to = to;
        competitionCategory.previous = previous;
        competitionCategory.later = later;

        return competitionCategory;
    }

    competitionCategoryImpl.properties = properties;

    return competitionCategoryImpl;
});