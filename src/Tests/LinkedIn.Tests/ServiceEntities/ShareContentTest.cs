//-----------------------------------------------------------------------
// <copyright file="ShareContentTest.cs" company="Beemway">
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
using NUnit.Framework;


namespace LinkedIn.ServiceEntities.Tests
{
  /// <summary>
  /// This is a test class for ShareContentTest and is intended
  /// to contain all ShareContentTest Unit Tests
  /// </summary>
  [TestFixture]
  public class ShareContentTest
  {
    private readonly string shareContentResponseFormat = @"<content>
            <title>{0}</title>            
            <submitted-url>{1}</submitted-url>            
          </content>";

    private readonly string shareContentLongResponseFormat = @"<content>
              <title>{0}</title>
              <description>{1}</description>
              <submitted-url>{2}</submitted-url>
              <shortened-url>{3}</shortened-url>
              <submitted-image-url>{4}</submitted-image-url>
              <thumbnail-url>{5}</thumbnail-url>
            </content>";

    private readonly string shareContentRequestFormat = @"<content><title>{0}</title><submitted-url>{1}</submitted-url><submitted-image-url>{2}</submitted-image-url></content>";
    
    private TestContext testContextInstance;
    private string shareContentResponse = string.Empty;
    private string shareContentLongResponse = string.Empty;
    private string shareContentRequest = string.Empty;

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
    /// Initializes a new instance of the <see cref="ShareContentTest"/> class.
    /// </summary>
    public ShareContentTest()
    {
      shareContentResponse = string.Format(
        this.shareContentResponseFormat, 
        SecurityElement.Escape(Constants.ShareContent_One_Title),
        Constants.ShareContent_One_SubmittedUrl);
      shareContentLongResponse = string.Format(
        shareContentLongResponseFormat,
        Constants.ShareContent_Three_Title,
        Constants.ShareContent_Three_Description,
        Constants.ShareContent_Three_SubmittedUrl,
        Constants.ShareContent_Three_ShortenedUrl,
        SecurityElement.Escape(Constants.ShareContent_Three_SubmittedImageUrl),
        SecurityElement.Escape(Constants.ShareContent_Three_ThumbnailUrl));
      shareContentRequest = string.Format(
        this.shareContentRequestFormat,
        Constants.ShareContent_Two_Title,
        Constants.ShareContent_Two_SubmittedUrl,
        Constants.ShareContent_Two_SubmittedImageUrl);
    }

    [Test]
    public void ReadXmlTest()
    {
      ShareContent target = new ShareContent();
      ShareContent expected = new ShareContent
      {
        Title = Constants.ShareContent_One_Title,
        SubmittedUrl = Constants.ShareContent_One_SubmittedUrl
      };

      XmlReader reader = XmlTextReader.Create(new StringReader(shareContentResponse));
      target.ReadXml(reader);

      Assert.AreEqual(expected.Title, target.Title);
      Assert.AreEqual(expected.SubmittedUrl, target.SubmittedUrl);
    }

    [Test]
    public void ReadLongXmlTest()
    {
      ShareContent target = new ShareContent();
      ShareContent expected = new ShareContent
      {
        Title = Constants.ShareContent_Three_Title,
        Description = Constants.ShareContent_Three_Description,
        SubmittedUrl = Constants.ShareContent_Three_SubmittedUrl,
        ShortenedUrl = Constants.ShareContent_Three_ShortenedUrl,
        SubmittedImageUrl = Constants.ShareContent_Three_SubmittedImageUrl,
        ThumbnailUrl = Constants.ShareContent_Three_ThumbnailUrl
      };

      XmlReader reader = XmlTextReader.Create(new StringReader(shareContentLongResponse));
      target.ReadXml(reader);

      Assert.AreEqual(expected.Title, target.Title);
      Assert.AreEqual(expected.Description, target.Description);
      Assert.AreEqual(expected.SubmittedUrl, target.SubmittedUrl);
      Assert.AreEqual(expected.ShortenedUrl, target.ShortenedUrl);
      Assert.AreEqual(expected.ThumbnailUrl, target.ThumbnailUrl);
    }

    [Test]
    public void WriteXmlTest()
    {
      ShareContent target = new ShareContent
      {
        Title = Constants.ShareContent_Two_Title,
        SubmittedUrl = Constants.ShareContent_Two_SubmittedUrl,
        SubmittedImageUrl = Constants.ShareContent_Two_SubmittedImageUrl
      };

      string actual = LinkedIn.Tests.Utility.WriteXml(target);

      Assert.AreEqual(this.shareContentRequest, actual);
    }
  }
}
