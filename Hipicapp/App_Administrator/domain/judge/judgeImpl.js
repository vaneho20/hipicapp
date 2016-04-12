/* global define: false, ko: false */
define(function judgeImplModule() {
    "use strict";

    var properties = {
        NAME: "name",
        SURNAMES: "surnames"
    };

    /* jshint maxstatements: 35 */
    function judgeImpl(currentJudge) {
        var judge = {}, id = null, version = ko.observable(), name = null, surnames = null, photoId = null, photo = null;

        if (currentJudge) {
            id = currentJudge.id;
            version(currentJudge.version);
            name = currentJudge.name;
            surnames = currentJudge.surnames;
            photoId = currentJudge.photoId;
            photo = currentJudge.photo;
        }

        judge.id = id;
        judge.version = version;
        judge.name = name;
        judge.surnames = surnames;
        judge.photoId = photoId;
        judge.photo = photo;

        return judge;
    }

    judgeImpl.properties = properties;

    return judgeImpl;
});