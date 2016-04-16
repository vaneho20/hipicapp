define(['core/authentication/authenticationBroker', 'core/authentication/securityContext',
    'core/broker', 'core/router', 'core/i18n', 'durandal/app']
    , function (authenticationBroker, securityContext, brokerUtils, router, i18n, app) {
        return {
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
                    { route: 'login', title: 'Login', moduleId: 'viewmodels/login', nav: false, hash: '#login' },
                    { route: 'register', title: 'Registro', moduleId: 'viewmodels/register', nav: false, hash: '#register' },
                    { route: 'dressage', title: 'Doma', moduleId: 'viewmodels/dressage', nav: false, hash: '#dressage' },
                    { route: 'jump', title: 'Salto', moduleId: 'viewmodels/jump', nav: false, hash: '#jump' }
                ]).buildNavigationModel();

                return router.activate().then(function init() {
                    if (securityContext.isAuthenticated() !== undefined && securityContext.isAuthenticated() === true) {
                    }
                });
            }
        };
    });