/* global $: false, define: false */
define(function select2Binding() {
    "use strict";

    var binding = {};

    function init(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var $element = $(element), options = ko.toJS(valueAccessor()) || {}, allBindings = allBindingsAccessor(),
            lookupKey = allBindings.lookupKey, open = allBindings.open, setValue = allBindings.setValue,
            isObservable = ko.isObservable(allBindings.options), multiple = element.multiple,
            lockedId = allBindings.lockedId;

        function format(state) {
            if (multiple && state.id === lockedId.toString()) {
                var $originalOption = $(state.element);
                $originalOption.data("locked", true);
                $originalOption.attr("disabled", "disabled");
                state.locked = true;
                state.disabled = true;
            }
            return state.text;
        }

        setTimeout(function doAfterBinding() {
            options.formatSelection = format;
            $element.select2(options).on("change", function (e) {
                if (multiple) {
                    allBindings.selectedOptionsObject(_.filter(isObservable ? allBindings.options() : allBindings.options, setValue.bind(this, e.val)));
                }
                else {
                    allBindings.valueObject(_.find(isObservable ? allBindings.options() : allBindings.options, setValue.bind(this, e.val)));
                }
            }).trigger('change');
            if (open && multiple) {
                // TODO descomentar para un select abierto permanetemente y poner unos 100 milisegundos al setTimeout
                /*$element.select2("open");
                $element.on("select2-close", function (e) {
                    $element.select2("open");
                });*/
            }
        }, 0);

        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).select2('destroy');
        });
    }

    binding.init = init;

    return binding;
});