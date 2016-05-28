/* global define: false, ko: false */
define([
    "domain/competitionCategory/competitionCategoryImpl", "domain/specialty/specialtyImpl"
], function competitionImplModule(competitionCategoryImpl, specialtyImpl) {
    "use strict";

    var properties = {
        NAME: "name",
        DATE: "date",
        CATEGORY_ID: "categoryId",
        SPECIALTY_ID: "specialtyId"
    };

    /* jshint maxstatements: 35 */
    function competitionImpl(currentCompetition) {
        var competition = {}, id = null, version = ko.observable(), categoryId = null, name = null, photoId = null,
            startDate = ko.observable(null), endDate = ko.observable(null), registrationStartDate = ko.observable(null),
            registrationEndDate = ko.observable(null), category = competitionCategoryImpl(), address = ko.observable(null),
            zipCode = ko.observable(null), placeId = ko.observable(null), description = null, specialtyId = null,
            specialty = specialtyImpl(), photo = null, finalized = ko.observable(null);

        if (currentCompetition) {
            id = currentCompetition.id;
            version(currentCompetition.version);
            categoryId = currentCompetition.categoryId;
            specialtyId = currentCompetition.specialtyId;
            photoId = currentCompetition.photoId;
            name = currentCompetition.name;
            description = currentCompetition.description;
            address(currentCompetition.address);
            zipCode(currentCompetition.zipCode);
            placeId(currentCompetition.placeId);
            startDate(currentCompetition.startDate);
            endDate(currentCompetition.endDate);
            registrationStartDate(currentCompetition.registrationStartDate);
            registrationEndDate(currentCompetition.registrationEndDate);
            finalized(currentCompetition.finalized);
            category = competitionCategoryImpl(currentCompetition.category);
            specialty = competitionCategoryImpl(currentCompetition.specialty);
            photo = currentCompetition.photo;
        }

        competition.id = id;
        competition.version = version;
        competition.categoryId = categoryId;
        competition.specialtyId = specialtyId;
        competition.photoId = photoId;
        competition.name = name;
        competition.description = description;
        competition.address = address;
        competition.zipCode = zipCode;
        competition.placeId = placeId;
        competition.startDate = startDate;
        competition.endDate = endDate;
        competition.registrationStartDate = registrationStartDate;
        competition.registrationEndDate = registrationEndDate;
        competition.finalized = finalized;
        competition.category = category;
        competition.specialty = specialty;
        competition.photo = photo;

        return competition;
    }

    competitionImpl.properties = properties;

    return competitionImpl;
});