using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
