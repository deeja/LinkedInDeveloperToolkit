//-----------------------------------------------------------------------
// <copyright file="ConnectionsTest.cs" company="Beemway">
//     Copyright (c) Beemway. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.ObjectModel;  
using System.IO;
using System.Xml;
using System.Xml.Schema;

using LinkedIn.ServiceEntities;
using LinkedIn.Tests;
using NUnit.Framework;


namespace LinkedIn.ServiceEntities.Tests
{
  /// <summary>
  /// This is a test class for ConnectionsTest and is intended
  /// to contain all ConnectionsTest Unit Tests
  /// </summary>
  [TestFixture]
  public class ConnectionsTest
  {
    private readonly string connectionsRequestFormat = @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?><connections total=""2"">{0}{1}</connections>";

    private TestContext testContextInstance;
    private string connectionsRequest = string.Empty;

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
    /// Initializes a new instance of the <see cref="ConnectionsTest"/> class.
    /// </summary>
    public ConnectionsTest()
    {
      connectionsRequest = string.Format(this.connectionsRequestFormat,
        Constants.Person_Simple_One_Xml,
        Constants.Person_Simple_Two_Xml);
    }

    /// <summary>
    /// A test for Deserialization.
    /// </summary>
    [Test]
    public void DeserializeTest()
    {
      Collection<Person> connectionItems = new Collection<Person>();
      connectionItems.Add(EntitiesConstants.Person_Simple_One);
      connectionItems.Add(EntitiesConstants.Person_Simple_Two);

      Connections expected = new Connections
      {
        Items = connectionItems,
      };

      Connections actual = LinkedIn.Utility.Utilities.DeserializeXml<Connections>(this.connectionsRequest);

      Assert.AreEqual(expected.NumberOfResults, actual.NumberOfResults);
      Assert.AreEqual(expected.Items[0].FirstName, actual.Items[0].FirstName);
      Assert.AreEqual(expected.Items[0].SiteStandardProfileUrl.Url, actual.Items[0].SiteStandardProfileUrl.Url);
    }
  }
}
