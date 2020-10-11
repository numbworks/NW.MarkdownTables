using System;
using System.Collections.Generic;

namespace NW.MarkdownTabulizer.UnitTests
{
    internal static class ObjectMother
    {

        // Fields
        // Properties
        internal static string[] ArrayHeader1
            = new string[] { "BookTitle", "Year", "Pages", "ReadDate", "Publisher" };
        internal static string ArrayHeader1_SmallerFontSizeTrue = string.Concat(
            "|<sub>BookTitle</sub>|<sub>Year</sub>|<sub>Pages</sub>|<sub>ReadDate</sub>|<sub>Publisher</sub>|",
            Environment.NewLine,
            "|---|---|---|---|---|"
            );
        internal static string ArrayHeader1_SmallerFontSizeFalse = string.Concat(
            "|BookTitle|Year|Pages|ReadDate|Publisher|",
            Environment.NewLine,
            "|---|---|---|---|---|"
            );

        internal static string[] ArrayRow1
            = new string[] { "Learn Powershell Core 6.0", "2018", "736", "2020-04-03", "Packt" };
        internal static string ArrayRow1_SmallerFontSizeTrue = string.Concat(
            "|<sub>Learn Powershell Core 6.0</sub>|<sub>2018</sub>|<sub>736</sub>|<sub>2020-04-03</sub>|<sub>Packt</sub>|"
            );
        internal static string ArrayRow1_SmallerFontSizeFalse = string.Concat(
            "|Learn Powershell Core 6.0|2018|736|2020-04-03|Packt|"
            );

        internal static Car Object1 = new Car() { Name = "Dodge Ram", Wheels = 4 };
        internal static string Object1_HeaderSmallerFontSizeTrue = string.Concat(
            "|<sub>Name</sub>|<sub>Wheels</sub>|",
            Environment.NewLine,
            "|---|---|"
            );
        internal static string Object1_HeaderSmallerFontSizeFalse = string.Concat(
            "|Name|Wheels|",
            Environment.NewLine,
            "|---|---|"
            );
        internal static string Object1_RowSmallerFontSizeTrue = string.Concat(
            "|<sub>Dodge Ram</sub>|<sub>4</sub>|"
            );
        internal static string Object1_RowSmallerFontSizeFalse = string.Concat(
            "|Dodge Ram|4|"
            );
        internal static string Object1_TableSmallerFontSizeTrue = string.Concat(
            "|<sub>Name</sub>|<sub>Wheels</sub>|",
            Environment.NewLine,
            "|---|---|",
            Environment.NewLine,
            "|<sub>Dodge Ram</sub>|<sub>4</sub>|"
            );
        internal static string Object1_TableSmallerFontSizeFalse = string.Concat(
            "|Name|Wheels|",
            Environment.NewLine,
            "|---|---|",
            Environment.NewLine,
            "|Dodge Ram|4|"
            );

        internal static NullHandlingStrategies NonExistantNullHandlingStrategy = (NullHandlingStrategies)(-1);
        internal static List<Car> List1 = new List<Car>()
            {

                Object1,
                new Car()
                    {
                        Name = "Nissan Skyline",
                        Wheels = 4
                    },
                new Car()
                    {
                        Name = null,
                        Wheels = 4
                    },
                null

            };
        internal static string List1_TableSmallerFontSizeTrueRemoveNulls = string.Concat(
            "|<sub>Name</sub>|<sub>Wheels</sub>|",
            Environment.NewLine,
            "|---|---|",
            Environment.NewLine,
            "|<sub>Dodge Ram</sub>|<sub>4</sub>|",
            Environment.NewLine,
            "|<sub>Nissan Skyline</sub>|<sub>4</sub>|",
            Environment.NewLine,
            "|<sub>null</sub>|<sub>4</sub>|"
            );
        internal static string List1_TableSmallerFontSizeFalseRemoveNulls = string.Concat(
            "|Name|Wheels|",
            Environment.NewLine,
            "|---|---|",
            Environment.NewLine,
            "|Dodge Ram|4|",
            Environment.NewLine,
            "|Nissan Skyline|4|",
            Environment.NewLine,
            "|null|4|"
            );
        internal static string List1_TableSmallerFontSizeTrueReplaceNulls = string.Concat(
            "|<sub>Name</sub>|<sub>Wheels</sub>|",
            Environment.NewLine,
            "|---|---|",
            Environment.NewLine,
            "|<sub>Dodge Ram</sub>|<sub>4</sub>|",
            Environment.NewLine,
            "|<sub>Nissan Skyline</sub>|<sub>4</sub>|",
            Environment.NewLine,
            "|<sub>null</sub>|<sub>4</sub>|",
            Environment.NewLine,
            "|<sub>null</sub>|<sub>null</sub>|"
            );
        internal static string List1_TableSmallerFontSizeFalseReplaceNulls = string.Concat(
            "|Name|Wheels|",
            Environment.NewLine,
            "|---|---|",
            Environment.NewLine,
            "|Dodge Ram|4|",
            Environment.NewLine,
            "|Nissan Skyline|4|",
            Environment.NewLine,
            "|null|4|",
            Environment.NewLine,
            "|null|null|"
            );

        // Methods (public)
        // Methods (private)

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 11.10.2020

*/
