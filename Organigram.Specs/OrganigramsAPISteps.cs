using System;
using TechTalk.SpecFlow;

namespace Organigram.Specs
{
    using System.Net.Http;

    using Xunit;

    [Binding]
    public class OrganigramsAPISteps
    {
        private bool authenticated;

        HttpResponseMessage response;

        [Given(@"I am not authenticated")]
        public void GivenIAmNotAuthenticated()
        {
            this.authenticated = false;
        }
        
        [Given(@"I perform a (.*) request on (.*)")]
        public void GivenIPerformAGETRequestOnOrganigrams(string httpMethod, string urlPath)
        {
            using (var client = OrganigramHttpClientFactory.Create())
            {
                this.response = client.GetAsync(urlPath).Result;
            }
        }
        
        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBeNotAuthorized(int p0)
        {
            Assert.Equal(p0, (int)this.response.StatusCode);
        }
    }
}
