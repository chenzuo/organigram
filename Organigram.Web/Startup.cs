namespace Organigram.Web
{
    using Organigram.Api;

    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new OrganigramApiConfiguration();            
            app.UseWebApi(configuration).UseNancy();
        }
    }
}