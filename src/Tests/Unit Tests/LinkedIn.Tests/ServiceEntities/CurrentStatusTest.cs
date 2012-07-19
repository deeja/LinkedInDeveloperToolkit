//-----------------------------------------------------------------------
// <copyright file="CurrentStatusTest.cs" company="Beemway">
//     Copyright (c) Beemway. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.ObjectModel;  
using System.IO;
using System.Xml;
using System.Xml.Schema;

using LinkedIn.ServiceEntities;
using LinkedIn.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedIn.ServiceEntities.Tests
{
  /// <summary>
  /// This is a test class for CurrentStatusTest and is intended
  /// to contain all CurrentStatusTest Unit Tests
  /// </summary>
  [TestClass()]
  public class CurrentStatusTest
  {
    private readonly string currentStatusRequestFormat = @"<current-status>{0}</current-status>";

    private TestContext testContextInstance;
    private string currentStatusRequest = string.Empty;

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
    /// Initializes a new instance of the <see cref="CurrentStatusTest"/> class.
    /// </summary>
    public CurrentStatusTest()
    {
      currentStatusRequest = string.Format(this.currentStatusRequestFormat,
        Constants.NetworkStatus);
    }

    /// <summary>
    /// A test for WriteXml
    /// </summary>
    [TestMethod()]
    public void WriteXmlTest()
    {
      CurrentStatus target = new CurrentStatus
      {
        Status = Constants.NetworkStatus
      };

      string actual = LinkedIn.Tests.Utility.WriteXml(target);

      Assert.AreEqual(this.currentStatusRequest, actual);
    }   
  }
}
