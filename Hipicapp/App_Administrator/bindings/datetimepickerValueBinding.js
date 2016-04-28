/* global $: false, define: false, setTimeout: false */
define(["core/i18n"
], function dateTimePickerBinding(i18n) {
    "use strict";

    var binding = {};

    function init(element, valueAccessor, allBindingsAccessor) {
        var underliyingObservable = valueAccessor(), previousDate = null, $element = $(element),
            options = allBindingsAccessor().dateTimePickerOptions || {};

        setTimeout(function doAfterBinding() {
            $element.datetimepicker(options).on("dp.change", function onChangeDate(event) {
                var currentDate = event.date.toDate();

                if (currentDate !== previousDate) {
                    previousDate = currentDate;
                    underliyingObservable(currentDate);
                    $element.find("input").change();
                }
            });
        }, 0);
    }

    binding.init = init;

    return binding;
});