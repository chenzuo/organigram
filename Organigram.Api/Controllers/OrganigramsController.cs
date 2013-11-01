namespace Organigram.Api.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using Organigram.Api.Attributes;
    using Organigram.Model;

    using Organigram = Organigram.Api.ApiModels.Organigram;

    public class OrganigramsController : ApiController
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>Collection of organigrams</returns>
        [OrganigramAuth(OrganigramPermission.OrganigramsView)]
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