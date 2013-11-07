namespace Organigram.Web
{
    using Nancy;
    using Nancy.Conventions;

    public class OrganigramBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            Conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("App"));
        }
    }
}