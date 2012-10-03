using System;
using System.Globalization;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.OAuth.ChannelElements;

namespace LinkedIn
{
    internal static class ServiceDescriptions
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
    }
}