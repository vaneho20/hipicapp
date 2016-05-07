/* global define: false, ko: false */
define(["domain/competitionCategory/competitionCategoryImpl", "domain/user/userImpl"],
    function athleteImplModule(competitionCategoryImpl, userImpl) {
        "use strict";

        var properties = {
            DNI: "dni",
            NAME: "name",
            SURNAMES: "surnames",
            GENDER: "gender",
            BIRTH_DATE: "birthDate"
        };

        /* jshint maxstatements: 35 */
        function athleteImpl(currentAthlete) {
            var athlete = {}, id = null, version = ko.observable(), dni = null, name = null, surnames = null,
                gender = ko.observable(null), photoId = null, userId = null, categoryId = null,
                birthDate = ko.observable(null), photo = null, user = userImpl(), category = competitionCategoryImpl(),
                weight = null;

            if (currentAthlete) {
                id = currentAthlete.id;
                version(currentAthlete.version);
                dni = currentAthlete.dni;
                name = currentAthlete.name;
                surnames = currentAthlete.surnames;
                gender(currentAthlete.gender);
                weight = currentAthlete.weight;
                categoryId = currentAthlete.categoryId;
                photoId = currentAthlete.photoId;
                userId = currentAthlete.userId;
                birthDate(currentAthlete.birthDate);
                photo = currentAthlete.photo;
                user = userImpl(currentAthlete.user);
                category = competitionCategoryImpl(currentAthlete.category);
            }

            athlete.id = id;
            athlete.version = version;
            athlete.dni = dni;
            athlete.name = name;
            athlete.surnames = surnames;
            athlete.gender = gender;
            athlete.weight = weight;
            athlete.categoryId = categoryId;
            athlete.photoId = photoId;
            athlete.userId = userId;
            athlete.birthDate = birthDate;
            athlete.category = category;
            athlete.photo = photo;
            athlete.user = user;

            return athlete;
        }

        athleteImpl.properties = properties;

        return athleteImpl;
    });