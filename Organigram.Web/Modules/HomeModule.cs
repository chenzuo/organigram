namespace Organigram.Web.Modules
{
    using Nancy;

    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            this.Get["/"] = _ =>
                {
                    var model = new { title = "Hello World!!" };
                    return View["home", model];
                };            
        }
    }
}