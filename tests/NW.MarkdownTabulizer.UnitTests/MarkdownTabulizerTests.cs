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

            // ToMarkdownRow()
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
                ),

            // ToMarkdownRow<T>()
            new TestCaseData(
                new TestDelegate( () =>
                    new MarkdownTabulizer().ToMarkdownRow<Car>(false, null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("obj").Message
                )

        };
        private static TestCaseData[] toMarkdownHeaderExceptions =
        {

            // ToMarkdownHeader()
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
                ),

            // ToMarkdownHeader<T>()
            new TestCaseData(
                new TestDelegate( () =>
                    new MarkdownTabulizer().ToMarkdownHeader<Car>(false, null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("obj").Message
                )

        };
        private static TestCaseData[] toMarkdownTableExceptions =
        {

            // ToMarkdownTable<T>()
            new TestCaseData(
                new TestDelegate( () =>
                    new MarkdownTabulizer().ToMarkdownTable<Car>(false, null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("obj").Message
                ),

            // ToMarkdownTable<T>(..., rows)
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
                    ObjectMother.Header_Input,
                    ObjectMother.Header_Output_SmallerFontSizeTrue
                ),

            new TestCaseData(
                    false,
                    ObjectMother.Header_Input,
                    ObjectMother.Header_Output_SmallerFontSizeFalse
                )

        };
        private static TestCaseData[] toMarkdownRowTestCases =
        {

            new TestCaseData(
                    true,
                    ObjectMother.Row1_Input,
                    ObjectMother.Row1_Output_SmallerFontSizeTrue
                ),

            new TestCaseData(
                    false,
                    ObjectMother.Row1_Input,
                    ObjectMother.Row1_Output_SmallerFontSizeFalse
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
