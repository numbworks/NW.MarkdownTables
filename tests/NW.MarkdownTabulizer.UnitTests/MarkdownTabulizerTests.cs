using System;
using System.Collections.Generic;
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
                            ObjectMother.Table1_Input_Object
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
        private static TestCaseData[] toMarkdownTableExceptions =
        {

            new TestCaseData(
                new TestDelegate( () =>
                    new MarkdownTabulizer()
                        .ToMarkdownTable(
                            false,
                            ObjectMother.NonExistantNullHandlingStrategy,
                            ObjectMother.Table2_Input_List
                        )),
                typeof(ArgumentException),
                MessageCollection.ProvidedNullHandlingStrategyNotValid.Invoke(ObjectMother.NonExistantNullHandlingStrategy)
                ),

            new TestCaseData(
                new TestDelegate( () =>
                    new MarkdownTabulizer()
                        .ToMarkdownTable<Car>(
                            false,
                            NullHandlingStrategies.RemoveNulls,
                            null
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("rows").Message
                ),

            new TestCaseData(
                new TestDelegate( () =>
                    new MarkdownTabulizer()
                        .ToMarkdownTable(
                            false,
                            NullHandlingStrategies.RemoveNulls,
                            new List<Car>() { }
                        )),
                typeof(ArgumentException),
                MessageCollection.CantHaveZeroItems.Invoke("rows")
                )

        };
        private static TestCaseData[] toMarkdownLineTestCases =
        {

            new TestCaseData( 
                    true,
                    true,
                    ObjectMother.Line_Input_Header,
                    ObjectMother.Line_Output_SmallerFontSizeTrueIsHeaderTrue
                ),

            new TestCaseData(
                    false,
                    true,
                    ObjectMother.Line_Input_Header,
                    ObjectMother.Line_Output_SmallerFontSizeFalseIsHeaderTrue
                ),

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

        [TestCaseSource(nameof(toMarkdownTableExceptions))]
        public void ToMarkdownTable_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type tyExpected, string strMessage)
        {

            // Arrange
            // Act
            // Assert
            Exception objActual = Assert.Throws(tyExpected, del);
            Assert.AreEqual(strMessage, objActual.Message);

        }

        [TestCaseSource(nameof(toMarkdownLineTestCases))]
        public void ToMarkdownLine_ShouldReturnExpectedString_WhenProperArguments
            (bool smallerFontSize, bool isHeader, string[] values, string expected)
        {

            // Arrange
            // Act
            string actual = new MarkdownTabulizer().ToMarkdownLine(smallerFontSize, isHeader, values);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        // TearDown
        // Support methods

    }
}

/*

    Author: rua@sitecore.net
    Last Update: 11.10.2020

*/
