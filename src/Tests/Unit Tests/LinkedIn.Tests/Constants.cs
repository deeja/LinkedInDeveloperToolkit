//-----------------------------------------------------------------------
// <copyright file="Constants.cs" company="Beemway">
//     Copyright (c) Beemway. All rights reserved.
// </copyright>
// <license>
//     Microsoft Public License (Ms-PL http://opensource.org/licenses/ms-pl.html).
//     Contributors may add their own copyright notice above.
// </license>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Security;
using LinkedIn.ServiceEntities;

namespace LinkedIn.Tests
{
  /// <summary>
  /// A Constants class.
  /// </summary>
  internal static class Constants
  {
    public static readonly string ApiBaseUrl = "http://api.linkedin.com/v1";
    public static readonly string PeopleResourceName = "people";
    public static readonly string QueryStringParam1 = "param1";
    public static readonly string QueryStringParam2 = "param2";
    public static readonly string QueryStringValue1 = "value1";
    public static readonly string QueryStringValue2 = "value2";
    public static readonly string CurrentUserIdentifier = "~";
    public static readonly string ResourceName = "resource";
    public static readonly string EmailAddress = "info@company.com";
    public static readonly string MemberId = "12345";
    public static readonly Uri ProfileUrl = new Uri("http://www.linkedin.com/profile");

    public static readonly string Activity_Body = @"<a href='http://www.linkedin.com/profile?viewProfile=&key=12345'>User Name</a> is using the LinkedIn Developer Toolkit.";
    public static readonly string Activity_AppId = "100";
    public static readonly string Activity_CultureName = "en_US";

    // First api request
    public static readonly string ApiRequest_One_Url = "http://api.linkedin.com/v1/people/12345:full";

    // Second api request
    public static readonly string ApiRequest_Two_Url = "http://api.linkedin.com/v1/people/45678:full";

    // Third api request
    public static readonly string ApiRequest_Three_Url = "http://api.linkedin.com/v1/people/78912:full";

    public static readonly string HttpHeader_Name = "x-li-auth-token";
    public static readonly string HttpHeader_Value = "name:5432";

    public static readonly string Company_Id = "73235";
    public static readonly string Company_Name = "Het Concertgebouw Amsterdam";
    public static readonly string CompanyType_Code = "N";
    public static readonly string CompanyType_Name = "Non-Profit";

    public static readonly string Job_Id = "8162505";
    public static readonly string Job_SiteRequest = "http://www.linkedin.com/jobs?viewJob=&jobId=8162505";
    
    public static readonly string Position_Title = "Editor";

    // First person
    public static readonly string Person_One_Id = "12345";
    public static readonly string Person_One_FirstName = "Shelton";
    public static readonly string Person_One_LastName = "Quacker";
    public static readonly string Person_One_Headline = "Co-Founder at Company.com";
    public static readonly string Person_One_Industry = "Computer Networking";
    public static readonly string Person_One_PictureUrl = "http://media.linkedin.com/mpr/mpr/shrink_80_80/p/3/000/000/000/12345.jpg";
    
    // Second person
    public static readonly string Person_Two_Id = "45678";
    public static readonly string Person_Two_FirstName = "Paul";
    public static readonly string Person_Two_LastName = "Vermegen";
    public static readonly string Person_Two_Headline = "Account manager at Marketing Agency";
    public static readonly string Person_Two_CurrentStatus = "Enjoying my vacation in Barcelona";
    public static readonly string Person_Two_Industry = "Marketing and Advertising";
    public static readonly string Person_Two_PictureUrl = "http://media.linkedin.com/mpr/mpr/shrink_80_80/p/3/000/000/000/45678.jpg";

    // Third person
    public static readonly string Person_Three_Id = "78912";
    public static readonly string Person_Three_FirstName = "Jeffrey";
    public static readonly string Person_Three_LastName = "Melchiorsen";
    public static readonly string Person_Three_Headline = "Student at Business and ICT";
    public static readonly string Person_Three_Industry = "Online Media";
    public static readonly string Person_Three_PictureUrl = "http://media.linkedin.com/mpr/mpr/shrink_80_80/p/3/000/000/000/78912.jpg";
    
