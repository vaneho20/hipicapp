/* global define: false, ko: false, moment: false */
define([
    "domain/user/userImpl"
], function ticketImplModule(userImpl) {
    "use strict";

    function ticketImpl(currentTicket) {
        var ticket = {}, user = userImpl(), key = ko.observable();

        if (currentTicket) {
            user = userImpl(currentTicket.user);
            key(currentTicket.key);
        }

        ticket.user = user;
        ticket.key = key;

        return ticket;
    }

    return ticketImpl;
});