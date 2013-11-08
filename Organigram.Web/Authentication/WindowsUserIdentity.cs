namespace Organigram.Web.Authentication
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    using Nancy.Security;

    class WindowsUserIdentity : IUserIdentity
    {
        private readonly string userName;

        private readonly IEnumerable<Claim> claims;

        public WindowsUserIdentity(string userName, IEnumerable<Claim> claims)
        {
            this.userName = userName;
            this.claims = claims;
        }

        public IEnumerable<string> Claims
        {
            get
            {
                return this.claims.Select(c => c.Value);
            }
        }

        public string UserName
        {
            get { return this.userName; }
        }
    }
}