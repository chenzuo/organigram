﻿namespace Organigram.Specs
{
    using System.Net.Http;

    using TechTalk.SpecFlow;

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

        [Given(@"I am authenticated")]
        public void GivenIAmAuthenticated()
        {
            this.authenticated = true;
        }
        
        [Given(@"I perform a (.*) request on (.*)")]
        public void GivenIPerformAGETRequestOnOrganigrams(string httpMethod, string urlPath)
        {
            using (var organigramApi = new OrganigramApiTester(this.authenticated))
            {
                this.response = organigramApi.Client.GetAsync(urlPath).Result;
            }
        }
        
        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBeNotAuthorized(int responseStatusCode)
        {
            Assert.Equal(responseStatusCode, (int)this.response.StatusCode);
        }
    }
}