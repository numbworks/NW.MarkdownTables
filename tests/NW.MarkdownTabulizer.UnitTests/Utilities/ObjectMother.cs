using System;
using System.Collections.Generic;

namespace NW.MarkdownTabulizer.UnitTests
{
    internal static class ObjectMother
    {

        // Fields
        // Properties
        #region Header
        internal static string[] Header_Input 
            = new string[] { "BookTitle", "Year", "Pages", "ReadDate", "Publisher" };
        internal static string Header_Output_SmallerFontSizeTrue = string.Concat(
            "|<sub>BookTitle</sub>|<sub>Year</sub>|<sub>Pages</sub>|<sub>ReadDate</sub>|<sub>Publisher</sub>|",
            Environment.NewLine,
            "|---|---|---|---|---|"
            );
        internal static string Header_Output_SmallerFontSizeFalse = string.Concat(
            "|BookTitle|Year|Pages|ReadDate|Publisher|",
            Environment.NewLine,
            "|---|---|---|---|---|"
            );
        #endregion

        #region Row1
        internal static string[] Row1_Input
            = new string[] { "Learn Powershell Core 6.0", "2018", "736", "2020-04-03", "Packt" };
        internal static string Row1_Output_SmallerFontSizeTrue = string.Concat(
            "|<sub>Learn Powershell Core 6.0</sub>|<sub>2018</sub>|<sub>736</sub>|<sub>2020-04-03</sub>|<sub>Packt</sub>|"
            );
        internal static string Row1_Output_SmallerFontSizeFalse = string.Concat(
            "|Learn Powershell Core 6.0|2018|736|2020-04-03|Packt|"
            );
        #endregion

        #region Table1
        internal static Car Table1_Input_Object = new Car() { Name = "Dodge Ram", Wheels = 4 };
        internal static string Table1_OnlyHeaderSmallerFontSizeTrue = string.Concat(
            "|<sub>Name</sub>|<sub>Wheels</sub>|",
            Environment.NewLine,
            "|---|---|"
            );
        internal static string Table1_OnlyHeaderSmallerFontSizeFalse = string.Concat(
            "|Name|Wheels|",
            Environment.NewLine,
            "|---|---|"
            );
        internal static string Table1_OnlyRowSmallerFontSizeTrue = string.Concat(
            "|<sub>Dodge Ram</sub>|<sub>4</sub>|"
            );
        internal static string Table1_OnlyRowSmallerFontSizeFalse = string.Concat(
            "|Dodge Ram|4|"
            );
        internal static string Table1_FullTableSmallerFontSizeTrue = string.Concat(
            "|<sub>Name</sub>|<sub>Wheels</sub>|",
            Environment.NewLine,
            "|---|---|",
            Environment.NewLine,
            "|<sub>Dodge Ram</sub>|<sub>4</sub>|"
            );
        internal static string Table1_FullTableSmallerFontSizeFalse = string.Concat(
            "|Name|Wheels|",
            Environment.NewLine,
            "|---|---|",
            Environment.NewLine,
            "|Dodge Ram|4|"
            );
        #endregion
        
        #region Table2
        internal static List<Car> Table2_Input_List = new List<Car>()
            {

                new Car()
                    {
                        Name = "Dodge Ram",
                        Wheels = 4
                    },
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
        internal static string Table2_OnlyHeaderSmallerFontSizeTrue = string.Concat(
            "|Name|Wheels|",
            "|---|---|"
            );
        internal static string Table2_OnlyHeaderSmallerFontSizeFalse = string.Concat(
            "|<sub>Name</sub>|<sub>Wheels</sub>|",
            "|---|---|"
            );
        internal static string Table2_OnlyRowSmallerFontSizeTrue = string.Concat(
            "|Dodge Ram|4|",
            Environment.NewLine,
            "|Nissan Skyline|4|",
            Environment.NewLine,
            "|null|4|",
            Environment.NewLine,
            "|null|null|"
            );
        internal static string Table2_OnlyRowSmallerFontSizeFalse = string.Concat(
            "|<sub>Dodge Ram</sub>|<sub>4</sub>|",
            Environment.NewLine,
            "|<sub>Nissan Skyline</sub>|<sub>4</sub>|",
            Environment.NewLine,
            "|<sub>null</sub>|<sub>4</sub>|",
            Environment.NewLine,
            "|<sub>null</sub>|<sub>null</sub>|"
            );
        internal static string Table2_FullTableSmallerFontSizeTrue = string.Concat(
            "|Name|Wheels|",
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
        internal static string Table2_FullTableSmallerFontSizeFalse = string.Concat(
            "|<sub>Name</sub>|<sub>Wheels</sub>|",
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
        #endregion

        internal static NullHandlingStrategies NonExistantNullHandlingStrategy = (NullHandlingStrategies)(-1);

        // Methods (public)
        // Methods (private)

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 11.10.2020

*/
