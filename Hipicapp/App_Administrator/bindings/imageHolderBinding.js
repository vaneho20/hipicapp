/* global $:false, define: false, Holder: false */
/* jshint maxparams: 10 */
define(function imageHolderBinding() {
    "use strict";

    var binding = {};

    function update(element, valueAccessor) {
        var $img = $(element);

        if (!$img.attr("src")) {
            $img.attr("data-src", "holder.js/" + valueAccessor());
            Holder.run({
                images: element
            });
        }
    }

    binding.update = update;

    return binding;
});