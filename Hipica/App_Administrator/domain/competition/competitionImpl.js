/* global define: false, ko: false */
define(["domain/competitionCategory/competitionCategoryImpl"], function competitionImplModule(competitionCategoryImpl) {
    "use strict";

    var properties = {
        NAME: "name",
        DATE: "date"
    };

    /* jshint maxstatements: 35 */
    function competitionImpl(currentCompetition) {
        var competition = {}, id = null, version = ko.observable(), categoryId = null, name = null,
            date = ko.observable(moment()), category = competitionCategoryImpl();

        if (currentCompetition) {
            id = currentCompetition.id;
            version(currentCompetition.version);
            categoryId = currentCompetition.categoryId;
            name = currentCompetition.name;
            date(currentCompetition.date);
            category = competitionCategoryImpl(currentCompetition.category);
        }

        competition.id = id;
        competition.version = version;
        competition.categoryId = categoryId;
        competition.name = name;
        competition.date = date;
        competition.category = category;

        return competition;
    }

    competitionImpl.properties = properties;

    return competitionImpl;
});