using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NW.MarkdownTables.UnitTests
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
                            ObjectMother.List1
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
                ),

            new TestCaseData(
                new TestDelegate( () =>
                    new MarkdownTabulizer()
                        .ToMarkdownTable(
                            false,
                            NullHandlingStrategies.DoNothing,
                            ObjectMother.List1
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("obj").Message
                )

        };
        private static TestCaseData[] toMarkdownRowTestCases =
        {

            new TestCaseData(
                    true,
                    ObjectMother.ArrayRow1,
                    ObjectMother.ArrayRow1_SmallerFontSizeTrue
                ),

            new TestCaseData(
                    false,
                    ObjectMother.ArrayRow1,
                    ObjectMother.ArrayRow1_SmallerFontSizeFalse
                )

        };
        private static TestCaseData[] toMarkdownRowTypeTTestCases =
        {

            new TestCaseData(
                    true,
                    ObjectMother.Object1,
                    ObjectMother.Object1_RowSmallerFontSizeTrue
                ),

            new TestCaseData(
                    false,
                    ObjectMother.Object1,
                    ObjectMother.Object1_RowSmallerFontSizeFalse
                ),

        };
        private static TestCaseData[] toMarkdownHeaderTestCases =
        {

            new TestCaseData(
                    true,
                    ObjectMother.ArrayHeader1,
                    ObjectMother.ArrayHeader1_SmallerFontSizeTrue
                ),

            new TestCaseData(
                    false,
                    ObjectMother.ArrayHeader1,
                    ObjectMother.ArrayHeader1_SmallerFontSizeFalse
                )

        };
        private static TestCaseData[] toMarkdownHeaderTypeTTestCases =
        {

            new TestCaseData(
                    true,
                    ObjectMother.Object1,
                    ObjectMother.Object1_HeaderSmallerFontSizeTrue
                ),

            new TestCaseData(
                    false,
                    ObjectMother.Object1,
                    ObjectMother.Object1_HeaderSmallerFontSizeFalse
                ),

        };
        private static TestCaseData[] toMarkdownTableObjectTestCases =
        {

            new TestCaseData(
                    true,
                    ObjectMother.Object1,
                    ObjectMother.Object1_TableSmallerFontSizeTrue
                ),

            new TestCaseData(
                    false,
                    ObjectMother.Object1,
                    ObjectMother.Object1_TableSmallerFontSizeFalse
                ),

        };
        private static TestCaseData[] toMarkdownTableListTestCases =
        {

            new TestCaseData(
                    true,
                    NullHandlingStrategies.RemoveNulls,
                    ObjectMother.List1,
                    ObjectMother.List1_TableSmallerFontSizeTrueRemoveNulls
                ),

            new TestCaseData(
                    false,
                    NullHandlingStrategies.RemoveNulls,
                    ObjectMother.List1,
                    ObjectMother.List1_TableSmallerFontSizeFalseRemoveNulls
                ),

            new TestCaseData(
                    true,
                    NullHandlingStrategies.ReplaceNullsWithNullMarkdownLines,
                    ObjectMother.List1,
                    ObjectMother.List1_TableSmallerFontSizeTrueReplaceNulls
                ),

            new TestCaseData(
                    false,
                    NullHandlingStrategies.ReplaceNullsWithNullMarkdownLines,
                    ObjectMother.List1,
                    ObjectMother.List1_TableSmallerFontSizeFalseReplaceNulls
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

        [TestCaseSource(nameof(toMarkdownRowTypeTTestCases))]
        public void ToMarkdownRowTypeT_ShouldReturnExpectedString_WhenProperArguments<T>
            (bool smallerFontSize, T obj, string expected)
        {

            // Arrange
            // Act
            string actual = new MarkdownTabulizer().ToMarkdownRow(smallerFontSize, obj);

            // Assert
            Assert.AreEqual(expected, actual);

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

        [TestCaseSource(nameof(toMarkdownHeaderTypeTTestCases))]
        public void ToMarkdownHeaderTypeT_ShouldReturnExpectedString_WhenProperArguments<T>
            (bool smallerFontSize, T obj, string expected)
        {

            // Arrange
            // Act
            string actual = new MarkdownTabulizer().ToMarkdownHeader(smallerFontSize, obj);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestCaseSource(nameof(toMarkdownTableObjectTestCases))]
        public void ToMarkdownTableObject_ShouldReturnExpectedString_WhenProperArguments<T>
            (bool smallerFontSize, T obj, string expected)
        {

            // Arrange
            // Act
            string actual = new MarkdownTabulizer().ToMarkdownTable(smallerFontSize, obj);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestCaseSource(nameof(toMarkdownTableListTestCases))]
        public void ToMarkdownTableList_ShouldReturnExpectedString_WhenProperArguments<T>
            (bool smallerFontSize, NullHandlingStrategies strategy, List<T> rows, string expected)
        {

            // Arrange
            // Act
            string actual = new MarkdownTabulizer().ToMarkdownTable(smallerFontSize, strategy, rows);

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
