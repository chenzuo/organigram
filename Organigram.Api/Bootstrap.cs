namespace Organigram.Api
{
    using System.Web.Http;

    public class Bootstrap
    {
        public void Configure(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "{controller}/{id}",
                defaults: new { controller = "Fred", id = RouteParameter.Optional });

            config.EnableQuerySupport();
        }
    }
}