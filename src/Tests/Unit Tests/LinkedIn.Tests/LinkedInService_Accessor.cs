using System;
using System.Collections.ObjectModel;
using System.Net;
using LinkedIn.Utility;
using NUnit.Framework;

namespace LinkedIn.Tests
{
    public class LinkedInService_Accessor
    {

        #region SendRequest tests

        /// <summary>
        ///     A test for SendRequest
        /// </summary>
        [Test]
        public void SendRequestTest()
        {
            //ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
            //LinkedInService_Accessor target = new LinkedInService_Accessor(authorization);
            WebRequest webRequest = WebRequest.Create(Constants.ApiBaseUrl);
            WebResponse actual = target.SendRequest(webRequest);
            Assert.IsNotNull(actual);
        }

        #endregion

        #region BuildApiUrl tests

        /// <summary>
        ///     A test for BuildApiUrlByMemberId
        /// </summary>
        [Test]
        
        public void BuildApiUrlByMemberIdTest()
        {
            ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
            LinkedInService_Accessor target = new LinkedInService_Accessor(authorization);
            string memberId = Constants.MemberId;
            string ResourceName = Constants.ResourceName;
            UriBuilder expected = new UriBuilder("http://api.linkedin.com/v1/people/id=12345/resource");

            UriBuilder actual = UriUtility.BuildApiUrlByMemberId(memberId, ResourceName);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     A test for BuildApiUrl
        /// </summary>
        [Test]
        
        public void BuildApiUrlForMemberTest()
        {
           ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
            LinkedInService_Accessor target = new LinkedInService_Accessor(authorization);
            string identifier = Constants.CurrentUserIdentifier;
            string resourceName = Constants.ResourceName;
            QueryStringParameters parameters = new QueryStringParameters();
            UriBuilder expected = new UriBuilder("http://api.linkedin.com/v1/people/~/resource");

            UriBuilder actual = UriUtility.BuildApiUrlForMember(identifier, resourceName, parameters);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     A test for BuildApiUrl
        /// </summary>
        [Test]
        
        public void BuildApiUrlForCurrentUserTest()
        {
            ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
            LinkedInService_Accessor target = new LinkedInService_Accessor(authorization);
            QueryStringParameters parameters = new QueryStringParameters();
            parameters.Add(Constants.QueryStringParam1, Constants.QueryStringValue1);

            UriBuilder expected = new UriBuilder("http://api.linkedin.com/v1/people/~");
            expected.Query = string.Format("{0}={1}", Constants.QueryStringParam1, Constants.QueryStringValue1);

            UriBuilder actual = UriUtility.BuildApiUrlForCurrentUser(parameters);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     A test for BuildApiUrl
        /// </summary>
        [Test]
        
        public void BuildApiUrlTest()
        {
            ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
            LinkedInService_Accessor target = new LinkedInService_Accessor(authorization);
            Collection<Resource> resources = new Collection<Resource>();
            resources.Add(new Resource
                {
                    Name = Constants.PeopleResourceName,
                    Identifier = Constants.CurrentUserIdentifier
                });
            resources.Add(new Resource {Name = Constants.ResourceName});
            QueryStringParameters parameters = new QueryStringParameters();
            parameters.Add(Constants.QueryStringParam1, Constants.QueryStringValue1);
            parameters.Add(Constants.QueryStringParam2, Constants.QueryStringValue2);

            UriBuilder expected =
                new UriBuilder("http://api.linkedin.com/v1/people/~/resource?param1=value1&param2=value2");

            UriBuilder actual = UriUtility.BuildApiUrl(resources, parameters);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}