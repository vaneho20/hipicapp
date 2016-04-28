/* global define: false, ko: false, moment: false */
define(
    ["core/i18n"],
    function epochAfterBinding(i18n) {
        "use strict";

        var binding = {};

        function init(element, valueAccessor, allBindingsAccessor) {
            if ($(element).closest("form")[0].checkValidity) {
                var underlyingObservable = valueAccessor(), allBindings = allBindingsAccessor(),
                    message = allBindings.afterMessage, pattern = allBindings.epochAfterPattern,
                    interceptor = ko.computed({
                        read: function read() {
                            return underlyingObservable();
                        },
                        write: function write(rawValue) {
                            var targetValue = underlyingObservable(), convertedValue =
                                moment(rawValue, pattern).valueOf();

                            if (convertedValue <= targetValue) {
                                element.setCustomValidity(message);
                            } else {
                                element.setCustomValidity("");
                            }
                        }
                    });

                if (!message) {
                    message = i18n.t("app:EPOCH_AFTER_TEXT");
                }

                ko.applyBindingsToNode(element, {
                    value: interceptor
                });
            }
        }

        binding.init = init;

        return binding;
    });