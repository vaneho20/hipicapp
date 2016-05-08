define(['core/authentication/authenticationBroker', 'core/authentication/securityContext',
    'core/broker', 'core/router', 'core/i18n', 'durandal/app']
    , function (authenticationBroker, securityContext, brokerUtils, router, i18n, app) {
        return {
            logout: function () {
                return authenticationBroker.logout().done(securityContext.clear).done(
                function () {
                    router.reloadCurrentLocation()
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
                    { route: 'login', title: 'Login', moduleId: 'viewmodels/login', nav: false, hash: '#login' },
                    { route: 'athletes', title: 'Atletas', moduleId: 'viewmodels/athletes', nav: true, hash: '#athletes', icon: "fa fa-users" },
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
                    //{ route: 'specialties', title: 'Disciplinas', moduleId: 'viewmodels/specialties', nav: true, hash: '#specialties', icon: "fa fa-certificate" },
                    //{ route: 'specialty(/:id)', title: 'Disciplina', moduleId: 'viewmodels/specialty', nav: false, hash: '#specialty' },
                    { route: 'judges', title: 'Jueces', moduleId: 'viewmodels/judges', nav: true, hash: '#judges', icon: "fa fa-balance-scale" },
                    { route: 'judge(/:id)', title: 'Juez', moduleId: 'viewmodels/judge', nav: false, hash: '#judge' },
                    { route: 'judge(/:id/images)', title: 'Foto', moduleId: 'viewmodels/judgeImages', nav: false, hash: '#judge' },
                    { route: 'users', title: 'Usuarios', moduleId: 'viewmodels/users', nav: true, hash: '#users', icon: "fa fa-lock" },
                    { route: 'user(/:id)', title: 'Usuario', moduleId: 'viewmodels/user', nav: false, hash: '#user' }
                ]).buildNavigationModel();

                return router.activate().then(function init() {
                    if (securityContext.isAuthenticated() !== undefined && securityContext.isAuthenticated() === true) {
                    }
                });
            },
            attached: function () {
                var URL = window.location,
                    $BODY = $('body'),
                    $MENU_TOGGLE = $('#menu_toggle'),
                    $SIDEBAR_MENU = $('#sidebar-menu'),
                    $SIDEBAR_FOOTER = $('.sidebar-footer'),
                    $LEFT_COL = $('.left_col'),
                    $RIGHT_COL = $('.right_col'),
                    $NAV_MENU = $('.nav_menu'),
                    $FOOTER = $('footer');

                if (securityContext.isAuthenticated() !== undefined && securityContext.isAuthenticated() === true) {
                    $BODY.css("background", "#2A3F54");
                } else {
                    $BODY.css("background", "#F7F7F7");
                }
                var setContentHeight = function () {
                    // reset height
                    $RIGHT_COL.css('min-height', $(window).height());

                    var bodyHeight = $BODY.height(),
                        leftColHeight = $LEFT_COL.eq(1).height() + $SIDEBAR_FOOTER.height(),
                        contentHeight = bodyHeight < leftColHeight ? leftColHeight : bodyHeight;

                    // normalize content
                    contentHeight -= $NAV_MENU.height() + $FOOTER.height();

                    $RIGHT_COL.css('min-height', contentHeight);
                };

                $SIDEBAR_MENU.find('a').on('click', function (ev) {
                    var $li = $(this).parent();

                    if ($li.is('.active')) {
                        $li.removeClass('active');
                        $('ul:first', $li).slideUp(function () {
                            setContentHeight();
                        });
                    } else {
                        // prevent closing menu if we are on child menu
                        if (!$li.parent().is('.child_menu')) {
                            $SIDEBAR_MENU.find('li').removeClass('active');
                            $SIDEBAR_MENU.find('li ul').slideUp();
                        }

                        $li.addClass('active');

                        $('ul:first', $li).slideDown(function () {
                            setContentHeight();
                        });
                    }
                });

                // toggle small or large menu
                $MENU_TOGGLE.on('click', function () {
                    if ($BODY.hasClass('nav-md')) {
                        $BODY.removeClass('nav-md').addClass('nav-sm');
                        $LEFT_COL.removeClass('scroll-view').removeAttr('style');

                        if ($SIDEBAR_MENU.find('li').hasClass('active')) {
                            $SIDEBAR_MENU.find('li.active').addClass('active-sm').removeClass('active');
                        }
                    } else {
                        $BODY.removeClass('nav-sm').addClass('nav-md');

                        if ($SIDEBAR_MENU.find('li').hasClass('active-sm')) {
                            $SIDEBAR_MENU.find('li.active-sm').addClass('active').removeClass('active-sm');
                        }
                    }

                    setContentHeight();
                });

                // check active menu
                $SIDEBAR_MENU.find('a[href="' + URL + '"]').parent('li').addClass('current-page');

                $SIDEBAR_MENU.find('a').filter(function () {
                    return this.href == URL;
                }).parent('li').addClass('current-page').parents('ul').slideDown(function () {
                    setContentHeight();
                }).parent().addClass('active');

                // recompute content when resizing
                $(window).smartresize(function () {
                    setContentHeight();
                });
            }
        };
    });