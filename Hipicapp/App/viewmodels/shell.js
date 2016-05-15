define(['core/authentication/authenticationBroker', 'core/authentication/securityContext',
    'core/broker', 'core/router', 'core/i18n', 'durandal/app']
    , function (authenticationBroker, securityContext, brokerUtils, router, i18n, app) {
        return {
            logout: function () {
                return authenticationBroker.logout().done(securityContext.clear).done(
                function () {
                    app.setRoot('viewmodels/home', 'entrance');
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
                    { route: '', title: 'Inicio', moduleId: 'viewmodels/home', nav: false, hash: '' },
                    { route: 'login', title: 'Acceso', moduleId: 'viewmodels/login', nav: false, hash: '#login' },
                    { route: 'athlete(/:id)', title: 'Perfil', moduleId: 'viewmodels/athlete', nav: false, hash: '#athlete' }
                ]).buildNavigationModel();

                return router.activate().then(function init() {
                    if (securityContext.isAuthenticated() !== undefined && securityContext.isAuthenticated() === true) {
                        router.navigateToAthlete();
                    }
                });
            }
        };
    });