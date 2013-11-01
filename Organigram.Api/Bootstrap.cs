namespace Organigram.Api
{
    using System.Web.Http;

    using Microsoft.Practices.ServiceLocation;

    using Organigram.Model;

    using SimpleAuth.Claims;
    using SimpleAuth.Container;
    using SimpleAuth.Permissions;
    using SimpleAuth.WebApi.Handlers;

    public class Bootstrap
    {
        public void Configure(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "{controller}/{id}",
                defaults: new { controller = "Fred", id = RouteParameter.Optional });

            this.ConfigureSimpleAuth(config);

            config.EnableQuerySupport();
        }

        private void ConfigureSimpleAuth(HttpConfiguration config)
        {
            var container = new SimpleContainer();

            var permissionsResolver = new PermissionAuthorization<OrganigramPermission>(new OrganigramPermissionsResolver());
            container.RegisterInstance(typeof(IClaimsResolver), null, permissionsResolver);
            container.RegisterInstance(typeof(IClaimsAuthorizer), null, permissionsResolver);

            ServiceLocator.SetLocatorProvider(() => new SimpleContainerServiceLocatorProvider(container));

            config.MessageHandlers.Add(new SimpleAuthAuthenticationHandler());
        }        
    }
}