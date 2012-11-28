using System;
using System.Globalization;
using System.Linq;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.OAuth.ChannelElements;
using LinkedIn.Utility;

namespace LinkedIn
{
    public static class ServiceDescriptions
    {
        /// <summary>
        /// The description of LinkedIn's OAuth protocol URIs.
        /// </summary>
        public static readonly ServiceProviderDescription LinkedInAuthenticationServiceDescription = new ServiceProviderDescription
                                                                                                         {
                                                                                                             RequestTokenEndpoint = new MessageReceivingEndpoint(
                                                                                                                 String.Format(CultureInfo.InvariantCulture, "{0}{1}", Constants.ApiOAuthBaseUrl, Constants.RequestTokenResourceName),
                                                                                                                 HttpDeliveryMethods.AuthorizationHeaderRequest | HttpDeliveryMethods.GetRequest),
                                                                                                             UserAuthorizationEndpoint = new MessageReceivingEndpoint(
                                                                                                                 String.Format(CultureInfo.InvariantCulture, "{0}{1}", Constants.ApiOAuthBaseUrl, Constants.AuthenticateMethod),
                                                                                                                 HttpDeliveryMethods.AuthorizationHeaderRequest | HttpDeliveryMethods.GetRequest),
                                                                                                             AccessTokenEndpoint = new MessageReceivingEndpoint(
                                                                                                                 String.Format(CultureInfo.InvariantCulture, "{0}{1}", Constants.ApiOAuthBaseUrl, Constants.AccessTokenResourceName),
                                                                                                                 HttpDeliveryMethods.AuthorizationHeaderRequest | HttpDeliveryMethods.GetRequest),
                                                                                                             TamperProtectionElements = new ITamperProtectionChannelBindingElement[] { new HmacSha1SigningBindingElement() }
                                                                                                         };

        /// <summary>
        /// The description of LinkedIn's OAuth protocol URIs.
        /// </summary>
        public static readonly ServiceProviderDescription LinkedInServiceDescription = new ServiceProviderDescription
                                                                                           {
                                                                                               RequestTokenEndpoint = new MessageReceivingEndpoint(
                                                                                                   String.Format(CultureInfo.InvariantCulture, "{0}{1}", Constants.ApiOAuthBaseUrl, Constants.RequestTokenResourceName),
                                                                                                   HttpDeliveryMethods.AuthorizationHeaderRequest | HttpDeliveryMethods.GetRequest),
                                                                                               UserAuthorizationEndpoint = new MessageReceivingEndpoint(
                                                                                                   String.Format(CultureInfo.InvariantCulture, "{0}{1}", Constants.ApiOAuthBaseUrl, Constants.AuthorizeTokenMethod),
                                                                                                   HttpDeliveryMethods.AuthorizationHeaderRequest | HttpDeliveryMethods.GetRequest),
                                                                                               AccessTokenEndpoint = new MessageReceivingEndpoint(
                                                                                                   String.Format(CultureInfo.InvariantCulture, "{0}{1}", Constants.ApiOAuthBaseUrl, Constants.AccessTokenResourceName),
                                                                                                   HttpDeliveryMethods.AuthorizationHeaderRequest | HttpDeliveryMethods.GetRequest),
                                                                                               TamperProtectionElements = new ITamperProtectionChannelBindingElement[] { new HmacSha1SigningBindingElement() }
                                                                                           };


        /// <summary>
        /// Gets a LinkedIn ServiceProviderDescription requesting additional permissions from the user.
        /// </summary>
        /// <param name="scopefields">The additional permissions to request from the user.</param>
        /// <returns>Returns a service description for LinkedIn with additional scope attached.</returns>
        public static ServiceProviderDescription GetLinkedInServiceDescriptionWithAdditionalScope(params ScopePermission[] scopefields)
        {
            if (scopefields == null || scopefields.Length == 0)
                return LinkedInServiceDescription;

            var scopestrings = scopefields.Select(i => EnumHelper.GetDescription(i));

            var urlparam = string.Join("+", scopestrings);

            return new ServiceProviderDescription
            {
                RequestTokenEndpoint = new MessageReceivingEndpoint(
                    String.Format(CultureInfo.InvariantCulture, "{0}{1}?scope={2}", Constants.ApiOAuthBaseUrl, Constants.RequestTokenResourceName, urlparam),
                    HttpDeliveryMethods.AuthorizationHeaderRequest | HttpDeliveryMethods.GetRequest),
                UserAuthorizationEndpoint = new MessageReceivingEndpoint(
                    String.Format(CultureInfo.InvariantCulture, "{0}{1}", Constants.ApiOAuthBaseUrl, Constants.AuthorizeTokenMethod),
                    HttpDeliveryMethods.AuthorizationHeaderRequest | HttpDeliveryMethods.GetRequest),
                AccessTokenEndpoint = new MessageReceivingEndpoint(
                    String.Format(CultureInfo.InvariantCulture, "{0}{1}", Constants.ApiOAuthBaseUrl, Constants.AccessTokenResourceName),
                    HttpDeliveryMethods.AuthorizationHeaderRequest | HttpDeliveryMethods.GetRequest),
                TamperProtectionElements = new ITamperProtectionChannelBindingElement[] { new HmacSha1SigningBindingElement() }
            };
        }
    }
}