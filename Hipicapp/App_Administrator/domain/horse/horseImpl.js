/* global define: false, ko: false */
define(function horseImplModule() {
    "use strict";

    var properties = {
        NAME: "name"
    };

    /* jshint maxstatements: 35 */
    function horseImpl(currentHorse) {
        var horse = {}, id = null, version = ko.observable(), name = null, height = null, photoId = null,
            birthDate = ko.observable(null), photo = null, athleteId = null, gender = ko.observable(null),
            weight = null, athlete = null;

        if (currentHorse) {
            id = currentHorse.id;
            version(currentHorse.version);
            name = currentHorse.name;
            height = currentHorse.height;
            photoId = currentHorse.photoId;
            birthDate(currentHorse.birthDate);
            gender(currentHorse.gender);
            weight = currentHorse.weight;
            photo = currentHorse.photo;
            athleteId = currentHorse.athleteId;
            athlete = currentHorse.athlete;
        }

        horse.id = id;
        horse.version = version;
        horse.name = name;
        horse.height = height;
        horse.photoId = photoId;
        horse.birthDate = birthDate;
        horse.gender = gender;
        horse.weight = weight;
        horse.photo = photo;
        horse.athleteId = athleteId;
        horse.athlete = athlete;

        return horse;
    }

    horseImpl.properties = properties;

    return horseImpl;
});