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
using LinkedIn.ServiceEntities;
using NUnit.Framework;

namespace LinkedIn.Tests
{
    /// <summary>
    ///     This is a test class for LinkedInServiceTest and is intended
    ///     to contain all LinkedInServiceTest Unit Tests.
    /// </summary>
    [TestFixture]
    public class LinkedInServiceTest
    {
        /// <summary>
        ///     Gets or sets the test context which provides
        ///     information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        #region GetProfile tests

        [Test]

        [ExpectedException(typeof (ArgumentException))]
        public void GetCurrentUser_StandardProfileWithPublicField_Test()
        {
            var target = GetLinkedInService();

            List<ProfileField> profileFields = new List<ProfileField>
                {
                    ProfileField.SitePublicProfileRequestUrl
                };

            target.GetCurrentUser(ProfileType.Standard, profileFields);
        }

        private static ILinkedInService GetLinkedInService()
        {
            var target = GetLinkedInService();

            return target;
        }

        #endregion

        #region GetConnectionsForCurrentUser tests

        [Test]

        [ExpectedException(typeof (ArgumentException))]
        public void GetConnectionsForCurrentUser_IncludingPublicField_Test()
        {
            var target = GetLinkedInService();


            List<ProfileField> profileFields = new List<ProfileField>
                {
                    ProfileField.SitePublicProfileRequestUrl
                };

            target.GetConnectionsForCurrentUser(profileFields, -1, -1);
        }

        [Test]

        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void GetConnectionsForCurrentUser_ModifiedSinceOutOfRange_Test()
        {
            var target = GetLinkedInService();


            target.GetConnectionsForCurrentUser(new List<ProfileField>(), Modified.Updated, 0);
        }

        [Test]

        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void GetConnectionsByMemberId_ModifiedSinceOutOfRange_Test()
        {
            var target = GetLinkedInService();
            target.GetConnectionsByMemberId(Constants.MemberId, new List<ProfileField>(), 1, 10, Modified.Updated, 0);
        }

        #endregion

        #region GetOutOfNetworkProfile tests

        [Test]

        [ExpectedException(typeof (ArgumentException))]
        public void GetOutOfNetworkProfile_EmptyUrl_Test()
        {
            var target = GetLinkedInService();


            ApiRequest apiRequest = new ApiRequest
                {
                    Url = string.Empty,
                    Headers = new Collection<HttpHeader>()
                };

            target.GetOutOfNetworkProfile(apiRequest);
        }

        [Test]

        [ExpectedException(typeof (ArgumentException))]
        public void GetOutOfNetworkProfile_InvalidUrl_Test()
        {
            var target = GetLinkedInService();

            ApiRequest apiRequest = new ApiRequest
                {
                    Url = "http:\\invalid.url",
                    Headers = new Collection<HttpHeader>()
                };

            target.GetOutOfNetworkProfile(apiRequest);
        }

        #endregion

        #region Network Updates tests

        [Test]

        [ExpectedException(typeof (ArgumentNullException))]
        public void CommentOnNetworkUpdate_NoUpdateKeyParam_Test()
        {
            var target = GetLinkedInService();

            target.CommentOnNetworkUpdate(null, null);
        }

        [Test]

        [ExpectedException(typeof (ArgumentNullException))]
        public void CommentOnNetworkUpdate_NoCommentParam_Test()
        {
            var target = GetLinkedInService();


            target.CommentOnNetworkUpdate("update key", null);
        }

        [Test]

        [ExpectedException(typeof (ArgumentException))]
        public void CommentOnNetworkUpdate_EmptyUpdateKeyParam_Test()
        {
            var target = GetLinkedInService();


            target.CommentOnNetworkUpdate(string.Empty, null);
        }

        [Test]

        [ExpectedException(typeof (ArgumentException))]
        public void CommentOnNetworkUpdate_EmptyCommentParam_Test()
        {
            var target = GetLinkedInService();

            target.CommentOnNetworkUpdate("update key", string.Empty);
        }

        [Test]

        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void CommentOnNetworkUpdate_ToLongCommentParam_Test()
        {
            var target = GetLinkedInService();


            target.CommentOnNetworkUpdate("update key", Constants.CreateShare_ToLongCommentParam);
        }

        [Test]

        [ExpectedException(typeof (ArgumentNullException))]
        public void LikeNetworkUpdate_NoUpdateKeyParam_Test()
        {
            var target = GetLinkedInService();

            target.LikeNetworkUpdate(null);
        }

        [Test]

        [ExpectedException(typeof (ArgumentException))]
        public void LikeNetworkUpdate_EmptyUpdateKeyParam_Test()
        {
            var target = GetLinkedInService();

            target.LikeNetworkUpdate(string.Empty);
        }

        [Test]

        [ExpectedException(typeof (ArgumentNullException))]
        public void UnlikeNetworkUpdate_NoUpdateKeyParam_Test()
        {
            var target = GetLinkedInService();

            target.UnlikeNetworkUpdate(null);
        }

        [Test]

        [ExpectedException(typeof (ArgumentException))]
        public void UnlikeNetworkUpdate_EmptyUpdateKeyParam_Test()
        {
            var target = GetLinkedInService();


            target.UnlikeNetworkUpdate(string.Empty);
        }

