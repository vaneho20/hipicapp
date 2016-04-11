/* global $: false, define: false */
define(function bootstrapSwitchBinding() {
    "use strict";

    var binding = {};

    function init(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        ko.bindingHandlers.checked.update(element, valueAccessor);
        setTimeout(function doAfterBinding() {
            $(element.parentElement).bootstrapSwitch().on('switch-change', function (e, data) {
                var value = valueAccessor();
                value(data.value);
                ko.bindingHandlers.checked.update(element, valueAccessor);
            });
        }, 0);
    }

    binding.init = init;

    return binding;
});