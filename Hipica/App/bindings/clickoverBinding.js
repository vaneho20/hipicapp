/* global $: false, define: false */
define(function clickoverBinding() {
    "use strict";

    var binding = {};

    function init(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        setTimeout(function doAfterBinding() {
            var $popover = $(element);
            $popover.data("content", $(allBindingsAccessor().clickover.clickoverId).html());
            $popover.clickover({ html: true });
        }, 1000);
    }

    binding.init = init;

    return binding;
});