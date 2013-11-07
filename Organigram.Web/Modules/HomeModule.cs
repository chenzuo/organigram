namespace Organigram.Web.Modules
{
    using Nancy;

    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            this.Get["/"] = _ =>
                {
                    var model = new { UserName = this.Context.CurrentUser.UserName };
                    return View["home", model];
                };            
        }
    }
}