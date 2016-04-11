/* global $: false, define: false, setTimeout: false */
define(["core/i18n"
], function dateTimePickerBinding(i18n) {
    "use strict";

    var binding = {};

    function init(element, valueAccessor) {
        var underliyingObservable = valueAccessor(), previousDate = null, $element = $(element);

        if (!$element.parents("fieldset")[0].disabled) {
            setTimeout(function doAfterBinding() {
                $element.datetimepicker({
                    //format: i18n.t("app:DATETIME_PICKER_PATTERN"),
                    //language: i18n.t("app:CURRENT_LANGUAGE"),
                    format: "dd/MM/yyyy HH:mm",
                    language: "es",
                    pick12HourFormat: false
                }).on("changeDate", function onChangeDate(event) {
                    var currentDate = event.localDate.getTime();

                    if (currentDate !== previousDate) {
                        previousDate = currentDate;
                        underliyingObservable(currentDate);
                        $element.find("input").change();
                    }
                });
            }, 0);
        }
    }

    binding.init = init;

    return binding;
});