namespace Organigram.Specs.LibraryCandidates
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.ServiceModel;
    using System.Web.Http;
    using System.Web.Http.SelfHost;

    /// <summary>
    /// Provides HTTP API Testing functionality
    /// </summary>
    public class ApiTester : IDisposable
    {
        /// <summary>
        /// The HTTP server
        /// </summary>
        private HttpSelfHostServer server;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiTester"/> class.
        /// </summary>
        /// <param name="baseAddress">The base address.</param>
        /// <param name="authenticated">if set to <c>true</c> the client is authenticated; otherwise they are unauthenticated.</param>        
        public ApiTester(string baseAddress, bool authenticated)
        {
            if (string.IsNullOrWhiteSpace(baseAddress))
            {
                throw new ArgumentNullException("baseAddress");
            }

            this.Initialize(new Uri(baseAddress), authenticated);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiTester"/> class.
        /// </summary>
        /// <param name="baseAddress">The base address.</param>
        /// <param name="authenticated">if set to <c>true</c> the client is authenticated; otherwise they are unauthenticated.</param>
        public ApiTester(Uri baseAddress, bool authenticated)
        {
            this.Initialize(baseAddress, authenticated);
        }

        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <value>
        /// The client.
        /// </value>
        public HttpClient Client { get; private set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.server.CloseAsync().Wait();

            this.Client.Dispose();                
            this.server.Dispose();                
        }

        /// <summary>
        /// Configures the server configuration.
        /// </summary>
        /// <param name="serverConfiguration">The server configuration.</param>
        protected virtual void ConfigureServerConfiguration(HttpConfiguration serverConfiguration)
        {
        }

        /// <summary>
        /// Initializes an HTTP server and client.
        /// </summary>
        /// <param name="baseAddress">The base address.</param>
        /// <param name="authenticated">if set to <c>true</c> the client is authenticated; otherwise they are unauthenticated.</param>        
        private void Initialize(Uri baseAddress, bool authenticated)
        {
            if (baseAddress == null)
            {
                throw new ArgumentNullException("baseAddress");
            }

            var serverConfiguration = new HttpSelfHostConfiguration(baseAddress)
            {
                ClientCredentialType = HttpClientCredentialType.Windows
            };

            this.ConfigureServerConfiguration(serverConfiguration);

            this.server = new HttpSelfHostServer(serverConfiguration);
            this.server.OpenAsync().Wait();

            var clientHandler =
                authenticated ?
                    new HttpClientHandler { UseDefaultCredentials = true } :
                    new HttpClientHandler { Credentials = new NetworkCredential("Invalid", "User") };

            this.Client = new HttpClient(clientHandler) { BaseAddress = baseAddress };
        }
    }
}