using System.Configuration;
using DotNetOpenAuth.AspNet.Clients;
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

            LinkedInOAuthClient linkedInOAuthClient = new LinkedInOAuthClient(new CookieAccessTokenStorage(consumerSecret),
                new DotNetOpenAuthWebConsumer(ServiceDescriptions.Authenticate,
                    new InMemoryOAuthTokenManager(consumerKey, consumerSecret)));

            ShouldReallyBeAnIocContainerAndDontUseServiceLocators.LinkedInService = linkedInOAuthClient;

            OAuthWebSecurity.RegisterClient(linkedInOAuthClient, "LinkedIn", null);
        }
    }
}