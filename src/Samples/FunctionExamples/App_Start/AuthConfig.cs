using Microsoft.AspNet.Membership.OpenAuth;

namespace FunctionalTests.App_Start
{
    internal static class AuthConfig
    {
        public static void RegisterOpenAuth()
        {
            OpenAuth.AuthenticationClients.Add("Linked In", () => ServiceLookup.GetLinkedInService());
        }
    }
}
