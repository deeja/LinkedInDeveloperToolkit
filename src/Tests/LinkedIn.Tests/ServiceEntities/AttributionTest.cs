//-----------------------------------------------------------------------
// <copyright file="AttributionTest.cs" company="Beemway">
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
  /// This is a test class for AttributionTest and is intended
  /// to contain all AttributionTest Unit Tests
  /// </summary>
  [TestFixture]
  public class AttributionTest
  {
    private readonly string attributionRequestFormat = @"<attribution><share><id>{0}</id></share></attribution>";

    private TestContext testContextInstance;
    private string attributionRequest = string.Empty;

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
    /// Initializes a new instance of the <see cref="AttributionTest"/> class.
    /// </summary>
    public AttributionTest()
    {
      attributionRequest = string.Format(
        this.attributionRequestFormat, 
        Constants.Share_One_Id);
    }

    [Test]
    public void WriteXmlTest()
    {
      Attribution target = new Attribution
      {
        Share = new Share
        {
          Id = Constants.Share_One_Id
        }
      };

      string actual = LinkedIn.Tests.Utility.WriteXml(target);

      Assert.AreEqual(this.attributionRequest, actual);
    }
  }
}
