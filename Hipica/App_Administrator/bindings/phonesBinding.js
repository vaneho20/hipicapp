/* global $: false, define: false */
define(function phonesBinding() {
    "use strict";

    var binding = {};

    function init(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var $phones = $(element), underlyingObservable = valueAccessor();
        if (viewModel.currentEntity() && viewModel.currentEntity().country) {
            $phones.data("country", viewModel.currentEntity().country());
        }
        $phones.data("number", underlyingObservable());
        $phones.bfhphone($phones.data());
    }

    binding.init = init;

    return binding;
});