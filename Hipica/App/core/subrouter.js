define(['durandal/system', 'durandal/viewModel', 'durandal/plugins/router'], function (system, viewModel, router) {
    return function subRouter() {
        var subrouter = {}, defaultPage = 'default', navigationPath = '#/subroute/', modulePath = 'viewmodels/subroute/', inSubRoute = viewModel.activator();

        function activate(activationData) {
            if (activationData == undefined) {
                subrouter.inSubRoute(convertSplatToModuleId());
            } else {
                subrouter.inSubRoute(convertSplatToModuleId(activationData.splat));
            }

            router.activeItem.settings.areSameItem = function (currentItem, newItem, data) {
                if (currentItem != newItem) {
                    return false;
                }
                else {
                    subrouter.inSubRoute(convertSplatToModuleId(data.splat));
                    return true;
                }
            };
            return true;
        }

        function showPage(name) {
            return function () {
                router.navigateTo(subrouter.navigationPath + name);
                subrouter.inSubRoute(convertNameToModuleId(name));
            };
        }

        function isPageActive(name) {
            var moduleName = convertNameToModuleId(name);
            return ko.computed(function () {
                return subrouter.inSubRoute === moduleName;
            });
        }

        function convertNameToModuleId(name) {
            return subrouter.modulePath + name;
        }

        function convertSplatToModuleId(splat) {
            if (splat && splat.length > 0) {
                return convertNameToModuleId(splat[0]);
            }
            return convertNameToModuleId(subrouter.defaultPage);
        }

        subrouter.defaultPage = defaultPage;
        subrouter.navigationPath = navigationPath;
        subrouter.modulePath = modulePath;
        subrouter.inSubRoute = inSubRoute;
        subrouter.activate = activate;
        subrouter.showPage = showPage;
        subrouter.isPageActive = isPageActive;

        return subrouter;
    };

    //return subRouter;

    //#region Internal Methods

    //#endregion
});