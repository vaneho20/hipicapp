/* global define: false, ko: false, moment: false */
define(function epochValuebinding() {
    "use strict";

    var binding = {};

    function init(element, valueAccessor, allBindingsAccessor) {
        var interceptor = {}, underlyingObservable = valueAccessor(),
            allBindings = allBindingsAccessor(), pattern = allBindings.epochValuePattern;

        function read() {
            var currentValue = underlyingObservable();
            if (currentValue) {
                return moment(currentValue).format(pattern);
            }
        }

        function write(rawValue) {
            var currentValue = underlyingObservable(), convertedValue = moment(rawValue, pattern).valueOf();

            if (convertedValue !== currentValue) {
                underlyingObservable(convertedValue);
            } else {
                if ((currentValue && moment(currentValue).format(pattern) !== rawValue) ||
                    rawValue !== currentValue) {
                    underlyingObservable.valueHasMutated();
                }
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