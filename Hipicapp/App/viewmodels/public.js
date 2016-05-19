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
                    { route: '', title: 'Inicio', moduleId: 'viewmodels/home', nav: false, hash: '' },
                    { route: 'login', title: 'Acceso', moduleId: 'viewmodels/login', nav: false, hash: '#login' },
                    { route: 'register', title: 'Registro', moduleId: 'viewmodels/register', nav: false, hash: '#register' },
                    { route: 'reset-password', title: 'Reestablecer contraseña', moduleId: 'viewmodels/passwordreset', nav: false, hash: '#reset-password' },
                    { route: 'update-password/:key', title: 'Actualizar contraseña', moduleId: 'viewmodels/updatepassword', nav: false, hash: '#update-password' },
                    { route: 'specialty/:id', title: 'Disciplina', moduleId: 'viewmodels/specialty', nav: false, hash: '#specialty' },
                    { route: 'specialty/:id/athletes', title: 'Jinetes', moduleId: 'viewmodels/athletes', nav: true },
                    { route: 'specialty/:id/competitions', title: 'Concursos', moduleId: 'viewmodels/competitions', nav: true },
                    { route: 'specialty/:id/horses', title: 'Caballos', moduleId: 'viewmodels/horses', nav: true },
                    { route: 'specialty/:id/judges', title: 'Jueces', moduleId: 'viewmodels/judges', nav: true },
                    { route: 'athlete(/:id)', title: 'Ficha', moduleId: 'viewmodels/athlete', nav: false, hash: '#athlete' },
                    { route: 'competition/:id', title: 'Concurso', moduleId: 'viewmodels/competition', nav: false, hash: '#competition' },
                    { route: 'competition/:id/horses', title: 'Caballos', moduleId: 'viewmodels/competitionHorses', nav: false },
                    { route: 'competition/:id/judges', title: 'Jueces', moduleId: 'viewmodels/competitionJudges', nav: false },
                    { route: 'horse/:id', title: 'Caballo', moduleId: 'viewmodels/horse', nav: false, hash: '#horse' },
                    { route: 'judge/:id', title: 'Juez', moduleId: 'viewmodels/judge', nav: false, hash: '#judge' }
                ]).buildNavigationModel();

                return router.activate().then(function init() {
                    if (securityContext.isAuthenticated() !== undefined && securityContext.isAuthenticated() === true) {
                    }
                });
            }
        };
    });