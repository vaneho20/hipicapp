/* global define: false, ko: false */
define([
    "domain/competitionCategory/competitionCategoryImpl", "domain/user/userImpl", "domain/specialty/specialtyImpl"
], function athleteImplModule(competitionCategoryImpl, userImpl, specialtyImpl) {
    "use strict";

    var properties = {
        DNI: "dni",
        NAME: "name",
        SURNAMES: "surnames",
        GENDER: "gender",
        BIRTH_DATE: "birthDate",
        SPECIALTY_ID: "specialtyId"
    };

    /* jshint maxstatements: 35 */
    function athleteImpl(currentAthlete) {
        var athlete = {}, id = null, version = ko.observable(), dni = null, name = ko.observable(null),
            surnames = ko.observable(null), gender = ko.observable(null), photoId = null, userId = null,
            categoryId = null, birthDate = ko.observable(null), photo = null, user = userImpl(),
            category = competitionCategoryImpl(), weight = null, specialtyId = null, specialty = specialtyImpl(),
            federation = ko.observable(null), zipCode = ko.observable(null), placeId = ko.observable(null);

        if (currentAthlete) {
            id = currentAthlete.id;
            version(currentAthlete.version);
            dni = currentAthlete.dni;
            name(currentAthlete.name);
            surnames(currentAthlete.surnames);
            gender(currentAthlete.gender);
            weight = currentAthlete.weight;
            categoryId = currentAthlete.categoryId;
            specialtyId = currentAthlete.specialtyId;
            photoId = currentAthlete.photoId;
            userId = currentAthlete.userId;
            birthDate(currentAthlete.birthDate);
            federation(currentAthlete.federation);
            zipCode(currentAthlete.zipCode);
            placeId(currentAthlete.placeId);
            photo = currentAthlete.photo;
            user = userImpl(currentAthlete.user);
            category = competitionCategoryImpl(currentAthlete.category);
            specialty = specialtyImpl(currentAthlete.specialty);
        }

        function completeName() {

        }

        athlete.id = id;
        athlete.version = version;
        athlete.dni = dni;
        athlete.name = name;
        athlete.surnames = surnames;
        athlete.gender = gender;
        athlete.weight = weight;
        athlete.categoryId = categoryId;
        athlete.specialtyId = specialtyId;
        athlete.photoId = photoId;
        athlete.userId = userId;
        athlete.birthDate = birthDate;
        athlete.federation = federation;
        athlete.zipCode = zipCode;
        athlete.placeId = placeId;
        athlete.category = category;
        athlete.photo = photo;
        athlete.specialty = specialty;
        athlete.user = user;
        athlete.fullName = ko.computed(function () {
            return athlete.name() + " " + athlete.surnames();
        }, athlete);

        return athlete;
    }

    athleteImpl.properties = properties;

    return athleteImpl;
});