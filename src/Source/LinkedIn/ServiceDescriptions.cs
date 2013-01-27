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
        /// Force the user Authorization screen
        /// </summary>
        public static readonly ServiceProviderDescription Authorize = CreateServiceDescription(Constants.AuthorizeTokenMethod);

        /// <summary>
        /// Authenticate, only showing the Authorize screen when from the user is needed
        /// </summary>
        public static readonly ServiceProviderDescription Authenticate = CreateServiceDescription(Constants.AuthenticateMethod);

        private static ServiceProviderDescription CreateServiceDescription(string tokenMethod)
        {
            return new ServiceProviderDescription
                       {
                           RequestTokenEndpoint = new MessageReceivingEndpoint(
                               String.Format(CultureInfo.InvariantCulture, "{0}{1}", Constants.ApiOAuthBaseUrl, Constants.RequestTokenResourceName),
                               HttpDeliveryMethods.AuthorizationHeaderRequest | HttpDeliveryMethods.GetRequest),
                           UserAuthorizationEndpoint = new MessageReceivingEndpoint(
                               String.Format(CultureInfo.InvariantCulture, "{0}{1}", Constants.ApiOAuthBaseUrl, tokenMethod),
                               HttpDeliveryMethods.AuthorizationHeaderRequest | HttpDeliveryMethods.GetRequest),
                           AccessTokenEndpoint = new MessageReceivingEndpoint(
                               String.Format(CultureInfo.InvariantCulture, "{0}{1}", Constants.ApiOAuthBaseUrl, Constants.AccessTokenResourceName),
                               HttpDeliveryMethods.AuthorizationHeaderRequest | HttpDeliveryMethods.GetRequest),
                           TamperProtectionElements = new ITamperProtectionChannelBindingElement[] { new HmacSha1SigningBindingElement() }
                       };
        }

        /// <summary>
        /// Gets a LinkedIn ServiceProviderDescription requesting additional permissions from the user. 
        /// </summary>
        /// <remarks>Doesn't force Authorize screen</remarks>
        /// <param name="scopefields">The additional permissions to request from the user.</param>
        /// <returns>Returns a service description for LinkedIn with additional scope attached.</returns>
        public static ServiceProviderDescription GetLinkedInServiceDescriptionWithAdditionalScope(
            params ScopePermission[] scopefields)
        {
            return GetLinkedInServiceDescriptionWithAdditionalScope(false, scopefields);
        }


        /// <summary>
        /// Gets a LinkedIn ServiceProviderDescription requesting additional permissions from the user.
        /// </summary>
        /// <param name="forceAuthorize">Force an authorize regardless if permission is already given by the user for this application</param>
        /// <param name="scopefields">The additional permissions to request from the user.</param>
        /// <returns>Returns a service description for LinkedIn with additional scope attached.</returns>
        public static ServiceProviderDescription GetLinkedInServiceDescriptionWithAdditionalScope(bool forceAuthorize, params ScopePermission[] scopefields)
        {
            if (scopefields == null || scopefields.Length == 0)
            {
                return forceAuthorize ? Authorize : Authenticate;
            }

            var scopestrings = scopefields.Select(i => EnumHelper.GetDescription(i));

            var urlparam = string.Join("+", scopestrings);

            return new ServiceProviderDescription
            {
                RequestTokenEndpoint = new MessageReceivingEndpoint(
                    String.Format(CultureInfo.InvariantCulture, "{0}{1}?scope={2}", Constants.ApiOAuthBaseUrl, Constants.RequestTokenResourceName, urlparam),
                    HttpDeliveryMethods.AuthorizationHeaderRequest | HttpDeliveryMethods.GetRequest),
                UserAuthorizationEndpoint = new MessageReceivingEndpoint(
                    String.Format(CultureInfo.InvariantCulture, "{0}{1}", Constants.ApiOAuthBaseUrl, forceAuthorize? Constants.AuthorizeTokenMethod : Constants.AuthenticateMethod),
                    HttpDeliveryMethods.AuthorizationHeaderRequest | HttpDeliveryMethods.GetRequest),
                AccessTokenEndpoint = new MessageReceivingEndpoint(
                    String.Format(CultureInfo.InvariantCulture, "{0}{1}", Constants.ApiOAuthBaseUrl, Constants.AccessTokenResourceName),
                    HttpDeliveryMethods.AuthorizationHeaderRequest | HttpDeliveryMethods.GetRequest),
                TamperProtectionElements = new ITamperProtectionChannelBindingElement[] { new HmacSha1SigningBindingElement() }
            };
        }
    }
}