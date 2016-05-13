/* global define: false, location: false */
define([
    "durandal/app", "core/frontPage"
], function appDecorator(app, frontPage) {
    function urmShowFrontPage(obj, activationData, context) {
        return frontPage.show(obj, activationData, context);
    }

    app.urmShowFrontPage = urmShowFrontPage;

    return app;
});