    // First location
    public static readonly string Location_One_Name = "Washington D.C. Metro Area";

    // Second location
    public static readonly string Location_Two_Name = "Utrecht Area, Netherlands";

    // Third location
    public static readonly string Location_Three_Name = "Greater Atlanta Area";

    // First Country
    public static readonly string Country_One_Code = "us";

    // Second Country
    public static readonly string Country_Two_Code = "nl";

    // Third Country
    public static readonly string Country_Three_Code = "us";

    // First member group
    public static readonly int MemberGroup_One_Id = 2560108;
    public static readonly string MemberGroup_One_Name = "Belgian ICT Pro's";

    // First site group request
    public static readonly string SiteGroupRequest_One_Url = "http://www.linkedin.com/groups?gid=2560108";

    // First site request
    public static readonly string SiteRequest_One_Url = "http://www.linkedin.com/profile?viewProfile=&key=12345&authToken=5432&authType=name";

    // Second site request
    public static readonly string SiteRequest_Two_Url = "http://www.linkedin.com/profile?viewProfile=&key=45678&authToken=8765&authType=name";

    // Third site request
    public static readonly string SiteRequest_Three_Url = "http://www.linkedin.com/profile?viewProfile=&key=78912&authToken=2198&authType=name";

    // First update
    public static readonly long Update_One_Timestamp = 1260303542000;
    public static readonly string Update_One_UpdateType = "CONN";
    public static readonly bool Update_One_IsCommentable = false;

    // Second update
    public static readonly long Update_Two_Timestamp = 1260303120688;
    public static readonly string Update_Two_UpdateKey = "STAT-7715686-390-*1";
    public static readonly string Update_Two_UpdateType = "STAT";
    public static readonly bool Update_Two_IsCommentable = true;

    // Third update
    public static readonly long Update_Three_Timestamp = 1260284584604;
    public static readonly string Update_Three_UpdateType = "JGRP";
    public static readonly bool Update_Three_IsCommentable = false;

    public static readonly string NetworkStatus = "nl";

    public static readonly int NumberOfConnections = 2;
    public static readonly int NetworkStatsDegreeOne = 3;
    public static readonly int NetworkStatsDegreeTwo = 21;
    public static readonly int NumberOfUpdates = 3;

    public static readonly string Share_One_Id = "s23916311";
    public static readonly long Share_One_Timestamp = 1283903797256;
    public static readonly string Share_One_Comment = "I love shares!";

    public static readonly string Share_Two_Comment = "83% of employers will use social media to hire: 78% LinkedIn, 55% Facebook, 45% Twitter [SF Biz Times] http://bit.ly/cCpeOD";

    public static readonly string Share_Three_Id = "s112815322";
    public static readonly long Share_Three_Timestamp = 1284110986336;
    public static readonly string Share_Three_Comment = "Follow LinkedIn on Twitter";
    
    public static readonly string ShareContent_One_Title = "LinkedIn Developer Network";
    public static readonly string ShareContent_One_SubmittedUrl = "http://developer.linkedin.com/";

    public static readonly string ShareContent_Two_Title = "Survey: Social networks top hiring tool - San Francisco Business Times";
    public static readonly string ShareContent_Two_SubmittedUrl = "http://sanfrancisco.bizjournals.com/sanfrancisco/stories/2010/06/28/daily34.html";
    public static readonly string ShareContent_Two_SubmittedImageUrl = "http://images.bizjournals.com/travel/cityscapes/thumbs/sm_sanfrancisco.jpg";

    public static readonly string ShareContent_Three_Title = "LinkedIn (LinkedIn) on Twitter";
    public static readonly string ShareContent_Three_Description = "from the folks who work at LinkedIn";
    public static readonly string ShareContent_Three_SubmittedUrl = "http://twitter.com/linkedin";
    public static readonly string ShareContent_Three_ShortenedUrl = "http://lnkd.in/pDwEKb";
    public static readonly string ShareContent_Three_SubmittedImageUrl = "http://a2.twimg.com/profile_images/519084170/pbandc_bigger.jpg";
    public static readonly string ShareContent_Three_ThumbnailUrl = "http://media.linkedin.com/media-proxy/ext?w=80&amp;h=100&amp;hash=uUPjCpwyxwSq%2F56C3UksL%2BklM0Q%3D&amp;url=http%3A%2F%2Fa2.twimg.com%2Fprofile_images%2F519084170%2Fpbandc_bigger.jpg";

