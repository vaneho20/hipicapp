/* global $: false, define: false */
define(function editableBinding() {
    "use strict";

    var binding = {};

    function init(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var attrs = allBindingsAccessor().editable;
        var toggle = attrs.toggle, savemethod = attrs.savemethod, display = attrs.display,
            defaultValue = attrs.defaultValue, savenochange = attrs.savenochange ? attrs.savenochange : false;
        setTimeout(function doAfterBinding() {
            $.fn.editable.defaults.mode = 'inline';
            $(element).editable('destroy').editable({
                type: 'text',
                toggle: toggle ? toggle : 'click',
                savenochange : savenochange,
                url: function (editParams) {
                    var newDescription = editParams.value;

                    var deferredObj = new $.Deferred();

                    function save(callback) {
                        savemethod(newDescription);
                        setTimeout(callback, 1000);
                    }

                    save(function () {
                        deferredObj.resolve();
                    });

                    return deferredObj.promise();
                },
                display: display,
                value: defaultValue,
                defaultValue: defaultValue
            });
        }, 0);
    }

    binding.init = init;

    return binding;
});