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
                    { route: '', title: 'Welcome', moduleId: 'viewmodels/welcome', nav: false, hash: '' },
                    { route: 'athletes', title: 'Atletas', moduleId: 'viewmodels/athletes', nav: true, hash: '#athletes' },
                    { route: 'athlete(/:id)', title: 'Atleta', moduleId: 'viewmodels/athlete', nav: false, hash: '#athlete' },
                    { route: 'athlete/:id/images', title: 'Foto', moduleId: 'viewmodels/athleteImages', nav: false },
                    { route: 'athlete/:id/horses', title: 'Caballos', moduleId: 'viewmodels/athleteHorses', nav: false, hash: '#horses' },
                    { route: 'athlete/:athleteId/horse(/:horseId)', title: 'Caballo', moduleId: 'viewmodels/horse', nav: false },
                    { route: 'athlete/:athleteId/horse/:horseId/images', title: 'Foto', moduleId: 'viewmodels/horseImages', nav: false },
                    { route: 'categories', title: 'Categorías', moduleId: 'viewmodels/competitionCategories', nav: true, hash: '#categories', icon: "fa fa-sitemap" },
                    { route: 'category(/:id)', title: 'Categoría', moduleId: 'viewmodels/competitionCategory', nav: false, hash: '#category' },
                    { route: 'competitions', title: 'Concursos', moduleId: 'viewmodels/competitions', nav: true, hash: '#competitions', icon: "fa fa-trophy" },
                    { route: 'competition(/:id)', title: 'Concurso', moduleId: 'viewmodels/competition', nav: false, hash: '#competition' },
                    { route: 'competition/:id/judges', title: 'Jueces', moduleId: 'viewmodels/competitionJudges', nav: false },
                    { route: 'judges', title: 'Jueces', moduleId: 'viewmodels/judges', nav: true, hash: '#judges', icon: "fa fa-balance-scale" },
                    { route: 'judge(/:id)', title: 'Juez', moduleId: 'viewmodels/judge', nav: false, hash: '#judge' },
                    { route: 'judge(/:id/images)', title: 'Foto', moduleId: 'viewmodels/judgeImages', nav: false, hash: '#judge' },
                    { route: 'specialties', title: 'Especialidades', moduleId: 'viewmodels/specialties', nav: true, hash: '#specialties', icon: "fa fa-certificate" },
                    { route: 'specialty(/:id)', title: 'Especialidad', moduleId: 'viewmodels/specialty', nav: false, hash: '#specialty' },
                    { route: 'users', title: 'Usuarios', moduleId: 'viewmodels/users', nav: true, hash: '#users', icon: "fa fa-users" },
                    { route: 'user(/:id)', title: 'Usuario', moduleId: 'viewmodels/user', nav: false, hash: '#user' }
                ]).buildNavigationModel();

                return router.activate().then(function init() {
                    if (securityContext.isAuthenticated() !== undefined && securityContext.isAuthenticated() === true) {
                    }
                });
            }
        };
    });