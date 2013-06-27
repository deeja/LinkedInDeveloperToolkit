//-----------------------------------------------------------------------
// <copyright file="QueryStringParametersTest.cs" company="Beemway">
//     Copyright (c) Beemway. All rights reserved.
// </copyright>
// <license>
//     Microsoft Public License (Ms-PL http://opensource.org/licenses/ms-pl.html).
//     Contributors may add their own copyright notice above.
// </license>
//-----------------------------------------------------------------------

using System;
using LinkedIn;
using NUnit.Framework;


namespace LinkedIn.Tests
{  
  /// <summary>
  /// This is a test class for QueryStringParametersTest and is intended
  /// to contain all QueryStringParametersTest Unit Tests
  ///</summary>
  [TestFixture]
  public class QueryStringParametersTest
  {
    private TestContext testContextInstance;

    /// <summary>
    /// Gets or sets the test context which provides
    /// information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    #region Additional test attributes
    // 
    //You can use the following additional attributes as you write your tests:
    //
    //Use ClassInitialize to run code before running the first test in the class
    //[ClassInitialize()]
    //public static void MyClassInitialize(TestContext testContext)
    //{
    //}
    //
    //Use ClassCleanup to run code after all tests in a class have run
    //[ClassCleanup()]
    //public static void MyClassCleanup()
    //{
    //}
    //
    //Use TestInitialize to run code before running each test
    //[TestInitialize()]
    //public void MyTestInitialize()
    //{
    //}
    //
    //Use TestCleanup to run code after each test has run
    //[TestCleanup()]
    //public void MyTestCleanup()
    //{
    //}
    //
    #endregion
    
    /// <summary>
    /// A test for adding a string parameter value.
    ///</summary>
    [Test]
    
    public void Add_String_Test()
    {
      QueryStringParameters target = new QueryStringParameters();
      string name = Constants.QueryStringParam1;
      string value = Constants.QueryStringValue1;
      target.Add(name, value);

      Assert.IsNotNull(target[name]);
    }

    /// <summary>
    /// A test for adding a invalid string parameter value.
    ///</summary>
    [Test]
    
    public void Add_InvalidString_Test()
    {
      QueryStringParameters target = new QueryStringParameters();
      string name = Constants.QueryStringParam1;
      string value = string.Empty;
      target.Add(name, value);

      Assert.IsNull(target[name]);
    }

    /// <summary>
    /// A test for adding a boolean parameter value.
    ///</summary>
    [Test]
    
    public void Add_Boolean_Test()
    {
      QueryStringParameters target = new QueryStringParameters();
      string name = string.Empty;
      bool value = false;
      target.Add(name, value);

      Assert.IsNotNull(target[name]);
    }

    /// <summary>
    /// A test for adding a integer parameter value.
    ///</summary>
    [Test]
    
    public void Add_Int_Test()
    {
      QueryStringParameters target = new QueryStringParameters();
      string name = string.Empty;
      int value = 1;
      target.Add(name, value);

      Assert.IsNotNull(target[name]);
    }

    /// <summary>
    /// A test for adding a invalid integer parameter value.
    ///</summary>
    [Test]
    
    public void Add_InvalidInt_Test()
    {
      QueryStringParameters target = new QueryStringParameters();
      string name = Constants.QueryStringParam1;
      int value = -1;
      target.Add(name, value);

      Assert.IsNull(target[name]);
    }

    /// <summary>
    /// A test for AppendToUri
    ///</summary>
    [Test]
    
    public void AppendToUriTest()
    {
        throw new NotImplementedException();
      /*UriBuilder location = new UriBuilder(Constants.ApiBaseUrl);
      target.Add(Constants.QueryStringParam1, Constants.QueryStringValue1);
      target.Add(Constants.QueryStringParam1, Constants.QueryStringValue2);

      UriBuilder expected = location;
      expected.Query = string.Format("?{0}={1}&{2}={3}",
        Constants.QueryStringParam1,
        Constants.QueryStringValue1,
        Constants.QueryStringParam2,
        Constants.QueryStringValue2);

      UriBuilder actual = target.AppendToUri(location);
      Assert.AreEqual(expected, actual);*/
    }
  }
}
