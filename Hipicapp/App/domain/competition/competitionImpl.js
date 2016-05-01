/* global define: false, ko: false */
define([
    "domain/competitionCategory/competitionCategoryImpl", "domain/specialty/specialtyImpl"
], function competitionImplModule(competitionCategoryImpl, specialtyImpl) {
    "use strict";

    var properties = {
        NAME: "name",
        DATE: "date"
    };

    /* jshint maxstatements: 35 */
    function competitionImpl(currentCompetition) {
        var competition = {}, id = null, version = ko.observable(), categoryId = null, name = null,
            startDate = ko.observable(moment()), endDate = ko.observable(moment()),
            registrationStartDate = ko.observable(moment()), registrationEndDate = ko.observable(moment()),
            category = competitionCategoryImpl(), address = null, zipCode = null, latitude = null, longitude = null,
            description = null, specialtyId = null, specialty = specialtyImpl();

        if (currentCompetition) {
            id = currentCompetition.id;
            version(currentCompetition.version);
            categoryId = currentCompetition.categoryId;
            specialtyId = currentCompetition.specialtyId;
            name = currentCompetition.name;
            description = currentCompetition.description;
            address = currentCompetition.address;
            zipCode = currentCompetition.zipCode;
            latitude = currentCompetition.latitude;
            longitude = currentCompetition.longitude;
            startDate(currentCompetition.startDate);
            endDate(currentCompetition.endDate);
            registrationStartDate(currentCompetition.registrationStartDate);
            registrationEndDate(currentCompetition.registrationEndDate);
            category = competitionCategoryImpl(currentCompetition.category);
            specialty = competitionCategoryImpl(currentCompetition.specialty);
        }

        competition.id = id;
        competition.version = version;
        competition.categoryId = categoryId;
        competition.specialtyId = specialtyId;
        competition.name = name;
        competition.description = description;
        competition.address = address;
        competition.zipCode = zipCode;
        competition.latitude = latitude;
        competition.longitude = longitude;
        competition.startDate = startDate;
        competition.endDate = endDate;
        competition.registrationStartDate = registrationStartDate;
        competition.registrationEndDate = registrationEndDate;
        competition.category = category;
        competition.specialty = specialty;

        return competition;
    }

    competitionImpl.properties = properties;

    return competitionImpl;
});