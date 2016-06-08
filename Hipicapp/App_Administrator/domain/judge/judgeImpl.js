/* global define: false, ko: false */
define([
    "domain/specialty/specialtyImpl"
], function judgeImplModule(specialtyImpl) {
    "use strict";

    var properties = {
        NAME: "name",
        SURNAMES: "surnames",
        SPECIALTY_ID: "specialtyId"
    };

    /* jshint maxstatements: 35 */
    function judgeImpl(currentJudge) {
        var judge = {}, id = null, version = ko.observable(), name = ko.observable(null),
            surnames = ko.observable(null), photoId = null, photo = null, gender = ko.observable(null),
            specialtyId = null, specialty = specialtyImpl(), federation = ko.observable(null),
            zipCode = ko.observable(null), placeId = ko.observable(null);

        if (currentJudge) {
            id = currentJudge.id;
            version(currentJudge.version);
            name(currentJudge.name);
            surnames(currentJudge.surnames);
            gender(currentJudge.gender);
            specialtyId = currentJudge.specialtyId;
            photoId = currentJudge.photoId;
            federation(currentJudge.federation);
            zipCode(currentJudge.zipCode);
            placeId(currentJudge.placeId);
            photo = currentJudge.photo;
            specialty = specialtyImpl(currentJudge.specialty);
        }

        judge.id = id;
        judge.version = version;
        judge.name = name;
        judge.surnames = surnames;
        judge.gender = gender;
        judge.federation = federation;
        judge.zipCode = zipCode;
        judge.placeId = placeId;
        judge.photoId = photoId;
        judge.specialtyId = specialtyId;
        judge.photo = photo;
        judge.specialty = specialty;
        judge.fullName = ko.computed(function () {
            return judge.id ? judge.name() + " " + judge.surnames() : "";
        }, judge);

        return judge;
    }

    judgeImpl.properties = properties;

    return judgeImpl;
});