define(["require", "exports", 'plugins/router'], function(require, exports, __router__) {
    var router = __router__;

    var shell = (function () {
        function shell() {
        }
        shell.prototype.activate = function () {
            router.map([
                { route: '', title: 'Welcome', moduleId: 'viewmodels/welcome', nav: true }
            ]).buildNavigationModel();

            return router.activate();
        };
        return shell;
    })();
    exports.shell = shell;

    return new shell();
});
//# sourceMappingURL=shell.js.map
