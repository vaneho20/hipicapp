/* global define: false, ko: false */
define(function horseImplModule() {
    "use strict";

    var properties = {
        NAME: "name"
    };

    /* jshint maxstatements: 35 */
    function horseImpl(currentHorse) {
        var horse = {}, id = null, version = ko.observable(), name = null, height = null, photoId = null,
            birthDate = ko.observable(null), photo = null, athleteId = null;

        if (currentHorse) {
            id = currentHorse.id;
            version(currentHorse.version);
            name = currentHorse.name;
            height = currentHorse.height;
            photoId = currentHorse.photoId;
            birthDate(currentHorse.birthDate);
            photo = currentHorse.photo;
            athleteId = currentHorse.athleteId;
        }

        horse.id = id;
        horse.version = version;
        horse.name = name;
        horse.height = height;
        horse.photoId = photoId;
        horse.birthDate = birthDate;
        horse.photo = photo;
        horse.athleteId = athleteId;

        return horse;
    }

    horseImpl.properties = properties;

    return horseImpl;
});