using System.Configuration;
using LinkedIn;
using Microsoft.Web.WebPages.OAuth;

namespace MvcSample
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            string consumerKey = ConfigurationManager.AppSettings["LinkedInConsumerKey"];
            string consumerSecret = ConfigurationManager.AppSettings["LinkedInConsumerSecret"];

            OAuthWebSecurity.RegisterClient(
                new LinkedInOAuthClient(consumerKey, consumerSecret, new SessionAccessTokenStorage()), "LinkedIn",
                null);
        }
    }
}