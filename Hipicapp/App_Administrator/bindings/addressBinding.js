/* global $: false, define: false */
define(["gmaps"], function addressBinding(gmaps) {
    "use strict";

    var binding = {}, component = {
        street_number: 'short_name',
        route: 'long_name',
        locality: 'long_name',
        administrative_area_level_1: 'short_name',
        country: 'long_name',
        postal_code: 'short_name'
    };

    function init(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var $element = $(element), underlyingObservable = valueAccessor(), autocomplete;
        autocomplete = new gmaps.places.Autocomplete($element[0]);
        autocomplete.addListener("place_changed", function() {
            fillIn(autocomplete, underlyingObservable);
        });
    }

    function fillIn(autocomplete, underlyingObservable) {
        var place = autocomplete.getPlace();

        underlyingObservable["value"](place.name);
        underlyingObservable["value"].valueHasMutated();
        underlyingObservable["place_id"](place.place_id);
        underlyingObservable["place_id"].valueHasMutated();
        /*for (var component in underlyingObservable) {
            if (ko.isObservable(component)) {

            }
            jQuery
            document.getElementById(component).value = "";
            document.getElementById(component).disabled = false;
        }*/

        for (var i = 0; i < place.address_components.length; i++) {
            var addressType = place.address_components[i].types[0];
            if (addressType in underlyingObservable) {
                var val = place.address_components[i][component[addressType]];
                if (ko.isObservable(underlyingObservable[addressType])) {
                    underlyingObservable[addressType](val);
                    underlyingObservable[addressType].valueHasMutated();
                } else {
                    underlyingObservable[addressType] = val;
                }
            }
        }
    }

    binding.init = init;

    return binding;
});