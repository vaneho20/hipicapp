/* global define: false, ko: false*/
define(function userImplModule() {
    "use strict";

    var properties = {
        USER_NAME: "userName"
    };

    /* jshint maxstatements: 100 */
    function userImpl(currentUser) {
        var user = {}, id = ko.observable(), version = ko.observable(), userName =
            ko.observable(), enabled = false, credentialsNonExpired = false, accountNonExpired =
            false, accountNonLocked = false, oldPassword = ko.observable(null), newPassword =
            ko.observable(null), confirmNewPassword = ko.observable(null);

        if (currentUser) {
            id(ko.isObservable(currentUser.id) ? currentUser.id() : currentUser.id);
            version(ko.isObservable(currentUser.version) ? currentUser.version() : currentUser.version);
            userName = currentUser.userName;
            enabled = currentUser.enabled;
            credentialsNonExpired = currentUser.credentialsNonExpired;
            accountNonExpired = currentUser.accountNonExpired;
            accountNonLocked = currentUser.accountNonLocked;

            oldPassword(ko.isObservable(currentUser.oldPassword) ? currentUser.oldPassword() : currentUser.oldPassword);
            newPassword(ko.isObservable(currentUser.newPassword) ? currentUser.newPassword() : currentUser.newPassword);
            confirmNewPassword(ko.isObservable(currentUser.confirmNewPassword) ? currentUser.confirmNewPassword() : currentUser.confirmNewPassword);
        }

        user.id = id;
        user.version = version;
        user.userName = userName;
        user.enabled = enabled;
        user.credentialsNonExpired = credentialsNonExpired;
        user.accountNonExpired = accountNonExpired;
        user.accountNonLocked = accountNonLocked;
        user.oldPassword = oldPassword;
        user.newPassword = newPassword;
        user.confirmNewPassword = confirmNewPassword;

        return user;
    }

    userImpl.properties = properties;

    return userImpl;
});