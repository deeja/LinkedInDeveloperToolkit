using System;
using System.Configuration;
using DotNetOpenAuth.AspNet.Clients;
using DotNetOpenAuth.OAuth;
using LinkedIn;

namespace FunctionalTests
{
    /// <summary>
    ///   A terrible ServiceLookup Locator. Don't do it this way. Use an IoC container.
    /// </summary>
    public class ServiceLookup
    {
        private static readonly string ConsumerKey = ConfigurationManager.AppSettings["LinkedInConsumerKey"];
        private static readonly string ConsumerSecret = ConfigurationManager.AppSettings["LinkedInConsumerSecret"];

        public const string ProviderName = "LinkedIn";

        [Obsolete("Because this style of thinking is a terrible idea")]
        public static LinkedInOAuthClient GetLinkedInService()
        {
            return new LinkedInOAuthClient(new CookieAccessTokenStorage(ConsumerSecret), new DotNetOpenAuthWebConsumer(ServiceDescriptions.LinkedInServiceDescription,new InMemoryOAuthTokenManager(ConsumerKey, ConsumerSecret)));
        }
    }
}