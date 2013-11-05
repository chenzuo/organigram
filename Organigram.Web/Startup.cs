namespace Organigram.Web
{
    using Organigram.Api;

    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new OrganigramApiConfiguration();
            app.UseWebApi(configuration);

            app.UseHandler(async (request, response) =>
            {
                response.ContentType = "text/html";
                await response.WriteAsync("OWIN Hello World!!");
            });

            //app.Run(context =>
            //{
            //    context.Response.ContentType = "text/plain";
            //    return context.Response.WriteAsync("Hello " + ClaimsPrincipal.Current.Identity.Name + "!");
            //});
        }
    }
}