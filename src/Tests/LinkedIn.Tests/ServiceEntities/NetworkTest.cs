//-----------------------------------------------------------------------
// <copyright file="NetworkTest.cs" company="Beemway">
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
  /// This is a test class for NetworkTest and is intended
  /// to contain all NetworkTest Unit Tests
  /// </summary>
  [TestFixture]
  public class NetworkTest
  {
    private readonly string networkRequestFormat = @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?><network><network-stats total=""2""><property key=""degree-1-count"">{0}</property><property key=""degree-2-count"">{1}</property></network-stats><updates total=""{2}"" start=""1"" count=""{2}"">{3}{4}{5}</updates></network>";

    private TestContext testContextInstance;
    private string networkRequest = string.Empty;

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
    /// Initializes a new instance of the <see cref="NetworkTest"/> class.
    /// </summary>
    public NetworkTest()
    {
      networkRequest = string.Format(this.networkRequestFormat,
        Constants.NetworkStatsDegreeOne,
        Constants.NetworkStatsDegreeTwo,
        Constants.NumberOfUpdates,
        Constants.Update_CONN_One,
        Constants.Update_STAT_One,
        Constants.Update_JGRP_One);
    }

    /// <summary>
    /// A test for Deserialization.
    /// </summary>
    [Test]
    public void DeserializeTest()
    {
      Collection<NetworkStatsProperty> networkStats = new Collection<NetworkStatsProperty>();
      networkStats.Add(new NetworkStatsProperty
      {
        Key = "degree-1-count",
        Value = Constants.NetworkStatsDegreeOne.ToString()
      });
      networkStats.Add(new NetworkStatsProperty
      {
        Key = "degree-2-count",
        Value = Constants.NetworkStatsDegreeTwo.ToString()
      });

      Updates updates = new Updates();
      updates.Items = new Collection<Update>();
      updates.Items.Add(EntitiesConstants.Update_One);
      updates.Items.Add(EntitiesConstants.Update_Two);
      updates.Items.Add(EntitiesConstants.Update_Three);
      updates.NumberOfResults = Constants.NumberOfUpdates;

      Network expected = new Network
      {
        NetworkStats = networkStats,
        Updates = updates
      };

      Network actual = LinkedIn.Utility.Utilities.DeserializeXml<Network>(this.networkRequest);

      Assert.AreEqual(expected.Updates.NumberOfResults, actual.Updates.NumberOfResults);
      Assert.AreEqual(expected.Updates.Items[0].UpdateType, actual.Updates.Items[0].UpdateType);
      Assert.AreEqual(expected.Updates.Items[0].UpdateContent.Person.Id, actual.Updates.Items[0].UpdateContent.Person.Id);
      Assert.AreEqual(expected.NetworkStats[0].Value, actual.NetworkStats[0].Value);
    }
  }
}
