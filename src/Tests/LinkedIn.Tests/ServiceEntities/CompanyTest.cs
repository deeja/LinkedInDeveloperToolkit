//-----------------------------------------------------------------------
// <copyright file="CompanyTest.cs" company="Beemway">
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
  /// This is a test class for CompanyTest and is intended
  /// to contain all CompanyTest Unit Tests
  /// </summary>
  [TestFixture]
  public class CompanyTest
  {
    private readonly string companyRequestFormat = @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?><company><id>{0}</id><name>{1}</name><company-type><code>{2}</code><name>{3}</name></company-type></company>";

    private TestContext testContextInstance;
    private string companyRequest = string.Empty;

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
    /// Initializes a new instance of the <see cref="CompanyTest"/> class.
    /// </summary>
    public CompanyTest()
    {
      companyRequest = string.Format(this.companyRequestFormat,
        Constants.Company_Id,
        Constants.Company_Name,
        Constants.CompanyType_Code,
        Constants.CompanyType_Name);
    }

    /// <summary>
    /// A test for Deserialization.
    /// </summary>
    [Test]
    public void DeserializeTest()
    {
      CompanyType companyType = new CompanyType
      {
        Code = Constants.CompanyType_Code,
        Name = Constants.CompanyType_Name
      };

      Company expected = new Company
      {        
        Id = Constants.Company_Id,
        Name = Constants.Company_Name,
        Type = companyType
      };

      Company actual = LinkedIn.Utility.Utilities.DeserializeXml<Company>(this.companyRequest);

      Assert.AreEqual(expected.Id, actual.Id);
      Assert.AreEqual(expected.Name, actual.Name);
      Assert.AreEqual(expected.Type.Code, actual.Type.Code);
    }    
  }
}
