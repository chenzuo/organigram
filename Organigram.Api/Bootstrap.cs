namespace Organigram.Api
{
    using System.Web.Http;

    using CommonServiceLocator.NinjectAdapter.Unofficial;

    using Microsoft.Practices.ServiceLocation;

    using Ninject;

    using Organigram.Model;

    using SimpleAuth.Claims;    
    using SimpleAuth.Permissions;
    using SimpleAuth.WebApi.Handlers;

    using WebApiContrib.IoC.Ninject;

    public class OrganigramApiConfiguration : HttpConfiguration
    {
        public OrganigramApiConfiguration()
        {
            this.ConfigureRoutes();

            IKernel kernel = new StandardKernel();
            this.ConfigureIoC(kernel);
            this.ConfigureSimpleAuth(kernel);

            this.EnableQuerySupport();
        }

        private void ConfigureRoutes()
        {
            this.MapHttpAttributeRoutes();

            this.Routes.MapHttpRoute(
               name: "API Default",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { controller = "Organigrams", id = RouteParameter.Optional });
        }

        // See https://github.com/WebApiContrib/WebApiContrib.IoC.Ninject
        private void ConfigureIoC(IKernel kernel)
        {
            this.DependencyResolver = new NinjectResolver(kernel);
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(kernel));
        }

        private void ConfigureSimpleAuth(IKernel kernel)
        {
            var permissionsResolver = new PermissionAuthorization<OrganigramPermission>(new OrganigramPermissionsResolver());
            kernel.Bind<IClaimsResolver>().ToMethod(context => permissionsResolver);
            kernel.Bind<IClaimsAuthorizer>().ToMethod(context => permissionsResolver);

            this.MessageHandlers.Add(new SimpleAuthAuthenticationHandler());
        }
    }

    public class Bootstrap
    {
        public void Configure(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "{controller}/{id}",
                defaults: new { controller = "Fred", id = RouteParameter.Optional });

            IKernel kernel = new StandardKernel();           
            this.ConfigureIoC(config, kernel);
            this.ConfigureSimpleAuth(config, kernel);

            config.EnableQuerySupport();
        }

        // See https://github.com/WebApiContrib/WebApiContrib.IoC.Ninject
        private void ConfigureIoC(HttpConfiguration config, IKernel kernel)
        {           
            config.DependencyResolver = new NinjectResolver(kernel);
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(kernel));
        }

        private void ConfigureSimpleAuth(HttpConfiguration config, IKernel kernel)
        {
            var permissionsResolver = new PermissionAuthorization<OrganigramPermission>(new OrganigramPermissionsResolver());
            kernel.Bind<IClaimsResolver>().ToMethod(context => permissionsResolver);
            kernel.Bind<IClaimsAuthorizer>().ToMethod(context => permissionsResolver);

            config.MessageHandlers.Add(new SimpleAuthAuthenticationHandler());
        }
    }
}