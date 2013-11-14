/// <reference path="../../Scripts/typings/jquery/jquery.d.ts" />
/// <reference path="../../Scripts/typings/knockout/knockout.d.ts" />

export class WelcomeViewModel {    
    public title: KnockoutObservable<string> = ko.observable('hello');
 
    public activate() {
        alert('welcome activated');        
        return true;
    }
}

return new WelcomeViewModel();