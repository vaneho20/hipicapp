/* global $: false, define: false */
define(function popoverBinding() {
    "use strict";

    var binding = {};

    function init(element) {
        $(element).popover({
            placement: "bottom"
        });
    }

    binding.init = init;

    return binding;
});