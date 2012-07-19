//-----------------------------------------------------------------------
// <copyright file="JobTest.cs" job="Beemway">
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
  /// This is a test class for JobTest and is intended
  /// to contain all JobTest Unit Tests
  /// </summary>
  [TestClass()]
  public class JobTest
  {
    private readonly string jobRequestFormat = @"<job><id>{0}</id><position><title>{1}</title></position><company><name>{2}</name></company></job>";

    private TestContext testContextInstance;
    private string jobRequest = string.Empty;

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
    /// Initializes a new instance of the <see cref="JobTest"/> class.
    /// </summary>
    public JobTest()
    {
      jobRequest = string.Format(this.jobRequestFormat,
        Constants.Job_Id,
        Constants.Position_Title,
        Constants.Company_Name);
    }

    /// <summary>
    /// A test for Deserialization.
    /// </summary>
    [TestMethod()]
    public void DeserializeTest()
    {
      Position position = new Position
      {
        Title = Constants.Position_Title
      };

      Company company = new Company
      {
        Name = Constants.Company_Name
      };

      Job expected = new Job
      {
        Id = Constants.Job_Id,
        Position = position,
        Company = company
      };

      Job actual = LinkedIn.Utility.Utilities.DeserializeXml<Job>(this.jobRequest);

      Assert.AreEqual(expected.Id, actual.Id);
      Assert.AreEqual(expected.Position.Title, actual.Position.Title);
      Assert.AreEqual(expected.Company.Name, actual.Company.Name);
    }
  }
}
