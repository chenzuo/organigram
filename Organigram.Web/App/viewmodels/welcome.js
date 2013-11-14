define(["require", "exports"], function(require, exports) {
    var WelcomeViewModel = (function () {
        function WelcomeViewModel() {
            this.title = ko.observable('hello');
        }
        WelcomeViewModel.prototype.activate = function () {
            alert('welcome activated');
            return true;
        };
        return WelcomeViewModel;
    })();
    exports.WelcomeViewModel = WelcomeViewModel;

    return new WelcomeViewModel();
});
//# sourceMappingURL=welcome.js.map
