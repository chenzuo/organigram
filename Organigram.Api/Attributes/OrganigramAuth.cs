namespace Organigram.Api.Attributes
{
    using Organigram.Model;

    using SimpleAuth.WebApi.Attributes;

    public class OrganigramAuth : SimpleAuthPermissionAttribute
    {
        public OrganigramAuth(OrganigramPermission permission) : base(permission)
        {
        }
    }
}