using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinkedIn.Mvc;
using Microsoft.Web.WebPages.OAuth;
using MvcSample.Models;

namespace MvcSample
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166


            OAuthWebSecurity.RegisterClient(new LinkedInService("hs202okb7yph", "ZOenHuu0saj1ZWY9"),"Linked In",null);

            OAuthWebSecurity.RegisterLinkedInClient("hs202okb7yph", "ZOenHuu0saj1ZWY9","Linked in OEM");
            OAuthWebSecurity.RegisterGoogleClient("Google");
        }
    }
}
