/* global $: false, define: false */
define(function carouselBinding() {
    "use strict";

    var binding = {};

    function init(element, valueAccessor) {
        setTimeout(function doAfterBinding() {
            var prevButton = valueAccessor().prevButton, nextButton = valueAccessor().nextButton,
                onBefore = valueAccessor().onBefore, items = valueAccessor().items;
            $(element).carouFredSel({
                circular: false,
                infinite: false,
                auto: false,
                prev: {
                    button: prevButton,
                    key: "left"
                },
                next: {
                    button: nextButton,
                    key: "right",
                    onBefore: onBefore
                }
            });
        }, 200);
    }

    binding.init = init;

    return binding;
});