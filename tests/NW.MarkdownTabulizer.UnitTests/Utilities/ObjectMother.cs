using System;
using System.Collections.Generic;

namespace NW.MarkdownTabulizer.UnitTests
{
    internal static class ObjectMother
    {

        // Fields
        // Properties
        #region Table1
        internal static string[] Table1_Source_Header 
            = new string[] { "BookTitle", "Year", "Pages", "ReadDate", "Publisher" };
        internal static string[] Table1_Source_Row1 
            = new string[] { "Learn Powershell Core 6.0", "2018", "736", "2020-04-03", "Packt" };
        internal static string Table1_SmallerFontSizeTrue_OnlyHeader = string.Concat(
            "|<sub>BookTitle</sub>|<sub>Year</sub>|<sub>Pages</sub>|<sub>ReadDate</sub>|<sub>Publisher</sub>|",
            Environment.NewLine,
            "|---|---|---|---|---|"
            );
        internal static string Table1_SmallerFontSizeTrue_OnlyRow = string.Concat(
            "|<sub>Learn Powershell Core 6.0</sub>|<sub>2018</sub>|<sub>736</sub>|<sub>2020-04-03</sub>|<sub>Packt</sub>|"
            );
        internal static string Table1_SmallerFontSizeTrue_FullTable = string.Concat(
            "|<sub>BookTitle</sub>|<sub>Year</sub>|<sub>Pages</sub>|<sub>ReadDate</sub>|<sub>Publisher</sub>|",
            Environment.NewLine,
            "|---|---|---|---|---|",
            Environment.NewLine,
            "|<sub>Learn Powershell Core 6.0</sub>|<sub>2018</sub>|<sub>736</sub>|<sub>2020-04-03</sub>|<sub>Packt</sub>|"
            );
        internal static string Table1_SmallerFontSizeFalse_OnlyHeader = string.Concat(
            "|BookTitle|Year|Pages|ReadDate|Publisher|",
            Environment.NewLine,
            "|---|---|---|---|---|"
            );
        internal static string Table1_SmallerFontSizeFalse_OnlyRow = string.Concat(
            "|Learn Powershell Core 6.0|2018|736|2020-04-03|Packt|"
            );
        internal static string Table1_SmallerFontSizeFalse_FullTable = string.Concat(
            "|BookTitle|Year|Pages|ReadDate|Publisher|",
            Environment.NewLine,
            "|---|---|---|---|---|",
            Environment.NewLine,
            "|Learn Powershell Core 6.0|2018|736|2020-04-03|Packt|"
            );
        #endregion
        
        #region Table2
        internal static Car Table2_Source_Object = new Car() { Name = "Dodge Ram", Wheels = 4 };
        internal static string Table2_SmallerFontSizeTrue_OnlyHeader = string.Concat(
            "|<sub>Name</sub>|<sub>Wheels</sub>|",
            Environment.NewLine,
            "|---|---|"
            );
        internal static string Table2_SmallerFontSizeTrue_OnlyRow = string.Concat(
            "|<sub>Dodge Ram</sub>|<sub>4</sub>|"
            );
        internal static string Table2_SmallerFontSizeTrue_FullTable = string.Concat(
            "|<sub>Name</sub>|<sub>Wheels</sub>|",
            Environment.NewLine,
            "|---|---|",
            Environment.NewLine,
            "|<sub>Dodge Ram</sub>|<sub>4</sub>|"
            );
        internal static string Table2_SmallerFontSizeFalse_OnlyHeader = string.Concat(
            "|Name|Wheels|",
            Environment.NewLine,
            "|---|---|"
            );
        internal static string Table2_SmallerFontSizeFalse_OnlyRow = string.Concat(
            "|Dodge Ram|4|"
            );
        internal static string Table2_SmallerFontSizeFalse_FullTable = string.Concat(
            "|Name|Wheels|",
            Environment.NewLine,
            "|---|---|",
            Environment.NewLine,
            "|Dodge Ram|4|"
            );
        #endregion
        
        #region Table3
        internal static List<Car> Table3_Source_Object = new List<Car>()
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
        internal static string Table3_SmallerFontSizeTrue_OnlyHeader = string.Concat(
            "|Name|Wheels|",
            "|---|---|"
            );
        internal static string Table3_SmallerFontSizeTrue_OnlyRow = string.Concat(
            "|Dodge Ram|4|",
            Environment.NewLine,
            "|Nissan Skyline|4|",
            Environment.NewLine,
            "|null|4|",
            Environment.NewLine,
            "|null|null|"
            );
        internal static string Table3_SmallerFontSizeTrue_FullTable = string.Concat(
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
        internal static string Table3_SmallerFontSizeFalse_OnlyHeader = string.Concat(
            "|<sub>Name</sub>|<sub>Wheels</sub>|",
            "|---|---|"
            );
        internal static string Table3_SmallerFontSizeFalse_OnlyRow = string.Concat(
            "|<sub>Dodge Ram</sub>|<sub>4</sub>|",
            Environment.NewLine,
            "|<sub>Nissan Skyline</sub>|<sub>4</sub>|",
            Environment.NewLine,
            "|<sub>null</sub>|<sub>4</sub>|",
            Environment.NewLine,
            "|<sub>null</sub>|<sub>null</sub>|"
            );
        internal static string Table3_SmallerFontSizeFalse_FullTable = string.Concat(
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

        internal static OutputOptions NonExistantOutputOption = (OutputOptions)(-1);

        // Methods (public)
        // Methods (private)

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 11.10.2020

*/
