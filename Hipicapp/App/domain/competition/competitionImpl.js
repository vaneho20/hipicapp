/* global define: false, ko: false */
define(function competitionImplModule() {
    "use strict";

    var properties = {
        NAME: "name",
        DATE: "date"
    };

    /* jshint maxstatements: 35 */
    function competitionImpl(currentCompetition) {
        var competition = {}, id = null, version = ko.observable(), name = null, date = ko.observable(moment());

        if (currentCompetition) {
            id = currentCompetition.id;
            version(currentCompetition.version);
            name = currentCompetition.name;
            date(currentCompetition.date);
        }

        competition.id = id;
        competition.version = version;
        competition.name = name;
        competition.date = date;

        return competition;
    }

    competitionImpl.properties = properties;

    return competitionImpl;
});