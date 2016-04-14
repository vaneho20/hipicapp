define(['core/authentication/authenticationBroker', 'core/authentication/securityContext',
    'core/broker', 'core/router', 'core/i18n', 'durandal/app']
    , function (authenticationBroker, securityContext, brokerUtils, router, i18n, app) {
        return {
            logout: function () {
                return authenticationBroker.logout().done(securityContext.clear).done(
                function () {
                    app.setRoot('viewmodels/login', 'entrance');
                    router.navigate("");
                });
            },
            isLoading: ko.computed(function () {
                return brokerUtils.requestCount > 0 || router.isNavigating();
            }),
            router: router,
            i18n: i18n,
            search: function () {
                //It's really easy to show a message box.
                //You can add custom options too. Also, it returns a promise for the user's response.
                app.showMessage('Search not yet implemented...');
            },
            activate: function () {
                router.map([
                    { route: '', title: 'Home', moduleId: 'viewmodels/home', nav: false, hash: '' },
                    { route: 'register', title: 'Registro', moduleId: 'viewmodels/register', nav: false, hash: '#register' },
                    { route: 'athlete', title: 'Atleta', moduleId: 'viewmodels/athlete', nav: true, hash: '#athlete' },
                    { route: 'horses', title: 'Caballos', moduleId: 'viewmodels/horses', nav: true, hash: '#horses' },
                    { route: 'competitions', title: 'Concursos', moduleId: 'viewmodels/competitions', nav: true, hash: '#competitions' },
                ]).buildNavigationModel();

                return router.activate().then(function init() {
                    if (securityContext.isAuthenticated() !== undefined && securityContext.isAuthenticated() === true) {
                    }
                });
            }
        };
    });