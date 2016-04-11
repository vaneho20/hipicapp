/* global $:false, define: false, ko:false */
define(function typeaheadBinding() {
    "use strict";

    var binding = {};

    function init(element, valueAccessor) {
        $(element).typeahead({
            'source': ko.utils.unwrapObservable(valueAccessor())
        });
    }

    binding.init = init;

    return binding;
});