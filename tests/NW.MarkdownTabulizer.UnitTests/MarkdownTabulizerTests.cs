using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NW.MarkdownTabulizer.UnitTests
{
    [TestFixture]
    public class MarkdownTabulizerTests
    {

        // Fields
        private static TestCaseData[] toMarkdownRowExceptions =
        {

            new TestCaseData(
                new TestDelegate( () => 
                    new MarkdownTabulizer().ToMarkdownRow(false, null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("values").Message
                ),

            new TestCaseData(
                new TestDelegate( () =>
                    new MarkdownTabulizer().ToMarkdownRow(false, new string[]{ })
                ),
                typeof(ArgumentException),
                MessageCollection.CantHaveZeroItems.Invoke("values")
                )

        };
        private static TestCaseData[] toMarkdownHeaderExceptions =
        {

            new TestCaseData(
                new TestDelegate( () =>
                    new MarkdownTabulizer().ToMarkdownHeader(false, null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("values").Message
                ),

            new TestCaseData(
                new TestDelegate( () =>
                    new MarkdownTabulizer().ToMarkdownHeader(false, new string[]{ })
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
        private static TestCaseData[] toMarkdownHeaderTestCases =
        {

            new TestCaseData( 
                    true,
                    ObjectMother.Line_Input_Header,
                    ObjectMother.Line_Output_SmallerFontSizeTrueIsHeaderTrue
                ),

            new TestCaseData(
                    false,
                    ObjectMother.Line_Input_Header,
                    ObjectMother.Line_Output_SmallerFontSizeFalseIsHeaderTrue
                )

        };
        private static TestCaseData[] toMarkdownRowTestCases =
        {

            new TestCaseData(
                    true,
                    ObjectMother.Line_Input_Row1,
                    ObjectMother.Line_Output_SmallerFontSizeTrueIsHeaderFalse
                ),

            new TestCaseData(
                    false,
                    ObjectMother.Line_Input_Row1,
                    ObjectMother.Line_Output_SmallerFontSizeFalseIsHeaderFalse
                )

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(toMarkdownRowExceptions))]
        public void ToMarkdownRow_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type tyExpected, string strMessage)
        {

            // Arrange
            // Act
            // Assert
            Exception objActual = Assert.Throws(tyExpected, del);
            Assert.AreEqual(strMessage, objActual.Message);

        }

        [TestCaseSource(nameof(toMarkdownHeaderExceptions))]
        public void ToMarkdownHeader_ShouldThrowACertainException_WhenUnproperArguments
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

        [TestCaseSource(nameof(toMarkdownHeaderTestCases))]
        public void ToMarkdownHeader_ShouldReturnExpectedString_WhenProperArguments
            (bool smallerFontSize, string[] values, string expected)
        {

            // Arrange
            // Act
            string actual = new MarkdownTabulizer().ToMarkdownHeader(smallerFontSize, values);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestCaseSource(nameof(toMarkdownRowTestCases))]
        public void ToMarkdownRow_ShouldReturnExpectedString_WhenProperArguments
            (bool smallerFontSize, string[] values, string expected)
        {

            // Arrange
            // Act
            string actual = new MarkdownTabulizer().ToMarkdownRow(smallerFontSize, values);

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