    public static readonly VisibilityCode Visibility_One_Code = VisibilityCode.Anyone;

    public static readonly string ServiceProvider_One_Name = "LINKEDIN";

    public static readonly string Application_One_Name = "My Application";

    public static readonly int UpdateComment_One_SequenceNumber = 0;
    public static readonly string UpdateComment_One_Comment = "Save me a trout, Richard!";

    public static readonly string CreateShare_ToLongCommentParam = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer sit amet nulla nibh. Etiam et mi non metus molestie egestas in eu sem. Duis magna dolor, pharetra nec consequat eget, ultricies viverra lectus. Quisque quis nisi velit. Integer eu nibh lacus. Pellentesque dapibus nunc ac eros sodales ornare. Ut sodales tempus sollicitudin. Pellentesque eu quam est. Nulla sed neque nisl. In hac habitasse platea dictumst. 
            Fusce id dictum orci. Vivamus quis sem non enim pretium sagittis. Donec eget euismod mi. Suspendisse molestie ornare lobortis. Curabitur et odio libero. Mauris urna erat, luctus sed euismod vitae, tincidunt ac felis. Vestibulum auctor leo ipsum, vitae faucibus risus. Nunc nullam.";
    public static readonly string CreateShare_ToLongTitleParam = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi dignissim ullamcorper nisi, ac luctus nulla gravida vel. Ut lorem velit, tempus at imperdiet nec, euismod ornare risus. Etiam vel quam id volutpat.";
    public static readonly string CreateShare_ToLongDescriptionParam = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque sit amet ligula eu tortor iaculis vehicula at eget libero. Curabitur ullamcorper porta sapien. Nam sed nisi eu dolor laoreet ullamcorper. Mauris tincidunt laoreet gravida. Praesent iaculis nibh et dolor venenatis consequat. Aenean vitae diam non turpis vestibulum venenatis. Etiam et leo erat. Phasellus sit amet rutrum arcu. Vivamus metus.";

    private static readonly string simplePersonFormat = @"<person><id>{0}</id><first-name>{1}</first-name><last-name>{2}</last-name><headline>{3}</headline><location><name>{4}</name><country><code>{5}</code></country></location><industry>{6}</industry><api-standard-profile-request><url>{7}</url><headers total=""1""><http-header><name>{8}</name><value>{9}</value></http-header></headers></api-standard-profile-request><site-standard-profile-request><url>{10}</url></site-standard-profile-request><picture-url>{11}</picture-url></person>";

    private static readonly string updateConnFormat = @"<update><timestamp>{0}</timestamp><update-type>{1}</update-type><update-content><person><id>{2}</id><first-name>{3}</first-name><last-name>{4}</last-name><headline>{5}</headline><connections total=""1""><person><id>{6}</id><first-name>{7}</first-name><last-name>{8}</last-name><headline>{9}</headline><api-standard-profile-request><url>{10}</url><headers total=""1""><http-header><name>{11}</name><value>{12}</value></http-header></headers></api-standard-profile-request><site-standard-profile-request><url>{13}</url></site-standard-profile-request></person></connections></person></update-content><is-commentable>{14}</is-commentable></update>";

    private static readonly string updateStatFormat = @"<update><timestamp>{0}</timestamp><update-key>{1}</update-key><update-type>{2}</update-type><update-content><person><id>{3}</id><first-name>{4}</first-name><last-name>{5}</last-name><headline>{6}</headline><current-status>{7}</current-status><api-standard-profile-request><url>{7}</url><headers total=""1""><http-header><name>{8}</name><value>{9}</value></http-header></headers></api-standard-profile-request><site-standard-profile-request><url>{10}</url></site-standard-profile-request></person></update-content><is-commentable>{11}</is-commentable></update>";

