//-----------------------------------------------------------------------
// <copyright file="CurrentStatusTest.cs" company="Beemway">
//     Copyright (c) Beemway. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using LinkedIn.Tests;
using NUnit.Framework;

namespace LinkedIn.ServiceEntities.Tests
{
    /// <summary>
    ///     This is a test class for CurrentStatusTest and is intended
    ///     to contain all CurrentStatusTest Unit Tests
    /// </summary>
    [TestFixture]
    public class CurrentStatusTest
    {
        private readonly string currentStatusRequestFormat = @"<current-status>{0}</current-status>";

        private readonly string currentStatusRequest = string.Empty;

        /// <summary>
        ///     Gets or sets the test context which provides
        ///     information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CurrentStatusTest" /> class.
        /// </summary>
        public CurrentStatusTest()
        {
            currentStatusRequest = string.Format(currentStatusRequestFormat,
                                                 Constants.NetworkStatus);
        }

        /// <summary>
        ///     A test for WriteXml
        /// </summary>
        [Test]
        public void WriteXmlTest()
        {
            CurrentStatus target = new CurrentStatus
                {
                    Status = Constants.NetworkStatus
                };

            string actual = LinkedIn.Tests.Utility.WriteXml(target);

            Assert.AreEqual(currentStatusRequest, actual);
        }
    }
}