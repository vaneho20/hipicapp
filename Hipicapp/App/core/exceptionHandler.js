/* global _: false, define: false */
define(["core/i18n", "durandal/system", "viewmodels/alerts"
], function exceptionHandler(i18n, system, alerts) {
    "use strict";

    var handler = {}, exceptionHandlers = {
        "org.springframework.web.bind.MethodArgumentNotValidException": function handler(data) {
            var errors = _.map(data.errors, function projection(error) {
                return error.defaultMessage;
            }), i = 0, imax = errors.length;
            alerts.info(i18n.t(data.key));
            for (i = 0; i < imax; i = i + 1) {
                alerts.error(errors[i]);
            }
        }
    };

    function handleException(data) {
        system.log(data);
    }

    function handleRuntimeException(data) {
        handleException(data);

        alerts.fatal(i18n.format(i18n.t("FATAL_ALERT_TEXT"), data.args));
    }

    function handleApplicationException(data) {
        var handler = data.exceptionType ? exceptionHandlers[data.exceptionType.replace(/\./g, '_')] : undefined,
            errors = [];

        handleException(data);

        if (handler) {
            handler(data);
        } else {
            if (data.modelState) {
                _.each(data.modelState, function items(item, i) {
                    errors.push(i + ": " + item);
                });
                alerts.error(errors);
            } else {
                alerts.error(i18n.format(i18n.t(data.exceptionType.replace(/\./g, '_')), data.args));
            }
        }
    }

    function handle(data, status) {
        if (status === "error") {
            handleApplicationException(data);
        } else {
            handleRuntimeException(data);
        }
    }

    handler.handle = handle;

    return handler;
});