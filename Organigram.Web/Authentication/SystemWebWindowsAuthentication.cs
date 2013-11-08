namespace Organigram.Web.Authentication
{
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Web;

    using Nancy;

    /// <summary>
    /// Use Windows authentication
    /// Adapted from http://stackoverflow.com/a/19370741/248164. 
    /// This does tie us to System.Web, so a better approach needs to be investigated
    /// </summary>
    public class SystemWebWindowsAuthentication
    {
        public static Response Apply(NancyContext context)
        {
            var principal = GetPrincipal();

            if (principal == null || !principal.Identity.IsAuthenticated || string.IsNullOrWhiteSpace(principal.Identity.Name))
            {
                return HttpStatusCode.Unauthorized;
            }

            context.CurrentUser = new WindowsUserIdentity(principal.Identity.Name, principal.Claims);

            return null;
        }

        private static ClaimsPrincipal GetPrincipal()
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.User as ClaimsPrincipal;
            }

            return new WindowsPrincipal(WindowsIdentity.GetCurrent());
        }        
    }
}