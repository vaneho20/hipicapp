/* global define: false, ko: false */
define(function competitionCategoryImplModule() {
    "use strict";

    var properties = {
        NAME: "name"
    };

    /* jshint maxstatements: 35 */
    function competitionCategoryImpl(currentCompetitionCategory) {
        var competitionCategory = {}, id = null, version = ko.observable(), name = null;

        if (currentCompetitionCategory) {
            id = currentCompetitionCategory.id;
            version(currentCompetitionCategory.version);
            name = currentCompetitionCategory.name;
        }

        competitionCategory.id = id;
        competitionCategory.version = version;
        competitionCategory.name = name;

        return competitionCategory;
    }

    competitionCategoryImpl.properties = properties;

    return competitionCategoryImpl;
});