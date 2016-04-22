/* global define: false, ko: false, moment: false */
define(function epochValuebinding() {
    "use strict";

    var binding = {};

    function init(element, valueAccessor) {
        var interceptor = {}, underlyingObservable = valueAccessor();

        function read() {
            var currentValue = underlyingObservable();
            if (currentValue) {
                return moment(currentValue).format('DD/MM/YYYY');
            }
        }

        function write(rawValue) {
            var currentValue = underlyingObservable(), convertedValue =
                moment(rawValue, 'DD/MM/YYYY').valueOf();

            if (convertedValue !== currentValue) {
                underlyingObservable(convertedValue);
            } else {
                if ((currentValue && moment(currentValue).format('DD/MM/YYYY') !== rawValue) ||
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