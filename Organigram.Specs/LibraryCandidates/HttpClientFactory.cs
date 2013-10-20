namespace Organigram.Specs.LibraryCandidates
{
    using System;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.SelfHost;

    public static class HttpClientFactory
    {
        public static HttpClient Create(string baseAddress, Action<HttpConfiguration> configure)
        {
            if (string.IsNullOrWhiteSpace(baseAddress))
            {
                throw new ArgumentNullException(baseAddress);
            }

            return Create(new Uri(baseAddress), configure);
        }

        public static HttpClient Create(Uri baseAddress, Action<HttpConfiguration> configure)
        {
            if (baseAddress == null)
            {
                throw new ArgumentNullException("baseAddress");
            }

            if (configure == null)
            {
                throw new ArgumentNullException("configure");
            }

            var config = new HttpSelfHostConfiguration(baseAddress);
            configure(config);
            var server = new HttpSelfHostServer(config);
            var client = new HttpClient(server);
            try
            {
                client.BaseAddress = baseAddress;
                return client;
            }
            catch
            {
                client.Dispose();
                throw;
            }
        }
    }
}