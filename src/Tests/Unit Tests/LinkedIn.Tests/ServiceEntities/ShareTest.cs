//-----------------------------------------------------------------------
// <copyright file="ShareTest.cs" company="Beemway">
//     Copyright (c) Beemway. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.IO;
using System.Security;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using LinkedIn.ServiceEntities;
using LinkedIn.Tests;

using LinkedIn.Utility;
using NUnit.Framework;

namespace LinkedIn.ServiceEntities.Tests
{
  /// <summary>
  /// This is a test class for ShareTest and is intended
  /// to contain all ShareTest Unit Tests
  /// </summary>
  [TestFixture]
  public class ShareTest
  {
    private readonly string shareResponseFormat = @"<current-share>
          <id>{0}</id>
          <timestamp>{1}</timestamp>
          <visibility>
            <code>{2}</code>
          </visibility>
          <comment>{3}</comment>
          <content>
            <title>{4}</title>
            <submitted-url>{5}</submitted-url>
          </content>
          <source>
            <service-provider>
              <name>{6}</name>
            </service-provider>
            <application>
              <name>{7}</name>
            </application>
          </source>
          <author>
            <id>{8}</id>
            <first-name>{9}</first-name>
            <last-name>{10}</last-name>
            <headline>{11}</headline>
          </author>
        </current-share>";

    private readonly string shareRequestFormat = @"<share><comment>{0}</comment><content><title>{1}</title><submitted-url>{2}</submitted-url><submitted-image-url>{3}</submitted-image-url></content><visibility><code>{4}</code></visibility></share>";
    
    private TestContext testContextInstance;
    private string shareResponse = string.Empty;
    private string shareLongResponse = string.Empty;
    private string shareRequest = string.Empty;

    /// <summary>
    /// Gets or sets the test context which provides
    /// information about and functionality for the current test run.
    /// </summary>
    public TestContext TestContext
    {
      get { return testContextInstance; }
      set { testContextInstance = value; }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ShareTest"/> class.
    /// </summary>
    public ShareTest()
    {
      shareResponse = string.Format(
        this.shareResponseFormat, 
        Constants.Share_One_Id,
        Constants.Share_One_Timestamp,
        EnumHelper.GetDescription(Constants.Visibility_One_Code),
        Constants.Share_One_Comment,
        Constants.ShareContent_One_Title,
        Constants.ShareContent_One_SubmittedUrl,
        Constants.ServiceProvider_One_Name,
        Constants.Application_One_Name,
        Constants.Person_One_Id,
        Constants.Person_One_FirstName,
        Constants.Person_One_LastName,
        Constants.Person_One_Headline
        );
      shareRequest = string.Format(
        this.shareRequestFormat,
        Constants.Share_Two_Comment,
        Constants.ShareContent_Two_Title,
        Constants.ShareContent_Two_SubmittedUrl,
        Constants.ShareContent_Two_SubmittedImageUrl,
        EnumHelper.GetDescription(Constants.Visibility_One_Code));
    }

    /// <summary>
    /// A test for ReadXml
    /// </summary>
    [Test]
    public void ReadXmlTest()
    {
      Share target = new Share();
      Share expected = new Share
      {
        Id = Constants.Share_One_Id,
        Timestamp = Constants.Share_One_Timestamp,
        Comment = Constants.Share_One_Comment,
        Content = new ShareContent
        {
          Title = Constants.ShareContent_One_Title,
          SubmittedUrl = Constants.ShareContent_One_SubmittedUrl
        },
        Visibility = new Visibility
        {
          Code = Constants.Visibility_One_Code
        },
        Source = new ShareSource
        {
          ServiceProvider = new ServiceProvider
          {
            Name = Constants.ServiceProvider_One_Name
          },
          Application = new Application
          {
            Name = Constants.Application_One_Name
          }
        },
        Author = new Person
        {
          Id = Constants.Person_One_Id,
          FirstName = Constants.Person_One_FirstName,
          LastName = Constants.Person_One_LastName,
          Headline = Constants.Person_One_Headline
        }
      };

      XmlReader reader = XmlTextReader.Create(new StringReader(shareResponse));
      target.ReadXml(reader);

      Assert.AreEqual(expected.Id, target.Id);
      Assert.AreEqual(expected.Timestamp, target.Timestamp);
      Assert.AreEqual(expected.Comment, target.Comment);
      Assert.AreEqual(expected.Content.Title, target.Content.Title);
      Assert.AreEqual(expected.Source.ServiceProvider.Name, target.Source.ServiceProvider.Name);
      Assert.AreEqual(expected.Source.Application.Name, target.Source.Application.Name);
      Assert.AreEqual(expected.Author.FirstName, target.Author.FirstName);
      Assert.AreEqual(expected.Visibility.Code, target.Visibility.Code);
    }

    /// <summary>
    /// A test for WriteXml
    /// </summary>
    [Test]
    public void WriteXmlTest()
    {
      Share target = new Share
      {
        Comment = Constants.Share_Two_Comment,
        Content = new ShareContent
        {
          Title = Constants.ShareContent_Two_Title,
          SubmittedUrl = Constants.ShareContent_Two_SubmittedUrl,
          SubmittedImageUrl = Constants.ShareContent_Two_SubmittedImageUrl
        },
        Visibility = new Visibility
        {
          Code = Constants.Visibility_One_Code
        },
      };
      
      string actual = LinkedIn.Tests.Utility.WriteXml(target);

      Assert.AreEqual(this.shareRequest, actual);
    }
  }
}
