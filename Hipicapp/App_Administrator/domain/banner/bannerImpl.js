/* global define: false, ko: false */
define(["domain/specialty/specialtyImpl"], function bannerImplModule(specialtyImpl) {
    "use strict";

    var properties = {
        TITLE: "title"
    };

    /* jshint maxstatements: 35 */
    function bannerImpl(currentBanner) {
        var banner = {}, id = null, version = ko.observable(), title = null, web = null, visible = null,
            imageId = null, specialtyId = null, image = null, specialty = specialtyImpl();

        if (currentBanner) {
            id = currentBanner.id;
            version(currentBanner.version);
            title = currentBanner.title;
            web = currentBanner.web;
            visible = currentBanner.visible;
            specialtyId = currentBanner.specialtyId;
            imageId = currentBanner.imageId;
            image = currentBanner.image;
            specialty = specialtyImpl(currentBanner.specialty);
        }

        banner.id = id;
        banner.version = version;
        banner.title = title;
        banner.web = web;
        banner.visible = visible;
        banner.specialtyId = specialtyId;
        banner.imageId = imageId;
        banner.image = image;
        banner.specialty = specialty;

        return banner;
    }

    bannerImpl.properties = properties;

    return bannerImpl;
});