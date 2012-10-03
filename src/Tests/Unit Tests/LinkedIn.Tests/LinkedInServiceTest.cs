//-----------------------------------------------------------------------
// <copyright file="LinkedInServiceTest.cs" company="Beemway">
//     Copyright (c) Beemway. All rights reserved.
// </copyright>
// <license>
//     Microsoft Public License (Ms-PL http://opensource.org/licenses/ms-pl.html).
//     Contributors may add their own copyright notice above.
// </license>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Web;

using LinkedIn;
using LinkedIn.ServiceEntities;
using LinkedIn.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedIn.Tests
{
  /// <summary>
  /// This is a test class for LinkedInServiceTest and is intended
  /// to contain all LinkedInServiceTest Unit Tests.
  ///</summary>
  [TestClass()]
  public class LinkedInServiceTest
  {
    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    #region Additional test attributes
    // 
    //You can use the following additional attributes as you write your tests:
    //
    //Use ClassInitialize to run code before running the first test in the class
    //[ClassInitialize()]
    //public static void MyClassInitialize(TestContext testContext)
    //{
    //}
    //
    //Use ClassCleanup to run code after all tests in a class have run
    //[ClassCleanup()]
    //public static void MyClassCleanup()
    //{
    //}
    //
    //Use TestInitialize to run code before running each test
    //[TestInitialize()]
    //public void MyTestInitialize()
    //{
    //}
    //
    //Use TestCleanup to run code after each test has run
    //[TestCleanup()]
    //public void MyTestCleanup()
    //{
    //}
    //
    #endregion

    #region GetProfile tests
    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentException))]
    public void GetCurrentUser_StandardProfileWithPublicField_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      List<ProfileField> profileFields = new List<ProfileField>
      {
        ProfileField.SitePublicProfileRequestUrl
      };

      target.GetCurrentUser(ProfileType.Standard, profileFields);
    }
    #endregion

    #region GetConnectionsForCurrentUser tests
    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentException))]
    public void GetConnectionsForCurrentUser_IncludingPublicField_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      List<ProfileField> profileFields = new List<ProfileField>
      {
        ProfileField.SitePublicProfileRequestUrl
      };

      target.GetConnectionsForCurrentUser(profileFields, -1, -1);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void GetConnectionsForCurrentUser_ModifiedSinceOutOfRange_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.GetConnectionsForCurrentUser(new List<ProfileField>(), Modified.Updated, 0);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void GetConnectionsByMemberId_ModifiedSinceOutOfRange_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.GetConnectionsByMemberId(Constants.MemberId, new List<ProfileField>(), 1, 10, Modified.Updated, 0);
    }
    #endregion

    #region GetOutOfNetworkProfile tests
    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentException))]
    public void GetOutOfNetworkProfile_EmptyUrl_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      ApiRequest apiRequest = new ApiRequest
      {
        Url = string.Empty,
        Headers = new Collection<HttpHeader>()
      };

      target.GetOutOfNetworkProfile(apiRequest);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentException))]
    public void GetOutOfNetworkProfile_InvalidUrl_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      ApiRequest apiRequest = new ApiRequest
      {
        Url = "http:\\invalid.url",
        Headers = new Collection<HttpHeader>()
      };

      target.GetOutOfNetworkProfile(apiRequest);
    }
    #endregion

    #region Network Updates tests
    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CommentOnNetworkUpdate_NoUpdateKeyParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.CommentOnNetworkUpdate(null, null);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CommentOnNetworkUpdate_NoCommentParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.CommentOnNetworkUpdate("update key", null);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentException))]
    public void CommentOnNetworkUpdate_EmptyUpdateKeyParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.CommentOnNetworkUpdate(string.Empty, null);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentException))]
    public void CommentOnNetworkUpdate_EmptyCommentParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.CommentOnNetworkUpdate("update key", string.Empty);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CommentOnNetworkUpdate_ToLongCommentParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.CommentOnNetworkUpdate("update key", Constants.CreateShare_ToLongCommentParam);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LikeNetworkUpdate_NoUpdateKeyParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.LikeNetworkUpdate(null);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentException))]
    public void LikeNetworkUpdate_EmptyUpdateKeyParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.LikeNetworkUpdate(string.Empty);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void UnlikeNetworkUpdate_NoUpdateKeyParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.UnlikeNetworkUpdate(null);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentException))]
    public void UnlikeNetworkUpdate_EmptyUpdateKeyParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.UnlikeNetworkUpdate(string.Empty);
    }
    #endregion

    #region Search tests
    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentException))]
    public void Search_IncludingPublicField_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      Collection<ProfileField> profileFields = new Collection<ProfileField>
      {
        ProfileField.SitePublicProfileRequestUrl
      };

      target.Search(string.Empty, string.Empty, string.Empty, string.Empty, true, SortCriteria.Connections, 0, 10, profileFields);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Search_ToLargeCount_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      Collection<ProfileField> profileFields = new Collection<ProfileField>
      {
        ProfileField.SitePublicProfileRequestUrl
      };

      int count = 26;

      target.Search(string.Empty, string.Empty, string.Empty, string.Empty, true, SortCriteria.Connections, 0, count, profileFields);
    }
    #endregion

    #region Share tests
    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CreateShare_NoCommentParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.CreateShare(null, VisibilityCode.ConnectionsOnly);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentException))]
    public void CreateShare_EmptyCommentParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.CreateShare(string.Empty, VisibilityCode.ConnectionsOnly);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentException))]
    public void CreateShare_EmptyCommentParamAndEmptyTitleParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.CreateShare(string.Empty, string.Empty, string.Empty, new Uri(Constants.ShareContent_One_SubmittedUrl), null, VisibilityCode.ConnectionsOnly, false);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentException))]
    public void CreateShare_EmptyCommentParamAndNoUriParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.CreateShare(string.Empty, Constants.ShareContent_One_Title, string.Empty, null, null, VisibilityCode.ConnectionsOnly, false);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentException))]
    public void CreateShare_UnknownVisibilityParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.CreateShare(string.Empty, VisibilityCode.Unknown);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CreateShare_ToLongCommentParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.CreateShare(Constants.CreateShare_ToLongCommentParam, VisibilityCode.Anyone);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CreateShare_ToLongTitleParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.CreateShare(string.Empty, Constants.CreateShare_ToLongTitleParam, string.Empty, new Uri(Constants.ShareContent_One_SubmittedUrl), null, VisibilityCode.ConnectionsOnly, false);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CreateShare_ToLongDescriptionParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.CreateShare(string.Empty, Constants.ShareContent_One_Title, Constants.CreateShare_ToLongDescriptionParam, new Uri(Constants.ShareContent_One_SubmittedUrl), null, VisibilityCode.ConnectionsOnly, false);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CreateReShare_ToLongCommentParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.CreateReShare(Constants.CreateShare_ToLongCommentParam, Constants.Share_One_Id, VisibilityCode.Anyone);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CreateReShare_NoShareIdParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.CreateReShare(string.Empty, null, VisibilityCode.ConnectionsOnly);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentException))]
    public void CreateReShare_EmptyShareIdParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.CreateReShare(string.Empty, string.Empty, VisibilityCode.ConnectionsOnly);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentException))]
    public void CreateReShare_UnknownVisibilityParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.CreateReShare(string.Empty, Constants.Share_One_Id, VisibilityCode.Unknown);
    }
    #endregion

    #region PostNetworkUpdate tests
    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void PostNetworkUpdate_NoBodyParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.PostNetworkUpdate(string.Empty, null);
    }

    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    [ExpectedException(typeof(ArgumentException))]
    public void PostNetworkUpdate_EmptyBodyParam_Test()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);

      target.PostNetworkUpdate(string.Empty, string.Empty);
    }
    #endregion

    #region SendRequest tests
    /// <summary>
    /// A test for SendRequest
    ///</summary>
    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    public void SendRequestTest()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService_Accessor target = new LinkedInService_Accessor(authorization);
      WebRequest webRequest = WebRequest.Create(Constants.ApiBaseUrl);

      WebResponse actual = target.SendRequest(webRequest);
      Assert.IsNotNull(actual);
    }
    #endregion

    #region BuildApiUrl tests
    /// <summary>
    /// A test for BuildApiUrlByMemberId
    ///</summary>
    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    public void BuildApiUrlByMemberIdTest()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService_Accessor target = new LinkedInService_Accessor(authorization);
      string memberId = Constants.MemberId;
      string ResourceName = Constants.ResourceName;
      UriBuilder expected = new UriBuilder("http://api.linkedin.com/v1/people/id=12345/resource");

      UriBuilder actual = target.BuildApiUrlByMemberId(memberId, ResourceName);
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for BuildApiUrl
    ///</summary>
    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    public void BuildApiUrlForMemberTest()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService_Accessor target = new LinkedInService_Accessor(authorization);
      string identifier = Constants.CurrentUserIdentifier;
      string resourceName = Constants.ResourceName;
      QueryStringParameters parameters = new QueryStringParameters();
      UriBuilder expected = new UriBuilder("http://api.linkedin.com/v1/people/~/resource");

      UriBuilder actual = target.BuildApiUrlForMember(identifier, resourceName, parameters);
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for BuildApiUrl
    ///</summary>
    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    public void BuildApiUrlForCurrentUserTest()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService_Accessor target = new LinkedInService_Accessor(authorization);
      QueryStringParameters parameters = new QueryStringParameters();
      parameters.Add(Constants.QueryStringParam1, Constants.QueryStringValue1);

      UriBuilder expected = new UriBuilder("http://api.linkedin.com/v1/people/~");
      expected.Query = string.Format("{0}={1}", Constants.QueryStringParam1, Constants.QueryStringValue1);

      UriBuilder actual = target.BuildApiUrlForCurrentUser(parameters);
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for BuildApiUrl
    ///</summary>
    [TestMethod()]
    [DeploymentItem("LinkedIn.dll")]
    public void BuildApiUrlTest()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService_Accessor target = new LinkedInService_Accessor(authorization);
      Collection<Resource> resources = new Collection<Resource>();
      resources.Add(new Resource { Name = Constants.PeopleResourceName, Identifier = Constants.CurrentUserIdentifier });
      resources.Add(new Resource { Name = Constants.ResourceName });
      QueryStringParameters parameters = new QueryStringParameters();
      parameters.Add(Constants.QueryStringParam1, Constants.QueryStringValue1);
      parameters.Add(Constants.QueryStringParam2, Constants.QueryStringValue2);

      UriBuilder expected = new UriBuilder("http://api.linkedin.com/v1/people/~/resource?param1=value1&param2=value2");

      UriBuilder actual = target.BuildApiUrl(resources, parameters);
      Assert.AreEqual(expected, actual);
    }
    #endregion

    #region Constructor tests
    /// <summary>
    /// A test for LinkedInOAuthClient Constructor
    ///</summary>
    [TestMethod()]
    public void LinkedInServiceConstructorTest()
    {
      ILinkedInAuthorization authorization = new LinkedInAuthorizationMock();
      LinkedInService target = new LinkedInService(authorization);
    }
    #endregion
  }
}
