/* global define: false, ko: false*/
define([
    "core/i18n", "core/util/validationUtils"
], function equalBinding(i18n, validationUtils) {
    "use strict";

    var binding = {};

    /* jshint unused: false*/
    function init(element, valueAccessor, allBindingsAccessor, viewModel) {
        var underlyingValueObservable = valueAccessor().value, underlyingOtherValueObservable =
            valueAccessor().otherValue, comparator = valueAccessor().comparator, otherElement =
            valueAccessor().otherElement, errorMessage = valueAccessor().errorMessage, interceptor =
            ko.computed({
                read: function read() {
                    return underlyingValueObservable();
                },
                write: function write(rawValue) {
                    var currentValue = underlyingValueObservable(), isValid =
                        validationUtils.isEqual(rawValue, underlyingOtherValueObservable(),
                            comparator);

                    if (rawValue !== currentValue) {
                        underlyingValueObservable(rawValue);
                        underlyingValueObservable.valueHasMutated();
                    }

                    if (!isValid) {
                        element.setCustomValidity(errorMessage);
                        $(otherElement)[0].setCustomValidity(errorMessage);
                    } else {
                        element.setCustomValidity("");
                        $(otherElement)[0].setCustomValidity("");
                    }
                }
            });

        ko.applyBindingsToNode(element, {
            value: interceptor
        });
    }

    binding.init = init;

    return binding;
});