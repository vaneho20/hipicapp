/* global define: false, ko: false */
define(function specialtyImplModule() {
    "use strict";

    var properties = {
        NAME: "name"
    };

    /* jshint maxstatements: 35 */
    function specialtyImpl(currentSpecialty) {
        var specialty = {}, id = null, version = ko.observable(), name = null, minAgeOfHorse = null, maxNoOfJudges = null,
            maxWeightOfAthlWithSaddle = null;

        if (currentSpecialty) {
            id = currentSpecialty.id;
            version(currentSpecialty.version);
            name = currentSpecialty.name;
            minAgeOfHorse = currentSpecialty.minAgeOfHorse;
            maxNoOfJudges = currentSpecialty.maxNoOfJudges;
            maxWeightOfAthlWithSaddle = currentSpecialty.maxWeightOfAthlWithSaddle;
        }

        specialty.id = id;
        specialty.version = version;
        specialty.name = name;
        specialty.minAgeOfHorse = minAgeOfHorse;
        specialty.maxNoOfJudges = maxNoOfJudges;
        specialty.maxWeightOfAthlWithSaddle = maxWeightOfAthlWithSaddle;

        return specialty;
    }

    specialtyImpl.properties = properties;

    return specialtyImpl;
});