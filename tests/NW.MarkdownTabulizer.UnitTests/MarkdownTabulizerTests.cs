using System;
using NUnit.Framework;

namespace NW.MarkdownTabulizer.UnitTests
{
    [TestFixture]
    public class MarkdownTabulizerTests
    {

        // Fields
        private static TestCaseData[] toMarkdownLineExceptions =
        {

            new TestCaseData(
                new TestDelegate( () => 
                    new MarkdownTabulizer().ToMarkdownLine(false, false, null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("values").Message
                ),

            new TestCaseData(
                new TestDelegate( () =>
                    new MarkdownTabulizer().ToMarkdownLine(false, false, new string[]{ })
                ),
                typeof(ArgumentException),
                MessageCollection.CantHaveZeroItems.Invoke("values")
                )

        };
        private static TestCaseData[] toMarkdownExceptions =
        {

            new TestCaseData(
                new TestDelegate( () =>
                    new MarkdownTabulizer()
                        .ToMarkdown(
                            false,
                            ObjectMother.NonExistantOutputOption, 
                            ObjectMother.Table2_Source_Object
                        )),
                typeof(ArgumentException),
                MessageCollection.ProvidedOutputOptionNotValid.Invoke(ObjectMother.NonExistantOutputOption)
                ),

            new TestCaseData(
                new TestDelegate( () =>
                    new MarkdownTabulizer()
                        .ToMarkdown<Car>(
                            false,
                            OutputOptions.OnlyRow,
                            null
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("obj").Message
                )

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(toMarkdownLineExceptions))]
        public void ToMarkdownLine_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type tyExpected, string strMessage)
        {

            // Arrange
            // Act
            // Assert
            Exception objActual = Assert.Throws(tyExpected, del);
            Assert.AreEqual(strMessage, objActual.Message);

        }

        [TestCaseSource(nameof(toMarkdownExceptions))]
        public void ToMarkdown_ShouldThrowACertainException_WhenUnproperArguments
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
