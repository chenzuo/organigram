/// <reference path="../../Scripts/typings/durandal/durandal.d.ts" />

import router = require('plugins/router');

export class shell {

    public activate() {

        router.map([
            { route: '', title: 'Welcome', moduleId: 'viewmodels/welcome', nav: true }
        ]).buildNavigationModel();

        return router.activate();
    }
}

return new shell();