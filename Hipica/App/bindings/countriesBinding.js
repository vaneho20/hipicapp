/* global $: false, define: false */
define(function countriesBinding() {
    "use strict";

    var binding = {};

    function init(element, valueAccessor) {
        var $countries = $(element), underlyingObservable = valueAccessor();
        $countries.data("country", underlyingObservable());
        $countries.bfhcountries($countries.data());
    }

    binding.init = init;

    return binding;
});