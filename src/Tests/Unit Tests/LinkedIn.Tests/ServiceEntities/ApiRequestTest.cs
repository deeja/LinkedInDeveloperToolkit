//-----------------------------------------------------------------------
// <copyright file="ApiRequestTest.cs" company="Beemway">
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
  /// This is a test class for ApiRequestTest and is intended
  /// to contain all ApiRequestTest Unit Tests
  /// </summary>
  [TestFixture]
  public class ApiRequestTest
  {
    private readonly string apiRequestRequestFormat = @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?><api-standard-profile-request><url>{0}</url><headers total=""1""><http-header><name>{1}</name><value>{2}</value></http-header></headers></api-standard-profile-request>";

    private TestContext testContextInstance;
    private string apiRequestRequest = string.Empty;

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
    /// Initializes a new instance of the <see cref="ApiRequestTest"/> class.
    /// </summary>
    public ApiRequestTest()
    {
      apiRequestRequest = string.Format(this.apiRequestRequestFormat, 
        Constants.ApiRequest_One_Url, 
        Constants.HttpHeader_Name, 
        Constants.HttpHeader_Value);
    }

    /// <summary>
    /// A test for Deserialization.
    /// </summary>
    [Test]
    public void DeserializeTest()
    {
      ApiRequest expected = EntitiesConstants.ApiRequest_One;

      ApiRequest actual = LinkedIn.Utility.Utilities.DeserializeXml<ApiRequest>(this.apiRequestRequest);

      Assert.AreEqual(expected.Url, actual.Url);
      Assert.AreEqual(expected.Headers[0].Value, actual.Headers[0].Value);
    }   
    
  }
}
