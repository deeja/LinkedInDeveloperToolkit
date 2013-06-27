//-----------------------------------------------------------------------
// <copyright file="ActivityTest.cs" company="Beemway">
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
  /// This is a test class for ActivityTest and is intended
  /// to contain all ActivityTest Unit Tests
  /// </summary>
  [TestFixture]
  public class ActivityTest
  {
    private readonly string activityResponseFormat = @"<activity>
              <body>{0}</body>
              <app-id>{1}</app-id>
            </activity>";

    private readonly string activityRequestFormat = @"<activity locale=""{0}""><content-type>linkedin-html</content-type><body>{1}</body></activity>";

    private TestContext testContextInstance;
    private string activityResponse = string.Empty;    
    private string activityRequest = string.Empty;

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
    /// Initializes a new instance of the <see cref="ActivityTest"/> class.
    /// </summary>
    public ActivityTest()
    {
      activityResponse = string.Format(this.activityResponseFormat, SecurityElement.Escape(Constants.Activity_Body), Constants.Activity_AppId);
      activityRequest = string.Format(this.activityRequestFormat, Constants.Activity_CultureName, LinkedIn.Tests.Utility.EscapeXml(Constants.Activity_Body));
    }

    /// <summary>
    /// A test for ReadXml
    /// </summary>
    [Test]
    public void ReadXmlTest()
    {
      Activity target = new Activity();
      Activity expected = new Activity
      {
        Body = Constants.Activity_Body,
        AppId = Constants.Activity_AppId
      };

      XmlReader reader = XmlTextReader.Create(new StringReader(activityResponse));
      target.ReadXml(reader);

      Assert.AreEqual(expected.Body, target.Body);
      Assert.AreEqual(expected.AppId, target.AppId);
    }

    /// <summary>
    /// A test for WriteXml
    /// </summary>
    [Test]
    public void WriteXmlTest()
    {
      Activity target = new Activity
      {
        Body = Constants.Activity_Body,
        CultureName = Constants.Activity_CultureName
      };

      string actual = LinkedIn.Tests.Utility.WriteXml(target);

      Assert.AreEqual(this.activityRequest, actual);
    }
  }
}
