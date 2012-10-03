//-----------------------------------------------------------------------
// <copyright file="OAuthAuthorization.cs">
//     Copyright (c) Andrew Arnott. All rights reserved.
//     Copyright (c) Beemway. All rights reserved.
// </copyright>
// <license>
//     Microsoft Public License (Ms-PL http://opensource.org/licenses/ms-pl.html).
//     Contributors may add their own copyright notice above.
// </license>
//-----------------------------------------------------------------------

using System;
using System.Net;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OAuth;

namespace LinkedIn
{
    /// <summary>
    /// Provides LinkedIn client authorization using the OAuth authorization protocol.
    /// </summary>
    [Serializable]
    public abstract class OAuthAuthorization : ILinkedInAuthorization, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthAuthorization"/> class.
        /// </summary>
        /// <param name="consumer">The consumer.</param>
        protected OAuthAuthorization(ConsumerBase consumer)
        {
            if (consumer == null)
            {
                throw new ArgumentNullException("consumer");
            }

            this.Consumer = consumer;
        }

        /// <summary>
        /// Gets the service description.
        /// </summary>
        /// <value>The service description.</value>
        internal ServiceProviderDescription ServiceDescription
        {
            get { return this.Consumer.ServiceProvider; }
        }

        /// <summary>
        /// Gets the consumer.
        /// </summary>
        /// <value>The consumer.</value>
        protected ConsumerBase Consumer { get; private set; }

        #region ILinkedInAuthorization Members
        /// <summary>
        /// Gets or sets the user agent.
        /// </summary>
        /// <value>The user agent.</value>
        public string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the timeout.
        /// </summary>
        /// <value>The timeout.</value>
        public TimeSpan Timeout { get; set; }

        /// <summary>
        /// Gets or sets the read write timeout.
        /// </summary>
        /// <value>The read write timeout.</value>
        public TimeSpan ReadWriteTimeout { get; set; }

        /// <summary>
        /// Gets or sets the base Service URI of the LinkedIn service to authenticate to.
        /// </summary>
        public string AuthenticationTarget
        {
            get
            {
                return this.ServiceDescription.RequestTokenEndpoint.Location.AbsoluteUri;
            }

            set
            {
                // Setting this doesn't make sense, since there are several OAuth URLs that would need to change.
                throw new NotSupportedException("This property cannot be set on an OAuth authorization module.");
            }
        }

        /// <summary>
        /// Gets the access token.
        /// </summary>
        public abstract string AccessToken { get; }

        /// <summary>
        /// Prepares an authorized HTTP GET request.
        /// </summary>
        /// <param name="requestUrl">The request URL.</param>
        /// <returns>
        /// The <see cref="HttpWebRequest"/> object that may be further customized.
        /// </returns>
        public HttpWebRequest InitializeGetRequest(Uri requestUrl)
        {
            return this.Consumer.PrepareAuthorizedRequest(new MessageReceivingEndpoint(requestUrl, HttpDeliveryMethods.GetRequest | HttpDeliveryMethods.AuthorizationHeaderRequest), this.AccessToken);
        }

        /// <summary>
        /// Prepares an authorized HTTP POST request.
        /// </summary>
        /// <param name="requestUrl">The request URL.</param>
        /// <returns>
        /// The <see cref="HttpWebRequest"/> object that may be further customized.
        /// </returns>
        public HttpWebRequest InitializePostRequest(Uri requestUrl)
        {
            return this.Consumer.PrepareAuthorizedRequest(new MessageReceivingEndpoint(requestUrl, HttpDeliveryMethods.PostRequest | HttpDeliveryMethods.AuthorizationHeaderRequest), this.AccessToken);
        }

        /// <summary>
        /// Prepares an authorized HTTP PUT request.
        /// </summary>
        /// <param name="requestUrl">The request URL.</param>
        /// <returns>
        /// The <see cref="HttpWebRequest"/> object that may be further customized.
        /// </returns>
        public HttpWebRequest InitializePutRequest(Uri requestUrl)
        {
            return this.Consumer.PrepareAuthorizedRequest(new MessageReceivingEndpoint(requestUrl, HttpDeliveryMethods.PutRequest | HttpDeliveryMethods.AuthorizationHeaderRequest), this.AccessToken);
        }

        /// <summary>
        /// Prepares an authorized HTTP DELETE request.
        /// </summary>
        /// <param name="requestUrl">The request URL.</param>
        /// <returns>
        /// The <see cref="HttpWebRequest"/> object that may be further customized.
        /// </returns>
        public HttpWebRequest InitializeDeleteRequest(Uri requestUrl)
        {
            return this.Consumer.PrepareAuthorizedRequest(new MessageReceivingEndpoint(requestUrl, HttpDeliveryMethods.DeleteRequest | HttpDeliveryMethods.AuthorizationHeaderRequest), this.AccessToken);
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.Consumer != null)
                {
                    this.Consumer.Dispose();
                }
            }
        }
        #endregion
    }
}
