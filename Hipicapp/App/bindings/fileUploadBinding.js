/* global $:false, define: false, setTimeout: false */
/* jshint maxparams: 10 */
define([
    "core/authentication/securityContext", "core/broker", "core/exceptionHandler", "core/i18n",
    "core/util/urlUtils", "core/util/validationUtils", "viewmodels/alerts"
], function fileuploadBinding(securityContext, brokerUtils, exceptionHandler, i18n,
    urlUtils, validationUtils, alerts) {
    "use strict";

    var binding = {};

    function init(element, valueAccessor) {
        var broker = valueAccessor().broker, entityId = valueAccessor().entityId, $dropZone, $thumbnail, $progress;

        function done(event, data) {
            broker.evictCache();

            if (!$thumbnail) {
                $thumbnail = $(valueAccessor().thumbnail).find("img");
            }

            if ($thumbnail && $thumbnail.length) {
                $thumbnail.attr("src", brokerUtils.requestMappings.BACKEND +
                    urlUtils.joinPath(brokerUtils.requestMappings.FILES, brokerUtils.requestMappings.DOWNLOAD, data.result.fileUuid));
            } else {
                alerts.success(i18n.t('app:SUCCESS_ALERT_TEXT'));
            }

            $progress.hide();
        }

        function fail(event, data) {
            broker.evictCache();

            exceptionHandler.handle(data.jqXHR.responseJSON);

            $progress.hide();
        }

        function processfail() {
            exceptionHandler.handle({
                exceptionType: "Hipicapp.Exceptions.ImageException",
                args: validationUtils.MAX_FILE_SIZE
            }, "error");
        }

        function progressall(event, data) {
            if (!$progress) {
                $progress = $(valueAccessor().progress).find(".bar");
            }

            $progress.show();

            if ($progress.length) {
                $progress.css("width", parseInt(data.loaded / data.total * 100, 10) + "%");
            }
        }

        $(element).fileupload({
            url: broker.getFileuploadUrlById(entityId),
            acceptFileTypes: validationUtils.ACCEPT_FILE_TYPES,
            maxFileSize: validationUtils.MAX_FILE_SIZE,
            processfail: processfail,
            progressall: progressall,
            done: done,
            fail: fail,
            type: "POST",
            dropZone: $dropZone,
            pasteZone: $dropZone,
            beforeSend: function (xhr, settings) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + securityContext.getAuthenticationToken());
            }
        });

        // set dropzone after page is loaded
        setTimeout(function delay() {
            if (!$dropZone) {
                $dropZone = $(valueAccessor().dropZone);
            }

            $(element).fileupload("option", "dropZone", $dropZone);
        }, 1000); // weve got time enough since user has to select a file and
        // drop it
    }

    binding.init = init;

    return binding;
});