    private static readonly string updateJgrpFormat = @"<update><timestamp>{0}</timestamp><update-type>{1}</update-type><update-content><person><id>{2}</id><first-name>{3}</first-name><last-name>{4}</last-name><headline>{5}</headline><api-standard-profile-request><url>{6}</url><headers total=""1""><http-header><name>{7}</name><value>{8}</value></http-header></headers></api-standard-profile-request><site-standard-profile-request><url>{9}</url></site-standard-profile-request><member-groups total=""1""><member-group><id>{10}</id><name>{11}</name><site-group-request><url>{12}</url></site-group-request></member-group></member-groups></person></update-content><is-commentable>{13}</is-commentable></update>";

    public static List<string> MemberIds
    {
      get
      {
        List<string> memberIds = new List<string>();
        memberIds.Add("123abc");
        memberIds.Add("456def");
        return memberIds;
      }
    }

    public static string Person_Simple_One_Xml
    {
      get
      {
        return string.Format(simplePersonFormat,
          Person_One_Id,
          Person_One_FirstName,
          Person_One_LastName,
          Person_One_Headline,
          Location_One_Name,
          Country_One_Code,
          Person_One_Industry,
          SecurityElement.Escape(ApiRequest_One_Url),
          HttpHeader_Name,
          HttpHeader_Value,
          SecurityElement.Escape(SiteRequest_One_Url),
          Person_One_PictureUrl);
      }
    }

    public static string Person_Simple_Two_Xml
    {
      get
      {
        return string.Format(simplePersonFormat,
          Person_Two_Id,
          Person_Two_FirstName,
          Person_Two_LastName,
          Person_Two_Headline,
          Location_Two_Name,
          Country_Two_Code,
          Person_Two_Industry,
          SecurityElement.Escape(ApiRequest_Two_Url),
          HttpHeader_Name,
          HttpHeader_Value,
          SecurityElement.Escape(SiteRequest_Two_Url),
          Person_Two_PictureUrl);
      }
    }

    public static string Update_CONN_One
    {
      get
      {
        return string.Format(updateConnFormat,
          Update_One_Timestamp,
          Update_One_UpdateType,
          Person_One_Id,
          Person_One_FirstName,
          Person_One_LastName,
          Person_One_Headline,
          Person_Three_Id,
          Person_Three_FirstName,
          Person_Three_LastName,
          Person_Three_Headline,
          SecurityElement.Escape(ApiRequest_Two_Url),
          HttpHeader_Name,
          HttpHeader_Value,
          SecurityElement.Escape(SiteRequest_One_Url),
          Update_One_IsCommentable.ToString().ToLower());
      }
    }

    public static string Update_STAT_One
    {
      get
      {
        return string.Format(updateStatFormat,
          Update_Two_Timestamp,
          Update_Two_UpdateType,
          Person_Two_Id,
          Person_Two_FirstName,
          Person_Two_LastName,
          Person_Two_Headline,
          Person_Two_CurrentStatus,
          SecurityElement.Escape(ApiRequest_Two_Url),
          HttpHeader_Name,
          HttpHeader_Value,
          SecurityElement.Escape(SiteGroupRequest_One_Url),
          Update_One_IsCommentable.ToString().ToLower());
      }
    }

    public static string Update_JGRP_One
    {
      get
      {
        return string.Format(updateJgrpFormat,
          Update_Three_Timestamp,
          Update_Three_UpdateType,
          Person_Three_Id,
          Person_Three_FirstName,
          Person_Three_LastName,
          Person_Three_Headline,
          SecurityElement.Escape(ApiRequest_Three_Url),
          HttpHeader_Name,
          HttpHeader_Value,
          SecurityElement.Escape(SiteRequest_Three_Url),
          MemberGroup_One_Id,
          MemberGroup_One_Name,
          SecurityElement.Escape(SiteGroupRequest_One_Url),
          Update_One_IsCommentable.ToString().ToLower());
      }
    }
  }
}
