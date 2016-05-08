/* global define: false, ko: false */
define([
    "domain/competition/competitionImpl", "domain/horse/horseImpl"
], function enrollmentImplModule(competitionImpl, horseImpl) {
    "use strict";

    var properties = {
        COMPETITION: "competition",
        HORSE: "horse"
    };

    /* jshint maxstatements: 35 */
    function enrollmentImpl(currentEnrollment) {
        var enrollment = {}, id = null, version = ko.observable(), enrollmentDate = ko.observable(null),
            competition = competitionImpl(), horse = horseImpl();

        if (currentEnrollment) {
            id = currentEnrollment.id;
            version(currentEnrollment.version);
            enrollmentDate(currentEnrollment.enrollmentDate);
            competition = competitionImpl(currentEnrollment.competition);
            horse = horseImpl(currentEnrollment.horse);
        }

        enrollment.id = id;
        enrollment.version = version;
        enrollment.enrollmentDate = enrollmentDate;
        enrollment.competition = competition;
        enrollment.horse = horse;

        return enrollment;
    }

    enrollmentImpl.properties = properties;
    enrollmentImpl.competitionImpl = competitionImpl;
    enrollmentImpl.horseImpl = horseImpl;

    return enrollmentImpl;
});