namespace Organigram.Api
{
    using System.Collections.Generic;

    using Organigram.Model;

    using SimpleAuth.Permissions;

    internal class OrganigramPermissionsResolver : IPermissionsResolver<OrganigramPermission>
    {
        public IEnumerable<OrganigramPermission> GetPermissions(string name)
        {
            return new List<OrganigramPermission> { OrganigramPermission.OrganigramsView };
        }
    }
}