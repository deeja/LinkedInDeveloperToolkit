//-----------------------------------------------------------------------
// <copyright file="UpdateCommentTest.cs" company="Beemway">
//     Copyright (c) Beemway. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.ObjectModel;
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
  /// This is a test class for UpdateCommentTest and is intended
  /// to contain all UpdateCommentTest Unit Tests
  /// </summary>
  [TestFixture]
  public class UpdateCommentTest
  {
    private readonly string shareContentResponseFormat = @"<update-comment>
          <sequence-number>{0}</sequence-number>
          <comment>{1}</comment>
          <person>
            <id>{2}</id>
            <first-name>{3}</first-name>
            <last-name>{4}</last-name>
            <headline>{5}</headline>
            <api-standard-profile-request>
              <url>{6}</url>
              <headers total=""1"">
                <http-header>
                  <name>{7}</name>
                  <value>{8}</value>
                </http-header>
              </headers>
            </api-standard-profile-request>
            <site-standard-profile-request>
              <url>{9}</url>
            </site-standard-profile-request>
          </person>
        </update-comment>";

    private readonly string shareContentRequestFormat = @"<update-comment><comment>{0}</comment></update-comment>";
    
    private TestContext testContextInstance;
    private string shareContentResponse = string.Empty;
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
    /// Initializes a new instance of the <see cref="UpdateCommentTest"/> class.
    /// </summary>
    public UpdateCommentTest()
    {
      shareContentResponse = string.Format(
        this.shareContentResponseFormat, 
        Constants.UpdateComment_One_SequenceNumber,
        Constants.UpdateComment_One_Comment,
        Constants.Person_One_Id,
        Constants.Person_One_FirstName,
        Constants.Person_One_LastName,
        Constants.Person_One_Headline,
        SecurityElement.Escape(Constants.ApiRequest_One_Url),
        Constants.HttpHeader_Name,
        Constants.HttpHeader_Value,
        SecurityElement.Escape(Constants.SiteRequest_One_Url));
      shareContentRequest = string.Format(
        this.shareContentRequestFormat,
        Constants.UpdateComment_One_Comment);
    }

    [Test]
    public void ReadXmlTest()
    {
      UpdateComment target = new UpdateComment();
      UpdateComment expected = new UpdateComment
      {
        SequenceNumber = Constants.UpdateComment_One_SequenceNumber,
        Comment = Constants.UpdateComment_One_Comment,
        Person = new Person
        {
          Id = Constants.Person_One_Id,
          FirstName = Constants.Person_One_FirstName,
          LastName = Constants.Person_One_LastName,
          Headline = Constants.Person_One_Headline,
          ApiStandardProfileRequest = new ApiRequest
          {
            Url = Constants.ApiRequest_One_Url,
            Headers = new Collection<HttpHeader>
              {
                new HttpHeader { Name = Constants.HttpHeader_Name, Value = Constants.HttpHeader_Value }
              }
          },
          SiteStandardProfileUrl = new SiteRequest
          {
            Url = Constants.SiteRequest_One_Url
          }
        }
      };

      XmlReader reader = XmlTextReader.Create(new StringReader(shareContentResponse));
      target.ReadXml(reader);

      Assert.AreEqual(expected.SequenceNumber, target.SequenceNumber);
      Assert.AreEqual(expected.Comment, target.Comment);
      Assert.AreEqual(expected.Person.Id, target.Person.Id);
    }

    [Test]
    public void WriteXmlTest()
    {
      UpdateComment target = new UpdateComment
      {
        Comment = Constants.UpdateComment_One_Comment
      };

      string actual = LinkedIn.Tests.Utility.WriteXml(target);

      Assert.AreEqual(this.shareContentRequest, actual);
    }
  }
}