        #endregion

        #region Search tests

        [Test]

        [ExpectedException(typeof (ArgumentException))]
        public void Search_IncludingPublicField_Test()
        {
            var target = GetLinkedInService();

            Collection<ProfileField> profileFields = new Collection<ProfileField>
                {
                    ProfileField.SitePublicProfileRequestUrl
                };

            target.Search(string.Empty, string.Empty, string.Empty, string.Empty, true, SortCriteria.Connections, 0, 10,
                          profileFields);
        }

        [Test]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Search_ToLargeCount_Test()
        {
            var target = GetLinkedInService();

            Collection<ProfileField> profileFields = new Collection<ProfileField>
                {
                    ProfileField.SitePublicProfileRequestUrl
                };

            int count = 26;

            target.Search(string.Empty, string.Empty, string.Empty, string.Empty, true, SortCriteria.Connections, 0,
                          count, profileFields);
        }

        #endregion

        #region Share tests

        [Test]

        [ExpectedException(typeof (ArgumentNullException))]
        public void CreateShare_NoCommentParam_Test()
        {
            var target = GetLinkedInService();

            target.CreateShare(null, VisibilityCode.ConnectionsOnly);
        }

        [Test]

        [ExpectedException(typeof (ArgumentException))]
        public void CreateShare_EmptyCommentParam_Test()
        {
            var target = GetLinkedInService();


            target.CreateShare(string.Empty, VisibilityCode.ConnectionsOnly);
        }

        [Test]

        [ExpectedException(typeof (ArgumentException))]
        public void CreateShare_EmptyCommentParamAndEmptyTitleParam_Test()
        {
            var target = GetLinkedInService();


            target.CreateShare(string.Empty, string.Empty, string.Empty,
                               new Uri(Constants.ShareContent_One_SubmittedUrl), null, VisibilityCode.ConnectionsOnly,
                               false);
        }

        [Test]

        [ExpectedException(typeof (ArgumentException))]
        public void CreateShare_EmptyCommentParamAndNoUriParam_Test()
        {
            var target = GetLinkedInService();

            target.CreateShare(string.Empty, Constants.ShareContent_One_Title, string.Empty, null, null,
                               VisibilityCode.ConnectionsOnly, false);
        }

        [Test]

        [ExpectedException(typeof (ArgumentException))]
        public void CreateShare_UnknownVisibilityParam_Test()
        {
            var target = GetLinkedInService();

            target.CreateShare(string.Empty, VisibilityCode.Unknown);
        }

        [Test]

        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void CreateShare_ToLongCommentParam_Test()
        {
            var target = GetLinkedInService();


            target.CreateShare(Constants.CreateShare_ToLongCommentParam, VisibilityCode.Anyone);
        }

        [Test]

        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void CreateShare_ToLongTitleParam_Test()
        {
            var target = GetLinkedInService();


            target.CreateShare(string.Empty, Constants.CreateShare_ToLongTitleParam, string.Empty,
                               new Uri(Constants.ShareContent_One_SubmittedUrl), null, VisibilityCode.ConnectionsOnly,
                               false);
        }

        [Test]

        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void CreateShare_ToLongDescriptionParam_Test()
        {
            var target = GetLinkedInService();


            target.CreateShare(string.Empty, Constants.ShareContent_One_Title,
                               Constants.CreateShare_ToLongDescriptionParam,
                               new Uri(Constants.ShareContent_One_SubmittedUrl), null, VisibilityCode.ConnectionsOnly,
                               false);
        }

        [Test]

        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void CreateReShare_ToLongCommentParam_Test()
        {
            var target = GetLinkedInService();


            target.CreateReShare(Constants.CreateShare_ToLongCommentParam, Constants.Share_One_Id, VisibilityCode.Anyone);
        }

        [Test]

        [ExpectedException(typeof (ArgumentNullException))]
        public void CreateReShare_NoShareIdParam_Test()
        {
            var target = GetLinkedInService();


            target.CreateReShare(string.Empty, null, VisibilityCode.ConnectionsOnly);
        }

        [Test]

        [ExpectedException(typeof (ArgumentException))]
        public void CreateReShare_EmptyShareIdParam_Test()
        {
            var target = GetLinkedInService();


            target.CreateReShare(string.Empty, string.Empty, VisibilityCode.ConnectionsOnly);
        }

        [Test]

        [ExpectedException(typeof (ArgumentException))]
        public void CreateReShare_UnknownVisibilityParam_Test()
        {
            var target = GetLinkedInService();


            target.CreateReShare(string.Empty, Constants.Share_One_Id, VisibilityCode.Unknown);
        }

        #endregion

        #region PostNetworkUpdate tests

        [Test]

        [ExpectedException(typeof (ArgumentNullException))]
        public void PostNetworkUpdate_NoBodyParam_Test()
        {
            var target = GetLinkedInService();

            target.PostNetworkUpdate(string.Empty, null);
        }

        [Test]

        [ExpectedException(typeof (ArgumentException))]
        public void PostNetworkUpdate_EmptyBodyParam_Test()
        {
            var target = GetLinkedInService();


            target.PostNetworkUpdate(string.Empty, string.Empty);
        }

        #endregion
    }
}