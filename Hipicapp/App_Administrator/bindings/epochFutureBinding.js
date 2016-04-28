/* global define: false, ko: false, moment: false */
define(
    [
        "core/i18n"
    ],
    function epochFutureBinding(i18n) {
        "use strict";

        var binding = {};

        function checkValid(element, value) {
            if (value <= moment().valueOf()) {
                element.setCustomValidity(i18n.t("app:EPOCH_FUTURE_VALIDATOR_MESSAGE"));
            } else {
                element.setCustomValidity("");
            }
        }

        function init(element, valueAccessor, allBindingsAccessor) {
            var $element = $(element), underlyingObservable = valueAccessor().value,
                condition = valueAccessor().condition, allBindings = allBindingsAccessor(),
                pattern = allBindings.epochFuturePattern, interceptor = {};

            function read() {
                if (condition && $element.closest("form")[0].checkValidity) {
                    checkValid(element, underlyingObservable());
                }

                var currentValue = underlyingObservable();
                if (currentValue) {
                    return moment(currentValue).format(pattern);
                }
            }

            function write(rawValue) {
                var convertedValue = moment(rawValue, pattern).valueOf();

                if (condition && $element.closest("form")[0].checkValidity) {
                    checkValid(element, convertedValue);
                }
            }

            interceptor.read = read;
            interceptor.write = write;

            ko.applyBindingsToNode(element, {
                value: ko.computed(interceptor)
            });
        }

        binding.init = init;

        return binding;
    });