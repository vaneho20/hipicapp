define(['core/authentication/authenticationBroker', 'core/authentication/securityContext',
    'core/broker', 'core/router', 'core/i18n', 'durandal/app']
    , function (authenticationBroker, securityContext, brokerUtils, router, i18n, app) {
        return {
            logout: function () {
                return authenticationBroker.logout().done(securityContext.clear).done(
                function () {
                    app.setRoot('viewmodels/home', 'entrance');
                    router.navigate("");
                    router.reloadCurrentLocation();
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
                    { route: 'specialty/:id', title: 'Disciplina', moduleId: 'viewmodels/specialty', nav: false, hash: '#specialty' },
                    { route: 'specialty/:id/athletes', title: 'Atletas', moduleId: 'viewmodels/athletes', nav: true },
                    { route: 'specialty/:id/competitions', title: 'Concursos', moduleId: 'viewmodels/competitions', nav: true },
                    { route: 'specialty/:id/horses', title: 'Caballos', moduleId: 'viewmodels/horses', nav: true },
                    { route: 'specialty/:id/judges', title: 'Jueces', moduleId: 'viewmodels/judges', nav: true },
                    { route: 'athlete(/:id)', title: 'Perfil', moduleId: 'viewmodels/athlete', nav: false, hash: '#athlete' }
                ]).buildNavigationModel();

                return router.activate().then(function init() {
                    if (securityContext.isAuthenticated() !== undefined && securityContext.isAuthenticated() === true) {
                    }
                });
            }
        };
    });