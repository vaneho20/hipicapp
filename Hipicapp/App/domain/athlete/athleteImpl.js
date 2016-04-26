/* global define: false, ko: false */
define(["domain/user/userImpl"], function athleteImplModule(userImpl) {
    "use strict";

    var properties = {
        DNI: "dni",
        NAME: "name",
        SURNAMES: "surnames",
        GENDER: "gender"
    }, genders = {
        MALE: "MALE",
        FEMALE: "FEMALE"
    };

    /* jshint maxstatements: 35 */
    function athleteImpl(currentAthlete) {
        var athlete = {}, id = null, version = ko.observable(), dni = null, name = null, surnames = null, gender = null,
            photoId = null, userId = null, birthDate = ko.observable(moment()), photo = null, user = userImpl(), weight = 0;

        if (currentAthlete) {
            id = currentAthlete.id;
            version(currentAthlete.version);
            dni = currentAthlete.dni;
            name = currentAthlete.name;
            surnames = currentAthlete.surnames;
            gender = currentAthlete.gender;
            weight = currentAthlete.weight;
            photoId = currentAthlete.photoId;
            userId = currentAthlete.userId;
            birthDate(currentAthlete.birthDate);
            photo = currentAthlete.photo;
            user = userImpl(currentAthlete.user);
        }

        athlete.id = id;
        athlete.version = version;
        athlete.dni = dni;
        athlete.name = name;
        athlete.surnames = surnames;
        athlete.gender = gender;
        athlete.weight = weight;
        athlete.photoId = photoId;
        athlete.userId = userId;
        athlete.birthDate = birthDate;
        athlete.photo = photo;
        athlete.user = user;

        return athlete;
    }

    athleteImpl.properties = properties;
    athleteImpl.genders = genders;

    return athleteImpl;
});