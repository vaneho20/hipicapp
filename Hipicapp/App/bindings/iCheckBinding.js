/* global $: false, define: false */
define(function iCheckBinding() {
    "use strict";

    var binding = {};

    function init(element, valueAccessor) {
        $(element).iCheck({
            checkboxClass: "icheckbox_flat-red"
        });

        $(element).on("ifChanged", function () {
            var observable = valueAccessor();
            observable($(element)[0].checked);
        });
    }

    function update(element, valueAccessor) {
        var value = ko.unwrap(valueAccessor());
        if (value) {
            $(element).iCheck("check");
        } else {
            $(element).iCheck("uncheck");
        }
    }

    binding.init = init;
    binding.update = update;

    return binding;
});