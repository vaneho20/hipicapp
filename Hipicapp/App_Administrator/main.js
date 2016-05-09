requirejs.config({
    paths: {
        'text': '../Scripts/text',
        'i18next': '../Scripts/i18next',
        'i18n': '../Scripts/require-i18next',
        'async': '../Scripts/async',
        'durandal': '../Scripts/durandal',
        'plugins': '../Scripts/durandal/plugins',
        'transitions': '../Scripts/durandal/transitions'
    },
    i18next: {
        ns: "app",
        fallbackLng: "es",
        detectLngQS: "locale",
        lowerCaseLng: true,
        useCookie: false,
        resGetPath: "__lng__/__ns__.json",
        supportedLngs: {
            es: [
                "app"
            ]
        }
    }
});

define('jquery', function () { return jQuery; });
define('knockout', ko);
define('gmaps', ['async!http://maps.google.com/maps/api/js?sensor=false'],
    function () {
        console.log('Google maps loaded');
        return window.google.maps;
    });

define([
    "bindings/compareBinding", "bindings/datetimepickerValueBinding", "bindings/epochAfterBinding", "bindings/epochFutureBinding",
    "bindings/epochValueBinding", "bindings/fileuploadBinding", "bindings/imageHolderBinding", "bindings/popoverBinding",
    "core/authentication/authenticationBroker", "core/authentication/securityContext", "durandal/system", "durandal/app",
    "durandal/viewLocator", "durandal/binder", "i18n!nls", "core/router"
], function (compareBinding, datetimepickerValueBinding, epochAfterBinding, epochFutureBinding,
        epochValueBinding, fileuploadBinding, imageHolderBinding, popoverBinding, authenticationBroker, securityContext, system,
        app, viewLocator, binder, i18n, router) {
    // Fast click
    FastClick.attach(document.body);

    //>>excludeStart("build", true);
    system.debug(true);
    //>>excludeEnd("build");

    var i18NOptions = {
        detectFromHeaders: false,
        lng: window.navigator.userLanguage || window.navigator.language || 'es-ES',
        //lng: 'es-ES',
        fallbackLang: 'es',
        ns: 'app',
        resGetPath: '__lng__/__ns__.json',
        useCookie: false
    };

    // setup knockout
    // custom binding handlers
    ko.bindingHandlers.compare = compareBinding;
    ko.bindingHandlers.datetimepickerValue = datetimepickerValueBinding;
    ko.bindingHandlers.epochAfter = epochAfterBinding;
    ko.bindingHandlers.epochFuture = epochFutureBinding;
    ko.bindingHandlers.epochValue = epochValueBinding;
    ko.bindingHandlers.fileupload = fileuploadBinding;
    ko.bindingHandlers.imageHolder = imageHolderBinding;
    ko.bindingHandlers.popover = popoverBinding;

    app.title = 'Hipicapp';

    app.configurePlugins({
        router: true,
        dialog: true
    });

    /*ko.serverSideValidator.showValidationMessageHandler = function (elem, message) {
        console.log("ELEMENT::::" + elem);
        console.log("MESSAGE::::" + message);
    }*/
    app.start().then(function () {
        i18n.init(i18NOptions, function () {
            //Replace 'viewmodels' in the moduleId with 'views' to locate the view.
            //Look for partial views in a 'views' folder in the root.
            viewLocator.useConvention();

            //Call localization on view before binding...
            binder.binding = function (obj, view) {
                $(view).i18n();
            };

            binder.bindingComplete = function (obj, view) {
                //if (obj.currentEntity && ko.isObservable(obj.currentEntity) && obj.currentEntity().hasOwnProperty('id')) {
                if ($(view).find("form").length > 0) {
                    //ko.applyValidation(obj.currentEntity(), $(view).find("form")[0]);
                }
                //}
            };

            //Show the app by setting the root view model for our application with a transition.
            //app.adaptToDevice();

            // shell
            authenticationBroker.setup();
            if (securityContext.isAuthenticated()) {
                app.setRoot("viewmodels/shell", "entrance");
            } else {
                app.setRoot("viewmodels/login", "entrance");
            }
        });
    });
});