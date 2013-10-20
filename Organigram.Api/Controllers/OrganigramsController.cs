namespace Organigram.Api.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using Organigram.Api.ApiModels;

    public class OrganigramsController : ApiController
    {
        public IEnumerable<Organigram> Get()
        {
            return new List<Organigram>
                {
                    new Organigram { Id = 1 },
                    new Organigram { Id = 2 }
                };
        }
    }
}
