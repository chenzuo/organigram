namespace Organigram.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Organigram.Model;

    public class EmployeeController : ApiController
    {
        [Queryable]
        public IQueryable<Employee> GetEmployees()
        {
            return new List<Employee>
                       {
                           new Employee { Forename = "Fred" },
                           new Employee { Forename = "Bert" }
                       }.AsQueryable();
        }
    }
}