using System;
using NUnit.Framework;

namespace NW.MarkdownTabulizer.UnitTests
{
    [TestFixture]
    public class MarkdownTabulizerTests
    {

        // Fields

        private static TestCaseData[] toMarkdownTableExceptions =
        {

            // Constructor
            new TestCaseData(
                new TestDelegate( /* action */ ),
                typeof(ArgumentNullException),
                new ArgumentNullException("null_argument_name").Message
                )
			/* ... */

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(toMarkdownTableExceptions))]
        public void Method_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type tyExpected, string strMessage)
        {

            // Arrange
            // Act
            // Assert
            Exception objActual = Assert.Throws(tyExpected, del);
            Assert.AreEqual(strMessage, objActual.Message);

        }

        // TearDown
        // Support methods

    }
}

/*

    Author: rua@sitecore.net
    Last Update: 11.10.2020

*/
