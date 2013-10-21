namespace Organigram.Specs.Helpers
{
    using System.Web.Http;

    using Organigram.Api;
    using Organigram.Specs.LibraryCandidates;

    public class OrganigramApiTester : ApiTester
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrganigramApiTester"/> class.
        /// </summary>
        /// <param name="authenticated">if set to <c>true</c> the client is authenticated; otherwise they are unauthenticated.</param>
        public OrganigramApiTester(bool authenticated) : base("http://localhost:9876", authenticated)
        {
        }

        /// <summary>
        /// Configures the server configuration.
        /// </summary>
        /// <param name="serverConfiguration">The server configuration.</param>
        protected override void ConfigureServerConfiguration(HttpConfiguration serverConfiguration)
        {
            new Bootstrap().Configure(serverConfiguration);
        }
    }
}