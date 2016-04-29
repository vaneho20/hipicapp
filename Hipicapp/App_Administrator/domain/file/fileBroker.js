/* global define: false */
define([
    "core/broker", "core/util/urlUtils"
], function fileBroker(brokerUtils, urlUtils) {
    "use strict";

    var broker = {};

    function getUrlByUuid(fileUuid) {
        return brokerUtils.requestMappings.BACKEND + urlUtils.joinPath(brokerUtils.requestMappings.FILES, brokerUtils.requestMappings.DOWNLOAD, fileUuid);
    }

    broker.getUrlByUuid = getUrlByUuid;

    return broker;
});